namespace com.smartwork
{
    partial class frmWeeklyReportForm
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
            this.grbWeeklyBaseline = new System.Windows.Forms.GroupBox();
            this.txtSundayCaseCommentCount = new System.Windows.Forms.TextBox();
            this.txtSaturdayCaseCommentCount = new System.Windows.Forms.TextBox();
            this.lblSundayCaseCommentCount = new System.Windows.Forms.Label();
            this.lblSaturdayCaseCommentCount = new System.Windows.Forms.Label();
            this.txtFridayCaseCommentCount = new System.Windows.Forms.TextBox();
            this.lblFridayCaseCommentCount = new System.Windows.Forms.Label();
            this.txtThursdayCaseCommentCount = new System.Windows.Forms.TextBox();
            this.lblThursdayCaseCommentCount = new System.Windows.Forms.Label();
            this.txtWednesdayCaseCommentCount = new System.Windows.Forms.TextBox();
            this.lblWednesdayCaseCommentCount = new System.Windows.Forms.Label();
            this.txtTuesdayCaseCommentCount = new System.Windows.Forms.TextBox();
            this.lblTuesdayCaseCommentCount = new System.Windows.Forms.Label();
            this.txtMondayCaseCommentCount = new System.Windows.Forms.TextBox();
            this.lblMonday = new System.Windows.Forms.Label();
            this.txtTotalCaseCommentCount = new System.Windows.Forms.TextBox();
            this.lblCaseCommentCount = new System.Windows.Forms.Label();
            this.txtEngQACaseCount = new System.Windows.Forms.TextBox();
            this.lblEngQACaseCount = new System.Windows.Forms.Label();
            this.txtEngCaseCount = new System.Windows.Forms.TextBox();
            this.lblEngCaseCount = new System.Windows.Forms.Label();
            this.txtProductionBugCount = new System.Windows.Forms.TextBox();
            this.lblProductionBugCount = new System.Windows.Forms.Label();
            this.txtNewJiraTicketCount = new System.Windows.Forms.TextBox();
            this.lblNewJiraTicketCount = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblSpecifiedSunday = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.txtInputCaseList = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.grdCaseList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.grbWeeklyBaseline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // grbWeeklyBaseline
            // 
            this.grbWeeklyBaseline.Controls.Add(this.txtSundayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtSaturdayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblSundayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblSaturdayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtFridayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblFridayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtThursdayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblThursdayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtWednesdayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblWednesdayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtTuesdayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblTuesdayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtMondayCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblMonday);
            this.grbWeeklyBaseline.Controls.Add(this.txtTotalCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblCaseCommentCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtEngQACaseCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblEngQACaseCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtEngCaseCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblEngCaseCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtProductionBugCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblProductionBugCount);
            this.grbWeeklyBaseline.Controls.Add(this.txtNewJiraTicketCount);
            this.grbWeeklyBaseline.Controls.Add(this.lblNewJiraTicketCount);
            this.grbWeeklyBaseline.Location = new System.Drawing.Point(852, 12);
            this.grbWeeklyBaseline.Name = "grbWeeklyBaseline";
            this.grbWeeklyBaseline.Size = new System.Drawing.Size(448, 209);
            this.grbWeeklyBaseline.TabIndex = 10;
            this.grbWeeklyBaseline.TabStop = false;
            this.grbWeeklyBaseline.Text = "Weekly Indicator";
            // 
            // txtSundayCaseCommentCount
            // 
            this.txtSundayCaseCommentCount.Location = new System.Drawing.Point(328, 189);
            this.txtSundayCaseCommentCount.Name = "txtSundayCaseCommentCount";
            this.txtSundayCaseCommentCount.Size = new System.Drawing.Size(100, 20);
            this.txtSundayCaseCommentCount.TabIndex = 35;
            // 
            // txtSaturdayCaseCommentCount
            // 
            this.txtSaturdayCaseCommentCount.Location = new System.Drawing.Point(328, 164);
            this.txtSaturdayCaseCommentCount.Name = "txtSaturdayCaseCommentCount";
            this.txtSaturdayCaseCommentCount.Size = new System.Drawing.Size(100, 20);
            this.txtSaturdayCaseCommentCount.TabIndex = 34;
            // 
            // lblSundayCaseCommentCount
            // 
            this.lblSundayCaseCommentCount.AutoSize = true;
            this.lblSundayCaseCommentCount.Location = new System.Drawing.Point(276, 193);
            this.lblSundayCaseCommentCount.Name = "lblSundayCaseCommentCount";
            this.lblSundayCaseCommentCount.Size = new System.Drawing.Size(46, 13);
            this.lblSundayCaseCommentCount.TabIndex = 33;
            this.lblSundayCaseCommentCount.Text = "Sunday:";
            // 
            // lblSaturdayCaseCommentCount
            // 
            this.lblSaturdayCaseCommentCount.AutoSize = true;
            this.lblSaturdayCaseCommentCount.Location = new System.Drawing.Point(274, 167);
            this.lblSaturdayCaseCommentCount.Name = "lblSaturdayCaseCommentCount";
            this.lblSaturdayCaseCommentCount.Size = new System.Drawing.Size(52, 13);
            this.lblSaturdayCaseCommentCount.TabIndex = 32;
            this.lblSaturdayCaseCommentCount.Text = "Saturday:";
            // 
            // txtFridayCaseCommentCount
            // 
            this.txtFridayCaseCommentCount.Location = new System.Drawing.Point(328, 136);
            this.txtFridayCaseCommentCount.Name = "txtFridayCaseCommentCount";
            this.txtFridayCaseCommentCount.Size = new System.Drawing.Size(100, 20);
            this.txtFridayCaseCommentCount.TabIndex = 31;
            // 
            // lblFridayCaseCommentCount
            // 
            this.lblFridayCaseCommentCount.AutoSize = true;
            this.lblFridayCaseCommentCount.Location = new System.Drawing.Point(284, 141);
            this.lblFridayCaseCommentCount.Name = "lblFridayCaseCommentCount";
            this.lblFridayCaseCommentCount.Size = new System.Drawing.Size(38, 13);
            this.lblFridayCaseCommentCount.TabIndex = 30;
            this.lblFridayCaseCommentCount.Text = "Friday:";
            // 
            // txtThursdayCaseCommentCount
            // 
            this.txtThursdayCaseCommentCount.Location = new System.Drawing.Point(328, 106);
            this.txtThursdayCaseCommentCount.Name = "txtThursdayCaseCommentCount";
            this.txtThursdayCaseCommentCount.Size = new System.Drawing.Size(100, 20);
            this.txtThursdayCaseCommentCount.TabIndex = 29;
            // 
            // lblThursdayCaseCommentCount
            // 
            this.lblThursdayCaseCommentCount.AutoSize = true;
            this.lblThursdayCaseCommentCount.Location = new System.Drawing.Point(268, 112);
            this.lblThursdayCaseCommentCount.Name = "lblThursdayCaseCommentCount";
            this.lblThursdayCaseCommentCount.Size = new System.Drawing.Size(54, 13);
            this.lblThursdayCaseCommentCount.TabIndex = 28;
            this.lblThursdayCaseCommentCount.Text = "Thursday:";
            // 
            // txtWednesdayCaseCommentCount
            // 
            this.txtWednesdayCaseCommentCount.Location = new System.Drawing.Point(328, 80);
            this.txtWednesdayCaseCommentCount.Name = "txtWednesdayCaseCommentCount";
            this.txtWednesdayCaseCommentCount.Size = new System.Drawing.Size(100, 20);
            this.txtWednesdayCaseCommentCount.TabIndex = 27;
            // 
            // lblWednesdayCaseCommentCount
            // 
            this.lblWednesdayCaseCommentCount.AutoSize = true;
            this.lblWednesdayCaseCommentCount.Location = new System.Drawing.Point(255, 83);
            this.lblWednesdayCaseCommentCount.Name = "lblWednesdayCaseCommentCount";
            this.lblWednesdayCaseCommentCount.Size = new System.Drawing.Size(67, 13);
            this.lblWednesdayCaseCommentCount.TabIndex = 26;
            this.lblWednesdayCaseCommentCount.Text = "Wednesday:";
            // 
            // txtTuesdayCaseCommentCount
            // 
            this.txtTuesdayCaseCommentCount.Location = new System.Drawing.Point(328, 54);
            this.txtTuesdayCaseCommentCount.Name = "txtTuesdayCaseCommentCount";
            this.txtTuesdayCaseCommentCount.Size = new System.Drawing.Size(100, 20);
            this.txtTuesdayCaseCommentCount.TabIndex = 25;
            // 
            // lblTuesdayCaseCommentCount
            // 
            this.lblTuesdayCaseCommentCount.AutoSize = true;
            this.lblTuesdayCaseCommentCount.Location = new System.Drawing.Point(271, 58);
            this.lblTuesdayCaseCommentCount.Name = "lblTuesdayCaseCommentCount";
            this.lblTuesdayCaseCommentCount.Size = new System.Drawing.Size(51, 13);
            this.lblTuesdayCaseCommentCount.TabIndex = 24;
            this.lblTuesdayCaseCommentCount.Text = "Tuesday:";
            // 
            // txtMondayCaseCommentCount
            // 
            this.txtMondayCaseCommentCount.Location = new System.Drawing.Point(328, 24);
            this.txtMondayCaseCommentCount.Name = "txtMondayCaseCommentCount";
            this.txtMondayCaseCommentCount.Size = new System.Drawing.Size(100, 20);
            this.txtMondayCaseCommentCount.TabIndex = 23;
            // 
            // lblMonday
            // 
            this.lblMonday.AutoSize = true;
            this.lblMonday.Location = new System.Drawing.Point(274, 27);
            this.lblMonday.Name = "lblMonday";
            this.lblMonday.Size = new System.Drawing.Size(48, 13);
            this.lblMonday.TabIndex = 22;
            this.lblMonday.Text = "Monday:";
            // 
            // txtTotalCaseCommentCount
            // 
            this.txtTotalCaseCommentCount.Location = new System.Drawing.Point(127, 138);
            this.txtTotalCaseCommentCount.Name = "txtTotalCaseCommentCount";
            this.txtTotalCaseCommentCount.Size = new System.Drawing.Size(100, 20);
            this.txtTotalCaseCommentCount.TabIndex = 21;
            // 
            // lblCaseCommentCount
            // 
            this.lblCaseCommentCount.AutoSize = true;
            this.lblCaseCommentCount.Location = new System.Drawing.Point(9, 141);
            this.lblCaseCommentCount.Name = "lblCaseCommentCount";
            this.lblCaseCommentCount.Size = new System.Drawing.Size(112, 13);
            this.lblCaseCommentCount.TabIndex = 20;
            this.lblCaseCommentCount.Text = "Case Comment Count:";
            // 
            // txtEngQACaseCount
            // 
            this.txtEngQACaseCount.Location = new System.Drawing.Point(127, 106);
            this.txtEngQACaseCount.Name = "txtEngQACaseCount";
            this.txtEngQACaseCount.Size = new System.Drawing.Size(100, 20);
            this.txtEngQACaseCount.TabIndex = 19;
            // 
            // lblEngQACaseCount
            // 
            this.lblEngQACaseCount.AutoSize = true;
            this.lblEngQACaseCount.Location = new System.Drawing.Point(16, 113);
            this.lblEngQACaseCount.Name = "lblEngQACaseCount";
            this.lblEngQACaseCount.Size = new System.Drawing.Size(105, 13);
            this.lblEngQACaseCount.TabIndex = 18;
            this.lblEngQACaseCount.Text = "Eng QA Case Count:";
            // 
            // txtEngCaseCount
            // 
            this.txtEngCaseCount.Location = new System.Drawing.Point(127, 80);
            this.txtEngCaseCount.Name = "txtEngCaseCount";
            this.txtEngCaseCount.Size = new System.Drawing.Size(100, 20);
            this.txtEngCaseCount.TabIndex = 17;
            // 
            // lblEngCaseCount
            // 
            this.lblEngCaseCount.AutoSize = true;
            this.lblEngCaseCount.Location = new System.Drawing.Point(34, 87);
            this.lblEngCaseCount.Name = "lblEngCaseCount";
            this.lblEngCaseCount.Size = new System.Drawing.Size(87, 13);
            this.lblEngCaseCount.TabIndex = 16;
            this.lblEngCaseCount.Text = "Eng Case Count:";
            // 
            // txtProductionBugCount
            // 
            this.txtProductionBugCount.Location = new System.Drawing.Point(127, 50);
            this.txtProductionBugCount.Name = "txtProductionBugCount";
            this.txtProductionBugCount.Size = new System.Drawing.Size(100, 20);
            this.txtProductionBugCount.TabIndex = 15;
            // 
            // lblProductionBugCount
            // 
            this.lblProductionBugCount.AutoSize = true;
            this.lblProductionBugCount.Location = new System.Drawing.Point(7, 57);
            this.lblProductionBugCount.Name = "lblProductionBugCount";
            this.lblProductionBugCount.Size = new System.Drawing.Size(114, 13);
            this.lblProductionBugCount.TabIndex = 14;
            this.lblProductionBugCount.Text = "Production Bug Count:";
            // 
            // txtNewJiraTicketCount
            // 
            this.txtNewJiraTicketCount.Location = new System.Drawing.Point(127, 24);
            this.txtNewJiraTicketCount.Name = "txtNewJiraTicketCount";
            this.txtNewJiraTicketCount.Size = new System.Drawing.Size(100, 20);
            this.txtNewJiraTicketCount.TabIndex = 13;
            // 
            // lblNewJiraTicketCount
            // 
            this.lblNewJiraTicketCount.AutoSize = true;
            this.lblNewJiraTicketCount.Location = new System.Drawing.Point(6, 27);
            this.lblNewJiraTicketCount.Name = "lblNewJiraTicketCount";
            this.lblNewJiraTicketCount.Size = new System.Drawing.Size(115, 13);
            this.lblNewJiraTicketCount.TabIndex = 12;
            this.lblNewJiraTicketCount.Text = "New Jira Ticket Count:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(121, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(100, 20);
            this.dtpStartDate.TabIndex = 10;
            // 
            // lblSpecifiedSunday
            // 
            this.lblSpecifiedSunday.AutoSize = true;
            this.lblSpecifiedSunday.Location = new System.Drawing.Point(20, 18);
            this.lblSpecifiedSunday.Name = "lblSpecifiedSunday";
            this.lblSpecifiedSunday.Size = new System.Drawing.Size(93, 13);
            this.lblSpecifiedSunday.TabIndex = 12;
            this.lblSpecifiedSunday.Text = "Specified Sunday:";
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(771, 107);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 30);
            this.btnSync.TabIndex = 13;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // txtInputCaseList
            // 
            this.txtInputCaseList.Location = new System.Drawing.Point(23, 46);
            this.txtInputCaseList.Multiline = true;
            this.txtInputCaseList.Name = "txtInputCaseList";
            this.txtInputCaseList.Size = new System.Drawing.Size(742, 172);
            this.txtInputCaseList.TabIndex = 14;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(771, 62);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 32);
            this.btnGet.TabIndex = 16;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(771, 148);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 31);
            this.btnSend.TabIndex = 17;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // grdCaseList
            // 
            this.grdCaseList.AllowUserToAddRows = false;
            this.grdCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.No,
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
            this.grdCaseList.Location = new System.Drawing.Point(26, 227);
            this.grdCaseList.Name = "grdCaseList";
            this.grdCaseList.Size = new System.Drawing.Size(1274, 511);
            this.grdCaseList.TabIndex = 18;
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
            // frmWeeklyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 750);
            this.Controls.Add(this.grdCaseList);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtInputCaseList);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.lblSpecifiedSunday);
            this.Controls.Add(this.grbWeeklyBaseline);
            this.Controls.Add(this.dtpStartDate);
            this.Name = "frmWeeklyReportForm";
            this.Text = "Weekly Report Form";
            this.grbWeeklyBaseline.ResumeLayout(false);
            this.grbWeeklyBaseline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbWeeklyBaseline;
        private System.Windows.Forms.TextBox txtTotalCaseCommentCount;
        private System.Windows.Forms.Label lblCaseCommentCount;
        private System.Windows.Forms.TextBox txtEngQACaseCount;
        private System.Windows.Forms.Label lblEngQACaseCount;
        private System.Windows.Forms.TextBox txtEngCaseCount;
        private System.Windows.Forms.Label lblEngCaseCount;
        private System.Windows.Forms.TextBox txtProductionBugCount;
        private System.Windows.Forms.Label lblProductionBugCount;
        private System.Windows.Forms.TextBox txtNewJiraTicketCount;
        private System.Windows.Forms.Label lblNewJiraTicketCount;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblSpecifiedSunday;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.TextBox txtInputCaseList;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtFridayCaseCommentCount;
        private System.Windows.Forms.Label lblFridayCaseCommentCount;
        private System.Windows.Forms.TextBox txtThursdayCaseCommentCount;
        private System.Windows.Forms.Label lblThursdayCaseCommentCount;
        private System.Windows.Forms.TextBox txtWednesdayCaseCommentCount;
        private System.Windows.Forms.Label lblWednesdayCaseCommentCount;
        private System.Windows.Forms.TextBox txtTuesdayCaseCommentCount;
        private System.Windows.Forms.Label lblTuesdayCaseCommentCount;
        private System.Windows.Forms.TextBox txtMondayCaseCommentCount;
        private System.Windows.Forms.Label lblMonday;
        private System.Windows.Forms.DataGridView grdCaseList;
        private System.Windows.Forms.TextBox txtSundayCaseCommentCount;
        private System.Windows.Forms.TextBox txtSaturdayCaseCommentCount;
        private System.Windows.Forms.Label lblSundayCaseCommentCount;
        private System.Windows.Forms.Label lblSaturdayCaseCommentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
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

    }
}