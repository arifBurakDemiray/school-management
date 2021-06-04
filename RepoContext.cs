
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.API.Models;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;

namespace SchoolManagement.API {
    public class RepoContext : DbContext
    {
        public RepoContext(DbContextOptions<RepoContext> opt) :base(opt)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}