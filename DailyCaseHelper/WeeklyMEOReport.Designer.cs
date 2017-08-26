namespace com.smartwork
{
    partial class WeeklyMEOReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSync = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dgvSubTaskTable = new System.Windows.Forms.DataGridView();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnSendMEOReport = new System.Windows.Forms.Button();
            this.btnSendUnusedSubTasks = new System.Windows.Forms.Button();
            this.btnPull = new System.Windows.Forms.Button();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIssueType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJiraKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssigneeQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReviewAndRecreateQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEO1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReviewAndRecreateDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEO2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResearchRootCauseDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEO3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCodeFixDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEO4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWriteTestCaseQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEO5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExecuteTestCaseQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEO6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWriteReleaseNotesDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEO7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReviewReleaseNotesQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssignee8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMEO8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimeSpent8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubTaskTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(263, 23);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 57);
            this.btnSync.TabIndex = 8;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(73, 60);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // dgvSubTaskTable
            // 
            this.dgvSubTaskTable.AllowUserToAddRows = false;
            this.dgvSubTaskTable.AllowUserToDeleteRows = false;
            this.dgvSubTaskTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubTaskTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colIssueType,
            this.colJiraKey,
            this.colSummary,
            this.colStatus,
            this.colAssignee,
            this.colAssigneeQA,
            this.colTimeSpent,
            this.colReviewAndRecreateQA,
            this.colAssignee1,
            this.colStatus1,
            this.colMEO1,
            this.colTimeSpent1,
            this.colReviewAndRecreateDev,
            this.colAssignee2,
            this.colStatus2,
            this.colMEO2,
            this.colTimeSpent2,
            this.colResearchRootCauseDev,
            this.colAssignee3,
            this.colStatus3,
            this.colMEO3,
            this.colTimeSpent3,
            this.colCodeFixDev,
            this.colAssignee4,
            this.colStatus4,
            this.colMEO4,
            this.colTimeSpent4,
            this.colWriteTestCaseQA,
            this.colAssignee5,
            this.colStatus5,
            this.colMEO5,
            this.colTimeSpent5,
            this.colExecuteTestCaseQA,
            this.colAssignee6,
            this.colStatus6,
            this.colMEO6,
            this.colTimeSpent6,
            this.colWriteReleaseNotesDev,
            this.colAssignee7,
            this.colStatus7,
            this.colMEO7,
            this.colTimeSpent7,
            this.colReviewReleaseNotesQA,
            this.colAssignee8,
            this.colStatus8,
            this.colMEO8,
            this.colTimeSpent8});
            this.dgvSubTaskTable.Location = new System.Drawing.Point(6, 119);
            this.dgvSubTaskTable.Name = "dgvSubTaskTable";
            this.dgvSubTaskTable.Size = new System.Drawing.Size(1267, 631);
            this.dgvSubTaskTable.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(73, 28);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(26, 67);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(16, 34);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnSendMEOReport);
            this.groupBox1.Controls.Add(this.btnSendUnusedSubTasks);
            this.groupBox1.Controls.Add(this.btnPull);
            this.groupBox1.Controls.Add(this.btnSync);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblFrom);
            this.groupBox1.Location = new System.Drawing.Point(6, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1267, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(656, 57);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(122, 17);
            this.checkBox2.TabIndex = 13;
            this.checkBox2.Text = "Only Resolved Case";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(656, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Only Reviewed Case";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnSendMEOReport
            // 
            this.btnSendMEOReport.Location = new System.Drawing.Point(492, 23);
            this.btnSendMEOReport.Name = "btnSendMEOReport";
            this.btnSendMEOReport.Size = new System.Drawing.Size(142, 57);
            this.btnSendMEOReport.TabIndex = 11;
            this.btnSendMEOReport.Text = "Send M.E.O Report";
            this.btnSendMEOReport.UseVisualStyleBackColor = true;
            this.btnSendMEOReport.Click += new System.EventHandler(this.btnSendMEOReport_Click);
            // 
            // btnSendUnusedSubTasks
            // 
            this.btnSendUnusedSubTasks.Location = new System.Drawing.Point(344, 23);
            this.btnSendUnusedSubTasks.Name = "btnSendUnusedSubTasks";
            this.btnSendUnusedSubTasks.Size = new System.Drawing.Size(142, 57);
            this.btnSendUnusedSubTasks.TabIndex = 10;
            this.btnSendUnusedSubTasks.Text = "Send Unused Sub Tasks";
            this.btnSendUnusedSubTasks.UseVisualStyleBackColor = true;
            this.btnSendUnusedSubTasks.Click += new System.EventHandler(this.btnSendUnusedSubTasks_Click);
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(182, 23);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 57);
            this.btnPull.TabIndex = 9;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // colNo
            // 
            this.colNo.DataPropertyName = "No";
            this.colNo.HeaderText = "No";
            this.colNo.Name = "colNo";
            this.colNo.Width = 30;
            // 
            // colIssueType
            // 
            this.colIssueType.DataPropertyName = "IssueType";
            this.colIssueType.HeaderText = "Issue Type";
            this.colIssueType.Name = "colIssueType";
            this.colIssueType.ReadOnly = true;
            // 
            // colJiraKey
            // 
            this.colJiraKey.DataPropertyName = "JiraKey";
            this.colJiraKey.HeaderText = "Jira Key";
            this.colJiraKey.Name = "colJiraKey";
            this.colJiraKey.ReadOnly = true;
            // 
            // colSummary
            // 
            this.colSummary.DataPropertyName = "Summary";
            this.colSummary.HeaderText = "Summary";
            this.colSummary.Name = "colSummary";
            this.colSummary.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            this.colStatus.HeaderText = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // colAssignee
            // 
            this.colAssignee.DataPropertyName = "Assignee";
            this.colAssignee.HeaderText = "Assignee";
            this.colAssignee.Name = "colAssignee";
            this.colAssignee.ReadOnly = true;
            // 
            // colAssigneeQA
            // 
            this.colAssigneeQA.DataPropertyName = "AssigneeQA";
            this.colAssigneeQA.HeaderText = "AssigneeQA";
            this.colAssigneeQA.Name = "colAssigneeQA";
            this.colAssigneeQA.ReadOnly = true;
            // 
            // colTimeSpent
            // 
            this.colTimeSpent.DataPropertyName = "TimeSpent";
            this.colTimeSpent.HeaderText = "Time Spent";
            this.colTimeSpent.Name = "colTimeSpent";
            this.colTimeSpent.ReadOnly = true;
            // 
            // colReviewAndRecreateQA
            // 
            this.colReviewAndRecreateQA.DataPropertyName = "ReviewAndRecreateQA";
            this.colReviewAndRecreateQA.HeaderText = "Review and Recreate(QA)";
            this.colReviewAndRecreateQA.Name = "colReviewAndRecreateQA";
            this.colReviewAndRecreateQA.ReadOnly = true;
            // 
            // colAssignee1
            // 
            this.colAssignee1.DataPropertyName = "Assignee1";
            this.colAssignee1.HeaderText = "Assignee(1)";
            this.colAssignee1.Name = "colAssignee1";
            this.colAssignee1.ReadOnly = true;
            // 
            // colStatus1
            // 
            this.colStatus1.DataPropertyName = "Status1";
            this.colStatus1.HeaderText = "Status(1)";
            this.colStatus1.Name = "colStatus1";
            this.colStatus1.ReadOnly = true;
            // 
            // colMEO1
            // 
            this.colMEO1.DataPropertyName = "MEO1";
            this.colMEO1.HeaderText = "M.E.O(1)";
            this.colMEO1.Name = "colMEO1";
            this.colMEO1.ReadOnly = true;
            // 
            // colTimeSpent1
            // 
            this.colTimeSpent1.DataPropertyName = "TimeSpent1";
            this.colTimeSpent1.HeaderText = "Time Spent(1)";
            this.colTimeSpent1.Name = "colTimeSpent1";
            this.colTimeSpent1.ReadOnly = true;
            // 
            // colReviewAndRecreateDev
            // 
            this.colReviewAndRecreateDev.DataPropertyName = "ReviewAndRecreateDev";
            this.colReviewAndRecreateDev.HeaderText = "Review and Recreate(Dev)";
            this.colReviewAndRecreateDev.Name = "colReviewAndRecreateDev";
            this.colReviewAndRecreateDev.ReadOnly = true;
            // 
            // colAssignee2
            // 
            this.colAssignee2.DataPropertyName = "Assignee2";
            this.colAssignee2.HeaderText = "Assignee(2)";
            this.colAssignee2.Name = "colAssignee2";
            this.colAssignee2.ReadOnly = true;
            // 
            // colStatus2
            // 
            this.colStatus2.DataPropertyName = "Status2";
            this.colStatus2.HeaderText = "Status(2)";
            this.colStatus2.Name = "colStatus2";
            this.colStatus2.ReadOnly = true;
            // 
            // colMEO2
            // 
            this.colMEO2.DataPropertyName = "MEO2";
            this.colMEO2.HeaderText = "M.E.O(2)";
            this.colMEO2.Name = "colMEO2";
            this.colMEO2.ReadOnly = true;
            // 
            // colTimeSpent2
            // 
            this.colTimeSpent2.DataPropertyName = "TimeSpent2";
            this.colTimeSpent2.HeaderText = "Time Spent(2)";
            this.colTimeSpent2.Name = "colTimeSpent2";
            this.colTimeSpent2.ReadOnly = true;
            // 
            // colResearchRootCauseDev
            // 
            this.colResearchRootCauseDev.DataPropertyName = "ResearchRootCauseDev";
            this.colResearchRootCauseDev.HeaderText = "Research Root Cause(Dev)";
            this.colResearchRootCauseDev.Name = "colResearchRootCauseDev";
            this.colResearchRootCauseDev.ReadOnly = true;
            // 
            // colAssignee3
            // 
            this.colAssignee3.DataPropertyName = "Assignee3";
            this.colAssignee3.HeaderText = "Assignee(3)";
            this.colAssignee3.Name = "colAssignee3";
            this.colAssignee3.ReadOnly = true;
            // 
            // colStatus3
            // 
            this.colStatus3.DataPropertyName = "Status3";
            this.colStatus3.HeaderText = "Status(3)";
            this.colStatus3.Name = "colStatus3";
            this.colStatus3.ReadOnly = true;
            // 
            // colMEO3
            // 
            this.colMEO3.DataPropertyName = "MEO3";
            this.colMEO3.HeaderText = "M.E.O(3)";
            this.colMEO3.Name = "colMEO3";
            this.colMEO3.ReadOnly = true;
            // 
            // colTimeSpent3
            // 
            this.colTimeSpent3.DataPropertyName = "TimeSpent3";
            this.colTimeSpent3.HeaderText = "Time Spent(3)";
            this.colTimeSpent3.Name = "colTimeSpent3";
            this.colTimeSpent3.ReadOnly = true;
            // 
            // colCodeFixDev
            // 
            this.colCodeFixDev.DataPropertyName = "CodeFixDev";
            this.colCodeFixDev.HeaderText = "Code Fix(Dev)";
            this.colCodeFixDev.Name = "colCodeFixDev";
            this.colCodeFixDev.ReadOnly = true;
            // 
            // colAssignee4
            // 
            this.colAssignee4.DataPropertyName = "Assignee4";
            this.colAssignee4.HeaderText = "Assignee(4)";
            this.colAssignee4.Name = "colAssignee4";
            this.colAssignee4.ReadOnly = true;
            // 
            // colStatus4
            // 
            this.colStatus4.DataPropertyName = "Status4";
            this.colStatus4.HeaderText = "Status(4)";
            this.colStatus4.Name = "colStatus4";
            this.colStatus4.ReadOnly = true;
            // 
            // colMEO4
            // 
            this.colMEO4.DataPropertyName = "MEO4";
            this.colMEO4.HeaderText = "M.E.O(4)";
            this.colMEO4.Name = "colMEO4";
            this.colMEO4.ReadOnly = true;
            // 
            // colTimeSpent4
            // 
            this.colTimeSpent4.DataPropertyName = "TimeSpent4";
            this.colTimeSpent4.HeaderText = "Time Spent(4)";
            this.colTimeSpent4.Name = "colTimeSpent4";
            this.colTimeSpent4.ReadOnly = true;
            // 
            // colWriteTestCaseQA
            // 
            this.colWriteTestCaseQA.DataPropertyName = "WriteTestCaseQA";
            this.colWriteTestCaseQA.HeaderText = "Write Test Case(QA)";
            this.colWriteTestCaseQA.Name = "colWriteTestCaseQA";
            this.colWriteTestCaseQA.ReadOnly = true;
            // 
            // colAssignee5
            // 
            this.colAssignee5.DataPropertyName = "Assignee5";
            this.colAssignee5.HeaderText = "Assignee(5)";
            this.colAssignee5.Name = "colAssignee5";
            this.colAssignee5.ReadOnly = true;
            // 
            // colStatus5
            // 
            this.colStatus5.DataPropertyName = "Status5";
            this.colStatus5.HeaderText = "Status(5)";
            this.colStatus5.Name = "colStatus5";
            this.colStatus5.ReadOnly = true;
            // 
            // colMEO5
            // 
            this.colMEO5.DataPropertyName = "MEO5";
            this.colMEO5.HeaderText = "M.E.O(5)";
            this.colMEO5.Name = "colMEO5";
            this.colMEO5.ReadOnly = true;
            // 
            // colTimeSpent5
            // 
            this.colTimeSpent5.DataPropertyName = "TimeSpent5";
            this.colTimeSpent5.HeaderText = "Time Spent(5)";
            this.colTimeSpent5.Name = "colTimeSpent5";
            this.colTimeSpent5.ReadOnly = true;
            // 
            // colExecuteTestCaseQA
            // 
            this.colExecuteTestCaseQA.DataPropertyName = "ExecuteTestCaseQA";
            this.colExecuteTestCaseQA.HeaderText = "Execute Test Case(QA)";
            this.colExecuteTestCaseQA.Name = "colExecuteTestCaseQA";
            this.colExecuteTestCaseQA.ReadOnly = true;
            // 
            // colAssignee6
            // 
            this.colAssignee6.DataPropertyName = "Assignee6";
            this.colAssignee6.HeaderText = "Assignee(6)";
            this.colAssignee6.Name = "colAssignee6";
            this.colAssignee6.ReadOnly = true;
            // 
            // colStatus6
            // 
            this.colStatus6.DataPropertyName = "Status6";
            this.colStatus6.HeaderText = "Status(6)";
            this.colStatus6.Name = "colStatus6";
            this.colStatus6.ReadOnly = true;
            // 
            // colMEO6
            // 
            this.colMEO6.DataPropertyName = "MEO6";
            this.colMEO6.HeaderText = "M.E.O(6)";
            this.colMEO6.Name = "colMEO6";
            this.colMEO6.ReadOnly = true;
            // 
            // colTimeSpent6
            // 
            this.colTimeSpent6.DataPropertyName = "TimeSpent6";
            this.colTimeSpent6.HeaderText = "Time Spent(6)";
            this.colTimeSpent6.Name = "colTimeSpent6";
            this.colTimeSpent6.ReadOnly = true;
            // 
            // colWriteReleaseNotesDev
            // 
            this.colWriteReleaseNotesDev.DataPropertyName = "WriteReleaseNotesDev";
            this.colWriteReleaseNotesDev.HeaderText = "Write Release Notes(Dev)";
            this.colWriteReleaseNotesDev.Name = "colWriteReleaseNotesDev";
            this.colWriteReleaseNotesDev.ReadOnly = true;
            // 
            // colAssignee7
            // 
            this.colAssignee7.DataPropertyName = "Assignee7";
            this.colAssignee7.HeaderText = "Assignee(7)";
            this.colAssignee7.Name = "colAssignee7";
            this.colAssignee7.ReadOnly = true;
            // 
            // colStatus7
            // 
            this.colStatus7.DataPropertyName = "Status7";
            this.colStatus7.HeaderText = "Status(7)";
            this.colStatus7.Name = "colStatus7";
            this.colStatus7.ReadOnly = true;
            // 
            // colMEO7
            // 
            this.colMEO7.DataPropertyName = "MEO7";
            this.colMEO7.HeaderText = "M.E.O(7)";
            this.colMEO7.Name = "colMEO7";
            this.colMEO7.ReadOnly = true;
            // 
            // colTimeSpent7
            // 
            this.colTimeSpent7.DataPropertyName = "TimeSpent7";
            this.colTimeSpent7.HeaderText = "Time Spent(7)";
            this.colTimeSpent7.Name = "colTimeSpent7";
            this.colTimeSpent7.ReadOnly = true;
            // 
            // colReviewReleaseNotesQA
            // 
            this.colReviewReleaseNotesQA.DataPropertyName = "ReviewReleaseNotesQA";
            this.colReviewReleaseNotesQA.HeaderText = "Review Release Notes(QA)";
            this.colReviewReleaseNotesQA.Name = "colReviewReleaseNotesQA";
            this.colReviewReleaseNotesQA.ReadOnly = true;
            // 
            // colAssignee8
            // 
            this.colAssignee8.DataPropertyName = "Assignee8";
            this.colAssignee8.HeaderText = "Assignee(8)";
            this.colAssignee8.Name = "colAssignee8";
            this.colAssignee8.ReadOnly = true;
            // 
            // colStatus8
            // 
            this.colStatus8.DataPropertyName = "Status8";
            this.colStatus8.HeaderText = "Status(8)";
            this.colStatus8.Name = "colStatus8";
            this.colStatus8.ReadOnly = true;
            // 
            // colMEO8
            // 
            this.colMEO8.DataPropertyName = "MEO8";
            this.colMEO8.HeaderText = "M.E.O(8)";
            this.colMEO8.Name = "colMEO8";
            this.colMEO8.ReadOnly = true;
            // 
            // colTimeSpent8
            // 
            this.colTimeSpent8.DataPropertyName = "TimeSpent8";
            this.colTimeSpent8.HeaderText = "Time Spent(8)";
            this.colTimeSpent8.Name = "colTimeSpent8";
            this.colTimeSpent8.ReadOnly = true;
            // 
            // WeeklyMEOReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 762);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvSubTaskTable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WeeklyMEOReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Weekly M.E.O Report";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubTaskTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DataGridView dgvSubTaskTable;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.Button btnSendMEOReport;
        private System.Windows.Forms.Button btnSendUnusedSubTasks;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIssueType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssigneeQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewAndRecreateQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEO1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewAndRecreateDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEO2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResearchRootCauseDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEO3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent3;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCodeFixDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEO4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWriteTestCaseQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEO5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExecuteTestCaseQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEO6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent6;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWriteReleaseNotesDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEO7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent7;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReviewReleaseNotesQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssignee8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMEO8;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimeSpent8;
    }
}