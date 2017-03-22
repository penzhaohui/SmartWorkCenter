namespace com.smartwork
{
    partial class DBRequestForm
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
            this.grbSFandJiraID = new System.Windows.Forms.GroupBox();
            this.txtEngsuppID = new System.Windows.Forms.TextBox();
            this.lblJiraID = new System.Windows.Forms.Label();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtSFID = new System.Windows.Forms.TextBox();
            this.lblSFID = new System.Windows.Forms.Label();
            this.grbLocalDBInfo = new System.Windows.Forms.GroupBox();
            this.txtRelatedCase = new System.Windows.Forms.TextBox();
            this.lblRelatedCase = new System.Windows.Forms.Label();
            this.txtDBVersion = new System.Windows.Forms.TextBox();
            this.lblDBVersion = new System.Windows.Forms.Label();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.lalDBPassword = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.lblDBUser = new System.Windows.Forms.Label();
            this.txtDBInstance = new System.Windows.Forms.TextBox();
            this.lblDBInstance = new System.Windows.Forms.Label();
            this.txtDBServerPort = new System.Windows.Forms.TextBox();
            this.lblDBServerPort = new System.Windows.Forms.Label();
            this.txtDBServerIP = new System.Windows.Forms.TextBox();
            this.lblDBServerIP = new System.Windows.Forms.Label();
            this.txtDBType = new System.Windows.Forms.TextBox();
            this.lblDBType = new System.Windows.Forms.Label();
            this.grbCustomerInfo = new System.Windows.Forms.GroupBox();
            this.chbJetspeed = new System.Windows.Forms.CheckBox();
            this.lblJetspeed = new System.Windows.Forms.Label();
            this.chbTestFlag = new System.Windows.Forms.CheckBox();
            this.lblTestFlag = new System.Windows.Forms.Label();
            this.chbSupportFlag = new System.Windows.Forms.CheckBox();
            this.lblSupportFlag = new System.Windows.Forms.Label();
            this.chbProductionFlag = new System.Windows.Forms.CheckBox();
            this.lblProductionFlag = new System.Windows.Forms.Label();
            this.txtCaseOwner = new System.Windows.Forms.TextBox();
            this.lblCaseOwner = new System.Windows.Forms.Label();
            this.chbAccelaHostedFlag = new System.Windows.Forms.CheckBox();
            this.lblAccelaHostedFlag = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtCustomerInfo = new System.Windows.Forms.TextBox();
            this.lblCustomerInfo = new System.Windows.Forms.Label();
            this.grbOutputBox = new System.Windows.Forms.GroupBox();
            this.txtOutputComment = new System.Windows.Forms.TextBox();
            this.lblIssueSubject = new System.Windows.Forms.Label();
            this.txtIssueSubject = new System.Windows.Forms.TextBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatabaseID = new System.Windows.Forms.TextBox();
            this.btnCheckDBRequest = new System.Windows.Forms.Button();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblSiteUrl = new System.Windows.Forms.Label();
            this.txtSiteUrl = new System.Windows.Forms.TextBox();
            this.grbCaseInfo = new System.Windows.Forms.GroupBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtNotice = new System.Windows.Forms.TextBox();
            this.grbSFandJiraID.SuspendLayout();
            this.grbLocalDBInfo.SuspendLayout();
            this.grbCustomerInfo.SuspendLayout();
            this.grbOutputBox.SuspendLayout();
            this.grbCaseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbSFandJiraID
            // 
            this.grbSFandJiraID.Controls.Add(this.txtSiteUrl);
            this.grbSFandJiraID.Controls.Add(this.lblSiteUrl);
            this.grbSFandJiraID.Controls.Add(this.btnRequest);
            this.grbSFandJiraID.Controls.Add(this.btnCheck);
            this.grbSFandJiraID.Controls.Add(this.txtSFID);
            this.grbSFandJiraID.Controls.Add(this.lblSFID);
            this.grbSFandJiraID.Location = new System.Drawing.Point(12, 12);
            this.grbSFandJiraID.Name = "grbSFandJiraID";
            this.grbSFandJiraID.Size = new System.Drawing.Size(539, 78);
            this.grbSFandJiraID.TabIndex = 0;
            this.grbSFandJiraID.TabStop = false;
            this.grbSFandJiraID.Text = "Please enter salesforce id or jira id here";
            // 
            // txtEngsuppID
            // 
            this.txtEngsuppID.Location = new System.Drawing.Point(109, 504);
            this.txtEngsuppID.Name = "txtEngsuppID";
            this.txtEngsuppID.Size = new System.Drawing.Size(126, 20);
            this.txtEngsuppID.TabIndex = 4;
            // 
            // lblJiraID
            // 
            this.lblJiraID.AutoSize = true;
            this.lblJiraID.Location = new System.Drawing.Point(29, 507);
            this.lblJiraID.Name = "lblJiraID";
            this.lblJiraID.Size = new System.Drawing.Size(76, 13);
            this.lblJiraID.TabIndex = 2;
            this.lblJiraID.Text = "ENGSUPP ID:";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(373, 19);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(149, 23);
            this.btnRequest.TabIndex = 3;
            this.btnRequest.Text = "Request New DB Dump";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(245, 20);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(111, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtSFID
            // 
            this.txtSFID.Location = new System.Drawing.Point(97, 27);
            this.txtSFID.Name = "txtSFID";
            this.txtSFID.Size = new System.Drawing.Size(126, 20);
            this.txtSFID.TabIndex = 1;
            // 
            // lblSFID
            // 
            this.lblSFID.AutoSize = true;
            this.lblSFID.Location = new System.Drawing.Point(17, 30);
            this.lblSFID.Name = "lblSFID";
            this.lblSFID.Size = new System.Drawing.Size(74, 13);
            this.lblSFID.TabIndex = 0;
            this.lblSFID.Text = "Salesforce ID:";
            // 
            // grbLocalDBInfo
            // 
            this.grbLocalDBInfo.Controls.Add(this.txtRelatedCase);
            this.grbLocalDBInfo.Controls.Add(this.lblRelatedCase);
            this.grbLocalDBInfo.Controls.Add(this.txtDBVersion);
            this.grbLocalDBInfo.Controls.Add(this.lblDBVersion);
            this.grbLocalDBInfo.Controls.Add(this.txtDBPassword);
            this.grbLocalDBInfo.Controls.Add(this.lalDBPassword);
            this.grbLocalDBInfo.Controls.Add(this.txtDBUser);
            this.grbLocalDBInfo.Controls.Add(this.lblDBUser);
            this.grbLocalDBInfo.Controls.Add(this.txtDBInstance);
            this.grbLocalDBInfo.Controls.Add(this.lblDBInstance);
            this.grbLocalDBInfo.Controls.Add(this.txtDBServerPort);
            this.grbLocalDBInfo.Controls.Add(this.lblDBServerPort);
            this.grbLocalDBInfo.Controls.Add(this.txtDBServerIP);
            this.grbLocalDBInfo.Controls.Add(this.lblDBServerIP);
            this.grbLocalDBInfo.Controls.Add(this.txtDBType);
            this.grbLocalDBInfo.Controls.Add(this.lblDBType);
            this.grbLocalDBInfo.Location = new System.Drawing.Point(12, 113);
            this.grbLocalDBInfo.Name = "grbLocalDBInfo";
            this.grbLocalDBInfo.Size = new System.Drawing.Size(256, 346);
            this.grbLocalDBInfo.TabIndex = 1;
            this.grbLocalDBInfo.TabStop = false;
            this.grbLocalDBInfo.Text = "Local DB Info";
            // 
            // txtRelatedCase
            // 
            this.txtRelatedCase.Location = new System.Drawing.Point(97, 300);
            this.txtRelatedCase.Name = "txtRelatedCase";
            this.txtRelatedCase.Size = new System.Drawing.Size(126, 20);
            this.txtRelatedCase.TabIndex = 19;
            // 
            // lblRelatedCase
            // 
            this.lblRelatedCase.AutoSize = true;
            this.lblRelatedCase.Location = new System.Drawing.Point(11, 303);
            this.lblRelatedCase.Name = "lblRelatedCase";
            this.lblRelatedCase.Size = new System.Drawing.Size(74, 13);
            this.lblRelatedCase.TabIndex = 18;
            this.lblRelatedCase.Text = "Related Case:";
            // 
            // txtDBVersion
            // 
            this.txtDBVersion.Location = new System.Drawing.Point(97, 257);
            this.txtDBVersion.Name = "txtDBVersion";
            this.txtDBVersion.Size = new System.Drawing.Size(126, 20);
            this.txtDBVersion.TabIndex = 17;
            // 
            // lblDBVersion
            // 
            this.lblDBVersion.AutoSize = true;
            this.lblDBVersion.Location = new System.Drawing.Point(35, 260);
            this.lblDBVersion.Name = "lblDBVersion";
            this.lblDBVersion.Size = new System.Drawing.Size(45, 13);
            this.lblDBVersion.TabIndex = 16;
            this.lblDBVersion.Text = "Version:";
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Location = new System.Drawing.Point(97, 217);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.Size = new System.Drawing.Size(126, 20);
            this.txtDBPassword.TabIndex = 15;
            // 
            // lalDBPassword
            // 
            this.lalDBPassword.AutoSize = true;
            this.lalDBPassword.Location = new System.Drawing.Point(24, 220);
            this.lalDBPassword.Name = "lalDBPassword";
            this.lalDBPassword.Size = new System.Drawing.Size(56, 13);
            this.lalDBPassword.TabIndex = 14;
            this.lalDBPassword.Text = "Password:";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Location = new System.Drawing.Point(97, 175);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(126, 20);
            this.txtDBUser.TabIndex = 13;
            // 
            // lblDBUser
            // 
            this.lblDBUser.AutoSize = true;
            this.lblDBUser.Location = new System.Drawing.Point(48, 178);
            this.lblDBUser.Name = "lblDBUser";
            this.lblDBUser.Size = new System.Drawing.Size(32, 13);
            this.lblDBUser.TabIndex = 12;
            this.lblDBUser.Text = "User:";
            // 
            // txtDBInstance
            // 
            this.txtDBInstance.Location = new System.Drawing.Point(97, 140);
            this.txtDBInstance.Name = "txtDBInstance";
            this.txtDBInstance.Size = new System.Drawing.Size(126, 20);
            this.txtDBInstance.TabIndex = 11;
            // 
            // lblDBInstance
            // 
            this.lblDBInstance.AutoSize = true;
            this.lblDBInstance.Location = new System.Drawing.Point(29, 143);
            this.lblDBInstance.Name = "lblDBInstance";
            this.lblDBInstance.Size = new System.Drawing.Size(51, 13);
            this.lblDBInstance.TabIndex = 10;
            this.lblDBInstance.Text = "Instance:";
            // 
            // txtDBServerPort
            // 
            this.txtDBServerPort.Location = new System.Drawing.Point(97, 104);
            this.txtDBServerPort.Name = "txtDBServerPort";
            this.txtDBServerPort.Size = new System.Drawing.Size(126, 20);
            this.txtDBServerPort.TabIndex = 9;
            // 
            // lblDBServerPort
            // 
            this.lblDBServerPort.AutoSize = true;
            this.lblDBServerPort.Location = new System.Drawing.Point(51, 111);
            this.lblDBServerPort.Name = "lblDBServerPort";
            this.lblDBServerPort.Size = new System.Drawing.Size(29, 13);
            this.lblDBServerPort.TabIndex = 8;
            this.lblDBServerPort.Text = "Port:";
            // 
            // txtDBServerIP
            // 
            this.txtDBServerIP.Location = new System.Drawing.Point(97, 70);
            this.txtDBServerIP.Name = "txtDBServerIP";
            this.txtDBServerIP.Size = new System.Drawing.Size(126, 20);
            this.txtDBServerIP.TabIndex = 7;
            // 
            // lblDBServerIP
            // 
            this.lblDBServerIP.AutoSize = true;
            this.lblDBServerIP.Location = new System.Drawing.Point(51, 77);
            this.lblDBServerIP.Name = "lblDBServerIP";
            this.lblDBServerIP.Size = new System.Drawing.Size(20, 13);
            this.lblDBServerIP.TabIndex = 6;
            this.lblDBServerIP.Text = "IP:";
            // 
            // txtDBType
            // 
            this.txtDBType.Location = new System.Drawing.Point(97, 34);
            this.txtDBType.Name = "txtDBType";
            this.txtDBType.Size = new System.Drawing.Size(126, 20);
            this.txtDBType.TabIndex = 5;
            // 
            // lblDBType
            // 
            this.lblDBType.AutoSize = true;
            this.lblDBType.Location = new System.Drawing.Point(51, 37);
            this.lblDBType.Name = "lblDBType";
            this.lblDBType.Size = new System.Drawing.Size(34, 13);
            this.lblDBType.TabIndex = 0;
            this.lblDBType.Text = "Type:";
            // 
            // grbCustomerInfo
            // 
            this.grbCustomerInfo.Controls.Add(this.txtNotice);
            this.grbCustomerInfo.Controls.Add(this.chbJetspeed);
            this.grbCustomerInfo.Controls.Add(this.lblJetspeed);
            this.grbCustomerInfo.Controls.Add(this.chbTestFlag);
            this.grbCustomerInfo.Controls.Add(this.lblTestFlag);
            this.grbCustomerInfo.Controls.Add(this.chbSupportFlag);
            this.grbCustomerInfo.Controls.Add(this.lblSupportFlag);
            this.grbCustomerInfo.Controls.Add(this.chbProductionFlag);
            this.grbCustomerInfo.Controls.Add(this.lblProductionFlag);
            this.grbCustomerInfo.Controls.Add(this.txtCaseOwner);
            this.grbCustomerInfo.Controls.Add(this.lblCaseOwner);
            this.grbCustomerInfo.Controls.Add(this.chbAccelaHostedFlag);
            this.grbCustomerInfo.Controls.Add(this.lblAccelaHostedFlag);
            this.grbCustomerInfo.Controls.Add(this.txtVersion);
            this.grbCustomerInfo.Controls.Add(this.lblVersion);
            this.grbCustomerInfo.Controls.Add(this.txtCustomerInfo);
            this.grbCustomerInfo.Controls.Add(this.lblCustomerInfo);
            this.grbCustomerInfo.Location = new System.Drawing.Point(284, 113);
            this.grbCustomerInfo.Name = "grbCustomerInfo";
            this.grbCustomerInfo.Size = new System.Drawing.Size(267, 346);
            this.grbCustomerInfo.TabIndex = 2;
            this.grbCustomerInfo.TabStop = false;
            this.grbCustomerInfo.Text = "Cutomer Info";
            // 
            // chbJetspeed
            // 
            this.chbJetspeed.AutoSize = true;
            this.chbJetspeed.Location = new System.Drawing.Point(111, 287);
            this.chbJetspeed.Name = "chbJetspeed";
            this.chbJetspeed.Size = new System.Drawing.Size(15, 14);
            this.chbJetspeed.TabIndex = 20;
            this.chbJetspeed.UseVisualStyleBackColor = true;
            // 
            // lblJetspeed
            // 
            this.lblJetspeed.AutoSize = true;
            this.lblJetspeed.Location = new System.Drawing.Point(43, 288);
            this.lblJetspeed.Name = "lblJetspeed";
            this.lblJetspeed.Size = new System.Drawing.Size(53, 13);
            this.lblJetspeed.TabIndex = 19;
            this.lblJetspeed.Text = "Jetspeed:";
            // 
            // chbTestFlag
            // 
            this.chbTestFlag.AutoSize = true;
            this.chbTestFlag.Location = new System.Drawing.Point(111, 257);
            this.chbTestFlag.Name = "chbTestFlag";
            this.chbTestFlag.Size = new System.Drawing.Size(15, 14);
            this.chbTestFlag.TabIndex = 18;
            this.chbTestFlag.UseVisualStyleBackColor = true;
            // 
            // lblTestFlag
            // 
            this.lblTestFlag.AutoSize = true;
            this.lblTestFlag.Location = new System.Drawing.Point(59, 257);
            this.lblTestFlag.Name = "lblTestFlag";
            this.lblTestFlag.Size = new System.Drawing.Size(31, 13);
            this.lblTestFlag.TabIndex = 17;
            this.lblTestFlag.Text = "Test:";
            // 
            // chbSupportFlag
            // 
            this.chbSupportFlag.AutoSize = true;
            this.chbSupportFlag.Location = new System.Drawing.Point(111, 216);
            this.chbSupportFlag.Name = "chbSupportFlag";
            this.chbSupportFlag.Size = new System.Drawing.Size(15, 14);
            this.chbSupportFlag.TabIndex = 16;
            this.chbSupportFlag.UseVisualStyleBackColor = true;
            // 
            // lblSupportFlag
            // 
            this.lblSupportFlag.AutoSize = true;
            this.lblSupportFlag.Location = new System.Drawing.Point(43, 217);
            this.lblSupportFlag.Name = "lblSupportFlag";
            this.lblSupportFlag.Size = new System.Drawing.Size(47, 13);
            this.lblSupportFlag.TabIndex = 15;
            this.lblSupportFlag.Text = "Support:";
            // 
            // chbProductionFlag
            // 
            this.chbProductionFlag.AutoSize = true;
            this.chbProductionFlag.Location = new System.Drawing.Point(111, 175);
            this.chbProductionFlag.Name = "chbProductionFlag";
            this.chbProductionFlag.Size = new System.Drawing.Size(15, 14);
            this.chbProductionFlag.TabIndex = 14;
            this.chbProductionFlag.UseVisualStyleBackColor = true;
            // 
            // lblProductionFlag
            // 
            this.lblProductionFlag.AutoSize = true;
            this.lblProductionFlag.Location = new System.Drawing.Point(35, 178);
            this.lblProductionFlag.Name = "lblProductionFlag";
            this.lblProductionFlag.Size = new System.Drawing.Size(61, 13);
            this.lblProductionFlag.TabIndex = 13;
            this.lblProductionFlag.Text = "Production:";
            // 
            // txtCaseOwner
            // 
            this.txtCaseOwner.Location = new System.Drawing.Point(111, 136);
            this.txtCaseOwner.Name = "txtCaseOwner";
            this.txtCaseOwner.Size = new System.Drawing.Size(126, 20);
            this.txtCaseOwner.TabIndex = 12;
            // 
            // lblCaseOwner
            // 
            this.lblCaseOwner.AutoSize = true;
            this.lblCaseOwner.Location = new System.Drawing.Point(28, 140);
            this.lblCaseOwner.Name = "lblCaseOwner";
            this.lblCaseOwner.Size = new System.Drawing.Size(68, 13);
            this.lblCaseOwner.TabIndex = 11;
            this.lblCaseOwner.Text = "Case Owner:";
            // 
            // chbAccelaHostedFlag
            // 
            this.chbAccelaHostedFlag.AutoSize = true;
            this.chbAccelaHostedFlag.Location = new System.Drawing.Point(111, 106);
            this.chbAccelaHostedFlag.Name = "chbAccelaHostedFlag";
            this.chbAccelaHostedFlag.Size = new System.Drawing.Size(15, 14);
            this.chbAccelaHostedFlag.TabIndex = 10;
            this.chbAccelaHostedFlag.UseVisualStyleBackColor = true;
            // 
            // lblAccelaHostedFlag
            // 
            this.lblAccelaHostedFlag.AutoSize = true;
            this.lblAccelaHostedFlag.Location = new System.Drawing.Point(21, 107);
            this.lblAccelaHostedFlag.Name = "lblAccelaHostedFlag";
            this.lblAccelaHostedFlag.Size = new System.Drawing.Size(80, 13);
            this.lblAccelaHostedFlag.TabIndex = 9;
            this.lblAccelaHostedFlag.Text = "Accela Hosted:";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(111, 67);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(126, 20);
            this.txtVersion.TabIndex = 8;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(51, 70);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "Version:";
            // 
            // txtCustomerInfo
            // 
            this.txtCustomerInfo.Location = new System.Drawing.Point(111, 30);
            this.txtCustomerInfo.Name = "txtCustomerInfo";
            this.txtCustomerInfo.Size = new System.Drawing.Size(126, 20);
            this.txtCustomerInfo.TabIndex = 6;
            // 
            // lblCustomerInfo
            // 
            this.lblCustomerInfo.AutoSize = true;
            this.lblCustomerInfo.Location = new System.Drawing.Point(21, 36);
            this.lblCustomerInfo.Name = "lblCustomerInfo";
            this.lblCustomerInfo.Size = new System.Drawing.Size(75, 13);
            this.lblCustomerInfo.TabIndex = 0;
            this.lblCustomerInfo.Text = "Customer Info:";
            // 
            // grbOutputBox
            // 
            this.grbOutputBox.Controls.Add(this.txtOutputComment);
            this.grbOutputBox.Location = new System.Drawing.Point(823, 113);
            this.grbOutputBox.Name = "grbOutputBox";
            this.grbOutputBox.Size = new System.Drawing.Size(383, 346);
            this.grbOutputBox.TabIndex = 3;
            this.grbOutputBox.TabStop = false;
            this.grbOutputBox.Text = "Output Comment";
            // 
            // txtOutputComment
            // 
            this.txtOutputComment.Location = new System.Drawing.Point(6, 19);
            this.txtOutputComment.Multiline = true;
            this.txtOutputComment.Name = "txtOutputComment";
            this.txtOutputComment.Size = new System.Drawing.Size(371, 321);
            this.txtOutputComment.TabIndex = 0;
            // 
            // lblIssueSubject
            // 
            this.lblIssueSubject.AutoSize = true;
            this.lblIssueSubject.Location = new System.Drawing.Point(558, 26);
            this.lblIssueSubject.Name = "lblIssueSubject";
            this.lblIssueSubject.Size = new System.Drawing.Size(74, 13);
            this.lblIssueSubject.TabIndex = 4;
            this.lblIssueSubject.Text = "Issue Subject:";
            // 
            // txtIssueSubject
            // 
            this.txtIssueSubject.Location = new System.Drawing.Point(561, 42);
            this.txtIssueSubject.Multiline = true;
            this.txtIssueSubject.Name = "txtIssueSubject";
            this.txtIssueSubject.Size = new System.Drawing.Size(639, 48);
            this.txtIssueSubject.TabIndex = 7;
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(16, 34);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(47, 13);
            this.lblProduct.TabIndex = 8;
            this.lblProduct.Text = "Product:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "DATABASE ID:";
            // 
            // txtDatabaseID
            // 
            this.txtDatabaseID.Location = new System.Drawing.Point(109, 543);
            this.txtDatabaseID.Name = "txtDatabaseID";
            this.txtDatabaseID.Size = new System.Drawing.Size(126, 20);
            this.txtDatabaseID.TabIndex = 10;
            // 
            // btnCheckDBRequest
            // 
            this.btnCheckDBRequest.Location = new System.Drawing.Point(257, 507);
            this.btnCheckDBRequest.Name = "btnCheckDBRequest";
            this.btnCheckDBRequest.Size = new System.Drawing.Size(111, 56);
            this.btnCheckDBRequest.TabIndex = 11;
            this.btnCheckDBRequest.Text = "Check";
            this.btnCheckDBRequest.UseVisualStyleBackColor = true;
            this.btnCheckDBRequest.Click += new System.EventHandler(this.btnCheckDBRequest_Click);
            // 
            // txtPriority
            // 
            this.txtPriority.Location = new System.Drawing.Point(83, 64);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(127, 20);
            this.txtPriority.TabIndex = 4;
            // 
            // lblPriority
            // 
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(16, 67);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Size = new System.Drawing.Size(41, 13);
            this.lblPriority.TabIndex = 12;
            this.lblPriority.Text = "Priority:";
            // 
            // lblSiteUrl
            // 
            this.lblSiteUrl.AutoSize = true;
            this.lblSiteUrl.Location = new System.Drawing.Point(35, 52);
            this.lblSiteUrl.Name = "lblSiteUrl";
            this.lblSiteUrl.Size = new System.Drawing.Size(53, 13);
            this.lblSiteUrl.TabIndex = 4;
            this.lblSiteUrl.Text = "Site URL:";
            // 
            // txtSiteUrl
            // 
            this.txtSiteUrl.Location = new System.Drawing.Point(97, 53);
            this.txtSiteUrl.Multiline = true;
            this.txtSiteUrl.Name = "txtSiteUrl";
            this.txtSiteUrl.Size = new System.Drawing.Size(425, 20);
            this.txtSiteUrl.TabIndex = 5;
            // 
            // grbCaseInfo
            // 
            this.grbCaseInfo.Controls.Add(this.txtProduct);
            this.grbCaseInfo.Controls.Add(this.lblPriority);
            this.grbCaseInfo.Controls.Add(this.txtPriority);
            this.grbCaseInfo.Controls.Add(this.lblProduct);
            this.grbCaseInfo.Location = new System.Drawing.Point(561, 113);
            this.grbCaseInfo.Name = "grbCaseInfo";
            this.grbCaseInfo.Size = new System.Drawing.Size(246, 345);
            this.grbCaseInfo.TabIndex = 13;
            this.grbCaseInfo.TabStop = false;
            this.grbCaseInfo.Text = "Case Info";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(83, 27);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(127, 20);
            this.txtProduct.TabIndex = 13;
            // 
            // txtNotice
            // 
            this.txtNotice.Location = new System.Drawing.Point(132, 174);
            this.txtNotice.Multiline = true;
            this.txtNotice.Name = "txtNotice";
            this.txtNotice.ReadOnly = true;
            this.txtNotice.Size = new System.Drawing.Size(125, 127);
            this.txtNotice.TabIndex = 21;
            this.txtNotice.Text = "Notice: Please tick on which enviroment this case could be recreated ";
            // 
            // DBRequestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 623);
            this.Controls.Add(this.grbCaseInfo);
            this.Controls.Add(this.btnCheckDBRequest);
            this.Controls.Add(this.txtDatabaseID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEngsuppID);
            this.Controls.Add(this.lblJiraID);
            this.Controls.Add(this.txtIssueSubject);
            this.Controls.Add(this.lblIssueSubject);
            this.Controls.Add(this.grbOutputBox);
            this.Controls.Add(this.grbCustomerInfo);
            this.Controls.Add(this.grbLocalDBInfo);
            this.Controls.Add(this.grbSFandJiraID);
            this.Name = "DBRequestForm";
            this.Text = "DB Request Form";
            this.grbSFandJiraID.ResumeLayout(false);
            this.grbSFandJiraID.PerformLayout();
            this.grbLocalDBInfo.ResumeLayout(false);
            this.grbLocalDBInfo.PerformLayout();
            this.grbCustomerInfo.ResumeLayout(false);
            this.grbCustomerInfo.PerformLayout();
            this.grbOutputBox.ResumeLayout(false);
            this.grbOutputBox.PerformLayout();
            this.grbCaseInfo.ResumeLayout(false);
            this.grbCaseInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSFandJiraID;
        private System.Windows.Forms.TextBox txtEngsuppID;
        private System.Windows.Forms.Label lblJiraID;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtSFID;
        private System.Windows.Forms.Label lblSFID;
        private System.Windows.Forms.GroupBox grbLocalDBInfo;
        private System.Windows.Forms.TextBox txtRelatedCase;
        private System.Windows.Forms.Label lblRelatedCase;
        private System.Windows.Forms.TextBox txtDBVersion;
        private System.Windows.Forms.Label lblDBVersion;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.Label lalDBPassword;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label lblDBUser;
        private System.Windows.Forms.TextBox txtDBInstance;
        private System.Windows.Forms.Label lblDBInstance;
        private System.Windows.Forms.TextBox txtDBServerPort;
        private System.Windows.Forms.Label lblDBServerPort;
        private System.Windows.Forms.TextBox txtDBServerIP;
        private System.Windows.Forms.Label lblDBServerIP;
        private System.Windows.Forms.TextBox txtDBType;
        private System.Windows.Forms.Label lblDBType;
        private System.Windows.Forms.GroupBox grbCustomerInfo;
        private System.Windows.Forms.CheckBox chbTestFlag;
        private System.Windows.Forms.Label lblTestFlag;
        private System.Windows.Forms.CheckBox chbSupportFlag;
        private System.Windows.Forms.CheckBox chbProductionFlag;
        private System.Windows.Forms.Label lblProductionFlag;
        private System.Windows.Forms.TextBox txtCaseOwner;
        private System.Windows.Forms.Label lblCaseOwner;
        private System.Windows.Forms.CheckBox chbAccelaHostedFlag;
        private System.Windows.Forms.Label lblAccelaHostedFlag;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtCustomerInfo;
        private System.Windows.Forms.Label lblCustomerInfo;
        private System.Windows.Forms.CheckBox chbJetspeed;
        private System.Windows.Forms.Label lblJetspeed;
        private System.Windows.Forms.GroupBox grbOutputBox;
        private System.Windows.Forms.TextBox txtOutputComment;
        private System.Windows.Forms.Label lblSupportFlag;
        private System.Windows.Forms.Label lblIssueSubject;
        private System.Windows.Forms.TextBox txtIssueSubject;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDatabaseID;
        private System.Windows.Forms.Button btnCheckDBRequest;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.TextBox txtSiteUrl;
        private System.Windows.Forms.Label lblSiteUrl;
        private System.Windows.Forms.GroupBox grbCaseInfo;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtNotice;
    }
}