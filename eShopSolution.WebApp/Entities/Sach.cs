using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Entities
{
    [Table("Sach")]
    public class Sach
    {
        [Key]
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public LoaiSach LoaiSach { get; set; }
        public string MoTa { get; set; }
        public string Hinh { get; set; }
        public double Gia { get; set; }
    }
}
