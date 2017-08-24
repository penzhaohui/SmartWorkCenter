using com.smartwork.Proxy;
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
    public partial class BatchMEOForm : Form
    {
        public BatchMEOForm()
        {
            InitializeComponent();

            List<string> SubTaskStatusOptions = new List<string>();
            SubTaskStatusOptions.Add("Empty");
            SubTaskStatusOptions.Add("Open");
            SubTaskStatusOptions.Add("Reopened");
            SubTaskStatusOptions.Add("Pending");
            SubTaskStatusOptions.Add("In Progress");
            SubTaskStatusOptions.Add("Development in Progress");
            SubTaskStatusOptions.Add("Resolved");
            SubTaskStatusOptions.Add("Closed");
            this.cmbSubTaskStatusOptions.DataSource = SubTaskStatusOptions;
           
            List<string> MEOOptions = new List<string>();
            MEOOptions.Add("Empty");
            MEOOptions.Add("Meets");
            MEOOptions.Add("Exceeds");
            MEOOptions.Add("Outstanding");
            this.cmbMEOOptions.DataSource = MEOOptions;

            List<string> DefaultMEOOptions = new List<string>();
            DefaultMEOOptions.Add("Empty");
            DefaultMEOOptions.Add("Meets");
            DefaultMEOOptions.Add("Exceeds");
            DefaultMEOOptions.Add("Outstanding");
            this.cmbDefautMEO.DataSource = DefaultMEOOptions;
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;

            try
            {
                DateTime from = this.dtpFrom.Value;
                DateTime to = this.dtpTo.Value;
                string userName = this.txtUser.Text;
                string password = this.txtPassword.Text;

                string MEOOption = this.cmbMEOOptions.SelectedValue as string;
                string status = this.cmbSubTaskStatusOptions.SelectedValue as string;

                if (String.IsNullOrEmpty(userName) || userName.Trim().Length == 0 || String.IsNullOrEmpty(password) || password.Trim().Length == 0)
                {
                    MessageBox.Show("User Name and Password cannot be empty.");
                    this.btnSync.Enabled = true;
                    return;
                }

                List<string> subTaskStatusList = new List<string>();
                if (String.IsNullOrEmpty(status) && status.Trim().Length > 0 && status == "Empty")
                {
                    subTaskStatusList.Add(status);
                }

                List<string> meoOptions = new List<string>();
                if (!String.IsNullOrEmpty(MEOOption) && MEOOption.Trim().Length > 0 && MEOOption != "Empty")
                {
                    meoOptions.Add(MEOOption);
                }                

                var issues = await JiraProxy.GetUpdatedIssueListByTimeslot(userName, password, from, to, subTaskStatusList, meoOptions);

                /*
                 * issue.fields.assignee.name = "gordon.chen@missionsky.com"
                 * issue.fields.assignee.emailAddress = "gordon.chen@missionsky.com"
                 * issue.fields.assignee.displayName = "Gordon Chen"
                 * issue.fields.issueType.name = "Sub-task"
                 * issue.fields.issueType.subtask = true
                 * issue.fields.parent.key = "ENGSUPP-14215"
                 * issue.fields.parent.fields.summary = "Unable to delete logs in Batch Engine"
                 * issue.fields.parent.fields.status.name = "In Progress"
                 * */

                string defaultMEO = this.cmbDefautMEO.SelectedValue as string;
                if (defaultMEO == "Empty")
                {
                    defaultMEO = "";
                }

                List<SubTask> SubTaskList = new List<SubTask>();
                foreach (var issue in issues)
                {
                    SubTask subTask = new SubTask();
                    subTask.SubTaskKey = issue.key;
                    subTask.SubTaskSummary = issue.fields.summary;
                    subTask.SubTaskStatus = issue.fields.status.name;
                    subTask.SubTaskAssignee = issue.fields.assignee.displayName;
                    subTask.MEO = issue.fields.customfield_14101 != null ? issue.fields.customfield_14101.value : defaultMEO;
                    subTask.TimeSpent = "" + Math.Round((double)issue.fields.timespent / 3600, 2) + "h";
                    subTask.AssociatedJirakey = issue.fields.parent.key;
                    subTask.AssociatedJiraSummary = issue.fields.parent.fields.summary;

                    SubTaskList.Add(subTask);
                }

                DataTable table = new DataTable("M.E.O Report");
                table.Columns.Add("No", typeof(int));
                table.Columns.Add("SubTaskKey", typeof(string));
                table.Columns.Add("SubTaskSummary", typeof(string));
                table.Columns.Add("SubTaskStatus", typeof(string));
                table.Columns.Add("SubTaskAssignee", typeof(string));
                table.Columns.Add("MEO", typeof(string));
                table.Columns.Add("TimeSpent", typeof(string));
                table.Columns.Add("AssociatedJirakey", typeof(string));
                table.Columns.Add("AssociatedJiraSummary", typeof(string));

                int index = 1;
                foreach (var subTask in SubTaskList)
                {
                    DataRow row = table.NewRow();
                    row["No"] = index;
                    row["SubTaskKey"] = subTask.SubTaskKey;
                    row["SubTaskSummary"] = subTask.SubTaskSummary;
                    row["SubTaskStatus"] = subTask.SubTaskStatus;
                    row["SubTaskAssignee"] = subTask.SubTaskAssignee;
                    row["MEO"] = subTask.MEO;
                    row["TimeSpent"] = subTask.TimeSpent;
                    row["AssociatedJirakey"] = subTask.AssociatedJirakey;
                    row["AssociatedJiraSummary"] = subTask.AssociatedJiraSummary;

                    table.Rows.Add(row);
                    index++;
                }

                this.dgvSubTaskTable.AutoGenerateColumns = false;
                this.dgvSubTaskTable.DataSource = table;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.btnSync.Enabled = true;
        }

        class SubTask
        {
            public string SubTaskKey { get; set; }
            public string SubTaskSummary { get; set; }
            public string SubTaskStatus { get; set; }
            public string SubTaskAssignee { get; set; }
            public string MEO { get; set; }
            public string TimeSpent { get; set; }
            public string AssociatedJirakey { get; set; }
            public string AssociatedJiraSummary { get; set; }
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            this.btnSubmit.Enabled = false;

            DataTable dataTable = dgvSubTaskTable.DataSource as DataTable;
            if (dataTable != null)
            {
                string SubTaskKey = "";                
                string MEO = "";

                int rowCount = dataTable.Rows.Count;
                for (int k = 0; k < rowCount; k++)
                {
                    DataRow row = dataTable.Rows[k];

                    SubTaskKey = row["SubTaskKey"] as string;
                    MEO = row["MEO"] as string;

                    if (!String.IsNullOrEmpty(SubTaskKey) 
                        && !String.IsNullOrEmpty(MEO)
                        && MEO.Trim().Length > 0)
                    {
                        IssueRef issueRef = new IssueRef();
                        issueRef.key = SubTaskKey;

                        var issue = await JiraProxy.LoadIssue(issueRef);
                        if (issue == null || issue.fields == null)
                        {
                            return;
                        }

                        issue.fields.customfield_14101 = new MEOOption();
                        issue.fields.customfield_14101.value = MEO;

                        JiraProxy.UpdateSubTask(issue);
                    }
                }
            }

            this.btnSubmit.Enabled = true;
        }
    }
}
