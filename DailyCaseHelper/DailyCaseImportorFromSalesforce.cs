using com.smartwork.Business;
using com.smartwork.Model;
using com.smartwork.Proxy;
using com.smartwork.Util;
using Salesforce.Force;
using SimpleConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.smartwork.Proxy.models;
using com.smartwork.Models;
using TechTalk.JiraRestClient;

namespace com.smartwork
{
    public partial class DailyCaseImportorFromSalesforce : Form
    {
        private static Dictionary<string, AcccelaDBModel> AccelaDBMapper = new Dictionary<string, AcccelaDBModel>();

        public DailyCaseImportorFromSalesforce()
        {
            InitializeComponent();

            InitializeForm();

            DataGridViewComboBoxColumn comments = this.grdCaseList.Columns["Comments"] as DataGridViewComboBoxColumn;
            if (comments != null)
            {
                List<string> commentStyles = new List<string>();
                commentStyles.Add("Need More Info");
                commentStyles.Add("Question");
                commentStyles.Add("Non-Code Issue");
                commentStyles.Add("Code Issue");
                commentStyles.Add("Enhancement");
                comments.DataSource = commentStyles;
            }
        }

        /// <summary>
        /// Initialize the form while loading
        /// </summary>
        private async void InitializeForm()
        {
            this.btnSendDailyCaseSummaryReport.Enabled = false;
            this.btnSyncWithJiraAndSF.Enabled = false;
            this.btnTopNNewCase.Enabled = false;
            this.btnTopNCommentedCase.Enabled = false;
            this.btnShowHotCases.Enabled = false;
            this.btnShowScheduledCase.Enabled = false;
            this.btnShowPendingCases.Enabled = false;
            this.btnShowOpenCase.Enabled = false;

            this.Text = "Build Version: 2.6.3.0 - peter.peng@missionsky.com";

            this.DisplayTodayCaseList();
            Task<IForceClient> createAuthenticationClient = SalesforceProxy.CreateAuthenticationClient();
            IForceClient client = await createAuthenticationClient;
            if (client != null)
            {
                this.btnSyncWithJiraAndSF.Enabled = true;
                this.btnTopNNewCase.Enabled = true;
                this.btnTopNCommentedCase.Enabled = true;
                this.btnShowHotCases.Enabled = true;
                this.btnShowScheduledCase.Enabled = true;
                this.btnShowPendingCases.Enabled = true;
                this.btnShowOpenCase.Enabled = true;
            }

            try
            {
                AccelaDBMapper = AccelaDBUtil.GetAccelaDatabaseMapper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Export the case list from salesforce.com with the specified case list
        /// </summary>
        private async void btnSyncWithJiraAndSF_Click(object sender, EventArgs e)
        {
            this.btnSendDailyCaseSummaryReport.Enabled = false;
            this.btnSyncWithJiraAndSF.Enabled = false;

            // 1, Construct one case list from the specified case list
            // 1.1 Check if the case list formate is valid or not
            // 1.2 Construct one case list
            string caseIDs = this.txtCaseIDList.Text.Replace(",,", ",");
            List<string> caseIdList = new List<string>();

            if (String.IsNullOrEmpty(caseIDs) || caseIDs.Trim().Length == 0)
            {
                // Refresh Today Case List
                this.DisplayTodayCaseList();

                // Show one error message "ERROR: Please enter case id"
                (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Please enter case id");

                this.btnSendDailyCaseSummaryReport.Enabled = true;
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
                        if (caseId.Trim().Length == 0) continue;

                        // Show one error message "ERROR: Invalid Format for XXXX"
                        (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Invalid Format for " + caseId);

                        this.btnSendDailyCaseSummaryReport.Enabled = true;
                        this.btnSyncWithJiraAndSF.Enabled = true;

                        return;
                    }
                }
            }

            var caseList = new List<AccelaCase>();
            var issueList = new List<Issue>();

            int N = 1;
            for (int i=0; i < caseIdList.Count; )
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
                
                caseList.AddRange(caseListTmp);
                issueList.AddRange(issueListTmp);
            }

            Dictionary<string, AccelaIssueCaseMapper> JiraMapping = new Dictionary<string, AccelaIssueCaseMapper>();
            foreach (var issue in issueList)
            {
                if (!JiraMapping.ContainsKey(issue.fields.customfield_10600))
                {
                    AccelaIssueCaseMapper accelaIssueCaseMapper = new AccelaIssueCaseMapper();
                    accelaIssueCaseMapper.IssueType = issue.fields.issueType.name;
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

                    if (issue != null && issue.fields.fixVersions != null)
                    {
                        accelaIssueCaseMapper.FixVersions = new List<string>();
                        foreach (var fixVersion in issue.fields.fixVersions)
                        {
                            if (fixVersion != null)
                            {
                                accelaIssueCaseMapper.FixVersions.Add(fixVersion.name);
                            }
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
            table.Columns.Add("TargetedRelease", typeof(string));
            table.Columns.Add("BZID", typeof(string));
            table.Columns.Add("IssueCategory", typeof(string));
            table.Columns.Add("Assignee", typeof(string));
            table.Columns.Add("AssigneeQA", typeof(string));
            table.Columns.Add("CaseComments", typeof(List<CaseComment>));
            table.Columns.Add("FixVersions", typeof(List<string>));

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

            string newCaseList = String.Empty;
            foreach (var caseinfo in caseList)
            {
                tempIssue = null;
                if (JiraMapping.ContainsKey(caseinfo.CaseNumber))
                {
                    tempIssue = JiraMapping[caseinfo.CaseNumber];
                }

                // Only show new case
                if (this.chkOnlyNewCase.Checked)
                {
                    if(tempIssue != null) continue;

                    if (String.IsNullOrEmpty(newCaseList)) newCaseList = caseinfo.CaseNumber;
                    else newCaseList += "," + caseinfo.CaseNumber;
                }               

                DataRow row = table.NewRow();
                row["ID"] = caseinfo.Id;
                row["No"] = index;
                row["HotCase"] = (tempIssue != null && tempIssue.HotCase);
                row["Missionsky"] = (tempIssue != null && tempIssue.Missionsky);
                row["JiraLabels"] = (tempIssue != null ? tempIssue.JiraLabels : null);
                row["FixVersions"] = (tempIssue != null ? tempIssue.FixVersions : null);
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

                row["NextJiraStatus"] = AccelaCaseUtil.GetNextJIRAStatus(caseinfo.Owner.Name, caseinfo.Status, jiaStstus, isCommentedToday, (tempIssue == null ? "" : tempIssue.IssueType));
                row["SFLastModified"] = lastModifiedDate;
                if (tempIssue != null && String.IsNullOrEmpty(tempIssue.LastModified))
                {
                    System.Console.WriteLine("Last Modified Date is empty");
                }

                row["TargetedRelease"] = caseinfo.TargetedRelease;
                row["BZID"] = caseinfo.BZID;

                table.Rows.Add(row);
                index++;
            }

            DataView dataTableView = table.DefaultView;
            dataTableView.Sort = "Severity ASC";
            table = dataTableView.ToTable();

            grdCaseList.AutoGenerateColumns = false;
            grdCaseList.DataSource = table;

            // 2, Exclude the exported case
            // 2.1 Exclude those case which exists in database already
            CaseBusiness caseBusiness = new CaseBusiness();
            List<CaseModel> caseModelList = caseBusiness.BatchQuery(caseIdList);
            // 2.2 Construct one new case list

            // 3, Invoke Salesforce REST API            
            caseBusiness.ImportCasesFromSalesforce(caseIdList);
            // 4, Display today case list with the status value as "In Progress" or ""

            // Only show new case
            if (this.chkOnlyNewCase.Checked)
            {
                this.txtCaseIDList.Text = newCaseList;
            }

            this.chkOnlyNewCase.Checked = false;
            this.btnSendDailyCaseSummaryReport.Enabled = true;
            this.btnSyncWithJiraAndSF.Enabled = true;
        }

        /// <summary>
        /// Display today case list with the status value as "In Progress" or ""
        /// </summary>
        private void DisplayTodayCaseList()
        {
        }

        private void btnSendDailyCaseSummaryReport_Click(object sender, EventArgs e)
        {
            this.btnSendDailyCaseSummaryReport.Enabled = false;
            string dailyCaseSummary = "";
            dailyCaseSummary = @"<table cellspacing='1' cellpadding='1' border='0' bgcolor='111111' style='border-collapse:collapse;border-spacing:0;border-left:1px solid #888;border-top:1px solid #888;background:#efefef;'>
                                    <tr>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>No</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Product</th>                                       
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>SF#</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Jira#</th> 
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Severity</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Rank</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Version</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Type</th>
                                        <th align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Customer</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Orgin</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Open Date</th>    
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Reopened#</th>                                    
                                        <th align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Summary</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Reviewer</th>                                   
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Comments</th>
                                    </tr>";

            DataTable dataTable = grdCaseList.DataSource as DataTable;
            CaseComment caseComment = null;

            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string product = "";
                string caseNumber = "";
                string jiraKey = "";
                string priority = "";
                int rank = 0;
                string buildVersion = "";
                string type = "";
                string summary = "";
                string customer = "";
                string origin = "";
                string description = "";
                string openDate = "";
                string reopenCount = "";
                string assignee = "";
                string jiaStstus = "";
                string caseId = "";
                string comment = "";
                string caseCommentBody = "";
                bool isNeedDoubleReview = false;

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    product = row["ProductForUI"] as string;
                    caseNumber = row["SalesforceID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    priority = row["Severity"] as string;
                    rank = (int)row["Rank"];
                    buildVersion = row["Version"] as string;
                    type = row["IssueCategory"] as string;
                    if (String.IsNullOrEmpty(type))
                    {
                        //type = row["Type"] as string;
                        type = "";
                    }
                    customer = row["Customer"] as string;
                    origin = row["Orgin"] as string;
                    openDate = row["OpenDate"] as string;
                    reopenCount = row["ReopenedCount"] as string;
                    summary = row["Summary"] as string;
                    assignee = row["Reviewer"] as string;
                    jiaStstus = row["JiraStatus"] as string;
                    description = row["Description"] as string;
                    comment = row["Comments"] as string;
                    caseId = row["ID"] as string;

                    caseComment = row["CaseComment"] as CaseComment;
                    caseCommentBody = (caseComment != null ? caseComment.CommentBody : "");

                    isNeedDoubleReview = false;
                    if (!String.IsNullOrEmpty(caseCommentBody) && (caseCommentBody.ToLower().Contains("released")
                                                           || caseCommentBody.ToLower().Contains(" fix ")
                                                           || caseCommentBody.ToLower().Contains("released")
                                                           || caseCommentBody.ToLower().Contains("fixed")
                                                           || caseCommentBody.ToLower().Contains("bug")
                                                           || caseCommentBody.ToLower().Contains("missionsky")
                                                           || caseCommentBody.ToLower().Contains("asap")))
                    {
                        isNeedDoubleReview = true;
                    }

                    dailyCaseSummary += String.Format(@"<tr>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{0}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{1}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://na26.salesforce.com/{14}'><font style='{15}'>{2}</font></a></td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://accelaeng.atlassian.net/browse/{3}'>{3}</a></td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{4}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{16}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{5}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{6}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{7}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{8}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{9}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{10}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{11}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{12}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{13}</td>
                                                    </tr>",
                                                       (i + 1),         // 0
                                                       product,         // 1
                                                       caseNumber,      // 2
                                                       jiraKey,         // 3
                                                       priority,        // 4
                                                       buildVersion,
                                                       type,
                                                       customer,
                                                       origin,
                                                       openDate,
                                                       reopenCount,
                                                       summary,
                                                       assignee,
                                                       //jiaStstus,
                                                       comment,
                                                       caseId,
                                                       "", //(isNeedDoubleReview ? "font-weight:bold;font-style:italic;color:red" : "color:green")
                                                       (rank == 0 ? "" : "" + rank)
                                                       );
                }
            }
            dailyCaseSummary += "</table>";

            string content = @"Hi All,<br/><br/>Below is the Daily Case Review Summary report today. Please kindly let us know if you have any further question.<br/><br/>" + dailyCaseSummary + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";
            string to = "accela-support-team@missionsky.com";
            if (this.chkOnlyEmailMe.Checked)
            {
                to = "peter.peng@missionsky.com";
            }
            string cc = "peter.peng@missionsky.com;leo.liu@missionsky.com;louis.he@missionsky.com";

            string subject = "Daily Case Review Summary - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

            try
            {
                EmailUtil.SendEmail(from, to, cc, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSendDailyCaseSummaryReport.Enabled = true;
        }

        private async void btnGetTopNNewCase_Click(object sender, EventArgs e)
        {
            this.btnTopNNewCase.Enabled = false;

            var GetTopNNewCaseList = SalesforceProxy.GetTopNNewCaseList(300, this.chkExcludeEngQA.Checked, this.chkOnlyEngQA.Checked);

            var caseList = await GetTopNNewCaseList;
            string caseIDs = "";
            bool isFirstOne = true;
            int index = 0;
            foreach (var caseinfo in caseList)
            {
                if (index == 126)
                {
                    System.Console.WriteLine("Debug");
                }

                System.Console.WriteLine("Start Index: " + ++index);
                if (caseinfo != null && String.IsNullOrEmpty(caseinfo.Product))
                {
                    System.Console.WriteLine("Skip Case ID: " + caseinfo.CaseNumber);
                    System.Console.WriteLine("Product: " + caseinfo.Product);
                    System.Console.WriteLine("Solution: " + caseinfo.Solution);
                    continue;
                }

                if (caseinfo != null
                    && caseinfo.Customer != null
                    && !String.IsNullOrEmpty(caseinfo.Customer.Name)
                    && caseinfo.Customer.Name.ToLower().IndexOf("test") >= 0)
                {
                    System.Console.WriteLine("Skip Case ID: " + caseinfo.CaseNumber + " because the customer name is " + caseinfo.Customer.Name);
                    continue;
                } else if (caseinfo != null
                    && caseinfo.Account != null
                    && !String.IsNullOrEmpty(caseinfo.Account.Name)
                    && caseinfo.Account.Name.ToLower().IndexOf("test") >= 0)
                {
                    System.Console.WriteLine("Skip Case ID: " + caseinfo.CaseNumber + " because the customer name is " + caseinfo.Account.Name);
                    continue;
                }

                if (isFirstOne)
                {
                    caseIDs = caseinfo.CaseNumber;
                    isFirstOne = false;
                }
                else
                {
                    caseIDs += "," + caseinfo.CaseNumber;
                }

                System.Console.WriteLine("End Index: " + index);
            }

            this.txtCaseIDList.Text = caseIDs;
            this.btnTopNNewCase.Enabled = true;
        }

        private async void btnTopNCommentedCase_Click(object sender, EventArgs e)
        {
            this.btnTopNCommentedCase.Enabled = false;
            var GetTopNCommentedCaseList = SalesforceProxy.GetTopNCommentedCaseList(100);

            var caseList = await GetTopNCommentedCaseList;
            string caseIDs = "";
            bool isFirstOne = true;
            DateTime startDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            foreach (var caseinfo in caseList)
            {
                if (caseinfo != null
                    && caseinfo.Customer != null
                    && !String.IsNullOrEmpty(caseinfo.Customer.Name)
                    && caseinfo.Customer.Name.ToLower().IndexOf("test") >= 0)
                {
                    continue;
                }
                else if (caseinfo != null
                  && caseinfo.Account != null
                  && !String.IsNullOrEmpty(caseinfo.Account.Name)
                  && caseinfo.Account.Name.ToLower().IndexOf("test") >= 0)
                {
                    continue;
                }

                if (caseinfo.CaseComments != null && caseinfo.CaseComments.Records.Count > 0)
                {
                    CaseComment comment = caseinfo.CaseComments.Records[0];
                    System.Console.Out.WriteLine("Case Number: " + caseinfo.CaseNumber);
                    System.Console.Out.WriteLine("LastModifiedBy: " + comment.LastModifiedBy);
                    System.Console.Out.WriteLine("LastModifiedDate: " + comment.LastModifiedDate.ToLocalTime().ToString());

                    if (DateTime.Compare(comment.LastModifiedDate, startDate) > 0)
                    {
                        if (isFirstOne)
                        {
                            caseIDs = caseinfo.CaseNumber;
                            isFirstOne = false;
                        }
                        else
                        {
                            caseIDs += "," + caseinfo.CaseNumber;
                        }
                    }
                }
            }

            this.txtCaseIDList.Text = caseIDs;
            this.btnTopNCommentedCase.Enabled = true;
        }

        private async void btnImportToJira_Click(object sender, EventArgs e)
        {
            this.btnImportToJira.Enabled = false;

            DataTable dataTable = grdCaseList.DataSource as DataTable;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string caseNumber = "";
                string caseId = "";
                string jiraKey = "";
                string jiraId = "";
                string product = "";
                string solution = "";
                string origin = "";
                string customer = "";
                string buildVersion = "";
                string summary = "";
                string description = "";
                string severity = "";
                string openDate;
                string type = "";
                string targetedRelease = "";
                int reopenCount = 0;
                string lastModifiedDate = "";
                string bzid = String.Empty;
                string jiraStstus = String.Empty;
                string nextJiraStatus = String.Empty;
                string sfStatus = String.Empty;

                bool hotCase = false;
                bool missionsky = false;
                List<string> jiraLabels = new List<string>();
                List<string> fixVersions = new List<string>();

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    caseNumber = row["SalesforceID"] as string;
                    caseId = row["ID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    product = row["Product"] as string;
                    solution = row["Solution"] as string;
                    origin = row["Orgin"] as string;
                    customer = row["Customer"] as string;
                    buildVersion = row["Version"] as string;
                    summary = row["Summary"] as string;
                    description = row["Description"] as string;
                    severity = row["Severity"] as string;
                    openDate = (row["OpenDate"] as string);
                    hotCase = bool.Parse(row["HotCase"].ToString());
                    missionsky = bool.Parse(row["Missionsky"].ToString());
                    jiraLabels = row["JiraLabels"] as List<string>;
                    fixVersions = row["FixVersions"] as List<string>;
                    reopenCount = (String.IsNullOrEmpty(row["ReopenedCount"] as string) ? 0 : int.Parse(row["ReopenedCount"] as string));
                    reopenCount = reopenCount + 1;
                    lastModifiedDate = row["SFLastModified"] as string;
                    targetedRelease = row["TargetedRelease"] as string;
                    sfStatus = row["SFStatus"] as string;

                    DateTime temOpenDate;

                    if (this.chkOnlyImportCase.Checked)
                    {
                        
                        if (String.IsNullOrEmpty((jiraKey)))
                        {
                            IssueFields fields = new IssueFields();
                            fields.customfield_10600 = caseNumber;
                            fields.summary = summary;
                            //fields.labels.Add("Missionsky");
                            if (hotCase)
                            {
                                fields.labels.Add("HotCase");
                            }

                            if (missionsky)
                            {
                                //fields.labels.Add("Missionsky");
                            }

                            fields.description = description;
                            if (!String.IsNullOrEmpty(buildVersion))
                            {
                                fields.customfield_10907.Add(buildVersion);
                            }
                            temOpenDate = DateTime.Parse(openDate);
                            fields.customfield_10902 = temOpenDate.Year + "-" + (temOpenDate.Month < 10 ? "0" + temOpenDate.Month : "" + temOpenDate.Month) + "-" + (temOpenDate.Day < 10 ? "0" + temOpenDate.Day : "" + temOpenDate.Day) + "T00:00:00.000+1100";
                            //fields.customfield_11106 = new IssueSeverity();
                            //fields.customfield_11106.id = 11106;
                            //fields.customfield_11106.name = severity;
                            //fields.Priority = new IssuePriority();
                            //fields.Priority.name = severity;

                            /*
                            fields.customfield_10905 = severity;
                            fields.Priority = new IssuePriority();
                            fields.Priority.name = severity;
                            fields.customfield_11106 = new IssueSeverity();
                            fields.customfield_11106.name = ("High" == severity ? "Major" : severity);
                            //issue.fields.customfield_11106.id = 10414;
                            //fields.customfield_11501 = ("AdHoc Reports" == product ? "Accela Automation" : product);
                            //fields.customfield_10904 = product;
                            //fields.customfield_10900 = customer;
                            //if (!String.IsNullOrEmpty(buildVersion))
                            //{
                            //    fields.customfield_10901 = buildVersion;
                            //}
                            //fields.customfield_10906 = "https://na26.salesforce.com/" + caseId;
                             */

                            var issue = await JiraProxy.CreateIssue(fields);

                            row["JiraID"] = issue.key;

                            CloneDuplicatedStepsFromSF(issue.key, caseId);
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty((jiraKey)))
                        {
                            jiraId = row["JiraId"] as string;
                            jiraKey = row["JiraKey"] as string;
                            bzid = row["BZID"] as string;
                            jiraStstus = row["JiraStatus"] as string;
                            nextJiraStatus = row["NextJiraStatus"] as string;

                            Issue issue = new Issue();
                            issue.id = jiraId;
                            issue.key = jiraKey;

                            if (jiraLabels == null)
                            {
                                jiraLabels = new List<string>();
                            }

                            issue.fields.labels = jiraLabels;

                            // Remove Missionsky label
                            if (issue.fields.labels.Contains("Missionsky"))
                            {
                                issue.fields.labels.Remove("Missionsky");
                            }

                            // Remove SupportQA label
                            if (issue.fields.labels.Contains("SupportQA"))
                            {
                                issue.fields.labels.Remove("SupportQA");
                            }

                            if (sfStatus != null && sfStatus.ToLower().IndexOf("qa") >= 0)
                            {
                                issue.fields.labels.Add("SupportQA");
                            }

                            /*
                            if (!issue.fields.labels.Contains("Missionsky"))
                            {
                                issue.fields.labels.Add("Missionsky");
                            }
                            */

                            if (!String.IsNullOrEmpty(bzid) && !issue.fields.labels.Contains("ENG_BUG_BUCKET"))
                            {
                                if ("Development in Progress" == jiraStstus || "Development in Progress" == nextJiraStatus)
                                {
                                    issue.fields.labels.Add("ENG_BUG_BUCKET");
                                }

                                if ("Close" == jiraStstus)
                                {
                                    issue.fields.labels.Remove("ENG_BUG_BUCKET");
                                }
                            }

                            // If it is already schedued in one version, remove 2 labels such as ENG_BUG_BUCKET and ENG_BUG_BACKLOG
                            if (fixVersions != null && fixVersions.Count > 0)
                            {
                                issue.fields.labels.Remove("ENG_BUG_BUCKET");
                                issue.fields.labels.Remove("ENG_BUG_BACKLOG");
                            }

                            // If it is already resolved or closed, remove 2 labels such as ENG_BUG_BUCKET and ENG_BUG_BACKLOG
                            if ("Resolved".Equals(jiraStstus, StringComparison.InvariantCultureIgnoreCase)
                                || "Closed".Equals(jiraStstus, StringComparison.InvariantCultureIgnoreCase))
                            {
                                issue.fields.labels.Remove("ENG_BUG_BUCKET");
                                issue.fields.labels.Remove("ENG_BUG_BACKLOG");
                            }

                            if (hotCase && !issue.fields.labels.Contains("HotCase"))
                            {
                                issue.fields.labels.Add("HotCase");
                            }

                            if (!hotCase && issue.fields.labels.Contains("HotCase"))
                            {
                                issue.fields.labels.Remove("HotCase");
                            }

                            if (missionsky && !issue.fields.labels.Contains("Missionsky"))
                            {
                                //issue.fields.labels.Add("Missionsky");
                            }

                            if (!missionsky && issue.fields.labels.Contains("Missionsky"))
                            {
                                issue.fields.labels.Remove("Missionsky");
                            }
                            
                            issue.fields.customfield_10905 = severity;
                            issue.fields.customfield_12801 = severity;
                            issue.fields.Priority = new IssuePriority();
                            //issue.fields.Priority.id = 7;
                            issue.fields.Priority.name = severity;
                            issue.fields.customfield_11106 = new IssueSeverity();
                            issue.fields.customfield_11106.name = ("High" == severity ? "Major" : severity);

                            issue.fields.customfield_11501 = product;
                            if (solution != null && solution.ToUpper().Contains("ARW")
                                || product != null && !String.IsNullOrEmpty("ARW") && product.ToUpper().Contains("ARW"))
                            {
                                issue.fields.customfield_11501 = "Accela ARW";
                            }

                            if ("AdHoc Reports" == product)
                            {
                                issue.fields.customfield_11501 = "Accela Ad Hoc";
                            }

                            if ("Reporting" == product)
                            {
                                issue.fields.customfield_11501 = "Accela Automation";
                            }

                            if ("Inspector" == product || "Civic Hero" == product || "Code Officer" == product || "Work Crew" == product || "Support Access" == product || "PublicStuff" == product)
                            {
                                issue.fields.customfield_11501 = "Accela Mobile";
                            }

                            if ("Civic Cloud Platform" == product || "Accela Asset Management" == product || "Accela Licensing & Case Management" == product || "Accela AMS Classic" == product || "EPC" == product)
                            {
                                issue.fields.customfield_11501 = "Accela Automation";
                            }

                            if ("Standard history conversion" == product)
                            {
                                issue.fields.customfield_11501 = "Accela Automation";
                            }

                            issue.fields.customfield_10904 = AccelaCaseUtil.AdjustProductName(product, solution, summary, description);
                            if ("Mobile Office" == issue.fields.customfield_10904)
                            {
                                issue.fields.customfield_11501 = "Mobile Office";
                            }

                            issue.fields.customfield_10900 = customer;
                            if ("Resolved".Equals(jiraStstus, StringComparison.InvariantCultureIgnoreCase)
                                || "Closed".Equals(jiraStstus, StringComparison.InvariantCultureIgnoreCase)
                                || "Development in Progress".Equals(jiraStstus, StringComparison.InvariantCultureIgnoreCase)
                                || "Resolved".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase)
                                || "Closed".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase)
                                || "Development in Progress".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (issue.fields.labels.Contains("DB"))
                                {
                                    issue.fields.labels.Remove("DB");
                                }
                            }
                            else if ("Pending".Equals(jiraStstus, StringComparison.InvariantCultureIgnoreCase)
                                    || "Pending".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase))
                            { 
                            }
                            else if ("Open".Equals(jiraStstus, StringComparison.InvariantCultureIgnoreCase)
                                || "In Progress".Equals(jiraStstus, StringComparison.InvariantCultureIgnoreCase)
                                || "Open".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase)
                                || "In Progress".Equals(nextJiraStatus, StringComparison.InvariantCultureIgnoreCase))
                            {
                                if (!issue.fields.labels.Contains("DB"))
                                {
                                    if (AccelaDBMapper.ContainsKey(customer))
                                    {
                                        issue.fields.labels.Add("DB");
                                        CreateDBInfoComment(jiraKey, customer);
                                    }
                                }
                            }                            

                            if ("Delivery".Equals(origin, StringComparison.CurrentCultureIgnoreCase))
                            {
                                origin = "Other";
                            }
                            issue.fields.customfield_11900 = (origin.IndexOf("Email") >= 0) ? "Email" : origin; // To deal with one special case - "Email-MEA"
                            issue.fields.customfield_12400 = reopenCount;
                            temOpenDate = DateTime.Parse(lastModifiedDate);
                            issue.fields.customfield_10903 = temOpenDate.Year + "-" + (temOpenDate.Month < 10 ? "0" + temOpenDate.Month : "" + temOpenDate.Month) + "-" + (temOpenDate.Day < 10 ? "0" + temOpenDate.Day : "" + temOpenDate.Day) + "T00:00:00.000+1100";
                            //issue.fields.customfield_10903 = lastModifiedDate;

                            if (!String.IsNullOrEmpty(buildVersion))
                            {
                                issue.fields.customfield_10901 = buildVersion;
                            }
                            issue.fields.customfield_10906 = "https://na26.salesforce.com/" + caseId;

                            try
                            {
                                var updateIssue = await JiraProxy.UpdateIssue(issue);                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Cannot update JIRA key - " + issue.key + ", please remove it and try again.");
                            }
                        }
                    }
                }
            }

            this.chkOnlyImportCase.Checked = !this.chkOnlyImportCase.Checked;
            this.btnImportToJira.Enabled = true;
        }

        private async void CreateDBInfoComment(string jiraKey, string customer)
        {
            if (AccelaDBMapper.ContainsKey(customer))
            {
                AcccelaDBModel dbInfo = AccelaDBMapper[customer];

                IssueRef issue = new IssueRef();
                issue.key = jiraKey;
                issue.id = jiraKey;

                string dbConnInfo = "";
                dbConnInfo += "Type: " + dbInfo.DBType + "\n";
                dbConnInfo += "IP: " + dbInfo.IP + "\n";
                dbConnInfo += "Port: " + dbInfo.Port + "\n";
                dbConnInfo += "SID: " + dbInfo.SID + "\n";
                dbConnInfo += "DB Name: " + dbInfo.DBName + "\n";
                dbConnInfo += "User: " + dbInfo.User + "\n";
                dbConnInfo += "Pass: " + dbInfo.Password + "\n";
                dbConnInfo += "Version: " + dbInfo.Version + "\n";
                dbConnInfo += "Related Case: " + dbInfo.SFCase + "\n";

                JiraProxy.CreateComment(issue, "This client provide some database dump before, please have a try on it first:\n---------------------------------------------------------\n" + dbConnInfo);
            }
        }

        private async void CloneDuplicatedStepsFromSF(string jiraKey, string id)
        {
            var GetCaseCommentsByCaseID = SalesforceProxy.GetCaseCommentsByCaseID(id);
            var comments = await GetCaseCommentsByCaseID;
            string duplicatedComment = string.Empty;

            if (comments != null)
            {
                foreach (var comment in comments)
                {
                    if (comment.CommentBody.Contains("<SFID>"))
                    {
                        duplicatedComment = comment.CommentBody;
                        break;
                    }
                }
            }

            if (!String.IsNullOrEmpty(duplicatedComment))
            {
                IssueRef issue = new IssueRef();
                issue.key = jiraKey;
                issue.id = jiraKey;

                JiraProxy.CreateComment(issue, "CRC collects some duplicated steps in salesforce, please validate it first:\n---------------------------------------------------------\n" + duplicatedComment);
            }
        }

        private void btnMoveCommentToJIRA_Click(object sender, EventArgs e)
        {
            this.btnMoveCommentToJIRA.Enabled = false;

            DataTable dataTable = grdCaseList.DataSource as DataTable;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string jiraKey = "";
                string jiraID = "";
                string lastModifiedDate = "";
                CaseComment caseComment = null;
                string today = "" + DateTime.Now.Year + "-" + (DateTime.Now.Month >= 10 ? "" + DateTime.Now.Month : "0" + DateTime.Now.Month) + "-" + (DateTime.Now.Day >= 10 ? "" + DateTime.Now.Day : "0" + DateTime.Now.Day);
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    jiraKey = row["JiraKey"] as string;
                    jiraID = row["JiraID"] as string;
                    lastModifiedDate = row["SFLastModified"] as string;
                    caseComment = row["CaseComment"] as CaseComment;
                    
                    // No comment today
                    if (caseComment == null)
                    {
                        continue;
                    }

                    string createdDate = "" + caseComment.CreatedDate.Year + "-" + (caseComment.CreatedDate.Month >= 10 ? "" + caseComment.CreatedDate.Month : "0" + caseComment.CreatedDate.Month) + "-" + (caseComment.CreatedDate.Day >= 10 ? "" + caseComment.CreatedDate.Day : "0" + caseComment.CreatedDate.Day); 

                    if (caseComment != null
                        && today != lastModifiedDate
                        && today == createdDate)
                    {
                        IssueRef issue = new IssueRef();
                        issue.key = jiraKey;
                        issue.id = jiraID;

                        JiraProxy.CreateComment(issue, "Copied from salesforce:\n---------------------------------------------------------\n" + caseComment.CommentBody);
                    }
                }
            }

            this.btnMoveCommentToJIRA.Enabled = true;
        }

        private void btnSendDailyCommentEmail_Click(object sender, EventArgs e)
        {
            this.btnSendDailyCommentEmail.Enabled = false;

            string allTodayCaseComment = "<table width='500px'  cellspacing='1px' cellpadding='1px' border='0px' style='border-collapse:collapse;border-spacing:0;border-left:1px solid #888;border-top:1px solid #888;background:#efefef;'>";
            string dailyCaseComment = "";
            DataTable dataTable = grdCaseList.DataSource as DataTable;
            bool isNeedDoubleReview = false;

            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string jiraKey = "";
                string jiraID = "";
                string caseId = "";
                string caseNumber = "";
                string prodcut = "";
                string customer = "";
                string summary = "";
                string comment = "";

                CaseComment caseComment = null;

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    jiraKey = row["JiraKey"] as string;
                    jiraID = row["JiraID"] as string;
                    caseId = row["ID"] as string;
                    caseNumber = row["SalesforceID"] as string;
                    prodcut = row["ProductForUI"] as string;
                    customer = row["Customer"] as string;
                    summary = row["Summary"] as string;
                    caseComment = row["CaseComment"] as CaseComment;
                    comment = (caseComment != null ? caseComment.CommentBody : "");
                    comment = comment.Replace("\r\n", "<br/>");
                    dailyCaseComment = @" 
	                                      <tr>
		                                        <td width='50px'  align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{0}</td>
		                                        <td width='100px' align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://na26.salesforce.com/{7}'>{1}</a></td>
		                                        <td width='100px' align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://accelaeng.atlassian.net/browse/{2}'>{2}</a></td>
		                                        <td width='100px' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{3}</td>
		                                        <td width='150px' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{4}</td>
	                                      </tr>
	                                      <tr>
		                                        <td colspan='5' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>
                                                    <span>{5}<span><br/><br/>
                                                    <p>{6}</p>
                                                    
                                                </td>		
	                                      </tr>";

                    isNeedDoubleReview = false;
                    if (!String.IsNullOrEmpty(comment) && (comment.ToLower().Contains("released")
                                                           || comment.ToLower().Contains(" fix ")
                                                           || comment.ToLower().Contains("released")
                                                           || comment.ToLower().Contains("fixed")
                                                           || comment.ToLower().Contains("bug")
                                                           || comment.ToLower().Contains("missionsky")
                                                           || comment.ToLower().Contains("asap")))
                    {
                        comment = "<p style='font-weight:bold;font-style:italic;color:red'>" + comment + "</p>";
                    }

                    dailyCaseComment = String.Format(dailyCaseComment, (i + 1), caseNumber, jiraKey, prodcut, customer, summary, comment, caseId);
                    allTodayCaseComment += dailyCaseComment;
                }
            }

            allTodayCaseComment += "</table>";

            string content = @"Hi All,<br/><br/>Below are our case comments added today. We are appreciated if you could give us some feedback!<br/><br/>" + allTodayCaseComment + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";
            string to = "accela-support-team@missionsky.com";
            if (this.chkOnlyEmailMe.Checked)
            {
                to = "peter.peng@missionsky.com";
            }
            string cc = "rleung@accela.com;peter.peng@missionsky.com;leo.liu@missionsky.com;louis.he@missionsky.com";
            string subject = "Daily Case Comment Summary - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
                        
            try
            {
                EmailUtil.SendEmail(from, to, cc, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSendDailyCommentEmail.Enabled = true;


        }

        private void btnUpdateJIRAStatus_Click(object sender, EventArgs e)
        {
            // Start Review Case: Open -> In Progress
            //                    Pending -> In Progress
            //                    Resolved -> In Progress(Command: Re-Open)
            //                    Closed -> In Progress(Command: Re-Open)
            // Add some comment: In Progress -> Pending
            // 

            this.btnUpdateJIRAStatus.Enabled = false;

            DataTable dataTable = grdCaseList.DataSource as DataTable;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string jiraKey = "";
                string jiraID = "";
                string jiraStatus = "";
                string jiraNextStatus = "";
                string bzid = "";

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    jiraKey = row["JiraKey"] as string;
                    jiraID = row["JiraID"] as string;
                    jiraStatus = row["JiraStatus"] as string;
                    jiraNextStatus = row["NextJiraStatus"] as string;
                    bzid = row["BZID"] as string;

                    if (!String.IsNullOrEmpty(jiraNextStatus))
                    {
                        IssueRef issue = new IssueRef();
                        issue.id = jiraID;
                        issue.key = jiraKey;
                        var updateJiraStatus = AccelaCaseUtil.UpdateJIRAStatus(issue, jiraStatus, jiraNextStatus);
                    }
                }
            }

            this.btnUpdateJIRAStatus.Enabled = true;
        }

        private async void btnShowScheduledCase_Click(object sender, EventArgs e)
        {
            btnShowScheduledCase.Enabled = false;
            this.txtCaseIDList.Text = "";

            string caseLists = string.Empty;

            var GetIssueList = JiraProxy.GetIssueListByLabel("ENG_BUG_BACKLOG");
            var issueList = await GetIssueList;

            foreach (var issue in issueList)
            {
                if (String.IsNullOrEmpty(caseLists))
                {
                    caseLists = issue.fields.customfield_10600;
                }
                else
                {
                    caseLists += "," + issue.fields.customfield_10600;
                }
            }

            this.txtCaseIDList.Text = caseLists;

            btnShowScheduledCase.Enabled = true;
        }

        private async void btnShowHotCases_Click(object sender, EventArgs e)
        {
            this.btnShowHotCases.Enabled = false;        
            this.txtCaseIDList.Text = "";

            string caseLists = string.Empty;
                        
            var GetCaseList = SalesforceProxy.GetHotCaseList(100);
            var caseList = await GetCaseList;

            foreach (var accelaCase in caseList)
            {
                if (String.IsNullOrEmpty(caseLists))
                {
                    caseLists = accelaCase.CaseNumber;
                }
                else
                {
                    caseLists += "," + accelaCase.CaseNumber;
                }
            }

            /*
            var GetIssueList = JiraProxy.GetIssueListByLabel("9.1.0CodeMerge");
            var issueList = await GetIssueList;

            foreach (var issue in issueList)
            {
                if (String.IsNullOrEmpty(caseLists))
                {
                    caseLists = issue.fields.customfield_10600;
                }
                else
                {
                    caseLists += "," + issue.fields.customfield_10600;
                }
            }
             * */
            
            this.txtCaseIDList.Text = caseLists;
            this.btnShowHotCases.Enabled = true;

        }

        private void chkSelectAllHotCase_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSelectAllHotCase.Checked)
            {
                for (int i = 0; i < this.grdCaseList.Rows.Count; i++)
                {
                    this.grdCaseList.Rows[i].Cells[2].Value = true;
                }
            }
            else
            {
                for (int i = 0; i < this.grdCaseList.Rows.Count; i++)
                {
                    this.grdCaseList.Rows[i].Cells[2].Value = false;
                }
            }
        }

        private void chkSelectAllMissionsky_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSelectTop10HotCase.Checked)
            {
                for (int i = 0; i < this.grdCaseList.Rows.Count; i++)
                {
                    if (this.grdCaseList.Rows[i].Cells[4].Value != null 
                        && (int)this.grdCaseList.Rows[i].Cells[4].Value >= 1
                        && (int)this.grdCaseList.Rows[i].Cells[4].Value <= 10)
                    {
                        this.grdCaseList.Rows[i].Cells[2].Value = true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < this.grdCaseList.Rows.Count; i++)
                {
                    this.grdCaseList.Rows[i].Cells[2].Value = false;
                }
            }
        }

        private async void btnShowPendingCases_Click(object sender, EventArgs e)
        {
            btnShowPendingCases.Enabled = false;
            this.txtCaseIDList.Text = "";

            string caseLists = string.Empty;

            List<string> statuses = new List<string>();
            statuses.Add("Open");
            statuses.Add("In Progress");
            statuses.Add("Reopened");
            statuses.Add("Pending");
            statuses.Add("Development in Progress");

            foreach (string status in statuses)
            {
                var GetIssueListByStatus = JiraProxy.GetIssueListByStatus(status);
                var issueList = await GetIssueListByStatus;

                foreach (var issue in issueList)
                {
                    if (String.IsNullOrEmpty(caseLists))
                    {
                        caseLists = issue.fields.customfield_10600;
                    }
                    else
                    {
                        caseLists += "," + issue.fields.customfield_10600;
                    }
                }
            }

            this.txtCaseIDList.Text = caseLists;

            btnShowPendingCases.Enabled = true;
        }

        private void btnSendCloseReport_Click(object sender, EventArgs e)
        {
            this.btnSendCloseReport.Enabled = false;

            DataTable dataTable = this.grdCaseList.DataSource as DataTable;

            DataView dataTableView = dataTable.DefaultView;
            dataTableView.Sort = "Reviewer ASC";
            dataTable = dataTableView.ToTable();

            string dailyCaseSummary = "";
            dailyCaseSummary = @"<table cellspacing='0px' cellpadding='1px' border='1px' style='border-color:black;font-size:14px'>
                                    <tr>
                                        <th align='center'>No</th>
                                        <th align='center'>Product</th>                                       
                                        <th align='center'>Salesforce ID</th>
                                        <th align='center'>Jira Key</th> 
                                        <th align='center'>Version</th>
                                        <th align='center'>Priority</th>
                                        <th align='center'>Customer</th>
                                        <th align='center'>Summary</th>
                                        <th align='left'>Reopened Times</th>
                                        <th align='center'>Reviewer</th>
                                        <th align='center'>SF Queue</th>    
                                        <th align='center'>SF Status Count</th>                                    
                                        <th align='left'>JIRA Status</th>
                                    </tr>";

            int count = 0;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string product = "";
                string caseId = "";
                string caseNumber = "";
                string jiraKey = "";
                string buildVersion = "";
                string priority = "";
                string customer = "";
                string summary = "";
                string reopenCount = "";
                string assignee = "";
                string sfQueue = "";
                string sfStatus = "";
                string jiaStstus = "";
                string jiraNextStatus = "";

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    product = row["Product"] as string;
                    caseId = row["ID"] as string;
                    caseNumber = row["SalesforceID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    buildVersion = row["Version"] as string;
                    priority = row["Severity"] as string;
                    customer = row["Customer"] as string;
                    summary = row["Summary"] as string;
                    reopenCount = row["ReopenedCount"] as string;
                    assignee = row["Reviewer"] as string;
                    sfQueue = row["SFQueue"] as string;
                    sfStatus = row["SFStatus"] as string;
                    jiaStstus = row["JiraStatus"] as string;

                    if (!"Ideas (Closed)".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase)
                        && !"Closed".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase)
                        && !"Dev Released".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase)
                        && !"Closed - Knowledge".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase)
                        && !"SPAM Closed".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }

                    dailyCaseSummary += String.Format(@"<tr>
                                                        <td align='center'>{0}</td>
                                                        <td align='center'>{1}</td>
                                                        <td align='center'><a href='https://na26.salesforce.com/{13}'>{2}</a></td>
                                                        <td align='center'><a href='https://accelaeng.atlassian.net/browse/{3}'>{3}</a></td>
                                                        <td align='center'>{4}</td>
                                                        <td align='center'>{5}</td>
                                                        <td align='center'>{6}</td>
                                                        <td align='left'>{7}</td>
                                                        <td align='center'>{8}</td>
                                                        <td align='center'>{9}</td>
                                                        <td align='center'>{10}</td>    
                                                        <td align='center'>{11}</td>
                                                        <td align='center'>{12}</td>
                                                    </tr>",
                                                       ++count,
                                                       product,
                                                       caseNumber,
                                                       jiraKey,
                                                       buildVersion,
                                                       priority,
                                                       customer,
                                                       summary,
                                                       reopenCount,
                                                       assignee,
                                                       sfQueue,
                                                       sfStatus,
                                                       jiaStstus,
                                                       caseId
                                                       );
                }
            }
            dailyCaseSummary += "</table>";

            if (count == 0)
            {
                this.btnSendCloseReport.Enabled = true;
                return;
            }

            string content = @"Hi, All guys<br/><br/>Below is your closed cases today, please close them on JIRA accordingly.<br/><br/>" + dailyCaseSummary + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";
            string to = "peter.peng@missionsky.com;leo.liu@missionsky.com;venli.li@missionsky.com";
            string cc = "accela-support-team@missionsky.com";
            string subject = "Closed Case List - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
                        
            try
            {
                EmailUtil.SendEmail(from, to, cc, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSendCloseReport.Enabled = true;
        }

        private async void btnSendRecreatedCase_Click(object sender, EventArgs e)
        {
            this.btnSendRecreatedCase.Enabled = false;

            DataTable dataTable = this.grdCaseList.DataSource as DataTable;

            DataView dataTableView = dataTable.DefaultView;
            dataTableView.Sort = "Assignee ASC";
            dataTable = dataTableView.ToTable();

            string dailyCaseSummary = "";
            dailyCaseSummary = @"<table cellspacing='1px' cellpadding='1px' border='1px' style='border-color:black;font-size:14px'>
                                    <tr>
                                        <th align='center'>No</th>
                                        <th align='center'>Product</th>                                       
                                        <th align='center'>Salesforce ID</th>
                                        <th align='center'>Jira Key</th> 
                                        <th align='center'>Version</th>
                                        <th align='center'>Priority</th>
                                        <th align='center'>Customer</th>
                                        <th align='center'>Summary</th>
                                        <th align='left'>Reopened Times</th>
                                        <th align='center'>Dev</th>
                                        <th align='center'>QA</th>    
                                        <th align='center'>Recreated Time</th>
                                    </tr>";

            int count = 0;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string product = "";
                string caseId = "";
                string caseNumber = "";
                string jiraID = "";
                string jiraKey = "";
                string buildVersion = "";
                string priority = "";
                string customer = "";
                string summary = "";
                string reopenCount = "";
                string assignee = "";
                string assigneeQA = "";
                List<string> jiraLabels = null;

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    product = row["Product"] as string;
                    caseId = row["ID"] as string;
                    caseNumber = row["SalesforceID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    buildVersion = row["Version"] as string;
                    priority = row["Severity"] as string;
                    customer = row["Customer"] as string;
                    summary = row["Summary"] as string;
                    reopenCount = row["ReopenedCount"] as string;
                    assignee = row["Assignee"] as string;
                    assigneeQA = row["AssigneeQA"] as string; 
                    jiraLabels = row["JiraLabels"] as List<string>;

                    if (jiraLabels != null && !jiraLabels.Contains("Recreated_By_QA"))
                    {
                        continue;
                    }

                    
                    jiraID = row["JiraID"] as string;
					
					IssueRef issue = new IssueRef();
                    issue.key = jiraKey;
                    issue.id = jiraID;
                    var GetComments = JiraProxy.GetComments(issue);
                    var Comments = await GetComments;
                    DateTime recreatedTime = DateTime.Now;
                    if (Comments != null && Comments.Count > 0)
                    {
                        foreach (Comment comment in Comments)
                        {
                            if (comment != null 
                                && comment.body != null)
                            {
                                if(comment.body.ToLower().Contains("copied from salesforce:"))
                                {
                                    continue;
                                }

                                if(comment.body.ToLower().Contains("reproduce") 
                                    || comment.body.ToLower().Contains("recreate")
                                    || comment.body.ToLower().Contains("replicate"))
                                {
                                    if (comment.UpdateAuthor != null && comment.UpdateAuthor.displayName == assigneeQA)
                                    {
                                        recreatedTime = comment.Updated;
                                        break;
                                    }
                                    else if (comment.Author != null && comment.Author.displayName == assigneeQA)
                                    {
                                        recreatedTime = comment.Created;
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    dailyCaseSummary += String.Format(@"<tr>
                                                        <td align='center'>{0}</td>
                                                        <td align='center'>{1}</td>
                                                        <td align='center'><a href='https://na26.salesforce.com/{12}'>{2}</a></td>
                                                        <td align='center'><a href='https://accelaeng.atlassian.net/browse/{3}'>{3}</a></td>
                                                        <td align='center'>{4}</td>
                                                        <td align='center'>{5}</td>
                                                        <td align='center'>{6}</td>
                                                        <td align='left'>{7}</td>
                                                        <td align='center'>{8}</td>
                                                        <td align='center'>{9}</td>
                                                        <td align='center'>{10}</td>    
                                                        <td align='center'>{11}</td>
                                                    </tr>",
                                                       ++count, // 0 - No
                                                       product, // 1 - Product
                                                       caseNumber, // 2 - Salesforce ID
                                                       jiraKey, // 3 - Jira Key
                                                       buildVersion, // 4 - Version
                                                       priority, // 5 - Priority
                                                       customer, // 6 - Customer
                                                       summary, // 7 - Summary
                                                       reopenCount, // 8 - Reopened Times
                                                       assignee, // 9 - Dev
                                                       assigneeQA, // 10 - QA
                                                       recreatedTime.ToShortDateString(), // 11 - Recreated Time
                                                       caseId
                                                       );
                }

                dailyCaseSummary += "</table>";

                if (count == 0)
                {
                    this.btnSendRecreatedCase.Enabled = true;
                    return;
                }

                string content = @"Hi, All guys<br/><br/>The following case are already recreated by our QA, please deal with them within one oe two days. If you finished it, please remove the label - Recreated_By_QA. Thanks a lot!<br/><br/>" + dailyCaseSummary + "<br/><br/>Thanks<br/>Accela Support Team";
                string from = "auto_sender@missionsky.com";
                string to = "peter.peng@missionsky.com;leo.liu@missionsky.com;abel.yu@missionsky.com";
                string cc = "accela-support-team@missionsky.com";
                string subject = "The Case List Recreated By QA - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

                try
                {
                    EmailUtil.SendEmail(from, to, cc, subject, content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to send email");
                }

                this.btnSendRecreatedCase.Enabled = true;
            }
        }

        private async void btnSendAnalysisReport_Click(object sender, EventArgs e)
        {
            /*
            this.btnSendAnalysisReport.Enabled = false;

            DataTable dataTable = this.grdCaseList.DataSource as DataTable;

            DataView dataTableView = dataTable.DefaultView;
            dataTableView.Sort = "Assignee ASC";
            dataTable = dataTableView.ToTable();

            string dailyCaseSummary = "";
            dailyCaseSummary = @"<table cellspacing='1px' cellpadding='1px' border='1px' style='border-color:black;font-size:14px'>
                                    <tr>
                                        <th align='center'>No</th>
                                        <th align='center'>Product</th>                                       
                                        <th align='center'>Salesforce ID</th>
                                        <th align='center'>Jira Key</th> 
                                        <th align='center'>Version</th>
                                        <th align='center'>Priority</th>
                                        <th align='center'>Customer</th>
                                        <th align='center'>Summary</th>
                                        <th align='left'>Reopened Times</th>
                                        <th align='left'>Review History</th>
                                        <th align='left'>QA Ratio</th>
                                        <th align='left'>Dev Ratio</th>
                                        <th align='left'>SF Status</th>
                                    </tr>";

            int count = 0;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string product = "";
                string caseId = "";
                string caseNumber = "";
                string jiraID = "";
                string jiraKey = "";
                string buildVersion = "";
                string priority = "";
                string customer = "";
                string summary = "";
                string reopenCount = "";
                string assignee = "";
                string reviewHostory = "";
                string sfStatus = "";
                List<string> jiraLabels = null;
                List<CaseComment> caseComments = null;

                Dictionary<string, string> Reviewers = SalesforceProxy.GetReviewerNamesList();
                List<string> DevNameList = null;
                List<string> QANameList = SalesforceProxy.GetQAReviewerNamesList();
                if (this.chkExcludeEngQA.Checked)
                {
                    QANameList = SalesforceProxy.GetSupportQAList();
                    DevNameList = SalesforceProxy.GetSupportDevList();
                }

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    product = row["Product"] as string;
                    caseId = row["ID"] as string;
                    caseNumber = row["SalesforceID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    buildVersion = row["Version"] as string;
                    priority = row["Severity"] as string;
                    customer = row["Customer"] as string;
                    summary = row["Summary"] as string;
                    reopenCount = row["ReopenedCount"] as string;
                    jiraLabels = row["JiraLabels"] as List<string>;
                    caseComments = row["CaseComments"] as List<CaseComment>;

                    sfStatus = row["SFStatus"] as string;
                    if (!"Ideas (Closed)".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase)
                        && !"Closed".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase))
                    {
                        sfStatus = "UnResolved";
                    }
                    else
                    {
                        sfStatus = "Closed";
                    }

                    Dictionary<DateTime, string> CommentHistories = new Dictionary<DateTime, string>();
                    if (caseComments != null && caseComments.Count > 0)
                    {
                        foreach (CaseComment comment in caseComments)
                        {
                            if (comment == null || comment.CommentBody == null)
                            {
                                continue;
                            }

                            if (this.chkOnlyCurrentMonth.Checked)
                            {
                                if (comment.LastModifiedDate.Month != DateTime.Now.Month)
                                {
                                    continue;
                                }
                            }

                            foreach (var key in Reviewers.Keys)
                            {
                                string value = Reviewers[key];
                                string value1 = value.Replace('.', ' ');
                                if (comment.CommentBody.ToUpper().EndsWith(key.ToUpper())
                                    || comment.CommentBody.ToUpper().EndsWith(value.ToUpper())
                                    || comment.CommentBody.ToUpper().EndsWith(value1.ToUpper()))
                                {
                                    assignee = Reviewers[key];
                                    CommentHistories.Add(comment.LastModifiedDate, assignee);
                                    break;
                                }
                            }
                        }
                    }                   

                    jiraID = row["JiraID"] as string;

                    IssueRef issue = new IssueRef();
                    issue.key = jiraKey;
                    issue.id = jiraID;
                    var GetComments = JiraProxy.GetComments(issue);
                    var Comments = await GetComments;

                    DateTime recreatedTime = DateTime.Now;
                    int caseCommentCount = 0;
                    if (Comments != null && Comments.Count > 0)
                    {
                        caseCommentCount = Comments.Count;
                        foreach (Comment comment in Comments)
                        {
                            if (comment != null
                                && comment.body != null)
                            {
                                if (this.chkOnlyCurrentMonth.Checked)
                                {
                                    if (comment.Updated.Month != DateTime.Now.Month)
                                    {
                                        continue;
                                    }
                                }

                                if (comment.body.ToLower().Contains("copied from salesforce:"))
                                {
                                    continue;
                                }

                                CommentHistories.Add(comment.Updated, comment.UpdateAuthor.displayName.Replace(" ", "."));
                            }
                        }
                    }

                    CommentHistories = CommentHistories.OrderBy(comment => comment.Key).ToDictionary(comment => comment.Key, comment => comment.Value);
                    reviewHostory = "";
                    string dateString = null;
                    string reviewer = "";
                    decimal totalReviewerCount = 0;
                    decimal totalQAReviewerCount = 0;
                    decimal totalDevReviewerCount = 0;
                    foreach(var commentHistory in CommentHistories)
                    {
                        if (dateString == commentHistory.Key.ToShortDateString() && reviewer == commentHistory.Value)
                        {
                            continue;
                        }

                        dateString = commentHistory.Key.ToShortDateString();
                        reviewer = commentHistory.Value;
                        reviewHostory += dateString + " - " + reviewer + "  <br/>";

                        totalReviewerCount = totalReviewerCount + 1;
                        if (QANameList.Contains(reviewer))
                        {
                            totalQAReviewerCount = totalQAReviewerCount + 1;
                        }

                        if (this.chkExcludeEngQA.Checked)
                        {
                            if (DevNameList.Contains(reviewer))
                            {
                                totalDevReviewerCount = totalDevReviewerCount + 1;
                            }
                        }
                    }

                    if (!this.chkExcludeEngQA.Checked)
                    {
                        totalDevReviewerCount = totalReviewerCount - totalQAReviewerCount;
                    }

                    decimal QARatio = 0;
                    if (totalReviewerCount != 0)
                    {
                        QARatio = Math.Round(totalQAReviewerCount / totalReviewerCount, 2);
                    }

                    decimal DevRatio = 0;
                    if (totalReviewerCount != 0)
                    {
                        DevRatio = Math.Round(totalDevReviewerCount / totalReviewerCount, 2);
                    }


                    dailyCaseSummary += String.Format(@"<tr>
                                                        <td align='center'>{0}</td>
                                                        <td align='center'>{1}</td>
                                                        <td align='center'><a href='https://na26.salesforce.com/{13}'>{2}</a></td>
                                                        <td align='center'><a href='https://accelaeng.atlassian.net/browse/{3}'>{3}</a></td>
                                                        <td align='center'>{4}</td>
                                                        <td align='center'>{5}</td>
                                                        <td align='center'>{6}</td>
                                                        <td align='left'>{7}</td>
                                                        <td align='center'>{8}</td>
                                                        <td align='left'>{9}</td>
                                                        <td align='center'>{10}</td>
                                                        <td align='center'>{11}</td>
                                                        <td align='center'>{12}</td>
                                                    </tr>",
                                                       ++count, // 0 - No
                                                       product, // 1 - Product
                                                       caseNumber, // 2 - Salesforce ID
                                                       jiraKey, // 3 - Jira Key
                                                       buildVersion, // 4 - Version
                                                       priority, // 5 - Priority
                                                       customer, // 6 - Customer
                                                       summary, // 7 - Summary
                                                       reopenCount, // 8 - Reopened Times
                                                       reviewHostory, // 9 - Review History  
                                                       QARatio, // 10 - QA Ratio
                                                       DevRatio, // 11 - Dev Ratio
                                                       sfStatus, // 12 - SF Status
                                                       caseId
                                                       );
                }

                dailyCaseSummary += "</table>";

                if (count == 0)
                {
                    this.btnSendRecreatedCase.Enabled = true;
                    return;
                }

                string content = @"Hi, All guys<br/><br/>Below is the case analysis report. Just for reference!<br/><br/>" + dailyCaseSummary + "<br/><br/>Thanks<br/>Accela Support Team";
                string from = "auto_sender@missionsky.com";
                string to = "peter.peng@missionsky.com;leo.liu@missionsky.com;abel.yu@missionsky.com";
                string cc = "accela-support-team@missionsky.com";
                string subject = "The Case Analysis Summary - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

                try
                {
                    EmailUtil.SendEmail(from, to, cc, subject, content);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Failed to send email");
                }

                this.btnSendAnalysisReport.Enabled = true;
             
            }
             * * 
             * */
        }

        private void chkOnlyEngQA_CheckedChanged(object sender, EventArgs e)
        {
            this.chkExcludeEngQA.Checked = !this.chkOnlyEngQA.Checked;
        }

        private void chkExcludeEngQA_CheckedChanged(object sender, EventArgs e)
        {
            this.chkOnlyEngQA.Checked = !this.chkExcludeEngQA.Checked;
        }

        private async void btnShowOpenCase_Click(object sender, EventArgs e)
        {
            btnShowOpenCase.Enabled = false;
            this.txtCaseIDList.Text = "";

            string caseLists = string.Empty;

            List<string> statuses = new List<string>();
            statuses.Add("Open");
            statuses.Add("In Progress");
            statuses.Add("Reopened");

            foreach (string status in statuses)
            {
                var GetIssueListByStatus = JiraProxy.GetIssueListByStatus(status);
                var issueList = await GetIssueListByStatus;

                foreach (var issue in issueList)
                {
                    if (String.IsNullOrEmpty(caseLists))
                    {
                        caseLists = issue.fields.customfield_10600;
                    }
                    else
                    {
                        caseLists += "," + issue.fields.customfield_10600;
                    }
                }
            }

            this.txtCaseIDList.Text = caseLists;

            btnShowOpenCase.Enabled = true;
        }
    }
}
