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
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.JiraRestClient;

namespace com.smartwork
{
    public partial class UpdateMyJIRAIssueFromSalesforce : Form
    {
        public UpdateMyJIRAIssueFromSalesforce()
        {
            InitializeComponent();
            InitializeForm();
        }

        /// <summary>
        /// Initialize the form while loading
        /// </summary>
        private async void InitializeForm()
        {
            this.btnLookUpInJiraAndSF.Enabled = false;
            this.btnSyncCaseInJiraAndSF.Enabled = false;
            this.Text = "Smart Worker - peter.peng@missionsky.com";

            Task<IForceClient> createAuthenticationClient = SalesforceProxy.CreateAuthenticationClient();
            IForceClient client = await createAuthenticationClient;
            if (client != null)
            {
                this.btnLookUpInJiraAndSF.Enabled = true;
                this.btnSyncCaseInJiraAndSF.Enabled = true;
            }

            this.ddlReviewerEmailAddress.Items.Clear();
            List<string> reviewerEmailAddressList = new List<string>();
            reviewerEmailAddressList.Add("jessy.zhang@missionsky.com");
            reviewerEmailAddressList.Add("adger.chen@missionsky.com");
            reviewerEmailAddressList.Add("tim.liu@missionsky.com");

            reviewerEmailAddressList.Add("mia.huang@missionsky.com");
            reviewerEmailAddressList.Add("alvin.li@missionsky.com");

            reviewerEmailAddressList.Add("peter.peng@missionsky.com");
            reviewerEmailAddressList.Add("john.huang@missionsky.com");
            reviewerEmailAddressList.Add("bass.yang@missionsky.com");
            reviewerEmailAddressList.Add("star.li@missionsky.com");
            reviewerEmailAddressList.Add("shaun.qiu@missionsky.com");
            reviewerEmailAddressList.Add("lex.wu@missionsky.com");
            reviewerEmailAddressList.Add("louis.he@missionsky.com");
            reviewerEmailAddressList.Add("likko.zhang@missionsky.com");
            reviewerEmailAddressList.Add("sandy.zheng@missionsky.com");
            reviewerEmailAddressList.Add("weber.yan@missionsky.com");
            reviewerEmailAddressList.Add("rick.liu@missionsky.com");
            reviewerEmailAddressList.Add("matt.ao@missionsky.com");
            reviewerEmailAddressList.Add("hyman.zhang@missionsky.com");
            reviewerEmailAddressList.Add("feng.xuan@missionsky.com");
            reviewerEmailAddressList.Add("cheng.xu@missionsky.com");
            reviewerEmailAddressList.Add("stephen.jin@missionsky.com");
            reviewerEmailAddressList.Add("shaun.qiu@missionsky.com");

            reviewerEmailAddressList.Add("mandy.zhou@missionsky.com");
            reviewerEmailAddressList.Add("linda.xiao@missionsky.com"); 
            reviewerEmailAddressList.Add("leo.liu@missionsky.com");
            reviewerEmailAddressList.Add("abel.yu@missionsky.com");
            reviewerEmailAddressList.Add("claire.cao@missionsky.com");
            reviewerEmailAddressList.Add("viola.shi@missionsky.com");
            reviewerEmailAddressList.Add("larry.francisco@missionsky.com");

            reviewerEmailAddressList.Add("gordon.chen@missionsky.com");
            reviewerEmailAddressList.Add("tracy.xiang@missionsky.com");

            reviewerEmailAddressList.Add("jessie.zhang@missionsky.com");
            reviewerEmailAddressList.Add("william.wang@missionsky.com");            

            reviewerEmailAddressList.Add("carly.xu@missionsky.com");
            reviewerEmailAddressList.Add("janice.zhong@missionsky.com");
            reviewerEmailAddressList.Add("jane.hu@missionsky.com");
            reviewerEmailAddressList.Add("amy.bao@missionsky.com");
            reviewerEmailAddressList.Add("iris.wang@missionsky.com");            
            reviewerEmailAddressList.Add("grace.tang@missionsky.com");
            reviewerEmailAddressList.Add("cloud.qi@missionsky.com");
            reviewerEmailAddressList.Add("carol.gong@missionsky.com");

            reviewerEmailAddressList.Add("mkarvat@accela.com");
            reviewerEmailAddressList.Add("sbalaji@accela.com");
            reviewerEmailAddressList.Add("jlu@accela.com");
            

            this.ddlReviewerEmailAddress.DataSource = reviewerEmailAddressList;
        }

        private async void btnLookUpInJiraAndSF_Click(object sender, EventArgs e)
        {
            this.btnLookUpInJiraAndSF.Enabled = false;

            string emailAddress = this.ddlReviewerEmailAddress.SelectedValue as string;

            if ("jessie.zhang@missionsky.com" == emailAddress)
            {
                emailAddress = emailAddress.Replace("@missionsky.com", "");
            }

            var issues = await JiraProxy.GetIssueList(emailAddress);

            List<string> caseList = new List<string>();
            Dictionary<string, AccelaIssueCaseMapper> JiraMapping = new Dictionary<string, AccelaIssueCaseMapper>();
            foreach (var issue in issues)
            {
                AccelaIssueCaseMapper accelaIssueCaseMapper = new AccelaIssueCaseMapper();
                accelaIssueCaseMapper.CaseNumber = issue.fields.customfield_10600;
                accelaIssueCaseMapper.Assignee = (issue.fields.assignee == null ? "" : issue.fields.assignee.displayName);
                accelaIssueCaseMapper.JiraKey = issue.key;
                accelaIssueCaseMapper.JiraId = issue.id;
                accelaIssueCaseMapper.Status = issue.fields.status.name;
                accelaIssueCaseMapper.HotCase = issue.fields.labels.Contains("HotCase");

                if (String.IsNullOrEmpty(accelaIssueCaseMapper.CaseNumber))
                {
                    continue;
                }

                if (!JiraMapping.ContainsKey(accelaIssueCaseMapper.CaseNumber))
                {
                    JiraMapping.Add(accelaIssueCaseMapper.CaseNumber, accelaIssueCaseMapper);
                }
                else
                {
                    System.Console.WriteLine("Duplicated Case: " + accelaIssueCaseMapper.CaseNumber);
                    if ("CLOSED".Equals(JiraMapping[accelaIssueCaseMapper.CaseNumber].Status, StringComparison.CurrentCultureIgnoreCase))
                    {
                        JiraMapping[accelaIssueCaseMapper.CaseNumber] = accelaIssueCaseMapper;
                    }
                   
                }
                caseList.Add(accelaIssueCaseMapper.CaseNumber);
            }

            DataTable table = new DataTable("CaseList");
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("No", typeof(int));            
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("SalesforceID", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("JiraID", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Version", typeof(string));
            table.Columns.Add("Priority", typeof(string));
            table.Columns.Add("Customer", typeof(string));
            table.Columns.Add("Summary", typeof(string));
            table.Columns.Add("Reviewer", typeof(string));
            table.Columns.Add("ReopenedCount", typeof(string));
            table.Columns.Add("SFQueue", typeof(string));
            table.Columns.Add("SFStatus", typeof(string));            
            table.Columns.Add("JiraStatus", typeof(string));           
            table.Columns.Add("JiraNextStatus", typeof(string));

            if (caseList.Count == 0)
            {
                this.grdCaseList.DataSource = table;
                this.grdCaseList.AutoGenerateColumns = false;
                this.btnLookUpInJiraAndSF.Enabled = true;
                return;
            }

            Dictionary<string, string> Reviewers = new Dictionary<string, string>();
            Reviewers.Add("Jessy", "Jessy.Zhang");
            Reviewers.Add("Adger", "Adger.Chen");
            Reviewers.Add("Tim", "Tim.Liu");

            Reviewers.Add("Mia", "Mia.Huang");
            Reviewers.Add("Alvin", "Alvin.Li");
            Reviewers.Add("Mina", "Mina.Xiong");

            Reviewers.Add("Peter", "Peter.Peng");
            Reviewers.Add("John", "John.Huang");
            Reviewers.Add("Bass", "Bass.Yang");
            Reviewers.Add("Star", "Star.Li");
            Reviewers.Add("Shaun", "Shaun.Qiu");
            Reviewers.Add("Lex", "Lex.Wu");
            Reviewers.Add("Louis", "Louis.He");
            Reviewers.Add("Likko", "Likko.Zhang");
            Reviewers.Add("Sandy", "Sandy.Zheng");
            Reviewers.Add("Weber", "Weber.Yan");
            Reviewers.Add("Rick", "Rick.Liu");
            Reviewers.Add("Matt", "Matt.Ao");
            Reviewers.Add("Hyman", "Hyman.Zhang");
            Reviewers.Add("Feng", "Feng.Xuan");
            Reviewers.Add("Cheng", "Cheng.Xu");
            Reviewers.Add("Stephen", "Stephen.Jin");

            Reviewers.Add("Mandy", "Mandy.Zhou");
            Reviewers.Add("Linda", "Linda.Xiao");
            Reviewers.Add("Leo", "Leo.Liu");
            Reviewers.Add("Abel", "Abel.Yu");
            Reviewers.Add("Claire", "Claire.Cao");
            Reviewers.Add("Viola", "Viola.Shi");
            Reviewers.Add("Larry", "Larry.Francisco");

            Reviewers.Add("Gordon", "Gordon.Chen");
            Reviewers.Add("Tracy", "Tracy.Xiang");

            Reviewers.Add("Jessie", "Jessie.Zhang");
            Reviewers.Add("William", "William.Wang");

            Reviewers.Add("Carly", "Carly.Xu");
            Reviewers.Add("Janice", "Janice.Zhong");
            Reviewers.Add("Jane", "Jane.Hu");
            Reviewers.Add("Amy", "Amy.Bao");
            Reviewers.Add("Iris", "Iris.Wang");
            Reviewers.Add("Grace", "Grace.Tang");
            Reviewers.Add("Cloud", "Clouid.Qi");
            Reviewers.Add("Carol", "Carol.Gong");

            Reviewers.Add("Manasi", "mkarvat@accela.com");
            Reviewers.Add("Sasirekha", "sbalaji@accela.com");
            Reviewers.Add("Jerry", "Jerry.Lu");

            var jiraId = "";
            var jiraKey = "";
            var customer = "";
            var assignee = "";
            var jiaStstus = "";
            var reopenCount = 0;
            bool isCommentedToday = false;
            int index = 1;
            AccelaIssueCaseMapper tempIssue = null;
            var cases = await SalesforceProxy.GetCaseList(caseList);
            foreach(var caseinfo in cases)
            {
                tempIssue = null;
                if (JiraMapping.ContainsKey(caseinfo.CaseNumber))
                {
                    tempIssue = JiraMapping[caseinfo.CaseNumber];
                }

                DataRow row = table.NewRow();
                row["ID"] = caseinfo.Id;
                row["No"] = index;
                row["Product"] = AccelaCaseUtil.AdjustProductName(caseinfo.Product, caseinfo.Solution, caseinfo.Subject, caseinfo.Description);
                row["SalesforceID"] = caseinfo.CaseNumber;
                jiraId = (tempIssue != null ? tempIssue.JiraId : "");
                row["JiraID"] = jiraId;
                jiraKey = (tempIssue != null ? tempIssue.JiraKey : "");
                row["JiraKey"] = jiraKey;
                row["Type"] = caseinfo.Type;
                row["Version"] = caseinfo.CurrentVersion;
                string[] severity = caseinfo.Priority.Split(' ');
                row["Priority"] = severity[1];
                customer = (caseinfo.Customer != null && !String.IsNullOrEmpty(caseinfo.Customer.Name) ? caseinfo.Customer.Name : (caseinfo.Account != null ? caseinfo.Account.Name : ""));
                row["Customer"] = customer;
                row["Summary"] = caseinfo.Subject;
                reopenCount = (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null ? caseinfo.CaseComments.Records.Count - 1 : 0);
                row["ReopenedCount"] = reopenCount;
                row["SFQueue"] = caseinfo.Owner.Name;
                row["SFStatus"] = caseinfo.Status;
                jiaStstus = (tempIssue != null ? tempIssue.Status : "");
                row["JiraStatus"] = jiaStstus;

                assignee = (tempIssue != null ? tempIssue.Assignee : "");

                isCommentedToday = false;
                if (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null)
                {
                    CaseComment comment = caseinfo.CaseComments.Records[0];

                    isCommentedToday = (comment.CreatedDate.Year == DateTime.Now.Year && comment.CreatedDate.Month == DateTime.Now.Month && comment.CreatedDate.Day == DateTime.Now.Day ? true : false);
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

                /*
                if ("CLOSED".Equals(caseinfo.Status, StringComparison.InvariantCultureIgnoreCase)
                    && !"CLOSED".Equals(jiaStstus, StringComparison.InvariantCultureIgnoreCase))
                {
                    row["JiraNextStatus"] = "Closed";
                }

                if ("engineering".Equals(caseinfo.Owner.Name, StringComparison.InvariantCultureIgnoreCase)
                    && "eng new".Equals(caseinfo.Status, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (isCommentedToday)
                    {
                        row["JiraNextStatus"] = "Pending";
                    }
                    else 
                    {
                        if (!"Open".Equals(jiaStstus, StringComparison.InvariantCultureIgnoreCase)
                            && !"In Progress".Equals(jiaStstus, StringComparison.InvariantCultureIgnoreCase))
                        {
                            row["JiraNextStatus"] = "In Progress";
                        }
                    }
                }

                if (isCommentedToday && !"Pending".Equals(jiaStstus, StringComparison.InvariantCultureIgnoreCase))
                {
                    row["JiraNextStatus"] = "Pending";
                }
                 * */
                row["JiraNextStatus"] = AccelaCaseUtil.GetNextJIRAStatus(caseinfo.Owner.Name, caseinfo.Status, jiaStstus, isCommentedToday);

                row["Reviewer"] = assignee;

                table.Rows.Add(row);
                index++;
            }

            this.grdCaseList.AutoGenerateColumns = false;
            this.grdCaseList.DataSource = table;

            this.btnLookUpInJiraAndSF.Enabled = true;
        }

        private async void btnSyncCaseInJiraAndSF_Click(object sender, EventArgs e)
        {
            this.btnSyncCaseInJiraAndSF.Enabled = false;
                      
            DataTable dataTable = grdCaseList.DataSource as DataTable;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string jiraKey = "";
                string jiraID = "";
                string jiraStatus = "";
                string jiraNextStatus = "";

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    jiraKey = row["JiraKey"] as string;
                    jiraID = row["JiraID"] as string;
                    jiraStatus = row["JiraStatus"] as string;
                    jiraNextStatus = row["JiraNextStatus"] as string;

                    if (!String.IsNullOrEmpty(jiraNextStatus))
                    {
                        IssueRef issue = new IssueRef();
                        issue.id = jiraID;
                        issue.key = jiraKey;
                        var updateJiraStatus = AccelaCaseUtil.UpdateJIRAStatus(issue, jiraStatus, jiraNextStatus);                        
                    }
                }
            }

            this.btnSyncCaseInJiraAndSF.Enabled = true;
        }

        private void btnSendTaskList_Click(object sender, EventArgs e)
        {
            this.btnSendTaskList.Enabled = false;

            DataTable dataTable = this.grdCaseList.DataSource as DataTable;

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
                    priority = row["Priority"] as string; 
                    customer = row["Customer"] as string;
                    summary = row["Summary"] as string;
                    reopenCount = row["ReopenedCount"] as string;                   
                    assignee = row["Reviewer"] as string;
                    sfQueue = row["SFQueue"] as string;
                    sfStatus = row["SFStatus"] as string;
                    jiaStstus = row["JiraStatus"] as string;
                    jiraNextStatus = row["JiraNextStatus"] as string;

                    if (!"In Progress".Equals(jiaStstus, StringComparison.InvariantCultureIgnoreCase) 
                        && !"Open".Equals(jiaStstus, StringComparison.InvariantCultureIgnoreCase)
                        && !"Reopned".Equals(jiaStstus, StringComparison.InvariantCultureIgnoreCase)
                        && String.IsNullOrEmpty(jiraNextStatus))
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
                this.btnSendTaskList.Enabled = true;
                return;
            }

            string reviewerEmailAddress = this.ddlReviewerEmailAddress.SelectedValue as string;
            string content = @"Hi," + reviewerEmailAddress + "<br/><br/>Below is your cases today, please take care of them.<br/><br/>" + dailyCaseSummary + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";
            string to = reviewerEmailAddress;
            string cc = "peter.peng@missionsky.com;leo.liu@missionsky.com;";
            string subject = "Daily Case Review Task - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year + " - " + reviewerEmailAddress;

            EmailUtil.SendEmail(from, to, cc, subject, content);
          
            this.btnSendTaskList.Enabled = true;
        }
    }
}
