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
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.OrderBy(p => p.EName).ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(Guid id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async System.Threading.Tasks.Task AddAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Employee employee)
        {
            var existEmployee = await _context.Employees.FindAsync(employee.EmployeeID);
            _context.Entry(existEmployee).CurrentValues.SetValues(employee);
            await _context.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            Employee employee = await _context.Employees.FindAsync(id);
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
