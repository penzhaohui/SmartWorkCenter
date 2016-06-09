using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salesforce.Common.Models;
using com.smartwork.Proxy.models;

namespace com.smartwork.Models
{
    public class AccelaCase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "CaseNumber")]
        public string CaseNumber { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public AttributeType CaseType { get; set; }

        [JsonProperty(PropertyName = "Current_Version__c")]
        public string CurrentVersion { get; set; }

        [JsonProperty(PropertyName = "Priority")]
        public string Priority { get; set; }

        [JsonProperty(PropertyName = "Go_Live_Critical__c")]
        public string GoLiveCritical { get; set; }

        [JsonProperty(PropertyName = "Services_Rank__c")]
        public string ServicesRank { get; set; }

        [JsonProperty(PropertyName = "Rank_Order__c")]
        public string RankOrder { get; set; }

        [JsonProperty(PropertyName = "Account")]
        public Account Account { get; set; }

        [JsonProperty(PropertyName = "Owner")]
        public Account Owner { get; set; }

        [JsonProperty(PropertyName = "Origin")]
        public string Origin { get; set; }

        [JsonProperty(PropertyName = "Patch_Number__c")]
        public string PatchNumber { get; set; }

        [JsonProperty(PropertyName = "Subject")]
        public string Subject { get; set; }

        [JsonProperty(PropertyName = "Type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "CreatedBy")]
        public Account CreatedBy { get; set; }

        [JsonProperty(PropertyName = "Status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "BZID__c")]
        public string BZID { get; set; }

        [JsonProperty(PropertyName = "Internal_Type__c")]
        public string InternalType { get; set; }

        [JsonProperty(PropertyName = "Product__c")]
        public string Product { get; set; }

        [JsonProperty(PropertyName = "solution__c")]
        public string Solution { get; set; }

        [JsonProperty(PropertyName = "release_info__c")]
        public string ReleaseInfo { get; set; }

        [JsonProperty(PropertyName = "targeted_release__c")]
        public string TargetedRelease { get; set; }

        [JsonProperty(PropertyName = "Customer__r")]
        public Account Customer { get; set; }

        [JsonProperty(PropertyName = "CaseComments")]
        public QueryResult<CaseComment> CaseComments { get; set; }

        [JsonProperty(PropertyName = "Attachments")]
        public QueryResult<CaseAttachment> CaseAttachments { get; set; }        
        
    }
}
