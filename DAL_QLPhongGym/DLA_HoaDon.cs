using DTO_QLPhongGym;
using System.Data.SqlClient;

public class DAL_HoaDon
{
    DBConnect db = new DBConnect(); // Lớp kết nối của bạn

    public bool LuuHoaDon(DTO_HoaDon hd)
    {
        string sql = "INSERT INTO HoaDon(MaHV, TongTien, PhuongThuc) VALUES(@mahv, @tien, @pt)";
        SqlConnection conn = db.GetConnection();
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@mahv", hd.MaHV);
        cmd.Parameters.AddWithValue("@tien", hd.TongTien);
        cmd.Parameters.AddWithValue("@pt", hd.PhuongThuc);

        conn.Open();
        int res = cmd.ExecuteNonQuery();
        conn.Close();
        return res > 0;
    }
}