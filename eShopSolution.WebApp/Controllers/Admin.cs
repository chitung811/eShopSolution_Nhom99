using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.WebApp.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ThemSach()
        {
            return View();
        }
        public IActionResult DsTaiKhoan()
        {
            return View();
        }
        public IActionResult ThemTaiKhoan()
        {
            return View();
        } 
        public IActionResult HoaDon()
        {
            return View();
        }
         public IActionResult Kho()
        {
            return View();
        }public IActionResult ThemKho()
        {
            return View();
        }


    }
}
