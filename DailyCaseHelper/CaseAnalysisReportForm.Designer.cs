namespace com.smartwork
{
    partial class CaseAnalysisReportForm
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
            this.grpMergeCaseAttachment = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.txtInputCaseList = new System.Windows.Forms.TextBox();
            this.grdCaseList = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesforceID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewLinkColumn();
            this.IssueCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFCommentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevCommentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QACommentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFQueue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpMergeCaseAttachment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMergeCaseAttachment
            // 
            this.grpMergeCaseAttachment.Controls.Add(this.btnSend);
            this.grpMergeCaseAttachment.Controls.Add(this.btnSync);
            this.grpMergeCaseAttachment.Controls.Add(this.txtInputCaseList);
            this.grpMergeCaseAttachment.Location = new System.Drawing.Point(12, 12);
            this.grpMergeCaseAttachment.Name = "grpMergeCaseAttachment";
            this.grpMergeCaseAttachment.Size = new System.Drawing.Size(1280, 162);
            this.grpMergeCaseAttachment.TabIndex = 2;
            this.grpMergeCaseAttachment.TabStop = false;
            this.grpMergeCaseAttachment.Text = "Import Case ID List";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1199, 84);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 60);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(1199, 19);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 59);
            this.btnSync.TabIndex = 3;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // txtInputCaseList
            // 
            this.txtInputCaseList.Location = new System.Drawing.Point(6, 19);
            this.txtInputCaseList.Multiline = true;
            this.txtInputCaseList.Name = "txtInputCaseList";
            this.txtInputCaseList.Size = new System.Drawing.Size(1187, 125);
            this.txtInputCaseList.TabIndex = 2;
            // 
            // grdCaseList
            // 
            this.grdCaseList.AllowUserToAddRows = false;
            this.grdCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Product,
            this.SalesforceID,
            this.JiraKey,
            this.IssueCategory,
            this.SFCommentCount,
            this.DevCommentCount,
            this.QACommentCount,
            this.Severity,
            this.Version,
            this.Customer,
            this.OpenDate,
            this.Summary,
            this.SFQueue,
            this.SFStatus});
            this.grdCaseList.Location = new System.Drawing.Point(12, 180);
            this.grdCaseList.Name = "grdCaseList";
            this.grdCaseList.Size = new System.Drawing.Size(1280, 522);
            this.grdCaseList.TabIndex = 8;
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
            // IssueCategory
            // 
            this.IssueCategory.DataPropertyName = "IssueCategory";
            this.IssueCategory.HeaderText = "Issue Category";
            this.IssueCategory.Name = "IssueCategory";
            // 
            // SFCommentCount
            // 
            this.SFCommentCount.DataPropertyName = "SFCaseCommentCount";
            this.SFCommentCount.HeaderText = "SFComment Count";
            this.SFCommentCount.Name = "SFCommentCount";
            // 
            // DevCommentCount
            // 
            this.DevCommentCount.DataPropertyName = "SFDevCaseCommentCount";
            this.DevCommentCount.HeaderText = "Dev Comment Count";
            this.DevCommentCount.Name = "DevCommentCount";
            // 
            // QACommentCount
            // 
            this.QACommentCount.DataPropertyName = "SFQACaseCommentCount";
            this.QACommentCount.HeaderText = "QA Comment Count";
            this.QACommentCount.Name = "QACommentCount";
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
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
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
            // CaseAnalysisReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 709);
            this.Controls.Add(this.grdCaseList);
            this.Controls.Add(this.grpMergeCaseAttachment);
            this.MaximizeBox = false;
            this.Name = "CaseAnalysisReportForm";
            this.Text = "Case Analysis & Report";
            this.grpMergeCaseAttachment.ResumeLayout(false);
            this.grpMergeCaseAttachment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMergeCaseAttachment;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.TextBox txtInputCaseList;
        private System.Windows.Forms.DataGridView grdCaseList;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewLinkColumn SalesforceID;
        private System.Windows.Forms.DataGridViewLinkColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFCommentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevCommentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn QACommentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFQueue;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFStatus;
    }
}