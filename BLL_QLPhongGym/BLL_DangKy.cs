using DAL_QLPhongGym;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QLPhongGym
{
    public class BLL_DangKy
    {
        DAL_DangKy dalDK = new DAL_DangKy();

        public DataTable getGoiTap()
        {
            return dalDK.getGoiTap();
        }

        public DataTable getPT()
        {
            return dalDK.getPT();
        }
        public void ThemMoiHoiVienVaDangKy(string ten, string sdt, int magoi, int mapt)
        {
            dalDK.ThemMoiHoiVienVaDangKy(ten, sdt, magoi, mapt);
        }
    }
}
