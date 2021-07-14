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
            if(HttpContext.Session.GetInt32("uid") != null)
                return View();
            return Redirect("/");
        }

        [HttpPost("CreateProject")]
        public IActionResult CreateProject(Project newProject)
        {
            if (ModelState.IsValid)
            {
                int? id = HttpContext.Session.GetInt32("uid");
                int gid = dbContext.students.FirstOrDefault(u => u.StudentId == id).GroupId;
                newProject.GroupId = gid;
                dbContext.projects.Add(newProject);
                dbContext.SaveChanges();
                return Redirect("/");
            }

            return View("NewProject", newProject);

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
            int? id = HttpContext.Session.GetInt32("uid");
            if (groupMembers.Any(s => s.StudentId == id))
            {
                ViewBag.CanEdit = "yes";
            }
            else
            {
                ViewBag.CanEdit = "no";

            }
            return View(thisProject);
        }

        [HttpGet("projects/edit/{projId}")]

        public IActionResult EditProject(int projId)
        {
            if (HttpContext.Session.GetInt32("uid") != null)
            {
                Project projectToEdit = dbContext.projects.FirstOrDefault(p => p.ProjectId == projId);
                return View("EditProject", projectToEdit);
            }
            return Redirect($"/projects/{projId}");
        }

        [HttpPost("projects/edit/{projId}")]
        public IActionResult UpdateProject(int projId, Project editedProject)
        {
            Project projectToEdit = dbContext.projects.FirstOrDefault(p => p.ProjectId == projId);
            if (ModelState.IsValid)
            {
                projectToEdit.ProjectName = editedProject.ProjectName;
                projectToEdit.Description = editedProject.Description;
                projectToEdit.StackName = editedProject.StackName;
                projectToEdit.ProjectGithub = editedProject.ProjectGithub;
                projectToEdit.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return Redirect($"/projects/{projId}");
            }
            return View("EditProject", projectToEdit);
        }
    }
}