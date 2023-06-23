using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HubBrokerjobApplications.Models
{
    public class Employee
    {

        public int StuId { get; set; }
        public string FullName { get; set; }
       
        public string EmailAddress { get; set; }
        public string MobileNo { get; set; }
        public int? JobId { get; set; }
        public int? DocId { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }
        public string JobName { get; set; }
       // public string DocuentName { get; set; }
       public string DocumentType { get; set; }


    }
}
