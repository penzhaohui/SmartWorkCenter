using com.smartwork.Models;
using com.smartwork.Proxy;
using com.smartwork.Proxy.models;
using com.smartwork.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.JiraRestClient;

namespace com.smartwork
{
    public partial class CaseAnalysisReportForm : Form
    {
        public CaseAnalysisReportForm()
        {
            InitializeComponent();
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;
            this.btnSend.Enabled = false;

            // 1, Construct one case list from the specified case list
            // 1.1 Check if the case list formate is valid or not
            // 1.2 Construct one case list
            string caseIDs = this.txtInputCaseList.Text;
            List<string> caseIdList = new List<string>();

            if (String.IsNullOrEmpty(caseIDs) || caseIDs.Trim().Length == 0)
            {
                // Show one error message "ERROR: Please enter case id"
                (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Please enter case id");

                this.btnSync.Enabled = true;
                this.btnSend.Enabled = true;

                return;
            }
            else
            {
                (this.MdiParent as MainForm).ShowStatusMessage("");

                string[] caseIDArray = caseIDs.Split(',');
                Regex reg = new Regex(@"\d{2}ACC-\d{5}");
                foreach (string caseId in caseIDArray)
                {
                    if (reg.IsMatch(caseId))
                    {
                        if (!caseIdList.Contains(caseId.Trim()))
                        {
                            caseIdList.Add(caseId.Trim());
                        }
                    }
                    else
                    {
                        // Show one error message "ERROR: Invalid Format for XXXX"
                        (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Invalid Format for " + caseId);

                        this.btnSync.Enabled = true;
                        this.btnSend.Enabled = true;

                        return;
                    }
                }
            }

            List<string> DevNameList = null;
            List<string> QANameList = SalesforceProxy.GetQAReviewerNamesList();
            QANameList = SalesforceProxy.GetSupportQAList();
            DevNameList = SalesforceProxy.GetSupportDevList();
            Dictionary<string, string> Reviewers = SalesforceProxy.GetReviewerNamesList();

            var caseList = new List<CaseAnalysisInfo>();
            var issueList = new List<Issue>();

            int N = 1;
            for (int i = 0; i < caseIdList.Count; )
            {
                List<string> caseIdListTemp = new List<string>();
                for (; i < N * 100 && i < caseIdList.Count; i++)
                {
                    caseIdListTemp.Add(caseIdList[i]);
                }

                N = N + 1;

                var GetCaseList = SalesforceProxy.GetCaseList(caseIdListTemp, false);
                var GetIssueList = JiraProxy.GetIssueList(caseIdListTemp);

                var caseListTmp = await GetCaseList;
                var issueListTmp = await GetIssueList;

                Dictionary<string, CaseAnalysisInfo> JIRAMapper = new Dictionary<string, CaseAnalysisInfo>();
                foreach (var issue in issueListTmp)
                {
                    CaseAnalysisInfo caseAnalysisInfo = new CaseAnalysisInfo();
                    caseAnalysisInfo.SFID = issue.fields.customfield_10600;
                    caseAnalysisInfo.JiraKey = issue.key;
                    caseAnalysisInfo.IssueCategory = (issue.fields.customfield_11502 != null && issue.fields.customfield_11502.Count > 0 ? issue.fields.customfield_11502[0].value : "NONE");
                    if (!JIRAMapper.ContainsKey(issue.fields.customfield_10600))
                    {
                        JIRAMapper.Add(issue.fields.customfield_10600, caseAnalysisInfo);
                    }
                }
                foreach (var caseInfo in caseListTmp)
                {
                    Dictionary<DateTime, string> CommentHistories = new Dictionary<DateTime, string>();
                    bool isFound = false;
                    int sfCommentCount = 0;
                    int sfDevCommentCount = 0;
                    int sfQACommentCount = 0;

                    if (caseInfo.CaseComments != null && caseInfo.CaseComments.Records  != null && caseInfo.CaseComments.Records.Count > 0)
                    {
                        foreach (CaseComment comment in caseInfo.CaseComments.Records)
                        {
                            if (comment == null
                                || comment.CommentBody == null
                                || comment.LastModifiedDate.Year != 2016
                                || comment.LastModifiedDate.Month < 4)
                            {
                                continue;
                            }

                            string assignee = "";                           

                            foreach (var key in Reviewers.Keys)
                            {
                                string value = Reviewers[key];
                                string value1 = value.Replace('.', ' ');
                                if (comment.CommentBody.ToUpper().EndsWith(key.ToUpper())
                                    || comment.CommentBody.ToUpper().EndsWith(value.ToUpper())
                                    || comment.CommentBody.ToUpper().EndsWith(value1.ToUpper())
                                    || comment.LastModifiedBy.Name.ToUpper().StartsWith(value.ToUpper())
                                    || comment.LastModifiedBy.Name.ToUpper().StartsWith(value1.ToUpper()))
                                {
                                    isFound = true;
                                    sfCommentCount++;
                                    assignee = Reviewers[key];                                    
                                    if (QANameList.Contains(assignee))
                                    {
                                        sfQACommentCount++;
                                    }
                                    
                                    if (DevNameList.Contains(assignee))
                                    {
                                        sfDevCommentCount++;
                                    }

                                    CommentHistories.Add(comment.LastModifiedDate, assignee);
                                    break;
                                }
                            }       
                        }
                    }

                    if (isFound)
                    {
                        CaseAnalysisInfo caseAnalysisInfo = ConstructCaseAnalysisInfoModel(caseInfo, sfCommentCount, sfDevCommentCount, sfQACommentCount, CommentHistories);

                        if (JIRAMapper.ContainsKey(caseAnalysisInfo.SFID))
                        {
                            CaseAnalysisInfo tempCaseAnalysisInfo = JIRAMapper[caseAnalysisInfo.SFID];
                            caseAnalysisInfo.JiraKey = tempCaseAnalysisInfo.JiraKey;
                            caseAnalysisInfo.IssueCategory = tempCaseAnalysisInfo.IssueCategory;
                        }

                        caseList.Add(caseAnalysisInfo);
                    }
                    else
                    {
                        System.Console.WriteLine("Skip " + caseInfo.CaseNumber);
                    }
                }
                
                //issueList.AddRange(issueListTmp);
            }

            DataTable table = new DataTable("Case Analysis Report");            
            table.Columns.Add("No", typeof(int));           
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("SalesforceID", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("SFCaseCommentCount", typeof(int));
            table.Columns.Add("SFDevCaseCommentCount", typeof(int));
            table.Columns.Add("SFQACaseCommentCount", typeof(int));
            table.Columns.Add("Customer", typeof(string));
            table.Columns.Add("Severity", typeof(string));
            table.Columns.Add("Version", typeof(string));
            table.Columns.Add("OpenDate", typeof(string));
            table.Columns.Add("Summary", typeof(string));
            table.Columns.Add("CommentHistories", typeof(Dictionary<DateTime, string>));
            table.Columns.Add("IssueCategory", typeof(string));           
            table.Columns.Add("SFQueue", typeof(string));
            table.Columns.Add("SFStatus", typeof(string));

            int index = 1;
            foreach (CaseAnalysisInfo caseAnalysisInfo in caseList)
            {
                DataRow row = table.NewRow();
                row["No"] = index;
                row["Product"] = caseAnalysisInfo.Product;
                row["SalesforceID"] = caseAnalysisInfo.SFID;
                row["JiraKey"] = caseAnalysisInfo.JiraKey;
                row["SFCaseCommentCount"] = caseAnalysisInfo.SFCaseCommentCount;
                row["SFDevCaseCommentCount"] = caseAnalysisInfo.SFDevCaseCommentCount;
                row["SFQACaseCommentCount"] = caseAnalysisInfo.SFQACaseCommentCount;
                row["Customer"] = caseAnalysisInfo.Customer;
                row["Severity"] = caseAnalysisInfo.Severity;
                row["Version"] = caseAnalysisInfo.Version;
                row["OpenDate"] = caseAnalysisInfo.OpenDate;
                row["Summary"] = caseAnalysisInfo.Summary;
                row["CommentHistories"] = caseAnalysisInfo.CommentHistories;
                row["IssueCategory"] = caseAnalysisInfo.IssueCategory;
                row["SFQueue"] = caseAnalysisInfo.SFQueue;
                row["SFStatus"] = caseAnalysisInfo.SFStatus;

                table.Rows.Add(row);
                index++;
            }

            DataView dataTableView = table.DefaultView;
            dataTableView.Sort = "SalesforceID ASC";
            table = dataTableView.ToTable();

            grdCaseList.AutoGenerateColumns = false;
            grdCaseList.DataSource = table;

                       
            this.btnSync.Enabled = true;
            this.btnSend.Enabled = true;
        }

        private CaseAnalysisInfo ConstructCaseAnalysisInfoModel(AccelaCase caseInfo, int SFCaseCommentCount, int SFDevCaseCommentCount, int SFQACaseCommentCount, Dictionary<DateTime, string> CommentHistories)
        {
            CaseAnalysisInfo caseAnalysisInfo = new CaseAnalysisInfo();
            caseAnalysisInfo.Product = caseInfo.Product;
            caseAnalysisInfo.SFID = caseInfo.CaseNumber;
            caseAnalysisInfo.JiraKey = String.Empty;
            caseAnalysisInfo.SFCaseCommentCount = SFCaseCommentCount;
            caseAnalysisInfo.SFDevCaseCommentCount = SFDevCaseCommentCount;
            caseAnalysisInfo.SFQACaseCommentCount = SFQACaseCommentCount;

            string customer = (caseInfo.Customer != null && !String.IsNullOrEmpty(caseInfo.Customer.Name) ? caseInfo.Customer.Name : (caseInfo.Account != null ? caseInfo.Account.Name : ""));
            if (customer.IndexOf("Accela") >= 0 && caseInfo.Account != null && !String.IsNullOrEmpty(caseInfo.Account.Name))
            {
                customer = caseInfo.Account.Name;
            }

            caseAnalysisInfo.Customer = customer;

            caseAnalysisInfo.Severity = caseInfo.Priority;
            caseAnalysisInfo.Version = caseInfo.CurrentVersion;
            caseAnalysisInfo.OpenDate = caseInfo.CreatedDate.ToShortDateString();
            caseAnalysisInfo.Summary = caseInfo.Subject;
            caseAnalysisInfo.SFQueue = caseInfo.Owner.Name;
            caseAnalysisInfo.SFStatus = caseInfo.Status;
            caseAnalysisInfo.CommentHistories = CommentHistories;

            return caseAnalysisInfo;
        }

        class CaseAnalysisInfo
        {
            public string Product { get; set; }
            public string SFID { get; set; }
            public string JiraKey { get; set; }
            public string IssueCategory { get; set; }
            public int SFCaseCommentCount { get; set; }
            public int SFDevCaseCommentCount { get; set; }
            public int SFQACaseCommentCount { get; set; }
            public string Severity { get; set; }
            public string Version { get; set; }
            public string Customer { get; set; }
            public string OpenDate { get; set; }
            public string Summary { get; set; }
            public string SFQueue { get; set; }
            public string SFStatus { get; set; }
            public Dictionary<DateTime, string> CommentHistories { get; set; }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.btnSend.Enabled = false;

            DataTable dataTable = this.grdCaseList.DataSource as DataTable;

            DataView dataTableView = dataTable.DefaultView;
            dataTable = dataTableView.ToTable();

            string dailyCaseSummary = "";
            dailyCaseSummary = @"<table cellspacing='1px' cellpadding='1px' border='1px' style='border-color:black;font-size:14px'>
                                    <tr>
                                        <th align='center'>No</th>
                                        <th align='center'>Product</th>                                       
                                        <th align='center'>Salesforce ID</th>
                                        <th align='center'>Jira Key</th> 
                                        <th align='center'>Issue Category</th> 
                                        <th align='center'>SFCaseCommentCount</th>
                                        <th align='center'>SFDevCaseCommentCount</th>
                                        <th align='center'>SFQACaseCommentCount</th>
                                        <th align='center'>Severity</th>
                                        <th align='center'>Version</th>
                                        <th align='center'>Customer</th>
                                        <th align='left'>Open Date</th>
                                        <th align='center'>Summary</th>                                     
                                        <th align='left'>SFQueue</th>
                                        <th align='left'>SF Status</th>
                                        <th align='left'>Review History</th>   
                                    </tr>";

            int count = 0;
            if (dataTable != null)
            {
                int no = 0;
                string product = "";
                string sfID = "";
                string jiraKey = "";
                string issueCategory = "";
                int sfCaseCommentCount = 0;
                int sfDevCaseCommentCount = 0;
                int sfQACaseCommentCount = 0;
                string severity = "";
                string version = "";
                string customer = "";
                string openDate = "";
                string summary = "";
                string sfQueue = "";
                string sfStatus = "";
                Dictionary<DateTime, string> commentHistories = null;
                string histoicalComments = null;

                int rowCount = dataTable.Rows.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    no = int.Parse(row["No"].ToString());
                    product = row["Product"].ToString();
                    sfID = row["SalesforceID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    issueCategory = row["IssueCategory"] as string;
                    sfCaseCommentCount = int.Parse(row["SFCaseCommentCount"].ToString());
                    sfDevCaseCommentCount = int.Parse(row["SFDevCaseCommentCount"].ToString());
                    sfQACaseCommentCount = int.Parse(row["SFQACaseCommentCount"].ToString());
                    severity = row["Severity"] as string;
                    version = row["Version"] as string;
                    customer = row["Customer"] as string;
                    openDate = row["OpenDate"] as string;
                    summary = row["Summary"] as string;
                    sfQueue = row["SFQueue"] as string;
                    sfStatus = row["SFStatus"] as string;
                    commentHistories = row["CommentHistories"] as Dictionary<DateTime, string>;

                    histoicalComments = "";
                    foreach (DateTime key in commentHistories.Keys)
                    {
                        histoicalComments += key.ToLongDateString() + " -- " + commentHistories[key] + "<br/>";
                    }

                    histoicalComments = "";

                    dailyCaseSummary += String.Format(@"<tr>
                                                        <td align='center'>{0}</td>
                                                        <td align='center'>{1}</td>
                                                        <td align='center'>{2}</td>
                                                        <td align='center'>{3}</td>
                                                        <td align='center'>{4}</td>
                                                        <td align='center'>{5}</td>
                                                        <td align='center'>{6}</td>
                                                        <td align='left'>{7}</td>
                                                        <td align='center'>{8}</td>
                                                        <td align='left'>{9}</td>
                                                        <td align='center'>{10}</td>
                                                        <td align='center'>{11}</td>
                                                        <td align='center'>{12}</td>
                                                        <td align='center'>{13}</td>
                                                        <td align='left'>{14}</td>
                                                    </tr>",
                                                       ++count, // 0 - No
                                                       product, // 1 - Product
                                                       sfID, // 2 - Salesforce ID
                                                       jiraKey, // 3 - Jira Key
                                                       issueCategory, // 4 - Jira Key
                                                       sfCaseCommentCount, // 5, SF Case Comment Count
                                                       sfDevCaseCommentCount, // 6, SF Dev Case Comment Count
                                                       sfQACaseCommentCount, // 7, SF QA Case Comment Count
                                                       severity, // 8 - Severity
                                                       version, // 9 - Version                                                       
                                                       customer, // 10 - Customer
                                                       openDate, // 11 - Open Date
                                                       summary, // 12 - Summary
                                                       sfQueue, // 13 - Dev Ratio
                                                       sfStatus, // 14 - SF Status
                                                       histoicalComments
                                                       );
                }
            }

            dailyCaseSummary += "</table>";

            if (count == 0)
            {
                this.btnSend.Enabled = true;
                return;
            }

            string content = @"Hi, All guys<br/><br/>Below is the case analysis report. Just for reference!<br/><br/>" + dailyCaseSummary + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";
            string to = "peter.peng@missionsky.com";
            string cc = "";
            string subject = "The Case Analysis Summary - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

            try
            {
                EmailUtil.SendEmail(from, to, cc, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSend.Enabled = true;
        }
    }
}
