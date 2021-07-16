using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
// W.A.R.S 
namespace CSharp_Project.Models
{
    public class Project
    {
        public int ProjectId {set;get;}
        [Required]
        [Display(Name = "Project Name")]
        public string ProjectName {set;get;}

        [Required]
        public string Description {get;set;}

        [Required]
        [Display(Name = "Stack Name")]
        public string StackName {get;set;}

        [Display(Name = "GitHub Link")]
        public string ProjectGithub {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int GroupId {set;get;}
        public Group CreatedBy {set;get;} 
    }
}