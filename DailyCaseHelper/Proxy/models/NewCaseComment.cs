using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Proxy.models
{
    public class NewCaseComment
    {
        [JsonProperty(PropertyName = "Body")]
        public Byte[] Body { get; set; }

        [JsonProperty(PropertyName = "CommentBody")]
        public string CommentBody { get; set; }

        [JsonProperty(PropertyName = "ParentId")]
        public string ParentId { get; set; }

        [JsonProperty(PropertyName = "IsPublished")]
        public bool IsPublished { get; set; }
    }
}
