namespace com.smartwork
{
    partial class BatchMEOForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblSubTaskStatus = new System.Windows.Forms.Label();
            this.lblMEOOptions = new System.Windows.Forms.Label();
            this.cmbMEOOptions = new System.Windows.Forms.ComboBox();
            this.cmbSubTaskStatusOptions = new System.Windows.Forms.ComboBox();
            this.btnSync = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dgvSubTaskTable = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTaskAssignee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MEO = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TimeSpent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssociatedJirakey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssociatedJiraSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDefautMEO = new System.Windows.Forms.ComboBox();
            this.lblDefaultMEO = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubTaskTable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDefaultMEO);
            this.groupBox1.Controls.Add(this.cmbDefautMEO);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.lblSubTaskStatus);
            this.groupBox1.Controls.Add(this.lblMEOOptions);
            this.groupBox1.Controls.Add(this.cmbMEOOptions);
            this.groupBox1.Controls.Add(this.cmbSubTaskStatusOptions);
            this.groupBox1.Controls.Add(this.btnSync);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.lblPassword);
            this.groupBox1.Controls.Add(this.lblUser);
            this.groupBox1.Controls.Add(this.dtpTo);
            this.groupBox1.Controls.Add(this.dtpFrom);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.lblFrom);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1267, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(753, 22);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 57);
            this.btnSubmit.TabIndex = 15;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblSubTaskStatus
            // 
            this.lblSubTaskStatus.AutoSize = true;
            this.lblSubTaskStatus.Location = new System.Drawing.Point(414, 26);
            this.lblSubTaskStatus.Name = "lblSubTaskStatus";
            this.lblSubTaskStatus.Size = new System.Drawing.Size(89, 13);
            this.lblSubTaskStatus.TabIndex = 13;
            this.lblSubTaskStatus.Text = "Sub Task Status:";
            // 
            // lblMEOOptions
            // 
            this.lblMEOOptions.AutoSize = true;
            this.lblMEOOptions.Location = new System.Drawing.Point(429, 61);
            this.lblMEOOptions.Name = "lblMEOOptions";
            this.lblMEOOptions.Size = new System.Drawing.Size(74, 13);
            this.lblMEOOptions.TabIndex = 12;
            this.lblMEOOptions.Text = "M.E.O Option:";
            // 
            // cmbMEOOptions
            // 
            this.cmbMEOOptions.FormattingEnabled = true;
            this.cmbMEOOptions.Location = new System.Drawing.Point(530, 58);
            this.cmbMEOOptions.Name = "cmbMEOOptions";
            this.cmbMEOOptions.Size = new System.Drawing.Size(121, 21);
            this.cmbMEOOptions.TabIndex = 11;
            // 
            // cmbSubTaskStatusOptions
            // 
            this.cmbSubTaskStatusOptions.FormattingEnabled = true;
            this.cmbSubTaskStatusOptions.Location = new System.Drawing.Point(530, 23);
            this.cmbSubTaskStatusOptions.Name = "cmbSubTaskStatusOptions";
            this.cmbSubTaskStatusOptions.Size = new System.Drawing.Size(121, 21);
            this.cmbSubTaskStatusOptions.TabIndex = 10;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(672, 23);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 57);
            this.btnSync.TabIndex = 8;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(260, 55);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(100, 20);
            this.txtPassword.TabIndex = 7;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(260, 23);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 6;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(195, 62);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(219, 30);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "User:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(73, 55);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(100, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(73, 23);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(26, 62);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To:";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(16, 29);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "From:";
            // 
            // dgvSubTaskTable
            // 
            this.dgvSubTaskTable.AllowUserToAddRows = false;
            this.dgvSubTaskTable.AllowUserToDeleteRows = false;
            this.dgvSubTaskTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubTaskTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.SubTaskKey,
            this.SubTaskSummary,
            this.SubTaskStatus,
            this.SubTaskAssignee,
            this.MEO,
            this.TimeSpent,
            this.AssociatedJirakey,
            this.AssociatedJiraSummary});
            this.dgvSubTaskTable.Location = new System.Drawing.Point(12, 118);
            this.dgvSubTaskTable.Name = "dgvSubTaskTable";
            this.dgvSubTaskTable.Size = new System.Drawing.Size(1267, 631);
            this.dgvSubTaskTable.TabIndex = 1;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 30;
            // 
            // SubTaskKey
            // 
            this.SubTaskKey.DataPropertyName = "SubTaskKey";
            this.SubTaskKey.HeaderText = "Sub Task Key";
            this.SubTaskKey.Name = "SubTaskKey";
            this.SubTaskKey.Width = 130;
            // 
            // SubTaskSummary
            // 
            this.SubTaskSummary.DataPropertyName = "SubTaskSummary";
            this.SubTaskSummary.HeaderText = "Sub Task Summary";
            this.SubTaskSummary.Name = "SubTaskSummary";
            this.SubTaskSummary.Width = 250;
            // 
            // SubTaskStatus
            // 
            this.SubTaskStatus.DataPropertyName = "SubTaskStatus";
            this.SubTaskStatus.HeaderText = "Sub Task Status";
            this.SubTaskStatus.Name = "SubTaskStatus";
            this.SubTaskStatus.Width = 150;
            // 
            // SubTaskAssignee
            // 
            this.SubTaskAssignee.DataPropertyName = "SubTaskAssignee";
            this.SubTaskAssignee.HeaderText = "Sub Task Assignee";
            this.SubTaskAssignee.Name = "SubTaskAssignee";
            this.SubTaskAssignee.Width = 150;
            // 
            // MEO
            // 
            this.MEO.DataPropertyName = "MEO";
            this.MEO.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.MEO.HeaderText = "M.E.O";
            this.MEO.Items.AddRange(new object[] {
            "None",
            "Meets",
            "Exceeds",
            "Outstanding"});
            this.MEO.Name = "MEO";
            this.MEO.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.MEO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // TimeSpent
            // 
            this.TimeSpent.DataPropertyName = "TimeSpent";
            this.TimeSpent.HeaderText = "Time Spent";
            this.TimeSpent.Name = "TimeSpent";
            // 
            // AssociatedJirakey
            // 
            this.AssociatedJirakey.DataPropertyName = "AssociatedJirakey";
            this.AssociatedJirakey.HeaderText = "Associated Jira key";
            this.AssociatedJirakey.Name = "AssociatedJirakey";
            this.AssociatedJirakey.Width = 130;
            // 
            // AssociatedJiraSummary
            // 
            this.AssociatedJiraSummary.DataPropertyName = "AssociatedJiraSummary";
            this.AssociatedJiraSummary.HeaderText = "Associated Jira Summary";
            this.AssociatedJiraSummary.Name = "AssociatedJiraSummary";
            this.AssociatedJiraSummary.Width = 250;
            // 
            // cmbDefautMEO
            // 
            this.cmbDefautMEO.FormattingEnabled = true;
            this.cmbDefautMEO.Location = new System.Drawing.Point(1125, 21);
            this.cmbDefautMEO.Name = "cmbDefautMEO";
            this.cmbDefautMEO.Size = new System.Drawing.Size(121, 21);
            this.cmbDefautMEO.TabIndex = 16;
            // 
            // lblDefaultMEO
            // 
            this.lblDefaultMEO.AutoSize = true;
            this.lblDefaultMEO.Location = new System.Drawing.Point(1045, 26);
            this.lblDefaultMEO.Name = "lblDefaultMEO";
            this.lblDefaultMEO.Size = new System.Drawing.Size(74, 13);
            this.lblDefaultMEO.TabIndex = 17;
            this.lblDefaultMEO.Text = "Default M.E.O";
            // 
            // BatchMEOForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 761);
            this.ControlBox = false;
            this.Controls.Add(this.dgvSubTaskTable);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchMEOForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Batch M.E.O";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubTaskTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DataGridView dgvSubTaskTable;
        private System.Windows.Forms.Label lblSubTaskStatus;
        private System.Windows.Forms.Label lblMEOOptions;
        private System.Windows.Forms.ComboBox cmbMEOOptions;
        private System.Windows.Forms.ComboBox cmbSubTaskStatusOptions;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTaskAssignee;
        private System.Windows.Forms.DataGridViewComboBoxColumn MEO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSpent;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssociatedJirakey;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssociatedJiraSummary;
        private System.Windows.Forms.Label lblDefaultMEO;
        private System.Windows.Forms.ComboBox cmbDefautMEO;
    }
}