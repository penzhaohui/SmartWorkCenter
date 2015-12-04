using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Model
{
    public class AcccelaDBModel
    {
        /// <summary>
        /// DB Type: Oracle or MSSQL
        /// </summary>
        public string Type { set; get; }

        /// <summary>
        /// Customer
        /// </summary>
        public string Customer { set; get; }

        /// <summary>
        /// DB Version
        /// </summary>
        public string Version { set; get; }

        /// <summary>
        /// DB IP
        /// </summary>
        public string IP { set; get; }

        /// <summary>
        /// DB Port
        /// </summary>
        public string Port { set; get; }

        /// <summary>
        /// DB SID
        /// </summary>
        public string SID { set; get; }

        /// <summary>
        /// DB Name
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// User
        /// </summary>
        public string User { set; get; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { set; get; }

        /// <summary>
        /// Created Date
        /// </summary>
        public DateTime CreatedDate { set; get; }

        /// <summary>
        /// DB Owner
        /// </summary>
        public string Owner { set; get; }

        /// <summary>
        /// Salesforce Number
        /// </summary>
        public string SFCase { set; get; }

        /// <summary>
        /// Agency List
        /// </summary>
        public string AgencyList { set; get; }
    }
}
