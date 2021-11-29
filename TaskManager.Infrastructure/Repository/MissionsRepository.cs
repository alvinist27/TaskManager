using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Infrastructure
{
    public class MissionsRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public MissionsRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Mission>> GetAllAsync()
        {
            return await _context.Missions.OrderBy(p => p.MName).ToListAsync();
        }
        public async Task<Mission> GetByIdAsync(Guid id)
        {
            return await _context.Missions.FindAsync(id);
        }
        public async Task AddAsync(Mission mission)
        {
            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Mission mission)
        {
            var existPerson = await _context.Missions.FindAsync(mission.MissionID);
            _context.Entry(existPerson).CurrentValues.SetValues(mission);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            Mission person = await _context.Missions.FindAsync(id);
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }
    }
}
