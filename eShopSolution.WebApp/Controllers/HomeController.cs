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

        //Dang ki dang nhap

        //Ket thuc dang ki dang nhap

        private int soSachMoiTrang = 10;
     
        public async Task<IActionResult> Index(int page =1)
        {
            if (HttpContext.Session != null)
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
            else
            {
                return RedirectToAction("Login");
            }
            
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TaiKhoan _TaiKhoan)
        {
            if (ModelState.IsValid)
            {
                var check = _context.TaiKhoans.FirstOrDefault(s => s.Email == _TaiKhoan.Email);
                if (check == null)
                {
                    //_TaiKhoan.Password = GetMD5(_TaiKhoan.Password);
                    //_context.Configuration.ValidateOnSaveEnabled = false;
                    _context.TaiKhoans.Add(_TaiKhoan);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {


                //var f_password = GetMD5(password);
                var data = _context.TaiKhoans.Where(s => s.Email.Equals(email) && s.Password.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    HttpContext.Session.SetString("FullName", data.FirstOrDefault().HoTen);
                    HttpContext.Session.SetString("Email", data.FirstOrDefault().Email);
                    HttpContext.Session.SetInt32("ID", data.FirstOrDefault().ID);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();//remove session
            return RedirectToAction("Login");
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
