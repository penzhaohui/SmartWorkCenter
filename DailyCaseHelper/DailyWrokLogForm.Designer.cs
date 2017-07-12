namespace com.smartwork
{
    partial class DailyWrokLogForm
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
            this.btnListWorkLogList = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.txtJiraKey = new System.Windows.Forms.TextBox();
            this.btnCreateSubTask = new System.Windows.Forms.Button();
            this.chkReviewAndRecreateQA = new System.Windows.Forms.CheckBox();
            this.chkReviewAndRecreateDev = new System.Windows.Forms.CheckBox();
            this.chkResearchRootCause = new System.Windows.Forms.CheckBox();
            this.chkCodeFix = new System.Windows.Forms.CheckBox();
            this.chkWriteTestCase = new System.Windows.Forms.CheckBox();
            this.chkExecuteTestCase = new System.Windows.Forms.CheckBox();
            this.chkWriteReleaseNotes = new System.Windows.Forms.CheckBox();
            this.chkReviewReleaseNotes = new System.Windows.Forms.CheckBox();
            this.txtReviewAndRecreateQASubTaskKey = new System.Windows.Forms.TextBox();
            this.txtReviewAndRecreateDevSubTaskKey = new System.Windows.Forms.TextBox();
            this.txtResearchRootCauseSubTaskKey = new System.Windows.Forms.TextBox();
            this.txtCodeFixSubTaskKey = new System.Windows.Forms.TextBox();
            this.txtWriteTestCaseSubTaskKey = new System.Windows.Forms.TextBox();
            this.txtExecuteTestCaseSubTaskKey = new System.Windows.Forms.TextBox();
            this.txtWriteReleaseNotesSubTaskKey = new System.Windows.Forms.TextBox();
            this.txtReviewReleaseNotesSubTaskKey = new System.Windows.Forms.TextBox();
            this.btnCheckJiraKey = new System.Windows.Forms.Button();
            this.btnCloseSubTask = new System.Windows.Forms.Button();
            this.txtReviewAndRecreateQAAssignee = new System.Windows.Forms.TextBox();
            this.txtReviewAndRecreateDevAssignee = new System.Windows.Forms.TextBox();
            this.txtResearchRootCauseAssignee = new System.Windows.Forms.TextBox();
            this.txtCodeFixAssignee = new System.Windows.Forms.TextBox();
            this.txtWriteTestCaseAssignee = new System.Windows.Forms.TextBox();
            this.txtExecuteTestCaseAssignee = new System.Windows.Forms.TextBox();
            this.txtWriteReleaseNotesAssignee = new System.Windows.Forms.TextBox();
            this.txtReviewReleaseNotesAssignee = new System.Windows.Forms.TextBox();
            this.txtAssigneeQA = new System.Windows.Forms.TextBox();
            this.txtAssignee = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnListWorkLogList
            // 
            this.btnListWorkLogList.Location = new System.Drawing.Point(248, 634);
            this.btnListWorkLogList.Name = "btnListWorkLogList";
            this.btnListWorkLogList.Size = new System.Drawing.Size(218, 61);
            this.btnListWorkLogList.TabIndex = 0;
            this.btnListWorkLogList.Text = "Generate and Send Work Log List";
            this.btnListWorkLogList.UseVisualStyleBackColor = true;
            this.btnListWorkLogList.Click += new System.EventHandler(this.btnListWorkLogList_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(12, 675);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(211, 20);
            this.dtpTo.TabIndex = 3;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(12, 634);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(211, 20);
            this.dtpFrom.TabIndex = 4;
            // 
            // txtJiraKey
            // 
            this.txtJiraKey.Location = new System.Drawing.Point(12, 12);
            this.txtJiraKey.Name = "txtJiraKey";
            this.txtJiraKey.Size = new System.Drawing.Size(151, 20);
            this.txtJiraKey.TabIndex = 5;
            // 
            // btnCreateSubTask
            // 
            this.btnCreateSubTask.Location = new System.Drawing.Point(347, 9);
            this.btnCreateSubTask.Name = "btnCreateSubTask";
            this.btnCreateSubTask.Size = new System.Drawing.Size(117, 23);
            this.btnCreateSubTask.TabIndex = 6;
            this.btnCreateSubTask.Text = "Create Sub Task";
            this.btnCreateSubTask.UseVisualStyleBackColor = true;
            this.btnCreateSubTask.Click += new System.EventHandler(this.btnCreateSubTask_Click);
            // 
            // chkReviewAndRecreateQA
            // 
            this.chkReviewAndRecreateQA.AutoSize = true;
            this.chkReviewAndRecreateQA.Location = new System.Drawing.Point(12, 60);
            this.chkReviewAndRecreateQA.Name = "chkReviewAndRecreateQA";
            this.chkReviewAndRecreateQA.Size = new System.Drawing.Size(151, 17);
            this.chkReviewAndRecreateQA.TabIndex = 7;
            this.chkReviewAndRecreateQA.Tag = "\"Notice: Just log QA effort for review and recreate the assicaited production cas" +
    "e\"";
            this.chkReviewAndRecreateQA.Text = "Review and Recreate(QA)";
            this.chkReviewAndRecreateQA.UseVisualStyleBackColor = true;
            // 
            // chkReviewAndRecreateDev
            // 
            this.chkReviewAndRecreateDev.AutoSize = true;
            this.chkReviewAndRecreateDev.Location = new System.Drawing.Point(12, 95);
            this.chkReviewAndRecreateDev.Name = "chkReviewAndRecreateDev";
            this.chkReviewAndRecreateDev.Size = new System.Drawing.Size(156, 17);
            this.chkReviewAndRecreateDev.TabIndex = 8;
            this.chkReviewAndRecreateDev.Text = "Review and Recreate(Dev)";
            this.chkReviewAndRecreateDev.UseVisualStyleBackColor = true;
            // 
            // chkResearchRootCause
            // 
            this.chkResearchRootCause.AutoSize = true;
            this.chkResearchRootCause.Location = new System.Drawing.Point(12, 132);
            this.chkResearchRootCause.Name = "chkResearchRootCause";
            this.chkResearchRootCause.Size = new System.Drawing.Size(131, 17);
            this.chkResearchRootCause.TabIndex = 9;
            this.chkResearchRootCause.Text = "Research Root Cause";
            this.chkResearchRootCause.UseVisualStyleBackColor = true;
            // 
            // chkCodeFix
            // 
            this.chkCodeFix.AutoSize = true;
            this.chkCodeFix.Location = new System.Drawing.Point(12, 170);
            this.chkCodeFix.Name = "chkCodeFix";
            this.chkCodeFix.Size = new System.Drawing.Size(93, 17);
            this.chkCodeFix.TabIndex = 10;
            this.chkCodeFix.Text = "Code Fix(Dev)";
            this.chkCodeFix.UseVisualStyleBackColor = true;
            // 
            // chkWriteTestCase
            // 
            this.chkWriteTestCase.AutoSize = true;
            this.chkWriteTestCase.Location = new System.Drawing.Point(12, 205);
            this.chkWriteTestCase.Name = "chkWriteTestCase";
            this.chkWriteTestCase.Size = new System.Drawing.Size(123, 17);
            this.chkWriteTestCase.TabIndex = 11;
            this.chkWriteTestCase.Text = "Write Test Case(QA)";
            this.chkWriteTestCase.UseVisualStyleBackColor = true;
            // 
            // chkExecuteTestCase
            // 
            this.chkExecuteTestCase.AutoSize = true;
            this.chkExecuteTestCase.Location = new System.Drawing.Point(12, 242);
            this.chkExecuteTestCase.Name = "chkExecuteTestCase";
            this.chkExecuteTestCase.Size = new System.Drawing.Size(137, 17);
            this.chkExecuteTestCase.TabIndex = 12;
            this.chkExecuteTestCase.Text = "Execute Test Case(QA)";
            this.chkExecuteTestCase.UseVisualStyleBackColor = true;
            // 
            // chkWriteReleaseNotes
            // 
            this.chkWriteReleaseNotes.AutoSize = true;
            this.chkWriteReleaseNotes.Location = new System.Drawing.Point(12, 275);
            this.chkWriteReleaseNotes.Name = "chkWriteReleaseNotes";
            this.chkWriteReleaseNotes.Size = new System.Drawing.Size(150, 17);
            this.chkWriteReleaseNotes.TabIndex = 13;
            this.chkWriteReleaseNotes.Text = "Write Release Notes(Dev)";
            this.chkWriteReleaseNotes.UseVisualStyleBackColor = true;
            // 
            // chkReviewReleaseNotes
            // 
            this.chkReviewReleaseNotes.AutoSize = true;
            this.chkReviewReleaseNotes.Location = new System.Drawing.Point(12, 310);
            this.chkReviewReleaseNotes.Name = "chkReviewReleaseNotes";
            this.chkReviewReleaseNotes.Size = new System.Drawing.Size(156, 17);
            this.chkReviewReleaseNotes.TabIndex = 14;
            this.chkReviewReleaseNotes.Text = "Review Release Notes(QA)";
            this.chkReviewReleaseNotes.UseVisualStyleBackColor = true;
            // 
            // txtReviewAndRecreateQASubTaskKey
            // 
            this.txtReviewAndRecreateQASubTaskKey.Location = new System.Drawing.Point(203, 57);
            this.txtReviewAndRecreateQASubTaskKey.Name = "txtReviewAndRecreateQASubTaskKey";
            this.txtReviewAndRecreateQASubTaskKey.Size = new System.Drawing.Size(100, 20);
            this.txtReviewAndRecreateQASubTaskKey.TabIndex = 15;
            // 
            // txtReviewAndRecreateDevSubTaskKey
            // 
            this.txtReviewAndRecreateDevSubTaskKey.Location = new System.Drawing.Point(203, 95);
            this.txtReviewAndRecreateDevSubTaskKey.Name = "txtReviewAndRecreateDevSubTaskKey";
            this.txtReviewAndRecreateDevSubTaskKey.Size = new System.Drawing.Size(100, 20);
            this.txtReviewAndRecreateDevSubTaskKey.TabIndex = 16;
            // 
            // txtResearchRootCauseSubTaskKey
            // 
            this.txtResearchRootCauseSubTaskKey.Location = new System.Drawing.Point(203, 132);
            this.txtResearchRootCauseSubTaskKey.Name = "txtResearchRootCauseSubTaskKey";
            this.txtResearchRootCauseSubTaskKey.Size = new System.Drawing.Size(100, 20);
            this.txtResearchRootCauseSubTaskKey.TabIndex = 17;
            // 
            // txtCodeFixSubTaskKey
            // 
            this.txtCodeFixSubTaskKey.Location = new System.Drawing.Point(203, 168);
            this.txtCodeFixSubTaskKey.Name = "txtCodeFixSubTaskKey";
            this.txtCodeFixSubTaskKey.Size = new System.Drawing.Size(100, 20);
            this.txtCodeFixSubTaskKey.TabIndex = 18;
            // 
            // txtWriteTestCaseSubTaskKey
            // 
            this.txtWriteTestCaseSubTaskKey.Location = new System.Drawing.Point(203, 204);
            this.txtWriteTestCaseSubTaskKey.Name = "txtWriteTestCaseSubTaskKey";
            this.txtWriteTestCaseSubTaskKey.Size = new System.Drawing.Size(100, 20);
            this.txtWriteTestCaseSubTaskKey.TabIndex = 19;
            // 
            // txtExecuteTestCaseSubTaskKey
            // 
            this.txtExecuteTestCaseSubTaskKey.Location = new System.Drawing.Point(203, 243);
            this.txtExecuteTestCaseSubTaskKey.Name = "txtExecuteTestCaseSubTaskKey";
            this.txtExecuteTestCaseSubTaskKey.Size = new System.Drawing.Size(100, 20);
            this.txtExecuteTestCaseSubTaskKey.TabIndex = 20;
            // 
            // txtWriteReleaseNotesSubTaskKey
            // 
            this.txtWriteReleaseNotesSubTaskKey.Location = new System.Drawing.Point(203, 273);
            this.txtWriteReleaseNotesSubTaskKey.Name = "txtWriteReleaseNotesSubTaskKey";
            this.txtWriteReleaseNotesSubTaskKey.Size = new System.Drawing.Size(100, 20);
            this.txtWriteReleaseNotesSubTaskKey.TabIndex = 21;
            // 
            // txtReviewReleaseNotesSubTaskKey
            // 
            this.txtReviewReleaseNotesSubTaskKey.Location = new System.Drawing.Point(203, 308);
            this.txtReviewReleaseNotesSubTaskKey.Name = "txtReviewReleaseNotesSubTaskKey";
            this.txtReviewReleaseNotesSubTaskKey.Size = new System.Drawing.Size(100, 20);
            this.txtReviewReleaseNotesSubTaskKey.TabIndex = 22;
            // 
            // btnCheckJiraKey
            // 
            this.btnCheckJiraKey.Location = new System.Drawing.Point(203, 9);
            this.btnCheckJiraKey.Name = "btnCheckJiraKey";
            this.btnCheckJiraKey.Size = new System.Drawing.Size(117, 23);
            this.btnCheckJiraKey.TabIndex = 23;
            this.btnCheckJiraKey.Text = "Check Jira Key";
            this.btnCheckJiraKey.UseVisualStyleBackColor = true;
            this.btnCheckJiraKey.Click += new System.EventHandler(this.btnCheckJiraKey_Click);
            // 
            // btnCloseSubTask
            // 
            this.btnCloseSubTask.Location = new System.Drawing.Point(492, 9);
            this.btnCloseSubTask.Name = "btnCloseSubTask";
            this.btnCloseSubTask.Size = new System.Drawing.Size(117, 23);
            this.btnCloseSubTask.TabIndex = 24;
            this.btnCloseSubTask.Text = "Close Sub Task";
            this.btnCloseSubTask.UseVisualStyleBackColor = true;
            this.btnCloseSubTask.Click += new System.EventHandler(this.btnCloseSubTask_Click);
            // 
            // txtReviewAndRecreateQAAssignee
            // 
            this.txtReviewAndRecreateQAAssignee.Location = new System.Drawing.Point(347, 58);
            this.txtReviewAndRecreateQAAssignee.Name = "txtReviewAndRecreateQAAssignee";
            this.txtReviewAndRecreateQAAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtReviewAndRecreateQAAssignee.TabIndex = 25;
            // 
            // txtReviewAndRecreateDevAssignee
            // 
            this.txtReviewAndRecreateDevAssignee.Location = new System.Drawing.Point(347, 94);
            this.txtReviewAndRecreateDevAssignee.Name = "txtReviewAndRecreateDevAssignee";
            this.txtReviewAndRecreateDevAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtReviewAndRecreateDevAssignee.TabIndex = 26;
            // 
            // txtResearchRootCauseAssignee
            // 
            this.txtResearchRootCauseAssignee.Location = new System.Drawing.Point(347, 130);
            this.txtResearchRootCauseAssignee.Name = "txtResearchRootCauseAssignee";
            this.txtResearchRootCauseAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtResearchRootCauseAssignee.TabIndex = 27;
            // 
            // txtCodeFixAssignee
            // 
            this.txtCodeFixAssignee.Location = new System.Drawing.Point(347, 168);
            this.txtCodeFixAssignee.Name = "txtCodeFixAssignee";
            this.txtCodeFixAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtCodeFixAssignee.TabIndex = 28;
            // 
            // txtWriteTestCaseAssignee
            // 
            this.txtWriteTestCaseAssignee.Location = new System.Drawing.Point(347, 203);
            this.txtWriteTestCaseAssignee.Name = "txtWriteTestCaseAssignee";
            this.txtWriteTestCaseAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtWriteTestCaseAssignee.TabIndex = 29;
            // 
            // txtExecuteTestCaseAssignee
            // 
            this.txtExecuteTestCaseAssignee.Location = new System.Drawing.Point(347, 240);
            this.txtExecuteTestCaseAssignee.Name = "txtExecuteTestCaseAssignee";
            this.txtExecuteTestCaseAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtExecuteTestCaseAssignee.TabIndex = 30;
            // 
            // txtWriteReleaseNotesAssignee
            // 
            this.txtWriteReleaseNotesAssignee.Location = new System.Drawing.Point(347, 273);
            this.txtWriteReleaseNotesAssignee.Name = "txtWriteReleaseNotesAssignee";
            this.txtWriteReleaseNotesAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtWriteReleaseNotesAssignee.TabIndex = 31;
            // 
            // txtReviewReleaseNotesAssignee
            // 
            this.txtReviewReleaseNotesAssignee.Location = new System.Drawing.Point(347, 309);
            this.txtReviewReleaseNotesAssignee.Name = "txtReviewReleaseNotesAssignee";
            this.txtReviewReleaseNotesAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtReviewReleaseNotesAssignee.TabIndex = 32;
            // 
            // txtAssigneeQA
            // 
            this.txtAssigneeQA.Location = new System.Drawing.Point(492, 95);
            this.txtAssigneeQA.Name = "txtAssigneeQA";
            this.txtAssigneeQA.Size = new System.Drawing.Size(100, 20);
            this.txtAssigneeQA.TabIndex = 33;
            // 
            // txtAssignee
            // 
            this.txtAssignee.Location = new System.Drawing.Point(492, 58);
            this.txtAssignee.Name = "txtAssignee";
            this.txtAssignee.Size = new System.Drawing.Size(100, 20);
            this.txtAssignee.TabIndex = 34;
            // 
            // DailyWrokLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 726);
            this.Controls.Add(this.txtAssignee);
            this.Controls.Add(this.txtAssigneeQA);
            this.Controls.Add(this.txtReviewReleaseNotesAssignee);
            this.Controls.Add(this.txtWriteReleaseNotesAssignee);
            this.Controls.Add(this.txtExecuteTestCaseAssignee);
            this.Controls.Add(this.txtWriteTestCaseAssignee);
            this.Controls.Add(this.txtCodeFixAssignee);
            this.Controls.Add(this.txtResearchRootCauseAssignee);
            this.Controls.Add(this.txtReviewAndRecreateDevAssignee);
            this.Controls.Add(this.txtReviewAndRecreateQAAssignee);
            this.Controls.Add(this.btnCloseSubTask);
            this.Controls.Add(this.btnCheckJiraKey);
            this.Controls.Add(this.txtReviewReleaseNotesSubTaskKey);
            this.Controls.Add(this.txtWriteReleaseNotesSubTaskKey);
            this.Controls.Add(this.txtExecuteTestCaseSubTaskKey);
            this.Controls.Add(this.txtWriteTestCaseSubTaskKey);
            this.Controls.Add(this.txtCodeFixSubTaskKey);
            this.Controls.Add(this.txtResearchRootCauseSubTaskKey);
            this.Controls.Add(this.txtReviewAndRecreateDevSubTaskKey);
            this.Controls.Add(this.txtReviewAndRecreateQASubTaskKey);
            this.Controls.Add(this.chkReviewReleaseNotes);
            this.Controls.Add(this.chkWriteReleaseNotes);
            this.Controls.Add(this.chkExecuteTestCase);
            this.Controls.Add(this.chkWriteTestCase);
            this.Controls.Add(this.chkCodeFix);
            this.Controls.Add(this.chkResearchRootCause);
            this.Controls.Add(this.chkReviewAndRecreateDev);
            this.Controls.Add(this.chkReviewAndRecreateQA);
            this.Controls.Add(this.btnCreateSubTask);
            this.Controls.Add(this.txtJiraKey);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.btnListWorkLogList);
            this.Name = "DailyWrokLogForm";
            this.Text = "Daily Wrok Log Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnListWorkLogList;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.TextBox txtJiraKey;
        private System.Windows.Forms.Button btnCreateSubTask;
        private System.Windows.Forms.CheckBox chkReviewAndRecreateQA;
        private System.Windows.Forms.CheckBox chkReviewAndRecreateDev;
        private System.Windows.Forms.CheckBox chkResearchRootCause;
        private System.Windows.Forms.CheckBox chkCodeFix;
        private System.Windows.Forms.CheckBox chkWriteTestCase;
        private System.Windows.Forms.CheckBox chkExecuteTestCase;
        private System.Windows.Forms.CheckBox chkWriteReleaseNotes;
        private System.Windows.Forms.CheckBox chkReviewReleaseNotes;
        private System.Windows.Forms.TextBox txtReviewAndRecreateQASubTaskKey;
        private System.Windows.Forms.TextBox txtReviewAndRecreateDevSubTaskKey;
        private System.Windows.Forms.TextBox txtResearchRootCauseSubTaskKey;
        private System.Windows.Forms.TextBox txtCodeFixSubTaskKey;
        private System.Windows.Forms.TextBox txtWriteTestCaseSubTaskKey;
        private System.Windows.Forms.TextBox txtExecuteTestCaseSubTaskKey;
        private System.Windows.Forms.TextBox txtWriteReleaseNotesSubTaskKey;
        private System.Windows.Forms.TextBox txtReviewReleaseNotesSubTaskKey;
        private System.Windows.Forms.Button btnCheckJiraKey;
        private System.Windows.Forms.Button btnCloseSubTask;
        private System.Windows.Forms.TextBox txtReviewAndRecreateQAAssignee;
        private System.Windows.Forms.TextBox txtReviewAndRecreateDevAssignee;
        private System.Windows.Forms.TextBox txtResearchRootCauseAssignee;
        private System.Windows.Forms.TextBox txtCodeFixAssignee;
        private System.Windows.Forms.TextBox txtWriteTestCaseAssignee;
        private System.Windows.Forms.TextBox txtExecuteTestCaseAssignee;
        private System.Windows.Forms.TextBox txtWriteReleaseNotesAssignee;
        private System.Windows.Forms.TextBox txtReviewReleaseNotesAssignee;
        private System.Windows.Forms.TextBox txtAssigneeQA;
        private System.Windows.Forms.TextBox txtAssignee;
    }
}