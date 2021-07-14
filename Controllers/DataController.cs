using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CSharp_Project.Models;
namespace CSharp_Project.Controllers
{
    public class DataController : Controller
    {

        private static MyContext context;
        
        public DataController(MyContext DBContext)
        {
            context = DBContext;
        }


        private static int[] groups = {
            1,
            2,
            3,
            4,
            5,
            6,
        };

        private static string[] instructors = {
            "Jason Brady",
            "Monica Hong",
        };

        private static string[] tas = {
            "Ghidaa Alahmadi,Jason Brady",
            "Corey Mckeel,Jason Brady",
            "Reem Alabbad,Monica Hong",
            "Nathan Bell,Monica Hong",
        };

        [HttpGet("getallthedata")]
        public IActionResult GetData()
        {
            foreach(int t in groups)
            {
                // string[] info = t.Split(",");
                context.groups.Add(
                    new Group() {
                        GroupNumber=t
                        // TeamName=info[1],
                        // LeagueId=Int32.Parse(info[2])
                    }
                );
            }
            context.SaveChanges();


            foreach(string x in instructors)
            {
                // string[] info = t.Split(",");
                context.instructors.Add(
                    new Instructor() {
                        Name=x
                        // TeamName=info[1],
                        // LeagueId=Int32.Parse(info[2])
                    }
                );
            }
            context.SaveChanges();


            foreach(string a in tas)
            {
                string[] info = a.Split(",");
                context.TAs.Add(
                    new TA() {
                        Name=info[0],
                        instructor=context.instructors.FirstOrDefault(i => i.Name ==info[1]),
                        InstructorId=context.instructors.FirstOrDefault(i => i.Name ==info[1]).InstructorId,
                    }
                );
            }
            context.SaveChanges();


            return Redirect("/");
        }


    }
}