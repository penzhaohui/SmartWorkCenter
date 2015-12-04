namespace com.smartwork
{
    partial class UpdateMyJIRAIssueFromSalesforce
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnLookUpInJiraAndSF = new System.Windows.Forms.Button();
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
            this.btnSyncCaseInJiraAndSF = new System.Windows.Forms.Button();
            this.btnSendTaskList = new System.Windows.Forms.Button();
            this.ddlReviewerEmailAddress = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please enter your email address and then click \"Sync\" button";
            // 
            // btnLookUpInJiraAndSF
            // 
            this.btnLookUpInJiraAndSF.Location = new System.Drawing.Point(331, 47);
            this.btnLookUpInJiraAndSF.Name = "btnLookUpInJiraAndSF";
            this.btnLookUpInJiraAndSF.Size = new System.Drawing.Size(75, 23);
            this.btnLookUpInJiraAndSF.TabIndex = 2;
            this.btnLookUpInJiraAndSF.Text = "Look Up";
            this.btnLookUpInJiraAndSF.UseVisualStyleBackColor = true;
            this.btnLookUpInJiraAndSF.Click += new System.EventHandler(this.btnLookUpInJiraAndSF_Click);
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
            this.grdCaseList.Location = new System.Drawing.Point(12, 75);
            this.grdCaseList.Name = "grdCaseList";
            this.grdCaseList.Size = new System.Drawing.Size(1277, 674);
            this.grdCaseList.TabIndex = 8;
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
            // btnSyncCaseInJiraAndSF
            // 
            this.btnSyncCaseInJiraAndSF.Location = new System.Drawing.Point(412, 46);
            this.btnSyncCaseInJiraAndSF.Name = "btnSyncCaseInJiraAndSF";
            this.btnSyncCaseInJiraAndSF.Size = new System.Drawing.Size(75, 23);
            this.btnSyncCaseInJiraAndSF.TabIndex = 9;
            this.btnSyncCaseInJiraAndSF.Text = "Sync";
            this.btnSyncCaseInJiraAndSF.UseVisualStyleBackColor = true;
            this.btnSyncCaseInJiraAndSF.Click += new System.EventHandler(this.btnSyncCaseInJiraAndSF_Click);
            // 
            // btnSendTaskList
            // 
            this.btnSendTaskList.Location = new System.Drawing.Point(493, 46);
            this.btnSendTaskList.Name = "btnSendTaskList";
            this.btnSendTaskList.Size = new System.Drawing.Size(75, 23);
            this.btnSendTaskList.TabIndex = 10;
            this.btnSendTaskList.Text = "Send";
            this.btnSendTaskList.UseVisualStyleBackColor = true;
            this.btnSendTaskList.Click += new System.EventHandler(this.btnSendTaskList_Click);
            // 
            // ddlReviewerEmailAddress
            // 
            this.ddlReviewerEmailAddress.FormattingEnabled = true;
            this.ddlReviewerEmailAddress.Location = new System.Drawing.Point(12, 48);
            this.ddlReviewerEmailAddress.Name = "ddlReviewerEmailAddress";
            this.ddlReviewerEmailAddress.Size = new System.Drawing.Size(293, 21);
            this.ddlReviewerEmailAddress.TabIndex = 11;
            // 
            // UpdateMyJIRAIssueFromSalesforce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1301, 767);
            this.Controls.Add(this.ddlReviewerEmailAddress);
            this.Controls.Add(this.btnSendTaskList);
            this.Controls.Add(this.btnSyncCaseInJiraAndSF);
            this.Controls.Add(this.grdCaseList);
            this.Controls.Add(this.btnLookUpInJiraAndSF);
            this.Controls.Add(this.label1);
            this.Name = "UpdateMyJIRAIssueFromSalesforce";
            this.Text = "Update My JIRA Issues From Salesforce";
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLookUpInJiraAndSF;
        private System.Windows.Forms.DataGridView grdCaseList;
        private System.Windows.Forms.Button btnSyncCaseInJiraAndSF;
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
        private System.Windows.Forms.Button btnSendTaskList;
        private System.Windows.Forms.ComboBox ddlReviewerEmailAddress;
    }
}