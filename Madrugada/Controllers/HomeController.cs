using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Madrugada.Models;
using Madrugada.Data;
using Microsoft.EntityFrameworkCore;

namespace Madrugada.Controllers
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
            var model = new ViewModels.Home.Index();
            model.RecentlyUpdatedLocations = _context.Locations.Include(q => q.CoverImage).OrderByDescending(q => q.LastUpdate).Take(5).ToList();

            //临时措施
            model.FeaturedLocations = _context.Locations.Include(q => q.CoverImage).Take(5).ToList();
            model.FeaturedWorks = _context.Works.Take(5).ToList();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult License()
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
