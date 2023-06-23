using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace HubBrokerjobApplications.Models
{
    public partial class StudentMaster
    {
        public int StuId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public int? JobId { get; set; }
        public int? DocId { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
    }
}
