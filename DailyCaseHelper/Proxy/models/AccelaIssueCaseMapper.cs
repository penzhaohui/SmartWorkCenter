using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Proxy.models
{
    public class AccelaIssueCaseMapper
    {
        public string CaseNumber { get; set; }
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
    }
}
