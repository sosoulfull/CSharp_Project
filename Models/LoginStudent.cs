using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CSharp_Project.Models
{
    public class LoginStudent
    {
        [Required]
        [EmailAddress]

        [Display(Name = "Email")]
        public string LoginEmail {get;set;}

        [Display(Name = "Password")]
        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}
    }
}