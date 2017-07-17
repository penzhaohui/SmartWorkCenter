using SimpleConsole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using com.smartwork.Business;
using com.smartwork.Model;
using com.smartwork.Proxy;

namespace com.smartwork
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            DailyCaseImportorFromSalesforce dailyCaseImportorFromSalesforce = new DailyCaseImportorFromSalesforce();
            dailyCaseImportorFromSalesforce.WindowState = FormWindowState.Maximized;
            dailyCaseImportorFromSalesforce.MdiParent = this;
            dailyCaseImportorFromSalesforce.MaximizeBox = false;
            dailyCaseImportorFromSalesforce.MinimizeBox = false;
            dailyCaseImportorFromSalesforce.Show();
        }

        public void ShowStatusMessage(string message)
        {
            this.statusMessage.Text = message;
        }

        /// <summary>
        /// Update today case list
        /// </summary>
        private void btnUpdateTodayCaseList_Click(object sender, EventArgs e)
        {
            // 1, Construct one case list with valid reviwer
            // 2, Update case in 2 scenarios
            // 2.1 Just update case if the case is updated "TODAY"
            // 2.2 Add case if the case is not updated "TODAY"
        }

        /// <summary>
        /// Send one email template
        /// </summary>
        private void btnSendTodayCaseList_Click(object sender, EventArgs e)
        {
            // 1, Get email information
            //    1) Send email address
            //    2) To email address
            //    3) Subject
            //    4) Email Template

            // 2, Generate email content
            // 2.1 Construct case list
            // 2.2 Generate email content

            // 3, Send email

            // 4, Show "Success" or "Failed" message on status bar
        }

        private void menuItemDatabaseConnection_Click(object sender, EventArgs e)
        {
            DBSettingForm dbSettingForm = new DBSettingForm();
            //dbSettingForm.WindowState = FormWindowState.Maximized;
            //dbSettingForm.MdiParent = this;
            //dbSettingForm.Show();
            dbSettingForm.ShowDialog();
        }

        private void menuItemEmailSever_Click(object sender, EventArgs e)
        {
            EmailSettingForm emailSettingForm = new EmailSettingForm();
            //emailSettingForm.WindowState = FormWindowState.Maximized;
            //emailSettingForm.MdiParent = this;
            //emailSettingForm.Show();
            emailSettingForm.ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void importCaseFromExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyCaseImportorFromExcel dailyCaseImportorFromExcel = new DailyCaseImportorFromExcel();
            dailyCaseImportorFromExcel.WindowState = FormWindowState.Maximized;
            dailyCaseImportorFromExcel.MdiParent = this;
            dailyCaseImportorFromExcel.MaximizeBox = false;
            dailyCaseImportorFromExcel.MinimizeBox = false;
            dailyCaseImportorFromExcel.Show();
        }

        private void importCaseFromEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            DailyCaseImportorFromEmail dailyCaseImportorFromEmail = new DailyCaseImportorFromEmail();
            dailyCaseImportorFromEmail.WindowState = FormWindowState.Maximized;
            dailyCaseImportorFromEmail.MdiParent = this;
            dailyCaseImportorFromEmail.MaximizeBox = false;
            dailyCaseImportorFromEmail.MinimizeBox = false;
            dailyCaseImportorFromEmail.Show();
        }

        private void AADevCheckerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            AADevEnvChecker aaDevEnvChecker = new AADevEnvChecker();
            aaDevEnvChecker.WindowState = FormWindowState.Maximized;
            aaDevEnvChecker.MdiParent = this;
            aaDevEnvChecker.MaximizeBox = false;
            aaDevEnvChecker.MinimizeBox = false;            
            aaDevEnvChecker.Show();
        }

        private void FTPMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            FTPMonitor ftpMonitor = new FTPMonitor();
            ftpMonitor.WindowState = FormWindowState.Maximized;
            ftpMonitor.MdiParent = this;
            ftpMonitor.MaximizeBox = false;
            ftpMonitor.MinimizeBox = false;
            ftpMonitor.Show();
        }

        private void syncJiraIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            UpdateMyJIRAIssueFromSalesforce updateMyJIRAIssueFromSalesforce = new UpdateMyJIRAIssueFromSalesforce();
            updateMyJIRAIssueFromSalesforce.WindowState = FormWindowState.Maximized;
            updateMyJIRAIssueFromSalesforce.MdiParent = this;
            updateMyJIRAIssueFromSalesforce.MaximizeBox = false;
            updateMyJIRAIssueFromSalesforce.MinimizeBox = false;
            updateMyJIRAIssueFromSalesforce.Show();
        }

        private void CloseAllChildForm()
        {
            foreach (Form child in this.MdiChildren)
            {
                child.Close();
                child.Dispose();
            }
        }

        private void dailyCaseToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            DailyCaseImportorFromSalesforce dailyCaseImportorFromSalesforce = new DailyCaseImportorFromSalesforce();
            dailyCaseImportorFromSalesforce.WindowState = FormWindowState.Maximized;
            dailyCaseImportorFromSalesforce.MdiParent = this;
            dailyCaseImportorFromSalesforce.MaximizeBox = false;
            dailyCaseImportorFromSalesforce.MinimizeBox = false;
            dailyCaseImportorFromSalesforce.Show();
        }

        private void dbManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            DBManager dbManager = new DBManager();
            dbManager.WindowState = FormWindowState.Maximized;
            dbManager.MdiParent = this;
            dbManager.MaximizeBox = false;
            dbManager.MinimizeBox = false;
            dbManager.Show();
        }

        private void mergeAttachmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            MergeAttchmentFromSalesforce mergeAttachment = new MergeAttchmentFromSalesforce();
            mergeAttachment.WindowState = FormWindowState.Maximized;
            mergeAttachment.MdiParent = this;
            mergeAttachment.MaximizeBox = false;
            mergeAttachment.MinimizeBox = false;
            mergeAttachment.Show();
        }

        private void caseAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            CaseAnalysisReportForm caseAnalysis = new CaseAnalysisReportForm();
            caseAnalysis.WindowState = FormWindowState.Maximized;
            caseAnalysis.MdiParent = this;
            caseAnalysis.MaximizeBox = false;
            caseAnalysis.MinimizeBox = false;
            caseAnalysis.Show();
        }

        private void scanStatusCrossProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            SyncCaseStatusCrossProject syncCaseStatusCrossProject = new SyncCaseStatusCrossProject();
            syncCaseStatusCrossProject.WindowState = FormWindowState.Maximized;
            syncCaseStatusCrossProject.MdiParent = this;
            syncCaseStatusCrossProject.MaximizeBox = false;
            syncCaseStatusCrossProject.MinimizeBox = false;
            syncCaseStatusCrossProject.Show();
        }

        private void scanReleaseStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            ScanReleaseStatusFomSalesforce scanReleaseStatusFomSalesforce = new ScanReleaseStatusFomSalesforce();
            scanReleaseStatusFomSalesforce.WindowState = FormWindowState.Maximized;
            scanReleaseStatusFomSalesforce.MdiParent = this;
            scanReleaseStatusFomSalesforce.MaximizeBox = false;
            scanReleaseStatusFomSalesforce.MinimizeBox = false;
            scanReleaseStatusFomSalesforce.Show();
        }

        private void weeklyReportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            frmWeeklyReportForm weeklyReportForm = new frmWeeklyReportForm();
            weeklyReportForm.WindowState = FormWindowState.Maximized;
            weeklyReportForm.MdiParent = this;
            weeklyReportForm.MaximizeBox = false;
            weeklyReportForm.MinimizeBox = false;
            weeklyReportForm.Show();
        }

        private void dBRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            DBRequestForm dbRequestForm = new DBRequestForm();
            dbRequestForm.WindowState = FormWindowState.Maximized;
            dbRequestForm.MdiParent = this;
            dbRequestForm.MaximizeBox = false;
            dbRequestForm.MinimizeBox = false;
            dbRequestForm.Show();
        }

        private void deliveryProgressReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            DeliveryProgressReportForm deliveryProgressReport = new DeliveryProgressReportForm();
            deliveryProgressReport.WindowState = FormWindowState.Maximized;
            deliveryProgressReport.MdiParent = this;
            deliveryProgressReport.MaximizeBox = false;
            deliveryProgressReport.MinimizeBox = false;
            deliveryProgressReport.Show();
        }

        private void dailyWorkLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            DailyWrokLogForm dailyWrokLogForm = new DailyWrokLogForm();
            dailyWrokLogForm.WindowState = FormWindowState.Maximized;
            dailyWrokLogForm.MdiParent = this;
            dailyWrokLogForm.MaximizeBox = false;
            dailyWrokLogForm.MinimizeBox = false;
            dailyWrokLogForm.Show();
        }

        private void checkCommitCommentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            CheckCommitCommentsOnGithubForm checkCommitCommentsOnGithubForm = new CheckCommitCommentsOnGithubForm();
            checkCommitCommentsOnGithubForm.WindowState = FormWindowState.Maximized;
            checkCommitCommentsOnGithubForm.MdiParent = this;
            checkCommitCommentsOnGithubForm.MaximizeBox = false;
            checkCommitCommentsOnGithubForm.MinimizeBox = false;
            checkCommitCommentsOnGithubForm.Show();
        }

        private void batchCreateSubTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllChildForm();
            BatchSubTaskManagementForm batchSubTaskManagementForm = new BatchSubTaskManagementForm();
            batchSubTaskManagementForm.WindowState = FormWindowState.Maximized;
            batchSubTaskManagementForm.MdiParent = this;
            batchSubTaskManagementForm.MaximizeBox = false;
            batchSubTaskManagementForm.MinimizeBox = false;
            batchSubTaskManagementForm.Show();
        }
    }
}
