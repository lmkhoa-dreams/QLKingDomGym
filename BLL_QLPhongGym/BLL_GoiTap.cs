using System.Data;
using DAL_QLPhongGym;

namespace BLL_QLPhongGym
{
    public class BLL_GoiTap
    {
        DAL_GoiTap GT = new DAL_GoiTap();

        public DataTable GetAll()
        {
            return GT.GetAll();
        }
        public DataTable LayDSGoiTap()
        {
            return GT.GetAll();
        }

        public bool Add(string tenGoi, decimal giaTien)
        {
            if (string.IsNullOrEmpty(tenGoi))
                return false;

            return GT.Insert(tenGoi, giaTien);
        }

        public bool Delete(int ma)
        {
            return GT.Delete(ma);
        }
    }
}