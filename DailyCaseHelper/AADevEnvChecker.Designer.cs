namespace com.smartwork
{
    partial class AADevEnvChecker
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
            this.lblSelectAAWorkSpace = new System.Windows.Forms.Label();
            this.txtAAWorkSpaceLocation = new System.Windows.Forms.TextBox();
            this.btnSelectAAWorkSpace = new System.Windows.Forms.Button();
            this.lblCheckFolderAndFileStructure = new System.Windows.Forms.Label();
            this.btnCheckFolderAndFileStructure = new System.Windows.Forms.Button();
            this.lblReplaceIPAndDomain = new System.Windows.Forms.Label();
            this.btnReplaceIPAndDomain = new System.Windows.Forms.Button();
            this.lblUpdateAndSyncConfigFile = new System.Windows.Forms.Label();
            this.btnUpdateAndSyncConfigFile = new System.Windows.Forms.Button();
            this.lblConfigEclipse = new System.Windows.Forms.Label();
            this.btnConfigEclipse = new System.Windows.Forms.Button();
            this.lblFullBuildAAEnv = new System.Windows.Forms.Label();
            this.btnFullBuildAAEnv = new System.Windows.Forms.Button();
            this.lblLaunchAAServer = new System.Windows.Forms.Label();
            this.btnLaunchAAServer = new System.Windows.Forms.Button();
            this.lblDetectAAServer = new System.Windows.Forms.Label();
            this.btnDetectAAServer = new System.Windows.Forms.Button();
            this.lblSwitchDataType = new System.Windows.Forms.Label();
            this.btnSwitchDataType = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSelectAAWorkSpace
            // 
            this.lblSelectAAWorkSpace.AutoSize = true;
            this.lblSelectAAWorkSpace.Location = new System.Drawing.Point(39, 40);
            this.lblSelectAAWorkSpace.Name = "lblSelectAAWorkSpace";
            this.lblSelectAAWorkSpace.Size = new System.Drawing.Size(277, 13);
            this.lblSelectAAWorkSpace.TabIndex = 0;
            this.lblSelectAAWorkSpace.Text = "Step 1, Select the folder for AA Development Workspace";
            // 
            // txtAAWorkSpaceLocation
            // 
            this.txtAAWorkSpaceLocation.Location = new System.Drawing.Point(42, 65);
            this.txtAAWorkSpaceLocation.Name = "txtAAWorkSpaceLocation";
            this.txtAAWorkSpaceLocation.Size = new System.Drawing.Size(274, 20);
            this.txtAAWorkSpaceLocation.TabIndex = 1;
            // 
            // btnSelectAAWorkSpace
            // 
            this.btnSelectAAWorkSpace.Location = new System.Drawing.Point(322, 62);
            this.btnSelectAAWorkSpace.Name = "btnSelectAAWorkSpace";
            this.btnSelectAAWorkSpace.Size = new System.Drawing.Size(75, 23);
            this.btnSelectAAWorkSpace.TabIndex = 2;
            this.btnSelectAAWorkSpace.Text = "Select";
            this.btnSelectAAWorkSpace.UseVisualStyleBackColor = true;
            this.btnSelectAAWorkSpace.Click += new System.EventHandler(this.btnSelectAAWorkSpace_Click);
            // 
            // lblCheckFolderAndFileStructure
            // 
            this.lblCheckFolderAndFileStructure.AutoSize = true;
            this.lblCheckFolderAndFileStructure.Location = new System.Drawing.Point(39, 107);
            this.lblCheckFolderAndFileStructure.Name = "lblCheckFolderAndFileStructure";
            this.lblCheckFolderAndFileStructure.Size = new System.Drawing.Size(240, 13);
            this.lblCheckFolderAndFileStructure.TabIndex = 3;
            this.lblCheckFolderAndFileStructure.Text = "Step 2, Check the folder structure and config files";
            // 
            // btnCheckFolderAndFileStructure
            // 
            this.btnCheckFolderAndFileStructure.Location = new System.Drawing.Point(322, 102);
            this.btnCheckFolderAndFileStructure.Name = "btnCheckFolderAndFileStructure";
            this.btnCheckFolderAndFileStructure.Size = new System.Drawing.Size(75, 23);
            this.btnCheckFolderAndFileStructure.TabIndex = 4;
            this.btnCheckFolderAndFileStructure.Text = "Check";
            this.btnCheckFolderAndFileStructure.UseVisualStyleBackColor = true;
            this.btnCheckFolderAndFileStructure.Click += new System.EventHandler(this.btnCheckFolderAndFileStructure_Click);
            // 
            // lblReplaceIPAndDomain
            // 
            this.lblReplaceIPAndDomain.AutoSize = true;
            this.lblReplaceIPAndDomain.Location = new System.Drawing.Point(39, 159);
            this.lblReplaceIPAndDomain.Name = "lblReplaceIPAndDomain";
            this.lblReplaceIPAndDomain.Size = new System.Drawing.Size(276, 13);
            this.lblReplaceIPAndDomain.TabIndex = 5;
            this.lblReplaceIPAndDomain.Text = "Step 3, Replace IP address and domain(PS: accela.com)";
            // 
            // btnReplaceIPAndDomain
            // 
            this.btnReplaceIPAndDomain.Location = new System.Drawing.Point(322, 154);
            this.btnReplaceIPAndDomain.Name = "btnReplaceIPAndDomain";
            this.btnReplaceIPAndDomain.Size = new System.Drawing.Size(75, 23);
            this.btnReplaceIPAndDomain.TabIndex = 6;
            this.btnReplaceIPAndDomain.Text = "Replace";
            this.btnReplaceIPAndDomain.UseVisualStyleBackColor = true;
            this.btnReplaceIPAndDomain.Click += new System.EventHandler(this.btnReplaceIPAndDomain_Click);
            // 
            // lblUpdateAndSyncConfigFile
            // 
            this.lblUpdateAndSyncConfigFile.AutoSize = true;
            this.lblUpdateAndSyncConfigFile.Location = new System.Drawing.Point(40, 211);
            this.lblUpdateAndSyncConfigFile.Name = "lblUpdateAndSyncConfigFile";
            this.lblUpdateAndSyncConfigFile.Size = new System.Drawing.Size(206, 13);
            this.lblUpdateAndSyncConfigFile.TabIndex = 7;
            this.lblUpdateAndSyncConfigFile.Text = "Step 4, Update and sync some config files";
            // 
            // btnUpdateAndSyncConfigFile
            // 
            this.btnUpdateAndSyncConfigFile.Location = new System.Drawing.Point(322, 206);
            this.btnUpdateAndSyncConfigFile.Name = "btnUpdateAndSyncConfigFile";
            this.btnUpdateAndSyncConfigFile.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateAndSyncConfigFile.TabIndex = 8;
            this.btnUpdateAndSyncConfigFile.Text = "Update";
            this.btnUpdateAndSyncConfigFile.UseVisualStyleBackColor = true;
            this.btnUpdateAndSyncConfigFile.Click += new System.EventHandler(this.btnUpdateAndSyncConfigFile_Click);
            // 
            // lblConfigEclipse
            // 
            this.lblConfigEclipse.AutoSize = true;
            this.lblConfigEclipse.Location = new System.Drawing.Point(40, 265);
            this.lblConfigEclipse.Name = "lblConfigEclipse";
            this.lblConfigEclipse.Size = new System.Drawing.Size(110, 13);
            this.lblConfigEclipse.TabIndex = 9;
            this.lblConfigEclipse.Text = "Step 5, Config eclipse";
            // 
            // btnConfigEclipse
            // 
            this.btnConfigEclipse.Location = new System.Drawing.Point(322, 255);
            this.btnConfigEclipse.Name = "btnConfigEclipse";
            this.btnConfigEclipse.Size = new System.Drawing.Size(75, 23);
            this.btnConfigEclipse.TabIndex = 10;
            this.btnConfigEclipse.Text = "Config";
            this.btnConfigEclipse.UseVisualStyleBackColor = true;
            this.btnConfigEclipse.Click += new System.EventHandler(this.btnConfigEclipse_Click);
            // 
            // lblFullBuildAAEnv
            // 
            this.lblFullBuildAAEnv.AutoSize = true;
            this.lblFullBuildAAEnv.Location = new System.Drawing.Point(39, 319);
            this.lblFullBuildAAEnv.Name = "lblFullBuildAAEnv";
            this.lblFullBuildAAEnv.Size = new System.Drawing.Size(124, 13);
            this.lblFullBuildAAEnv.TabIndex = 11;
            this.lblFullBuildAAEnv.Text = "Step 6, Full build AA Env";
            // 
            // btnFullBuildAAEnv
            // 
            this.btnFullBuildAAEnv.Location = new System.Drawing.Point(322, 309);
            this.btnFullBuildAAEnv.Name = "btnFullBuildAAEnv";
            this.btnFullBuildAAEnv.Size = new System.Drawing.Size(75, 23);
            this.btnFullBuildAAEnv.TabIndex = 12;
            this.btnFullBuildAAEnv.Text = "Build";
            this.btnFullBuildAAEnv.UseVisualStyleBackColor = true;
            this.btnFullBuildAAEnv.Click += new System.EventHandler(this.btnFullBuildAAEnv_Click);
            // 
            // lblLaunchAAServer
            // 
            this.lblLaunchAAServer.AutoSize = true;
            this.lblLaunchAAServer.Location = new System.Drawing.Point(40, 407);
            this.lblLaunchAAServer.Name = "lblLaunchAAServer";
            this.lblLaunchAAServer.Size = new System.Drawing.Size(149, 13);
            this.lblLaunchAAServer.TabIndex = 13;
            this.lblLaunchAAServer.Text = "Step 8, Launch all AA Servers";
            // 
            // btnLaunchAAServer
            // 
            this.btnLaunchAAServer.Location = new System.Drawing.Point(322, 397);
            this.btnLaunchAAServer.Name = "btnLaunchAAServer";
            this.btnLaunchAAServer.Size = new System.Drawing.Size(75, 23);
            this.btnLaunchAAServer.TabIndex = 14;
            this.btnLaunchAAServer.Text = "Lauch";
            this.btnLaunchAAServer.UseVisualStyleBackColor = true;
            this.btnLaunchAAServer.Click += new System.EventHandler(this.btnLaunchAAServer_Click);
            // 
            // lblDetectAAServer
            // 
            this.lblDetectAAServer.AutoSize = true;
            this.lblDetectAAServer.Location = new System.Drawing.Point(40, 448);
            this.lblDetectAAServer.Name = "lblDetectAAServer";
            this.lblDetectAAServer.Size = new System.Drawing.Size(230, 13);
            this.lblDetectAAServer.TabIndex = 15;
            this.lblDetectAAServer.Text = "Step 9, Detect ACA service, GovXML, RestAPI";
            // 
            // btnDetectAAServer
            // 
            this.btnDetectAAServer.Location = new System.Drawing.Point(322, 438);
            this.btnDetectAAServer.Name = "btnDetectAAServer";
            this.btnDetectAAServer.Size = new System.Drawing.Size(75, 23);
            this.btnDetectAAServer.TabIndex = 16;
            this.btnDetectAAServer.Text = "Detect";
            this.btnDetectAAServer.UseVisualStyleBackColor = true;
            this.btnDetectAAServer.Click += new System.EventHandler(this.btnDetectAAServer_Click);
            // 
            // lblSwitchDataType
            // 
            this.lblSwitchDataType.AutoSize = true;
            this.lblSwitchDataType.Location = new System.Drawing.Point(40, 365);
            this.lblSwitchDataType.Name = "lblSwitchDataType";
            this.lblSwitchDataType.Size = new System.Drawing.Size(146, 13);
            this.lblSwitchDataType.TabIndex = 17;
            this.lblSwitchDataType.Text = "Step 7, Switch database type";
            // 
            // btnSwitchDataType
            // 
            this.btnSwitchDataType.Location = new System.Drawing.Point(322, 355);
            this.btnSwitchDataType.Name = "btnSwitchDataType";
            this.btnSwitchDataType.Size = new System.Drawing.Size(75, 23);
            this.btnSwitchDataType.TabIndex = 18;
            this.btnSwitchDataType.Text = "Switch";
            this.btnSwitchDataType.UseVisualStyleBackColor = true;
            this.btnSwitchDataType.Click += new System.EventHandler(this.btnSwitchDataType_Click);
            // 
            // AADevEnvChecker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 511);
            this.Controls.Add(this.btnSwitchDataType);
            this.Controls.Add(this.lblSwitchDataType);
            this.Controls.Add(this.btnDetectAAServer);
            this.Controls.Add(this.lblDetectAAServer);
            this.Controls.Add(this.btnLaunchAAServer);
            this.Controls.Add(this.lblLaunchAAServer);
            this.Controls.Add(this.btnFullBuildAAEnv);
            this.Controls.Add(this.lblFullBuildAAEnv);
            this.Controls.Add(this.btnConfigEclipse);
            this.Controls.Add(this.lblConfigEclipse);
            this.Controls.Add(this.btnUpdateAndSyncConfigFile);
            this.Controls.Add(this.lblUpdateAndSyncConfigFile);
            this.Controls.Add(this.btnReplaceIPAndDomain);
            this.Controls.Add(this.lblReplaceIPAndDomain);
            this.Controls.Add(this.btnCheckFolderAndFileStructure);
            this.Controls.Add(this.lblCheckFolderAndFileStructure);
            this.Controls.Add(this.btnSelectAAWorkSpace);
            this.Controls.Add(this.txtAAWorkSpaceLocation);
            this.Controls.Add(this.lblSelectAAWorkSpace);
            this.Name = "AADevEnvChecker";
            this.Text = "AA Devevlopment Enviroment Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectAAWorkSpace;
        private System.Windows.Forms.TextBox txtAAWorkSpaceLocation;
        private System.Windows.Forms.Button btnSelectAAWorkSpace;
        private System.Windows.Forms.Label lblCheckFolderAndFileStructure;
        private System.Windows.Forms.Button btnCheckFolderAndFileStructure;
        private System.Windows.Forms.Label lblReplaceIPAndDomain;
        private System.Windows.Forms.Button btnReplaceIPAndDomain;
        private System.Windows.Forms.Label lblUpdateAndSyncConfigFile;
        private System.Windows.Forms.Button btnUpdateAndSyncConfigFile;
        private System.Windows.Forms.Label lblConfigEclipse;
        private System.Windows.Forms.Button btnConfigEclipse;
        private System.Windows.Forms.Label lblFullBuildAAEnv;
        private System.Windows.Forms.Button btnFullBuildAAEnv;
        private System.Windows.Forms.Label lblLaunchAAServer;
        private System.Windows.Forms.Button btnLaunchAAServer;
        private System.Windows.Forms.Label lblDetectAAServer;
        private System.Windows.Forms.Button btnDetectAAServer;
        private System.Windows.Forms.Label lblSwitchDataType;
        private System.Windows.Forms.Button btnSwitchDataType;
    }
}