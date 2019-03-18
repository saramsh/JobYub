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
    public class JobCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/JobCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobCategory>>> GetJobCategory()
        {
            return await _context.JobCategory.ToListAsync();
        }

        // GET: api/JobCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JobCategory>> GetJobCategory(int id)
        {
            var jobCategory = await _context.JobCategory.FindAsync(id);

            if (jobCategory == null)
            {
                return NotFound();
            }

            return jobCategory;
        }

        // PUT: api/JobCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJobCategory(int id, JobCategory jobCategory)
        {
            if (id != jobCategory.ID)
            {
                return BadRequest();
            }

            _context.Entry(jobCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobCategoryExists(id))
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

        // POST: api/JobCategories
        [HttpPost]
        public async Task<ActionResult<JobCategory>> PostJobCategory(JobCategory jobCategory)
        {
            _context.JobCategory.Add(jobCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJobCategory", new { id = jobCategory.ID }, jobCategory);
        }

        // DELETE: api/JobCategories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JobCategory>> DeleteJobCategory(int id)
        {
            var jobCategory = await _context.JobCategory.FindAsync(id);
            if (jobCategory == null)
            {
                return NotFound();
            }

            _context.JobCategory.Remove(jobCategory);
            await _context.SaveChangesAsync();

            return jobCategory;
        }

        private bool JobCategoryExists(int id)
        {
            return _context.JobCategory.Any(e => e.ID == id);
        }
    }
}
