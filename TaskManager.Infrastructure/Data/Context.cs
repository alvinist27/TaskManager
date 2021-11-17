using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using Microsoft.EntityFrameworkCore;
using Task = TaskManager.Domain.Task;

namespace TaskManager.Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
           .HasMany(l => l.Tasks)
           .WithOne(a => a.Employee);

            modelBuilder.Entity<Project>()
           .HasMany(l => l.Tasks)
           .WithOne(a => a.Project);
        }
    }
}