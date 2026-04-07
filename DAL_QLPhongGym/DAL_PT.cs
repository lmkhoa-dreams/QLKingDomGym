using DTO_QLPhongGym;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLPhongGym
{
    public class DAL_PT
    {
        string connStr = @"Data Source=localhost;Initial Catalog=KingDomGym;Integrated Security=True";

        public DataTable GetPT()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT mapt, ten, gioitinh, sdt FROM pt";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool ThemPT(DTO_PT pt)
        {
            string sql = "INSERT INTO pt (ten, gioitinh, sdt) VALUES (@ten, @gioitinh, @sdt)";

            // Tái sử dụng biến connStr đã có sẵn ở đầu class
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    // Truyền tham số để tránh lỗi SQL Injection
                    cmd.Parameters.AddWithValue("@ten", pt.Ten);
                    cmd.Parameters.AddWithValue("@gioitinh", pt.GioiTinh);
                    cmd.Parameters.AddWithValue("@sdt", pt.SDT);

                    try
                    {
                        conn.Open();
                        int result = cmd.ExecuteNonQuery(); // Thực thi câu lệnh INSERT
                        return result > 0; // Nếu insert thành công, result sẽ > 0
                    }
                    catch
                    {
                        return false; // Bắt lỗi nếu có vấn đề khi lưu vào DB
                    }
                }
            }
        }
        public bool XoaPT(int maPT)
        {
            string sql = "DELETE FROM pt WHERE mapt = @mapt";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@mapt", maPT);
                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
