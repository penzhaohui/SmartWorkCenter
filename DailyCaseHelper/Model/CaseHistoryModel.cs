using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.smartwork.Model
{
    public class CaseHistoryModel
    {
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Case ID
        /// </summary>
        public int CaseID { get; set; }

        /// <summary>
        /// History Reviewer
        /// </summary>
        public string Reviewer { get; set; }

        /// <summary>
        /// History Comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// History Assign Date
        /// </summary>
        public DateTime AssignedDate { get; set; }

        /// <summary>
        /// History Assigner's email address
        /// </summary>
        public string Assigner { get; set; }
    }
}
