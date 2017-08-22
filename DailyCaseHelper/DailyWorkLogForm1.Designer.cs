namespace com.smartwork
{
    partial class DailyWorkLogForm1
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
            this.gpbFunctionArea = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.dgvWorkLogReport = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Assignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Effort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskAssignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpbFunctionArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkLogReport)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFunctionArea
            // 
            this.gpbFunctionArea.Controls.Add(this.btnSend);
            this.gpbFunctionArea.Controls.Add(this.btnAssign);
            this.gpbFunctionArea.Controls.Add(this.dtpTo);
            this.gpbFunctionArea.Controls.Add(this.dtpFrom);
            this.gpbFunctionArea.Controls.Add(this.lblTo);
            this.gpbFunctionArea.Controls.Add(this.lblFrom);
            this.gpbFunctionArea.Controls.Add(this.btnSync);
            this.gpbFunctionArea.Location = new System.Drawing.Point(12, 12);
            this.gpbFunctionArea.Name = "gpbFunctionArea";
            this.gpbFunctionArea.Size = new System.Drawing.Size(1270, 91);
            this.gpbFunctionArea.TabIndex = 0;
            this.gpbFunctionArea.TabStop = false;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(482, 19);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(140, 53);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(336, 20);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(140, 53);
            this.btnAssign.TabIndex = 1;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(78, 52);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(106, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(78, 22);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(106, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(40, 58);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(30, 28);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From:";
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(190, 19);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(140, 53);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // dgvWorkLogReport
            // 
            this.dgvWorkLogReport.AllowUserToAddRows = false;
            this.dgvWorkLogReport.AllowUserToDeleteRows = false;
            this.dgvWorkLogReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWorkLogReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Assignee,
            this.Effort,
            this.SubTaskID,
            this.SubTaskSummary,
            this.SubTaskAssignee,
            this.SubTaskComment,
            this.JiraKey,
            this.JiraSummary});
            this.dgvWorkLogReport.Location = new System.Drawing.Point(12, 119);
            this.dgvWorkLogReport.Name = "dgvWorkLogReport";
            this.dgvWorkLogReport.ReadOnly = true;
            this.dgvWorkLogReport.Size = new System.Drawing.Size(1270, 623);
            this.dgvWorkLogReport.TabIndex = 1;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;
            // 
            // Assignee
            // 
            this.Assignee.DataPropertyName = "Name";
            this.Assignee.HeaderText = "Name";
            this.Assignee.Name = "Assignee";
            this.Assignee.ReadOnly = true;
            // 
            // Effort
            // 
            this.Effort.DataPropertyName = "Effort";
            this.Effort.HeaderText = "Effort";
            this.Effort.Name = "Effort";
            this.Effort.ReadOnly = true;
            // 
            // SubTaskID
            // 
            this.SubTaskID.DataPropertyName = "SubTaskID";
            this.SubTaskID.HeaderText = "Sub Task[ID]";
            this.SubTaskID.Name = "SubTaskID";
            this.SubTaskID.ReadOnly = true;
            // 
            // SubTaskSummary
            // 
            this.SubTaskSummary.DataPropertyName = "SubTaskSummary";
            this.SubTaskSummary.HeaderText = "Sub Task[Summary]";
            this.SubTaskSummary.Name = "SubTaskSummary";
            this.SubTaskSummary.ReadOnly = true;
            this.SubTaskSummary.Width = 200;
            // 
            // SubTaskAssignee
            // 
            this.SubTaskAssignee.DataPropertyName = "SubTaskAssignee";
            this.SubTaskAssignee.HeaderText = "Sub Task[Assignee]";
            this.SubTaskAssignee.Name = "SubTaskAssignee";
            this.SubTaskAssignee.ReadOnly = true;
            this.SubTaskAssignee.Width = 150;
            // 
            // SubTaskComment
            // 
            this.SubTaskComment.DataPropertyName = "SubTaskComment";
            this.SubTaskComment.HeaderText = "Sub Task[Comment]";
            this.SubTaskComment.Name = "SubTaskComment";
            this.SubTaskComment.ReadOnly = true;
            this.SubTaskComment.Width = 250;
            // 
            // JiraKey
            // 
            this.JiraKey.DataPropertyName = "JiraKey";
            this.JiraKey.HeaderText = "Associated Jira Key";
            this.JiraKey.Name = "JiraKey";
            this.JiraKey.ReadOnly = true;
            // 
            // JiraSummary
            // 
            this.JiraSummary.DataPropertyName = "JiraSummary";
            this.JiraSummary.HeaderText = "Associated Jira Summary";
            this.JiraSummary.Name = "JiraSummary";
            this.JiraSummary.ReadOnly = true;
            this.JiraSummary.Width = 200;
            // 
            // DailyWorkLogForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 754);
            this.ControlBox = false;
            this.Controls.Add(this.dgvWorkLogReport);
            this.Controls.Add(this.gpbFunctionArea);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DailyWorkLogForm1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Daily Work Log Report";
            this.gpbFunctionArea.ResumeLayout(false);
            this.gpbFunctionArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWorkLogReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFunctionArea;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.DataGridView dgvWorkLogReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssignName;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Assignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Effort;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskAssignee;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraSummary;
    }
}