using com.smartwork.Model;
using com.smartwork.Models;
using com.smartwork.Proxy;
using com.smartwork.Util;
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
    public partial class DBRequestForm : Form
    {
        private static Dictionary<string, AcccelaDBModel> AccelaDBMapper = new Dictionary<string, AcccelaDBModel>();

        public DBRequestForm()
        {
            InitializeComponent();

            try
            {
                this.btnRequest.Enabled = false;

                this.txtIssueSubject.ReadOnly = true;
                this.txtProduct.ReadOnly = true;
                this.txtPriority.ReadOnly = true;
                this.txtCustomerInfo.ReadOnly = true;
                this.txtVersion.ReadOnly = true;
                this.txtCaseOwner.ReadOnly = true;
                this.txtEngsuppID.ReadOnly = true;

                AccelaDBMapper = AccelaDBUtil.GetAccelaDatabaseMapper();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnCheck_Click(object sender, EventArgs e)
        {
            // 
            this.btnCheck.Enabled = false;

            string strSFID = this.txtSFID.Text.Trim();

            var GetCaseInfoByID = SalesforceProxy.GetCaseInfoByID(strSFID);
            var caseInfo = await GetCaseInfoByID;

            AccelaCase[] accelaCaseList = caseInfo.ToArray();
            if (accelaCaseList.Length == 0)
            {
                MessageBox.Show("No case is found.");
            }
            else
            {
                this.txtCustomerInfo.Text = accelaCaseList[0].Customer != null ? accelaCaseList[0].Customer.Name : (accelaCaseList[0].Account != null ? accelaCaseList[0].Account.Name : "");
                this.txtVersion.Text = accelaCaseList[0].CurrentVersion;
                this.chbAccelaHostedFlag.Checked = (accelaCaseList[0].Hosted != null && accelaCaseList[0].Hosted.IndexOf("Accela") >= 0 ? true : false);
                this.txtCaseOwner.Text = accelaCaseList[0].CreatedBy.Name;
                this.txtIssueSubject.Text = accelaCaseList[0].Subject;
                this.txtProduct.Text = accelaCaseList[0].Product;
                this.txtPriority.Text = "";
                if (accelaCaseList[0].Priority.IndexOf("Critical") >= 0)
                {
                    this.txtPriority.Text = "Critical";
                }

                if (accelaCaseList[0].Priority.IndexOf("High") >= 0)
                {
                    this.txtPriority.Text = "High";
                }

                if (accelaCaseList[0].Priority.IndexOf("Medium") >= 0)
                {
                    this.txtPriority.Text = "Medium";
                }

                if (accelaCaseList[0].Priority.IndexOf("Low") >= 0)
                {
                    this.txtPriority.Text = "Low";
                }
            }

            var GetIssueByID = JiraProxy.GetIssueByID("ENGSUPP", "", strSFID);
            var issueInfo = await GetIssueByID;

            if (issueInfo == null)
            {
                return;
            }

            this.txtEngsuppID.Text = issueInfo.key;
            this.txtReviewer.Text = issueInfo.fields.assignee.name;

            bool hasOldDB = issueInfo.fields.labels.IndexOf("DB") >= 0;

            if (hasOldDB && AccelaDBMapper.ContainsKey(this.txtCustomerInfo.Text))
            {
                AcccelaDBModel acccelaDBInfo = AccelaDBMapper[this.txtCustomerInfo.Text];
                this.txtDBType.Text = acccelaDBInfo.DBType;
                this.txtDBServerIP.Text = acccelaDBInfo.IP;
                this.txtDBServerPort.Text = acccelaDBInfo.Port;
                this.txtDBInstance.Text = acccelaDBInfo.DBName;
                this.txtDBVersion.Text = acccelaDBInfo.Version;
                this.txtDBUser.Text = acccelaDBInfo.User;
                this.txtDBPassword.Text = acccelaDBInfo.Password;
                this.txtRelatedCase.Text = acccelaDBInfo.SFCase;

            }

            var GetDBTaskBySFID = JiraProxy.GetDatabaseTaskByCaseID("DATABASE", "Task", strSFID);
            var taskInfo = await GetDBTaskBySFID;
            if (taskInfo != null)
            {
                this.txtDatabaseID.Text = taskInfo.key;
            }

            this.btnRequest.Enabled = true;
            this.btnCheck.Enabled = true;
        }

        private async void btnRequest_Click(object sender, EventArgs e)
        {
            //
            this.btnRequest.Enabled = false;

            string sfid = this.txtSFID.Text;
            string engsuppKey = this.txtEngsuppID.Text;
            string currentVersion = this.txtVersion.Text;
            string product = this.txtProduct.Text;
            string contact = this.txtCaseOwner.Text;
            string priority = this.txtPriority.Text;
            string siteUr = this.txtSiteUrl.Text;

            string issueSubject = this.txtIssueSubject.Text;            
            string customerInfo = this.txtCustomerInfo.Text;
            string dbType = this.txtDBType.Text;
            string dbIP = this.txtDBServerIP.Text;
            string dbPort = this.txtDBServerPort.Text;
            string dbInstance = this.txtDBInstance.Text;
            string dbUserName = this.txtDBUser.Text;
            string dbUserPassword = this.txtDBPassword.Text;
            string dbVersion = this.txtDBVersion.Text;
            string dbRelatedCase = this.txtRelatedCase.Text;
            string enviroment = "";
            string reviewer = this.txtReviewer.Text;

            if (this.txtSiteUrl.Text.Trim().IndexOf(".accela.com") == -1)
            {
                MessageBox.Show("Please specify the client's site url where this case could be recreated.\n For example: https://av.supp3.accela.com/ ");
                this.btnRequest.Enabled = true;
                return;
            }

            if (chbAccelaHostedFlag.Checked)
            {
                if (this.chbProductionFlag.Checked)
                {
                    enviroment += "<<Production>>";
                }

                if (this.chbSupportFlag.Checked)
                {
                    enviroment += "<<Support>>";
                }

                if (this.chbTestFlag.Checked)
                {
                    enviroment += "<<Test>>";
                }

                if (this.chbJetspeed.Checked)
                {
                    enviroment += "<<Jetspeed>>";
                }

                if (String.IsNullOrEmpty(enviroment))
                {
                    MessageBox.Show("Please specify which database enviroment you would request. For example, production, support or test or jetspped");
                    this.btnRequest.Enabled = true;
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please double check if this customer is Accela hosted. If yes, please tick the checkbox beside Accela Hosted field.");
                this.btnRequest.Enabled = true;
                return;
            }

           

            string summary = "Request one fresh database dump for [" + customerInfo + "] - " + sfid;
            string description1 = @"
Hi [~rleung@accela.com],
                              
Please kindly help to get one fresh database dump pings to {0} for <<{1}>> which is Accela hosted, because we could not reproduce the problem on our local site. The problem might exists on their latest {2} enviroment.


Custom Info:
---------------------------------------------------------
Salesforce ID: {3}
ENGSUPP Key: {4}
Customer: {5}
Current Version: {6}
Product: {7}
Contact:{8}
Priority: {9}
Issue Subject: {10}
---------------------------------------------------------

After the fresh database dump is ready, please put it under Accela ftp server. The path should like ftp://ftp.accela.com/BIN/MISSIONSKY/XXXXX-XXXXX, and then re-assign this jira ticket to [~{11}] who will download it in Missionsky. Any further question, please let us know.

Thanks you very much!

CC [~rleung@accela.com] [~vsunku@accela.com] [~evelyn.zhang@missionsky.com] [~{11}]";

            description1 = String.Format(description1,
                                            siteUr,
                                            customerInfo,                                            
                                            enviroment,
                                            sfid,
                                            engsuppKey,
                                            customerInfo,
                                            currentVersion,
                                            product,
                                            contact,
                                            priority,
                                            issueSubject,
                                            reviewer
                                        );

            IssueFields fields = new IssueFields();
            fields.summary = summary;
            fields.description = description1;

            var GetDBTaskBySFID = JiraProxy.GetDatabaseTaskByCaseID("DATABASE", "Task", sfid);
            var GetDatabaseTaskByCustomerID = JiraProxy.GetDatabaseTaskByCustomerID("DATABASE", "Task", customerInfo);
            var taskInfoByCaseId = await GetDBTaskBySFID;
            var taskInfoByCustomerId = await GetDatabaseTaskByCustomerID;
            if (taskInfoByCaseId != null || taskInfoByCustomerId != null)
            {
                var taskInfo = taskInfoByCaseId;
                if (taskInfo == null)
                {
                    taskInfo = taskInfoByCustomerId;
                }

                taskInfo.fields = fields;
                JiraProxy.UpdateDatabaseTask(taskInfo);

                this.txtDatabaseID.Text = taskInfo.key;
                MessageBox.Show("The database request ticket already exists, please refer to " + taskInfo.key);
                showCaseComment(engsuppKey, taskInfo.key);
            }
            else
            {

                var issue = await JiraProxy.CreateDatabaseTask(fields);
                this.txtDatabaseID.Text = issue.key;

                // 2 - Critical
                // 7 - High
                // 6 - Medium
                // 8 - Low
                issue.fields.Priority = new IssuePriority();
                issue.fields.Priority.name = priority;

                JiraProxy.UpdateDatabaseTask(issue);
                showCaseComment(engsuppKey, issue.key);

                IssueRef engIssue = new IssueRef();
                engIssue.key = engsuppKey;
                engIssue.id = engsuppKey;

                JiraProxy.CreateComment(engIssue, String.Format("One jira ticket is already submitted to Accela DBA for the most recent database dump, because the reported issue might be data-related based on the research. The ticket key is {0}.  Thank you for your patience", issue.key));
            }            
           
            this.btnRequest.Enabled = true;
        }

        private void showCaseComment(string jiraKey, string dbKey)
        {
            string sfComment = @"
Hi XXXXX,

One jira ticket is already submitted to Accela DBA for the most recent database dump, because the reported issue might be data-related based on the research. The ticket key is {0}.  Thank you for your patience.

Additional Information:
<You could request other information from client here>
1, ...
2, ...
3, ...

XXXXXXX";

            sfComment = String.Format(sfComment, dbKey);

            this.txtOutputComment.Text = sfComment;
        }

        private async void btnCheckDBRequest_Click(object sender, EventArgs e)
        {
            var GetIssueByID = JiraProxy.GetDatabaseTaskByID("DATABASE", "Task", this.txtDatabaseID.Text);
            var issueInfo = await GetIssueByID;
        }
    }
}
