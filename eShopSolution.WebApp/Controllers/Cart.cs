using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.WebApp.Controllers
{
    public class Cart : Controller
    {
        public IActionResult cart()
        {
            return View();
        }
    }
}
