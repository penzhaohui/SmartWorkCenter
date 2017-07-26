namespace com.smartwork
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemDatabaseConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemEmailSever = new System.Windows.Forms.ToolStripMenuItem();
            this.importCaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCaseFromExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importCaseFromEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncJiraIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FTPMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeAttachmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caseAnalysisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanStatusCrossProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanReleaseStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklyReportToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dBRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveryProgressReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyWorkLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchCreateSubTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.githubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkCommitCommentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.testrailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesforceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyCaseToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.scanTestResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetting,
            this.salesforceToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.githubToolStripMenuItem,
            this.testrailToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1307, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuSetting
            // 
            this.menuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDatabaseConnection,
            this.menuItemEmailSever,
            this.importCaseToolStripMenuItem,
            this.menuItemExit});
            this.menuSetting.Name = "menuSetting";
            this.menuSetting.Size = new System.Drawing.Size(61, 20);
            this.menuSetting.Text = "Settings";
            // 
            // menuItemDatabaseConnection
            // 
            this.menuItemDatabaseConnection.Name = "menuItemDatabaseConnection";
            this.menuItemDatabaseConnection.Size = new System.Drawing.Size(152, 22);
            this.menuItemDatabaseConnection.Text = "Database";
            this.menuItemDatabaseConnection.Click += new System.EventHandler(this.menuItemDatabaseConnection_Click);
            // 
            // menuItemEmailSever
            // 
            this.menuItemEmailSever.Name = "menuItemEmailSever";
            this.menuItemEmailSever.Size = new System.Drawing.Size(152, 22);
            this.menuItemEmailSever.Text = "Email Setting";
            this.menuItemEmailSever.Click += new System.EventHandler(this.menuItemEmailSever_Click);
            // 
            // importCaseToolStripMenuItem
            // 
            this.importCaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCaseFromExcelToolStripMenuItem,
            this.importCaseFromEmailToolStripMenuItem});
            this.importCaseToolStripMenuItem.Name = "importCaseToolStripMenuItem";
            this.importCaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importCaseToolStripMenuItem.Text = "Import Case";
            // 
            // importCaseFromExcelToolStripMenuItem
            // 
            this.importCaseFromExcelToolStripMenuItem.Name = "importCaseFromExcelToolStripMenuItem";
            this.importCaseFromExcelToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.importCaseFromExcelToolStripMenuItem.Text = "From Excel ";
            this.importCaseFromExcelToolStripMenuItem.Click += new System.EventHandler(this.importCaseFromExcelToolStripMenuItem_Click);
            // 
            // importCaseFromEmailToolStripMenuItem
            // 
            this.importCaseFromEmailToolStripMenuItem.Name = "importCaseFromEmailToolStripMenuItem";
            this.importCaseFromEmailToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.importCaseFromEmailToolStripMenuItem.Text = "From Email";
            this.importCaseFromEmailToolStripMenuItem.Click += new System.EventHandler(this.importCaseFromEmailToolStripMenuItem_Click);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(152, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.syncJiraIssueToolStripMenuItem,
            this.dailyCaseToolToolStripMenuItem,
            this.FTPMonitorToolStripMenuItem,
            this.dbManagerToolStripMenuItem,
            this.mergeAttachmentToolStripMenuItem,
            this.caseAnalysisToolStripMenuItem,
            this.scanStatusCrossProjectToolStripMenuItem,
            this.scanReleaseStatusToolStripMenuItem,
            this.weeklyReportToolStripMenuItem1,
            this.dBRequestToolStripMenuItem,
            this.deliveryProgressReportToolStripMenuItem,
            this.dailyWorkLogToolStripMenuItem,
            this.batchCreateSubTaskToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.toolsToolStripMenuItem.Text = "Jira";
            // 
            // syncJiraIssueToolStripMenuItem
            // 
            this.syncJiraIssueToolStripMenuItem.Name = "syncJiraIssueToolStripMenuItem";
            this.syncJiraIssueToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.syncJiraIssueToolStripMenuItem.Text = "Sync JIRA Issue";
            this.syncJiraIssueToolStripMenuItem.Click += new System.EventHandler(this.syncJiraIssueToolStripMenuItem_Click);
            // 
            // FTPMonitorToolStripMenuItem
            // 
            this.FTPMonitorToolStripMenuItem.Name = "FTPMonitorToolStripMenuItem";
            this.FTPMonitorToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.FTPMonitorToolStripMenuItem.Text = "FTP Monitor";
            this.FTPMonitorToolStripMenuItem.Click += new System.EventHandler(this.FTPMonitorToolStripMenuItem_Click);
            // 
            // dbManagerToolStripMenuItem
            // 
            this.dbManagerToolStripMenuItem.Name = "dbManagerToolStripMenuItem";
            this.dbManagerToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.dbManagerToolStripMenuItem.Text = "DB Manager";
            this.dbManagerToolStripMenuItem.Click += new System.EventHandler(this.dbManagerToolStripMenuItem_Click);
            // 
            // mergeAttachmentToolStripMenuItem
            // 
            this.mergeAttachmentToolStripMenuItem.Name = "mergeAttachmentToolStripMenuItem";
            this.mergeAttachmentToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.mergeAttachmentToolStripMenuItem.Text = "Merge Attachment";
            this.mergeAttachmentToolStripMenuItem.Click += new System.EventHandler(this.mergeAttachmentToolStripMenuItem_Click);
            // 
            // caseAnalysisToolStripMenuItem
            // 
            this.caseAnalysisToolStripMenuItem.Name = "caseAnalysisToolStripMenuItem";
            this.caseAnalysisToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.caseAnalysisToolStripMenuItem.Text = "Case Analysis";
            this.caseAnalysisToolStripMenuItem.Click += new System.EventHandler(this.caseAnalysisToolStripMenuItem_Click);
            // 
            // scanStatusCrossProjectToolStripMenuItem
            // 
            this.scanStatusCrossProjectToolStripMenuItem.Name = "scanStatusCrossProjectToolStripMenuItem";
            this.scanStatusCrossProjectToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.scanStatusCrossProjectToolStripMenuItem.Text = "Scan Status Cross Project";
            this.scanStatusCrossProjectToolStripMenuItem.Click += new System.EventHandler(this.scanStatusCrossProjectToolStripMenuItem_Click);
            // 
            // scanReleaseStatusToolStripMenuItem
            // 
            this.scanReleaseStatusToolStripMenuItem.Name = "scanReleaseStatusToolStripMenuItem";
            this.scanReleaseStatusToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.scanReleaseStatusToolStripMenuItem.Text = "Scan Release Status";
            this.scanReleaseStatusToolStripMenuItem.Click += new System.EventHandler(this.scanReleaseStatusToolStripMenuItem_Click);
            // 
            // weeklyReportToolStripMenuItem1
            // 
            this.weeklyReportToolStripMenuItem1.Name = "weeklyReportToolStripMenuItem1";
            this.weeklyReportToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.weeklyReportToolStripMenuItem1.Text = "Weekly Report";
            this.weeklyReportToolStripMenuItem1.Click += new System.EventHandler(this.weeklyReportToolStripMenuItem1_Click);
            // 
            // dBRequestToolStripMenuItem
            // 
            this.dBRequestToolStripMenuItem.Name = "dBRequestToolStripMenuItem";
            this.dBRequestToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.dBRequestToolStripMenuItem.Text = "DB Request";
            this.dBRequestToolStripMenuItem.Click += new System.EventHandler(this.dBRequestToolStripMenuItem_Click);
            // 
            // deliveryProgressReportToolStripMenuItem
            // 
            this.deliveryProgressReportToolStripMenuItem.Name = "deliveryProgressReportToolStripMenuItem";
            this.deliveryProgressReportToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.deliveryProgressReportToolStripMenuItem.Text = "Delivery Progress Report";
            this.deliveryProgressReportToolStripMenuItem.Click += new System.EventHandler(this.deliveryProgressReportToolStripMenuItem_Click);
            // 
            // dailyWorkLogToolStripMenuItem
            // 
            this.dailyWorkLogToolStripMenuItem.Name = "dailyWorkLogToolStripMenuItem";
            this.dailyWorkLogToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.dailyWorkLogToolStripMenuItem.Text = "Daily Work Log";
            this.dailyWorkLogToolStripMenuItem.Click += new System.EventHandler(this.dailyWorkLogToolStripMenuItem_Click);
            // 
            // batchCreateSubTaskToolStripMenuItem
            // 
            this.batchCreateSubTaskToolStripMenuItem.Name = "batchCreateSubTaskToolStripMenuItem";
            this.batchCreateSubTaskToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.batchCreateSubTaskToolStripMenuItem.Text = "Batch Create Sub Task";
            this.batchCreateSubTaskToolStripMenuItem.Click += new System.EventHandler(this.batchCreateSubTaskToolStripMenuItem_Click);
            // 
            // githubToolStripMenuItem
            // 
            this.githubToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkCommitCommentsToolStripMenuItem});
            this.githubToolStripMenuItem.Name = "githubToolStripMenuItem";
            this.githubToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.githubToolStripMenuItem.Text = "Github";
            // 
            // checkCommitCommentsToolStripMenuItem
            // 
            this.checkCommitCommentsToolStripMenuItem.Name = "checkCommitCommentsToolStripMenuItem";
            this.checkCommitCommentsToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.checkCommitCommentsToolStripMenuItem.Text = "Check Commit Comments";
            this.checkCommitCommentsToolStripMenuItem.Click += new System.EventHandler(this.checkCommitCommentsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // versionToolStripMenuItem
            // 
            this.versionToolStripMenuItem.Name = "versionToolStripMenuItem";
            this.versionToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.versionToolStripMenuItem.Text = "Version";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMessage});
            this.statusBar.Location = new System.Drawing.Point(0, 782);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1307, 22);
            this.statusBar.TabIndex = 6;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusMessage
            // 
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // testrailToolStripMenuItem
            // 
            this.testrailToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanTestResultToolStripMenuItem});
            this.testrailToolStripMenuItem.Name = "testrailToolStripMenuItem";
            this.testrailToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.testrailToolStripMenuItem.Text = "Testrail";
            // 
            // salesforceToolStripMenuItem
            // 
            this.salesforceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.toolStripMenuItem4});
            this.salesforceToolStripMenuItem.Name = "salesforceToolStripMenuItem";
            this.salesforceToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.salesforceToolStripMenuItem.Text = "Salesforce";
            // 
            // dailyCaseToolToolStripMenuItem
            // 
            this.dailyCaseToolToolStripMenuItem.Name = "dailyCaseToolToolStripMenuItem";
            this.dailyCaseToolToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.dailyCaseToolToolStripMenuItem.Text = "Daily Case Tool";
            this.dailyCaseToolToolStripMenuItem.Click += new System.EventHandler(this.dailyCaseToolToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 22);
            this.toolStripMenuItem2.Text = "Daily Case Tool";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem1.Text = "Delivery Progress Report";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem3.Text = "Weekly Report";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(202, 22);
            this.toolStripMenuItem4.Text = "FTP Monitor";
            // 
            // scanTestResultToolStripMenuItem
            // 
            this.scanTestResultToolStripMenuItem.Name = "scanTestResultToolStripMenuItem";
            this.scanTestResultToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.scanTestResultToolStripMenuItem.Text = "Scan Test Result";
            this.scanTestResultToolStripMenuItem.Click += new System.EventHandler(this.scanTestResultToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1307, 804);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Smart Worker";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSetting;
        private System.Windows.Forms.ToolStripMenuItem menuItemDatabaseConnection;
        private System.Windows.Forms.ToolStripMenuItem menuItemEmailSever;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.ToolStripMenuItem importCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCaseFromExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCaseFromEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncJiraIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FTPMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeAttachmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caseAnalysisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanStatusCrossProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanReleaseStatusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weeklyReportToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dBRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliveryProgressReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyWorkLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem githubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkCommitCommentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchCreateSubTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesforceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem dailyCaseToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testrailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem scanTestResultToolStripMenuItem;
    }
}

