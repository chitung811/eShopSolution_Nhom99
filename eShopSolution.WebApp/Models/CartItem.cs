using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Models
{
    public class CartItem
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string Hinh { get; set; }
        public double Gia { get; set; }
        public int SoLuong { get; set; }
        public double TongTien => Gia * SoLuong;
    }
}
