using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLPhongGym;

namespace BLL_QLPhongGym
{
    public class BLL_DangNhap
    {
        DAL_DangNhap dalTK = new DAL_DangNhap();

        public bool Login(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                return false;
            }
            return dalTK.CheckLogin(user, pass);
        }
    }
}
