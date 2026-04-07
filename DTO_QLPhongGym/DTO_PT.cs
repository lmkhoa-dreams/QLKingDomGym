using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QLPhongGym
{
    public class DTO_PT
    {
        public int MaPT { get; set; }
        public string Ten { get; set; }
        public string GioiTinh { get; set; }
        public string SDT { get; set; }
        public DTO_PT(string ten, string gioiTinh, string sdt)
        {
            this.Ten = ten;
            this.GioiTinh = gioiTinh;
            this.SDT = sdt;
        }
    }
}
