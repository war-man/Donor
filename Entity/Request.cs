using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Donor.Entity
{
    public class Request:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string District { get; set; }
        public string Thana { get; set; }
        public string Address { get; set; }
        public string RecipientType { get; set; }
        public string BoodGroup { get; set; }
        public DateTime RequestDate { get; set; }
    }
}
