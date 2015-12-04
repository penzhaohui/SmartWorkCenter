using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Models
{
    public class Account
    {
        [JsonProperty(PropertyName = "attributes")]
        public AttributeType Attributes { get; set; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
