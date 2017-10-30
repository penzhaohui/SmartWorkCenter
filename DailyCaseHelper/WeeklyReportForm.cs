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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechTalk.JiraRestClient;

namespace com.smartwork
{
    public partial class frmWeeklyReportForm : Form
    {
        public frmWeeklyReportForm()
        {
            InitializeComponent();
            LoadProcessedCase();
        }

        private async void LoadProcessedCase()
        {
            DateTime from = DateUtil.GetWeekFirstDaySun(DateTime.Today);
            DateTime end = DateUtil.GetWeekLastDaySat(DateTime.Today);

            if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                from = DateUtil.GetWeekFirstDaySun(DateTime.Today.AddDays(-7));
                end = DateUtil.GetWeekLastDaySat(DateTime.Today.AddDays(-7));
            }

            this.dtpStartDate.Value = from;

            var caseNoList = await SalesforceProxy.GetProcessedCaseNOs(from, end, "Accela Support Team");
            this.txtInputCaseList.Text = string.Join(",", caseNoList);
        }

        private async void btnGet_Click(object sender, EventArgs e)
        {
            this.btnGet.Enabled = false;

            DateTime starDate = this.dtpStartDate.Value;
            DateTime endDate = starDate.AddDays(6);
            
            // 1. Get new jira tickect count for specified week duration
            GetNewJiraTiketCount(starDate, endDate);

            // 2. Get the existing production bugs count
            GetExistingProductionBugCount();

            // 3. Get the existing case count in eng queue
            GetExistingEngCaseCount();

            // 4. Get the existing case count in engqa queue
            GetExistingEngQACaseCount();

            this.btnGet.Enabled = true;
        }

        /// <summary>
        /// Get new jira tickect count for specified duration
        /// </summary>
        /// <param name="startDate">start date</param>
        /// <param name="endDate">end date</param>
        private async void GetNewJiraTiketCount(DateTime startDate, DateTime endDate)
        {
            int count = 0;

            var GetIssueList = JiraProxy.GetIssueListByCreatedDate(startDate, endDate);
            var issueListTmp = await GetIssueList;
            count = issueListTmp.ToArray().Length;

            this.txtNewJiraTicketCount.Text = "" + count;
        }

        /// <summary>
        /// Get the existing production bug count
        /// </summary>
        private async void GetExistingProductionBugCount()
        {
            int count = 0;
            var GetIssueList = JiraProxy.GetProductionIssueList();
            var issueListTmp = await GetIssueList;
            count = issueListTmp.ToArray().Length;

            this.txtProductionBugCount.Text = "" + count;
        }

        /// <summary>
        /// Get the existing ENG case count
        /// </summary>
        private async void GetExistingEngCaseCount()
        {
            int count = 0;

            var GetTopNNewCaseList = SalesforceProxy.GetTopNNewCaseList(300, true, false, false);
            var issueListTmp = await GetTopNNewCaseList;
            count = issueListTmp.ToArray().Length;

            this.txtEngCaseCount.Text = "" + count;
        }

        /// <summary>
        /// Get the existing ENG QA case count
        /// </summary>
        /// <returns>production bug count</returns>
        private async void GetExistingEngQACaseCount()
        {
            int count = 0;
            var GetTopNNewCaseList = SalesforceProxy.GetTopNNewCaseList(300, false, true, false);
            var issueListTmp = await GetTopNNewCaseList;
            count = issueListTmp.ToArray().Length;

            this.txtEngQACaseCount.Text = "" + count;
        }

        private async void btnSync_Click(object sender, EventArgs e)
        {
            this.btnSync.Enabled = false;
            this.btnSend.Enabled = false;

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
                this.btnSend.Enabled = true;

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
                        this.btnSend.Enabled = true;

                        return;
                    }
                }
            }

            DateTime monday = this.dtpStartDate.Value.AddDays(1);
            DateTime tuesday = monday.AddDays(1);
            DateTime wednesday = tuesday.AddDays(1);
            DateTime thursday = wednesday.AddDays(1);
            DateTime friday = thursday.AddDays(1);
            DateTime saturday = friday.AddDays(1);
            DateTime sunday = saturday.AddDays(1);

            var caseList = new List<AccelaCase>();
            var issueList = new List<Issue>();

            int N = 1;

            Dictionary<string, AccelaCase> SFCaseList = new Dictionary<string, AccelaCase>();
            Dictionary<string, int> SFCaseCommentCounter = new Dictionary<string, int>();

            int mondayCaseCommentCount = 0;
            int tuesdayCaseCommentCount = 0;
            int wednesdayCaseCommentCount = 0;
            int thursdayCaseCommentCount = 0;
            int fridayCaseCommentCount = 0;
            int saturdayCaseCommentCount = 0;
            int sundayCaseCommentCount = 0;

            for (int i = 0; i < caseIdList.Count; )
            {
                List<string> caseIdListTemp = new List<string>();
                for (; i < N * 100 && i < caseIdList.Count; i++)
                {
                    caseIdListTemp.Add(caseIdList[i]);
                }

                N = N + 1;

                var GetCaseList = SalesforceProxy.GetCaseList(caseIdListTemp, true);
                var GetIssueList = JiraProxy.GetIssueList(caseIdListTemp);

                var caseListTmp = await GetCaseList;
                var issueListTmp = await GetIssueList;

                issueList.AddRange(issueListTmp);

                foreach (var caseInfo in caseListTmp)
                {
                    Dictionary<DateTime, string> CommentHistories = new Dictionary<DateTime, string>();

                    if (caseInfo.CaseComments != null && caseInfo.CaseComments.Records != null && caseInfo.CaseComments.Records.Count > 0)
                    {
                        int caseCommentCountor = 0;
                        foreach (CaseComment comment in caseInfo.CaseComments.Records)
                        {
                            if (IsSameday(comment.CreatedDate, monday))
                            {
                                if (!SFCaseList.ContainsKey(caseInfo.CaseNumber))
                                {
                                    caseList.Add(caseInfo);
                                    SFCaseList.Add(caseInfo.CaseNumber, caseInfo);
                                }

                                caseCommentCountor++;
                                mondayCaseCommentCount++;
                                System.Console.WriteLine("[1] " + caseInfo.CaseNumber);
                            }
                            else if (IsSameday(comment.CreatedDate, tuesday))
                            {
                                if (!SFCaseList.ContainsKey(caseInfo.CaseNumber))
                                {
                                    caseList.Add(caseInfo);
                                    SFCaseList.Add(caseInfo.CaseNumber, caseInfo);
                                }

                                caseCommentCountor++;
                                tuesdayCaseCommentCount++;
                                System.Console.WriteLine("[2] " + caseInfo.CaseNumber);
                            }
                            else if (IsSameday(comment.CreatedDate, wednesday))
                            {
                                if (!SFCaseList.ContainsKey(caseInfo.CaseNumber))
                                {
                                    caseList.Add(caseInfo);
                                    SFCaseList.Add(caseInfo.CaseNumber, caseInfo);
                                }

                                caseCommentCountor++;
                                wednesdayCaseCommentCount++;
                                System.Console.WriteLine("[3] " + caseInfo.CaseNumber);
                            }
                            else if (IsSameday(comment.CreatedDate, thursday))
                            {
                                if (!SFCaseList.ContainsKey(caseInfo.CaseNumber))
                                {
                                    caseList.Add(caseInfo);
                                    SFCaseList.Add(caseInfo.CaseNumber, caseInfo);
                                }

                                caseCommentCountor++;
                                thursdayCaseCommentCount++;
                                System.Console.WriteLine("[4] " + caseInfo.CaseNumber);                                
                            }
                            else if (IsSameday(comment.CreatedDate, friday))
                            {
                                if(!SFCaseList.ContainsKey(caseInfo.CaseNumber))
                                {
                                    caseList.Add(caseInfo);
                                    SFCaseList.Add(caseInfo.CaseNumber, caseInfo);
                                }

                                caseCommentCountor++;
                                fridayCaseCommentCount++;
                                System.Console.WriteLine("[5] " + caseInfo.CaseNumber);                                
                            }
                            else if (IsSameday(comment.CreatedDate, saturday))
                            {
                                if (!SFCaseList.ContainsKey(caseInfo.CaseNumber))
                                {
                                    caseList.Add(caseInfo);
                                    SFCaseList.Add(caseInfo.CaseNumber, caseInfo);
                                }

                                caseCommentCountor++;
                                saturdayCaseCommentCount++;
                                System.Console.WriteLine("[6] " + caseInfo.CaseNumber);                                
                            }
                            else if (IsSameday(comment.CreatedDate, sunday))
                            {
                                if (!SFCaseList.ContainsKey(caseInfo.CaseNumber))
                                {
                                    caseList.Add(caseInfo);
                                    SFCaseList.Add(caseInfo.CaseNumber, caseInfo);
                                }

                                caseCommentCountor++;
                                sundayCaseCommentCount++;
                                System.Console.WriteLine("[7] " + caseInfo.CaseNumber);
                            }                          
                        }

                        SFCaseCommentCounter.Add(caseInfo.CaseNumber, caseCommentCountor);
                    }
                }
            }

            this.txtMondayCaseCommentCount.Text = "" + mondayCaseCommentCount;
            this.txtTuesdayCaseCommentCount.Text = "" + tuesdayCaseCommentCount;
            this.txtWednesdayCaseCommentCount.Text = "" + wednesdayCaseCommentCount;
            this.txtThursdayCaseCommentCount.Text = "" + thursdayCaseCommentCount;
            this.txtFridayCaseCommentCount.Text = "" + fridayCaseCommentCount;
            this.txtSaturdayCaseCommentCount.Text = "" + saturdayCaseCommentCount;
            this.txtSundayCaseCommentCount.Text = "" + sundayCaseCommentCount;
            this.txtTotalCaseCommentCount.Text = "" + (mondayCaseCommentCount + tuesdayCaseCommentCount + wednesdayCaseCommentCount + thursdayCaseCommentCount + fridayCaseCommentCount + saturdayCaseCommentCount + sundayCaseCommentCount);

            this.btnSync.Enabled = true;
            this.btnSend.Enabled = true;

            ////////////////////////////////////////////////////////////////

            Dictionary<string, AccelaIssueCaseMapper> JiraMapping = new Dictionary<string, AccelaIssueCaseMapper>();
            foreach (var issue in issueList)
            {
                if (!JiraMapping.ContainsKey(issue.fields.customfield_10600))
                {
                    AccelaIssueCaseMapper accelaIssueCaseMapper = new AccelaIssueCaseMapper();
                    accelaIssueCaseMapper.CaseNumber = issue.fields.customfield_10600;
                    accelaIssueCaseMapper.Assignee = (issue.fields.assignee == null ? "" : issue.fields.assignee.displayName);
                    accelaIssueCaseMapper.AssigneeQA = (issue.fields.customfield_11702 == null ? "" : issue.fields.customfield_11702.displayName);
                    accelaIssueCaseMapper.JiraId = issue.id;
                    accelaIssueCaseMapper.JiraKey = issue.key;
                    accelaIssueCaseMapper.IssueCategory = (issue.fields.customfield_11502 != null && issue.fields.customfield_11502.Count > 0 ? issue.fields.customfield_11502[0].value : "--NONE--");
                    accelaIssueCaseMapper.LastModified = issue.fields.customfield_10903;
                    accelaIssueCaseMapper.Status = issue.fields.status.name;
                    accelaIssueCaseMapper.HotCase = issue.fields.labels.Contains("HotCase");
                    accelaIssueCaseMapper.Missionsky = issue.fields.labels.Contains("Missionsky");
                    accelaIssueCaseMapper.JiraLabels = issue.fields.labels;
                    accelaIssueCaseMapper.AggregateTimeSpent = issue.fields.aggregatetimespent;

                    JiraMapping.Add(accelaIssueCaseMapper.CaseNumber, accelaIssueCaseMapper);
                }
            }

            DataTable table = new DataTable("Daily Report");
            table.Columns.Add("ID", typeof(string));
            table.Columns.Add("No", typeof(int));
            table.Columns.Add("HotCase", typeof(bool));
            table.Columns.Add("Missionsky", typeof(bool));
            table.Columns.Add("JiraLabels", typeof(List<string>));
            table.Columns.Add("ProductForUI", typeof(string));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Solution", typeof(string));
            table.Columns.Add("Orgin", typeof(string));
            table.Columns.Add("OpenDate", typeof(string));
            table.Columns.Add("Severity", typeof(string));
            table.Columns.Add("Rank", typeof(int));
            table.Columns.Add("SalesforceID", typeof(string));
            table.Columns.Add("JiraID", typeof(string));
            table.Columns.Add("JiraKey", typeof(string));
            table.Columns.Add("Type", typeof(string));
            table.Columns.Add("Version", typeof(string));
            table.Columns.Add("Customer", typeof(string));
            table.Columns.Add("Summary", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Reviewer", typeof(string));
            table.Columns.Add("Comments", typeof(string));
            table.Columns.Add("ReopenedCount", typeof(string));
            table.Columns.Add("JiraStatus", typeof(string));
            table.Columns.Add("NextJiraStatus", typeof(string));
            table.Columns.Add("SFQueue", typeof(string));
            table.Columns.Add("SFStatus", typeof(string));
            table.Columns.Add("SFLastModified", typeof(string));
            table.Columns.Add("CaseComment", typeof(CaseComment));
            table.Columns.Add("TargetedRelease", typeof(string));
            table.Columns.Add("BZID", typeof(string));
            table.Columns.Add("IssueCategory", typeof(string));
            table.Columns.Add("Assignee", typeof(string));
            table.Columns.Add("AssigneeQA", typeof(string));
            table.Columns.Add("CaseComments", typeof(List<CaseComment>));
            table.Columns.Add("CaseCommentCount", typeof(int));
            table.Columns.Add("TotalCommentCount", typeof(int));
            table.Columns.Add("Timespent", typeof(double));

            Dictionary<string, string> Reviewers = SalesforceProxy.GetReviewerNamesList();

            int index = 1;
            AccelaIssueCaseMapper tempIssue = null;
            string openDate = "";
            string jiraKey = "";
            string jiraId = "";
            string customer = "";
            string assignee = "";
            int reopenCount = 0;
            string jiaStstus = "";
            string[] Severity = null;
            string temComment = "";
            string lastModifiedDate = "";

            int rank = 0;

            foreach (var caseinfo in caseList)
            {
                tempIssue = null;
                if (JiraMapping.ContainsKey(caseinfo.CaseNumber))
                {
                    tempIssue = JiraMapping[caseinfo.CaseNumber];
                }

                DataRow row = table.NewRow();
                row["ID"] = caseinfo.Id;
                row["No"] = index;
                row["HotCase"] = (tempIssue != null && tempIssue.HotCase);
                row["Missionsky"] = (tempIssue != null && tempIssue.Missionsky);
                row["JiraLabels"] = (tempIssue != null ? tempIssue.JiraLabels : null);
                row["IssueCategory"] = (tempIssue != null ? tempIssue.IssueCategory : null);
                row["Assignee"] = (tempIssue != null ? tempIssue.Assignee : null);
                row["AssigneeQA"] = (tempIssue != null ? tempIssue.AssigneeQA : null);
                //row["HotCase"] = true;
                row["ProductForUI"] = AccelaCaseUtil.AdjustProductName(caseinfo.Product, caseinfo.Solution, caseinfo.Subject, caseinfo.Description);
                row["Product"] = caseinfo.Product;
                row["Solution"] = caseinfo.Solution;
                row["Orgin"] = caseinfo.Origin;
                //openDate = caseinfo.CreatedDate.ToShortDateString();
                openDate = (caseinfo.CreatedDate.Month < 10 ? "0" + caseinfo.CreatedDate.Month : "" + caseinfo.CreatedDate.Month)
                           + "/" + (caseinfo.CreatedDate.Day < 10 ? "0" + caseinfo.CreatedDate.Day : "" + caseinfo.CreatedDate.Day)
                           + "/" + ("" + caseinfo.CreatedDate.Year);

                row["OpenDate"] = openDate;
                Severity = caseinfo.Priority.Split(' ');
                row["Severity"] = Severity[1];

                rank = 0;
                if (!String.IsNullOrEmpty(caseinfo.RankOrder))
                {
                    rank = int.Parse(caseinfo.RankOrder);
                }
                else if (!String.IsNullOrEmpty(caseinfo.ServicesRank))
                {
                    rank = int.Parse(caseinfo.ServicesRank);
                }
                else
                {
                    rank = 0;
                }

                row["Rank"] = rank;

                row["SalesforceID"] = caseinfo.CaseNumber;
                jiraKey = (tempIssue != null ? tempIssue.JiraKey : "");
                jiraId = (tempIssue != null ? tempIssue.JiraId : "");
                row["JiraKey"] = jiraKey;
                row["JiraID"] = jiraId;
                row["Type"] = (String.IsNullOrEmpty(caseinfo.InternalType) ? caseinfo.Type : "Production " + caseinfo.InternalType);
                row["Version"] = caseinfo.CurrentVersion;
                customer = (caseinfo.Customer != null && !String.IsNullOrEmpty(caseinfo.Customer.Name) ? caseinfo.Customer.Name : (caseinfo.Account != null ? caseinfo.Account.Name : ""));
                if (customer.IndexOf("Accela") >= 0 && caseinfo.Account != null && !String.IsNullOrEmpty(caseinfo.Account.Name))
                {
                    customer = caseinfo.Account.Name;
                }

                row["Customer"] = customer;
                row["Summary"] = caseinfo.Subject;
                row["Description"] = caseinfo.Description;
                assignee = (tempIssue != null ? tempIssue.Assignee : "");

                temComment = "";

                //lastModifiedDate = DateTime.Now.Year + "-" + (DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month : "" + DateTime.Now.Month) + "-" + (DateTime.Now.Day < 10 ? "0" + DateTime.Now.Day : "" + DateTime.Now.Day);
                DateTime Yesterday = DateTime.Now.AddDays(-1);
                lastModifiedDate = Yesterday.Year + "-" + Yesterday.Month + "-" + Yesterday.Day;
                if (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null)
                {
                    row["CaseComments"] = caseinfo.CaseComments.Records;
                    row["TotalCommentCount"] = caseinfo.CaseComments.Records.Count;

                    CaseComment comment = caseinfo.CaseComments.Records[0];
                    //lastModifiedDate = comment.CreatedDate.Year + "-" + (comment.CreatedDate.Month < 10 ? "0" + comment.CreatedDate.Month : "" + comment.CreatedDate.Month) + "-" + (comment.CreatedDate.Day < 10 ? "0" + comment.CreatedDate.Day : "" + comment.CreatedDate.Day);
                    if (DateTime.Now.Year != comment.CreatedDate.Year
                        && DateTime.Now.Month != comment.CreatedDate.Month
                        && DateTime.Now.Day != comment.CreatedDate.Day)
                    {
                        lastModifiedDate = comment.CreatedDate.Year + "-" + comment.CreatedDate.Month + "-" + comment.CreatedDate.Day;
                    }

                    row["CaseComment"] = comment;

                    if (!String.IsNullOrEmpty(comment.CommentBody))
                    {
                        if (comment.CommentBody.ToUpper().IndexOf("BUB") > 0)
                        {
                            temComment += "This is a bug.<br>";
                        }

                        if (comment.CommentBody.ToUpper().IndexOf("DEFECT") > 0)
                        {
                            temComment += "This is a defect.<br>";
                        }
                    }

                    if (!String.IsNullOrEmpty(assignee) && comment.CommentBody.ToUpper().Contains(assignee.ToUpper()))
                    {
                    }
                    else
                    {
                        foreach (var key in Reviewers.Keys)
                        {
                            string value = Reviewers[key];
                            string value1 = value.Replace('.', ' ');
                            if (comment.CommentBody.ToUpper().EndsWith(key.ToUpper())
                                || comment.CommentBody.ToUpper().EndsWith(value.ToUpper())
                                || comment.CommentBody.ToUpper().EndsWith(value1.ToUpper()))
                            {
                                assignee = Reviewers[key];
                                break;
                            }
                        }
                    }
                }                

                row["Reviewer"] = assignee;
                row["Comments"] = temComment;
                reopenCount = (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null ? caseinfo.CaseComments.Records.Count - 1 : 0);
                row["ReopenedCount"] = reopenCount;
                jiaStstus = (tempIssue != null ? tempIssue.Status : "");
                row["JiraStatus"] = jiaStstus;
                row["SFQueue"] = caseinfo.Owner.Name;
                row["SFStatus"] = caseinfo.Status;

                bool isCommentedToday = false;
                if (caseinfo.CaseComments != null && caseinfo.CaseComments.Records != null)
                {
                    CaseComment comment = caseinfo.CaseComments.Records[0];

                    isCommentedToday = (comment.CreatedDate.Year == DateTime.Now.Year && comment.CreatedDate.Month == DateTime.Now.Month && comment.CreatedDate.Day == DateTime.Now.Day ? true : false);
                }

                row["NextJiraStatus"] = AccelaCaseUtil.GetNextJIRAStatus(caseinfo.Owner.Name, caseinfo.Status, jiaStstus, isCommentedToday);
                row["SFLastModified"] = lastModifiedDate;
                if (tempIssue != null && String.IsNullOrEmpty(tempIssue.LastModified))
                {
                    System.Console.WriteLine("Last Modified Date is empty");
                }

                row["TargetedRelease"] = caseinfo.TargetedRelease;
                row["BZID"] = caseinfo.BZID;
                row["CaseCommentCount"] = SFCaseCommentCounter[caseinfo.CaseNumber];
                row["Timespent"] = Math.Round((double)tempIssue.AggregateTimeSpent/3600,2);

                table.Rows.Add(row);
                index++;
            }

            grdCaseList.AutoGenerateColumns = false;
            grdCaseList.DataSource = table;
        }

        private bool IsSameday(DateTime createdDate, DateTime comparisionDate)
        {
            if (createdDate.Year == comparisionDate.Year
                && createdDate.Month == comparisionDate.Month
                && createdDate.Day == comparisionDate.Day)
            {
                return true;
            }

            return false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            this.btnSend.Enabled = false;

            string weekyIndicatorSummary = "";
            weekyIndicatorSummary = @"<table cellspacing='1' cellpadding='1' border='0' bgcolor='111111' style='border-collapse:collapse;border-spacing:0;border-left:1px solid #888;border-top:1px solid #888;background:#efefef;'>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>New Jira Ticket Count:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{0}</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Monday:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{5}</td>
                                            </tr>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Production Bug Count:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{1}</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Tuesday:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{6}</td>
                                            </tr>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Eng Case Count:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{2}</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Wednesday:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{7}</td>
                                            </tr>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Eng QA Case Count:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{3}</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Thursday:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{8}</td>
                                            </tr>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Case Comment Count:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{4}</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Friday:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{9}</td>
                                            </tr>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>&nbsp;</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>&nbsp;</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Saturday:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{10}</td>
                                            </tr>
                                            <tr>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>&nbsp;</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>&nbsp;</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>Sunday:</td>
                                                <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{11}</td>
                                            </tr>
                                        </table>";
            weekyIndicatorSummary = String.Format(weekyIndicatorSummary, this.txtNewJiraTicketCount.Text,
                                                                         this.txtProductionBugCount.Text,
                                                                         this.txtEngCaseCount.Text,
                                                                         this.txtEngQACaseCount.Text,
                                                                         this.txtTotalCaseCommentCount.Text,
                                                                         this.txtMondayCaseCommentCount.Text,
                                                                         this.txtTuesdayCaseCommentCount.Text,
                                                                         this.txtWednesdayCaseCommentCount.Text,
                                                                         this.txtThursdayCaseCommentCount.Text,
                                                                         this.txtFridayCaseCommentCount.Text,
                                                                         this.txtSaturdayCaseCommentCount.Text,
                                                                         this.txtSundayCaseCommentCount.Text);


            string weekyCaseSummary = "";
            weekyCaseSummary = @"<table cellspacing='1' cellpadding='1' border='0' bgcolor='111111' style='border-collapse:collapse;border-spacing:0;border-left:1px solid #888;border-top:1px solid #888;background:#efefef;'>
                                    <tr>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>No</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Product</th>                                       
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>SF#</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Jira#</th> 
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Severity</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Rank</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Version</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Type</th>
                                        <th align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Customer</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Orgin</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Open Date</th>    
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Reopened#</th>                                    
                                        <th align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Summary</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Reviewer</th>                                   
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Comments</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Case Comment Count</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Total Case Comment</th>
                                        <th align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;font-weight:bold;background:#ccc;'>Total Time Spent</th>
                                    </tr>";

            DataTable dataTable = grdCaseList.DataSource as DataTable;
            CaseComment caseComment = null;

            if (dataTable != null)
            {
                int rowCount = dataTable.Rows.Count;
                string product = "";
                string caseNumber = "";
                string jiraKey = "";
                string priority = "";
                int rank = 0;
                string buildVersion = "";
                string type = "";
                string summary = "";
                string customer = "";
                string origin = "";
                string description = "";
                string openDate = "";
                string reopenCount = "";
                string assignee = "";
                string jiaStstus = "";
                string caseId = "";
                string comment = "";
                string caseCommentBody = "";                
                double CaseCommentCount = 0.0;
                double TotalCommentCount = 0.0;
                double TotalTimespent = 0.0;

                for (int i = 0; i < rowCount; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    product = row["ProductForUI"] as string;
                    caseNumber = row["SalesforceID"] as string;
                    jiraKey = row["JiraKey"] as string;
                    priority = row["Severity"] as string;
                    rank = (int)row["Rank"];
                    buildVersion = row["Version"] as string;
                    type = row["IssueCategory"] as string;
                    if (String.IsNullOrEmpty(type))
                    {
                        //type = row["Type"] as string;
                        type = "";
                    }
                    customer = row["Customer"] as string;
                    origin = row["Orgin"] as string;
                    openDate = row["OpenDate"] as string;
                    reopenCount = row["ReopenedCount"] as string;
                    summary = row["Summary"] as string;
                    assignee = row["Reviewer"] as string;
                    jiaStstus = row["JiraStatus"] as string;
                    description = row["Description"] as string;
                    comment = row["Comments"] as string;
                    caseId = row["ID"] as string;

                    caseComment = row["CaseComment"] as CaseComment;
                    caseCommentBody = (caseComment != null ? caseComment.CommentBody : "");
                    
                    CaseCommentCount = (int)row["CaseCommentCount"];
                    TotalCommentCount = (int)row["TotalCommentCount"];
                    TotalTimespent = (double)row["Timespent"];

                    weekyCaseSummary += String.Format(@"<tr>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{0}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{1}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://na26.salesforce.com/{14}'><font style='{15}'>{2}</font></a></td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'><a href='https://accelaeng.atlassian.net/browse/{3}'>{3}</a></td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{4}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{16}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{5}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{6}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{7}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{8}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{9}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{10}</td>
                                                        <td align='left' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{11}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{12}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{13}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{17}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{18}</td>
                                                        <td align='center' style='border-right:1px solid #888;border-bottom:1px solid #888;padding:1px 10px;'>{19}h</td>
                                                    </tr>",
                                                       (i + 1),         // 0
                                                       product,         // 1
                                                       caseNumber,      // 2
                                                       jiraKey,         // 3
                                                       priority,        // 4
                                                       buildVersion,
                                                       type,
                                                       customer,
                                                       origin,
                                                       openDate,
                                                       reopenCount,
                                                       summary,
                                                       assignee,
                        //jiaStstus,
                                                       comment,
                                                       caseId,
                                                       "", //(isNeedDoubleReview ? "font-weight:bold;font-style:italic;color:red" : "color:green")
                                                       (rank == 0 ? "" : "" + rank),
                                                       CaseCommentCount,
                                                       TotalCommentCount,
                                                       TotalTimespent
                                                       );
                }
            }
            weekyCaseSummary += "</table>";

            string content = @"Hi All,<br/><br/>Below is the Weekly Case Review Summary report. Please kindly let us know if you have any further question.<br/><br/>" + weekyIndicatorSummary + "<br/><br/>" + weekyCaseSummary + "<br/><br/>Thanks<br/>Accela Support Team";
            string from = "auto_sender@missionsky.com";
            string to = "peter.peng@missionsky.com;leo.liu@missionsky.com;louis.he@missionsky.com";
            string cc = "accela-support-team@missionsky.com";

            string subject = "Weekly Case Review Summary - " + DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;

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
