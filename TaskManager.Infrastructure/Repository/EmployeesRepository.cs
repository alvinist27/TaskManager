using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure
{
    public class EmployeesRepository
    {
        private readonly Context _context;

        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public EmployeesRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException();
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async System.Threading.Tasks.Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployee(Guid ID)
        {
            return await _context.Employees.FindAsync(ID);
        }
    }
}
