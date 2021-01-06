using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eShopSolution.WebApp.Models;
using eShopSolution.WebApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace eShopSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDBContext _context;

        public HomeController(MyDBContext context)
        {
            _context = context;
        }

     
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Sachs.Include(h => h.LoaiSach);
            return View(await myDbContext.ToListAsync());
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
