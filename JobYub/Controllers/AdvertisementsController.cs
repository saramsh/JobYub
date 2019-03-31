using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobYub.Data;
using JobYub.Models;
using Microsoft.AspNetCore.Authorization;

namespace JobYub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdvertisementsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("SearchAsync")]
        public async Task<ActionResult<List<Advertisement>>> SearchAsync(AdvertisementSearchModel model)
        {
            IQueryable<Advertisement> res = _context.Advertisement;
            
            if (model.Title != null)
                res = res.Where(a => a.Title.Contains(model.Title) == true);

            if (model.City != null)
                res = res.Where(a => a.City.Name.Contains(model.City)==true);
            if (model.JobCategory != null)
                res = res.Where(a => a.JobCategory.Name.Contains(model.JobCategory)==true);
            if (model.Role != null)
            {
                
                res = res;
            }
            if (res != null)
            {
                return await res.ToListAsync();
            }
            else
            {
                return NotFound("جستجو نتیجه ای در بر نداشت.");
            }
            
            
        }
        // GET: api/Advertisements
        [HttpGet]
        public async Task<ActionResult> GetAdvertisement()
        {
            var res=await _context.Advertisement.Where(a=>a.Confirmed==true).ToListAsync();
            if (res != null)
                return Ok(res);
            else
                return NotFound();
                    
        }

        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Advertisement>> GetAdvertisement(int id)
        {
            var advertisement = await _context.Advertisement.FindAsync(id);

            if (advertisement == null)
            {
                return NotFound();
            }

            return advertisement;
        }

        // PUT: api/Advertisements/5
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdvertisement(int id, Advertisement advertisement)
        {
            if (id != advertisement.ID)
            {
                return BadRequest();
            }

            _context.Entry(advertisement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementExists(id))
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

        // POST: api/Advertisements
       
        [HttpPost]
        public async Task<ActionResult<Advertisement>> PostAdvertisement(Advertisement advertisement)
        {
            //var user =await  _context.Users.FirstOrDefaultAsync(m => m.UserName == User.Identity.Name);
            //advertisement.ApplicationUser = user;
            //advertisement.ApplicationUserID = user.Id;
            _context.Advertisement.Add(advertisement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdvertisement", new { id = advertisement.ID }, advertisement);
        }

        // DELETE: api/Advertisements/5
      
        [HttpDelete("{id}")]
        public async Task<ActionResult<Advertisement>> DeleteAdvertisement(int id)
        {
            var advertisement = await _context.Advertisement.FindAsync(id);
            if (advertisement == null)
            {
                return NotFound();
            }

            _context.Advertisement.Remove(advertisement);
            await _context.SaveChangesAsync();

            return advertisement;
        }

        private bool AdvertisementExists(int id)
        {
            return _context.Advertisement.Any(e => e.ID == id);
        }

		[Route("/Advertisements/SearchByKeyword")]
		public async Task<ActionResult> SearchAdvertisementByKeyword(KeywordSearchModel keywordSearchModel )
		{

			var res =  _context.Advertisement.Where(adds =>adds.advertisementType==keywordSearchModel.AdvertisementType && adds.status==Status.confirmed && (  adds.Title.ToLower().Contains(keywordSearchModel.keyword.ToLower()) || adds.Description.ToLower().Contains(keywordSearchModel.keyword.ToLower()))).FirstOrDefault();
			//addtype
			if (res != null)
				return Ok(res);
			else
				return NotFound();

		}

		[Route("/Advertisements/Search")]
		public async Task<ActionResult> SearchAdvertisement(KeywordSearchModel keywordSearchModel)
		{

			var res = _context.Advertisement.Where(adds => adds.advertisementType == keywordSearchModel.AdvertisementType && (adds.Title.ToLower().Contains(keywordSearchModel.keyword.ToLower()) || adds.Description.ToLower().Contains(keywordSearchModel.keyword.ToLower()))).FirstOrDefault();
			//addtype
			if (res != null)
				return Ok(res);
			else
				return NotFound();

		}


	}
}
