using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLPhongGym
{
    public class DTO_HoiVien
    {
        public int MaHV { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public int IdGoiTap { get; set; }
        public int IdPT { get; set; }
        public string TenGoiTap { get; set; }
        public string TenPT { get; set; }
        public DateTime NgayDK { get;set; }
    }
}
