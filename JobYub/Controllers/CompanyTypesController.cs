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
    public class CompanyTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompanyTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CompanyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyType>>> GetCompanyType()
        {
            return await _context.CompanyType.ToListAsync();
        }

        // GET: api/CompanyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyType>> GetCompanyType(int id)
        {
            var companyType = await _context.CompanyType.FindAsync(id);

            if (companyType == null)
            {
                return NotFound();
            }

            return companyType;
        }

        // PUT: api/CompanyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyType(int id, CompanyType companyType)
        {
            if (id != companyType.ID)
            {
                return BadRequest();
            }

            _context.Entry(companyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyTypeExists(id))
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

        // POST: api/CompanyTypes
        [HttpPost]
        public async Task<ActionResult<CompanyType>> PostCompanyType(CompanyType companyType)
        {
            _context.CompanyType.Add(companyType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyType", new { id = companyType.ID }, companyType);
        }

        // DELETE: api/CompanyTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyType>> DeleteCompanyType(int id)
        {
            var companyType = await _context.CompanyType.FindAsync(id);
            if (companyType == null)
            {
                return NotFound();
            }

            _context.CompanyType.Remove(companyType);
            await _context.SaveChangesAsync();

            return companyType;
        }

        private bool CompanyTypeExists(int id)
        {
            return _context.CompanyType.Any(e => e.ID == id);
        }
    }
}
