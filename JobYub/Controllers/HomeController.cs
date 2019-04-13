using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobYub.Models;
using Microsoft.AspNetCore.Authorization;
using RestSharp;
using Microsoft.Extensions.Configuration;
using JobYub.Helpers;
using Microsoft.Extensions.Logging;
using JobYub.Data;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace JobYub.Controllers
{
    public class HomeController : Controller
    {
        public delegate void Logger();
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _context;
        IServiceProvider ServiceProvider;
        public HomeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,IServiceProvider serviceProvider)
        {

            _context = context;
            _userManager = userManager;
            ServiceProvider = serviceProvider;
            
            
        }
        public async Task<IActionResult> Index()
        {
            // var roles =await _userManager.GetRolesAsync(_context.ApplicationUser.FirstOrDefault(u => u.UserName == User.Identity.Name));
            //var RoleManager = ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            return View(_context.Advertisement.Include(a=>a.ApplicationUser).ToList());
        }
        [Authorize]
        [HttpGet]
        public IActionResult Privacy()
        {
            AuthMessageSender s = new AuthMessageSender();
            
            //  s.SendSmsAsync("9010596159", "test again");
            
            return View();
        }
        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
