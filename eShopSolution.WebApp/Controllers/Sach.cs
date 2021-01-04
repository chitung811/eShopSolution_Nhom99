using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.WebApp.Controllers
{
    public class Sach : Controller
    {
        public IActionResult Chitiet()
        {
            return View();
        }
    }
}
