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
    public partial class DailyWorkLogForm1 : Form
    {
        public DailyWorkLogForm1()
        {
            InitializeComponent();

            this.dtpFrom.Value = DateTime.Today;
            this.dtpTo.Value = DateTime.Today.AddDays(1);
        }

        private List<string> GetSupportTeamMembers()
        {
            List<string> members = new List<string>();

            //members.Add("peter.peng@missionsky.com");        
            members.Add("john.huang@missionsky.com");
            members.Add("louis.he@missionsky.com");
            members.Add("likko.zhang");
            members.Add("alex.li@missionsky.com");
            members.Add("andy.li@missionsky.com");
            members.Add("ainy.xiao@missionsky.com");
     

            members.Add("bass.yang@missionsky.com");
            
            members.Add("felix.chen@missionsky.com");
            members.Add("kevin.chen@missionsky.com");
            members.Add("clare.han@missionsky.com");
            members.Add("tracy.xiang@missionsky.com");

            members.Add("gordon.chen@missionsky.com");
            members.Add("jane.hu@missionsky.com");
            members.Add("Linda.Xiao@missionsky.comLinda.Xiao");
            members.Add("leo.liu@missionsky.com");
            members.Add("jessy.zhang@missionsky.com");
            members.Add("jenna.zhang@missionsky.com");
            members.Add("venli.li@missionsky.com");

            members.Add("jlu@accela.com");
           

            return members;
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;

            DateTime from = this.dtpFrom.Value;
            DateTime to = this.dtpTo.Value;
            var issueList = await JiraProxy.GetUpdatedIssueListByAssigneeList(from, to, GetSupportTeamMembers());
            
            if (issueList == null || issueList.Count == 0)
            {
                this.btnSync.Enabled = true;
                return;
            }

            Dictionary<string, List<IndividualWorkLog>> IndividualWorkLogs = new Dictionary<string, List<IndividualWorkLog>>();
            foreach (var issue in issueList)
            {
                if (issue == null) continue;

                /*
                string taskKey = issue.fields.parent.key;
                string taskSummary = issue.fields.parent.fields.summary;
                string taskType = issue.fields.parent.fields.issuetype.name;
                string subTaskkey = issue.key;
                string subTaskSummary = issue.fields.summary;
                */

                string issueType = issue.fields.issueType.name;
                IndividualWorkLog individualWorkLog = new IndividualWorkLog();

                if ("Sub-task".Equals(issueType, StringComparison.InvariantCultureIgnoreCase))
                {
                    /*
                     * issue.fields.assignee.name = "gordon.chen@missionsky.com"
                     * issue.fields.assignee.emailAddress = "gordon.chen@missionsky.com"
                     * issue.fields.assignee.displayName = "Gordon Chen"
                     * issue.fields.issueType.name = "Sub-task"
                     * issue.fields.issueType.subtask = true
                     * issue.fields.parent.key = "ENGSUPP-14215"
                     * issue.fields.parent.fields.summary = "Unable to delete logs in Batch Engine"
                     * issue.fields.parent.fields.status.name = "In Progress"
                     */
                    var workLogs = await JiraProxy.GetWorklogs(issue);
                    if (workLogs != null && workLogs.Count > 0)
                    {
                        foreach (var worklog in workLogs)
                        {
                            if (DateTime.Compare(worklog.created, from) >= 0 && DateTime.Compare(worklog.created, to) <= 0)
                            {
                                individualWorkLog = new IndividualWorkLog();
                                individualWorkLog.subTaskKey = issue.key;
                                individualWorkLog.subTaskSummary = issue.fields.summary;
                                individualWorkLog.subTaskAssignee = issue.fields.assignee.displayName;
                                individualWorkLog.jiraIssueKey = issue.fields.parent.key;
                                individualWorkLog.jiraIssueSummary = issue.fields.parent.fields.summary;

                                individualWorkLog.assignee = worklog.author.displayName;
                                individualWorkLog.assigneeEmailAddress = worklog.author.emailAddress;
                                individualWorkLog.timeSpent = worklog.timeSpent;
                                individualWorkLog.comment = worklog.comment.Replace("\r\n", ";");

                                if (!IndividualWorkLogs.ContainsKey(individualWorkLog.jiraIssueKey))
                                {
                                    IndividualWorkLogs.Add(individualWorkLog.jiraIssueKey, new List<IndividualWorkLog>());
                                }
                                List<IndividualWorkLog> individualWorkLogList = IndividualWorkLogs[individualWorkLog.jiraIssueKey];
                                individualWorkLogList.Add(individualWorkLog);
                                IndividualWorkLogs[individualWorkLog.jiraIssueKey] = individualWorkLogList;
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No work log on " + issue.key);
                    }
                }
                else
                {
                    var workLogs = await JiraProxy.GetWorklogs(issue);
                    if (workLogs != null && workLogs.Count > 0)
                    {
                        foreach (var worklog in workLogs)
                        {
                            System.Console.WriteLine("Work Log are created on " + worklog.created);

                            if (DateTime.Compare(worklog.created, from) >= 0 && DateTime.Compare(worklog.created, to) <= 0)
                            {
                                individualWorkLog = new IndividualWorkLog();
                                //individualWorkLog.subTaskKey = issue.fields.parent.key;
                                //individualWorkLog.subTaskSummary = issue.fields.summary;
                                //individualWorkLog.subTaskAssignee = issue.fields.assignee.displayName;
                                individualWorkLog.jiraIssueKey = issue.key;
                                individualWorkLog.jiraIssueSummary = issue.fields.summary;

                                individualWorkLog.assignee = worklog.author.displayName;
                                individualWorkLog.assigneeEmailAddress = worklog.author.emailAddress;
                                individualWorkLog.timeSpent = worklog.timeSpent;
                                individualWorkLog.comment = worklog.comment.Replace("\r\n", ";");

                                if (!IndividualWorkLogs.ContainsKey(individualWorkLog.jiraIssueKey))
                                {
                                    IndividualWorkLogs.Add(individualWorkLog.jiraIssueKey, new List<IndividualWorkLog>());
                                }
                                List<IndividualWorkLog> individualWorkLogList = IndividualWorkLogs[individualWorkLog.jiraIssueKey];
                                individualWorkLogList.Add(individualWorkLog);
                                IndividualWorkLogs[individualWorkLog.jiraIssueKey] = individualWorkLogList;
                            }
                            else {
                                System.Console.WriteLine("Work Log cannot be added.");
                            }
                        }
                    }
                    else
                    {
                        System.Console.WriteLine("No work log on " + issue.key);
                    }
                }
            }

            if (IndividualWorkLogs.Count == 0)
            {
                this.btnSync.Enabled = true;
                return;
            }

            DataTable table = new DataTable("Daily Work Log Report");
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("Name", typeof(string));
            table.Columns.Add("EmailAddress", typeof(string));
            table.Columns.Add("Effort", typeof(string));
            table.Columns.Add("SubTaskID", typeof(string));
            table.Columns.Add("SubTaskSummary", typeof(string));
            table.Columns.Add("SubTaskAssignee", typeof(string));
            table.Columns.Add("SubTaskComment", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("JiraSummary", typeof(string));

            int index = 1;
            foreach (string key in IndividualWorkLogs.Keys)
            {
                List<IndividualWorkLog> individualWorkLogList = IndividualWorkLogs[key];
                foreach (var workLog in individualWorkLogList)
                {
                    DataRow row = table.NewRow();
                    row["No"] = index;
                    row["Name"] = workLog.assignee;
                    row["EmailAddress"] = workLog.assigneeEmailAddress;
                    row["Effort"] = workLog.timeSpent;
                    row["SubTaskID"] = workLog.subTaskKey;
                    row["SubTaskSummary"] = workLog.subTaskSummary;
                    row["SubTaskAssignee"] = workLog.subTaskAssignee;
                    row["SubTaskComment"] = workLog.comment;
                    row["JiraKey"] = workLog.jiraIssueKey;
                    row["JiraSummary"] = workLog.jiraIssueSummary;

                    table.Rows.Add(row);
                    index++;
                }
            }

            dgvWorkLogReport.AutoGenerateColumns = false;
            dgvWorkLogReport.DataSource = table;            
            this.btnSync.Enabled = true;
        }

        private async void btnAssign_Click(object sender, EventArgs e)
        {
            this.btnAssign.Enabled = false;

            DataTable dataTable = dgvWorkLogReport.DataSource as DataTable;
            if (dataTable != null)
            {
                string Name = "";
                string EmailAddress = "";
                string Effort = "";
                string SubTaskID = "";
                string SubTaskSummary = "";
                string SubTaskAssignee = "";
                string SubTaskComment = "";
                string JiraKey = "";
                string JiraSummary = "";

                int rowCount = dataTable.Rows.Count;
                for (int k = 0; k < rowCount; k++)
                {
                    DataRow row = dataTable.Rows[k];                    

                    Name = row["Name"] as string;
                    EmailAddress = row["EmailAddress"] as string;
                    Effort = row["Effort"] as string;
                    SubTaskID = row["SubTaskID"] as string;
                    SubTaskSummary = row["SubTaskSummary"] as string;
                    SubTaskAssignee = row["SubTaskAssignee"] as string;
                    SubTaskComment = row["SubTaskComment"] as string;
                    JiraKey = row["JiraKey"] as string;
                    JiraSummary = row["JiraSummary"] as string;

                    if (!String.IsNullOrEmpty(SubTaskID) 
                        && !Name.Equals(SubTaskAssignee, StringComparison.InvariantCultureIgnoreCase))
                    {
                        IssueRef issueRef = new IssueRef();
                        issueRef.key = SubTaskID;

                        var issue = await JiraProxy.LoadIssue(issueRef);
                        if (issue == null || issue.fields == null)
                        {
                            return;
                        }

                        // https://accelaeng.atlassian.net/rest/api/2/user/picker?query=peter.peng@missionsky.com
                        JiraUser jiraUser = new JiraUser();

                        if ("likko.zhang@missionsky.com" == EmailAddress)
                        {
                            EmailAddress = "likko.zhang";
                        }
                        jiraUser.name = EmailAddress;
                        issue.fields.assignee = jiraUser;

                        JiraProxy.UpdateSubTask(issue);
                    }
                }
            }

            this.btnAssign.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.btnSend.Enabled = false;

            DataTable dataTable = dgvWorkLogReport.DataSource as DataTable;

            DataView dataTableView = dataTable.DefaultView;
            dataTableView.Sort = "Name ASC";
            dataTable = dataTableView.ToTable();

            Dictionary<string, List<IndividualWorkLog>> IndividualWorkLogs = new Dictionary<string, List<IndividualWorkLog>>();
            if (dataTable != null)
            {
                string Name = "";
                string EmailAddress = "";
                string Effort = "";
                string SubTaskID = "";
                string SubTaskSummary = "";
                string SubTaskAssignee = "";
                string SubTaskComment = "";
                string JiraKey = "";
                string JiraSummary = "";

                int rowCount = dataTable.Rows.Count;
                for (int k = 0; k < rowCount; k++)
                {
                    DataRow row = dataTable.Rows[k];

                    Name = row["Name"] as string;
                    EmailAddress = row["EmailAddress"] as string;
                    Effort = row["Effort"] as string;
                    SubTaskID = row["SubTaskID"] as string;
                    SubTaskSummary = row["SubTaskSummary"] as string;
                    SubTaskAssignee = row["SubTaskAssignee"] as string;
                    SubTaskComment = row["SubTaskComment"] as string;
                    JiraKey = row["JiraKey"] as string;
                    JiraSummary = row["JiraSummary"] as string;

                    IndividualWorkLog workLog = new IndividualWorkLog();
                    workLog.assignee = Name;
                    workLog.assigneeEmailAddress = EmailAddress;
                    workLog.timeSpent = Effort;
                    workLog.subTaskKey = SubTaskID;
                    workLog.subTaskSummary = SubTaskSummary;
                    workLog.subTaskAssignee = SubTaskAssignee;
                    workLog.comment = SubTaskComment;
                    workLog.jiraIssueKey = JiraKey;
                    workLog.jiraIssueSummary = JiraSummary;

                    if (!IndividualWorkLogs.ContainsKey(Name))
                    {
                        IndividualWorkLogs.Add(Name, new List<IndividualWorkLog>());
                    }
                    List<IndividualWorkLog> individualWorkList = IndividualWorkLogs[Name];
                    individualWorkList.Add(workLog);
                    IndividualWorkLogs[Name] = individualWorkList;
                }
            }

            string dailyWorkLogSummaryReport = "";
            dailyWorkLogSummaryReport = @"<table cellspacing='1' cellpadding='1' border='0' bgcolor='111111' style='border-collapse:collapse;border-spacing:0;border-left:1px solid #888;border-top:1px solid #888;background:#efefef;'>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>No</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Name</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Work Logs</td>                                               
                                            </tr>";

            int i = 1;
            foreach(string name in IndividualWorkLogs.Keys)
            {
                dailyWorkLogSummaryReport += "  <tr>";
                dailyWorkLogSummaryReport += "      <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>" + i + "</td>";
                dailyWorkLogSummaryReport += "      <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>" + name + "</td>";
                dailyWorkLogSummaryReport += "      <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>";

                int j = 1;
                List<IndividualWorkLog> workLogs = IndividualWorkLogs[name];
                foreach (var worklog in workLogs)
                {
                    dailyWorkLogSummaryReport += "" + j + ") <a href='https://accelaeng.atlassian.net/browse/" + worklog.jiraIssueKey + "'>" + worklog.jiraIssueKey + "</a> - " + worklog.jiraIssueSummary + "<br/>";
                    if (String.IsNullOrEmpty(worklog.subTaskKey) || worklog.subTaskKey.Trim().Length == 0)
                    {
                        dailyWorkLogSummaryReport += "&nbsp;&nbsp;&nbsp;&nbsp;[No Sub Task] " + worklog.timeSpent + " - " + worklog.comment + "<br/>";
                    }
                    else
                    {
                        dailyWorkLogSummaryReport += "&nbsp;&nbsp;&nbsp;&nbsp;[<a href='https://accelaeng.atlassian.net/browse/" + worklog.subTaskKey + "'>" + worklog.subTaskSummary + "</a>] " + worklog.timeSpent + " - " + worklog.comment + "<br/>";
                    }
                    dailyWorkLogSummaryReport += "<br/>";
                    j++;
                }

                dailyWorkLogSummaryReport += "      </td>";
                dailyWorkLogSummaryReport += "  </tr>";

                i++;
            }

            dailyWorkLogSummaryReport += "</table>";

            string content = @"Hi, All<br/><br/>Below is the work log summary report.<br/><br/>" + dailyWorkLogSummaryReport + "<br/><br/>Thanks<br/>Accela Support Team";
            string fromEmailAddress = "auto_sender@missionsky.com";
            string toEmailAddress = "peter.peng@missionsky.com;";
            if (DateTime.Now.Hour >= 17)
            {
                toEmailAddress += "rleung@accela.com;accela.robinson@gmail.com;jlu@accela.com";
            }

            string ccEmailAddress = "accela-support-team@missionsky.com";
            string subject = "Daily Work Log Summary - [" + this.dtpFrom.Value.ToString("MM/dd/yyyy") + "-" + this.dtpTo.Value.ToString("MM/dd/yyyy") + "]";

            try
            {
                EmailUtil.SendEmail(fromEmailAddress, toEmailAddress, ccEmailAddress, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            System.Console.WriteLine(dailyWorkLogSummaryReport);

            this.btnSend.Enabled = true;
        }

        class IndividualWorkLog
        {
            public string assignee { get; set; }
            public string assigneeEmailAddress { get; set; }
            public string timeSpent { get; set; }
            public string comment { get; set; }
            public string subTaskKey { get; set; }
            public string subTaskSummary { get; set; }
            public string subTaskAssignee { get; set; }            
            public string jiraIssueKey { get; set; }
            public string jiraIssueSummary { get; set; }
        }
    }
}
