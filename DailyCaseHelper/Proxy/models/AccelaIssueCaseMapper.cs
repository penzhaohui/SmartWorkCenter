using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;

namespace com.smartwork.Proxy.models
{
    public class AccelaIssueCaseMapper
    {
        public string IssueType { get; set; }
        public string CaseNumber { get; set; }
        public string SFProduct { get; set; }
        public string SFCustomer { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string JiraId { get; set; }
        public string JiraKey { get; set; }
        public string IssueCategory { get; set; }
        public string Assignee { get; set; }
        public string AssigneeQA { get; set; }
        public string Status { get; set; }
        public string LastModified { get; set; }
        public bool HotCase { get; set; }
        public bool Missionsky { get; set; }
        public List<string> JiraLabels { get; set; }
        public List<string> FixVersions { get; set; }
        public List<Comment> Comments { get; set; }
        public string ReleaseNote { get; set; }
        public int AggregateTimeSpent { get; set; }
    }
}
