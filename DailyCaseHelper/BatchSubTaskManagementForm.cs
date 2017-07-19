using com.smartwork.Proxy;
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
    public partial class BatchSubTaskManagementForm : Form
    {
        private static Dictionary<string, string> SubTaskTemplates = new Dictionary<string, string>();

        private void InitSubTaskTemplates()
        {
            SubTaskTemplates.Clear();

            SubTaskTemplates.Add("Review and Recreate(QA)", 
@"*{color:red}Notice{color}*: 
* {color:red}Just log QA effort spent on reviewing and recreating the assicaited production case{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when this case is recreated");

            SubTaskTemplates.Add("Review and Recreate(Dev)",
@"*{color:red}Notice{color}*: 
* {color:red}Just log Dev effort spent on reviewing and recreating the assicaited production case{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when this case is recreated");

            SubTaskTemplates.Add("Research Root Cause",
@"*{color:red}Notice{color}*: 
* {color:red}Just log Dev effort spent on researching root cause after the assicaited production case is recreated{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when this root cause is found");

            SubTaskTemplates.Add("Code Fix(Dev)",
@"*{color:red}Notice{color}*: 
* {color:red}Just log Dev effort spent on solving the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done");

            SubTaskTemplates.Add("Write Test Case(QA)" ,
@"*{color:red}Notice{color}*: 
* {color:red}Just log QA effort spent on writing test case for the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done");

            SubTaskTemplates.Add("Execute Test Case(QA)",
@"*{color:red}Notice{color}*: 
* {color:red}Just log QA effort spent on executing test case for the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done");

            SubTaskTemplates.Add("Write Release Notes(Dev)",
@"*{color:red}Notice{color}*: 
* {color:red}Just log Dev effort spent on writing release notes for the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done");

            SubTaskTemplates.Add("Review Release Notes(QA)",
@"*{color:red}Notice{color}*: 
* {color:red}Just log QA effort spent on reviewing release notes for the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done");       
        }

        public BatchSubTaskManagementForm()
        {
            InitializeComponent();

            InitSubTaskTemplates();

            this.btnCreateSubTask.Enabled = false;
            this.btnSyncAssignee.Enabled = false;
            this.btnCloseSubTask.Enabled = false;
            this.btnSendReport.Enabled = false; 
        }

        private void dgvCaseList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void btnCreateSubTask_Click(object sender, EventArgs e)
        {
            this.btnCreateSubTask.Enabled = false;

            // Step 1, Collect the sub task option           
            SubTaskOption SubTaskOption = new SubTaskOption();
            SubTaskOption.ReviewAndRecreateByQA = this.chkReviewAndRecreateQA.Checked;            
            SubTaskOption.ReviewAndRecreateByDev = this.chkReviewAndRecreateDev.Checked;
            SubTaskOption.ResearchRootCauseByDev = this.chkResearchRootCause.Checked;

            SubTaskOption.CodeFixByDev = this.chkCodeFix.Checked;
            SubTaskOption.WriteTestCaseByQA = this.chkWriteTestCase.Checked;
            SubTaskOption.ExecuteTestCaseByQA = this.chkExecuteTestCase.Checked;
            SubTaskOption.WriteReleaseNotesByDev = this.chkWriteReleaseNotes.Checked;
            SubTaskOption.ReviewReleaseNotesByQA = this.chkReviewReleaseNotes.Checked;

            if (!SubTaskOption.ReviewAndRecreateByQA
                && !SubTaskOption.ReviewAndRecreateByDev
                && !SubTaskOption.ResearchRootCauseByDev
                && !SubTaskOption.CodeFixByDev
                && !SubTaskOption.WriteTestCaseByQA
                && !SubTaskOption.ExecuteTestCaseByQA
                && !SubTaskOption.WriteReleaseNotesByDev
                && !SubTaskOption.ReviewReleaseNotesByQA)
            {
                MessageBox.Show("Please select at least one sub task option!");
                this.btnCreateSubTask.Enabled = true;
                return;
            }

            DataTable dataTable = this.dgvCaseList.DataSource as DataTable;
            if (dataTable != null)
            {
                /*
                bool Checked = false;
                string SFID = "";
                string JiraKey = "";
                string IssueType = "";
                string Status = "";
                string Assignee = "";
                string AssigneeEmail = "";
                string AssigneeQA = "";
                string AssigneeQAEmail = "";
                string ReviewAndRecreateByQA = "";
                string Assignee1 = "";
                string Status1 = "";
                string ReviewAndRecreateByDev = "";
                string Assignee2 = "";
                string Status2 = "";
                string ResearchRootCauseByDev = "";
                string Assignee3 = "";
                string Status3 = "";
                string CodeFixByDev = "";
                string Assignee4 = "";
                string Status4 = "";
                string WriteTestCaseByQA = "";
                string Assignee5 = "";
                string Status5 = "";
                string ExecuteTestCaseByQA = "";
                string Assignee6 = "";
                string Status6 = "";
                string WriteReleaseNotesByDev = "";
                string Assignee7 = "";
                string Status7 = "";
                string ReviewReleaseNotesByQA = "";
                string Assignee8 = "";
                string Status8 = "";
                 * */

                bool checkedFlag = false;
                int rowCount = dataTable.Rows.Count;

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    SubTaskSuite SubTaskSuite = new SubTaskSuite();
                    // row["ID"] as int;
                    SubTaskSuite.SFID = row["SFID"] as string;
                    SubTaskSuite.JiraKey = row["JiraKey"] as string;
                    SubTaskSuite.IssueType = row["IssueType"] as string;
                    SubTaskSuite.Status = row["Status"] as string;
                    SubTaskSuite.Assignee = row["Assignee"] as string;
                    SubTaskSuite.AssigneeEmail = row["AssigneeEmail"] as string;
                    SubTaskSuite.AssigneeQA = row["AssigneeQA"] as string;
                    SubTaskSuite.AssigneeQAEmail = row["AssigneeQAEmail"] as string;
                    SubTaskSuite.ReviewAndRecreateByQA = row["ReviewAndRecreateByQA"] as string;
                    SubTaskSuite.Assignee1 = row["Assignee1"] as string;
                    SubTaskSuite.Status1 = row["Status1"] as string;
                    SubTaskSuite.ReviewAndRecreateByDev = row["ReviewAndRecreateByDev"] as string;
                    SubTaskSuite.Assignee2 = row["Assignee2"] as string;
                    SubTaskSuite.Status2 = row["Status2"] as string;
                    SubTaskSuite.ResearchRootCauseByDev = row["ResearchRootCauseByDev"] as string;
                    SubTaskSuite.Assignee3 = row["Assignee3"] as string;
                    SubTaskSuite.Status3 = row["Status2"] as string;
                    SubTaskSuite.CodeFixByDev = row["CodeFixByDev"] as string;
                    SubTaskSuite.Assignee4 = row["Assignee4"] as string;
                    SubTaskSuite.Status4 = row["Status4"] as string;
                    SubTaskSuite.WriteTestCaseByQA = row["WriteTestCaseByQA"] as string;
                    SubTaskSuite.Assignee5 = row["Assignee5"] as string;
                    SubTaskSuite.Status5 = row["Status5"] as string;
                    SubTaskSuite.ExecuteTestCaseByQA = row["ExecuteTestCaseByQA"] as string;
                    SubTaskSuite.Assignee6 = row["Assignee6"] as string;
                    SubTaskSuite.Status6 = row["Status6"] as string;
                    SubTaskSuite.WriteReleaseNotesByDev = row["WriteReleaseNotesByDev"] as string;
                    SubTaskSuite.Assignee7 = row["Assignee7"] as string;
                    SubTaskSuite.Status7 = row["Status7"] as string;
                    SubTaskSuite.ReviewReleaseNotesByQA = row["ReviewReleaseNotesByQA"] as string;
                    SubTaskSuite.Assignee8 = row["Assignee8"] as string;
                    SubTaskSuite.Status8 = row["Status8"] as string;
                    checkedFlag = bool.Parse(row["Checked"].ToString());

                    if (checkedFlag)
                    {
                        CreateSubTask(SubTaskSuite, SubTaskOption);
                    }
                }
            }

            this.btnCreateSubTask.Enabled = true;
        }

        private async void CreateSubTask(SubTaskSuite SubTaskSuite, SubTaskOption SubTaskOption)
        {
            if ("Resolved".Equals(SubTaskSuite.Status, StringComparison.InvariantCultureIgnoreCase)
                || "Closed".Equals(SubTaskSuite.Status, StringComparison.InvariantCultureIgnoreCase))
            {
                return;
            }

            if ("Case".Equals(SubTaskSuite.IssueType, StringComparison.InvariantCultureIgnoreCase)
                && !String.IsNullOrEmpty(SubTaskSuite.SFID))
            {
                if (SubTaskOption.ReviewAndRecreateByQA == true
                    && String.IsNullOrEmpty(SubTaskSuite.ReviewAndRecreateByQA))
                {
                    createSubTask(SubTaskSuite.JiraKey, "Review and Recreate(QA)", SubTaskTemplates["Review and Recreate(QA)"]);
                }

                if (SubTaskOption.ReviewAndRecreateByDev == true
                    && String.IsNullOrEmpty(SubTaskSuite.ReviewAndRecreateByDev))
                {
                    createSubTask(SubTaskSuite.JiraKey, "Review and Recreate(Dev)", SubTaskTemplates["Review and Recreate(Dev)"]);
                }

                if (SubTaskOption.ResearchRootCauseByDev == true
                    && String.IsNullOrEmpty(SubTaskSuite.ResearchRootCauseByDev))
                {
                    createSubTask(SubTaskSuite.JiraKey, "Research Root Cause", SubTaskTemplates["Research Root Cause"]);
                }
            }

            if ("Bug".Equals(SubTaskSuite.IssueType, StringComparison.InvariantCultureIgnoreCase))
            {
                if (SubTaskOption.CodeFixByDev == true
                    && String.IsNullOrEmpty(SubTaskSuite.CodeFixByDev))
                {
                    createSubTask(SubTaskSuite.JiraKey, "Code Fix(Dev)", SubTaskTemplates["Code Fix(Dev)"]);
                }

                if (SubTaskOption.WriteTestCaseByQA == true
                    && String.IsNullOrEmpty(SubTaskSuite.WriteTestCaseByQA)
                    && !String.IsNullOrEmpty(SubTaskSuite.SFID))
                {
                    createSubTask(SubTaskSuite.JiraKey, "Write Test Case(QA)", SubTaskTemplates["Write Test Case(QA)"]);
                }

                if (SubTaskOption.ExecuteTestCaseByQA == true
                    && String.IsNullOrEmpty(SubTaskSuite.ExecuteTestCaseByQA))
                {
                    createSubTask(SubTaskSuite.JiraKey, "Execute Test Case(QA)", SubTaskTemplates["Execute Test Case(QA)"]);
                }

                if (SubTaskOption.WriteReleaseNotesByDev == true
                    && String.IsNullOrEmpty(SubTaskSuite.WriteReleaseNotesByDev)
                    && !String.IsNullOrEmpty(SubTaskSuite.SFID))
                {
                    createSubTask(SubTaskSuite.JiraKey, "Write Release Notes(Dev)", SubTaskTemplates["Write Release Notes(Dev)"]);
                }

                if (SubTaskOption.ReviewReleaseNotesByQA == true
                    && String.IsNullOrEmpty(SubTaskSuite.ReviewReleaseNotesByQA)
                    && !String.IsNullOrEmpty(SubTaskSuite.SFID))
                {
                    createSubTask(SubTaskSuite.JiraKey, "Review Release Notes(QA)", SubTaskTemplates["Review Release Notes(QA)"]);
                }
            }
        }

        public async Task<string> createSubTask(string issueKey, string summary, string description)
        {
            IssueRef issueRef = new IssueRef();
            issueRef.key = issueKey;

            var issue = await JiraProxy.CreateSubTask(summary, description, issueRef);

            return issue.key;
        }


        private void btnSyncAssignee_Click(object sender, EventArgs e)
        {

        }

        public async void updateSubTask(string subTaskKey, string assignee)
        {
            IssueRef issueRef = new IssueRef();
            issueRef.key = subTaskKey;

            var issue = await JiraProxy.LoadIssue(issueRef);
            if (issue == null || issue.fields == null)
            {
                return;
            }

            // https://accelaeng.atlassian.net/rest/api/2/user/picker?query=peter.peng@missionsky.com
            JiraUser jiraUser = new JiraUser();
            jiraUser.name = assignee;
            issue.fields.assignee = jiraUser;

            JiraProxy.UpdateSubTask(issue);
        }


        private void btnCloseSubTask_Click(object sender, EventArgs e)
        {

        }

        private async void btnSyncSubTask_Click(object sender, EventArgs e)
        {
            this.btnSyncSubTask.Enabled = false;

            // Step 1, Get Case ID List
            List<string> caseIDs = GetCaseIDList(this.txtCaseIDList.Text);

            if (caseIDs.Count == 0)
            {
                MessageBox.Show("Please enter at least one case number!");
                this.btnSyncSubTask.Enabled = true;
                return;
            }

            // Step 2, Get Jira ID List            
            var subTaskSuites = await GetSubTaskSuiteByCaseID(caseIDs);

            // Step 3, Dispplay Jira Issue and assocaited sub tasks
            DisplayJiraIssuesAndAssociatedSubTask(subTaskSuites);

            this.btnSyncSubTask.Enabled = true;

            this.btnCreateSubTask.Enabled = true;
            this.btnSyncAssignee.Enabled = true;
            this.btnCloseSubTask.Enabled = true;
            this.btnSendReport.Enabled = true;    
        }

        private async void DisplayJiraIssuesAndAssociatedSubTask(List<SubTaskSuite> subTaskSuites)
        {
            DataTable table = new DataTable("Jira Issues and Associated Sub Task List");
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("Checked", typeof(bool));
            table.Columns.Add("SFID", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("IssueType", typeof(string));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Assignee", typeof(string));
            table.Columns.Add("AssigneeEmail", typeof(string));
            table.Columns.Add("AssigneeQA", typeof(string));
            table.Columns.Add("AssigneeQAEmail", typeof(string));
            table.Columns.Add("ReviewAndRecreateByQA", typeof(string));
            table.Columns.Add("Assignee1", typeof(string));
            table.Columns.Add("Status1", typeof(string));
            table.Columns.Add("ReviewAndRecreateByDev", typeof(string));
            table.Columns.Add("Assignee2", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("ResearchRootCauseByDev", typeof(string));
            table.Columns.Add("Assignee3", typeof(string));
            table.Columns.Add("Status3", typeof(string));
            table.Columns.Add("CodeFixByDev", typeof(string));
            table.Columns.Add("Assignee4", typeof(string));
            table.Columns.Add("Status4", typeof(string));
            table.Columns.Add("WriteTestCaseByQA", typeof(string));
            table.Columns.Add("Assignee5", typeof(string));
            table.Columns.Add("Status5", typeof(string));
            table.Columns.Add("ExecuteTestCaseByQA", typeof(string));
            table.Columns.Add("Assignee6", typeof(string));
            table.Columns.Add("Status6", typeof(string));
            table.Columns.Add("WriteReleaseNotesByDev", typeof(string));
            table.Columns.Add("Assignee7", typeof(string));
            table.Columns.Add("Status7", typeof(string));
            table.Columns.Add("ReviewReleaseNotesByQA", typeof(string));
            table.Columns.Add("Assignee8", typeof(string));
            table.Columns.Add("Status8", typeof(string));

            int index = 1;
            foreach (var subTask in subTaskSuites)
            {
                DataRow row = table.NewRow();
                row["ID"] = index;
                row["Checked"] = true;
                row["SFID"] = subTask.SFID;
                row["JiraKey"] = subTask.JiraKey;
                row["IssueType"] = subTask.IssueType;
                row["Status"] = subTask.Status;
                row["Assignee"] = subTask.Assignee;
                row["AssigneeEmail"] = subTask.AssigneeEmail;
                row["AssigneeQA"] = subTask.AssigneeQA;
                row["AssigneeQAEmail"] = subTask.AssigneeQAEmail;
                row["ReviewAndRecreateByQA"] = subTask.ReviewAndRecreateByQA;
                row["Assignee1"] = subTask.Assignee1;
                row["Status1"] = subTask.Status1;
                row["ReviewAndRecreateByDev"] = subTask.ReviewAndRecreateByDev;
                row["Assignee2"] = subTask.Assignee2;
                row["Status2"] = subTask.Status2;
                row["ResearchRootCauseByDev"] = subTask.ResearchRootCauseByDev;
                row["Assignee3"] = subTask.Assignee3;
                row["Status2"] = subTask.Status3;
                row["CodeFixByDev"] = subTask.CodeFixByDev;
                row["Assignee4"] = subTask.Assignee4;
                row["Status4"] = subTask.Status4;
                row["WriteTestCaseByQA"] = subTask.WriteTestCaseByQA;
                row["Assignee5"] = subTask.Assignee5;
                row["Status5"] = subTask.Assignee6;
                row["ExecuteTestCaseByQA"] = subTask.ExecuteTestCaseByQA;
                row["Assignee6"] = subTask.Assignee6;
                row["Status6"] = subTask.Status6;
                row["WriteReleaseNotesByDev"] = subTask.WriteReleaseNotesByDev;
                row["Assignee7"] = subTask.Assignee7;
                row["Status7"] = subTask.Status7;
                row["ReviewReleaseNotesByQA"] = subTask.ReviewReleaseNotesByQA;
                row["Assignee8"] = subTask.Assignee8;
                row["Status8"] = subTask.Status8;

                table.Rows.Add(row);
                index++;
            }

            this.dgvCaseList.AutoGenerateColumns = false;
            this.dgvCaseList.DataSource = table;
        }

        private async Task<List<SubTaskSuite>> GetSubTaskSuiteByCaseID(List<string> caseIDs)
        {
            List<SubTaskSuite> subTaskSuites = new List<SubTaskSuite>();

            var issueList = new List<Issue>();

            int N = 1;
            for (int i = 0; i < caseIDs.Count; )
            {
                List<string> caseIdListTemp = new List<string>();
                for (; i < N * 50 && i < caseIDs.Count; i++)
                {
                    caseIdListTemp.Add(caseIDs[i]);
                }

                N = N + 1;
               
                var GetIssueList = JiraProxy.GetIssueList(caseIdListTemp);
        
                var issueListTmp = await GetIssueList;
              
                issueList.AddRange(issueListTmp);
            }
                       
            foreach (var issue in issueList)
            {
                SubTaskSuite subTaskSuite = new SubTaskSuite();

                // SF ID
                subTaskSuite.SFID = issue.fields.customfield_10600;
                // Jira Key
                subTaskSuite.JiraKey = issue.key;
                // Issue Type
                subTaskSuite.IssueType = issue.fields.issueType.name;
                // Status
                subTaskSuite.Status = issue.fields.status.name;
                // Assignee
                subTaskSuite.Assignee = (issue.fields.assignee == null ? "" : issue.fields.assignee.displayName);
                subTaskSuite.AssigneeEmail = (issue.fields.assignee == null ? "" : issue.fields.assignee.name);
                // AssigneeQA
                subTaskSuite.AssigneeQA = (issue.fields.customfield_11702 == null ? "" : issue.fields.customfield_11702.displayName);
                subTaskSuite.AssigneeQAEmail = (issue.fields.customfield_11702 == null ? "" : issue.fields.customfield_11702.name);

                Dictionary<string, string> SubTaskMaper = new Dictionary<string, string>();
                foreach (var subTask in issue.fields.subtasks)
                {
                    if (subTask != null && subTask.fields != null && subTask.fields.issuetype.subtask == true)
                    {
                        if (!SubTaskMaper.ContainsKey(subTask.fields.summary))
                        {
                            SubTaskMaper.Add(subTask.fields.summary, subTask.key);
                        }
                    }
                }

                // Review and Recreate(QA)
                if (SubTaskMaper.ContainsKey("Review and Recreate(QA)"))
                {
                    subTaskSuite.ReviewAndRecreateByQA = SubTaskMaper["Review and Recreate(QA)"];

                    var subTask = await GetAssigneeAndStatus(subTaskSuite.ReviewAndRecreateByQA);
                    subTaskSuite.Assignee1 = subTask.Assignee;
                    subTaskSuite.Status1 = subTask.Status;
                }

                // Review and Recreate(Dev)
                if (SubTaskMaper.ContainsKey("Review and Recreate(Dev)"))
                {
                    subTaskSuite.ReviewAndRecreateByDev = SubTaskMaper["Review and Recreate(Dev)"];

                    var subTask = await GetAssigneeAndStatus(subTaskSuite.ReviewAndRecreateByDev);
                    subTaskSuite.Assignee2 = subTask.Assignee;
                    subTaskSuite.Status2 = subTask.Status;
                }

                // Research Root Cause
                if (SubTaskMaper.ContainsKey("Research Root Cause"))
                {
                    subTaskSuite.ResearchRootCauseByDev = SubTaskMaper["Research Root Cause"];

                    var subTask = await GetAssigneeAndStatus(subTaskSuite.ReviewAndRecreateByDev);
                    subTaskSuite.Assignee3 = subTask.Assignee;
                    subTaskSuite.Status3 = subTask.Status;
                }

                // Code Fix(Dev)
                if (SubTaskMaper.ContainsKey("Code Fix(Dev)"))
                {
                    subTaskSuite.CodeFixByDev = SubTaskMaper["Code Fix(Dev)"];

                    var subTask = await GetAssigneeAndStatus(subTaskSuite.CodeFixByDev);
                    subTaskSuite.Assignee4 = subTask.Assignee;
                    subTaskSuite.Status4 = subTask.Status;
                }

                // Write Test Case(QA)
                if (SubTaskMaper.ContainsKey("Write Test Case(QA)"))
                {
                    subTaskSuite.WriteTestCaseByQA = SubTaskMaper["Write Test Case(QA)"];

                    var subTask = await GetAssigneeAndStatus(subTaskSuite.WriteTestCaseByQA);
                    subTaskSuite.Assignee5 = subTask.Assignee;
                    subTaskSuite.Status5 = subTask.Status;
                }

                // Execute Test Case(QA)
                if (SubTaskMaper.ContainsKey("Execute Test Case(QA)"))
                {
                    subTaskSuite.WriteTestCaseByQA = SubTaskMaper["Execute Test Case(QA)"];

                    var subTask = await GetAssigneeAndStatus(subTaskSuite.WriteTestCaseByQA);
                    subTaskSuite.Assignee6 = subTask.Assignee;
                    subTaskSuite.Status6 = subTask.Status;
                }

                // Write Release Notes(Dev)
                if (SubTaskMaper.ContainsKey("Write Release Notes(Dev)"))
                {
                    subTaskSuite.WriteTestCaseByQA = SubTaskMaper["Write Release Notes(Dev)"];

                    var subTask = await GetAssigneeAndStatus(subTaskSuite.WriteTestCaseByQA);
                    subTaskSuite.Assignee7 = subTask.Assignee;
                    subTaskSuite.Status7 = subTask.Status;
                }

                // Review Release Notes(QA)
                if (SubTaskMaper.ContainsKey("Review Release Notes(QA)"))
                {
                    subTaskSuite.ReviewReleaseNotesByQA = SubTaskMaper["Review Release Notes(QA)"];

                    var subTask = await GetAssigneeAndStatus(subTaskSuite.ReviewReleaseNotesByQA);
                    subTaskSuite.Assignee8 = subTask.Assignee;
                    subTaskSuite.Status8 = subTask.Status;
                }

                subTaskSuites.Add(subTaskSuite);
            }

            return subTaskSuites;
        }

        private async Task<SubTask> GetAssigneeAndStatus(string subTaskKey)
        {
            SubTask subTask = new SubTask();

            IssueRef issueRef = new IssueRef();
            issueRef.key = subTaskKey;

            var issue = await JiraProxy.LoadIssue(issueRef);

            if (issue == null || issue.fields == null)
            {
                return null;
            }

            subTask.Key = issue.key;
            subTask.Name = issue.fields.summary;
            subTask.Assignee = issue.fields.assignee.displayName;
            subTask.AssigneeEmail = issue.fields.assignee.name;
            subTask.Status = issue.fields.status.name;
            subTask.Estimation = 0;

            return subTask;
        }

        private List<string> GetCaseIDList(string caseIDs)
        {
            List<string> caseIdList = new List<string>();

            caseIDs = caseIDs.Replace(",,", ",");
            
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
                }
            }

            return caseIdList;
        }

        class SubTask
        {
            public string Key { get; set; }
            public string Name { get; set; }
            public string Assignee { get; set; }
            public string AssigneeEmail { get; set; }
            public string Status { get; set; }
            public int Estimation { get; set; }
        }

        class SubTaskOption
        {
            public bool ReviewAndRecreateByQA { get; set; }
            public bool ReviewAndRecreateByDev { get; set; }
            public bool ResearchRootCauseByDev { get; set; }
            public bool CodeFixByDev { get; set; }
            public bool WriteTestCaseByQA { get; set; }
            public bool ExecuteTestCaseByQA { get; set; }
            public bool WriteReleaseNotesByDev { get; set; }
            public bool ReviewReleaseNotesByQA { get; set; }
        }

        class SubTaskSuite
        {
            public string Checked { get; set; }
            public string SFID { get; set; }
            public string JiraKey { get; set; }
            public string IssueType { get; set; }
            public string Status { get; set; }
            public string Assignee { get; set; }
            public string AssigneeEmail { get; set; }
            public string AssigneeQA { get; set; }
            public string AssigneeQAEmail { get; set; }
            public string ReviewAndRecreateByQA { get; set; }
            public string Assignee1 { get; set; }
            public string Status1 { get; set; }
            public string ReviewAndRecreateByDev { get; set; }
            public string Assignee2 { get; set; }
            public string Status2 { get; set; }
            public string ResearchRootCauseByDev { get; set; }
            public string Assignee3 { get; set; }
            public string Status3 { get; set; }
            public string CodeFixByDev { get; set; }
            public string Assignee4 { get; set; }
            public string Status4 { get; set; }
            public string WriteTestCaseByQA { get; set; }
            public string Assignee5 { get; set; }
            public string Status5 { get; set; }
            public string ExecuteTestCaseByQA { get; set; }
            public string Assignee6 { get; set; }
            public string Status6 { get; set; }
            public string WriteReleaseNotesByDev { get; set; }
            public string Assignee7 { get; set; }
            public string Status7 { get; set; }
            public string ReviewReleaseNotesByQA { get; set; }
            public string Assignee8 { get; set; }
            public string Status8 { get; set; }
        }

        private void btnSendReport_Click(object sender, EventArgs e)
        {

        }
    }
}
