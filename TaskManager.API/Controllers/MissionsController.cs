using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;
using TaskManager.Infrastructure;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        private readonly Context _context;
        private readonly MissionsRepository _repository;

        public MissionsController(Context context)
        {
            _context = context;
            _repository = new MissionsRepository(_context);
        }

        // GET: api/Missions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mission>>> GetMissions()
        {
            //return await _context.Missions.ToListAsync();
            return await _repository.GetAllAsync();
        }

        // GET: api/Missions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mission>> GetMission(Guid id)
        {
            //var mission = await _context.Missions.FindAsync(id);
            var mission = await _repository.GetByIdAsync(id);

            if (mission == null)
            {
                return NotFound();
            }

            return mission;
        }

        // PUT: api/Missions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMission(Guid id, Mission mission)
        {
            if (id != mission.MissionID)
            {
                return BadRequest();
            }

            /*
            _context.Entry(mission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            */

            await _repository.UpdateAsync(mission);

            return NoContent();
        }

        // POST: api/Missions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mission>> PostMission(Mission mission)
        {
            //_context.Missions.Add(mission);
            //await _context.SaveChangesAsync();
            await _repository.AddAsync(mission);
            return CreatedAtAction("GetMission", new { id = mission.MissionID }, mission);
        }

        // DELETE: api/Missions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMission(Guid id)
        {
            //var mission = await _context.Missions.FindAsync(id);
            var mission = await _repository.GetByIdAsync(id);

            if (mission == null)
            {
                return NotFound();
            }

            //_context.Missions.Remove(mission);
            //await _context.SaveChangesAsync();
            await _repository.DeleteAsync(id);

            return NoContent();
        }

        private bool MissionExists(Guid id)
        {
            return _context.Missions.Any(e => e.MissionID == id);
        }
    }
}
