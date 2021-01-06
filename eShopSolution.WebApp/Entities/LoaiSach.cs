using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.WebApp.Entities
{
    [Table("LoaiSach")]
    public class LoaiSach
    {
        [Key]
        public int MaLoai { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenLoai { get; set; }
        public ICollection<Sach> Sachs { get; set; }
        public LoaiSach()
        {
            Sachs = new HashSet<Sach>();
        }
    }
}
