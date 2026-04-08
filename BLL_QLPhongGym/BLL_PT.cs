using DAL_QLPhongGym;
using DTO_QLPhongGym;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QLPhongGym
{
    public class BLL_PT
    {
        DAL_PT PT = new DAL_PT();
        public DataTable LayDSPT()
        {
            return PT.GetPT();
        }
        public bool ThemPT(DTO_PT pt)
        {
            if (string.IsNullOrWhiteSpace(pt.Ten) || string.IsNullOrWhiteSpace(pt.SDT))
            {
                return false;
            }

            return PT.ThemPT(pt);
        }
        public bool XoaPT(int maPT)
        {
            return PT.XoaPT(maPT);
        }
    }
}
