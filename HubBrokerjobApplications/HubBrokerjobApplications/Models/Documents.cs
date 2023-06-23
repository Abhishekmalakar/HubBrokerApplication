using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HubBrokerjobApplications.Models
{
    public partial class Documents
    {
        public int DocId { get; set; }
        public string DocuentName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentContent { get; set; }
    }
}
