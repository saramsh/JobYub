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

namespace JobYub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           
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
