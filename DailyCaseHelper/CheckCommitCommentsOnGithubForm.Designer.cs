namespace com.smartwork
{
    partial class CheckCommitCommentsOnGithubForm
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
            this.cmbRepositories = new System.Windows.Forms.ComboBox();
            this.cmbBranches = new System.Windows.Forms.ComboBox();
            this.lblRepository = new System.Windows.Forms.Label();
            this.lblBranch = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.txtCommitCommentOutput = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbRepositories
            // 
            this.cmbRepositories.FormattingEnabled = true;
            this.cmbRepositories.Location = new System.Drawing.Point(25, 28);
            this.cmbRepositories.Name = "cmbRepositories";
            this.cmbRepositories.Size = new System.Drawing.Size(116, 21);
            this.cmbRepositories.TabIndex = 0;
            this.cmbRepositories.SelectedIndexChanged += new System.EventHandler(this.cmbRepositories_SelectedIndexChanged);
            // 
            // cmbBranches
            // 
            this.cmbBranches.FormattingEnabled = true;
            this.cmbBranches.Location = new System.Drawing.Point(170, 28);
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Size = new System.Drawing.Size(116, 21);
            this.cmbBranches.TabIndex = 1;
            // 
            // lblRepository
            // 
            this.lblRepository.AutoSize = true;
            this.lblRepository.Location = new System.Drawing.Point(22, 12);
            this.lblRepository.Name = "lblRepository";
            this.lblRepository.Size = new System.Drawing.Size(57, 13);
            this.lblRepository.TabIndex = 2;
            this.lblRepository.Text = "Repository";
            // 
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(167, 12);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(41, 13);
            this.lblBranch.TabIndex = 3;
            this.lblBranch.Text = "Branch";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(310, 28);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 136);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(25, 88);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(261, 20);
            this.dtpStart.TabIndex = 5;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(25, 144);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(262, 20);
            this.dtpEnd.TabIndex = 6;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(22, 72);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(29, 13);
            this.lblStart.TabIndex = 7;
            this.lblStart.Text = "Start";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(22, 128);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(26, 13);
            this.lblEnd.TabIndex = 8;
            this.lblEnd.Text = "End";
            // 
            // txtCommitCommentOutput
            // 
            this.txtCommitCommentOutput.Location = new System.Drawing.Point(25, 183);
            this.txtCommitCommentOutput.Multiline = true;
            this.txtCommitCommentOutput.Name = "txtCommitCommentOutput";
            this.txtCommitCommentOutput.Size = new System.Drawing.Size(1257, 567);
            this.txtCommitCommentOutput.TabIndex = 9;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(401, 28);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 136);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // CheckCommitCommentsOnGithubForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 773);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtCommitCommentOutput);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.lblRepository);
            this.Controls.Add(this.cmbBranches);
            this.Controls.Add(this.cmbRepositories);
            this.Name = "CheckCommitCommentsOnGithubForm";
            this.Text = "Check Commit Comments On Github";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRepositories;
        private System.Windows.Forms.ComboBox cmbBranches;
        private System.Windows.Forms.Label lblRepository;
        private System.Windows.Forms.Label lblBranch;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.TextBox txtCommitCommentOutput;
        private System.Windows.Forms.Button btnSend;
    }
}