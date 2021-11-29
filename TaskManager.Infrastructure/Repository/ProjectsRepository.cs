using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure
{
    public class ProjectsRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get 
            {
                return _context;
            }
        }
        public ProjectsRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.OrderBy(p => p.PName).ToListAsync();
        }
        public async Task<Project> GetByIdAsync(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }
        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Project project)
        {
            var existProject = await _context.Projects.FindAsync(project.ProjectID);
            _context.Entry(existProject).CurrentValues.SetValues(project);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            Project project = await _context.Projects.FindAsync(id);
            _context.Remove(project);
            await _context.SaveChangesAsync();
        }
    }
}
