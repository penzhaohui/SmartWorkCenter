namespace com.smartwork
{
    partial class EmailSettingForm
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
            this.txtHost = new System.Windows.Forms.TextBox();
            this.tabEmailSetting = new System.Windows.Forms.TabControl();
            this.tabEmailServer = new System.Windows.Forms.TabPage();
            this.txtDefaultToReceiver = new System.Windows.Forms.TextBox();
            this.lblDefaultToReceiver = new System.Windows.Forms.Label();
            this.txtDefaultCCReceiver = new System.Windows.Forms.TextBox();
            this.lblDefaultCCReceiver = new System.Windows.Forms.Label();
            this.txtDefaultSender = new System.Windows.Forms.TextBox();
            this.lblDefaultSender = new System.Windows.Forms.Label();
            this.chkAuth = new System.Windows.Forms.CheckBox();
            this.btnUpdateEmailServerSetting = new System.Windows.Forms.Button();
            this.btnTestEmailServer = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblAuth = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblHost = new System.Windows.Forms.Label();
            this.tabDailyCaseEmailTemplate = new System.Windows.Forms.TabPage();
            this.btnUpdateDailyCaseEmailTemplate = new System.Windows.Forms.Button();
            this.txtDailyEmailContent = new System.Windows.Forms.TextBox();
            this.txtDailyEmailSubject = new System.Windows.Forms.TextBox();
            this.txtDailyEmailTo = new System.Windows.Forms.TextBox();
            this.txtDailyEmailFrom = new System.Windows.Forms.TextBox();
            this.lblDailyEmailContent = new System.Windows.Forms.Label();
            this.lblDailyEmailSubject = new System.Windows.Forms.Label();
            this.lblDailyEmailTo = new System.Windows.Forms.Label();
            this.lblDailyEmailFrom = new System.Windows.Forms.Label();
            this.txtDailyEmailCC = new System.Windows.Forms.TextBox();
            this.lblDailyEmailCC = new System.Windows.Forms.Label();
            this.tabEmailSetting.SuspendLayout();
            this.tabEmailServer.SuspendLayout();
            this.tabDailyCaseEmailTemplate.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(9, 34);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(175, 20);
            this.txtHost.TabIndex = 0;
            this.txtHost.Text = "smtp.exmail.qq.com";
            // 
            // tabEmailSetting
            // 
            this.tabEmailSetting.Controls.Add(this.tabEmailServer);
            this.tabEmailSetting.Controls.Add(this.tabDailyCaseEmailTemplate);
            this.tabEmailSetting.Location = new System.Drawing.Point(12, 12);
            this.tabEmailSetting.Name = "tabEmailSetting";
            this.tabEmailSetting.SelectedIndex = 0;
            this.tabEmailSetting.Size = new System.Drawing.Size(545, 418);
            this.tabEmailSetting.TabIndex = 10;
            // 
            // tabEmailServer
            // 
            this.tabEmailServer.Controls.Add(this.txtDefaultToReceiver);
            this.tabEmailServer.Controls.Add(this.lblDefaultToReceiver);
            this.tabEmailServer.Controls.Add(this.txtDefaultCCReceiver);
            this.tabEmailServer.Controls.Add(this.lblDefaultCCReceiver);
            this.tabEmailServer.Controls.Add(this.txtDefaultSender);
            this.tabEmailServer.Controls.Add(this.lblDefaultSender);
            this.tabEmailServer.Controls.Add(this.chkAuth);
            this.tabEmailServer.Controls.Add(this.btnUpdateEmailServerSetting);
            this.tabEmailServer.Controls.Add(this.btnTestEmailServer);
            this.tabEmailServer.Controls.Add(this.txtPassword);
            this.tabEmailServer.Controls.Add(this.txtUser);
            this.tabEmailServer.Controls.Add(this.txtPort);
            this.tabEmailServer.Controls.Add(this.lblPassword);
            this.tabEmailServer.Controls.Add(this.lblUser);
            this.tabEmailServer.Controls.Add(this.lblAuth);
            this.tabEmailServer.Controls.Add(this.lblPort);
            this.tabEmailServer.Controls.Add(this.lblHost);
            this.tabEmailServer.Controls.Add(this.txtHost);
            this.tabEmailServer.Location = new System.Drawing.Point(4, 22);
            this.tabEmailServer.Name = "tabEmailServer";
            this.tabEmailServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmailServer.Size = new System.Drawing.Size(537, 392);
            this.tabEmailServer.TabIndex = 0;
            this.tabEmailServer.Text = "Email Server";
            this.tabEmailServer.UseVisualStyleBackColor = true;
            // 
            // txtDefaultToReceiver
            // 
            this.txtDefaultToReceiver.Location = new System.Drawing.Point(9, 213);
            this.txtDefaultToReceiver.Name = "txtDefaultToReceiver";
            this.txtDefaultToReceiver.Size = new System.Drawing.Size(175, 20);
            this.txtDefaultToReceiver.TabIndex = 22;
            this.txtDefaultToReceiver.Text = "peter.peng@missionsky.com";
            // 
            // lblDefaultToReceiver
            // 
            this.lblDefaultToReceiver.AutoSize = true;
            this.lblDefaultToReceiver.Location = new System.Drawing.Point(6, 197);
            this.lblDefaultToReceiver.Name = "lblDefaultToReceiver";
            this.lblDefaultToReceiver.Size = new System.Drawing.Size(60, 13);
            this.lblDefaultToReceiver.TabIndex = 21;
            this.lblDefaultToReceiver.Text = "Default To:";
            // 
            // txtDefaultCCReceiver
            // 
            this.txtDefaultCCReceiver.Location = new System.Drawing.Point(9, 268);
            this.txtDefaultCCReceiver.Name = "txtDefaultCCReceiver";
            this.txtDefaultCCReceiver.Size = new System.Drawing.Size(175, 20);
            this.txtDefaultCCReceiver.TabIndex = 20;
            this.txtDefaultCCReceiver.Text = "peter.peng@missionsky.com";
            // 
            // lblDefaultCCReceiver
            // 
            this.lblDefaultCCReceiver.AutoSize = true;
            this.lblDefaultCCReceiver.Location = new System.Drawing.Point(6, 252);
            this.lblDefaultCCReceiver.Name = "lblDefaultCCReceiver";
            this.lblDefaultCCReceiver.Size = new System.Drawing.Size(61, 13);
            this.lblDefaultCCReceiver.TabIndex = 19;
            this.lblDefaultCCReceiver.Text = "Default CC:";
            // 
            // txtDefaultSender
            // 
            this.txtDefaultSender.Location = new System.Drawing.Point(9, 163);
            this.txtDefaultSender.Name = "txtDefaultSender";
            this.txtDefaultSender.Size = new System.Drawing.Size(175, 20);
            this.txtDefaultSender.TabIndex = 18;
            this.txtDefaultSender.Text = "auto_sender@missionsky.com";
            // 
            // lblDefaultSender
            // 
            this.lblDefaultSender.AutoSize = true;
            this.lblDefaultSender.Location = new System.Drawing.Point(6, 147);
            this.lblDefaultSender.Name = "lblDefaultSender";
            this.lblDefaultSender.Size = new System.Drawing.Size(81, 13);
            this.lblDefaultSender.TabIndex = 17;
            this.lblDefaultSender.Text = "Default Sender:";
            // 
            // chkAuth
            // 
            this.chkAuth.AutoSize = true;
            this.chkAuth.Checked = true;
            this.chkAuth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuth.Location = new System.Drawing.Point(44, 68);
            this.chkAuth.Name = "chkAuth";
            this.chkAuth.Size = new System.Drawing.Size(15, 14);
            this.chkAuth.TabIndex = 16;
            this.chkAuth.UseVisualStyleBackColor = true;
            // 
            // btnUpdateEmailServerSetting
            // 
            this.btnUpdateEmailServerSetting.Location = new System.Drawing.Point(437, 64);
            this.btnUpdateEmailServerSetting.Name = "btnUpdateEmailServerSetting";
            this.btnUpdateEmailServerSetting.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateEmailServerSetting.TabIndex = 15;
            this.btnUpdateEmailServerSetting.Text = "Update";
            this.btnUpdateEmailServerSetting.UseVisualStyleBackColor = true;
            this.btnUpdateEmailServerSetting.Click += new System.EventHandler(this.btnUpdateEmailServerSetting_Click);
            // 
            // btnTestEmailServer
            // 
            this.btnTestEmailServer.Location = new System.Drawing.Point(437, 31);
            this.btnTestEmailServer.Name = "btnTestEmailServer";
            this.btnTestEmailServer.Size = new System.Drawing.Size(75, 23);
            this.btnTestEmailServer.TabIndex = 14;
            this.btnTestEmailServer.Text = "Test";
            this.btnTestEmailServer.UseVisualStyleBackColor = true;
            this.btnTestEmailServer.Click += new System.EventHandler(this.btnTestEmailServer_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(190, 110);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(175, 20);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.Text = "Ms123456!";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(9, 110);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(175, 20);
            this.txtUser.TabIndex = 12;
            this.txtUser.Text = "auto_sender@missionsky.com";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(190, 34);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(52, 20);
            this.txtPort.TabIndex = 11;
            this.txtPort.Text = "25";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(187, 94);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 10;
            this.lblPassword.Text = "Password:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(6, 94);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 9;
            this.lblUser.Text = "User:";
            // 
            // lblAuth
            // 
            this.lblAuth.AutoSize = true;
            this.lblAuth.Location = new System.Drawing.Point(6, 69);
            this.lblAuth.Name = "lblAuth";
            this.lblAuth.Size = new System.Drawing.Size(32, 13);
            this.lblAuth.TabIndex = 4;
            this.lblAuth.Text = "Auth:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(187, 18);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 3;
            this.lblPort.Text = "Port:";
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(6, 18);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 13);
            this.lblHost.TabIndex = 2;
            this.lblHost.Text = "Host:";
            // 
            // tabDailyCaseEmailTemplate
            // 
            this.tabDailyCaseEmailTemplate.Controls.Add(this.lblDailyEmailCC);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.txtDailyEmailCC);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.btnUpdateDailyCaseEmailTemplate);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.txtDailyEmailContent);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.txtDailyEmailSubject);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.txtDailyEmailTo);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.txtDailyEmailFrom);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.lblDailyEmailContent);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.lblDailyEmailSubject);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.lblDailyEmailTo);
            this.tabDailyCaseEmailTemplate.Controls.Add(this.lblDailyEmailFrom);
            this.tabDailyCaseEmailTemplate.Location = new System.Drawing.Point(4, 22);
            this.tabDailyCaseEmailTemplate.Name = "tabDailyCaseEmailTemplate";
            this.tabDailyCaseEmailTemplate.Padding = new System.Windows.Forms.Padding(3);
            this.tabDailyCaseEmailTemplate.Size = new System.Drawing.Size(537, 392);
            this.tabDailyCaseEmailTemplate.TabIndex = 1;
            this.tabDailyCaseEmailTemplate.Text = "Daily Case Email Template";
            this.tabDailyCaseEmailTemplate.UseVisualStyleBackColor = true;
            // 
            // btnUpdateDailyCaseEmailTemplate
            // 
            this.btnUpdateDailyCaseEmailTemplate.Location = new System.Drawing.Point(438, 13);
            this.btnUpdateDailyCaseEmailTemplate.Name = "btnUpdateDailyCaseEmailTemplate";
            this.btnUpdateDailyCaseEmailTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDailyCaseEmailTemplate.TabIndex = 13;
            this.btnUpdateDailyCaseEmailTemplate.Text = "Update";
            this.btnUpdateDailyCaseEmailTemplate.UseVisualStyleBackColor = true;
            this.btnUpdateDailyCaseEmailTemplate.Click += new System.EventHandler(this.btnUpdateDailyCaseEmailTemplate_Click);
            // 
            // txtDailyEmailContent
            // 
            this.txtDailyEmailContent.Location = new System.Drawing.Point(16, 164);
            this.txtDailyEmailContent.Multiline = true;
            this.txtDailyEmailContent.Name = "txtDailyEmailContent";
            this.txtDailyEmailContent.Size = new System.Drawing.Size(497, 209);
            this.txtDailyEmailContent.TabIndex = 12;
            this.txtDailyEmailContent.Text = "Hi All,\r\n\r\nBelow is the production case list from Accela, please review it on the" +
    " high priority.\r\n\r\n$ProductCaseTable$\r\n\r\nBest Regards,\r\nPeter";
            // 
            // txtDailyEmailSubject
            // 
            this.txtDailyEmailSubject.Location = new System.Drawing.Point(16, 115);
            this.txtDailyEmailSubject.Name = "txtDailyEmailSubject";
            this.txtDailyEmailSubject.Size = new System.Drawing.Size(497, 20);
            this.txtDailyEmailSubject.TabIndex = 11;
            this.txtDailyEmailSubject.Text = "Today Production Case List from Accela";
            // 
            // txtDailyEmailTo
            // 
            this.txtDailyEmailTo.Location = new System.Drawing.Point(16, 72);
            this.txtDailyEmailTo.Name = "txtDailyEmailTo";
            this.txtDailyEmailTo.Size = new System.Drawing.Size(175, 20);
            this.txtDailyEmailTo.TabIndex = 10;
            this.txtDailyEmailTo.Text = "peter.peng@missionsky.com";
            // 
            // txtDailyEmailFrom
            // 
            this.txtDailyEmailFrom.Location = new System.Drawing.Point(16, 29);
            this.txtDailyEmailFrom.Name = "txtDailyEmailFrom";
            this.txtDailyEmailFrom.Size = new System.Drawing.Size(175, 20);
            this.txtDailyEmailFrom.TabIndex = 9;
            this.txtDailyEmailFrom.Text = "auto_sender@missionsky.com";
            // 
            // lblDailyEmailContent
            // 
            this.lblDailyEmailContent.AutoSize = true;
            this.lblDailyEmailContent.Location = new System.Drawing.Point(13, 148);
            this.lblDailyEmailContent.Name = "lblDailyEmailContent";
            this.lblDailyEmailContent.Size = new System.Drawing.Size(94, 13);
            this.lblDailyEmailContent.TabIndex = 8;
            this.lblDailyEmailContent.Text = "Content Template:";
            // 
            // lblDailyEmailSubject
            // 
            this.lblDailyEmailSubject.AutoSize = true;
            this.lblDailyEmailSubject.Location = new System.Drawing.Point(13, 102);
            this.lblDailyEmailSubject.Name = "lblDailyEmailSubject";
            this.lblDailyEmailSubject.Size = new System.Drawing.Size(46, 13);
            this.lblDailyEmailSubject.TabIndex = 7;
            this.lblDailyEmailSubject.Text = "Subject:";
            // 
            // lblDailyEmailTo
            // 
            this.lblDailyEmailTo.AutoSize = true;
            this.lblDailyEmailTo.Location = new System.Drawing.Point(13, 57);
            this.lblDailyEmailTo.Name = "lblDailyEmailTo";
            this.lblDailyEmailTo.Size = new System.Drawing.Size(23, 13);
            this.lblDailyEmailTo.TabIndex = 6;
            this.lblDailyEmailTo.Text = "To:";
            // 
            // lblDailyEmailFrom
            // 
            this.lblDailyEmailFrom.AutoSize = true;
            this.lblDailyEmailFrom.Location = new System.Drawing.Point(13, 13);
            this.lblDailyEmailFrom.Name = "lblDailyEmailFrom";
            this.lblDailyEmailFrom.Size = new System.Drawing.Size(33, 13);
            this.lblDailyEmailFrom.TabIndex = 5;
            this.lblDailyEmailFrom.Text = "From:";
            // 
            // txtDailyEmailCC
            // 
            this.txtDailyEmailCC.Location = new System.Drawing.Point(232, 72);
            this.txtDailyEmailCC.Name = "txtDailyEmailCC";
            this.txtDailyEmailCC.Size = new System.Drawing.Size(175, 20);
            this.txtDailyEmailCC.TabIndex = 14;
            this.txtDailyEmailCC.Text = "peter.peng@missionsky.com";
            // 
            // lblDailyEmailCC
            // 
            this.lblDailyEmailCC.AutoSize = true;
            this.lblDailyEmailCC.Location = new System.Drawing.Point(229, 56);
            this.lblDailyEmailCC.Name = "lblDailyEmailCC";
            this.lblDailyEmailCC.Size = new System.Drawing.Size(24, 13);
            this.lblDailyEmailCC.TabIndex = 15;
            this.lblDailyEmailCC.Text = "CC:";
            // 
            // EmailSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 442);
            this.Controls.Add(this.tabEmailSetting);
            this.Name = "EmailSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Email Setting";
            this.tabEmailSetting.ResumeLayout(false);
            this.tabEmailServer.ResumeLayout(false);
            this.tabEmailServer.PerformLayout();
            this.tabDailyCaseEmailTemplate.ResumeLayout(false);
            this.tabDailyCaseEmailTemplate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TabControl tabEmailSetting;
        private System.Windows.Forms.TabPage tabEmailServer;
        private System.Windows.Forms.CheckBox chkAuth;
        private System.Windows.Forms.Button btnUpdateEmailServerSetting;
        private System.Windows.Forms.Button btnTestEmailServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblAuth;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.TabPage tabDailyCaseEmailTemplate;
        private System.Windows.Forms.TextBox txtDailyEmailContent;
        private System.Windows.Forms.TextBox txtDailyEmailSubject;
        private System.Windows.Forms.TextBox txtDailyEmailTo;
        private System.Windows.Forms.TextBox txtDailyEmailFrom;
        private System.Windows.Forms.Label lblDailyEmailContent;
        private System.Windows.Forms.Label lblDailyEmailSubject;
        private System.Windows.Forms.Label lblDailyEmailTo;
        private System.Windows.Forms.Label lblDailyEmailFrom;
        private System.Windows.Forms.Button btnUpdateDailyCaseEmailTemplate;
        private System.Windows.Forms.TextBox txtDefaultToReceiver;
        private System.Windows.Forms.Label lblDefaultToReceiver;
        private System.Windows.Forms.TextBox txtDefaultCCReceiver;
        private System.Windows.Forms.Label lblDefaultCCReceiver;
        private System.Windows.Forms.TextBox txtDefaultSender;
        private System.Windows.Forms.Label lblDefaultSender;
        private System.Windows.Forms.Label lblDailyEmailCC;
        private System.Windows.Forms.TextBox txtDailyEmailCC;
    }
}