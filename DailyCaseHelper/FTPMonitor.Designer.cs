namespace com.smartwork
{
    partial class FTPMonitor
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
            this.grdCaseList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesforceID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReopenedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NextStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbFunctionArea = new System.Windows.Forms.GroupBox();
            this.txtCaseIDList = new System.Windows.Forms.TextBox();
            this.btnTop50NewCases = new System.Windows.Forms.Button();
            this.btnSyncWithJIRA = new System.Windows.Forms.Button();
            this.btnSendNotificationEmail = new System.Windows.Forms.Button();
            this.txtSFID = new System.Windows.Forms.TextBox();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).BeginInit();
            this.grbFunctionArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCaseList
            // 
            this.grdCaseList.AllowUserToAddRows = false;
            this.grdCaseList.AllowUserToDeleteRows = false;
            this.grdCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.No,
            this.Product,
            this.SalesforceID,
            this.JiraKey,
            this.Version,
            this.Customer,
            this.Summary,
            this.ReopenedCount,
            this.Reviewer,
            this.SFQueue,
            this.SFStatus,
            this.Status,
            this.NextStatus});
            this.grdCaseList.Location = new System.Drawing.Point(8, 118);
            this.grdCaseList.Name = "grdCaseList";
            this.grdCaseList.Size = new System.Drawing.Size(1288, 557);
            this.grdCaseList.TabIndex = 9;
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
            // Product
            // 
            this.Product.DataPropertyName = "Product";
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
            // Version
            // 
            this.Version.DataPropertyName = "Version";
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // Summary
            // 
            this.Summary.DataPropertyName = "Summary";
            this.Summary.HeaderText = "Summary";
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            // 
            // ReopenedCount
            // 
            this.ReopenedCount.DataPropertyName = "ReopenedCount";
            this.ReopenedCount.HeaderText = "Reopened Times";
            this.ReopenedCount.Name = "ReopenedCount";
            this.ReopenedCount.ReadOnly = true;
            // 
            // Reviewer
            // 
            this.Reviewer.DataPropertyName = "Reviewer";
            this.Reviewer.HeaderText = "Reviewer";
            this.Reviewer.Name = "Reviewer";
            // 
            // SFQueue
            // 
            this.SFQueue.DataPropertyName = "SFQueue";
            this.SFQueue.HeaderText = "SF Queue";
            this.SFQueue.Name = "SFQueue";
            this.SFQueue.ReadOnly = true;
            // 
            // SFStatus
            // 
            this.SFStatus.DataPropertyName = "SFStatus";
            this.SFStatus.HeaderText = "SF Status";
            this.SFStatus.Name = "SFStatus";
            this.SFStatus.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "JiraStatus";
            this.Status.HeaderText = "Jira Status";
            this.Status.Name = "Status";
            // 
            // NextStatus
            // 
            this.NextStatus.DataPropertyName = "JiraNextStatus";
            this.NextStatus.HeaderText = "Next JIRA Status";
            this.NextStatus.Name = "NextStatus";
            // 
            // grbFunctionArea
            // 
            this.grbFunctionArea.Controls.Add(this.txtCaseIDList);
            this.grbFunctionArea.Controls.Add(this.btnTop50NewCases);
            this.grbFunctionArea.Controls.Add(this.btnSyncWithJIRA);
            this.grbFunctionArea.Controls.Add(this.btnSendNotificationEmail);
            this.grbFunctionArea.Location = new System.Drawing.Point(8, 9);
            this.grbFunctionArea.Name = "grbFunctionArea";
            this.grbFunctionArea.Size = new System.Drawing.Size(1288, 103);
            this.grbFunctionArea.TabIndex = 13;
            this.grbFunctionArea.TabStop = false;
            // 
            // txtCaseIDList
            // 
            this.txtCaseIDList.Location = new System.Drawing.Point(163, 22);
            this.txtCaseIDList.Multiline = true;
            this.txtCaseIDList.Name = "txtCaseIDList";
            this.txtCaseIDList.Size = new System.Drawing.Size(1119, 74);
            this.txtCaseIDList.TabIndex = 16;
            // 
            // btnTop50NewCases
            // 
            this.btnTop50NewCases.Location = new System.Drawing.Point(16, 19);
            this.btnTop50NewCases.Name = "btnTop50NewCases";
            this.btnTop50NewCases.Size = new System.Drawing.Size(130, 23);
            this.btnTop50NewCases.TabIndex = 15;
            this.btnTop50NewCases.Text = "Top 50 New Case";
            this.btnTop50NewCases.UseVisualStyleBackColor = true;
            this.btnTop50NewCases.Click += new System.EventHandler(this.btnTop50NewCases_Click);
            // 
            // btnSyncWithJIRA
            // 
            this.btnSyncWithJIRA.Location = new System.Drawing.Point(16, 48);
            this.btnSyncWithJIRA.Name = "btnSyncWithJIRA";
            this.btnSyncWithJIRA.Size = new System.Drawing.Size(130, 23);
            this.btnSyncWithJIRA.TabIndex = 14;
            this.btnSyncWithJIRA.Text = "Sync with JIRA";
            this.btnSyncWithJIRA.UseVisualStyleBackColor = true;
            this.btnSyncWithJIRA.Click += new System.EventHandler(this.btnSyncWithJIRA_Click);
            // 
            // btnSendNotificationEmail
            // 
            this.btnSendNotificationEmail.Location = new System.Drawing.Point(16, 73);
            this.btnSendNotificationEmail.Name = "btnSendNotificationEmail";
            this.btnSendNotificationEmail.Size = new System.Drawing.Size(130, 23);
            this.btnSendNotificationEmail.TabIndex = 13;
            this.btnSendNotificationEmail.Text = "Send Notication Email";
            this.btnSendNotificationEmail.UseVisualStyleBackColor = true;
            this.btnSendNotificationEmail.Click += new System.EventHandler(this.btnSendNotificationEmail_Click);
            // 
            // txtSFID
            // 
            this.txtSFID.Location = new System.Drawing.Point(8, 698);
            this.txtSFID.Name = "txtSFID";
            this.txtSFID.Size = new System.Drawing.Size(102, 20);
            this.txtSFID.TabIndex = 17;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(128, 695);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 18;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(209, 695);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 19;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // FTPMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 756);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.txtSFID);
            this.Controls.Add(this.grbFunctionArea);
            this.Controls.Add(this.grdCaseList);
            this.Name = "FTPMonitor";
            this.Text = "DBMonitor";
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).EndInit();
            this.grbFunctionArea.ResumeLayout(false);
            this.grbFunctionArea.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCaseList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewLinkColumn SalesforceID;
        private System.Windows.Forms.DataGridViewLinkColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReopenedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reviewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn NextStatus;
        private System.Windows.Forms.GroupBox grbFunctionArea;
        private System.Windows.Forms.Button btnTop50NewCases;
        private System.Windows.Forms.Button btnSyncWithJIRA;
        private System.Windows.Forms.Button btnSendNotificationEmail;
        private System.Windows.Forms.TextBox txtCaseIDList;
        private System.Windows.Forms.TextBox txtSFID;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnSubmit;
    }
}