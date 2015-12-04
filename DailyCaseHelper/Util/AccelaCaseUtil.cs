using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;

namespace com.smartwork.Util
{
    public class AccelaCaseUtil
    {
        public static string AdjustProductName(string product, string solution, string subject, string description)
        {
            string productName = product;

            if ("AdHoc Reports" == product)
            {
                productName = product;
            }

            if ("Inspector" == product || "Civic Hero" == product || "Code Officer" == product || "Work Crew" == product || "Support Access" == product)
            {
                productName = product;
            }

            if ("Inspector" == solution || "Civic Hero" == solution || "Code Officer" == solution || "Work Crew" == solution || "Support Access" == solution)
            {
                productName = solution;
            }

            if ("Civic Cloud Platform" == product || "Accela Asset Management" == product || "Accela Licensing & Case Management" == product)
            {
                productName = product;
            }

            if ("Standard history conversion" == product)
            {
                productName = product;
            }

            if ("Mobile Office" == solution)
            {
                productName = solution;
            }

            if ("Accela Mobile" == productName)
            {
                if ((subject != null && (subject.ToUpper().Contains("AMO") || subject.ToUpper().Contains("MOBILE OFFICE")))
                    || (description != null && (description.ToUpper().Contains("AMO") || description.ToUpper().Contains("MOBILE OFFICE"))))
                {
                    productName = "Mobile Office";
                }
            }

            return productName;
        }

        public static string GetJiraLabel(string product, string solution, string subject)
        {
            string label = "";

            if ("Inspector" == product || "Civic Hero" == product || "Code Officer" == product || "Work Crew" == product || "Support Access" == product)
            {
                label = product;
            }

            if ("Civic Cloud Platform" == product)
            {
                label = product;
            }

            if ("Standard history conversion" == product)
            {
                label = product;
            }

            return label;
        }

        public static string GetNextJIRAStatus(string sfQueue, string sfStatus, string jiraStatus, bool isCommentedToday)
        {
            string nextJiraStatus = "";

            if (isCommentedToday)
            {
                if (!"Pending".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                    && !"Resolved".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                    && !"Closed".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase)
                    && !"Dev In Progress".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                {
                    nextJiraStatus = "Pending";
                }
            }
            else
            {
                if ("Engineering".Equals(sfQueue, System.StringComparison.InvariantCultureIgnoreCase)
                    && "Eng New".Equals(sfStatus, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    if (!"In Progress".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                    {
                        nextJiraStatus = "In Progress";
                    }
                }
                else
                {
                    if ("CLOSED".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase)
                        || "PM Assigned".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase)
                        || "Ideas (Closed)".Equals(sfStatus, StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (!"Closed".Equals(jiraStatus, StringComparison.InvariantCultureIgnoreCase))
                        {
                            nextJiraStatus = "Closed";
                        }
                    }
                }
            }
                
            return nextJiraStatus;
        }

        public static bool UpdateJIRAStatus(IssueRef issueRef, string jiraStatus, string jiraNextStatus)
        {
            // Start Review Case: Open -> In Progress
            //                    Pending -> In Progress
            //                    Resolved -> In Progress(Command: Re-Open)
            //                    Closed -> In Progress(Command: Re-Open)
            // Add some comment: In Progress -> Pending
            // 

            if (String.IsNullOrEmpty(jiraNextStatus))
            {
                return false;
            }

            IJiraClient jira = new JiraClient("https://accelaeng.atlassian.net/", "peter.peng@missionsky.com", "peter.peng");
            var transitions = jira.GetTransitions(issueRef);

            if ("In Progress" == jiraNextStatus)
            {
                if ("Open".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }

                if ("Pending".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase)
                    || "Reopened".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase))
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
                else
                {
                    if ("Closed".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase))
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

                    if ("Resolved".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        foreach (var transition in transitions)
                        {
                            if ("Dev In Progress".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                            {
                                jira.TransitionIssue(issueRef, transition);
                                break;
                            }
                        }
                    }

                    transitions = jira.GetTransitions(issueRef);

                    foreach (var transition in transitions)
                    {
                        if ("Analysis In Progress".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                        {
                            jira.TransitionIssue(issueRef, transition);
                            break;
                        }
                    }
                }
            }

            if ("Pending" == jiraNextStatus)
            {
                if ("Open".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase))
                {
                    foreach (var transition in transitions)
                    {
                        if ("Analysis In Progress".Equals(transition.name, System.StringComparison.InvariantCultureIgnoreCase))
                        {
                            jira.TransitionIssue(issueRef, transition);
                            break;
                        }
                    }

                    jiraStatus = "In Progress";
                }

                if ("In Progress".Equals(jiraStatus, System.StringComparison.InvariantCultureIgnoreCase))
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
            }

            if ("Closed" == jiraNextStatus)
            { 
            }

            return true;
        }
    }
}
