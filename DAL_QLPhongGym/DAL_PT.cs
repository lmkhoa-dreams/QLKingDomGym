using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLPhongGym
{
    public class DAL_PT
    {
        string connStr = @"Data Source=localhost;Initial Catalog=KingDomGym;Integrated Security=True";

        public DataTable GetPT()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT mapt, ten FROM pt";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
