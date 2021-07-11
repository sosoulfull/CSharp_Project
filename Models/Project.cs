using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CSharp_Project.Models
{
    public class Project
    {
        public int ProjectId {set;get;}
        public string ProjectName {set;get;}
        public string Description {get;set;}
        public string StackName {get;set;}
        public string ProjectGithub {get;set;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int GroupId {set;get;}
        public Group CreatedBy {set;get;} 
    }
}