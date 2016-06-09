using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Proxy.models
{
    public class User
    {
        [JsonProperty(PropertyName = "Name")]
        public string Name { get; set; }

        /*
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "MiddleName")]
        public string MiddleName { get; set; }

        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }
         * */
    }
}
