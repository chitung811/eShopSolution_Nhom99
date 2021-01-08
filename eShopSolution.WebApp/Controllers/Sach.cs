using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.WebApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eShopSolution.WebApp.Controllers
{
    public class Sach : Controller
    {
        private readonly MyDBContext _context;

        public Sach(MyDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Chitiet(int id)
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

    }
}

