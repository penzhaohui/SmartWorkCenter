namespace com.smartwork
{
    partial class MergeAttchmentFromSalesforce
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
            this.dgdMergeFileList = new System.Windows.Forms.DataGridView();
            this.grpMergeCaseAttachment = new System.Windows.Forms.GroupBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.txtInputCaseList = new System.Windows.Forms.TextBox();
            this.Merge = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaseFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UploadedBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgdMergeFileList)).BeginInit();
            this.grpMergeCaseAttachment.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgdMergeFileList
            // 
            this.dgdMergeFileList.AllowUserToAddRows = false;
            this.dgdMergeFileList.AllowUserToDeleteRows = false;
            this.dgdMergeFileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgdMergeFileList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Merge,
            this.JiraKey,
            this.JiraFileName,
            this.CaseNumber,
            this.CaseFileName,
            this.UploadDate,
            this.UploadedBy});
            this.dgdMergeFileList.Location = new System.Drawing.Point(18, 115);
            this.dgdMergeFileList.Name = "dgdMergeFileList";
            this.dgdMergeFileList.Size = new System.Drawing.Size(1166, 553);
            this.dgdMergeFileList.TabIndex = 0;
            // 
            // grpMergeCaseAttachment
            // 
            this.grpMergeCaseAttachment.Controls.Add(this.btnMerge);
            this.grpMergeCaseAttachment.Controls.Add(this.btnSync);
            this.grpMergeCaseAttachment.Controls.Add(this.txtInputCaseList);
            this.grpMergeCaseAttachment.Location = new System.Drawing.Point(12, 12);
            this.grpMergeCaseAttachment.Name = "grpMergeCaseAttachment";
            this.grpMergeCaseAttachment.Size = new System.Drawing.Size(936, 86);
            this.grpMergeCaseAttachment.TabIndex = 1;
            this.grpMergeCaseAttachment.TabStop = false;
            this.grpMergeCaseAttachment.Text = "Import Case ID List";
            // 
            // btnMerge
            // 
            this.btnMerge.Location = new System.Drawing.Point(291, 30);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(75, 50);
            this.btnMerge.TabIndex = 4;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(210, 30);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 50);
            this.btnSync.TabIndex = 3;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // txtInputCaseList
            // 
            this.txtInputCaseList.Location = new System.Drawing.Point(6, 30);
            this.txtInputCaseList.Multiline = true;
            this.txtInputCaseList.Name = "txtInputCaseList";
            this.txtInputCaseList.Size = new System.Drawing.Size(198, 50);
            this.txtInputCaseList.TabIndex = 2;
            // 
            // Merge
            // 
            this.Merge.DataPropertyName = "IsMerged";
            this.Merge.Frozen = true;
            this.Merge.HeaderText = "Merge";
            this.Merge.Name = "Merge";
            // 
            // JiraKey
            // 
            this.JiraKey.DataPropertyName = "JiraKey";
            this.JiraKey.Frozen = true;
            this.JiraKey.HeaderText = "Jira Key";
            this.JiraKey.Name = "JiraKey";
            // 
            // JiraFileName
            // 
            this.JiraFileName.DataPropertyName = "JiraFileName";
            this.JiraFileName.Frozen = true;
            this.JiraFileName.HeaderText = "Attchement From JIRA";
            this.JiraFileName.Name = "JiraFileName";
            this.JiraFileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.JiraFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.JiraFileName.Width = 300;
            // 
            // CaseNumber
            // 
            this.CaseNumber.DataPropertyName = "CaseNumber";
            this.CaseNumber.Frozen = true;
            this.CaseNumber.HeaderText = "Salesforce ID";
            this.CaseNumber.Name = "CaseNumber";
            // 
            // CaseFileName
            // 
            this.CaseFileName.DataPropertyName = "CaseFileName";
            this.CaseFileName.Frozen = true;
            this.CaseFileName.HeaderText = "Attchement From Salesforce";
            this.CaseFileName.Name = "CaseFileName";
            this.CaseFileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CaseFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CaseFileName.Width = 300;
            // 
            // UploadDate
            // 
            this.UploadDate.DataPropertyName = "UploadDate";
            this.UploadDate.HeaderText = "Upload Date";
            this.UploadDate.Name = "UploadDate";
            this.UploadDate.ReadOnly = true;
            // 
            // UploadedBy
            // 
            this.UploadedBy.DataPropertyName = "UploadedBy";
            this.UploadedBy.HeaderText = "Uploaded By";
            this.UploadedBy.Name = "UploadedBy";
            this.UploadedBy.ReadOnly = true;
            // 
            // MergeAttchmentFromSalesforce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 680);
            this.Controls.Add(this.grpMergeCaseAttachment);
            this.Controls.Add(this.dgdMergeFileList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MergeAttchmentFromSalesforce";
            this.Text = "Merge Attchment From Salesforce";
            ((System.ComponentModel.ISupportInitialize)(this.dgdMergeFileList)).EndInit();
            this.grpMergeCaseAttachment.ResumeLayout(false);
            this.grpMergeCaseAttachment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgdMergeFileList;
        private System.Windows.Forms.GroupBox grpMergeCaseAttachment;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.TextBox txtInputCaseList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Merge;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaseFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadedBy;
    }
}