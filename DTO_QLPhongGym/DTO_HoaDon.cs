using System;

namespace DTO_QLPhongGym
{
    public class DTO_HoaDon
    {
        public int MaHD { get; set; }
        public int MaHV { get; set; }
        public DateTime NgayThanhToan { get; set; }
        public decimal TongTien { get; set; }
        public string PhuongThuc { get; set; }

        public DTO_HoaDon() { }
        public DTO_HoaDon(int maHV, decimal tongTien, string phuongThuc)
        {
            this.MaHV = maHV;
            this.TongTien = tongTien;
            this.PhuongThuc = phuongThuc;
        }
    }
}
