using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using JobYub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using JobYub.Data;
using System.Linq;
using JobYub.Helpers;

namespace JobYub.Areas.Identity.Pages.Account
{
	[AllowAnonymous]
	[IgnoreAntiforgeryToken(Order = 1001)]
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;
		private ApplicationDbContext _context;

		public RegisterModel(
			UserManager<ApplicationUser> userManager,
			SignInManager<ApplicationUser> signInManager,
			ILogger<RegisterModel> logger,
			IEmailSender emailSender, ApplicationDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
			_emailSender = emailSender;
			//_context = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());
			_context = context;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public string ReturnUrl { get; set; }

		public class InputModel
		{
			//[Required]
			//[StringLength(11, ErrorMessage = "The must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
			//[Display(Name = "Mobile")]
			//public string Mobile { get; set; }

            [Display(Name = "PhoneNumber")]
            public string PhoneNumber { get; set; }

            //[Required]
            [EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

            [MaxLength(4)]
            public string VerificationCode { get; set; }
                                             
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }

			//register required fields for employee and employer
			[Display(Name = "City")]
			public int CityID { get; set; }

			//register required fields for employer 
			[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[Display(Name = "CompanyName")]
			public string CompanyName { get; set; }

			[Display(Name = "CompanyType")]
			public int CompanyTypeID { get; set; }

			//register required fields for employee 
			[Display(Name = "Graduated")]
			public bool Graduated { get; set; }

			[Display(Name = "EdcationLevel")]
			public string EdcationLevel { get; set; }

			[Display(Name = "Major")]
			public int MajorID { get; set; }


		}

		public void OnGet(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl = returnUrl ?? Url.Content("~/");
           //await _userManager.CreateAsync(new ApplicationUser() { Email = "a@a.com", PhoneNumber = "9010596159", UserName = "a@a.com",EmailConfirmed=true,PhoneNumberConfirmed=true }, "A@aaa1");
            if (ModelState.IsValid)
			{
				//var user = new ApplicationUser { UserName = string.IsNullOrEmpty( Input.Email)? "unknown":Input.Email, Email = Input.Email , Mobile=Input.Mobile, PasswordHash=Input.Password, CityID=Input.CityID,Company=Input.CompanyName, CompanyTypeID=Input.CompanyTypeID, Graduated=Input.Graduated, EducationLevel=Input.EdcationLevel, MajorID=Input.MajorID};
				if (Input.PhoneNumber != null)
				{
					var user = _context.ApplicationUser.FirstOrDefault(u => u.PhoneNumber == Input.PhoneNumber);

                    if (user == null)
					{
						string un = string.IsNullOrEmpty(Input.Email) ? "unknown" + Input.PhoneNumber.Substring(7) :Input.Email ;
						user = new ApplicationUser { UserName = un, PhoneNumber=Input.PhoneNumber};
						var result = await _userManager.CreateAsync(user);
						if (result.Succeeded)
						{

							_logger.LogInformation("User created a new account with password.");

							//var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
							//var callbackUrl = Url.Page(
							//    "/Account/ConfirmEmail",
							//    pageHandler: null,
							//    values: new { userId = user.Id, code = code },
							//    protocol: Request.Scheme);

							//await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
							//    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

							//await _signInManager.SignInAsync(user, isPersistent: false);
							// return LocalRedirect(returnUrl);
							//return new JsonResult(int.Parse("1234"));
						}
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError(string.Empty, error.Description);
						}
					}
                    user.VerificationCode =await _userManager.GenerateChangePhoneNumberTokenAsync(user, user.PhoneNumber);
                    await _context.SaveChangesAsync();
                    AuthMessageSender s = new AuthMessageSender();
                    await s.SendSmsAsync(user.PhoneNumber, user.VerificationCode);

					//var resul = await _signInManager.PasswordSignInAsync("a@a.com", "A@aaa1", false, lockoutOnFailure: true);
					//new { PhoneNumber = user.PhoneNumber }
					return new StatusCodeResult(200);

               
                    
                    
                    // var ty= await  _signInManager.CanSignInAsync(us);
                    //var s= User.Identity.IsAuthenticated;
                   //  return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl});
                  //  return StatusCode(200);

                   // return new JsonResult(int.Parse("1234"));

					// var result = await _userManager.CreateAsync(user, Input.Password);
				}




				// If we got this far, something failed, redisplay form
				//return Page();
				return new StatusCodeResult(400);
			}


			return new StatusCodeResult(400);
		}
        public async Task<IActionResult> OnPutAsync( string returnurl=null)
        {
            ApplicationUser user= _context.ApplicationUser.FirstOrDefault(u => u.PhoneNumber == Input.PhoneNumber);
            if (user != null)
            {


                if (user.VerificationCode ==Input.VerificationCode)
                {
                    user.AccessFailedCount = 0;
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    string g = await _userManager.GetAuthenticationTokenAsync(user, "test", "token");
                    OkObjectResult s = new OkObjectResult(g);
                    return s;
                    
                }
                else
                {
                    user.AccessFailedCount++;
                    return BadRequest("The Verification Code is not true;");
                }
            }
            else
            {
                return NotFound("Phone has not found;");
            }
        }
     
        
        
        
      





    }
}
