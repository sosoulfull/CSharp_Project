using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CSharp_Project.Models;

namespace CSharp_Project.Controllers
{
    public class UserController : Controller
    {

        private MyContext dbContext;
        
        public UserController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("")]
        public IActionResult Dashboard()
        {
            return View();
        }
        
    }
}
