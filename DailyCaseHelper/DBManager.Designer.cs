namespace com.smartwork
{
    partial class DBManager
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
            this.btnSync = new System.Windows.Forms.Button();
            this.btnRestPWD = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtCaseNo = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblCaseNo = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DB_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_Port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_SID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DB_Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SFCase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgencyList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAgencyCode = new System.Windows.Forms.Label();
            this.txtAgencyCode = new System.Windows.Forms.TextBox();
            this.txtJIRAKey = new System.Windows.Forms.TextBox();
            this.lblJIRAKey = new System.Windows.Forms.Label();
            this.btnUnlcokUser = new System.Windows.Forms.Button();
            this.btnResetSEQ = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(12, 16);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 23);
            this.btnSync.TabIndex = 2;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnRestPWD
            // 
            this.btnRestPWD.Location = new System.Drawing.Point(93, 16);
            this.btnRestPWD.Name = "btnRestPWD";
            this.btnRestPWD.Size = new System.Drawing.Size(75, 23);
            this.btnRestPWD.TabIndex = 3;
            this.btnRestPWD.Text = "Rest PWD";
            this.btnRestPWD.UseVisualStyleBackColor = true;
            this.btnRestPWD.Click += new System.EventHandler(this.btnRestPWD_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1209, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtCaseNo
            // 
            this.txtCaseNo.Location = new System.Drawing.Point(1027, 56);
            this.txtCaseNo.Name = "txtCaseNo";
            this.txtCaseNo.Size = new System.Drawing.Size(176, 20);
            this.txtCaseNo.TabIndex = 5;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(745, 31);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(176, 20);
            this.txtCustomer.TabIndex = 6;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(685, 38);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(54, 13);
            this.lblCustomer.TabIndex = 7;
            this.lblCustomer.Text = "Customer:";
            // 
            // lblCaseNo
            // 
            this.lblCaseNo.AutoSize = true;
            this.lblCaseNo.Location = new System.Drawing.Point(948, 63);
            this.lblCaseNo.Name = "lblCaseNo";
            this.lblCaseNo.Size = new System.Drawing.Size(53, 13);
            this.lblCaseNo.TabIndex = 8;
            this.lblCaseNo.Text = "Case NO:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DB_Type,
            this.Customer,
            this.DB_Version,
            this.DB_IP,
            this.DB_Port,
            this.DB_SID,
            this.DB_Name,
            this.DB_User,
            this.DB_Password,
            this.DB_Created,
            this.DB_Owner,
            this.SFCase,
            this.AgencyList});
            this.dataGridView1.Location = new System.Drawing.Point(12, 85);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1278, 664);
            this.dataGridView1.TabIndex = 9;
            // 
            // DB_Type
            // 
            this.DB_Type.HeaderText = "DB Type";
            this.DB_Type.Name = "DB_Type";
            this.DB_Type.ReadOnly = true;
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // DB_Version
            // 
            this.DB_Version.HeaderText = "Version";
            this.DB_Version.Name = "DB_Version";
            this.DB_Version.ReadOnly = true;
            // 
            // DB_IP
            // 
            this.DB_IP.HeaderText = "IP";
            this.DB_IP.Name = "DB_IP";
            this.DB_IP.ReadOnly = true;
            // 
            // DB_Port
            // 
            this.DB_Port.HeaderText = "Port";
            this.DB_Port.Name = "DB_Port";
            this.DB_Port.ReadOnly = true;
            // 
            // DB_SID
            // 
            this.DB_SID.HeaderText = "SID";
            this.DB_SID.Name = "DB_SID";
            this.DB_SID.ReadOnly = true;
            // 
            // DB_Name
            // 
            this.DB_Name.HeaderText = "DB Name";
            this.DB_Name.Name = "DB_Name";
            this.DB_Name.ReadOnly = true;
            // 
            // DB_User
            // 
            this.DB_User.HeaderText = "User";
            this.DB_User.Name = "DB_User";
            this.DB_User.ReadOnly = true;
            // 
            // DB_Password
            // 
            this.DB_Password.HeaderText = "Password";
            this.DB_Password.Name = "DB_Password";
            this.DB_Password.ReadOnly = true;
            // 
            // DB_Created
            // 
            this.DB_Created.HeaderText = "Created Date";
            this.DB_Created.Name = "DB_Created";
            this.DB_Created.ReadOnly = true;
            // 
            // DB_Owner
            // 
            this.DB_Owner.HeaderText = "Owner";
            this.DB_Owner.Name = "DB_Owner";
            this.DB_Owner.ReadOnly = true;
            // 
            // SFCase
            // 
            this.SFCase.HeaderText = "SF Case";
            this.SFCase.Name = "SFCase";
            this.SFCase.ReadOnly = true;
            // 
            // AgencyList
            // 
            this.AgencyList.HeaderText = "Agency List";
            this.AgencyList.Name = "AgencyList";
            this.AgencyList.ReadOnly = true;
            // 
            // lblAgencyCode
            // 
            this.lblAgencyCode.AutoSize = true;
            this.lblAgencyCode.Location = new System.Drawing.Point(665, 59);
            this.lblAgencyCode.Name = "lblAgencyCode";
            this.lblAgencyCode.Size = new System.Drawing.Size(74, 13);
            this.lblAgencyCode.TabIndex = 10;
            this.lblAgencyCode.Text = "Agency Code:";
            // 
            // txtAgencyCode
            // 
            this.txtAgencyCode.Location = new System.Drawing.Point(745, 56);
            this.txtAgencyCode.Name = "txtAgencyCode";
            this.txtAgencyCode.Size = new System.Drawing.Size(176, 20);
            this.txtAgencyCode.TabIndex = 11;
            // 
            // txtJIRAKey
            // 
            this.txtJIRAKey.Location = new System.Drawing.Point(1027, 24);
            this.txtJIRAKey.Name = "txtJIRAKey";
            this.txtJIRAKey.Size = new System.Drawing.Size(176, 20);
            this.txtJIRAKey.TabIndex = 12;
            // 
            // lblJIRAKey
            // 
            this.lblJIRAKey.AutoSize = true;
            this.lblJIRAKey.Location = new System.Drawing.Point(948, 31);
            this.lblJIRAKey.Name = "lblJIRAKey";
            this.lblJIRAKey.Size = new System.Drawing.Size(54, 13);
            this.lblJIRAKey.TabIndex = 13;
            this.lblJIRAKey.Text = "JIRA Key:";
            // 
            // btnUnlcokUser
            // 
            this.btnUnlcokUser.Location = new System.Drawing.Point(12, 49);
            this.btnUnlcokUser.Name = "btnUnlcokUser";
            this.btnUnlcokUser.Size = new System.Drawing.Size(75, 23);
            this.btnUnlcokUser.TabIndex = 14;
            this.btnUnlcokUser.Text = "Unlock User";
            this.btnUnlcokUser.UseVisualStyleBackColor = true;
            // 
            // btnResetSEQ
            // 
            this.btnResetSEQ.Location = new System.Drawing.Point(93, 49);
            this.btnResetSEQ.Name = "btnResetSEQ";
            this.btnResetSEQ.Size = new System.Drawing.Size(75, 23);
            this.btnResetSEQ.TabIndex = 15;
            this.btnResetSEQ.Text = "Rest SEQ";
            this.btnResetSEQ.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1209, 53);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 16;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // DBManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 749);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnResetSEQ);
            this.Controls.Add(this.btnUnlcokUser);
            this.Controls.Add(this.lblJIRAKey);
            this.Controls.Add(this.txtJIRAKey);
            this.Controls.Add(this.txtAgencyCode);
            this.Controls.Add(this.lblAgencyCode);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblCaseNo);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtCaseNo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRestPWD);
            this.Controls.Add(this.btnSync);
            this.Name = "DBManager";
            this.Text = "DB Manager";
            this.Load += new System.EventHandler(this.DBManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnRestPWD;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtCaseNo;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblCaseNo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAgencyCode;
        private System.Windows.Forms.TextBox txtAgencyCode;
        private System.Windows.Forms.TextBox txtJIRAKey;
        private System.Windows.Forms.Label lblJIRAKey;
        private System.Windows.Forms.Button btnUnlcokUser;
        private System.Windows.Forms.Button btnResetSEQ;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Port;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_SID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Created;
        private System.Windows.Forms.DataGridViewTextBoxColumn DB_Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn SFCase;
        private System.Windows.Forms.DataGridViewTextBoxColumn AgencyList;
    }
}