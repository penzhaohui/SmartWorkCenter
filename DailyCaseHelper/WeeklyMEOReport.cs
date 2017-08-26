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
    public partial class WeeklyMEOReport : Form
    {
        private static List<JiraIssue> jiraIssueList = new List<JiraIssue>();
        public WeeklyMEOReport()
        {
            InitializeComponent();
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;

            if (jiraIssueList == null || jiraIssueList.Count <= 0)
            {
                this.btnSync.Enabled = true;
                return;
            }

            foreach (var issue in jiraIssueList)
            {
                if (issue.subtasks == null || issue.subtasks.Count <= 0)
                {
                    continue;
                }

                foreach (var key in issue.subtasks.Keys)
                {
                    var subTask = issue.subtasks[key];

                    IssueRef issueRef = new IssueRef();
                    issueRef.key = subTask.key;
                    issueRef.id = subTask.key;

                    if (subTask == null
                        || subTask.timespent <= 0
                        || subTask.worklogs == null
                        || subTask.worklogs.Count <= 0)
                    {
                        continue;
                    }

                    var lastWorkLog = subTask.worklogs[subTask.worklogs.Count - 1];
                    var lastAssigneeEmailAddress = lastWorkLog.assigneeEmailAddress;
                    
                    var subTaskItem = await JiraProxy.LoadIssue(issueRef);
                    if (subTaskItem == null || subTaskItem.fields == null)
                    {
                        continue;
                    }

                    if (subTask.assignee == "Jerry Lu")
                    {
                        // https://accelaeng.atlassian.net/rest/api/2/user/picker?query=peter.peng@missionsky.com
                        JiraUser jiraUser = new JiraUser();

                        if ("likko.zhang@missionsky.com" == lastAssigneeEmailAddress)
                        {
                            lastAssigneeEmailAddress = "likko.zhang";
                        }
                        jiraUser.name = lastAssigneeEmailAddress;
                        subTaskItem.fields.assignee = jiraUser;

                        JiraProxy.UpdateSubTask(subTaskItem);
                    }

                    if ("Closed".Equals(issue.status, StringComparison.InvariantCultureIgnoreCase)
                        && !"Closed".Equals(subTask.status, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if ("Case".Equals(issue.issueType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            if ("Review and Recreate(QA)".Equals(subTask.name, StringComparison.InvariantCultureIgnoreCase)
                                || "Review and Recreate(Dev)".Equals(subTask.name, StringComparison.InvariantCultureIgnoreCase)
                                || "Research Root Cause".Equals(subTask.name, StringComparison.InvariantCultureIgnoreCase))
                            {
                                JiraProxy.CloseSubTask(issueRef);
                            }
                        }

                        if ("Bug".Equals(issue.issueType, StringComparison.InvariantCultureIgnoreCase))
                        {
                            if ("Code Fix(Dev)".Equals(subTask.name, StringComparison.InvariantCultureIgnoreCase)
                                || "Write Test Case(QA)".Equals(subTask.name, StringComparison.InvariantCultureIgnoreCase)
                                || "Execute Test Case(QA)".Equals(subTask.name, StringComparison.InvariantCultureIgnoreCase)
                                || "Write Release Notes(Dev)".Equals(subTask.name, StringComparison.InvariantCultureIgnoreCase)
                                || "Review Release Notes(QA)".Equals(subTask.name, StringComparison.InvariantCultureIgnoreCase))
                            {
                                JiraProxy.CloseSubTask(issueRef);
                            }
                        }
                    }
                }
            }

            this.btnSync.Enabled = true;
        }

        private async void btnPull_Click(object sender, EventArgs e)
        {
            this.btnPull.Enabled = false;

            DateTime from = this.dtpFrom.Value;
            DateTime to = this.dtpTo.Value;

            var issues = await JiraProxy.GetUpdatedIssueList(from, to);
            
            if (issues == null || issues.Count == 0)
            {
                this.btnPull.Enabled = true;
                return;
            }

            jiraIssueList.Clear();
            JiraIssue jiraIssue = null;

            foreach (var issue in issues)
            {
                jiraIssue = new JiraIssue();
                jiraIssue.key = issue.key;
                jiraIssue.issueType = issue.fields.issueType.name;
                jiraIssue.name = issue.fields.summary;
                jiraIssue.assignee = issue.fields.assignee.name;
                jiraIssue.assigneeEmailAddress = issue.fields.assignee.emailAddress;
                jiraIssue.assigneeDisplayName = issue.fields.assignee.displayName;
                jiraIssue.status = issue.fields.status.name;                             

                jiraIssue.subtasks = new Dictionary<string, SubTask>();

                if (issue.fields.subtasks == null || issue.fields.subtasks.Count == 0)
                {
                    jiraIssueList.Add(jiraIssue);
                    continue;
                }

                double timeSpentSeconds = 0;
                foreach (var subtask in issue.fields.subtasks)
                {
                    string subTaskKey = subtask.key;
                    string subTaskName = subtask.fields.summary;
                    bool isSubTask = subtask.fields.issuetype.subtask;

                    if (isSubTask && !jiraIssue.subtasks.ContainsKey(subTaskName))
                    {
                        IssueRef issueRef = new IssueRef();
                        issueRef.id = subTaskKey;
                        issueRef.key = subTaskKey;
                        var subTaskInfo = await JiraProxy.LoadIssue(issueRef);


                        if (subTaskInfo == null)
                        {                            
                            continue;
                        }

                        SubTask subTaskItem = new SubTask();
                        subTaskItem.key = subTaskInfo.key;
                        subTaskItem.name = subTaskInfo.fields.summary;
                        subTaskItem.assignee = subTaskInfo.fields.assignee.displayName;
                        subTaskItem.status = subTaskInfo.fields.status.name;
                        subTaskItem.MEO = subTaskInfo.fields.customfield_14101 == null ? "" : subTaskInfo.fields.customfield_14101.value;
                        
                        var worklogs = await JiraProxy.GetWorklogs(issueRef);

                        if (worklogs == null && worklogs.Count == 0)
                        {
                            jiraIssue.subtasks.Add(subTaskItem.name, subTaskItem);
                            continue;
                        }

                        subTaskItem.worklogs = new List<WorkLog>();
                        foreach (var worklog in worklogs)
                        {
                            WorkLog individualWorkLog = new WorkLog();
                            individualWorkLog.assignee = worklog.author.displayName;
                            individualWorkLog.assigneeEmailAddress = worklog.author.emailAddress;
                            individualWorkLog.timeSpent = worklog.timeSpent;
                            individualWorkLog.comment = worklog.comment.Replace("\r\n", ";");

                            subTaskItem.worklogs.Add(individualWorkLog);

                            timeSpentSeconds += worklog.timeSpentSeconds;
                        }                        

                        subTaskItem.timespent = Math.Round((double)subTaskInfo.fields.timespent / 3600, 2);
                        jiraIssue.subtasks.Add(subTaskItem.name, subTaskItem);
                    }
                }

                jiraIssue.timespent = (int)Math.Round((double)timeSpentSeconds / 3600, 2);
                jiraIssueList.Add(jiraIssue);
            }

            DataTable table = new DataTable("Daily Work Log Report");
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("IssueType", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("Summary", typeof(string));
            table.Columns.Add("Status", typeof(string));
            table.Columns.Add("Assignee", typeof(string));
            table.Columns.Add("AssigneeQA", typeof(string));
            table.Columns.Add("TimeSpent", typeof(string));
            table.Columns.Add("ReviewAndRecreateQA", typeof(string));
            table.Columns.Add("Assignee1", typeof(string));
            table.Columns.Add("Status1", typeof(string));
            table.Columns.Add("MEO1", typeof(string));
            table.Columns.Add("TimeSpent1", typeof(string));
            table.Columns.Add("ReviewAndRecreateDev", typeof(string));
            table.Columns.Add("Assignee2", typeof(string));
            table.Columns.Add("Status2", typeof(string));
            table.Columns.Add("MEO2", typeof(string));
            table.Columns.Add("TimeSpent2", typeof(string));
            table.Columns.Add("ResearchRootCauseDev", typeof(string));
            table.Columns.Add("Assignee3", typeof(string));
            table.Columns.Add("Status3", typeof(string));
            table.Columns.Add("MEO3", typeof(string));
            table.Columns.Add("TimeSpent3", typeof(string));
            table.Columns.Add("CodeFixDev", typeof(string));
            table.Columns.Add("Assignee4", typeof(string));
            table.Columns.Add("Status4", typeof(string));
            table.Columns.Add("MEO4", typeof(string));
            table.Columns.Add("TimeSpent4", typeof(string));
            table.Columns.Add("WriteTestCaseQA", typeof(string));
            table.Columns.Add("Assignee5", typeof(string));
            table.Columns.Add("Status5", typeof(string));
            table.Columns.Add("MEO5", typeof(string));
            table.Columns.Add("TimeSpent5", typeof(string));
            table.Columns.Add("ExecuteTestCaseQA", typeof(string));
            table.Columns.Add("Assignee6", typeof(string));
            table.Columns.Add("Status6", typeof(string));
            table.Columns.Add("MEO6", typeof(string));
            table.Columns.Add("TimeSpent6", typeof(string));
            table.Columns.Add("WriteReleaseNotesDev", typeof(string));
            table.Columns.Add("Assignee7", typeof(string));
            table.Columns.Add("Status7", typeof(string));
            table.Columns.Add("MEO7", typeof(string));
            table.Columns.Add("TimeSpent7", typeof(string));
            table.Columns.Add("ReviewReleaseNotesQA", typeof(string));
            table.Columns.Add("Assignee8", typeof(string));
            table.Columns.Add("Status8", typeof(string));
            table.Columns.Add("MEO8", typeof(string));
            table.Columns.Add("TimeSpent8", typeof(string));

            int index = 1;
            foreach (var jiraIssueItem in jiraIssueList)
            {
                DataRow row = table.NewRow();
                row["No"] = index;
                row["IssueType"] = jiraIssueItem.issueType;
                row["JiraKey"] = jiraIssueItem.key;
                row["Summary"] = jiraIssueItem.name;
                row["Status"] = jiraIssueItem.status;
                row["Assignee"] = jiraIssueItem.assignee;
                row["AssigneeQA"] = jiraIssueItem.assignee;
                row["TimeSpent"] = jiraIssueItem.timespent;
                
                SubTask subTaskReviewAndRecreateQA = jiraIssueItem.subtasks.ContainsKey("Review and Recreate(QA)") ? jiraIssueItem.subtasks["Review and Recreate(QA)"] : null;
                if (subTaskReviewAndRecreateQA != null)
                {
                    row["ReviewAndRecreateQA"] = subTaskReviewAndRecreateQA.key;
                    row["Assignee1"] = subTaskReviewAndRecreateQA.assignee;
                    row["Status1"] = subTaskReviewAndRecreateQA.status;
                    row["MEO1"] = subTaskReviewAndRecreateQA.MEO;
                    row["TimeSpent1"] = subTaskReviewAndRecreateQA.timespent;                   
                }

                SubTask subTaskReviewAndRecreateDev = jiraIssueItem.subtasks.ContainsKey("Review and Recreate(Dev)") ? jiraIssueItem.subtasks["Review and Recreate(Dev)"] : null;
                if (subTaskReviewAndRecreateDev != null)
                {
                    row["ReviewAndRecreateDev"] = subTaskReviewAndRecreateDev.key;
                    row["Assignee2"] = subTaskReviewAndRecreateDev.assignee;
                    row["Status2"] = subTaskReviewAndRecreateDev.status;
                    row["MEO2"] = subTaskReviewAndRecreateDev.MEO;
                    row["TimeSpent2"] = subTaskReviewAndRecreateDev.timespent;
                }

                SubTask subTaskResearchRootCause = jiraIssueItem.subtasks.ContainsKey("Research Root Cause") ? jiraIssueItem.subtasks["Research Root Cause"] : null;
                if (subTaskResearchRootCause != null)
                {
                    row["ResearchRootCauseDev"] = subTaskResearchRootCause.key;
                    row["Assignee3"] = subTaskResearchRootCause.assignee;
                    row["Status3"] = subTaskResearchRootCause.status;
                    row["MEO3"] = subTaskResearchRootCause.MEO;
                    row["TimeSpent3"] = subTaskResearchRootCause.timespent;
                }

                SubTask subTaskCodeFixDev = jiraIssueItem.subtasks.ContainsKey("Code Fix(Dev)") ? jiraIssueItem.subtasks["Code Fix(Dev)"] : null;
                if (subTaskCodeFixDev != null)
                {
                    row["CodeFixDev"] = subTaskCodeFixDev.key;
                    row["Assignee4"] = subTaskCodeFixDev.assignee;
                    row["Status4"] = subTaskCodeFixDev.status;
                    row["MEO4"] = subTaskCodeFixDev.MEO;
                    row["TimeSpent4"] = subTaskCodeFixDev.timespent;
                }

                SubTask subTaskWriteTestCaseQA = jiraIssueItem.subtasks.ContainsKey("Write Test Case(QA)") ? jiraIssueItem.subtasks["Write Test Case(QA)"] : null;
                if (subTaskWriteTestCaseQA != null)
                {
                    row["WriteTestCaseQA"] = subTaskWriteTestCaseQA.key;
                    row["Assignee5"] = subTaskWriteTestCaseQA.assignee;
                    row["Status5"] = subTaskWriteTestCaseQA.status;
                    row["MEO5"] = subTaskWriteTestCaseQA.MEO;
                    row["TimeSpent5"] = subTaskWriteTestCaseQA.timespent;
                }


                SubTask subTaskExecuteTestCaseQA = jiraIssueItem.subtasks.ContainsKey("Execute Test Case(QA)") ? jiraIssueItem.subtasks["Execute Test Case(QA)"] : null;
                if (subTaskExecuteTestCaseQA != null)
                {
                    row["ExecuteTestCaseQA"] = subTaskExecuteTestCaseQA.key;
                    row["Assignee6"] = subTaskExecuteTestCaseQA.assignee;
                    row["Status6"] = subTaskExecuteTestCaseQA.status;
                    row["MEO6"] = subTaskExecuteTestCaseQA.MEO;
                    row["TimeSpent6"] = subTaskExecuteTestCaseQA.timespent;
                }

                SubTask subTaskWriteReleaseNotesDev = jiraIssueItem.subtasks.ContainsKey("Write Release Notes(Dev)") ? jiraIssueItem.subtasks["Write Release Notes(Dev)"] : null;
                if (subTaskWriteReleaseNotesDev != null)
                {
                    row["WriteReleaseNotesDev"] = subTaskWriteReleaseNotesDev.key;
                    row["Assignee7"] = subTaskWriteReleaseNotesDev.assignee;
                    row["Status7"] = subTaskWriteReleaseNotesDev.status;
                    row["MEO7"] = subTaskWriteReleaseNotesDev.MEO;
                    row["TimeSpent7"] = subTaskWriteReleaseNotesDev.timespent;
                }

                SubTask subTaskReviewReleaseNotesQA = jiraIssueItem.subtasks.ContainsKey("Review Release Notes(QA)") ? jiraIssueItem.subtasks["Review Release Notes(QA)"] : null;
                if (subTaskReviewReleaseNotesQA != null)
                {
                    row["ReviewReleaseNotesQA"] = subTaskReviewReleaseNotesQA.key;
                    row["Assignee8"] = subTaskReviewReleaseNotesQA.assignee;
                    row["Status8"] = subTaskReviewReleaseNotesQA.status;
                    row["MEO8"] = subTaskReviewReleaseNotesQA.MEO;
                    row["TimeSpent8"] = subTaskReviewReleaseNotesQA.timespent;
                }

                table.Rows.Add(row);
                index++;
            }

            this.dgvSubTaskTable.AutoGenerateColumns = false;
            this.dgvSubTaskTable.DataSource = table;

            this.btnPull.Enabled = true;
            return;
        }

        private void btnSendUnusedSubTasks_Click(object sender, EventArgs e)
        {
            this.btnSendUnusedSubTasks.Enabled = false;

            List<SubTask> SubTaskItems = new List<SubTask>();
            DataTable dataTable = dgvSubTaskTable.DataSource as DataTable;
            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                for (int k = 0; k < rowCount; k++)
                {
                    DataRow row = dataTable.Rows[k];

                    string status = row["Status"] as string;
                    if (!"Closed".Equals(status, StringComparison.InvariantCultureIgnoreCase)
                        && !"Resolved".Equals(status, StringComparison.InvariantCultureIgnoreCase)
                        && !"Dev In Progress".Equals(status, StringComparison.InvariantCultureIgnoreCase))
                    {
                        continue;
                    }

                    SubTask subTaskReviewAndRecreateQA = new SubTask();
                    subTaskReviewAndRecreateQA.key = row["ReviewAndRecreateQA"] as string;
                    subTaskReviewAndRecreateQA.name = "Review and Recreate(QA)";
                    subTaskReviewAndRecreateQA.assignee = row["Assignee1"] as string;
                    subTaskReviewAndRecreateQA.status = row["Status1"] as string;
                    subTaskReviewAndRecreateQA.MEO = row["MEO1"] as string;
                    subTaskReviewAndRecreateQA.timespent = (row["TimeSpent1"] as string)  == null ? 0 : double.Parse(row["TimeSpent1"] as string);
                    if (!String.IsNullOrEmpty(subTaskReviewAndRecreateQA.key) && subTaskReviewAndRecreateQA.timespent <= 0) SubTaskItems.Add(subTaskReviewAndRecreateQA);

                    SubTask subTaskReviewAndRecreateDev = new SubTask();
                    subTaskReviewAndRecreateDev.key = row["ReviewAndRecreateDev"] as string;
                    subTaskReviewAndRecreateDev.name = "Review and Recreate(Dev)";
                    subTaskReviewAndRecreateDev.assignee = row["Assignee2"] as string;
                    subTaskReviewAndRecreateDev.status = row["Status2"] as string;
                    subTaskReviewAndRecreateDev.MEO = row["MEO2"] as string;
                    subTaskReviewAndRecreateDev.timespent = (row["TimeSpent2"] as string) == null ? 0 : double.Parse(row["TimeSpent2"] as string);
                    if (!String.IsNullOrEmpty(subTaskReviewAndRecreateDev.key) && subTaskReviewAndRecreateDev.timespent <= 0) SubTaskItems.Add(subTaskReviewAndRecreateDev);

                    SubTask subTaskResearchRootCause = new SubTask();
                    subTaskResearchRootCause.key = row["ResearchRootCauseDev"] as string;
                    subTaskResearchRootCause.name = "Research Root Cause";
                    subTaskResearchRootCause.assignee = row["Assignee3"] as string;
                    subTaskResearchRootCause.status = row["Status3"] as string;
                    subTaskResearchRootCause.MEO = row["MEO3"] as string;
                    subTaskResearchRootCause.timespent = (row["TimeSpent3"] as string) == null ? 0 : double.Parse(row["TimeSpent3"] as string);
                    if (!String.IsNullOrEmpty(subTaskResearchRootCause.key) && subTaskResearchRootCause.timespent <= 0) SubTaskItems.Add(subTaskResearchRootCause);

                    SubTask subTaskCodeFixDev = new SubTask();
                    subTaskCodeFixDev.key = row["CodeFixDev"] as string;
                    subTaskCodeFixDev.name = "Code Fix(Dev)";
                    subTaskCodeFixDev.assignee = row["Assignee4"] as string;
                    subTaskCodeFixDev.status = row["Status4"] as string;
                    subTaskCodeFixDev.MEO = row["MEO4"] as string;
                    subTaskCodeFixDev.timespent = (row["TimeSpent4"] as string) == null ? 0 : double.Parse(row["TimeSpent4"] as string);
                    if (!String.IsNullOrEmpty(subTaskCodeFixDev.key) && subTaskCodeFixDev.timespent <= 0) SubTaskItems.Add(subTaskCodeFixDev);

                    SubTask subTaskWriteTestCaseQA = new SubTask();
                    subTaskWriteTestCaseQA.key = row["WriteTestCaseQA"] as string;
                    subTaskWriteTestCaseQA.name = "Write Test Case(QA)";
                    subTaskWriteTestCaseQA.assignee = row["Assignee5"] as string;
                    subTaskWriteTestCaseQA.status = row["Status5"] as string;
                    subTaskWriteTestCaseQA.MEO = row["MEO5"] as string;
                    subTaskWriteTestCaseQA.timespent = (row["TimeSpent5"] as string) == null ? 0 : double.Parse(row["TimeSpent5"] as string);
                    if (!String.IsNullOrEmpty(subTaskWriteTestCaseQA.key) && subTaskWriteTestCaseQA.timespent <= 0) SubTaskItems.Add(subTaskWriteTestCaseQA);

                    SubTask subTaskExecuteTestCaseQA = new SubTask();
                    subTaskExecuteTestCaseQA.key = row["ExecuteTestCaseQA"] as string;
                    subTaskExecuteTestCaseQA.name = "Execute Test Case(QA)";
                    subTaskExecuteTestCaseQA.assignee = row["Assignee6"] as string;
                    subTaskExecuteTestCaseQA.status = row["Status6"] as string;
                    subTaskExecuteTestCaseQA.MEO = row["MEO6"] as string;
                    subTaskExecuteTestCaseQA.timespent = (row["TimeSpent6"] as string) == null ? 0 : double.Parse(row["TimeSpent6"] as string);
                    if (!String.IsNullOrEmpty(subTaskExecuteTestCaseQA.key) && subTaskExecuteTestCaseQA.timespent <= 0) SubTaskItems.Add(subTaskExecuteTestCaseQA);

                    SubTask subTaskWriteReleaseNotesDev = new SubTask();
                    subTaskWriteReleaseNotesDev.key = row["WriteReleaseNotesDev"] as string;
                    subTaskWriteReleaseNotesDev.name = "Write Release Notes(Dev)";
                    subTaskWriteReleaseNotesDev.assignee = row["Assignee7"] as string;
                    subTaskWriteReleaseNotesDev.status = row["Status7"] as string;
                    subTaskWriteReleaseNotesDev.MEO = row["MEO7"] as string;
                    subTaskWriteReleaseNotesDev.timespent = (row["TimeSpent7"] as string) == null ? 0 : double.Parse(row["TimeSpent7"] as string);
                    if (!String.IsNullOrEmpty(subTaskWriteReleaseNotesDev.key) && subTaskWriteReleaseNotesDev.timespent <= 0) SubTaskItems.Add(subTaskWriteReleaseNotesDev);

                    SubTask subTaskReviewReleaseNotesQA = new SubTask();
                    subTaskReviewReleaseNotesQA.key = row["ReviewReleaseNotesQA"] as string;
                    subTaskReviewReleaseNotesQA.name = "Review Release Notes(QA)";
                    subTaskReviewReleaseNotesQA.assignee = row["Assignee8"] as string;
                    subTaskReviewReleaseNotesQA.status = row["Status8"] as string;
                    subTaskReviewReleaseNotesQA.MEO = row["MEO8"] as string;
                    subTaskReviewReleaseNotesQA.timespent = (row["TimeSpent8"] as string) == null ? 0 : double.Parse(row["TimeSpent8"] as string);
                    if (!String.IsNullOrEmpty(subTaskReviewReleaseNotesQA.key) && subTaskReviewReleaseNotesQA.timespent <= 0) SubTaskItems.Add(subTaskReviewReleaseNotesQA);
                }
            }

            string unusedSubTaskReport = "";
            unusedSubTaskReport = @"<table cellspacing='1' cellpadding='1' border='0' bgcolor='111111' style='border-collapse:collapse;border-spacing:0;border-left:1px solid #888;border-top:1px solid #888;background:#efefef;'>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>No</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Sub Task Key</td>
                                                <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Sub Task Name</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Assignee</td> 
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Status</td> 
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Time Spent(h)</td> 
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>M.E.O</td> 
                                            </tr>";
            int index = 1;
            foreach (var sunTaskItem in SubTaskItems)
            {
                unusedSubTaskReport += String.Format(@" <tr>
                                                            <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{0}</td>
                                                            <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://accelaeng.atlassian.net/browse/{1}'>{1}</a></td>
                                                            <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{2}</td>
                                                            <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{3}</td> 
                                                            <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{4}</td> 
                                                            <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{5}</td> 
                                                            <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{6}</td> 
                                                        </tr>", 
                                                            index++,
                                                            sunTaskItem.key,
                                                            sunTaskItem.name,
                                                            sunTaskItem.assignee,
                                                            sunTaskItem.status,
                                                            sunTaskItem.timespent,
                                                            sunTaskItem.MEO);
            }

            unusedSubTaskReport += "</table>";

            string content = @"Hi, All guys<br/><br/>Below is the unused sub task report.<br/><br/>" + unusedSubTaskReport + "<br/><br/>Thanks<br/>Accela Support Team";
            string fromEmailAddress = "auto_sender@missionsky.com";
            string toEmailAddress = "peter.peng@missionsky.com;";
            if (DateTime.Now.Hour >= 17)
            {
                toEmailAddress += "rleung@accela.com;accela.robinson@gmail.com;jlu@accela.com";
            }

            string ccEmailAddress = "accela-support-team@missionsky.com";
            string subject = "Unused Sub Task Summary - [" + this.dtpFrom.Value.ToString("MM/dd/yyyy") + "-" + this.dtpTo.Value.ToString("MM/dd/yyyy") + "]";

            try
            {
                EmailUtil.SendEmail(fromEmailAddress, toEmailAddress, ccEmailAddress, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSendUnusedSubTasks.Enabled = true;
        }

        private void btnSendMEOReport_Click(object sender, EventArgs e)
        {

        }

        class JiraIssue
        {
            public string key { get; set; }
            public string issueType { get; set; }
            public string name { get; set; }
            public string assignee { get; set; }
            public string assigneeEmailAddress { get; set; }
            public string assigneeDisplayName { get; set; }
            public string status { get; set; }
            public int timespent { get; set; }
            public Dictionary<string, SubTask> subtasks { get; set; }
        }

        class SubTask
        {
            public string key { get; set; }
            public string name { get; set; }
            public string assignee { get; set; }
            public string status { get; set; }
            public string MEO { get; set; }
            public double timespent { get; set; }
            public List<WorkLog> worklogs { get; set; }
        }

        class WorkLog
        {
            public string assignee { get; set; }
            public string assigneeEmailAddress { get; set; }
            public string timeSpent { get; set; }
            public string comment { get; set; }
        }
    }
}
