using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Proxy.models
{
    public class AccelaCaseStatusMapper
    {
        public string SalesforceID { get; set; }
        public string SuppJiraID { get; set; }
        public string SuppAssignee { get; set; }
        public string LinkedJiraID { get; set; }
        public string LinkedJiraAssignee { get; set; }
        public string Summary { get; set; }
        public string SFQueue { get; set; }
        public string SFStatus { get; set; }
        public string SuppJiraStatus { get; set; }
        public string LinkedJiraStatus { get; set; }
        public bool NeedSync { get; set; }
    }
}
