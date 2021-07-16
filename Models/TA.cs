using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
// W.A.R.S 
namespace CSharp_Project.Models
{
    public class TA
    {
        public int TAId {get;set;}
        public string Name {set;get;}

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public int InstructorId {get;set;}
        public Instructor instructor {get;set;}

        
    }
}