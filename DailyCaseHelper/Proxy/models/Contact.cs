using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Proxy.models
{
    public class Contact
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }
    }
}
