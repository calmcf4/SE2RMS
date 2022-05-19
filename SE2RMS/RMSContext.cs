using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SE2RMS.Models;

namespace SE2RMS
{
    public class RMSContext : DbContext
    {
        public DbSet<Assessment>? Assessments { get; set; }
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Grade>? Grades { get; set; }
        public DbSet<Module>? Modules { get; set; }
        public DbSet<Register>? Registers { get; set; }
        public DbSet<Staff>? Staff { get; set; }       
        public DbSet<Student>? Students { get; set; }
        public DbSet<Student_Module>? Student_Modules { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            object p = optionsBuilder.UseSqlite(
                "Data Source=SE2GP.db");
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
