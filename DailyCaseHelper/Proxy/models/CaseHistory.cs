using com.smartwork.Models;
using Newtonsoft.Json;
using System;

namespace com.smartwork.Proxy.models
{
    public class CaseHistory
    {
        [JsonProperty(PropertyName = "attributes")]
        public AttributeType Attributes { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Case")]
        public AccelaCase Case { get; set; }

        [JsonProperty(PropertyName = "CreatedBy")]
        public User CreatedBy { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "NewValue")]
        public string NewValue { get; set; }

        [JsonProperty(PropertyName = "OldValue")]
        public string OldValue { get; set; }

        [JsonProperty(PropertyName = "IsDeleted")]
        public bool IsDeleted { get; set; }
    }
}
