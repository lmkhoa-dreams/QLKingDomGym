using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLPhongGym;
using System.Data;
using DTO_QLPhongGym;

namespace BLL_QLPhongGym
{
    public class BLL_HoiVien
    {
        DAL_HoiVien HV = new DAL_HoiVien();

        public List<DTO_HoiVien> LayDanhSach()
        {
            return HV.GetDanhSachHoiVien();
        }

        public bool ThemHoiVien(DTO_HoiVien hv)
        {
            // Móc đồ trong thùng ra kiểm tra xem có trống không
            if (string.IsNullOrWhiteSpace(hv.Ten) || string.IsNullOrWhiteSpace(hv.SDT))
            {
                return false;
            }

            // Ném nguyên cái thùng xuống DAL
            return HV.ThemHoiVien(hv);
        }
        public bool Sua(int mahv, string ten, string gioitinh, string sdt)
        {
            // Bắt lỗi không cho nhập trống tên và sđt
            if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(sdt))
                return false;

            // dalHV là cái tên biến DAL bạn khai báo ở đầu file BLL nha (có thể của bạn là HV, nhớ check lại)
            return HV.SuaHoiVien(mahv, ten, gioitinh, sdt);
        }
        public DataTable TimKiem(string ten)
        {
            return HV.TimKiemHoiVien(ten);
        }
        public bool Xoa(int mahv)
        {
            return HV.XoaHoiVien(mahv);
        }
    }
}
