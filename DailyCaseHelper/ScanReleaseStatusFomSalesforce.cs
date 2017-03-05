using com.smartwork.Models;
using com.smartwork.Proxy;
using com.smartwork.Proxy.models;
using com.smartwork.Util;
using Salesforce.Force;
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
    public partial class ScanReleaseStatusFomSalesforce : Form
    {
        public ScanReleaseStatusFomSalesforce()
        {
            InitializeComponent();

            InitializeForm();
        }

        /// <summary>
        /// Initialize the form while loading
        /// </summary>
        private async void InitializeForm()
        {
            this.btnSyncWithJiraAndSF.Enabled = false;
            this.btnSendSummaryReport.Enabled = false;
            
            Task<IForceClient> createAuthenticationClient = SalesforceProxy.CreateAuthenticationClient();
            IForceClient client = await createAuthenticationClient;
            if (client != null)
            {
                this.btnSyncWithJiraAndSF.Enabled = true;
                this.btnSendSummaryReport.Enabled = true;
            }
        }

        private async void btnSyncWithJiraAndSF_Click(object sender, EventArgs e)
        {
            this.btnSendSummaryReport.Enabled = false;
            this.btnSyncWithJiraAndSF.Enabled = false;

            List<string> problemCaseIDList = new List<string>();

            // 1, Construct one case list from the specified case list
            // 1.1 Check if the case list formate is valid or not
            // 1.2 Construct one case list
            string caseIDs = this.txtCaseIDList.Text;
            List<string> caseIdList = new List<string>();

            if (String.IsNullOrEmpty(caseIDs) || caseIDs.Trim().Length == 0)
            {
                // Show one error message "ERROR: Please enter case id"
                (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Please enter case id");

                this.btnSendSummaryReport.Enabled = true;
                this.btnSyncWithJiraAndSF.Enabled = true;

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

                        this.btnSendSummaryReport.Enabled = true;
                        this.btnSyncWithJiraAndSF.Enabled = true;

                        return;
                    }
                }
            }

            var caseList = new List<AccelaCase>();
            var issueList = new List<Issue>();

            int N = 1;
            for (int i = 0; i < caseIdList.Count; )
            {
                List<string> caseIdListTemp = new List<string>();
                for (; i < N * 50 && i < caseIdList.Count; i++)
                {
                    caseIdListTemp.Add(caseIdList[i]);
                }

                N = N + 1;

                var GetCaseList = SalesforceProxy.GetCaseList(caseIdListTemp);
                var GetIssueList = JiraProxy.GetIssueList(caseIdListTemp);

                var caseListTmp = await GetCaseList;
                var issueListTmp = await GetIssueList;

                if (caseIdListTemp.Count != caseListTmp.Count)
                {
                    foreach (var tempCase in caseListTmp)
                    {
                        string caseID = tempCase.CaseNumber;
                        if (caseIdListTemp.Contains(caseID))
                        {
                            caseIdListTemp.Remove(caseID);
                        }                       
                    }

                    problemCaseIDList.AddRange(caseIdListTemp);                    
                }
                caseList.AddRange(caseListTmp);
                issueList.AddRange(issueListTmp);
            }

            if (problemCaseIDList != null && problemCaseIDList.Count > 0)
            {
                System.Console.WriteLine("Below case id are lost.");
                foreach (string lostCaseId in problemCaseIDList)
                {
                    System.Console.WriteLine(lostCaseId);
                }
            }

            Dictionary<string, AccelaIssueCaseMapper> JiraMapping = new Dictionary<string, AccelaIssueCaseMapper>();
            foreach (var issue in issueList)
            {
                if (!JiraMapping.ContainsKey(issue.fields.customfield_10600))
                {
                    AccelaIssueCaseMapper accelaIssueCaseMapper = new AccelaIssueCaseMapper();
                    accelaIssueCaseMapper.CaseNumber = issue.fields.customfield_10600;
                    accelaIssueCaseMapper.Assignee = (issue.fields.assignee == null ? "" : issue.fields.assignee.displayName);
                    accelaIssueCaseMapper.AssigneeQA = (issue.fields.customfield_11702 == null ? "" : issue.fields.customfield_11702.displayName);
                    accelaIssueCaseMapper.JiraId = issue.id;
                    accelaIssueCaseMapper.JiraKey = issue.key;
                    accelaIssueCaseMapper.IssueCategory = (issue.fields.customfield_11502 != null && issue.fields.customfield_11502.Count > 0 ? issue.fields.customfield_11502[0].value : "--NONE--");
                    accelaIssueCaseMapper.LastModified = issue.fields.customfield_10903;
                    accelaIssueCaseMapper.Status = issue.fields.status.name;
                    accelaIssueCaseMapper.HotCase = issue.fields.labels.Contains("HotCase");
                    accelaIssueCaseMapper.Missionsky = issue.fields.labels.Contains("Missionsky");
                    accelaIssueCaseMapper.JiraLabels = issue.fields.labels;
                    accelaIssueCaseMapper.FixVersions = new List<string>();
                   
                    if (issue.fields.fixVersions != null)
                    {                        
                        foreach (var fixVersion in issue.fields.fixVersions)
                        {
                            accelaIssueCaseMapper.FixVersions.Add(fixVersion.name);
                        }
                    }

                    JiraMapping.Add(accelaIssueCaseMapper.CaseNumber, accelaIssueCaseMapper);
                }
            }

            DataTable table = new DataTable("Daily Report");
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("HotCase", typeof(bool));
            table.Columns.Add("Missionsky", typeof(bool));
            table.Columns.Add("JiraLabels", typeof(List<string>));
            table.Columns.Add("ProductForUI", typeof(string));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Solution", typeof(string));
            table.Columns.Add("Orgin", typeof(string));
            table.Columns.Add("OpenDate", typeof(string));
            table.Columns.Add("Severity", typeof(string));
            table.Columns.Add("Rank", typeof(int));
            table.Columns.Add("SalesforceID", typeof(string));
            table.Columns.Add("JiraID", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Version", typeof(string));
            table.Columns.Add("Customer", typeof(string));
            table.Columns.Add("Summary", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Reviewer", typeof(string));
            table.Columns.Add("Comments", typeof(string));
            table.Columns.Add("ReopenedCount", typeof(string));
            table.Columns.Add("JiraStatus", typeof(string));
            table.Columns.Add("NextJiraStatus", typeof(string));
            table.Columns.Add("SFQueue", typeof(string));
            table.Columns.Add("SFStatus", typeof(string));
            table.Columns.Add("SFLastModified", typeof(string));
            table.Columns.Add("CaseComment", typeof(CaseComment));
            table.Columns.Add("FixVersions", typeof(string));
            table.Columns.Add("ReleaseInfo", typeof(string));
            table.Columns.Add("TargetedRelease", typeof(string));
            table.Columns.Add("InternalType", typeof(string));
            table.Columns.Add("EngineeringStatus", typeof(string));
            table.Columns.Add("BZID", typeof(string));
            table.Columns.Add("IssueCategory", typeof(string));
            table.Columns.Add("Assignee", typeof(string));
            table.Columns.Add("AssigneeQA", typeof(string));
            table.Columns.Add("CaseComments", typeof(List<CaseComment>));

            Dictionary<string, string> Reviewers = SalesforceProxy.GetReviewerNamesList();

            int index = 1;
            AccelaIssueCaseMapper tempIssue = null;
            string openDate = "";
            string jiraKey = "";
            string jiraId = "";
            string customer = "";
            string assignee = "";
            int reopenCount = 0;
            string jiaStstus = "";
            string[] Severity = null;
            string temComment = "";
            string lastModifiedDate = "";

            int rank = 0;

            foreach (var caseinfo in caseList)
            {
                tempIssue = null;
                if (JiraMapping.ContainsKey(caseinfo.CaseNumber))
                {
                    tempIssue = JiraMapping[caseinfo.CaseNumber];
                }

                if (caseinfo.ReleaseInfo != null)
                {
                    //SalesforceProxy.GetReleaseInfoById(caseinfo.ReleaseInfo);
                }

                DataRow row = table.NewRow();
                row["ID"] = caseinfo.Id;
                row["No"] = index;
                row["HotCase"] = (tempIssue != null && tempIssue.HotCase);
                row["Missionsky"] = (tempIssue != null && tempIssue.Missionsky);
                row["JiraLabels"] = (tempIssue != null ? tempIssue.JiraLabels : null);
                row["IssueCategory"] = (tempIssue != null ? tempIssue.IssueCategory : null);
                row["Assignee"] = (tempIssue != null ? tempIssue.Assignee : null);
                row["AssigneeQA"] = (tempIssue != null ? tempIssue.AssigneeQA : null);
                //row["HotCase"] = true;
                row["ProductForUI"] = AccelaCaseUtil.AdjustProductName(caseinfo.Product, caseinfo.Solution, caseinfo.Subject, caseinfo.Description);
                row["Product"] = caseinfo.Product;
                row["Solution"] = caseinfo.Solution;
                row["Orgin"] = caseinfo.Origin;
                //openDate = caseinfo.CreatedDate.ToShortDateString();
                openDate = (caseinfo.CreatedDate.Month < 10 ? "0" + caseinfo.CreatedDate.Month : "" + caseinfo.CreatedDate.Month)
                           + "/" + (caseinfo.CreatedDate.Day < 10 ? "0" + caseinfo.CreatedDate.Day : "" + caseinfo.CreatedDate.Day)
                           + "/" + ("" + caseinfo.CreatedDate.Year);

                row["OpenDate"] = openDate;
                Severity = caseinfo.Priority.Split(' ');
                row["Severity"] = Severity[1];

                rank = 0;
                if (!String.IsNullOrEmpty(caseinfo.RankOrder))
                {
                    rank = int.Parse(caseinfo.RankOrder);
                }
                else if (!String.IsNullOrEmpty(caseinfo.ServicesRank))
                {
                    rank = int.Parse(caseinfo.ServicesRank);
                }
                else
                {
                    rank = 0;
                }

                row["Rank"] = rank;

                row["SalesforceID"] = caseinfo.CaseNumber;
                jiraKey = (tempIssue != null ? tempIssue.JiraKey : "");
                jiraId = (tempIssue != null ? tempIssue.JiraId : "");
                row["JiraKey"] = jiraKey;
                row["JiraID"] = jiraId;
                row["Type"] = (String.IsNullOrEmpty(caseinfo.InternalType) ? caseinfo.Type : "Production " + caseinfo.InternalType);
                row["Version"] = caseinfo.CurrentVersion;
                customer = (caseinfo.Customer != null && !String.IsNullOrEmpty(caseinfo.Customer.Name) ? caseinfo.Customer.Name : (caseinfo.Account != null ? caseinfo.Account.Name : ""));
                if (customer.IndexOf("Accela") >= 0 && caseinfo.Account != null && !String.IsNullOrEmpty(caseinfo.Account.Name))
                {
                    customer = caseinfo.Account.Name;
                }

                row["Customer"] = customer;
                row["Summary"] = caseinfo.Subject;
                row["Description"] = caseinfo.Description;
                assignee = (tempIssue != null ? tempIssue.Assignee : "");

                temComment = "";

                //lastModifiedDate = DateTime.Now.Year + "-" + (DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month : "" + DateTime.Now.Month) + "-" + (DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day : "" + DateTime.Now.Day);
                DateTime Yesterday = DateTime.Now.AddDays(-1);
                lastModifiedDate = Yesterday.Year + "-" + Yesterday.Month + "-" + Yesterday.Day;
                if (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null)
                {
                    row["CaseComments"] = caseinfo.CaseComments.Records;

                    CaseComment comment = caseinfo.CaseComments.Records[0];
                    //lastModifiedDate = comment.CreatedDate.Year + "-" + (comment.CreatedDate.Month < 10 ? "0" + comment.CreatedDate.Month : "" + comment.CreatedDate.Month) + "-" + (comment.CreatedDate.Day < 10 ? "0" + comment.CreatedDate.Day : "" + comment.CreatedDate.Day);
                    if (DateTime.Now.Year != comment.CreatedDate.Year
                        && DateTime.Now.Month != comment.CreatedDate.Month
                        && DateTime.Now.Day != comment.CreatedDate.Day)
                    {
                        lastModifiedDate = comment.CreatedDate.Year + "-" + comment.CreatedDate.Month + "-" + comment.CreatedDate.Day;
                    }

                    row["CaseComment"] = comment;

                    if (!String.IsNullOrEmpty(comment.CommentBody))
                    {
                        if (comment.CommentBody.ToUpper().IndexOf("BUB") > 0)
                        {
                            temComment += "This is a bug.<br>";
                        }

                        if (comment.CommentBody.ToUpper().IndexOf("DEFECT") > 0)
                        {
                            temComment += "This is a defect.<br>";
                        }
                    }

                    if (!String.IsNullOrEmpty(assignee) && comment.CommentBody.ToUpper().Contains(assignee.ToUpper()))
                    {
                    }
                    else
                    {
                        foreach (var key in Reviewers.Keys)
                        {
                            string value = Reviewers[key];
                            string value1 = value.Replace('.', ' ');
                            if (comment.CommentBody.ToUpper().EndsWith(key.ToUpper())
                                || comment.CommentBody.ToUpper().EndsWith(value.ToUpper())
                                || comment.CommentBody.ToUpper().EndsWith(value1.ToUpper()))
                            {
                                assignee = Reviewers[key];
                                break;
                            }
                        }
                    }
                }

                row["Reviewer"] = assignee;
                row["Comments"] = temComment;
                reopenCount = (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null ? caseinfo.CaseComments.Records.Count - 1 : 0);
                row["ReopenedCount"] = reopenCount;
                jiaStstus = (tempIssue != null ? tempIssue.Status : "");
                row["JiraStatus"] = jiaStstus;
                row["SFQueue"] = caseinfo.Owner.Name;
                row["SFStatus"] = caseinfo.Status;

                bool isCommentedToday = false;
                if (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null)
                {
                    CaseComment comment = caseinfo.CaseComments.Records[0];

                    isCommentedToday = (comment.CreatedDate.Year == DateTime.Now.Year && comment.CreatedDate.Month == DateTime.Now.Month && comment.CreatedDate.Day == DateTime.Now.Day ? true : false);
                }

                row["NextJiraStatus"] = AccelaCaseUtil.GetNextJIRAStatus(caseinfo.Owner.Name, caseinfo.Status, jiaStstus, isCommentedToday);
                row["SFLastModified"] = lastModifiedDate;
                if (tempIssue != null && String.IsNullOrEmpty(tempIssue.LastModified))
                {
                    System.Console.WriteLine("Last Modified Date is empty");
                }

                if (tempIssue != null && tempIssue.FixVersions != null)
                {
                    bool isFirst = true;
                    foreach (var fixVersion in tempIssue.FixVersions)
                    {
                        if (isFirst)
                        {
                            row["FixVersions"] = fixVersion;
                            isFirst = false;
                        }
                        else
                        {
                            row["FixVersions"] += "," + fixVersion;
                        }
                    }
                }

                row["ReleaseInfo"] = caseinfo.ReleaseInfo;
                row["TargetedRelease"] = caseinfo.TargetedRelease;
                row["BZID"] = caseinfo.BZID;
                row["InternalType"] = caseinfo.InternalType;
                row["EngineeringStatus"] = caseinfo.EngineeringStatus;

                table.Rows.Add(row);
                index++;
            }

            grdCaseList.AutoGenerateColumns = false;
            grdCaseList.DataSource = table;



            this.btnSendSummaryReport.Enabled = true;
            this.btnSyncWithJiraAndSF.Enabled = true;
        }

        private void btnSendSummaryReport_Click(object sender, EventArgs e)
        {
            this.btnSendSummaryReport.Enabled = false;

            DataTable dataTable = this.grdCaseList.DataSource as DataTable;

            string caseStatusSummary = "";
            caseStatusSummary = @"<table cellspacing='1px' cellpadding='1px' border='1px' style='border-color:black;font-size:14px'>
                                    <tr>
                                        <th align='center'>No</th> 
                                        <th align='left'>Product</th> 
                                        <th align='left'>Salesforce ID</th> 
                                        <th align='center'>Jira Key</th> 
                                        <th align='center'>Severity</th> 
                                        <th align='center'>Version</th> 
                                        <th align='center'>Type</th> 
                                        <th align='left'>Customer</th> 
                                        <th align='center'>Original</th> 
                                        <th align='center'>Open Date</th> 
                                        <th align='left'>Summary</th> 
                                        <th align='center'>Reviewer</th> 
                                        <th align='center'>Jira Assignee</th> 
                                        <th align='center'>Jira Assignee QA</th> 
                                        <th align='center'>Jira Status</th> 
                                        <th align='center'>SF Queue</th> 
                                        <th align='center'>SF Status</th> 
                                        <th align='center'>SF Internal Type</th> 
                                        <th align='center'>SF Engineering Status</th> 
                                        <th align='center'>SF BZID</th> 
                                        <th align='left'>SF Release Info</th> 
                                        <th align='left'>SF Targeted Release</th> 
                                        <th align='left'>Jira Fix Versions</th>
                                    </tr>";

            int count = 0;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;

                string product = "";
                string salesforceID = "";
                string jiraKey = "";
                string severity = "";
                string version = "";
                string type = "";
                string customer = "";
                string original = "";
                string openDate = "";
                string summary = "";
                string reviewer = "";
                string jiraAssignee = "";
                string jiraAssigneeQA = "";
                string jiraStatus = "";
                string sfQueue = "";
                string sfStatus = "";
                string sfInternalType = "";
                string sfEngineeringStatus = "";
                string sfBZID = "";
                string sfReleaseInfo = "";
                string sfTargetedRelease = "";
                string jiraFixVersions = "";

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    product = row["Product"] as string;
                    salesforceID = row["SalesforceID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    severity = row["Severity"] as string;
                    version = row["Version"] as string;
                    type = row["Type"] as string;
                    customer = row["Customer"] as string;
                    original = row["Orgin"] as string;
                    openDate = row["OpenDate"] as string;
                    summary = row["Summary"] as string;
                    reviewer = row["Reviewer"] as string;
                    jiraAssignee = row["Assignee"] as string;
                    jiraAssigneeQA = row["AssigneeQA"] as string;
                    jiraStatus = row["JiraStatus"] as string;
                    sfQueue = row["SFQueue"] as string;
                    sfStatus = row["SFStatus"] as string;
                    sfInternalType = row["InternalType"] as string;
                    sfEngineeringStatus = row["EngineeringStatus"] as string;
                    sfBZID = row["BZID"] as string;
                    sfReleaseInfo = row["ReleaseInfo"] as string;
                    sfTargetedRelease = row["TargetedRelease"] as string;
                    jiraFixVersions = row["FixVersions"] as string;

                    count++;

                    caseStatusSummary += String.Format(@"<tr>
                                                        <td align='center'>{0}</td>
                                                        <td align='center'>{1}</td>
                                                        <td align='center'>{2}</td>
                                                        <td align='center'>{3}</td>
                                                        <td align='center'>{4}</td>
                                                        <td align='center'>{5}</td>
                                                        <td align='center'>{6}</td>
                                                        <td align='left'>{7}</td>
                                                        <td align='center'>{8}</td>
                                                        <td align='center'>{9}</td>
                                                        <td align='center'>{10}</td>    
                                                        <td align='center'>{11}</td>
                                                        <td align='center'>{12}</td>
                                                        <td align='center'>{13}</td>
                                                        <td align='center'>{14}</td>
                                                        <td align='center'>{15}</td>
                                                        <td align='center'>{16}</td>
                                                        <td align='center'>{17}</td>
                                                        <td align='center'>{18}</td>
                                                        <td align='left'>{19}</td>
                                                        <td align='left'>{20}</td>
                                                        <td align='center'>{21}</td>
                                                        <td align='center'>{22}</td>
                                                    </tr>",
                                                       i,
                                                       product,
                                                       salesforceID,
                                                       jiraKey,
                                                       severity,
                                                       version,
                                                       type,
                                                       customer,
                                                       original,
                                                       openDate,
                                                       summary,
                                                       reviewer,
                                                       jiraAssignee,
                                                       jiraAssigneeQA,
                                                       jiraStatus,
                                                       sfQueue,
                                                       sfStatus,
                                                       sfInternalType,
                                                       sfEngineeringStatus,
                                                       sfBZID,
                                                       sfReleaseInfo,
                                                       sfTargetedRelease,
                                                       jiraFixVersions
                                                       );
                }
            }
            caseStatusSummary += "</table>";

            if (count == 0)
            {
                this.btnSendSummaryReport.Enabled = true;
                return;
            }

            string content = @"Hi, All guys<br/><br/>Some cases may be delivered already by other team, please inform the assignee QA to synchronize salesforce status cross the jira projects.<br/><br/>" + caseStatusSummary + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";
            string to = "peter.peng@missionsky.com;leo.liu@missionsky.com;abel.yu@missionsky.com";
            string cc = "rleung@accela.com";
            string subject = "Production Case List - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

            try
            {
                EmailUtil.SendEmail(from, to, cc, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSendSummaryReport.Enabled = true;
        }
    }
}
