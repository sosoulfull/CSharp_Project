using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CSharp_Project.Models
{
    public class Student
    {
        [Key]

        public int StudentId {get;set;}

        [Required]
        [MinLength(3, ErrorMessage="First name must have at least 3 characters")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(4, ErrorMessage="Last name must have at least 4 characters")]
        public string LastName {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        
        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must have at least 8 characters")]
        public string Password {get;set;}

        [NotMapped]
        [Compare("Password", ErrorMessage="Passwords must match!")]
        [DataType(DataType.Password)]
        public string Confirm {get;set;}

        public string StudentGithub {get;set;}
        public string linkedin {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        Instructor instructor {get;set;}
        Group group {get;set;}
    }
}