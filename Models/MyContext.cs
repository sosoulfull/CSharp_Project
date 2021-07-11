using Microsoft.EntityFrameworkCore;
using CSharp_Project.Models;

namespace CSharp_Project.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
            public DbSet<Student> students {get;set;}
            public DbSet<Group> groups {get;set;}
            public DbSet<Project> projects {get;set;}
            public DbSet<Instructor> instructors {get;set;}
            public DbSet<TA> TAs {get;set;}

    }
}