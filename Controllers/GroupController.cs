using System.Linq;
using CSharp_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CSharp_Project.Controllers
{
    public class GroupController : Controller
    {
        private MyContext dbContext;

        public GroupController(MyContext context)
        {
            dbContext = context;
        }

        [HttpGet("groups/{gid}")]
        public IActionResult GroupDetail(int gid)
        {
            Group thisGroup = dbContext.groups
            .Include(g => g.JoinedStudents)
            .Include(g => g.CreatedProjects)
            .FirstOrDefault(g => g.GroupId == gid);
            
            return View("Group", thisGroup);
        }
    }
}