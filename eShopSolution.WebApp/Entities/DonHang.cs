using eShopSolution.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Entities
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int MaDH { get; set; }
        public int MaKH { get; set; }
        [ForeignKey("ID")]
        public TaiKhoan TaiKhoan { get; set; }
        public DateTime NgayDat { get; set; }
        public string NoiGiao { get; set; }
        public int TinhTrang { get; set; }
        public ICollection<CTDH> CTDHs { get; set; }
        public DonHang()
        {
            CTDHs = new HashSet<CTDH>();
        }
    }
}
