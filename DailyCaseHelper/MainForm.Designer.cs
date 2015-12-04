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
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weeklyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personlyReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AADevCheckerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syncJiraIssueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyCaseToolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FTPMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dbManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetting,
            this.reportToolStripMenuItem,
            this.toolsToolStripMenuItem,
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
            this.menuItemDatabaseConnection.Size = new System.Drawing.Size(143, 22);
            this.menuItemDatabaseConnection.Text = "Database";
            this.menuItemDatabaseConnection.Click += new System.EventHandler(this.menuItemDatabaseConnection_Click);
            // 
            // menuItemEmailSever
            // 
            this.menuItemEmailSever.Name = "menuItemEmailSever";
            this.menuItemEmailSever.Size = new System.Drawing.Size(143, 22);
            this.menuItemEmailSever.Text = "Email Setting";
            this.menuItemEmailSever.Click += new System.EventHandler(this.menuItemEmailSever_Click);
            // 
            // importCaseToolStripMenuItem
            // 
            this.importCaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importCaseFromExcelToolStripMenuItem,
            this.importCaseFromEmailToolStripMenuItem});
            this.importCaseToolStripMenuItem.Name = "importCaseToolStripMenuItem";
            this.importCaseToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
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
            this.menuItemExit.Size = new System.Drawing.Size(143, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyReportToolStripMenuItem,
            this.weeklyReportToolStripMenuItem,
            this.monthlyReportToolStripMenuItem,
            this.personlyReportToolStripMenuItem,
            this.productReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // dailyReportToolStripMenuItem
            // 
            this.dailyReportToolStripMenuItem.Name = "dailyReportToolStripMenuItem";
            this.dailyReportToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.dailyReportToolStripMenuItem.Text = "Daily Report";
            // 
            // weeklyReportToolStripMenuItem
            // 
            this.weeklyReportToolStripMenuItem.Name = "weeklyReportToolStripMenuItem";
            this.weeklyReportToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.weeklyReportToolStripMenuItem.Text = "Weekly Report";
            // 
            // monthlyReportToolStripMenuItem
            // 
            this.monthlyReportToolStripMenuItem.Name = "monthlyReportToolStripMenuItem";
            this.monthlyReportToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.monthlyReportToolStripMenuItem.Text = "Monthly Report";
            // 
            // personlyReportToolStripMenuItem
            // 
            this.personlyReportToolStripMenuItem.Name = "personlyReportToolStripMenuItem";
            this.personlyReportToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.personlyReportToolStripMenuItem.Text = "Individual  Report";
            // 
            // productReportToolStripMenuItem
            // 
            this.productReportToolStripMenuItem.Name = "productReportToolStripMenuItem";
            this.productReportToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.productReportToolStripMenuItem.Text = "Product Report";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AADevCheckerToolStripMenuItem,
            this.syncJiraIssueToolStripMenuItem,
            this.dailyCaseToolToolStripMenuItem,
            this.FTPMonitorToolStripMenuItem,
            this.dbManagerToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // AADevCheckerToolStripMenuItem
            // 
            this.AADevCheckerToolStripMenuItem.Name = "AADevCheckerToolStripMenuItem";
            this.AADevCheckerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.AADevCheckerToolStripMenuItem.Text = "AA Dev";
            this.AADevCheckerToolStripMenuItem.Click += new System.EventHandler(this.AADevCheckerToolStripMenuItem_Click);
            // 
            // syncJiraIssueToolStripMenuItem
            // 
            this.syncJiraIssueToolStripMenuItem.Name = "syncJiraIssueToolStripMenuItem";
            this.syncJiraIssueToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.syncJiraIssueToolStripMenuItem.Text = "Sync JIRA Issue";
            this.syncJiraIssueToolStripMenuItem.Click += new System.EventHandler(this.syncJiraIssueToolStripMenuItem_Click);
            // 
            // dailyCaseToolToolStripMenuItem
            // 
            this.dailyCaseToolToolStripMenuItem.Name = "dailyCaseToolToolStripMenuItem";
            this.dailyCaseToolToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dailyCaseToolToolStripMenuItem.Text = "Daily Case Tool";
            this.dailyCaseToolToolStripMenuItem.Click += new System.EventHandler(this.dailyCaseToolToolStripMenuItem_Click);
            // 
            // FTPMonitorToolStripMenuItem
            // 
            this.FTPMonitorToolStripMenuItem.Name = "FTPMonitorToolStripMenuItem";
            this.FTPMonitorToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.FTPMonitorToolStripMenuItem.Text = "FTP Monitor";
            this.FTPMonitorToolStripMenuItem.Click += new System.EventHandler(this.FTPMonitorToolStripMenuItem_Click);
            // 
            // dbManagerToolStripMenuItem
            // 
            this.dbManagerToolStripMenuItem.Name = "dbManagerToolStripMenuItem";
            this.dbManagerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.dbManagerToolStripMenuItem.Text = "DB Manager";
            this.dbManagerToolStripMenuItem.Click += new System.EventHandler(this.dbManagerToolStripMenuItem_Click);
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
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weeklyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem personlyReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.ToolStripMenuItem importCaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCaseFromExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importCaseFromEmailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AADevCheckerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem syncJiraIssueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyCaseToolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FTPMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dbManagerToolStripMenuItem;
    }
}

