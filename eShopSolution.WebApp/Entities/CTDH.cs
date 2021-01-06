using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eShopSolution.WebApp.Entities
{
    [Table("CTDH")]
    public class CTDH
    {
        [Key]
        public int SoCT { get; set; }
        public int MaDH { get; set; }
        [ForeignKey("MaDH")]
        public DonHang DonHang { get; set; }
        public int MaSach { get; set; }
        [ForeignKey("MaSach")]
        public Sach Sach { get; set; }
        public int SoLuong { get; set; }

    }
}
