using com.smartwork.Models;
using com.smartwork.Proxy;
using com.smartwork.Proxy.models;
using com.smartwork.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.JiraRestClient;

namespace com.smartwork
{
    public partial class DeliveryProgressReportForm : Form
    {
        static Dictionary<string, List<AccelaIssueCaseMapper>> dicDeliveryCaseMapper = new Dictionary<string, List<AccelaIssueCaseMapper>>();

        public DeliveryProgressReportForm()
        {
            InitializeComponent();
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;

            var jiraLabels = this.txtLabelList.Text;

            if (jiraLabels.Trim().Length == 0)
            {
                MessageBox.Show("Please enter some jira labels related release version like 9.0.4");
                this.btnSync.Enabled = true;
                return;
            }

            dicDeliveryCaseMapper.Clear();

            string[] jiraLabelList = jiraLabels.Split(',');
           
            foreach(string label in jiraLabelList)
            {
                if (String.IsNullOrEmpty(label) || String.IsNullOrWhiteSpace(label))
                {
                    continue;
                }

                var GetIssueList = JiraProxy.GetIssueListByLabel(label);
                var issueList = await GetIssueList;

                if (issueList == null || issueList.Count == 0)
                {
                    continue;
                }

                List<AccelaIssueCaseMapper> jiraIssues = dicDeliveryCaseMapper.ContainsKey(label) ? dicDeliveryCaseMapper[label] : new List<AccelaIssueCaseMapper>();

                foreach (var issue in issueList)
                {
                    if (issue == null) continue;

                    AccelaIssueCaseMapper issueMapper = new AccelaIssueCaseMapper();

                    // Product
                    issueMapper.SFProduct = issue.fields.customfield_10904;
                    // Jira Key
                    issueMapper.JiraKey = issue.key;
                    // Salesforce ID
                    issueMapper.CaseNumber = issue.fields.customfield_10600;
                    // Customer
                    issueMapper.SFCustomer = issue.fields.customfield_10900;
                    // Summary
                    issueMapper.Description = issue.fields.summary;
                    // Type
                    issueMapper.IssueType = (issue.fields.issueType == null ? "" : issue.fields.issueType.name);
                    // Severity
                    issueMapper.Priority = (issue.fields.Priority == null ? "" : issue.fields.Priority.name);
                    // Fix Version
                    issueMapper.FixVersions = new List<string>();
                    if (issue.fields.fixVersions != null)
                    {
                        foreach (var fixVersion in issue.fields.fixVersions)
                        {
                            if (fixVersion == null) continue;

                            issueMapper.FixVersions.Add(fixVersion.name);
                        }

                        issueMapper.FixVersions.Sort();
                    }
                    // Jira Status
                    issueMapper.Status = (issue.fields.status == null ? "" : issue.fields.status.name);
                    // Assignee(Dev)
                    issueMapper.Assignee = (issue.fields.assignee == null ? "" : issue.fields.assignee.displayName);
                    // Assignee(QA)
                    issueMapper.AssigneeQA = (issue.fields.customfield_11702 == null ? "" : issue.fields.customfield_11702.displayName);

                    List<Comment> comments = new List<Comment>();

                    if (this.chkRootCause.Checked
                        || this.chkSolution.Checked
                        || this.chkImpactArea.Checked)
                    {
                        if ("ENGSUPP-12597".Equals(issue.key))
                        {
                            System.Console.WriteLine("" + issue.key);
                        }

                        var Comments = await JiraProxy.GetComments(issue);
                        foreach (var comment in Comments)
                        {
                            if (this.chkRootCause.Checked
                                && comment.body.Contains("Root Cause"))
                            {
                                comments.Add(comment);
                                continue;
                            }

                            if (this.chkSolution.Checked
                                && comment.body.Contains("Solution"))
                            {
                                comments.Add(comment);
                                continue;
                            }

                            if (this.chkImpactArea.Checked
                                && comment.body.Contains("Impact Area"))
                            {
                                comments.Add(comment);
                                continue;
                            }
                        }
                    }

                    issueMapper.Comments = comments;
                    issueMapper.ReleaseNote = issue.fields.customfield_11500;

                    jiraIssues.Add(issueMapper);

                }

                dicDeliveryCaseMapper[label] = jiraIssues;                
            }

            DataTable table = new DataTable("Delivery Progress Report");
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("SalesforceID", typeof(string));
            table.Columns.Add("Customer", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("IssueType", typeof(string));
            table.Columns.Add("Severity", typeof(string));
            table.Columns.Add("FixVersions", typeof(List<string>));
            table.Columns.Add("FixVersionsForUI", typeof(string));
            table.Columns.Add("JiraStatus", typeof(string));
            table.Columns.Add("AssigneeDev", typeof(string));
            table.Columns.Add("AssigneeQA", typeof(string));
            table.Columns.Add("Comments", typeof(List<Comment>));
            table.Columns.Add("CemmentCount", typeof(int));
            table.Columns.Add("ReleaseNote", typeof(string));

            int index = 1;
            int labelIndex = 1;
            foreach (string versionLabel in jiraLabelList)
            {
                if (String.IsNullOrEmpty(versionLabel) || String.IsNullOrWhiteSpace(versionLabel))
                {
                    continue;
                }

                List<AccelaIssueCaseMapper> jiraIssueList = dicDeliveryCaseMapper.ContainsKey(versionLabel) ? dicDeliveryCaseMapper[versionLabel] : new List<AccelaIssueCaseMapper>();
                if (jiraIssueList.Count == 0)
                {
                    continue;
                }

                foreach (AccelaIssueCaseMapper jiraIssue in jiraIssueList)
                {
                    DataRow row = table.NewRow();
                    row["No"] = index++;
                    row["Product"] = jiraIssue.SFProduct;
                    row["JiraKey"] = jiraIssue.JiraKey;
                    row["SalesforceID"] = jiraIssue.CaseNumber;
                    row["Customer"] = jiraIssue.SFCustomer;
                    row["Description"] = jiraIssue.Description;
                    row["IssueType"] = jiraIssue.IssueType;
                    row["Severity"] = jiraIssue.Priority;
                    row["FixVersions"] = jiraIssue.FixVersions;
                    
                    string fixVersionsForUI = String.Empty;
                    foreach(string versionUI in jiraIssue.FixVersions)
                    {
                        if (String.IsNullOrEmpty(fixVersionsForUI)) fixVersionsForUI = versionUI;
                        else fixVersionsForUI += "," + versionUI;
                    }
                    row["FixVersionsForUI"] = fixVersionsForUI;

                    row["JiraStatus"] = jiraIssue.Status;
                    row["AssigneeDev"] = jiraIssue.Assignee;
                    row["AssigneeQA"] = jiraIssue.AssigneeQA;
                    row["Comments"] = jiraIssue.Comments;
                    row["CemmentCount"] = jiraIssue.Comments.Count;
                    row["ReleaseNote"] = jiraIssue.ReleaseNote;

                    table.Rows.Add(row);
                }

                if (labelIndex < jiraLabelList.Length)
                {
                    labelIndex++;
                    table.Rows.Add(table.NewRow());
                }
            }

            //DataView dataTableView = table.DefaultView;
            //dataTableView.Sort = "Severity ASC";
            //table = dataTableView.ToTable();

            grdCaseList.AutoGenerateColumns = false;
            grdCaseList.DataSource = table;

            this.btnSync.Enabled = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.btnSend.Enabled = false;

            if (dicDeliveryCaseMapper == null)
            {
                MessageBox.Show("No data! Please click Sync button first.");
                this.btnSend.Enabled = true;
                return;
            }

            string deliveryProgressReport = "";
            deliveryProgressReport = @"<table cellspacing='1' cellpadding='1' border='0' bgcolor='111111' style='border-collapse:collapse;border-spacing:0;border-left:1px solid #888;border-top:1px solid #888;background:#efefef;'>
                                    <tr>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>No</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Product</th>                                       
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Jira Key</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>SF ID</th> 
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Customer</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Description</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Type</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Severity</th>
                                        <th align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Fix Version</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Jira Status</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Assignee Dev</th>    
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Assignee QA</th> 
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Root Cause/Solution/Impact Area</th> 
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Release Notes</th> 
                                    </tr>";


            List<string> uniqueJiraKeys = new List<string>();
            foreach (string versionLabel in dicDeliveryCaseMapper.Keys)
            {
                List<AccelaIssueCaseMapper> jiraIssues = dicDeliveryCaseMapper[versionLabel];
                int no = 1;
                string product = "";
                string jiraKey = "";
                string jiraId = "";                
                string sfid = "";
                string customer = "";
                string description = "";
                string issueType = "";
                string severity = "";
                string fixVersion = "";
                string status = "";
                string assigneeDev = "";
                string assigneeQA = "";

                int totalCount = jiraIssues.Count;
                int resolvedCount = 0;
                int closedCount = 0;
                string detailedInfo = "";
                string releaseNote = "";
               
                foreach(AccelaIssueCaseMapper jiraIssue in jiraIssues)
                {
                    product = jiraIssue.SFProduct;
                    jiraKey = jiraIssue.JiraKey;
                    sfid = jiraIssue.CaseNumber;
                    customer = jiraIssue.SFCustomer;
                    description = jiraIssue.Description;
                    issueType = jiraIssue.IssueType;
                    severity = jiraIssue.Priority;
                    releaseNote = jiraIssue.ReleaseNote;

                    string fixVersionsForUI = String.Empty;
                    foreach (string versionUI in jiraIssue.FixVersions)
                    {
                        if (String.IsNullOrEmpty(fixVersionsForUI)) fixVersionsForUI = versionUI;
                        else fixVersionsForUI += "," + versionUI;
                    }
                    fixVersion = fixVersionsForUI;

                    status = jiraIssue.Status;
                    assigneeDev = jiraIssue.Assignee;
                    assigneeQA = jiraIssue.AssigneeQA;

                    if ("Resolved".Equals(status, StringComparison.InvariantCultureIgnoreCase))
                    {
                        resolvedCount++;
                    }

                    if ("Closed".Equals(status, StringComparison.InvariantCultureIgnoreCase))
                    {
                        closedCount++;
                    }

                    List<Comment> comments = jiraIssue.Comments;
                    string commentStr = "";
                    if (this.chkRootCause.Checked
                        || this.chkSolution.Checked
                        || this.chkImpactArea.Checked)
                    {
                        int index = 1;
                        foreach (var comment in comments)
                        {
                            commentStr += index++ + ". ------------------------------------------------<br/>";
                            commentStr += comment.body.Replace("\r\n", "<br/>") + "<br/><br/>";
                        }
                    }

                    if (uniqueJiraKeys.Contains(jiraKey))
                    {
                        detailedInfo += String.Format(@"<tr bgcolor='red'>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{0}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{1}</td>                                                        
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://accelaeng.atlassian.net/browse/{2}'>{2}</a></td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{3}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{4}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{5}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{6}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{7}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{8}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{9}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{10}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{11}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{12}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{13}</td>
                                                    </tr>",
                                                          no++,
                                                          product,
                                                          jiraKey,
                                                          sfid,
                                                          customer,
                                                          description,
                                                          issueType,
                                                          severity,
                                                          fixVersion,
                                                          status,
                                                          assigneeDev,
                                                          assigneeQA,
                                                          commentStr,
                                                          releaseNote
                                                           );
                    }
                    else
                    {
                        uniqueJiraKeys.Add(jiraKey);

                        detailedInfo += String.Format(@"<tr>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{0}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{1}</td>                                                        
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://accelaeng.atlassian.net/browse/{2}'>{2}</a></td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{3}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{4}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{5}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{6}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{7}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{8}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{9}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{10}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{11}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{12}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{13}</td>
                                                    </tr>",
                                                          no++,
                                                          product,
                                                          jiraKey,
                                                          sfid,
                                                          customer,
                                                          description,
                                                          issueType,
                                                          severity,
                                                          fixVersion,
                                                          status,
                                                          assigneeDev,
                                                          assigneeQA,
                                                          commentStr,
                                                          releaseNote
                                                           );
                    }
                }

                deliveryProgressReport += "<tr><td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;' colspan='14'> Jira Version Label: "
                    + versionLabel + " [Target Date: XX/XX/XXXX] - Total: " + totalCount 
                    + " items; QA Verified: " + closedCount 
                    + " Items, Dev Resolved: " + resolvedCount 
                    + " items, Development In Progress: " + (totalCount - closedCount - resolvedCount) + " items </td></tr>";
                deliveryProgressReport += detailedInfo;
                
            }

            deliveryProgressReport += "</table>";

            string content = @"Hi All,<br/><br/>Below is the current delivery progress report. Please kindly let us know if you have any further question.<br/><br/>" + deliveryProgressReport + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";            
            string to = "peter.peng@missionsky.com;trancy.zhai@missionsky.com;";
            string cc = "accela-support-team@missionsky.com";

            string subject = "Delivery Progress Summary - " + this.txtLabelList.Text;

            try
            {
                EmailUtil.SendEmail(from, to, cc, subject, content);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to send email");
            }

            this.btnSend.Enabled = true;
        }
    }
}
