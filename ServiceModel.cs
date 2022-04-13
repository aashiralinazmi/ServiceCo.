using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace ServiceCo.Models
{
    public class ServiceModel
    {
        [Required]
        public int FID { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(20, ErrorMessage = "Max 20 allowed")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required field")]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Contact { get; set; }
        public bool Electrical { get; set; }
        public bool Sanitary { get; set; }
        public bool Mechanical { get; set; }
        public bool HouseCleansing { get; set; }
        public bool Security { get; set; }
        public string ChooseService { get; set; }

        public LoginModel LoginInfo { get; set; }
       
    }
}