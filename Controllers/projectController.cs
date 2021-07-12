using System;
using System.Collections.Generic;
using System.Linq;
using CSharp_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CSharp_Project.Controllers
{
    public class ProjectController : Controller
    {
        private MyContext dbContext;
        
        public ProjectController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("project/create")]
        public IActionResult NewProject()
        {
            return View();
        }

        [HttpPost("CreateProject")]
        public IActionResult CreateProject(Project newProject)
        {
            int? id =  HttpContext.Session.GetInt32("uid");
            int gid = dbContext.students.FirstOrDefault(u => u.StudentId == id ).GroupId;
            newProject.GroupId = gid;
            dbContext.projects.Add(newProject);
            dbContext.SaveChanges();
            return Redirect("/");
        }

        [HttpGet("projects/{projId}")]
        public IActionResult ProjectDetails(int projId)
        {
            Project thisProject = dbContext.projects.FirstOrDefault(p => p.ProjectId == projId);
            ViewBag.ThisGroup = dbContext.groups
            .Include(g => g.JoinedStudents)
            .Include(g => g.CreatedProjects)
            .FirstOrDefault(g => g.GroupId == thisProject.GroupId);
            List<Student> groupMembers = ViewBag.ThisGroup.JoinedStudents;
            int? id =  HttpContext.Session.GetInt32("uid");
            if(groupMembers.Any(s => s.StudentId == id ))
            {
                ViewBag.CanEdit = "yes";
            }
            else
            {
                ViewBag.CanEdit = "no";

            }
            return View(thisProject);
        }

    }
}