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

namespace JobYub.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
	[IgnoreAntiforgeryToken(Order =1001)]
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
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
			//_context = new ApplicationDbContext();
		}

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
			//[Required]
			//[StringLength(11, ErrorMessage = "The must be at least {2} and at max {1} characters long.", MinimumLength = 11)]
			[Display(Name = "Mobile")]
			public string Mobile { get; set; }

			//[Required]
			[EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }


			//[Required]
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
            if (ModelState.IsValid)
            {
				//var user = new ApplicationUser { UserName = string.IsNullOrEmpty( Input.Email)? "unknown":Input.Email, Email = Input.Email , Mobile=Input.Mobile, PasswordHash=Input.Password, CityID=Input.CityID,Company=Input.CompanyName, CompanyTypeID=Input.CompanyTypeID, Graduated=Input.Graduated, EducationLevel=Input.EdcationLevel, MajorID=Input.MajorID};			
			//	var userQuery = _context.ApplicationUser.Where(u => u.Mobile == Input.Mobile).Single();
				//if (ApplicationUser)
				var user = new ApplicationUser { UserName = string.IsNullOrEmpty(Input.Email) ? "unknown" : Input.Email, Mobile = Input.Mobile};
				// var result = await _userManager.CreateAsync(user, Input.Password);
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
					return new JsonResult(int.Parse( "1234"));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
