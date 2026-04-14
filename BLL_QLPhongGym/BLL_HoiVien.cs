using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLPhongGym;
using System.Data;
using DTO_QLPhongGym;
using System.ComponentModel;

namespace BLL_QLPhongGym
{
    public class BLL_HoiVien
    {
        DAL_HoiVien HV = new DAL_HoiVien();
        public DataTable LayDanhSach()
        {
            return HV.GetDanhSachHoiVien();
        }
        public bool ThemHoiVien(DTO_HoiVien hv)
        {
            if (string.IsNullOrWhiteSpace(hv.Ten) || string.IsNullOrWhiteSpace(hv.SDT))
            {
                return false;
            }
            return HV.ThemHoiVien(hv);
        }
        public bool Sua(int mahv, string ten, string gioitinh, string sdt)
        {
            if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(sdt))
                return false;

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
        public bool CapNhatHV(int mahv, int magoi, int mapt)
        {
            return HV.CapNhatHV(mahv, magoi, mapt);
        }
    }
}
