using com.smartwork.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Proxy.models
{
    public class CaseAttachment
    {
        [JsonProperty(PropertyName = "attributes")]
        public AttributeType Attributes { get; set; }

        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "ContentType")]
        public string ContentType { get; set; }

        [JsonProperty(PropertyName = "BodyLength")]
        public double BodyLength { get; set; }

        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "IsPrivate")]
        public bool IsPrivate { get; set; }

        [JsonProperty(PropertyName = "OwnerId")]
        public string OwnerId { get; set; }

        [JsonProperty(PropertyName = "ParentId")]
        public string ParentId { get; set; }

        [JsonProperty(PropertyName = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty(PropertyName = "CreatedById")]
        public string CreatedById { get; set; }

        [JsonProperty(PropertyName = "LastModifiedDate")]
        public DateTime LastModifiedDate { get; set; }

        [JsonProperty(PropertyName = "LastModifiedById")]
        public string LastModifiedById { get; set; }

    }
}
