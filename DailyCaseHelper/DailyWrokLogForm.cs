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
    public partial class DailyWrokLogForm : Form
    {
        public DailyWrokLogForm()
        {
            InitializeComponent();
            btnCreateSubTask.Enabled = false;
        }

        private async void btnListWorkLogList_Click(object sender, EventArgs e)
        {
            this.btnListWorkLogList.Enabled = false;

            DateTime from = this.dtpFrom.Value;
            DateTime to = this.dtpTo.Value;

            from = DateTime.Today.AddDays(-1);
            to = DateTime.Today.AddDays(1);

            var GetUpdatedIssueListByAssignee = JiraProxy.GetUpdatedIssueListByTimeslot(from, to);
            var issueList = await GetUpdatedIssueListByAssignee;

            if (issueList == null || issueList.Count == 0)
            {
                return;
            }

            Dictionary<string, JiraTask> workLogsStore = new Dictionary<string, JiraTask>();
            foreach (var issue in issueList)
            {
                if (issue == null) continue;

                string taskKey = issue.fields.parent.key;
                string taskSummary = issue.fields.parent.fields.summary;
                string taskType = issue.fields.parent.fields.issuetype.name;
                string subTaskkey = issue.key;
                string subTaskSummary = issue.fields.summary;

                var workLogs = await JiraProxy.GetWorklogs(issue);
                if (workLogs != null && workLogs.Count > 0)
                {
                    foreach (var worklog in workLogs)
                    {
                        if (worklog.created.Year == DateTime.Today.Year
                            && worklog.created.Month == DateTime.Today.Month
                            && worklog.created.Day == DateTime.Today.Day)
                        {
                            if (!workLogsStore.ContainsKey(taskKey))
                            {
                                JiraTask jiraTask = new JiraTask();
                                jiraTask.Key = taskKey;
                                jiraTask.summary = taskSummary;
                                jiraTask.Type = taskType;
                                jiraTask.subTasks = new Dictionary<string, SubTask>();
                                workLogsStore.Add(taskKey, jiraTask);
                            }

                            JiraTask jiraTask1 = workLogsStore[taskKey];                            
                            if (!jiraTask1.subTasks.ContainsKey(subTaskkey))
                            {
                                SubTask subTask = new SubTask();
                                subTask.Key = subTaskkey;
                                subTask.summary = subTaskSummary;
                                jiraTask1.subTasks.Add(subTaskkey, subTask);
                            }

                            SubTask subTask1 = jiraTask1.subTasks[subTaskkey];
                            if (subTask1.worklogs == null)
                            {
                                subTask1.worklogs = new List<Worklog>();
                            }

                            Worklog workLog = new Worklog();
                            workLog.displayName = worklog.author.displayName;
                            workLog.timeSpent = worklog.timeSpent;
                            workLog.comment = worklog.comment.Replace("\r\n",";");
                            subTask1.worklogs.Add(workLog);

                            jiraTask1.subTasks[subTaskkey] = subTask1;
                            workLogsStore[taskKey] = jiraTask1;
                        }
                    }
                }
            }

            /*
            string dailyWorkLogSummaryReport = "";
            int index1 = 1;
            foreach (string taskKey in workLogsStore.Keys)
            {
                JiraTask jiraTask = workLogsStore[taskKey];

                dailyWorkLogSummaryReport += index1 + " " + jiraTask.Type + " - " + taskKey + " " + jiraTask.summary + "<br/>";

                int index2 = 1;
                foreach (string subTaskkey in jiraTask.subTasks.Keys)
                {
                    SubTask subTask = jiraTask.subTasks[subTaskkey];

                    dailyWorkLogSummaryReport += index1 + "." + index2 + " Sub Task: " + subTaskkey + " " + subTask.summary + "<br/>";

                    int index3 = 1;
                    foreach (var workLog in subTask.worklogs)
                    {
                        dailyWorkLogSummaryReport += index1 + "." + index2 + "." + index3 + " " + workLog.displayName + "[" + workLog.timeSpent + "]" + workLog.comment + "<br/>";

                        index3++;
                    }

                    index2++;
                }

                dailyWorkLogSummaryReport += "<br/><br/>";
                index1++;
            }
            */

            string dailyWorkLogSummaryReport = "";
            Dictionary<string, List<IndividualWorkLog>> IndividualWorkLogs = new Dictionary<string, List<IndividualWorkLog>>();
            foreach (string taskKey in workLogsStore.Keys)
            {
                JiraTask jiraTask = workLogsStore[taskKey];
                foreach (string subTaskkey in jiraTask.subTasks.Keys)
                {
                    SubTask subTask = jiraTask.subTasks[subTaskkey];
                    foreach (var workLog in subTask.worklogs)
                    {
                        IndividualWorkLog individualWorkLog = new IndividualWorkLog();
                        individualWorkLog.jiraKey = taskKey;
                        individualWorkLog.summary = jiraTask.summary;
                        individualWorkLog.subTaskSummary = subTask.summary;
                        individualWorkLog.timeSpent = workLog.timeSpent;
                        individualWorkLog.comment = workLog.comment;

                        if (!IndividualWorkLogs.ContainsKey(workLog.displayName))
                        {
                            IndividualWorkLogs.Add(workLog.displayName, new List<IndividualWorkLog>());
                        }
                        List<IndividualWorkLog> workLogs = IndividualWorkLogs[workLog.displayName];
                        workLogs.Add(individualWorkLog);
                        IndividualWorkLogs[workLog.displayName] = workLogs;
                    }
                }
            }

            dailyWorkLogSummaryReport = @"<table cellspacing='1' cellpadding='1' border='0' bgcolor='111111' style='border-collapse:collapse;border-spacing:0;border-left:1px solid #888;border-top:1px solid #888;background:#efefef;'>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>No</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Name</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Work Logs</td>                                               
                                            </tr>";

            int i = 1;
            foreach (string name in IndividualWorkLogs.Keys)
            {
                dailyWorkLogSummaryReport += "  <tr>";
                dailyWorkLogSummaryReport += "      <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>" + i + "</td>";
                dailyWorkLogSummaryReport += "      <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>" + name + "</td>";
                dailyWorkLogSummaryReport += "      <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>";

                int j = 1;
                List<IndividualWorkLog> workLogs = IndividualWorkLogs[name];
                foreach (var worklog in workLogs)
                {
                    dailyWorkLogSummaryReport += "" + j + ") " + worklog.jiraKey + " - " + worklog.summary + "<br/>";
                    dailyWorkLogSummaryReport += "[" + worklog.subTaskSummary + "] "+ worklog.timeSpent + " - " + worklog.comment + "<br/>";
                    j++;
                }
                dailyWorkLogSummaryReport += "      </td>";
                dailyWorkLogSummaryReport += "  </tr>";

                i++;
            }

            dailyWorkLogSummaryReport += "</table>";

            string content = @"Hi, All guys<br/><br/>Below is the work log summary report.<br/><br/>" + dailyWorkLogSummaryReport + "Thanks<br/>Accela Support Team";
            string fromEmailAddress = "auto_sender@missionsky.com";
            string toEmailAddress = "peter.peng@missionsky.com;rleung@accela.com";
            string ccEmailAddress = "accela-support-team@missionsky.com";
            string subject = "Daily Work Log Summary - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

            try
            {
                EmailUtil.SendEmail(fromEmailAddress, toEmailAddress, ccEmailAddress, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            System.Console.WriteLine(dailyWorkLogSummaryReport);

            this.btnListWorkLogList.Enabled = true;
        }

        class IndividualWorkLog
        {
            public string jiraKey { get; set; }
            public string summary { get; set; }
            public string subTaskSummary { get; set; }
            public string timeSpent { get; set; }
            public string comment { get; set; }
        }

        class JiraTask
        {
            public string Key { get; set; }
            public string summary { get; set; }
            public string Type { get; set; }
            public Dictionary<string, SubTask> subTasks { get; set; }
        }

        class SubTask
        {           
            public string Key { get; set; }
            public string summary { get; set; }
            public List<Worklog> worklogs { get; set; }
        }

        class Worklog
        {
            public string Key { get; set; }
            public string displayName { get; set; }
            public string timeSpent { get; set; }
            public string comment { get; set; }
        }

        private async void btnCreateSubTask_Click(object sender, EventArgs e)
        {
            this.btnCreateSubTask.Enabled = false;
            string jiraKey = this.txtJiraKey.Text;

            //var subTaskReviewAndRecreateQA = new Task<string>();
            // Create Sub Task for Review Case
            if (this.chkReviewAndRecreateQA.Checked)
            {
                if (this.txtReviewAndRecreateQASubTaskKey.Text.Trim().Length == 0)
                {
                    createSubTask(this.chkReviewAndRecreateQA.Text, jiraKey);
                }
                else
                {
                    updateSubTask(this.txtReviewAndRecreateQASubTaskKey.Text, this.txtAssigneeQA.Text);
                }
            }

            //var subTaskReviewAndRecreateDev = new Task<string>();
            if (this.chkReviewAndRecreateDev.Checked)
            {
                if (this.txtReviewAndRecreateDevSubTaskKey.Text.Trim().Length == 0)
                {
                    createSubTask(this.chkReviewAndRecreateDev.Text, jiraKey);
                }
                else
                {
                    updateSubTask(this.txtReviewAndRecreateDevSubTaskKey.Text, this.txtAssignee.Text);
                }
            }

            // var subTaskResearchRootCause = new Task<string>();
            if (this.chkResearchRootCause.Checked)
            {
                if (this.txtResearchRootCauseSubTaskKey.Text.Trim().Length == 0)
                {
                    createSubTask(this.chkResearchRootCause.Text, jiraKey);
                }
                else
                {
                    updateSubTask(this.txtResearchRootCauseSubTaskKey.Text, this.txtAssignee.Text);
                }
            }

            // Create Sub Task for Bug Fix
            // var subTaskCodeFix = new Task<string>();
            if (this.chkCodeFix.Checked)
            {
                if (this.txtCodeFixSubTaskKey.Text.Trim().Length == 0)
                {
                    createSubTask(this.chkCodeFix.Text, jiraKey);
                }
                else
                {
                    updateSubTask(this.txtCodeFixSubTaskKey.Text, this.txtAssignee.Text);
                }
            }

            // var subTaskWriteTestCase = new Task<string>();
            if (this.chkWriteTestCase.Checked)
            {
                if (this.txtWriteTestCaseSubTaskKey.Text.Trim().Length == 0)
                {
                    createSubTask(this.chkWriteTestCase.Text, jiraKey);
                }
                else
                {
                    updateSubTask(this.txtWriteTestCaseSubTaskKey.Text, this.txtAssigneeQA.Text);
                }
            }

            // var subTaskExecuteTestCase = new Task<string>();
            if (this.chkExecuteTestCase.Checked)
            {
                if (this.txtExecuteTestCaseSubTaskKey.Text.Trim().Length == 0)
                {
                    createSubTask(this.chkExecuteTestCase.Text, jiraKey);
                }
                else
                {
                    updateSubTask(this.txtExecuteTestCaseSubTaskKey.Text, this.txtAssigneeQA.Text);
                }
            }

            // var subTaskWriteReleaseNotes = new Task<string>();
            if (this.chkWriteReleaseNotes.Checked)
            {
                if (this.txtWriteReleaseNotesSubTaskKey.Text.Trim().Length == 0)
                {
                    createSubTask(this.chkWriteReleaseNotes.Text, jiraKey);
                }
                else
                {
                    updateSubTask(this.txtWriteReleaseNotesSubTaskKey.Text, this.txtAssignee.Text);
                }  
            }

            // var subTaskReviewReleaseNotes = new Task<string>();
            if (this.chkReviewReleaseNotes.Checked)
            {
                if (this.txtReviewReleaseNotesSubTaskKey.Text.Trim().Length == 0)
                {
                    createSubTask(this.chkReviewReleaseNotes.Text, jiraKey);
                }
                else
                {
                    updateSubTask(this.txtReviewReleaseNotesSubTaskKey.Text, this.txtAssigneeQA.Text);
                }
            }

            btnCreateSubTask.Enabled = false;
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

        public async Task<string> createSubTask(string summary, string issueKey)
        {
            IssueRef issueRef = new IssueRef();
            issueRef.key = issueKey;

            string description = "";
            if ("Review and Recreate(QA)" == summary)
            {
                description =
@"*{color:red}Notice{color}*: 
* {color:red}Just log QA effort spent on reviewing and recreating the assicaited production case{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when this case is recreated";

            }

            if ("Review and Recreate(Dev)" == summary)
            {
                description =
@"*{color:red}Notice{color}*: 
* {color:red}Just log Dev effort spent on reviewing and recreating the assicaited production case{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when this case is recreated";
            }

            if ("Research Root Cause" == summary)
            {
                description =
@"*{color:red}Notice{color}*: 
* {color:red}Just log Dev effort spent on researching root cause after the assicaited production case is recreated{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when this root cause is found";
            }

            // Code Fix(Dev)
            if ("Code Fix(Dev)" == summary)
            {
                description =
@"*{color:red}Notice{color}*: 
* {color:red}Just log Dev effort spent on solving the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done";
            }

            // Write Test Case(QA)
            if ("Write Test Case(QA)" == summary)
            {
                description =
@"*{color:red}Notice{color}*: 
* {color:red}Just log QA effort spent on writing test case for the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done";
            }

            // Execute Test Case(QA)
            if ("Execute Test Case(QA)" == summary)
            {
                description =
@"*{color:red}Notice{color}*: 
* {color:red}Just log QA effort spent on executing test case for the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done";
            }

            // Write Release Notes(Dev)
            if ("Write Release Notes(Dev)" == summary)
            {
                description =
@"*{color:red}Notice{color}*: 
* {color:red}Just log Dev effort spent on writing release notes for the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done";
            }

            // Review Release Notes(QA)
            if ("Review Release Notes(QA)" == summary)
            {
                description =
@"*{color:red}Notice{color}*: 
* {color:red}Just log QA effort spent on reviewing release notes for the assicaited production bug{color}
* {color:red}Please DO NOT add comment in the sub task{color}

Following the below steps if you work on this sub task
# Assign this sub task to you
# Log all your effort spent on this case
# Post your comment in the parent jira ticket if neccessary
# Close this sub task when it is done";
            }

            var issue = await JiraProxy.CreateSubTask(summary, description, issueRef);

            return issue.key;
        }



        private async void btnCheckJiraKey_Click(object sender, EventArgs e)
        {
            this.btnCheckJiraKey.Enabled = false;

            string jiraKey = this.txtJiraKey.Text;

            IssueRef issueRef = new IssueRef();
            issueRef.key = jiraKey;

            var issue = await JiraProxy.LoadIssue(issueRef);

            if (issue == null || issue.fields == null)
            {
                return;
            }

            this.txtAssignee.Text = issue.fields.assignee.name;
            this.txtAssigneeQA.Text = issue.fields.customfield_11702 == null ? "" : issue.fields.customfield_11702.name;

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

            if ("Case".Equals(issue.fields.issueType.name, StringComparison.InvariantCultureIgnoreCase))
            {
                //this.btnCreateSubTask.Enabled = true;
                //this.chkReviewAndRecreateQA.Enabled = true;
                //this.chkReviewAndRecreateDev.Enabled = true;
                //this.chkResearchRootCause.Enabled = true;

                this.chkCodeFix.Enabled = false;
                //this.chkWriteTestCase.Enabled = false;
                //this.chkExecuteTestCase.Enabled = false;
                //this.chkWriteReleaseNotes.Enabled = false;
                //this.chkReviewReleaseNotes.Enabled = false;

                foreach (string key in SubTaskMaper.Keys)
                {
                    // Review and Recreate(QA)
                    if (this.chkReviewAndRecreateQA.Text == key)
                    {
                        //this.chkReviewAndRecreateQA.Enabled = false;
                        this.txtReviewAndRecreateQASubTaskKey.Text = SubTaskMaper[key];

                        var assignee = await JiraProxy.GetAssigneeByJiraKey(SubTaskMaper[key]);
                        this.txtReviewAndRecreateQAAssignee.Text = assignee;
                    }

                    // Review and Recreate(Dev)
                    if (this.chkReviewAndRecreateDev.Text == key)
                    {
                        //this.chkReviewAndRecreateDev.Enabled = false;
                        this.txtReviewAndRecreateDevSubTaskKey.Text = SubTaskMaper[key];

                        var assignee = await JiraProxy.GetAssigneeByJiraKey(SubTaskMaper[key]);
                        this.txtReviewAndRecreateDevAssignee.Text = assignee;
                    }

                    // Research Root Cause
                    if (this.chkResearchRootCause.Text == key)
                    {
                        //this.chkResearchRootCause.Enabled = false;
                        this.txtResearchRootCauseSubTaskKey.Text = SubTaskMaper[key];

                        var assignee = await JiraProxy.GetAssigneeByJiraKey(SubTaskMaper[key]);
                        this.txtResearchRootCauseAssignee.Text = assignee;
                    }
                }
            }
            

            if ("Bug".Equals(issue.fields.issueType.name, StringComparison.InvariantCultureIgnoreCase))
            {
                this.btnCreateSubTask.Enabled = true;
                this.chkReviewAndRecreateQA.Enabled = false;
                this.chkReviewAndRecreateDev.Enabled = false;
                this.chkResearchRootCause.Enabled = false;

                this.chkCodeFix.Enabled = true;
                this.chkWriteTestCase.Enabled = true;
                this.chkExecuteTestCase.Enabled = true;
                this.chkWriteReleaseNotes.Enabled = true;
                this.chkReviewReleaseNotes.Enabled = true;

                foreach (string key in SubTaskMaper.Keys)
                {
                    // Code Fix(Dev)
                    if (this.chkCodeFix.Text == key)
                    {
                        this.chkCodeFix.Enabled = false;
                        this.txtCodeFixSubTaskKey.Text = SubTaskMaper[key];
                    }

                    // Write Test Case(QA)
                    if (this.chkWriteTestCase.Text == key)
                    {
                        this.chkWriteTestCase.Enabled = false;
                        this.txtWriteTestCaseSubTaskKey.Text = SubTaskMaper[key];
                    }

                    // Execute Test Case(QA)
                    if (this.chkExecuteTestCase.Text == key)
                    {
                        this.chkExecuteTestCase.Enabled = false;
                        this.txtExecuteTestCaseSubTaskKey.Text = SubTaskMaper[key];
                    }

                    // Write Release Notes(Dev)
                    if (this.chkWriteReleaseNotes.Text == key)
                    {
                        this.chkWriteReleaseNotes.Enabled = false;
                        this.txtWriteReleaseNotesSubTaskKey.Text = SubTaskMaper[key];
                    }

                    // Review Release Notes(QA)
                    if (this.chkReviewReleaseNotes.Text == key)
                    {
                        this.chkReviewReleaseNotes.Enabled = false;
                        this.txtReviewReleaseNotesSubTaskKey.Text = SubTaskMaper[key];
                    }
                }
            }

            this.btnCreateSubTask.Enabled = true;
            this.btnCheckJiraKey.Enabled = true;
        }

        private async void btnCloseSubTask_Click(object sender, EventArgs e)
        {
            if (this.chkReviewAndRecreateQA.Checked)
            {
                if (this.txtReviewAndRecreateQASubTaskKey.Text.Trim().Length == 0)
                {                   
                }
                else
                {
                    CloseSubTaskk(this.txtReviewAndRecreateQASubTaskKey.Text);
                }
            }
        }

        private async void CloseSubTaskk(string subTaskKey)
        {
            IssueRef issueRef = new IssueRef();
            issueRef.key = subTaskKey;
            issueRef.id = subTaskKey;

            var issue = await JiraProxy.LoadIssue(issueRef);
            if (issue == null || issue.fields == null)
            {
                return;
            }           

            JiraProxy.CloseSubTask(issueRef);
        }
    }
}
