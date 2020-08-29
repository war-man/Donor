using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Donor.Entity
{
    public class DonorModel:BaseEntity
    {
        public string Name { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{11})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Want to invisible your Phone?")]
        public bool HidePhone { get; set; }
        [Display(Name = "District/State?")]
        public string District { get; set; }
        [Display(Name = "Thana/Area?")]
        public string Thana { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string DonateType { get; set; }
        public string PreviewesHealthProblem { get; set; }
        public string BoodGroup { get; set; }
        public string RecentDrag { get; set; }
        public string Others { get; set; }
        public string Approved { get; set; }

    }
}
