using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO_QLPhongGym;

namespace DAL_QLPhongGym
{
    public class DAL_HoiVien
    {
        string connStr = @"Data Source=localhost;Initial Catalog=KingDomGym;Integrated Security=True";
        // Nhớ thêm dòng using System.Collections.Generic; ở trên cùng nếu nó báo lỗi chữ List nha
        public List<DTO_HoiVien> GetDanhSachHoiVien()
        {
            List<DTO_HoiVien> dsHoiVien = new List<DTO_HoiVien>(); // Chiếc xe tải chở DTO

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = @"
            SELECT hv.mahv, hv.ten, hv.gioitinh, hv.sdt, 
                   gt.tengoi, pt.ten as tenpt, dk.ngay_dangky
            FROM hoivien hv
            LEFT JOIN dangky dk ON hv.mahv = dk.hoivien_mahv
            LEFT JOIN goitap gt ON dk.goitap_magoi = gt.magoi
            LEFT JOIN pt ON dk.pt_mapt = pt.mapt";

                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DTO_HoiVien hv = new DTO_HoiVien();

                    // Bắt đầu nhét đồ vào thùng
                    hv.MaHV = Convert.ToInt32(reader["mahv"]);
                    hv.Ten = reader["ten"].ToString();
                    hv.GioiTinh = reader["gioitinh"].ToString();
                    hv.SDT = reader["sdt"].ToString();

                    // Những cột LEFT JOIN có thể bị rỗng (NULL), phải kiểm tra kỹ bằng DBNull.Value để không bị lỗi văng app
                    hv.TenGoiTap = reader["tengoi"] != DBNull.Value ? reader["tengoi"].ToString() : "Chưa đăng ký";
                    hv.TenPT = reader["tenpt"] != DBNull.Value ? reader["tenpt"].ToString() : "Không thuê";

                    // Quăng cái thùng đã đóng gói lên xe tải
                    dsHoiVien.Add(hv);
                }
            }
            return dsHoiVien;
        }

        //Thêm hội viên mới
        public bool ThemHoiVien(DTO_HoiVien hv)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    string sqlHV = "INSERT INTO hoivien(ten, gioitinh, sdt) OUTPUT INSERTED.mahv VALUES (@ten, @gioitinh, @sdt)";
                    SqlCommand cmdHV = new SqlCommand(sqlHV, conn, transaction);

                    cmdHV.Parameters.AddWithValue("@ten", hv.Ten);
                    cmdHV.Parameters.AddWithValue("@gioitinh", hv.GioiTinh);
                    cmdHV.Parameters.AddWithValue("@sdt", hv.SDT);

                    int mahv = (int)cmdHV.ExecuteScalar();

                    string sqlDK = "INSERT INTO dangky(hoivien_mahv, goitap_magoi, pt_mapt, ngay_dangky) VALUES (@mahv, @magoi, @mapt, @ngay)";
                    SqlCommand cmdDK = new SqlCommand(sqlDK, conn, transaction);
                    cmdDK.Parameters.AddWithValue("@mahv", mahv);
                    cmdDK.Parameters.AddWithValue("@magoi", hv.IdGoiTap);
                    cmdDK.Parameters.AddWithValue("@ngay", DateTime.Now.Date);

                    if (hv.IdPT == 0)
                        cmdDK.Parameters.AddWithValue("@mapt", DBNull.Value);
                    else
                        cmdDK.Parameters.AddWithValue("@mapt", hv.IdPT);

                    cmdDK.ExecuteNonQuery();
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }
        public bool SuaHoiVien(int mahv, string tenMoi, string gioiTinhMoi, string sdtMoi)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "UPDATE hoivien SET ten = @ten, gioitinh = @gioitinh, sdt = @sdt WHERE mahv = @mahv";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ten", tenMoi);
                cmd.Parameters.AddWithValue("@gioitinh", gioiTinhMoi);
                cmd.Parameters.AddWithValue("@sdt", sdtMoi);
                cmd.Parameters.AddWithValue("@mahv", mahv);

                int kq = cmd.ExecuteNonQuery();
                return kq > 0;
            }
        }
        public DataTable TimKiemHoiVien(string tenTK)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //Dùng LEFT JOIN lúc load danh sách để mất dữ liệu
                string sql = @"
            SELECT hv.mahv as 'Mã HV', hv.ten as 'Họ Tên', hv.gioitinh as 'Giới Tính', hv.sdt as 'SĐT', 
                   gt.tengoi as 'Gói Tập', pt.ten as 'Tên PT', dk.ngay_dangky as 'Ngày ĐK'
            FROM hoivien hv
            LEFT JOIN dangky dk ON hv.mahv = dk.hoivien_mahv
            LEFT JOIN goitap gt ON dk.goitap_magoi = gt.magoi
            LEFT JOIN pt ON dk.pt_mapt = pt.mapt
            WHERE hv.ten LIKE @ten";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@ten", "%" + tenTK + "%");
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool XoaHoiVien(int mahv)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlDK = "DELETE FROM dangky WHERE hoivien_mahv = @mahv";
                    SqlCommand cmdDK = new SqlCommand(sqlDK, conn, trans);
                    cmdDK.Parameters.AddWithValue("@mahv", mahv);
                    cmdDK.ExecuteNonQuery();

                    string sqlHV = "DELETE FROM hoivien WHERE mahv = @mahv";
                    SqlCommand cmdHV = new SqlCommand(sqlHV, conn, trans);
                    cmdHV.Parameters.AddWithValue("@mahv", mahv);
                    cmdHV.ExecuteNonQuery();

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }
    }
}
