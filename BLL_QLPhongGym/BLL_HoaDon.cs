using DAL_QLPhongGym;
using DTO_QLPhongGym;

namespace BLL_QLPhongGym
{
    public class BLL_HoaDon
    {
        DAL_HoaDon dalHD = new DAL_HoaDon();

        public bool ThanhToan(DTO_HoaDon hd)
        {
            // Có thể thêm logic kiểm tra tiền > 0 ở đây
            return dalHD.LuuHoaDon(hd);
        }
    }
}