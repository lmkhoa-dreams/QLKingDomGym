using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QLPhongGym
{
        public class DAL_DangKy : DBConnect
        {
            public DataTable getGoiTap()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM goitap", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public DataTable getPT()
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM pt", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            public void themDangKy(string ten, string sdt, int magoi, int mapt)
            {
                conn.Open();
                // Bạn cần lưu vào bảng hoivien trước, sau đó mới lưu vào bảng dangky
                // Để đơn giản bước đầu, mình sẽ viết logic lưu trực tiếp vào bảng dangky
                string sql = "INSERT INTO dangky (hoivien_ten, sdt, goitap_magoi, pt_mapt, ngay_dangky) " +
                         "VALUES (@ten, @sdt, @magoi, @mapt, GETDATE())";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", ten);
                cmd.Parameters.AddWithValue("@sdt", sdt);
                cmd.Parameters.AddWithValue("@magoi", magoi);
                cmd.Parameters.AddWithValue("@mapt", mapt);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        public void ThemMoiHoiVienVaDangKy(string ten, string sdt, int magoi, int mapt)
        {
            try
            {
                conn.Open();
                // 1. Thêm hội viên mới và lấy mã (ID) tự động sinh ra
                string sqlHV = "INSERT INTO hoivien (ten, sdt) OUTPUT INSERTED.mahv VALUES (@ten, @sdt)";
                SqlCommand cmd1 = new SqlCommand(sqlHV, conn);
                cmd1.Parameters.AddWithValue("@ten", ten);
                cmd1.Parameters.AddWithValue("@sdt", sdt);
                int maMoi = (int)cmd1.ExecuteScalar();

                // 2. Thêm vào bảng đăng ký bằng mã hội viên vừa lấy được
                string sqlDK = "INSERT INTO dangky (hoivien_mahv, goitap_magoi, pt_mapt, ngay_dangky) " +
                               "VALUES (@mahv, @magoi, @mapt, GETDATE())";
                SqlCommand cmd2 = new SqlCommand(sqlDK, conn);
                cmd2.Parameters.AddWithValue("@mahv", maMoi);
                cmd2.Parameters.AddWithValue("@magoi", magoi);
                cmd2.Parameters.AddWithValue("@mapt", mapt);
                cmd2.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    } 
}
