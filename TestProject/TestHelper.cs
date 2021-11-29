using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using TaskManager.Infrastructure;
using Microsoft.EntityFrameworkCore;



namespace TestProject
{
    public class TestHelper
    {
        private readonly Context _context;
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase(databaseName: "TestDB");

            var dbContextOptions = builder.Options;
            _context = new Context(dbContextOptions);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public EmployeesRepository EmployeesRepository
        {
            get
            {
                return new EmployeesRepository(_context);
            }
        }
        public ProjectsRepository ProjectsRepository
        {
            get
            {
                return new ProjectsRepository(_context);
            }
        }
        public MissionsRepository TasksRepository
        {
            get
            {
                return new MissionsRepository(_context);
            }
        }
    }
}