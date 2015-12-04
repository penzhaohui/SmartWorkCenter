using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;

namespace com.smartwork.Proxy
{
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

        public static async Task<List<Issue>> GetIssueList(string email)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            string sql = "assignee in (\"" + email  + "\")";

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

        public static async Task<Issue> CreateIssue(IssueFields fields)
        {
            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");

            var issue = jira.CreateIssue("ENGSUPP", "Case", fields);

            return issue;
        }      

        public static async Task<Issue> UpdateIssue(Issue issue)
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
    }
}
