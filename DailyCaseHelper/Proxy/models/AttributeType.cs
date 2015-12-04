using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Models
{
    public class AttributeType
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set;}

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }
}
