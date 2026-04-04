using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QLPhongGym;
using System.Data;

namespace BLL_QLPhongGym
{
    public class BLL_PT
    {
        DAL_PT PT = new DAL_PT();
        public DataTable LayDSPT()
        {
            return PT.GetPT();
        }
    }
}
