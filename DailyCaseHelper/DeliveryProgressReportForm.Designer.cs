﻿namespace com.smartwork
{
    partial class DeliveryProgressReportForm
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
            this.grdCaseList = new System.Windows.Forms.DataGridView();
            this.grbJiraLabelList = new System.Windows.Forms.GroupBox();
            this.chkRootCause = new System.Windows.Forms.CheckBox();
            this.chkSolution = new System.Windows.Forms.CheckBox();
            this.chkImpactArea = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.txtLabelList = new System.Windows.Forms.TextBox();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JiraKey = new System.Windows.Forms.DataGridViewLinkColumn();
            this.SalesforceID = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Severity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FixVersionsForUI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssigneeDev = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssigneeQA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CemmentCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReleaseNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).BeginInit();
            this.grbJiraLabelList.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCaseList
            // 
            this.grdCaseList.AllowUserToAddRows = false;
            this.grdCaseList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCaseList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.Product,
            this.JiraKey,
            this.SalesforceID,
            this.Customer,
            this.Description,
            this.Type,
            this.Severity,
            this.FixVersionsForUI,
            this.Status,
            this.AssigneeDev,
            this.AssigneeQA,
            this.CemmentCount,
            this.ReleaseNote});
            this.grdCaseList.Location = new System.Drawing.Point(12, 129);
            this.grdCaseList.Name = "grdCaseList";
            this.grdCaseList.Size = new System.Drawing.Size(1284, 611);
            this.grdCaseList.TabIndex = 19;
            // 
            // grbJiraLabelList
            // 
            this.grbJiraLabelList.Controls.Add(this.chkRootCause);
            this.grbJiraLabelList.Controls.Add(this.chkSolution);
            this.grbJiraLabelList.Controls.Add(this.chkImpactArea);
            this.grbJiraLabelList.Controls.Add(this.btnSend);
            this.grbJiraLabelList.Controls.Add(this.btnSync);
            this.grbJiraLabelList.Controls.Add(this.txtLabelList);
            this.grbJiraLabelList.Location = new System.Drawing.Point(12, 12);
            this.grbJiraLabelList.Name = "grbJiraLabelList";
            this.grbJiraLabelList.Size = new System.Drawing.Size(1284, 100);
            this.grbJiraLabelList.TabIndex = 20;
            this.grbJiraLabelList.TabStop = false;
            this.grbJiraLabelList.Text = "Please enter the jira label list like Label1, Label2";
            // 
            // chkRootCause
            // 
            this.chkRootCause.AutoSize = true;
            this.chkRootCause.Location = new System.Drawing.Point(1168, 21);
            this.chkRootCause.Name = "chkRootCause";
            this.chkRootCause.Size = new System.Drawing.Size(82, 17);
            this.chkRootCause.TabIndex = 21;
            this.chkRootCause.Text = "Root Cause";
            this.chkRootCause.UseVisualStyleBackColor = true;
            // 
            // chkSolution
            // 
            this.chkSolution.AutoSize = true;
            this.chkSolution.Location = new System.Drawing.Point(1168, 49);
            this.chkSolution.Name = "chkSolution";
            this.chkSolution.Size = new System.Drawing.Size(64, 17);
            this.chkSolution.TabIndex = 4;
            this.chkSolution.Text = "Solution";
            this.chkSolution.UseVisualStyleBackColor = true;
            // 
            // chkImpactArea
            // 
            this.chkImpactArea.AutoSize = true;
            this.chkImpactArea.Location = new System.Drawing.Point(1168, 77);
            this.chkImpactArea.Name = "chkImpactArea";
            this.chkImpactArea.Size = new System.Drawing.Size(83, 17);
            this.chkImpactArea.TabIndex = 3;
            this.chkImpactArea.Text = "Impact Area";
            this.chkImpactArea.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(533, 19);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 75);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(452, 19);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(75, 75);
            this.btnSync.TabIndex = 1;
            this.btnSync.Text = "Sync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // txtLabelList
            // 
            this.txtLabelList.Location = new System.Drawing.Point(6, 19);
            this.txtLabelList.Multiline = true;
            this.txtLabelList.Name = "txtLabelList";
            this.txtLabelList.Size = new System.Drawing.Size(440, 75);
            this.txtLabelList.TabIndex = 0;
            // 
            // No
            // 
            this.No.DataPropertyName = "No";
            this.No.HeaderText = "No";
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 50;
            // 
            // Product
            // 
            this.Product.DataPropertyName = "Product";
            this.Product.HeaderText = "Product";
            this.Product.Name = "Product";
            this.Product.ReadOnly = true;
            // 
            // JiraKey
            // 
            this.JiraKey.DataPropertyName = "JiraKey";
            this.JiraKey.HeaderText = "Jira Key";
            this.JiraKey.Name = "JiraKey";
            this.JiraKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.JiraKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SalesforceID
            // 
            this.SalesforceID.DataPropertyName = "SalesforceID";
            this.SalesforceID.HeaderText = "Salesforce ID";
            this.SalesforceID.Name = "SalesforceID";
            this.SalesforceID.ReadOnly = true;
            this.SalesforceID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SalesforceID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Customer
            // 
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.Name = "Customer";
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "IssueType";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Severity
            // 
            this.Severity.DataPropertyName = "Severity";
            this.Severity.HeaderText = "Severity";
            this.Severity.Name = "Severity";
            this.Severity.ReadOnly = true;
            // 
            // FixVersionsForUI
            // 
            this.FixVersionsForUI.DataPropertyName = "FixVersionsForUI";
            this.FixVersionsForUI.HeaderText = "Fix Version";
            this.FixVersionsForUI.Name = "FixVersionsForUI";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "JiraStatus";
            this.Status.HeaderText = "Jira Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // AssigneeDev
            // 
            this.AssigneeDev.DataPropertyName = "AssigneeDev";
            this.AssigneeDev.HeaderText = "Assignee(Dev)";
            this.AssigneeDev.Name = "AssigneeDev";
            this.AssigneeDev.ReadOnly = true;
            // 
            // AssigneeQA
            // 
            this.AssigneeQA.DataPropertyName = "AssigneeQA";
            this.AssigneeQA.HeaderText = "Assignee(QA)";
            this.AssigneeQA.Name = "AssigneeQA";
            this.AssigneeQA.ReadOnly = true;
            // 
            // CemmentCount
            // 
            this.CemmentCount.DataPropertyName = "CemmentCount";
            this.CemmentCount.HeaderText = "Cemment Count";
            this.CemmentCount.Name = "CemmentCount";
            this.CemmentCount.ReadOnly = true;
            this.CemmentCount.Width = 150;
            // 
            // ReleaseNote
            // 
            this.ReleaseNote.DataPropertyName = "ReleaseNote";
            this.ReleaseNote.HeaderText = "ReleaseNote";
            this.ReleaseNote.Name = "ReleaseNote";
            // 
            // DeliveryProgressReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 752);
            this.ControlBox = false;
            this.Controls.Add(this.grbJiraLabelList);
            this.Controls.Add(this.grdCaseList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeliveryProgressReportForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Delivery Progress Report";
            ((System.ComponentModel.ISupportInitialize)(this.grdCaseList)).EndInit();
            this.grbJiraLabelList.ResumeLayout(false);
            this.grbJiraLabelList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdCaseList;
        private System.Windows.Forms.GroupBox grbJiraLabelList;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.TextBox txtLabelList;
        private System.Windows.Forms.CheckBox chkImpactArea;
        private System.Windows.Forms.CheckBox chkRootCause;
        private System.Windows.Forms.CheckBox chkSolution;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewLinkColumn JiraKey;
        private System.Windows.Forms.DataGridViewLinkColumn SalesforceID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Severity;
        private System.Windows.Forms.DataGridViewTextBoxColumn FixVersionsForUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssigneeDev;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssigneeQA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CemmentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReleaseNote;
    }
}