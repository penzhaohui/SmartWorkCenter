using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.JiraRestClient;

namespace com.smartwork.Proxy.models
{
    public class AccelaIssueFields : IssueFields
    {
        [JsonProperty(PropertyName = "customfield_10600")]
        public String CaseNumber { get; set; }
    }
}
