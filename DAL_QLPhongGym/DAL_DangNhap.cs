using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLPhongGym
{
    public class DAL_DangNhap
    {
        string connStr = @"Data Source=localhost;Initial Catalog=KingDomGym;Integrated Security=True";

        public bool CheckLogin(string user, string pass)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM taikhoan WHERE tendangnhap = @user AND matkhau = @pass";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}