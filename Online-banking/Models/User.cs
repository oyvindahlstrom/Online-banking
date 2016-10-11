using Online_banking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Online_banking.Models
{
    public class User
    {

        [Required]
        [Display(Name = "Personal Identification")]
        public string personal_Identification { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

    }
}