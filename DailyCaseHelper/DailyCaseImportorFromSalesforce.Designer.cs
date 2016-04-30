namespace com.smartwork
{
    partial class DailyCaseImportorFromSalesforce
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
            this.grbImportTodayCaseList = new System.Windows.Forms.GroupBox();
            this.btnShowPendingCases = new System.Windows.Forms.Button();
            this.btnShowHotCases = new System.Windows.Forms.Button();
            this.btnShowScheduledCase = new System.Windows.Forms.Button();
            this.chkExcludeV8000 = new System.Windows.Forms.CheckBox();
            this.chkOnlyV8000 = new System.Windows.Forms.CheckBox();
            this.btnTopNCommentedCase = new System.Windows.Forms.Button();
            this.btnTopNNewCase = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblImportTodayCaseList = new System.Windows.Forms.Label();
            this.txtCaseIDList = new System.Windows.Forms.TextBox();
            this.grbExportTodayCaseList = new System.Windows.Forms.GroupBox();
            this.chkOnlyEmailMe = new System.Windows.Forms.CheckBox();
            this.chkOnlyImportCase = new System.Windows.Forms.CheckBox();
            this.grdCaseList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HotCase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Missionsky = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesforceID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Orgin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReopenedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextJiraStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSendRecreatedCase = new System.Windows.Forms.Button();
            this.btnSendAnalysisReport = new System.Windows.Forms.Button();
            this.btnSendCloseReport = new System.Windows.Forms.Button();
            this.chkSelectAllMissionsky = new System.Windows.Forms.CheckBox();
            this.chkSelectAllHotCase = new System.Windows.Forms.CheckBox();
            this.btnUpdateJIRAStatus = new System.Windows.Forms.Button();
            this.btnSendDailyCommentEmail = new System.Windows.Forms.Button();
            this.btnMoveCommentToJIRA = new System.Windows.Forms.Button();
            this.btnSyncWithJiraAndSF = new System.Windows.Forms.Button();
            this.btnSendDailyCaseSummaryReport = new System.Windows.Forms.Button();
            this.btnImportToJira = new System.Windows.Forms.Button();
            this.lblExportTodayCaseList = new System.Windows.Forms.Label();
            this.chkOnlySupport = new System.Windows.Forms.CheckBox();
            this.chkOnlyCurrentMonth = new System.Windows.Forms.CheckBox();
            this.grbImportTodayCaseList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grbExportTodayCaseList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbImportTodayCaseList
            // 
            this.grbImportTodayCaseList.Controls.Add(this.btnShowPendingCases);
            this.grbImportTodayCaseList.Controls.Add(this.btnShowHotCases);
            this.grbImportTodayCaseList.Controls.Add(this.btnShowScheduledCase);
            this.grbImportTodayCaseList.Controls.Add(this.chkExcludeV8000);
            this.grbImportTodayCaseList.Controls.Add(this.chkOnlyV8000);
            this.grbImportTodayCaseList.Controls.Add(this.btnTopNCommentedCase);
            this.grbImportTodayCaseList.Controls.Add(this.btnTopNNewCase);
            this.grbImportTodayCaseList.Controls.Add(this.panel1);
            this.grbImportTodayCaseList.Controls.Add(this.txtCaseIDList);
            this.grbImportTodayCaseList.Location = new System.Drawing.Point(18, 12);
            this.grbImportTodayCaseList.Name = "grbImportTodayCaseList";
            this.grbImportTodayCaseList.Size = new System.Drawing.Size(1273, 124);
            this.grbImportTodayCaseList.TabIndex = 2;
            this.grbImportTodayCaseList.TabStop = false;
            this.grbImportTodayCaseList.Text = "1. Import Today Case List";
            // 
            // btnShowPendingCases
            // 
            this.btnShowPendingCases.Location = new System.Drawing.Point(301, 32);
            this.btnShowPendingCases.Name = "btnShowPendingCases";
            this.btnShowPendingCases.Size = new System.Drawing.Size(138, 23);
            this.btnShowPendingCases.TabIndex = 16;
            this.btnShowPendingCases.Text = "Show Pending Cases";
            this.btnShowPendingCases.UseVisualStyleBackColor = true;
            this.btnShowPendingCases.Click += new System.EventHandler(this.btnShowPendingCases_Click);
            // 
            // btnShowHotCases
            // 
            this.btnShowHotCases.Location = new System.Drawing.Point(13, 34);
            this.btnShowHotCases.Name = "btnShowHotCases";
            this.btnShowHotCases.Size = new System.Drawing.Size(138, 23);
            this.btnShowHotCases.TabIndex = 15;
            this.btnShowHotCases.Text = "Show Hot Cases";
            this.btnShowHotCases.UseVisualStyleBackColor = true;
            this.btnShowHotCases.Click += new System.EventHandler(this.btnShowHotCases_Click);
            // 
            // btnShowScheduledCase
            // 
            this.btnShowScheduledCase.Location = new System.Drawing.Point(157, 34);
            this.btnShowScheduledCase.Name = "btnShowScheduledCase";
            this.btnShowScheduledCase.Size = new System.Drawing.Size(138, 23);
            this.btnShowScheduledCase.TabIndex = 14;
            this.btnShowScheduledCase.Text = "Show Scheduled Cases";
            this.btnShowScheduledCase.UseVisualStyleBackColor = true;
            this.btnShowScheduledCase.Click += new System.EventHandler(this.btnShowScheduledCase_Click);
            // 
            // chkExcludeV8000
            // 
            this.chkExcludeV8000.AutoSize = true;
            this.chkExcludeV8000.Location = new System.Drawing.Point(976, 38);
            this.chkExcludeV8000.Name = "chkExcludeV8000";
            this.chkExcludeV8000.Size = new System.Drawing.Size(100, 17);
            this.chkExcludeV8000.TabIndex = 13;
            this.chkExcludeV8000.Text = "Exclude 8.0.0.0";
            this.chkExcludeV8000.UseVisualStyleBackColor = true;
            // 
            // chkOnlyV8000
            // 
            this.chkOnlyV8000.AutoSize = true;
            this.chkOnlyV8000.Location = new System.Drawing.Point(976, 13);
            this.chkOnlyV8000.Name = "chkOnlyV8000";
            this.chkOnlyV8000.Size = new System.Drawing.Size(83, 17);
            this.chkOnlyV8000.TabIndex = 12;
            this.chkOnlyV8000.Text = "Only 8.0.0.0";
            this.chkOnlyV8000.UseVisualStyleBackColor = true;
            // 
            // btnTopNCommentedCase
            // 
            this.btnTopNCommentedCase.Location = new System.Drawing.Point(1091, 32);
            this.btnTopNCommentedCase.Name = "btnTopNCommentedCase";
            this.btnTopNCommentedCase.Size = new System.Drawing.Size(169, 23);
            this.btnTopNCommentedCase.TabIndex = 10;
            this.btnTopNCommentedCase.Text = "Top 100 Commented Case";
            this.btnTopNCommentedCase.UseVisualStyleBackColor = true;
            this.btnTopNCommentedCase.Click += new System.EventHandler(this.btnTopNCommentedCase_Click);
            // 
            // btnTopNNewCase
            // 
            this.btnTopNNewCase.Location = new System.Drawing.Point(1091, 9);
            this.btnTopNNewCase.Name = "btnTopNNewCase";
            this.btnTopNNewCase.Size = new System.Drawing.Size(169, 23);
            this.btnTopNNewCase.TabIndex = 5;
            this.btnTopNNewCase.Text = "Top 300 New Case            ";
            this.btnTopNNewCase.UseVisualStyleBackColor = true;
            this.btnTopNNewCase.Click += new System.EventHandler(this.btnGetTopNNewCase_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblImportTodayCaseList);
            this.panel1.Location = new System.Drawing.Point(10, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 23);
            this.panel1.TabIndex = 4;
            // 
            // lblImportTodayCaseList
            // 
            this.lblImportTodayCaseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblImportTodayCaseList.Location = new System.Drawing.Point(0, 0);
            this.lblImportTodayCaseList.Name = "lblImportTodayCaseList";
            this.lblImportTodayCaseList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblImportTodayCaseList.Size = new System.Drawing.Size(685, 23);
            this.lblImportTodayCaseList.TabIndex = 8;
            this.lblImportTodayCaseList.Text = "Input case list with comma as seperator like \"15ACC-00001,15ACC-00002\" into the b" +
    "elow box and then click \"Sync with JIRA and SF\" button.";
            // 
            // txtCaseIDList
            // 
            this.txtCaseIDList.Location = new System.Drawing.Point(13, 61);
            this.txtCaseIDList.Multiline = true;
            this.txtCaseIDList.Name = "txtCaseIDList";
            this.txtCaseIDList.Size = new System.Drawing.Size(1247, 57);
            this.txtCaseIDList.TabIndex = 2;
            // 
            // grbExportTodayCaseList
            // 
            this.grbExportTodayCaseList.Controls.Add(this.chkOnlyEmailMe);
            this.grbExportTodayCaseList.Controls.Add(this.chkOnlyImportCase);
            this.grbExportTodayCaseList.Controls.Add(this.grdCaseList);
            this.grbExportTodayCaseList.Controls.Add(this.panel3);
            this.grbExportTodayCaseList.Location = new System.Drawing.Point(18, 142);
            this.grbExportTodayCaseList.Name = "grbExportTodayCaseList";
            this.grbExportTodayCaseList.Size = new System.Drawing.Size(1273, 608);
            this.grbExportTodayCaseList.TabIndex = 9;
            this.grbExportTodayCaseList.TabStop = false;
            this.grbExportTodayCaseList.Text = "2, Export Today Case List";
            // 
            // chkOnlyEmailMe
            // 
            this.chkOnlyEmailMe.AutoSize = true;
            this.chkOnlyEmailMe.Location = new System.Drawing.Point(1167, 46);
            this.chkOnlyEmailMe.Name = "chkOnlyEmailMe";
            this.chkOnlyEmailMe.Size = new System.Drawing.Size(93, 17);
            this.chkOnlyEmailMe.TabIndex = 11;
            this.chkOnlyEmailMe.Text = "Only Email Me";
            this.chkOnlyEmailMe.UseVisualStyleBackColor = true;
            // 
            // chkOnlyImportCase
            // 
            this.chkOnlyImportCase.AutoSize = true;
            this.chkOnlyImportCase.Checked = true;
            this.chkOnlyImportCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyImportCase.Location = new System.Drawing.Point(1167, 23);
            this.chkOnlyImportCase.Name = "chkOnlyImportCase";
            this.chkOnlyImportCase.Size = new System.Drawing.Size(106, 17);
            this.chkOnlyImportCase.TabIndex = 10;
            this.chkOnlyImportCase.Text = "Only Import Case";
            this.chkOnlyImportCase.UseVisualStyleBackColor = true;
            // 
            // grdCaseList
            // 
            this.grdCaseList.AllowUserToAddRows = false;
            this.grdCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.No,
            this.HotCase,
            this.Missionsky,
            this.Rank,
            this.Product,
            this.SalesforceID,
            this.JiraKey,
            this.Severity,
            this.Version,
            this.Type,
            this.Customer,
            this.Orgin,
            this.OpenDate,
            this.Summary,
            this.Reviewer,
            this.ReopenedCount,
            this.Status,
            this.SFQueue,
            this.SFStatus,
            this.NextJiraStatus});
            this.grdCaseList.Location = new System.Drawing.Point(13, 80);
            this.grdCaseList.Name = "grdCaseList";
            this.grdCaseList.Size = new System.Drawing.Size(1254, 522);
            this.grdCaseList.TabIndex = 7;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // HotCase
            // 
            this.HotCase.DataPropertyName = "HotCase";
            this.HotCase.HeaderText = "Hot Case";
            this.HotCase.Name = "HotCase";
            this.HotCase.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HotCase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Missionsky
            // 
            this.Missionsky.DataPropertyName = "Missionsky";
            this.Missionsky.HeaderText = "Missionsky";
            this.Missionsky.Name = "Missionsky";
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Rank";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "ProductForUI";
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // SalesforceID
            // 
            this.SalesforceID.DataPropertyName = "SalesforceID";
            this.SalesforceID.HeaderText = "Salesforce ID";
            this.SalesforceID.Name = "SalesforceID";
            this.SalesforceID.ReadOnly = true;
            this.SalesforceID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SalesforceID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // JiraKey
            // 
            this.JiraKey.DataPropertyName = "JiraKey";
            this.JiraKey.HeaderText = "Jira Key";
            this.JiraKey.Name = "JiraKey";
            this.JiraKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.JiraKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Severity
            // 
            this.Severity.DataPropertyName = "Severity";
            this.Severity.HeaderText = "Severity";
            this.Severity.Name = "Severity";
            this.Severity.ReadOnly = true;
            // 
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "IssueCategory";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // Orgin
            // 
            this.Orgin.DataPropertyName = "Orgin";
            this.Orgin.HeaderText = "Orgin";
            this.Orgin.Name = "Orgin";
            // 
            // OpenDate
            // 
            this.OpenDate.DataPropertyName = "OpenDate";
            this.OpenDate.HeaderText = "Open Date";
            this.OpenDate.Name = "OpenDate";
            this.OpenDate.ReadOnly = true;
            // 
            // Summary
            // 
            this.Summary.DataPropertyName = "Summary";
            this.Summary.HeaderText = "Summary";
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            // 
            // Reviewer
            // 
            this.Reviewer.DataPropertyName = "Reviewer";
            this.Reviewer.HeaderText = "Reviewer";
            this.Reviewer.Name = "Reviewer";
            this.Reviewer.ReadOnly = true;
            // 
            // ReopenedCount
            // 
            this.ReopenedCount.DataPropertyName = "ReopenedCount";
            this.ReopenedCount.HeaderText = "Reopened Times";
            this.ReopenedCount.Name = "ReopenedCount";
            this.ReopenedCount.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "JiraStatus";
            this.Status.HeaderText = "Jira Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // SFQueue
            // 
            this.SFQueue.DataPropertyName = "SFQueue";
            this.SFQueue.HeaderText = "SFQueue";
            this.SFQueue.Name = "SFQueue";
            this.SFQueue.ReadOnly = true;
            // 
            // SFStatus
            // 
            this.SFStatus.DataPropertyName = "SFStatus";
            this.SFStatus.HeaderText = "SFStatus";
            this.SFStatus.Name = "SFStatus";
            this.SFStatus.ReadOnly = true;
            // 
            // NextJiraStatus
            // 
            this.NextJiraStatus.DataPropertyName = "NextJiraStatus";
            this.NextJiraStatus.HeaderText = "NextJiraStatus";
            this.NextJiraStatus.Name = "NextJiraStatus";
            this.NextJiraStatus.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkOnlyCurrentMonth);
            this.panel3.Controls.Add(this.chkOnlySupport);
            this.panel3.Controls.Add(this.btnSendRecreatedCase);
            this.panel3.Controls.Add(this.btnSendAnalysisReport);
            this.panel3.Controls.Add(this.btnSendCloseReport);
            this.panel3.Controls.Add(this.chkSelectAllMissionsky);
            this.panel3.Controls.Add(this.chkSelectAllHotCase);
            this.panel3.Controls.Add(this.btnUpdateJIRAStatus);
            this.panel3.Controls.Add(this.btnSendDailyCommentEmail);
            this.panel3.Controls.Add(this.btnMoveCommentToJIRA);
            this.panel3.Controls.Add(this.btnSyncWithJiraAndSF);
            this.panel3.Controls.Add(this.btnSendDailyCaseSummaryReport);
            this.panel3.Controls.Add(this.btnImportToJira);
            this.panel3.Controls.Add(this.lblExportTodayCaseList);
            this.panel3.Location = new System.Drawing.Point(13, 19);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1151, 55);
            this.panel3.TabIndex = 9;
            // 
            // btnSendRecreatedCase
            // 
            this.btnSendRecreatedCase.Location = new System.Drawing.Point(846, 4);
            this.btnSendRecreatedCase.Name = "btnSendRecreatedCase";
            this.btnSendRecreatedCase.Size = new System.Drawing.Size(138, 23);
            this.btnSendRecreatedCase.TabIndex = 24;
            this.btnSendRecreatedCase.Text = "Send Recreated Case";
            this.btnSendRecreatedCase.UseVisualStyleBackColor = true;
            this.btnSendRecreatedCase.Click += new System.EventHandler(this.btnSendRecreatedCase_Click);
            // 
            // btnSendAnalysisReport
            // 
            this.btnSendAnalysisReport.Location = new System.Drawing.Point(438, -1);
            this.btnSendAnalysisReport.Name = "btnSendAnalysisReport";
            this.btnSendAnalysisReport.Size = new System.Drawing.Size(138, 23);
            this.btnSendAnalysisReport.TabIndex = 26;
            this.btnSendAnalysisReport.Text = "Send Analysis Report";
            this.btnSendAnalysisReport.UseVisualStyleBackColor = true;
            this.btnSendAnalysisReport.Click += new System.EventHandler(this.btnSendAnalysisReport_Click);
            // 
            // btnSendCloseReport
            // 
            this.btnSendCloseReport.Location = new System.Drawing.Point(846, 29);
            this.btnSendCloseReport.Name = "btnSendCloseReport";
            this.btnSendCloseReport.Size = new System.Drawing.Size(138, 23);
            this.btnSendCloseReport.TabIndex = 23;
            this.btnSendCloseReport.Text = "Send Closed Case";
            this.btnSendCloseReport.UseVisualStyleBackColor = true;
            this.btnSendCloseReport.Click += new System.EventHandler(this.btnSendCloseReport_Click);
            // 
            // chkSelectAllMissionsky
            // 
            this.chkSelectAllMissionsky.AutoSize = true;
            this.chkSelectAllMissionsky.Location = new System.Drawing.Point(1067, 27);
            this.chkSelectAllMissionsky.Name = "chkSelectAllMissionsky";
            this.chkSelectAllMissionsky.Size = new System.Drawing.Size(91, 17);
            this.chkSelectAllMissionsky.TabIndex = 22;
            this.chkSelectAllMissionsky.Text = "All Missionsky";
            this.chkSelectAllMissionsky.UseVisualStyleBackColor = true;
            this.chkSelectAllMissionsky.CheckedChanged += new System.EventHandler(this.chkSelectAllMissionsky_CheckedChanged);
            // 
            // chkSelectAllHotCase
            // 
            this.chkSelectAllHotCase.AutoSize = true;
            this.chkSelectAllHotCase.Location = new System.Drawing.Point(1067, 4);
            this.chkSelectAllHotCase.Name = "chkSelectAllHotCase";
            this.chkSelectAllHotCase.Size = new System.Drawing.Size(84, 17);
            this.chkSelectAllHotCase.TabIndex = 21;
            this.chkSelectAllHotCase.Text = "All Hot Case";
            this.chkSelectAllHotCase.UseVisualStyleBackColor = true;
            this.chkSelectAllHotCase.CheckedChanged += new System.EventHandler(this.chkSelectAllHotCase_CheckedChanged);
            // 
            // btnUpdateJIRAStatus
            // 
            this.btnUpdateJIRAStatus.Location = new System.Drawing.Point(726, 29);
            this.btnUpdateJIRAStatus.Name = "btnUpdateJIRAStatus";
            this.btnUpdateJIRAStatus.Size = new System.Drawing.Size(114, 23);
            this.btnUpdateJIRAStatus.TabIndex = 12;
            this.btnUpdateJIRAStatus.Text = "Sync JIRA Status";
            this.btnUpdateJIRAStatus.UseVisualStyleBackColor = true;
            this.btnUpdateJIRAStatus.Click += new System.EventHandler(this.btnUpdateJIRAStatus_Click);
            // 
            // btnSendDailyCommentEmail
            // 
            this.btnSendDailyCommentEmail.Location = new System.Drawing.Point(582, 28);
            this.btnSendDailyCommentEmail.Name = "btnSendDailyCommentEmail";
            this.btnSendDailyCommentEmail.Size = new System.Drawing.Size(138, 23);
            this.btnSendDailyCommentEmail.TabIndex = 17;
            this.btnSendDailyCommentEmail.Text = "Send Daily Comment";
            this.btnSendDailyCommentEmail.UseVisualStyleBackColor = true;
            this.btnSendDailyCommentEmail.Click += new System.EventHandler(this.btnSendDailyCommentEmail_Click);
            // 
            // btnMoveCommentToJIRA
            // 
            this.btnMoveCommentToJIRA.Location = new System.Drawing.Point(291, 27);
            this.btnMoveCommentToJIRA.Name = "btnMoveCommentToJIRA";
            this.btnMoveCommentToJIRA.Size = new System.Drawing.Size(138, 23);
            this.btnMoveCommentToJIRA.TabIndex = 11;
            this.btnMoveCommentToJIRA.Text = "Move Comment to JIRA";
            this.btnMoveCommentToJIRA.UseVisualStyleBackColor = true;
            this.btnMoveCommentToJIRA.Click += new System.EventHandler(this.btnMoveCommentToJIRA_Click);
            // 
            // btnSyncWithJiraAndSF
            // 
            this.btnSyncWithJiraAndSF.Location = new System.Drawing.Point(3, 28);
            this.btnSyncWithJiraAndSF.Name = "btnSyncWithJiraAndSF";
            this.btnSyncWithJiraAndSF.Size = new System.Drawing.Size(138, 23);
            this.btnSyncWithJiraAndSF.TabIndex = 10;
            this.btnSyncWithJiraAndSF.Text = "Sync with JIRA and SF";
            this.btnSyncWithJiraAndSF.UseVisualStyleBackColor = true;
            this.btnSyncWithJiraAndSF.Click += new System.EventHandler(this.btnSyncWithJiraAndSF_Click);
            // 
            // btnSendDailyCaseSummaryReport
            // 
            this.btnSendDailyCaseSummaryReport.Location = new System.Drawing.Point(438, 27);
            this.btnSendDailyCaseSummaryReport.Name = "btnSendDailyCaseSummaryReport";
            this.btnSendDailyCaseSummaryReport.Size = new System.Drawing.Size(138, 23);
            this.btnSendDailyCaseSummaryReport.TabIndex = 6;
            this.btnSendDailyCaseSummaryReport.Text = "Send Daily Report";
            this.btnSendDailyCaseSummaryReport.UseVisualStyleBackColor = true;
            this.btnSendDailyCaseSummaryReport.Click += new System.EventHandler(this.btnSendDailyCaseSummaryReport_Click);
            // 
            // btnImportToJira
            // 
            this.btnImportToJira.Location = new System.Drawing.Point(147, 27);
            this.btnImportToJira.Name = "btnImportToJira";
            this.btnImportToJira.Size = new System.Drawing.Size(138, 23);
            this.btnImportToJira.TabIndex = 10;
            this.btnImportToJira.Text = "Import to JIRA";
            this.btnImportToJira.UseVisualStyleBackColor = true;
            this.btnImportToJira.Click += new System.EventHandler(this.btnImportToJira_Click);
            // 
            // lblExportTodayCaseList
            // 
            this.lblExportTodayCaseList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblExportTodayCaseList.Location = new System.Drawing.Point(0, 0);
            this.lblExportTodayCaseList.Name = "lblExportTodayCaseList";
            this.lblExportTodayCaseList.Size = new System.Drawing.Size(1151, 55);
            this.lblExportTodayCaseList.TabIndex = 20;
            this.lblExportTodayCaseList.Text = "Update the \"Comment\" column, click \"Send Daily Report\" to send case list to your " +
    "mail box. ";
            // 
            // chkOnlySupport
            // 
            this.chkOnlySupport.AutoSize = true;
            this.chkOnlySupport.Checked = true;
            this.chkOnlySupport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlySupport.Location = new System.Drawing.Point(582, 3);
            this.chkOnlySupport.Name = "chkOnlySupport";
            this.chkOnlySupport.Size = new System.Drawing.Size(117, 17);
            this.chkOnlySupport.TabIndex = 12;
            this.chkOnlySupport.Text = "Only Support Team";
            this.chkOnlySupport.UseVisualStyleBackColor = true;
            // 
            // chkOnlyCurrentMonth
            // 
            this.chkOnlyCurrentMonth.AutoSize = true;
            this.chkOnlyCurrentMonth.Checked = true;
            this.chkOnlyCurrentMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlyCurrentMonth.Location = new System.Drawing.Point(730, 4);
            this.chkOnlyCurrentMonth.Name = "chkOnlyCurrentMonth";
            this.chkOnlyCurrentMonth.Size = new System.Drawing.Size(117, 17);
            this.chkOnlyCurrentMonth.TabIndex = 13;
            this.chkOnlyCurrentMonth.Text = "Only Current Month";
            this.chkOnlyCurrentMonth.UseVisualStyleBackColor = true;
            // 
            // DailyCaseImportorFromSalesforce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1297, 762);
            this.Controls.Add(this.grbExportTodayCaseList);
            this.Controls.Add(this.grbImportTodayCaseList);
            this.Name = "DailyCaseImportorFromSalesforce";
            this.Text = "Smart Worker";
            this.grbImportTodayCaseList.ResumeLayout(false);
            this.grbImportTodayCaseList.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grbExportTodayCaseList.ResumeLayout(false);
            this.grbExportTodayCaseList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbImportTodayCaseList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCaseIDList;
        private System.Windows.Forms.GroupBox grbExportTodayCaseList;
        private System.Windows.Forms.DataGridView grdCaseList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnSendDailyCaseSummaryReport;
        private System.Windows.Forms.Button btnTopNCommentedCase;
        private System.Windows.Forms.Button btnTopNNewCase;
        private System.Windows.Forms.Label lblImportTodayCaseList;
        private System.Windows.Forms.Button btnSyncWithJiraAndSF;
        private System.Windows.Forms.Button btnImportToJira;
        private System.Windows.Forms.Button btnMoveCommentToJIRA;
        private System.Windows.Forms.Button btnSendDailyCommentEmail;
        private System.Windows.Forms.CheckBox chkOnlyEmailMe;
        private System.Windows.Forms.CheckBox chkOnlyImportCase;
        private System.Windows.Forms.Button btnUpdateJIRAStatus;
        private System.Windows.Forms.CheckBox chkOnlyV8000;
        private System.Windows.Forms.CheckBox chkExcludeV8000;
        private System.Windows.Forms.Button btnShowScheduledCase;
        private System.Windows.Forms.Label lblExportTodayCaseList;
        private System.Windows.Forms.Button btnShowHotCases;
        private System.Windows.Forms.CheckBox chkSelectAllMissionsky;
        private System.Windows.Forms.CheckBox chkSelectAllHotCase;
        private System.Windows.Forms.Button btnShowPendingCases;
        private System.Windows.Forms.Button btnSendCloseReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HotCase;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Missionsky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewLinkColumn SalesforceID;
        private System.Windows.Forms.DataGridViewLinkColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orgin;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reviewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReopenedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextJiraStatus;
        private System.Windows.Forms.Button btnSendRecreatedCase;
        private System.Windows.Forms.Button btnSendAnalysisReport;
        private System.Windows.Forms.CheckBox chkOnlyCurrentMonth;
        private System.Windows.Forms.CheckBox chkOnlySupport;
    }
}