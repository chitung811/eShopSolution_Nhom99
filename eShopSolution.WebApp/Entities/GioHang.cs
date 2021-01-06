using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopSolution.WebApp.Entities
{
    [Table("GioHang")]
    public class GioHang
    {
        [Key]
        public int MaGH { get; set; }
        public int MaKH { get; set; }
        [ForeignKey("ID")]
        public TaiKhoan TaiKhoan { get; set; }
        public int MaSach { get; set; }
        [ForeignKey("MaSach")]
        public Sach Sach { get; set; }
        public int SoLuong { get; set; }
        public ICollection<Sach> Sachs { get; set; }
        public GioHang()
        {
            Sachs = new HashSet<Sach>();
        }
    }
}
