using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSharp_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;



namespace CSharp_Project.Controllers
{
    public class StudentController : Controller
    {

        private MyContext dbContext;
        
        public StudentController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet("registration_login")]
        public IActionResult RegLogin()
        {
            ViewBag.Allgroups = dbContext.groups.ToList();
            ViewBag.AllInstructors = dbContext.instructors.ToList();
            return View("Register");
        }

        [HttpPost("register")]
        public IActionResult ProcessReg(Student regStudent)
        {
            if (ModelState.IsValid)
            {
                if (dbContext.students.Any(u => u.Email == regStudent.Email))
                {
                    ModelState.AddModelError("Email", "The Email is already in use!");
                    ViewBag.Allgroups = dbContext.groups.ToList();
                    ViewBag.AllInstructors = dbContext.instructors.ToList();
                    return View("Register");
                }
                PasswordHasher<Student> Hasher = new PasswordHasher<Student>();
                regStudent.Password = Hasher.HashPassword(regStudent, regStudent.Password);
                dbContext.students.Add(regStudent);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("uid", regStudent.StudentId);
                HttpContext.Session.SetString("name", regStudent.FirstName);
                return RedirectToAction("Dashboard");
            }
            ViewBag.Allgroups = dbContext.groups.ToList();
            ViewBag.AllInstructors = dbContext.instructors.ToList();
            return View("Register");
        }

        [HttpPost("login")]
        public IActionResult ProcessLogin(LoginStudent thisStudent)
        {
            if (ModelState.IsValid)
            {
                Student LoggedStudent = dbContext.students.FirstOrDefault(u => u.Email == thisStudent.LoginEmail);
                if (LoggedStudent != null)
                {
                    PasswordHasher<LoginStudent > Hasher = new PasswordHasher<LoginStudent >();
                    if (Hasher.VerifyHashedPassword(thisStudent, LoggedStudent.Password, thisStudent.LoginPassword) != 0)
                    {
                        HttpContext.Session.SetInt32("uid", LoggedStudent.StudentId);
                        HttpContext.Session.SetString("name", LoggedStudent.FirstName);
                        return RedirectToAction("Dashboard");
                    }
                }

                ModelState.AddModelError("LoginEmail", "Invalid login credentials!");
                ViewBag.Allgroups = dbContext.groups.ToList();
                ViewBag.AllInstructors = dbContext.instructors.ToList();
                return View("Register");
            }
            ViewBag.Allgroups = dbContext.groups.ToList();
            ViewBag.AllInstructors = dbContext.instructors.ToList();
            return View("Register");
        }

        [HttpGet("students/{uid}")]
        public IActionResult Profile(int uid)
        {
            Student Details = dbContext.students
            .Include(g => g.group)
            .FirstOrDefault(s => s.StudentId == uid);
            int? gid = Details.GroupId;
            ViewBag.AllProjects = dbContext.groups.Include( t => t.CreatedProjects )
            .FirstOrDefault( t => t.GroupId == gid );
            ViewBag.InstructorWithTAs = dbContext.instructors
            .Include(i => i.TAs)
            .FirstOrDefault(i => i.InstructorId == Details.InstructorId);
            return View("Profile", Details);
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Dashboard");
        }
    }
}
