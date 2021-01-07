using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.WebApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.TagHelpers;
namespace eShopSolution.WebApp.Controllers

{
    public class Admin : Controller
    {
        private readonly MyDBContext _context;

        public Admin(MyDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.Sachs.Include(h => h.LoaiSach);
            return View(await myDbContext.ToListAsync());

        }
        public IActionResult ThemLoai()
        {
           
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemLoai([Bind("MaLoai,TenLoai")] LoaiSach loai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loai);
        }
        public IActionResult ThemSach()
        {
            //ViewData["MaLoai"] = new SelectList(_context.LoaiSachs, "MaLoai", "TenLoai");
            return View();

        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> ThemSach([Bind("TenSach,TacGia,MaLoai,MoTa,Hinh,Gia")] Sach sach, IFormFile HinhUpload)
        //{
        //    //if (ModelState.IsValid)
        //    //{
        //    //    //upload hình lên đâu đó

        //    //    //cập nhật field hình
        //    //   sach.Hinh = HinhUpload.FileName;

        //    //    _context.Add(sach);
        //    //    await _context.SaveChangesAsync();
        //    //    return RedirectToAction(nameof(Index));
        //    //}
        //    ViewData["MaLoai"] = new SelectList(_context.LoaiSachs, "MaLoai", "TenLoai", sach.LoaiSach.MaLoai);
        //    return View(sach);
        //}

        // GET: HangHoas/Edit/5
       
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
        }
        public IActionResult ThemKho()
        {
            return View();
        }
    }
}