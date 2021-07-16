using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
// W.A.R.S 
namespace CSharp_Project.Models
{
    public class Group
    {
        [Display(Name="Group Number:")]
        public int GroupId {get;set;}

        public int GroupNumber {get;set;}

        public List<Student> JoinedStudents {get;set;}
        public List<Project> CreatedProjects {set;get;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}