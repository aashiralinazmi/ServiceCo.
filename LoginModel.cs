using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ServiceCo.Models
{
    public class LoginModel
    {
        [Key]
        public int LoginID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
        public string Role { get; set; }
        public int FID { get; set; }
        public bool IsActive { get; set; }
    }
}