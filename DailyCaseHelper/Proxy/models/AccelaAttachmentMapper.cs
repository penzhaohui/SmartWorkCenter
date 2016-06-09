using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.smartwork.Proxy.models
{
    public class AccelaAttachmentMapper
    {
        public bool IsMerged { get; set; }

        public string CaseFileName { get; set; }
        public string CaseId { get; set; }
        public string CaseNumber { get; set; }
        public string CaseAttchmentId { get; set; }
        public string CaseAttachmentType { get; set; }
        public bool CaseIsPrivate { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploadedBy { get; set; }

        public string JiraFileName { get; set; }
        public string JiraId { get; set; }
        public string JiraKey { get; set; }
        public string JiraAttachmentId { get; set; }
    }
}
