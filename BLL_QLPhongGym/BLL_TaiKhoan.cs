using DAL_QLPhongGym;

namespace BLL_QLPhongGym
{
    public class BLL_TaiKhoan
    {
        DAL_TaiKhoan dalTK = new DAL_TaiKhoan();

        public bool Login(string user, string pass)
        {
            // Có thể thêm logic kiểm tra trống ở đây
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
                return false;

            return dalTK.checkLogin(user, pass);
        }
    }
}