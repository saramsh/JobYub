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




      
        // GET: api/Advertisements
        [HttpGet]
        public async Task<ActionResult> GetAdvertisement()
        {
            var res=await _context.Advertisement.Where(a=>a.status==Status.confirmed).Select(a=>a.City).ToListAsync();
			
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
        [HttpPost]
        [Route("/Advertisements/search")]
        public async Task<IActionResult> SearchAsync(AdvertisementSearchModel model)
        {

            //IQueryable<Advertisement> res = _context.Advertisement;

            var query = _context.Advertisement.AsQueryable();

            if (model.AdvertisementType != null)
                query = query.Where(a => a.advertisementType == model.AdvertisementType);

            if (model.CollaborationType != null)
                query = query.Where(a => a.CollaborationType == model.CollaborationType);

            if (model.Salary != null)
                query = query.Where(a => a.MinSalary >= model.Salary && a.MaxSalary<=model.Salary);

            if (model.Gender != null)
                query = query.Where(a => a.Gender == model.Gender);

            if (model.CompanyTypeIDs != null)
            {
                model.CompanyTypeIDs.ForEach(cID => query = query.Where(a => a.ApplicationUser.CompanyTypeID == cID));
            }
            
            if(model.Graduated!=null)
                query = query.Where(a => a.Graduated == model.Graduated);

            if (model.EducationLevel != null)
            {

                model.EducationLevel.ForEach(eID => query = query.Where(a => a.EducationLevel.Contains(eID)));
            }

            //if (model.MajorIDs != null)
            //{

                
            //    model.MajorIDs.ForEach(mID => query = query.Where(a => a.AdvertisementMajors.Where(am => am.MajorID == mID));
            //}


            if (model.Experience != null)
                query = query.Where(a => a.Experience <= model.Experience);
            
            if (model.KeyWord != null)
                query = query.Where(a => a.Title.Contains(model.KeyWord) || a.Description.Contains(model.KeyWord));

            if (model.Title != null)
                query = query.Where(a => a.Title.Contains(model.Title) == true);

            if (model.City != null)
                query = query.Where(a => a.City.Name.Contains(model.City) == true);

            if (model.JobCategoryID != null)
                query = query.Where(a => a.JobCategory.ID == model.JobCategoryID);





            return Ok(await query.ToListAsync());



        }
        //[Route("/Advertisements/SearchByKeyword")]
        //public async Task<ActionResult> SearchAdvertisementByKeyword(KeywordSearchModel keywordSearchModel)
        //{

        //	var res =  _context.Advertisement.Where(adds =>adds.advertisementType==keywordSearchModel.AdvertisementType && adds.status==Status.confirmed && (  adds.Title.ToLower().Contains(keywordSearchModel.keyword.ToLower()) || adds.Description.ToLower().Contains(keywordSearchModel.keyword.ToLower()))).FirstOrDefault();

        //          //addtype
        //	if (res != null)
        //		return Ok(res);
        //	else
        //		return NotFound();

        //}

        //[Route("/Advertisements/Search")]
        //public async Task<ActionResult> SearchAdvertisement(KeywordSearchModel keywordSearchModel)
        //{

        //	var res = _context.Advertisement.Where(adds => adds.advertisementType == keywordSearchModel.AdvertisementType && (adds.Title.ToLower().Contains(keywordSearchModel.keyword.ToLower()) || adds.Description.ToLower().Contains(keywordSearchModel.keyword.ToLower()))).FirstOrDefault();
        //	//addtype
        //	if (res != null)
        //		return Ok(res);
        //	else
        //		return NotFound();

        //}





		[Route("/Advertisements/Confirm")]
		public async Task<ActionResult> ConfirmAdvertisements(AdvertisementIDsModel advertisementIDs)
		{
			try
			{
				foreach (int id in advertisementIDs.AdvertisementIDs)
				{
					var advertisement = await _context.Advertisement.FindAsync(id);
					advertisement.status = Status.confirmed;
				}
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch(Exception ex)
			{
				return StatusCode(500);
			}

		}

		[Route("/Advertisements/Deactivate")]
		public async Task<ActionResult> DeactivateAdvertisements(AdvertisementIDsModel advertisementIDs)
		{
			try
			{
				foreach (int id in advertisementIDs.AdvertisementIDs)
				{
					var advertisement = await _context.Advertisement.FindAsync(id);
					advertisement.status = Status.deactive;
				}
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500);
			}

		}

    }
}
