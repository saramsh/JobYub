using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using JobYub.Data;
using JobYub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobYub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
		private readonly ApplicationDbContext _context;

		public ApplicationUserController(ApplicationDbContext context)
		{
			_context = context;
		}

		public class InputModel
		{
			//[Required]
			//[StringLength(11, ErrorMessage = "The must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
			//[Display(Name = "Mobile")]
			//public string Mobile { get; set; }
			[Required]
			public string PhoneNumber { get; set; }

			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
			public string FirstName { get; set; }

			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
			public string LastName { get; set; }

			[Url]
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			public string Website { get; set; }

			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
			public string BirthDate { get; set; }

			[StringLength(11, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 8)]
			public string HomePhone { get; set; }

			//[Required]
			[EmailAddress]
			public string Email { get; set; }

			[MaxLength(6)]
			public string VerificationCode { get; set; }

			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }

			//register required fields for employee and employer
			public int? CityID { get; set; }

			public int? MajorID { get; set; }
			
			public int? MilitaryStatus { get; set; }
			
			public int? RegionID { get; set; }

			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			public string Address { get; set; }

			//size: 100k
			[StringLength(100000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			public string Photo { get; set; }

			//size: 100k
			[StringLength(100000, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			public string Resume { get; set; }

			//register required fields for employer 
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			public string Company { get; set; }
			public int? CompanyTypeID { get; set; }

			public double? Latitude { get; set; }
			
			public double? longtitude { get; set; }

			//register required fields for employee 

			public bool Graduated { get; set; }

			public int? EdcationLevel { get; set; }

			public int? Experience { get; set; }

			public string ID { get; set; }

			//public Advertisement[] ad
		}


		//Edit user profile
		[Route("/Identity/Account/Edit")]
		public async Task<IActionResult> EditProfile(InputModel Input)
		{
			if (!ModelState.IsValid)
			{
				return new StatusCodeResult(400);
			}
			try
			{
				var ApUser = await _context.ApplicationUser.FindAsync( Input.ID);
				ApUser.FirstName = Input.FirstName;
				ApUser.LastName = Input.LastName;
				ApUser.Website = Input.Website;
				ApUser.BirthDate = Input.BirthDate;
				ApUser.HomePhone = Input.HomePhone;
				ApUser.MajorID = Input.MajorID;
				ApUser.Email = Input.Email;
				ApUser.CityID = Input.CityID;
				if(Input.MilitaryStatus!=null)
					ApUser.MilitaryStatus = (MilitaryStatus)Enum.Parse(typeof(MilitaryStatus), Input.MilitaryStatus.ToString());
				ApUser.Address = Input.Address;
				if (Input.Photo != null)
					ApUser.Photo = System.Convert.FromBase64String(Input.Photo);
				if (Input.Resume != null)
					ApUser.Resume = System.Convert.FromBase64String(Input.Resume);
				ApUser.Company = Input.Company;
				ApUser.CompanyTypeID = Input.CompanyTypeID;
				ApUser.Longtitude = Input.longtitude;
				ApUser.Latitude = Input.Latitude;
				ApUser.Graduated = Input.Graduated;
				if (Input.EdcationLevel != null)
					ApUser.EducationLevel = (EducationLevel)Enum.Parse(typeof(EducationLevel), Input.EdcationLevel.ToString()); ;
				ApUser.Experience = Input.Experience;
				await _context.SaveChangesAsync();
				return new StatusCodeResult(200);
			}
			catch (Exception ex)
			{
				return new StatusCodeResult(400);
			}
		}

		//  api/ApplicationUser
		[HttpPost]
		public async Task<ActionResult<Advertisement>> findApplicationUser(ApplicationUser user)
		{
			try
			{
				var applicationUser = await _context.ApplicationUser.FindAsync(user.Id);

				if (applicationUser == null)
				{
					return NotFound();
				}

				return Ok(applicationUser);
			}
			catch(Exception ex)
			{
				return StatusCode(500);
			}
		}

	}
}