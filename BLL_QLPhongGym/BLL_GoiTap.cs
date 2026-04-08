using System.Data;
using DAL_QLPhongGym;

namespace BLL_QLPhongGym
{
    public class BLL_GoiTap
    {
        DAL_GoiTap dal = new DAL_GoiTap();

        public DataTable GetAll()
        {
            return dal.GetAll();
        }

        // 🔥 THÊM HÀM NÀY
        public DataTable LayDSGoiTap()
        {
            return dal.GetAll();
        }

        public bool Add(string tenGoi, decimal giaTien)
        {
            if (string.IsNullOrEmpty(tenGoi))
                return false;

            return dal.Insert(tenGoi, giaTien);
        }

        public bool Delete(int ma)
        {
            return dal.Delete(ma);
        }
    }
}