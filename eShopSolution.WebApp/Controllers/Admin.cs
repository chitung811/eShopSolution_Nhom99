using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.WebApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;

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
            ViewData["MaLoai"] = new SelectList(_context.LoaiSachs, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemSach([Bind("MaSach,TenSach,TacGia,MaLoai,MoTa,Hinh,Gia")] eShopSolution.WebApp.Entities.Sach sach, IFormFile HinhUpload)
        {
            if (ModelState.IsValid)
           {
                if (HinhUpload != null)
                {
                    var urlFull = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", HinhUpload.FileName);
                    using(var file=new FileStream(urlFull, FileMode.Create))
                    {
                        await HinhUpload.CopyToAsync(file);
                    }
                    sach.Hinh = HinhUpload.FileName;
                }
             
            _context.Add(sach);
         await _context.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
        }
          ViewData["MaLoai"] = new SelectList(_context.LoaiSachs, "MaLoai", "TenLoai", sach.MaLoai);
            
           return View(sach);
        
       }

        // GET: HangHoas/Edit/5
        public IActionResult SuaSach(int id)
        {
            var sach = _context.Sachs.SingleOrDefault(lo=>lo.MaSach==id);
            if (sach == null)
            {
                return RedirectToAction("Index");
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiSachs, "MaLoai", "TenLoai", sach.MaLoai);
            return View(sach);
        }
        [HttpPost]

        public IActionResult SuaSach( [Bind("MaSach,TenSach,TacGia, MaLoai, MoTa, Hinh, Gia")] eShopSolution.WebApp.Entities.Sach sach,IFormFile HinhUpLoad)
        {
           
            if (ModelState.IsValid)
            {
                if (HinhUpLoad != null)
                {
                    var urlFull = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", HinhUpLoad.FileName);
                    using (var file = new FileStream(urlFull, FileMode.Create))
                    {
                         HinhUpLoad.CopyTo(file);
                    }
                    sach.Hinh = HinhUpLoad.FileName;
                }
               
                    _context.Sachs.Update(sach);
                    _context.SaveChanges();
               
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiSachs, "MaLoai", "TenLoai", sach.MaLoai);
            return View(sach);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sach = await _context.Sachs
                .Include(h => h.LoaiSach)
                .FirstOrDefaultAsync(m => m.MaSach == id);
            if (sach == null)
            {
                return NotFound();
            }

            return View(sach);
        }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sach = await _context.Sachs.FindAsync(id);
            _context.Sachs.Remove(sach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
        }
        public IActionResult ThemKho()
        {
            return View();
        }
    }
}