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
using eShopSolution.WebApp.ViewModels;

namespace eShopSolution.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDBContext _context;

        public HomeController(MyDBContext context)
        {
            _context = context;
        }

        private int soSachMoiTrang = 10;
     
        public async Task<IActionResult> Index(int page =1)
        {
            var dsSach = _context.Sachs
                .Include(h => h.LoaiSach);
                //.Skip((page - 1) * soSachMoiTrang)
                //.Take(soSachMoiTrang)
                //.Select(p => new HangHoaVM
                //{
                //    MaSach = p.MaSach,
                //    TenSach = p.TenSach,
                //    TacGia = p.TacGia,
                //    MaLoai = p.MaLoai,
                //    Hinh = p.Hinh,
                //    MoTa = p.MoTa,
                //    Gia = p.Gia
                //});

            return View(await dsSach.ToListAsync());
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
        public IActionResult Detail(int id)
        {
            var item = _context.Sachs.SingleOrDefault(sach => sach.MaSach == id);
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Index");
        }
        public  IActionResult Category(int id)
        {
           var dsSach = _context.Sachs.SingleOrDefault(sach => sach.MaLoai == id);
           if(dsSach != null)
            {
                return  View(dsSach);
            }

            return RedirectToAction("Index");
        }
    }
}
