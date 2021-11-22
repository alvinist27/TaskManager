using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure
{
    public class TasksRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public TasksRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Domain.Task>> GetAllAsync()
        {
            return await _context.Tasks.OrderBy(p => p.TName).ToListAsync();
        }
        public async Task<Domain.Task> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }
        public async System.Threading.Tasks.Task AddAsync(Domain.Task task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task UpdateAsync(Domain.Task task)
        {
            var existTask = await _context.Tasks.FindAsync(task.TaskID);
            _context.Entry(existTask).CurrentValues.SetValues(task);
            await _context.SaveChangesAsync();
        }
        public async System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            Domain.Task task = await _context.Tasks.FindAsync(id);
            _context.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
