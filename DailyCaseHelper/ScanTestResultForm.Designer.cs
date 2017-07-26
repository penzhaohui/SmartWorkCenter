namespace com.smartwork
{
    partial class ScanTestResultForm
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
            this.grpEnterTestRunUrl = new System.Windows.Forms.GroupBox();
            this.lblTestRunUrl = new System.Windows.Forms.Label();
            this.txtTestRunUrl = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSyncToJira = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JIRAKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssigneeQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssigneeDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpEnterTestRunUrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpEnterTestRunUrl
            // 
            this.grpEnterTestRunUrl.Controls.Add(this.btnSend);
            this.grpEnterTestRunUrl.Controls.Add(this.btnSyncToJira);
            this.grpEnterTestRunUrl.Controls.Add(this.btnScan);
            this.grpEnterTestRunUrl.Controls.Add(this.txtTestRunUrl);
            this.grpEnterTestRunUrl.Controls.Add(this.lblTestRunUrl);
            this.grpEnterTestRunUrl.Location = new System.Drawing.Point(12, 12);
            this.grpEnterTestRunUrl.Name = "grpEnterTestRunUrl";
            this.grpEnterTestRunUrl.Size = new System.Drawing.Size(1283, 69);
            this.grpEnterTestRunUrl.TabIndex = 0;
            this.grpEnterTestRunUrl.TabStop = false;
            this.grpEnterTestRunUrl.Text = "Please enter the url of one specified test run";
            // 
            // lblTestRunUrl
            // 
            this.lblTestRunUrl.AutoSize = true;
            this.lblTestRunUrl.Location = new System.Drawing.Point(17, 32);
            this.lblTestRunUrl.Name = "lblTestRunUrl";
            this.lblTestRunUrl.Size = new System.Drawing.Size(79, 13);
            this.lblTestRunUrl.TabIndex = 0;
            this.lblTestRunUrl.Text = "Test Run URL:";
            // 
            // txtTestRunUrl
            // 
            this.txtTestRunUrl.Location = new System.Drawing.Point(103, 28);
            this.txtTestRunUrl.Name = "txtTestRunUrl";
            this.txtTestRunUrl.Size = new System.Drawing.Size(376, 20);
            this.txtTestRunUrl.TabIndex = 1;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(485, 25);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Product,
            this.JIRAKey,
            this.Title,
            this.AssigneeQA,
            this.AssigneeDev,
            this.Status});
            this.dataGridView1.Location = new System.Drawing.Point(12, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1283, 627);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnSyncToJira
            // 
            this.btnSyncToJira.Location = new System.Drawing.Point(566, 25);
            this.btnSyncToJira.Name = "btnSyncToJira";
            this.btnSyncToJira.Size = new System.Drawing.Size(75, 23);
            this.btnSyncToJira.TabIndex = 3;
            this.btnSyncToJira.Text = "Sync to Jira";
            this.btnSyncToJira.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(647, 25);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.Width = 50;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.Width = 120;
            // 
            // JIRAKey
            // 
            this.JIRAKey.HeaderText = "JIRA Key";
            this.JIRAKey.Name = "JIRAKey";
            // 
            // Title
            // 
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.Width = 570;
            // 
            // AssigneeQA
            // 
            this.AssigneeQA.HeaderText = "AssigneeQA";
            this.AssigneeQA.Name = "AssigneeQA";
            this.AssigneeQA.Width = 150;
            // 
            // AssigneeDev
            // 
            this.AssigneeDev.HeaderText = "AssigneeDev";
            this.AssigneeDev.Name = "AssigneeDev";
            this.AssigneeDev.Width = 150;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // ScanTestResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 753);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.grpEnterTestRunUrl);
            this.Name = "ScanTestResultForm";
            this.Text = "Scan Test Result Form";
            this.grpEnterTestRunUrl.ResumeLayout(false);
            this.grpEnterTestRunUrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpEnterTestRunUrl;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.TextBox txtTestRunUrl;
        private System.Windows.Forms.Label lblTestRunUrl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSyncToJira;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn JIRAKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssigneeQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssigneeDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}