﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobYub.Data;
using JobYub.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq.Expressions;


namespace JobYub.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
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
        public async Task<ActionResult> GetAdvertisement(int? cityId, int page = 1)
        {
            IQueryable<Advertisement> res = _context.Advertisement.Where(a => a.status == Status.confirmed).Include(s => s.City).Include(s => s.Tarrif).Include(s => s.Region).Include(s => s.AdvertisementMajors).Include(s => s.AdvertisementEducationLevels);
            if (cityId != null&&cityId!=0)
                res = res.Where(a=>a.CityID==cityId);
            List<Advertisement> result =await  res.Skip((page-1) * 15).Take(15).ToListAsync();
            if (result != null)
                return Ok(new { Total = result.Count(), result = result });
            else
                return NotFound();
                    
        }

        // GET: api/Advertisements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Advertisement>> GetAdvertisement(int id)

		{
            var result =  _context.Advertisement.Where(a => a.status == Status.confirmed).Include(a => a.City).Include(a => a.ApplicationUser).Include(a => a.JobCategory).Include(a => a.Payment).Include(a => a.Region).Include(a => a.Tarrif).Include(a => a.AdvertisementEducationLevels).ThenInclude(ael => ael.EducationLevel).Include(a => a.AdvertisementMajors).ThenInclude(am=>am.Major);
           // result = await result.FirstOrDefaultAsync(a => a.ID == id);
            var advertisement=await result.FirstOrDefaultAsync(a => a.ID == id);
           

            if (advertisement == null)
            {
                return NotFound();
            }

            return advertisement;
        }


		// POST: api/Advertisements
		[HttpPost]
		public async Task<ActionResult<Advertisement>> PostAdvertisement(Advertisement advertisement)
		{

			_context.Advertisement.Add(advertisement);
          
            await _context.SaveChangesAsync();
			return CreatedAtAction("GetAdvertisement", new { id = advertisement.ID }, advertisement);
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
                //advertisement.a
                _context.AdvertisementMajors.RemoveRange(_context.AdvertisementMajors.Where(adm => adm.AdvertisementID == advertisement.ID));
                await _context.SaveChangesAsync();
                //advertisement.AdvertisementMajors.ForEach(am => am.Advertisement = advertisement);
                if (advertisement.AdvertisementMajors != null)
                    await _context.AdvertisementMajors.AddRangeAsync(advertisement.AdvertisementMajors);
                await _context.SaveChangesAsync();
                _context.AdvertisementEducationLevels.RemoveRange(_context.AdvertisementEducationLevels.Where(adm => adm.AdvertisementID == advertisement.ID));
                await _context.SaveChangesAsync();
                //advertisement.AdvertisementEducationLevels.ForEach(ae => ae.Advertisement = advertisement);
                if (advertisement.AdvertisementEducationLevels != null)
                    await _context.AdvertisementEducationLevels.AddRangeAsync(advertisement.AdvertisementEducationLevels);
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

			// return NoContent();
			return Ok(advertisement);
		}

		// POST: api/UserAdvertisements
		[Route("/api/UserAdvertisements")]
		[HttpPost]
        public async Task<ActionResult<Advertisement>> UserAdvertisements(ApplicationUser user)
        {
			try
			{
				var advertisement = await _context.Advertisement.Where(a => a.ApplicationUserID == user.Id).Include(a => a.City).Include(a => a.JobCategory).Include(a => a.Payment).Include(a => a.Tarrif).ToListAsync();
				if (advertisement != null)
				{
					return Ok(advertisement);
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return StatusCode(500);
			}
		}

		// GET: api/UserAdvertisement
		[Route("/api/UserAdvertisement")]
		[HttpGet("{id}")]
		public async Task<ActionResult<Advertisement>> UserAdvertisement(int id)
		{
			var result = _context.Advertisement.Where(a => a.ID == id).Include(a => a.City).Include(a => a.ApplicationUser).Include(a => a.JobCategory).Include(a => a.Payment).Include(a => a.Region).Include(a => a.Tarrif).Include(a => a.AdvertisementEducationLevels).ThenInclude(ael => ael.EducationLevel).Include(a => a.AdvertisementMajors).ThenInclude(am => am.Major);
			// result = await result.FirstOrDefaultAsync(a => a.ID == id);
			var advertisement = await result.FirstOrDefaultAsync();


			if (advertisement == null)
			{
				return NotFound();
			}

			return advertisement;
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
            query = query.Where(a => a.status == Status.confirmed);         
            if (model.AdvertisementType != null)
                query = query.Where(a => a.advertisementType == model.AdvertisementType);

            if (model.CollaborationType != null)
                query = query.Where(a => a.CollaborationType == model.CollaborationType);

            if (model.MinSalary != null)
                query = query.Where(a => a.MinSalary >= model.MinSalary);

            if (model.MaxSalary != null)
                query = query.Where(a => a.MaxSalary <= model.MaxSalary);

            if (model.MinAge != null)
                query = query.Where(a => a.MinAge >= model.MinAge);

            if (model.MaxAge != null)
                query = query.Where(a => a.MaxAge <= model.MaxAge);


            if (model.Gender != null)
                query = query.Where(a => a.Gender == model.Gender);

            if (model.CompanyTypeIDs != null)
            {
                model.CompanyTypeIDs.ForEach(cID => query = query.Where(a => a.ApplicationUser.CompanyTypeID == cID));
            }
            
            if(model.Graduated!=null)
                query = query.Where(a => a.Graduated == model.Graduated);

            if (model.EducationLevelIDs != null)
            {
             
                model.EducationLevelIDs.ForEach(eID => query = query.Where(a => a.AdvertisementEducationLevels.Where(ae=>ae.EducationLevelID==eID)!=null));
            }

            if (model.MajorIDs != null)
            {
                foreach(var id in model.MajorIDs)
                {
                    query = query.Where(a => a.AdvertisementMajors.Where(am => am.MajorID == id) != null);
                }
            }         
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
