using com.smartwork.Models;
using com.smartwork.Proxy;
using com.smartwork.Proxy.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.JiraRestClient;

namespace com.smartwork
{
    public partial class MergeAttchmentFromSalesforce : Form
    {
        public MergeAttchmentFromSalesforce()
        {
            InitializeComponent();
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;
            this.btnMerge.Enabled = false;

            // 1, Construct one case list from the specified case list
            // 1.1 Check if the case list formate is valid or not
            // 1.2 Construct one case list
            string caseIDs = this.txtInputCaseList.Text;
            List<string> caseIdList = new List<string>();

            if (String.IsNullOrEmpty(caseIDs) || caseIDs.Trim().Length == 0)
            {
                // Show one error message "ERROR: Please enter case id"
                (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Please enter case id");

                this.btnSync.Enabled = true;
                this.btnMerge.Enabled = false;

                return;
            }
            else
            {
                (this.MdiParent as MainForm).ShowStatusMessage("");

                string[] caseIDArray = caseIDs.Split(',');
                Regex reg = new Regex(@"\d{2}ACC-\d{5}");
                foreach (string caseId in caseIDArray)
                {
                    if (reg.IsMatch(caseId))
                    {
                        if (!caseIdList.Contains(caseId.Trim()))
                        {
                            caseIdList.Add(caseId.Trim());
                        }
                    }
                    else
                    {
                        // Show one error message "ERROR: Invalid Format for XXXX"
                        (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Invalid Format for " + caseId);

                        this.btnSync.Enabled = true;
                        this.btnMerge.Enabled = false;

                        return;
                    }
                }
            }

            if (caseIdList.Count == 0)
            {
                // Show one error message "ERROR: Please enter case id"
                (this.MdiParent as MainForm).ShowStatusMessage("ERROR: Please enter case id");

                this.btnSync.Enabled = true;
                this.btnMerge.Enabled = false;

                return;
            }

            Dictionary<string, Dictionary<string, AccelaAttachmentMapper>> AttachmentMapper = new Dictionary<string, Dictionary<string, AccelaAttachmentMapper>>();
            var GetCaseAttachmentInfoByID = SalesforceProxy.GetCaseAttachmentInfoByID(caseIdList);
            var GetJiraIssueList = JiraProxy.GetIssueList(caseIdList);

            var CaseAttachments = await GetCaseAttachmentInfoByID;
            foreach (AccelaCase accelaCase in CaseAttachments)
            {
                string caseId = accelaCase.Id;
                string caseNumber = accelaCase.CaseNumber;

                if (!AttachmentMapper.ContainsKey(caseNumber))
                {
                    AttachmentMapper.Add(caseNumber, new Dictionary<string,AccelaAttachmentMapper>());
                }
                
                if (accelaCase.CaseAttachments != null && accelaCase.CaseAttachments.Records.Count > 0)
                {
                    Dictionary<string, AccelaAttachmentMapper> CaseAttachmentDic = AttachmentMapper[caseNumber];

                    foreach (CaseAttachment caseAttachment in accelaCase.CaseAttachments.Records)
                    {
                        string fileName = caseAttachment.Name;

                        var GetUserInfoById = SalesforceProxy.GetUserInfoById(caseAttachment.LastModifiedById);
                        var UserInfo = await GetUserInfoById;

                        if (!CaseAttachmentDic.ContainsKey(fileName))
                        {
                            AccelaAttachmentMapper accelaAttachmentMapper = new AccelaAttachmentMapper();

                            accelaAttachmentMapper.IsMerged = true;
                            accelaAttachmentMapper.CaseId = caseId;
                            accelaAttachmentMapper.CaseNumber = caseNumber;
                            accelaAttachmentMapper.CaseFileName = fileName;
                            accelaAttachmentMapper.CaseAttchmentId = caseAttachment.Id;
                            accelaAttachmentMapper.CaseAttachmentType = caseAttachment.ContentType;
                            accelaAttachmentMapper.CaseIsPrivate = caseAttachment.IsPrivate;
                            accelaAttachmentMapper.UploadedBy = UserInfo.Name;
                            accelaAttachmentMapper.UploadDate = caseAttachment.LastModifiedDate;

                            CaseAttachmentDic.Add(fileName, accelaAttachmentMapper);
                        }
                    }
                }
            }

            var JiraIssueList = await GetJiraIssueList;
            foreach (Issue issue in JiraIssueList)
            {
                IssueRef issueRef = new IssueRef();
                issueRef.id = issue.id;
                issueRef.key = issue.key;

                string caseNumber = issue.fields.customfield_10600;
                if (!AttachmentMapper.ContainsKey(caseNumber))
                {
                    AttachmentMapper.Add(caseNumber, new Dictionary<string, AccelaAttachmentMapper>());
                }

                Dictionary<string, AccelaAttachmentMapper> CaseAttachmentDic = AttachmentMapper[caseNumber];
                if (CaseAttachmentDic != null)
                {
                    foreach (AccelaAttachmentMapper accelaAttachmentMapper in CaseAttachmentDic.Values)
                    {
                        accelaAttachmentMapper.JiraId = issue.id;
                        accelaAttachmentMapper.JiraKey = issue.key;
                    }
                }

                var GetAttachments = JiraProxy.GetAttachments(issueRef);
                var JiraAttachmentList = await GetAttachments;

                if (JiraAttachmentList != null && JiraAttachmentList.Count > 0)
                {
                    foreach (Attachment attachment in JiraAttachmentList)
                    {
                        string fileName = attachment.filename;
                        AccelaAttachmentMapper accelaAttachmentMapper = null;
                        if (CaseAttachmentDic.ContainsKey(fileName))
                        {
                            accelaAttachmentMapper = CaseAttachmentDic[fileName];
                            accelaAttachmentMapper.IsMerged = false;
                        }
                        else
                        {                           
                            accelaAttachmentMapper = new AccelaAttachmentMapper();
                            //accelaAttachmentMapper.CaseId = caseId;
                            accelaAttachmentMapper.CaseNumber = caseNumber;
                        }

                        accelaAttachmentMapper.JiraId = issue.id;
                        accelaAttachmentMapper.JiraKey = issue.key;
                        accelaAttachmentMapper.JiraFileName = fileName;
                        accelaAttachmentMapper.JiraAttachmentId = attachment.id;
                        //CaseAttachmentDic.Add(fileName, accelaAttachmentMapper);
                        CaseAttachmentDic[fileName] = accelaAttachmentMapper;
                    }
                }
            }

            DataTable table = new DataTable("Merge Attachment");
            table.Columns.Add("IsMerged", typeof(bool));
            table.Columns.Add("CaseFileName", typeof(string));
            table.Columns.Add("CaseId", typeof(string));
            table.Columns.Add("CaseNumber", typeof(string));
            table.Columns.Add("CaseAttchmentId", typeof(string));
            table.Columns.Add("CaseAttachmentType", typeof(string));
            table.Columns.Add("CaseIsPrivate", typeof(bool));
            table.Columns.Add("UploadDate", typeof(string));
            table.Columns.Add("UploadedBy", typeof(string));
            table.Columns.Add("JiraFileName", typeof(string));
            table.Columns.Add("JiraId", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("JiraAttachmentId", typeof(string));

            foreach (string caseNumber in AttachmentMapper.Keys)
            {
                Dictionary<string, AccelaAttachmentMapper> CaseAttachmentDic = AttachmentMapper[caseNumber];
                foreach (AccelaAttachmentMapper accelaAttachMapper in CaseAttachmentDic.Values)
                {
                    DataRow row = table.NewRow();
                    row["IsMerged"] = accelaAttachMapper.IsMerged;
                    row["CaseFileName"] = accelaAttachMapper.CaseFileName;
                    row["CaseId"] = accelaAttachMapper.CaseId;
                    row["CaseNumber"] = accelaAttachMapper.CaseNumber;
                    row["CaseAttchmentId"] = accelaAttachMapper.CaseAttchmentId;
                    row["CaseAttachmentType"] = accelaAttachMapper.CaseAttachmentType;
                    row["CaseIsPrivate"] = accelaAttachMapper.CaseIsPrivate;
                    row["UploadDate"] = accelaAttachMapper.UploadDate.ToShortDateString();
                    row["UploadedBy"] = accelaAttachMapper.UploadedBy;
                    row["JiraFileName"] = accelaAttachMapper.JiraFileName;
                    row["JiraId"] = accelaAttachMapper.JiraId;
                    row["JiraKey"] = accelaAttachMapper.JiraKey;
                    row["JiraAttachmentId"] = accelaAttachMapper.JiraAttachmentId;

                    table.Rows.Add(row);
                }
            }

            DataView dataTableView = table.DefaultView;
            dataTableView.Sort = "CaseNumber ASC, UploadDate ASC";
            table = dataTableView.ToTable();

            this.dgdMergeFileList.AutoGenerateColumns = false;
            this.dgdMergeFileList.DataSource = table;
            
            this.btnSync.Enabled = true;
            this.btnMerge.Enabled = true;
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;
            this.btnMerge.Enabled = false;
            
            DataTable dataTable = this.dgdMergeFileList.DataSource as DataTable;

            DataView dataTableView = dataTable.DefaultView;
            dataTableView.Sort = "CaseNumber ASC, UploadDate ASC";
            dataTable = dataTableView.ToTable();

            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                bool IsMerged = false;
                string caseId = "";
                string caseNumber = "";
                string caseAttachmentId = "";
                string caseFileName = "";
                string caseAttchmentId = "";
                string caseAttachmentType = "";
                string uploadedBy = "";
                string uploadDate = "";
                string jiraId = "";
                string jiraKey = "";
                string currentCaseNumber = "";
                string commentMoveFileList = string.Empty;

                IssueRef issueRef = new IssueRef();
                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    IsMerged = bool.Parse(row["IsMerged"].ToString());
                    caseId = row["CaseId"] as string;
                    caseNumber = row["CaseNumber"] as string;
                    caseAttachmentId = row["CaseAttchmentId"] as string;
                    caseFileName = row["CaseFileName"] as string;
                    caseAttchmentId = row["CaseAttchmentId"] as string;
                    caseAttachmentType = row["CaseAttachmentType"] as string;
                    uploadDate = row["UploadDate"] as string;
                    uploadedBy = row["UploadedBy"] as string;
                    jiraId = row["JiraId"] as string;
                    jiraKey = row["JiraKey"] as string;

                    if (!String.IsNullOrEmpty(commentMoveFileList) && currentCaseNumber != caseNumber)
                    {
                        // Upload jira comment
                        commentMoveFileList = "Copy some attachments from salesforce \n------------------------------------------------------------------------\n" + commentMoveFileList;
                        JiraProxy.CreateComment(issueRef, commentMoveFileList);
                        commentMoveFileList = string.Empty;
                    }

                    issueRef.id = jiraId;
                    issueRef.key = jiraKey;

                    if (IsMerged)
                    {
                        byte[] fileStream = SalesforceProxy.GetCaseAttachmentById(caseAttachmentId);                        
                        JiraProxy.UploadAttachment(issueRef, caseFileName, fileStream);

                        commentMoveFileList += "The file : <<" + caseFileName + ">> uploaded by <<" + uploadedBy + ">> on " + uploadDate + "\n";
                    }
                    
                    currentCaseNumber = caseNumber;                    
                }

                if (!String.IsNullOrEmpty(commentMoveFileList))
                {
                    // Upload jira comment
                    commentMoveFileList = "Copy some attachments from salesforce \n------------------------------------------------------------------------\n" + commentMoveFileList;
                    JiraProxy.CreateComment(issueRef, commentMoveFileList);
                    commentMoveFileList = string.Empty;
                }
            }

            this.btnSync.Enabled = true;
            this.btnMerge.Enabled = false;
        }
    }
}
