using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Mission> Missions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
           .HasMany(l => l.Missions)
           .WithOne(a => a.Employee);

            modelBuilder.Entity<Project>()
           .HasMany(l => l.Missions)
           .WithOne(a => a.Project);
        }
    }
}