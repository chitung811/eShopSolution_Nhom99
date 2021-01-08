using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.WebApp.Entities;
using Microsoft.AspNetCore.Mvc;
using eShopSolution.WebApp.Helpers;
using eShopSolution.WebApp.Models;

namespace eShopSolution.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly MyDBContext _context;

        public CartController(MyDBContext context)
        {
            _context = context;
        }
        public List<CartItem> Carts
        {
            get
            {
                var data = HttpContext.Session.Get<List<CartItem>>("GioHang");
                if(data == null)
                {
                    data = new List<CartItem>();
                }
                return data;
            }
        }
        public IActionResult Index()
        {
            return View(Carts);
        }
        public IActionResult AddToCart(int id, int SoLuong, string type = "Normal")
        {
            var myCart = Carts;
            var item = myCart.SingleOrDefault(p => p.MaSach == id);
            if(item == null)
            {
                var sach = _context.Sachs.SingleOrDefault(p => p.MaSach == id);
                item = new CartItem
                {
                    MaSach = id,
                    TenSach = sach.TenSach,
                    Gia = sach.Gia,
                    SoLuong = SoLuong,
                    Hinh = sach.Hinh
                };
                myCart.Add(item);
            }
            else
            {
                item.SoLuong++;
            }
            HttpContext.Session.Set("GioHang", myCart);
            if(type == "ajax")
            {
                return Json(new
                {
                    SoLuong = Carts.Sum(c=> c.SoLuong)
                });
            }
            return RedirectToAction("Index");
        }
    }
}
