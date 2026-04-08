using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_QLPhongGym
{
    public class DAL_GoiTap
    {
        string connStr = @"Data Source=localhost;Initial Catalog=KingDomGym;Integrated Security=True";
        public DataTable GetAll()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM goitap";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool Insert(string tenGoi, decimal giaTien)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO goitap (tengoi, giatien) VALUES (@Ten, @Gia)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Ten", tenGoi);
                cmd.Parameters.AddWithValue("@Gia", giaTien);

                conn.Open();
                int kq = cmd.ExecuteNonQuery();
                conn.Close();

                return kq > 0;
            }
        }
        public bool Delete(int maGoi)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "DELETE FROM goitap WHERE magoi = @Ma";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Ma", maGoi);

                conn.Open();
                int kq = cmd.ExecuteNonQuery();
                conn.Close();

                return kq > 0;
            }
        }
    }
}