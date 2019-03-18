using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobYub.Data;
using JobYub.Models;

namespace JobYub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarrifsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TarrifsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Tarrifs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarrif>>> GetTarrif()
        {
            return await _context.Tarrif.ToListAsync();
        }

        // GET: api/Tarrifs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarrif>> GetTarrif(int id)
        {
            var tarrif = await _context.Tarrif.FindAsync(id);

            if (tarrif == null)
            {
                return NotFound();
            }

            return tarrif;
        }

        // PUT: api/Tarrifs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarrif(int id, Tarrif tarrif)
        {
            if (id != tarrif.ID)
            {
                return BadRequest();
            }

            _context.Entry(tarrif).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TarrifExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tarrifs
        [HttpPost]
        public async Task<ActionResult<Tarrif>> PostTarrif(Tarrif tarrif)
        {
            _context.Tarrif.Add(tarrif);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTarrif", new { id = tarrif.ID }, tarrif);
        }

        // DELETE: api/Tarrifs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarrif>> DeleteTarrif(int id)
        {
            var tarrif = await _context.Tarrif.FindAsync(id);
            if (tarrif == null)
            {
                return NotFound();
            }

            _context.Tarrif.Remove(tarrif);
            await _context.SaveChangesAsync();

            return tarrif;
        }

        private bool TarrifExists(int id)
        {
            return _context.Tarrif.Any(e => e.ID == id);
        }
    }
}
