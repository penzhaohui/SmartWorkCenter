using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.smartwork.Model
{
    public class CaseModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Product
        /// </summary>
        public string Product { get; set; }

        /// <summary>
        /// Open Date
        /// </summary>
        public DateTime OpenDate { get; set; }

        /// <summary>
        /// Severity
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// Salesforce ID
        /// </summary>
        public string SalesforceID { get; set; }

        /// <summary>
        /// JIRA ID
        /// </summary>
        public string JiraID { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Customer
        /// </summary>
        public string Customer { get; set; }

        /// <summary>
        /// Summary
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Reviwer
        /// </summary>
        public string Reviewer { get; set; }

        /// <summary>
        /// Status
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Reopened Count
        /// </summary>
        public int ReopenedCount { get; set; }
    }
}
