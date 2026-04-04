using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLPhongGym;
using System.Data;

namespace BLL_QLPhongGym
{
    public class BLL_GoiTap
    {
        DAL_GoiTap GT = new DAL_GoiTap();
        public DataTable LayDSGoiTap()
        {
            return GT.GetGoiTap();
        }
    }
}