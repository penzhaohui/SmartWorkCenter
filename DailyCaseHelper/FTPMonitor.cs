using com.smartwork.Models;
using com.smartwork.Proxy;
using com.smartwork.Proxy.models;
using com.smartwork.Util;
using Newtonsoft.Json;
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

namespace com.smartwork
{
    public partial class FTPMonitor : Form
    {
        public FTPMonitor()
        {
            InitializeComponent();
        }

        private async void btnTop50NewCases_Click(object sender, EventArgs e)
        {
            this.btnTop50NewCases.Enabled = false;

            var GetTopNNewCaseList = SalesforceProxy.GetTopNNewCaseList(300, false, false, true);

            var caseList = await GetTopNNewCaseList;
            string caseIDs = "";
            bool isFirstOne = true;
            foreach (var caseinfo in caseList)
            {

                if (caseinfo.CaseComments == null) continue;

                bool hasFtpObject = false;
                foreach(CaseComment comment in caseinfo.CaseComments.Records)
                {
                    // Only check the recent comments within 7 days
                    if (DateTime.Now.CompareTo(comment.CreatedDate.AddDays(7)) > 0)
                    {
                        continue;
                    }

                    if(comment.CommentBody.ToLower().Contains("ftp.accela.com")
                        || comment.CommentBody.ToLower().Contains("ftp"))
                    {
                        hasFtpObject = true;
                        break;
                    }                    
                }

                if(hasFtpObject == false) continue;

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

            this.txtCaseIDList.Text = caseIDs;
            this.btnTop50NewCases.Enabled = true;
        }

        private async void btnSyncWithJIRA_Click(object sender, EventArgs e)
        {
            this.btnSendNotificationEmail.Enabled = false;
            this.btnSyncWithJIRA.Enabled = false;

            // 1, Construct one case list from the specified case list
            // 1.1 Check if the case list formate is valid or not
            // 1.2 Construct one case list
            string caseIDs = this.txtCaseIDList.Text;
            List<string> caseIdList = new List<string>();

            if (String.IsNullOrEmpty(caseIDs) || caseIDs.Trim().Length == 0)
            {
                // Show one error message "ERROR: Please enter case id"
                (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Please enter case id");
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
                        caseIdList.Add(caseId.Trim());
                    }
                    else
                    {
                        // Show one error message "ERROR: Invalid Format for XXXX"
                        (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Invalid Format for " + caseId);
                        return;
                    }
                }
            }

            var GetCaseList = SalesforceProxy.GetCaseList(caseIdList);
            var GetIssueList = JiraProxy.GetIssueList(caseIdList);

            var caseList = await GetCaseList;
            var issueList = await GetIssueList;

            Dictionary<string, AccelaIssueCaseMapper> JiraMapping = new Dictionary<string, AccelaIssueCaseMapper>();
            foreach (var issue in issueList)
            {
                if (!JiraMapping.ContainsKey(issue.fields.customfield_10600))
                {
                    AccelaIssueCaseMapper accelaIssueCaseMapper = new AccelaIssueCaseMapper();
                    accelaIssueCaseMapper.CaseNumber = issue.fields.customfield_10600;
                    accelaIssueCaseMapper.Assignee = (issue.fields.assignee == null ? "" : issue.fields.assignee.displayName);
                    accelaIssueCaseMapper.JiraId = issue.id;
                    accelaIssueCaseMapper.JiraKey = issue.key;
                    accelaIssueCaseMapper.LastModified = issue.fields.customfield_10903;
                    accelaIssueCaseMapper.Status = issue.fields.status.name;
                    accelaIssueCaseMapper.HotCase = issue.fields.labels.Contains("HotCase");
                    accelaIssueCaseMapper.JiraLabels = issue.fields.labels;

                    JiraMapping.Add(accelaIssueCaseMapper.CaseNumber, accelaIssueCaseMapper);
                }
            }

            DataTable table = new DataTable("Daily Report");
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("HotCase", typeof(bool));
            table.Columns.Add("JiraLabels", typeof(List<string>));
            table.Columns.Add("ProductForUI", typeof(string));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Solution", typeof(string));
            table.Columns.Add("Orgin", typeof(string));
            table.Columns.Add("OpenDate", typeof(string));
            table.Columns.Add("Severity", typeof(string));
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

            Dictionary<string, string> Reviewers = new Dictionary<string, string>();
            Reviewers.Add("Alvin", "Alvin.Li");
            Reviewers.Add("Rick", "Rick.Liu");
            Reviewers.Add("Weber", "Weber.Yan");
            Reviewers.Add("John", "John.Huang");
            Reviewers.Add("Hyman", "Hyman.Zhang");
            Reviewers.Add("Star", "Star.Li");
            Reviewers.Add("Lex", "Lex.Wu");
            Reviewers.Add("Bass", "Bass.Yang");
            Reviewers.Add("Mandy", "Mandy.Zhou");
            Reviewers.Add("Linda", "Linda.Xiao");
            Reviewers.Add("Abel", "Abel.Yu");
            Reviewers.Add("Matt", "Matt.Ao");
            Reviewers.Add("Peter", "Peter.Peng");
            Reviewers.Add("Sandy", "Sandy.Zheng");
            Reviewers.Add("Likko", "Likko.Zhang");
            Reviewers.Add("Mina", "Mina.Xiong");
            Reviewers.Add("Jessy", "Jessy.Zhang");
            Reviewers.Add("Louis", "Louis.He");
            Reviewers.Add("Leo", "Leo.Liu");
            Reviewers.Add("Adger", "Adger.Chen");
            Reviewers.Add("Tim", "Tim.Liu");
            Reviewers.Add("Mia", "Mia.Huang");
            Reviewers.Add("Jessie", "Jessie.Zhang");
            Reviewers.Add("William", "William.Wang");
            Reviewers.Add("Cheng", "Cheng.Xu");
            Reviewers.Add("Gordon", "Gordon.Chen");
            Reviewers.Add("Tracy", "Tracy.Xiang");

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

            foreach (var caseinfo in caseList)
            {
                tempIssue = null;
                if (JiraMapping.ContainsKey(caseinfo.CaseNumber))
                {
                    tempIssue = JiraMapping[caseinfo.CaseNumber];
                }

                DataRow row = table.NewRow();
                row["ID"] = caseinfo.Id;
                row["No"] = index;
                row["HotCase"] = (tempIssue != null && tempIssue.HotCase);
                row["JiraLabels"] = (tempIssue != null ? tempIssue.JiraLabels : null);
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
                row["SalesforceID"] = caseinfo.CaseNumber;
                jiraKey = (tempIssue != null ? tempIssue.JiraKey : "");
                jiraId = (tempIssue != null ? tempIssue.JiraId : "");
                row["JiraKey"] = jiraKey;
                row["JiraID"] = jiraId;
                row["Type"] = caseinfo.Type;
                row["Version"] = caseinfo.CurrentVersion;
                customer = (caseinfo.Customer != null && !String.IsNullOrEmpty(caseinfo.Customer.Name) ? caseinfo.Customer.Name : caseinfo.Account.Name);
                row["Customer"] = customer;
                row["Summary"] = caseinfo.Subject;
                row["Description"] = caseinfo.Description;
                assignee = (tempIssue != null ? tempIssue.Assignee : "");

                temComment = "";

                if (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null)
                {
                    CaseComment comment = caseinfo.CaseComments.Records[0];
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
                row["SFLastModified"] = (tempIssue != null ? tempIssue.LastModified : "");

                table.Rows.Add(row);
                index++;
            }

            grdCaseList.AutoGenerateColumns = false;
            grdCaseList.DataSource = table;

            this.btnSendNotificationEmail.Enabled = true;
            this.btnSyncWithJIRA.Enabled = true;
        }

        private void btnSendNotificationEmail_Click(object sender, EventArgs e)
        {
            this.btnSendNotificationEmail.Enabled = false;
                        
            string from = "auto_sender@missionsky.com";
            string to = "leo.liu@missionsky.com";

            string dailyCaseSummary = "";
            dailyCaseSummary = @"<table cellspacing='0px' cellpadding='1px' border='1px' style='border-color:black;font-size:14px'>
                                    <tr>
                                        <th align='center'>No</th>
                                        <th align='center'>Product</th>                                       
                                        <th align='center'>Salesforce ID</th>
                                        <th align='center'>Jira ID</th> 
                                        <th align='center'>Severity</th>
                                        <th align='center'>Version</th>
                                        <th align='center'>Type</th>
                                        <th align='left'>Customer</th>
                                        <th align='center'>Orgin</th>
                                        <th align='center'>Open Date</th>    
                                        <th align='center'>Reopened Count</th>                                    
                                        <th align='left'>Summary</th>
                                        <th align='center'>Reviewer</th> 
                                        <th align='center'>Jira Status</th>                                         
                                        <th align='center'>Comments</th>
                                    </tr>";

            DataTable dataTable = grdCaseList.DataSource as DataTable;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string product = "";
                string caseNumber = "";
                string jiraKey = "";
                string priority = "";
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

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    product = row["ProductForUI"] as string;
                    caseNumber = row["SalesforceID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    priority = row["Severity"] as string;
                    buildVersion = row["Version"] as string;
                    type = row["Type"] as string;
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

                    string emailAddress = assignee.Replace(" ", ".").ToLower() + "@missionsky.com";
                    if(!to.Contains(emailAddress))
                    {
                        to += ";" + emailAddress;
                    }

                    dailyCaseSummary += String.Format(@"<tr>
                                                        <td align='center'>{0}</td>
                                                        <td align='center'>{1}</td>
                                                        <td align='center'><a href='https://na26.salesforce.com/{15}'>{2}</a></td>
                                                        <td align='center'><a href='https://accelaeng.atlassian.net/browse/{3}'>{3}</a></td>
                                                        <td align='center'>{4}</td>
                                                        <td align='center'>{5}</td>
                                                        <td align='center'>{6}</td>
                                                        <td align='left'>{7}</td>
                                                        <td align='center'>{8}</td>
                                                        <td align='center'>{9}</td>
                                                        <td align='center'>{10}</td>
                                                        <td align='left'>{11}</td>
                                                        <td align='center'>{12}</td>
                                                        <td align='center'>{13}</td>
                                                        <td align='center'>{14}</td>
                                                    </tr>",
                                                       (i + 1),
                                                       product,
                                                       caseNumber,
                                                       jiraKey,
                                                       priority,
                                                       buildVersion,
                                                       type,
                                                       customer,
                                                       origin,
                                                       openDate,
                                                       reopenCount,
                                                       summary,
                                                       assignee,
                                                       jiaStstus,
                                                       comment,
                                                       caseId
                                                       );
                }
            }
            dailyCaseSummary += "</table>";

            string content = @"Hi All,<br/><br/>Below salesforce cases have some detailed information (such as database dump, log or other) on ftp.accela.com (U/P: Missionsky/Accela5214), please download them in time.<br/><br/>" + dailyCaseSummary + "<br/><br/>Thanks<br/>Accela Support Team";
            string cc = "peter.peng@missionsky.com;rleung@accela.com";

            string subject = "Download Notification on ftp.accela.com - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

            EmailUtil.SendEmail(from, to, cc, subject, content);

            this.btnSendNotificationEmail.Enabled = true;
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;

            string strSFID = this.txtSFID.Text;

            var GetCaseInfoByID = SalesforceProxy.GetCaseInfoByID(strSFID);
            var caseInfo = await GetCaseInfoByID;

            AccelaCase[] accelaCaseList = caseInfo.ToArray();
            if (accelaCaseList.Length == 0)
            {
                MessageBox.Show("No case is found.");
            }
            else
            {
                // http://stackoverflow.com/questions/31079195/adding-a-new-case-comment-via-salesforce-api-c-sharp
                // https://github.com/developerforce/Force.com-Toolkit-for-NET/issues/73
                NewCaseComment caseComment = new NewCaseComment()
                {
                    CommentBody = "Peter's Test",
                    ParentId = accelaCaseList[0].Id,
                    IsPublished = true
                };

                var CreateCaseComment = SalesforceProxy.CreateCaseComment(caseComment);
                var commentId = await CreateCaseComment;
                MessageBox.Show("Case Comment's ID is " + commentId);
            }

            this.btnSync.Enabled = true;
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}
