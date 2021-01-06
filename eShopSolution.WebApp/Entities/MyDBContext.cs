using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Entities
{
    public class MyDBContext: DbContext
    {
        public MyDBContext (DbContextOptions options) : base(options)
        {

        }
        public DbSet<LoaiSach> LoaiSachs { get; set; }
        public DbSet<Sach> Sachs { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<CTDH> CTDHs { get; set; }

    }
}
