namespace com.smartwork
{
    partial class DBSettingForm
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
            this.lblHost = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDatabaseName = new System.Windows.Forms.TextBox();
            this.btnTestDBConnection = new System.Windows.Forms.Button();
            this.btnUpdateDBConnection = new System.Windows.Forms.Button();
            this.lblUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(38, 48);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 13);
            this.lblHost.TabIndex = 0;
            this.lblHost.Text = "Host:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(38, 79);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 1;
            this.lblPort.Text = "Port:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(11, 158);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Password:";
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.AutoSize = true;
            this.lblDatabaseName.Location = new System.Drawing.Point(11, 196);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Size = new System.Drawing.Size(56, 13);
            this.lblDatabaseName.TabIndex = 4;
            this.lblDatabaseName.Text = "Database:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(76, 45);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(149, 20);
            this.txtHost.TabIndex = 5;
            this.txtHost.Text = "192.168.0.54";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(76, 79);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(34, 20);
            this.txtPort.TabIndex = 6;
            this.txtPort.Text = "1433";
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(76, 117);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(149, 20);
            this.txtUser.TabIndex = 7;
            this.txtUser.Text = "accela";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(76, 155);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(149, 20);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.Text = "accela";
            // 
            // txtDatabaseName
            // 
            this.txtDatabaseName.Location = new System.Drawing.Point(76, 193);
            this.txtDatabaseName.Name = "txtDatabaseName";
            this.txtDatabaseName.Size = new System.Drawing.Size(149, 20);
            this.txtDatabaseName.TabIndex = 9;
            this.txtDatabaseName.Text = "ACM";
            // 
            // btnTestDBConnection
            // 
            this.btnTestDBConnection.Location = new System.Drawing.Point(23, 244);
            this.btnTestDBConnection.Name = "btnTestDBConnection";
            this.btnTestDBConnection.Size = new System.Drawing.Size(75, 23);
            this.btnTestDBConnection.TabIndex = 10;
            this.btnTestDBConnection.Text = "Test";
            this.btnTestDBConnection.UseVisualStyleBackColor = true;
            this.btnTestDBConnection.Click += new System.EventHandler(this.btnTestDBConnection_Click);
            // 
            // btnUpdateDBConnection
            // 
            this.btnUpdateDBConnection.Location = new System.Drawing.Point(116, 244);
            this.btnUpdateDBConnection.Name = "btnUpdateDBConnection";
            this.btnUpdateDBConnection.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateDBConnection.TabIndex = 11;
            this.btnUpdateDBConnection.Text = "Update";
            this.btnUpdateDBConnection.UseVisualStyleBackColor = true;
            this.btnUpdateDBConnection.Click += new System.EventHandler(this.btnUpdateDBConnection_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(35, 120);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(32, 13);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User:";
            // 
            // DBSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 297);
            this.Controls.Add(this.btnUpdateDBConnection);
            this.Controls.Add(this.btnTestDBConnection);
            this.Controls.Add(this.txtDatabaseName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.lblDatabaseName);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblHost);
            this.Name = "DBSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Connection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblDatabaseName;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDatabaseName;
        private System.Windows.Forms.Button btnTestDBConnection;
        private System.Windows.Forms.Button btnUpdateDBConnection;
        private System.Windows.Forms.Label lblUser;
    }
}