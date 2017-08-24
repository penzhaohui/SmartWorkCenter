using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;

namespace com.smartwork.Proxy
{
    // http://stackoverflow.com/questions/31079195/adding-a-new-case-comment-via-salesforce-api-c-sharp
    public class JiraProxy
    {
        public static async Task<List<Issue>> GetIssueList(List<string> caseIdList)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "(";
            bool isFirstOne = true;
            foreach(string caseId in caseIdList)
            {
                if(isFirstOne) 
                {
                    sql += " \"SalesForce ID\" ~  " + caseId;
                    isFirstOne = false;
                }
                else
                {
                    sql += " OR \"SalesForce ID\" ~  " + caseId;
                }                
            }
            sql += ")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public static async Task<Issue> GetIssueByID(string project, string type, string caseId)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "(";
            sql += " \"SalesForce ID\" ~  " + caseId;
            sql += ")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery(project, type, sql);

            foreach (Issue issue in issues)
            {
                if (issue != null)
                {
                    return issue;
                }
            }

            return null;
        }

        public static async Task<Issue> GetDatabaseTaskByID(string project, string type, string id)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "(";
            sql += " \"key\" =  " + id;
            sql += ")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery(project, type, sql);

            foreach (Issue issue in issues)
            {
                if (issue != null)
                {
                    return issue;
                }
            }

            return null;
        }

        public static async Task<Issue> GetDatabaseTaskByCaseID(string project, string type, string caseid)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "(";
            sql += " \"summary\" ~ " + caseid;
            sql += ")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery(project, type, sql);

            foreach (Issue issue in issues)
            {
                if (issue != null)
                {
                    return issue;
                }
            }

            return null;
        }

        public static async Task<Issue> GetDatabaseTaskByCustomerID(string project, string type, string customer)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "(";
            sql += " created >= -15d AND summary ~ \"" + customer + "\"";
            sql += ")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery(project, type, sql);

            foreach (Issue issue in issues)
            {
                if (issue != null)
                {
                    return issue;
                }
            }

            return null;
        }

        public static async Task<List<Issue>> GetIssueList(string email)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "assignee in (\"" + email  + "\") and status in (\"Open\", \"In Progress\", \"Reopened\", \"Pending\", \"Development in Progress\") ";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public static async Task<List<Issue>> GetIssueListByLabel(string label)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "labels = " + label + "";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public static async Task<List<Issue>> GetUpdatedIssueListByTimeslot(DateTime from, DateTime to)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            //string sql = " updated >= " + from.ToString("yyyy-MM-dd") + " AND updated <= " + to.ToString("yyyy-MM-dd") + " AND assignee in (\"" + assignee + "\") ";
            string sql = " issuetype in (subTaskIssueTypes()) AND updated >= " + from.ToString("yyyy-MM-dd") + " AND updated <= " + to.ToString("yyyy-MM-dd") + " ";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public static async Task<List<Issue>> GetUpdatedIssueListByTimeslot(string userName, string password, DateTime from, DateTime to, List<string> subTaskStatusList = null, List<string> meoOptions = null)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", userName, password);

            int fromTimeSlot = (int)DateTime.Now.Subtract(from).TotalHours;
            int toTimeSlot = (int)DateTime.Now.Subtract(to).TotalHours;

            string sql = " issuetype in (subTaskIssueTypes()) ";

            if(userName != "peter.peng@missionsky.com")
            {
                sql += " AND assignee = \"" + userName + "\" ";
            }

            if (toTimeSlot < 0)
            {
                sql += " AND updated >= -" + DateTime.Now.Subtract(from).Hours + "h ";
            }
            else
            {
                sql += " AND updated >= -" + fromTimeSlot + "h AND updated <= -" + toTimeSlot + "h ";
            }

            if (meoOptions == null || meoOptions.Count == 0)
            {
                sql += " AND \"Self Rating\" is EMPTY ";
            }
            else
            {
                sql += " AND \"Self Rating\" in (";
                bool isFirstOne = true;
                foreach (string meo in meoOptions)
                {
                    if (isFirstOne)
                    {
                        sql += meo;
                        isFirstOne = false;
                    }
                    else
                    {
                        sql += "," + meo;
                    }
                }               
                sql += ") ";
            }

            if (subTaskStatusList == null || subTaskStatusList.Count == 0)
            {

                sql += " AND status in (Closed, Resolved) ";
            }
            else
            {
                sql += " AND status in (";
                bool isFirstOne = true;
                foreach (string status in subTaskStatusList)
                {
                    if (isFirstOne)
                    {
                        sql += "\"" + status + "\"";
                        isFirstOne = false;
                    }
                    else
                    {
                        sql += "," + "\"" + status + "\"";
                    }
                }                
                sql += ") ";
            }

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public static async Task<List<Issue>> GetUpdatedIssueListByAssigneeList(DateTime from, DateTime to, List<string> assignees)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            //string sql = " updated >= " + from.ToString("yyyy-MM-dd") + " AND updated <= " + to.ToString("yyyy-MM-dd") + " ";
            string sql = "";

            int fromTimeSlot = (int)DateTime.Now.Subtract(from).TotalHours;
            int toTimeSlot = (int)DateTime.Now.Subtract(to).TotalHours;

            if (toTimeSlot < 0)
            {
                sql = " updated >= -" + DateTime.Now.Subtract(from).Hours + "h ";
            }
            else
            {
                sql = " updated >= -" + fromTimeSlot + "h AND updated <= -" + toTimeSlot + "h ";
            }            

            if (assignees.Count > 0)
            {
                sql += " AND assignee in (";
                bool isFirst = true;
                foreach (var assignee in assignees)
                {
                    if (isFirst)
                    {
                        sql += " \"" + assignee + "\" ";
                        isFirst = false;
                    }
                    else
                    {
                        sql += " ,\"" + assignee + "\" ";
                    }
                }
                sql += " )";
            }

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        private static async Task<int> GetTimeSlot(DateTime date)
        {
            if (date.Year == DateTime.Now.Year
                && date.Month == DateTime.Now.Month
                && date.Day == DateTime.Now.Day)
            {
                return DateTime.Now.Subtract(date).Hours;
            }
            else if (date.Year == DateTime.Now.Year
                && date.Month == DateTime.Now.Month)
            {
                return DateTime.Now.Subtract(date).Days * 24 + DateTime.Now.Subtract(date).Hours;
            }

            return 12;
        }

        public static async Task<Issue> LoadIssue(IssueRef issue)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var Issue = jira.LoadIssue(issue);

            return Issue;
        }

        public static async Task<string> GetAssigneeByJiraKey(string jiraKey)
        {
            IssueRef issueRef = new IssueRef();
            issueRef.key = jiraKey;

            var issue = await JiraProxy.LoadIssue(issueRef);

            if (issue == null || issue.fields == null || issue.fields.assignee == null)
            {
                return "";
            }

            return issue.fields.assignee.name;
        }

        public static async Task<List<Worklog>> GetWorklogs(IssueRef issue)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var worklogs = jira.GetWorklogs(issue);

            return (worklogs as List<Worklog>);
        }

        public static async Task<List<Issue>> GetIssueListByStatus(string status)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "project = ENGSUPP AND issuetype not in (subTaskIssueTypes()) AND status = \"" + status + "\" AND reporter in (\"peter.peng@missionsky.com\")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }


        public static async Task<Issue> CreateIssue(IssueFields fields)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var issue = jira.CreateIssue("ENGSUPP", "Case", fields);

            return issue;
        }

        public static async Task<Issue> CreateSubTask(string summary, string description, IssueRef parent)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var issue = jira.CreateSubTask("ENGSUPP", parent.key, summary, description);

            return issue;
        }

        // https://www.quora.com/How-could-I-close-JIRA-ticket-using-rest-API
        public static async void CloseSubTask(IssueRef issueRef)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            var transitions = jira.GetTransitions(issueRef);
            foreach (var transition in transitions)
            {
                if ("Closed" == transition.name)
                {
                    jira.TransitionIssue(issueRef, transition);
                }
            }
        }

        public static async Task<Issue> UpdateSubTask(Issue issue)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var result = jira.UpdateSubTask("ENGSUPP", issue);

            return result;
        }

        public static async Task<Issue> UpdateIssue(Issue issue)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var result = jira.UpdateIssue(issue);

            return result;
        }

        public static async Task<Issue> CreateDatabaseTask(IssueFields fields)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var issue = jira.CreateIssue("DATABASE", "Task", fields);

            return issue;
        }

        public static async Task<Issue> UpdateDatabaseTask(Issue issue)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var result = jira.UpdateIssue(issue);

            return result;
        }

        public static async Task<Comment> CreateComment(IssueRef issue, string caseComment)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var jiraComments = jira.GetComments(issue);
            bool isFound = false;
            Comment jiraComment = null;
            foreach (Comment temp in jiraComments)
            {
                if (temp.body.Equals(caseComment, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    jiraComment = temp;
                    isFound = true;
                    break;
                }
            }

            if (!isFound)
            {
                jiraComment = jira.CreateComment(issue, caseComment);
            }

            return jiraComment;
        }

        public static async Task<List<Comment>> GetComments(IssueRef issue)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var jiraComments = jira.GetComments(issue);


            return (jiraComments as List<Comment>);
        }

        public static async Task<List<Attachment>> GetAttachments(IssueRef issue)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var jiraAttachments = jira.GetAttachments(issue);


            return (jiraAttachments as List<Attachment>);
        }

        public static bool UploadAttachment(IssueRef issue, string fileName, byte[] fileStream)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            jira.CreateAttachment(issue, fileStream, fileName);

            return true;
        }

        public static async Task<bool> UpdateJiraStatus(IssueRef issueRef, string jiraStatus, string jiraNextStatus)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var transitions = jira.GetTransitions(issueRef);
            if ("Closed".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                && jiraNextStatus == "In Progress")
            {
                foreach (var transition in transitions)
                {
                    if ("Re-Open".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        jira.TransitionIssue(issueRef, transition);
                        break;
                    }
                }
            }

            if ("Pending".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                && jiraNextStatus == "In Progress")
            {
                foreach (var transition in transitions)
                {
                    if ("Analysis In Progress".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        jira.TransitionIssue(issueRef, transition);
                        break;
                    }
                }
            }

            if ("In Progress".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                && jiraNextStatus == "Pending")
            {
                foreach (var transition in transitions)
                {
                    if ("Commented".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        jira.TransitionIssue(issueRef, transition);
                        break;
                    }
                }
            }

            if (("Pending".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                || "Resolved".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase))
                && jiraNextStatus == "Closed")
            {
                foreach (var transition in transitions)
                {
                    if ("Closed".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        jira.TransitionIssue(issueRef, transition);
                        break;
                    }
                }
            }
            //var issues = jira.TransitionIssue(issueRef, inProgressOrReopen);

            // "Open" -> "In Progress"
            // "In Progress" -> "Commented"
            // "In Progress" -> "Closed"
            return true;
        }

        public static async Task<List<Issue>> GetCaseListFromCrossProjects(DateTime startDate, DateTime endDate, List<string> projects)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            string sql = "resolutiondate >= " + String.Format("{0}-{1}-{2}", startDate.Year, startDate.Month, startDate.Day) + " AND " + " resolutiondate <= " + String.Format("{0}-{1}-{2}", endDate.Year, endDate.Month, endDate.Day);
            sql += " AND \"Salesforce ID\" !~ Empty ";
            sql += " AND project in ( ";

            bool isFirstOne = true;
            foreach (string project in projects)
            {
                if (isFirstOne)
                {
                    sql += project;
                    isFirstOne = false;
                }
                else
                {
                    sql += " , " + project;
                }
            }
            sql += ")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public static async Task<List<Issue>> GetIssueListBySalesforceId(string salesforceId, List<string> projects)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            string sql = "\"Salesforce ID\" ~ " + salesforceId;
            sql += " AND project in ( ";

            bool isFirstOne = true;
            foreach (string project in projects)
            {
                if (isFirstOne)
                {
                    sql += project;
                    isFirstOne = false;
                }
                else
                {
                    sql += " , " + project;
                }
            }
            sql += ")";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public static async Task<List<Issue>> GetIssueListByCreatedDate(DateTime start, DateTime end)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            // http://www.cnblogs.com/polk6/p/5465088.html
            string sql = "issuetype not in (Task, Sub-task) AND reporter in (\"Peter.peng@missionsky.com\") AND created >= " + start.ToString("yyyy-MM-dd") + " AND created < " + end.ToString("yyyy-MM-dd") + " ";
            
            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }

        public static async Task<List<Issue>> GetProductionIssueList()
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            // http://www.cnblogs.com/polk6/p/5465088.html
            string sql = " status in (Open, \"In Progress\", Reopened, Pending, \"Development in Progress\") AND not \"Salesforce ID\" is EMPTY AND reporter in (\"Peter.peng@missionsky.com\") ";

            List<Issue> issueList = new List<Issue>();
            var issues = jira.GetIssuesByQuery("ENGSUPP", "Bug", sql);
            foreach (Issue issue in issues)
            {
                issueList.Add(issue);
            }

            return issueList;
        }
    }
}
