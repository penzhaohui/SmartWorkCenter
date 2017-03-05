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

namespace com.smartwork
{
    public partial class SyncCaseStatusCrossProject : Form
    {
        public SyncCaseStatusCrossProject()
        {
            InitializeComponent();

            // Only scan the updated jira issues in the past one week
            this.dtpStartDate.Value = DateTime.Now.AddDays(-7);
            this.dtpEndDate.Value = DateTime.Now;
        }

        private async void btnScanCrossProjects_Click(object sender, EventArgs e)
        {
            this.btnScanCrossProjects.Enabled = false;

            DateTime startDate = this.dtpStartDate.Value;
            DateTime endDate = this.dtpEndDate.Value;

            if (endDate < startDate)
            {
                MessageBox.Show("End Date must be greater than Start Date.");
                return;
            }

            List<string> projects = new List<string>();
            if (this.chkProjectAATHETA.Checked)
            {
                projects.Add("AATHETA");
            }

            if (this.chkProjectCAGAMMA.Checked)
            {
                projects.Add("CAGAMMA");
            }

            if (this.chkProjectENGSUPP.Checked)
            {
                projects.Add("ENGSUPP");
            }

            if (this.chkProjectPMA.Checked)
            {
                projects.Add("PMA");
            }

            if (projects.Count == 0)
            {
                MessageBox.Show("Please select one project at least.");
                return;
            }

            var GetCaseListFromCrossProjects = JiraProxy.GetCaseListFromCrossProjects(startDate, endDate, projects);
            var issueListTmp = await GetCaseListFromCrossProjects;

            List<string> caseIdList = new List<string>();

            foreach (var issueInfo in issueListTmp)
            {
                string caseIds = issueInfo.fields.customfield_10600;                
                String[] caseIDArray = caseIds.Split(',');

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
                }
            }

            string caseIdString = "";
            bool isFirstOne = true;
            foreach (string caseId in caseIdList)
            {
                if (isFirstOne)
                {
                    isFirstOne = false;
                    caseIdString = caseId;
                }
                else
                {
                    caseIdString += "," + caseId;
                }
            }


            this.txtCaseIdList.Text = caseIdString;

            this.btnScanCrossProjects.Enabled = true;
        }

        private async void btnSendEmail_Click(object sender, EventArgs e)
        {
            this.btnSendEmail.Enabled = false;

            DataTable dataTable = this.grdAccelaCaseStatus.DataSource as DataTable;
           
            string caseStatusSummary = "";
            caseStatusSummary = @"<table cellspacing='1px' cellpadding='1px' border='1px' style='border-color:black;font-size:14px'>
                                    <tr>
                                        <th align='center'>No</th>
                                        <th align='center'>SF ID</th>                                       
                                        <th align='center'>Supp JIRA ID</th>
                                        <th align='center'>Supp JIRA Assignee</th> 
                                        <th align='center'>Linked JIRA ID</th>
                                        <th align='center'>Linked JIRA Assignee</th>
                                        <th align='center'>Summary</th>
                                        <th align='left'>SF Queue</th>
                                        <th align='center'>SF Status</th>
                                        <th align='center'>Supp JIRA Status</th>    
                                        <th align='center'>Linked JIRA Status</th>                                    
                                        <th align='left'>Sync</th>
                                    </tr>";

            int count = 0;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string sfID = "";
                string suppJiraID = "";
                string suppJiraAssignee = "";
                string linkedJiraID = "";
                string linkedJiraAssignee = "";
                string summary = "";
                string sfQueue = "";
                string sfStatus = "";
                string suppJiraStatus = "";
                string linkedJiraStatus = "";

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];

                    sfID = row["SFID"] as string;
                    suppJiraID = row["SuppJiraID"] as string;
                    suppJiraAssignee = row["SuppJiraAssignee"] as string;
                    linkedJiraID = row["LinkedJiraID"] as string;
                    linkedJiraAssignee = row["LinkedJiraAssignee"] as string;
                    summary = row["Summary"] as string;
                    sfQueue = row["SFQueue"] as string;
                    sfStatus = row["SFStatus"] as string;
                    suppJiraStatus = row["SuppJiraStatus"] as string;
                    linkedJiraStatus = row["LinkedJiraStatus"] as string;

                    suppJiraAssignee = (suppJiraAssignee == null ? "" : suppJiraAssignee.ToLower().Replace("@missionsky.com", ""));
                    linkedJiraAssignee = (linkedJiraAssignee == null ? "" : linkedJiraAssignee.ToLower().Replace("@missionsky.com", ""));

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
                                                    </tr>",
                                                       ++count,
                                                       sfID,
                                                       suppJiraID,
                                                       suppJiraAssignee,
                                                       linkedJiraID,
                                                       linkedJiraAssignee,
                                                       summary,
                                                       sfQueue,
                                                       sfStatus,
                                                       suppJiraStatus,
                                                       linkedJiraStatus,
                                                       ""
                                                       );
                }
            }
            caseStatusSummary += "</table>";

            if (count == 0)
            {
                this.btnSendEmail.Enabled = true;
                return;
            }

            string content = @"Hi, All guys<br/><br/>Some cases may be already solved by other team, please inform the assignee QA to synchronize jira status cross the jira projects.<br/><br/>" + caseStatusSummary + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";
            string to = "peter.peng@missionsky.com;leo.liu@missionsky.com;abel.yu@missionsky.com";
            string cc = "lucky.song@missionsky.com";
            string subject = "Resiolved Case List - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

            try
            {
                EmailUtil.SendEmail(from, to, cc, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSendEmail.Enabled = true;
        }

        private async void btnScanCaseCrossProject_Click(object sender, EventArgs e)
        {
            this.btnScanCaseCrossProject.Enabled = false;

            string caseIDs = this.txtCaseIdList.Text;
            List<string> caseIdList = new List<string>();

            if (String.IsNullOrEmpty(caseIDs) || caseIDs.Trim().Length == 0)
            {
                // Show one error message "ERROR: Please enter case id"
                (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Please enter case id");

                this.btnScanCaseCrossProject.Enabled = true;
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

                        this.btnScanCaseCrossProject.Enabled = true;
                        return;
                    }
                }
            }

            List<string> projects = new List<string>();
            projects.Add("ENGSUPP");

            if (this.chkProjectAATHETA.Checked)
            {
                projects.Add("AATHETA");
            }

            if (this.chkProjectCAGAMMA.Checked)
            {
                projects.Add("CAGAMMA");
            }
            
            if (this.chkProjectPMA.Checked)
            {
                projects.Add("PMA");
            }

            if (projects.Count == 0)
            {
                MessageBox.Show("Please select one project at least.");
                return;
            }

            var GetCaseList = SalesforceProxy.GetCaseList(caseIdList);
            var caseListTmp = await GetCaseList;
            Dictionary<string, AccelaCase> AccelaCaseMapper = new Dictionary<string, AccelaCase>();
            foreach (var caseInfo in caseListTmp)
            {
                AccelaCaseMapper.Add(caseInfo.CaseNumber, caseInfo);
            }

            List<AccelaCaseStatusMapper> AccelaCaseStatusMapper = new List<AccelaCaseStatusMapper>();
            foreach (string caseId in caseIdList)
            {
                var GetIssueListBySalesforceId = JiraProxy.GetIssueListBySalesforceId(caseId, projects);
                var issueListTmp = await GetIssueListBySalesforceId;
                AccelaCaseStatusMapper accelaCaseStatus = new AccelaCaseStatusMapper();

                foreach (var issue in issueListTmp)
                {
                    string jiraKey = issue.key;
                    string status = (issue != null ? issue.fields.status.name : "");

                    if (jiraKey.StartsWith("ENGSUPP-"))
                    {
                        if (String.IsNullOrEmpty(accelaCaseStatus.SalesforceID))
                        {
                            accelaCaseStatus.SalesforceID = issue.fields.customfield_10600;
                        }

                        accelaCaseStatus.SuppJiraID = jiraKey;
                        accelaCaseStatus.SuppJiraStatus = status;
                        accelaCaseStatus.SuppAssignee = (issue.fields.assignee != null ? issue.fields.assignee.emailAddress : "");

                        if (AccelaCaseMapper.ContainsKey(accelaCaseStatus.SalesforceID))
                        {
                            AccelaCase accelaCase = AccelaCaseMapper[accelaCaseStatus.SalesforceID];
                            accelaCaseStatus.SFQueue = accelaCase.Owner.Name;
                            accelaCaseStatus.SFStatus = accelaCase.Status;
                            accelaCaseStatus.Summary = accelaCase.Subject;
                        }
                    }
                }

                foreach (var issue in issueListTmp)
                {
                    string jiraKey = issue.key;
                    string status = (issue != null ? issue.fields.status.name : "");                    

                    if (!jiraKey.StartsWith("ENGSUPP-"))
                    {
                        if (String.IsNullOrEmpty(accelaCaseStatus.SalesforceID))
                        {
                            accelaCaseStatus.SalesforceID = issue.fields.customfield_10600;

                            if (AccelaCaseMapper.ContainsKey(accelaCaseStatus.SalesforceID))
                            {
                                AccelaCase accelaCase = AccelaCaseMapper[accelaCaseStatus.SalesforceID];
                                accelaCaseStatus.SFQueue = accelaCase.Owner.Name;
                                accelaCaseStatus.SFStatus = accelaCase.Status;
                                accelaCaseStatus.Summary = accelaCase.Subject;
                            }
                        }

                        // Skipe some jira issue when their status is same already.
                        //if (status == accelaCaseStatus.SuppJiraStatus)
                        //{
                        //    continue;
                        //}

                        if (String.IsNullOrEmpty(accelaCaseStatus.LinkedJiraID))
                        {
                            accelaCaseStatus.LinkedJiraID = jiraKey;
                            accelaCaseStatus.LinkedJiraStatus = status;
                            accelaCaseStatus.LinkedJiraAssignee = (issue.fields.assignee != null ? issue.fields.assignee.emailAddress : "");

                            if (status != accelaCaseStatus.SuppJiraStatus)
                            {
                                accelaCaseStatus.NeedSync = true;
                            }
                        }
                        else
                        {
                            accelaCaseStatus.LinkedJiraID += "," + jiraKey;
                            
                            if (status != "" && accelaCaseStatus.LinkedJiraStatus.IndexOf(status) < 0)
                            {
                                accelaCaseStatus.LinkedJiraStatus += "," + status;
                            }

                            if (status != accelaCaseStatus.SuppJiraStatus)
                            {
                                accelaCaseStatus.NeedSync = true;
                            }

                            if (issue.fields.assignee != null && accelaCaseStatus.LinkedJiraAssignee.IndexOf(issue.fields.assignee.emailAddress) < 0)
                            {
                                accelaCaseStatus.LinkedJiraAssignee += "," + issue.fields.assignee.emailAddress;
                            }
                        }
                    }                    
                }

                // All status is same.
                //if (!String.IsNullOrEmpty(accelaCaseStatus.LinkedJiraID))
                {
                    AccelaCaseStatusMapper.Add(accelaCaseStatus);
                }
            }

            DataTable table = new DataTable("Accela Case Status Report");           
            table.Columns.Add("No", typeof(int));            
            table.Columns.Add("SFID", typeof(string));
            table.Columns.Add("SuppJiraID", typeof(string));
            table.Columns.Add("SuppJiraAssignee", typeof(string));
            table.Columns.Add("LinkedJiraID", typeof(string));
            table.Columns.Add("LinkedJiraAssignee", typeof(string));
            table.Columns.Add("Summary", typeof(string));
            table.Columns.Add("SFQueue", typeof(string));
            table.Columns.Add("SFStatus", typeof(string));
            table.Columns.Add("SuppJiraStatus", typeof(string));
            table.Columns.Add("LinkedJiraStatus", typeof(string));
            table.Columns.Add("Sync", typeof(bool));

            int index = 0;
            foreach (var accelaCaseStatus in AccelaCaseStatusMapper)
            {
                DataRow row = table.NewRow();
                row["No"] = ++index;
                row["SFID"] = accelaCaseStatus.SalesforceID;
                row["SuppJiraID"] = accelaCaseStatus.SuppJiraID;
                row["SuppJiraAssignee"] = accelaCaseStatus.SuppAssignee;
                row["LinkedJiraID"] = accelaCaseStatus.LinkedJiraID;
                row["LinkedJiraAssignee"] = accelaCaseStatus.LinkedJiraAssignee;
                row["Summary"] = accelaCaseStatus.Summary;
                row["SFQueue"] = accelaCaseStatus.SFQueue;
                row["SFStatus"] = accelaCaseStatus.SFStatus;
                row["SuppJiraStatus"] = accelaCaseStatus.SuppJiraStatus;
                row["LinkedJiraStatus"] = accelaCaseStatus.LinkedJiraStatus;
                row["Sync"] = accelaCaseStatus.NeedSync;

                table.Rows.Add(row);
            }

            this.grdAccelaCaseStatus.AutoGenerateColumns = false;
            this.grdAccelaCaseStatus.DataSource = table;

            this.btnScanCaseCrossProject.Enabled = true;
        }
    }
}
