using System.Data;
using System.Data.SqlClient;

namespace DAL_QLPhongGym
{
    public class DAL_TaiKhoan : DBConnect
    {
        public bool checkLogin(string user, string pass)
        {
            conn.Open();
            // Kiểm tra xem có dòng nào khớp cả user và pass không
            string sql = "SELECT COUNT(*) FROM taikhoan WHERE tendangnhap = @user AND matkhau = @pass";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);

            int result = (int)cmd.ExecuteScalar();
            conn.Close();

            return result > 0; // Trả về true nếu tìm thấy
        }
    }
}