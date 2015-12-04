namespace com.smartwork
{
    partial class DailyCaseImportorFromExcel
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.grdTodayCaseList = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesforceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Version = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Summary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reviewer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReopenedCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTodayCaseList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(904, 95);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 15;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(904, 53);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 14;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // grdTodayCaseList
            // 
            this.grdTodayCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTodayCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.No,
            this.Product,
            this.OpenDate,
            this.Severity,
            this.SalesforceID,
            this.JiraID,
            this.Version,
            this.Customer,
            this.Summary,
            this.Reviewer,
            this.Comments,
            this.ReopenedCount,
            this.Status});
            this.grdTodayCaseList.Location = new System.Drawing.Point(24, 200);
            this.grdTodayCaseList.Name = "grdTodayCaseList";
            this.grdTodayCaseList.Size = new System.Drawing.Size(996, 510);
            this.grdTodayCaseList.TabIndex = 13;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // OpenDate
            // 
            this.OpenDate.HeaderText = "Open Date";
            this.OpenDate.Name = "OpenDate";
            this.OpenDate.ReadOnly = true;
            // 
            // Severity
            // 
            this.Severity.HeaderText = "Severity";
            this.Severity.Name = "Severity";
            this.Severity.ReadOnly = true;
            // 
            // SalesforceID
            // 
            this.SalesforceID.HeaderText = "Salesforce ID";
            this.SalesforceID.Name = "SalesforceID";
            this.SalesforceID.ReadOnly = true;
            // 
            // JiraID
            // 
            this.JiraID.HeaderText = "Jira ID";
            this.JiraID.Name = "JiraID";
            // 
            // Version
            // 
            this.Version.HeaderText = "Version";
            this.Version.Name = "Version";
            // 
            // Customer
            // 
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // Summary
            // 
            this.Summary.HeaderText = "Summary";
            this.Summary.Name = "Summary";
            this.Summary.ReadOnly = true;
            // 
            // Reviewer
            // 
            this.Reviewer.HeaderText = "Reviewer";
            this.Reviewer.Name = "Reviewer";
            this.Reviewer.ReadOnly = true;
            // 
            // Comments
            // 
            this.Comments.HeaderText = "Comments";
            this.Comments.Name = "Comments";
            this.Comments.ReadOnly = true;
            // 
            // ReopenedCount
            // 
            this.ReopenedCount.HeaderText = "Reopened Times";
            this.ReopenedCount.Name = "ReopenedCount";
            this.ReopenedCount.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(24, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 164);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Import Daily Case From Local .exls File";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(305, 23);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Load File List";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(19, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(280, 134);
            this.listBox1.TabIndex = 0;
            // 
            // DailyCaseImportorFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 720);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.grdTodayCaseList);
            this.Controls.Add(this.groupBox1);
            this.Name = "DailyCaseImportorFromExcel";
            this.Text = "Daily Case Importor From Excel";
            ((System.ComponentModel.ISupportInitialize)(this.grdTodayCaseList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView grdTodayCaseList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn OpenDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesforceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn JiraID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Version;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Summary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reviewer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReopenedCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1;
    }
}