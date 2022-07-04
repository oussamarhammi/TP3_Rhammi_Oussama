
using JuliePro_DataAccess.Data;
using JuliePro_Models;
using JuliePro_Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JuliePro.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IStringLocalizer<HomeController> _localizer;

        private readonly JulieProDbContext _db;
        

        public HomeController(ILogger<HomeController>
          logger, IStringLocalizer<HomeController> localizer, JulieProDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var donnees = _db.CalendarEvents.ToList();
            donnees = _db.CalendarEvents.OrderByDescending(c => c.Date).Take(3).ToList();

            return View(donnees);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       

    }
}
