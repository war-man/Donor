using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Donor.Models
{
    public class RemoveRequest
    {
        public string PhoneNumber { get; set; }
        [Display(Name = "Want to invisible your Phone?")]
        public bool HidePhone { get; set; }
        [Display(Name = "Want to invisible your Phone? Give details contact address")]
        public string Address { get; set; }
    }
}
