using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace CSharp_Project.Models
{
    public class Instructor
    {
        public int InstructorId {get;set;}
        public string Name {set;get;}

        public List<Student> Students {get;set;}
        public List<TA> TAs {set;get;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        
        
    }
}