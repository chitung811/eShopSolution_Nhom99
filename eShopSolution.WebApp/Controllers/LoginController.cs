using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.WebApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace eShopSolution.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly MyDBContext _context;
        

        public LoginController(MyDBContext context)
        {
            _context = context;
        }
        // GET: Home
        public ActionResult Index()
        {
            if (HttpContext.Session != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        //GET: Register

        public ActionResult Register()
        {
            return View();
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
                    _TaiKhoan.Password = GetMD5(_TaiKhoan.Password);
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


                var f_password = GetMD5(password);
                var data = _context.TaiKhoans.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
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



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
