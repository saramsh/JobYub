using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobYub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
		//Edit user profile
		[Route("/Identity/Account/Edit")]
		//public async Task<IActionResult> EditProfile(string returnurl = null)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return new StatusCodeResult(400);
		//	}
		//	try
		//	{
		//		var ApUser = await _userManager.FindByIdAsync(Input.UserID.ToString());
		//		ApUser.FirstName = Input.FirstName;
		//		ApUser.LastName = Input.LastName;
		//		ApUser.Website = Input.Website;
		//		ApUser.BirthDate = Input.BirthDate;
		//		ApUser.HomePhone = Input.HomePhone;
		//		ApUser.MajorID = Input.MajorID;
		//		ApUser.Email = Input.Email;
		//		ApUser.CityID = Input.CityID;
		//		ApUser.MilitaryStatus = (MilitaryStatus)Enum.Parse(typeof(MilitaryStatus), Input.MilitaryStatus.ToString());
		//		ApUser.Address = Input.Address;
		//		ApUser.Photo = System.Convert.FromBase64String(Input.Photo);
		//		ApUser.Resume = System.Convert.FromBase64String(Input.Resume);
		//		ApUser.Company = Input.Company;
		//		ApUser.CompanyTypeID = Input.CompanyTypeID;
		//		ApUser.Longtitude = Input.longtitude;
		//		ApUser.Latitude = Input.Latitude;
		//		ApUser.Graduated = Input.Graduated;
		//		ApUser.EducationLevel = (EducationLevel)Enum.Parse(typeof(EducationLevel), Input.EdcationLevel.ToString()); ;
		//		ApUser.Experience = Input.Experience;
		//		await _userManager.UpdateAsync(ApUser);
		//		return new StatusCodeResult(200);
		//	}
		//	catch (Exception ex)
		//	{
		//		return new StatusCodeResult(400);
		//	}
		//}

	}
}