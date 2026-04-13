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
        public DataTable GetDanhSachHoiVien()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
            SELECT hv.mahv as 'Mã HV', hv.ten as 'Họ Tên', hv.gioitinh as 'Giới Tính', hv.sdt as 'SĐT', 
                   ISNULL(gt.tengoi, N'Chưa đăng ký') as 'Gói Tập', 
                   ISNULL(pt.ten, N'Không thuê') as 'Tên PT', 
                   dk.ngay_dangky as 'Ngày ĐK'
            FROM hoivien hv
            LEFT JOIN dangky dk ON hv.mahv = dk.hoivien_mahv
            LEFT JOIN goitap gt ON dk.goitap_magoi = gt.magoi
            LEFT JOIN pt ON dk.pt_mapt = pt.mapt";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        //Thêm hội viên mới
        // Sửa hàm: Thêm 2 tham số tongTien và phuongThuc
        public bool ThemHoiVien(DTO_HoiVien hv, decimal tongTien, string phuongThuc)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    // --- BƯỚC 1: THÊM HỘI VIÊN VÀ LẤY MÃ ---
                    string sqlHV = "INSERT INTO hoivien(ten, gioitinh, sdt) OUTPUT INSERTED.mahv VALUES (@ten, @gioitinh, @sdt)";
                    SqlCommand cmdHV = new SqlCommand(sqlHV, conn, transaction);
                    cmdHV.Parameters.AddWithValue("@ten", hv.Ten);
                    cmdHV.Parameters.AddWithValue("@gioitinh", hv.GioiTinh);
                    cmdHV.Parameters.AddWithValue("@sdt", hv.SDT);

                    int mahv = (int)cmdHV.ExecuteScalar();

                    // --- BƯỚC 2: THÊM VÀO BẢNG ĐĂNG KÝ ---
                    string sqlDK = "INSERT INTO dangky(hoivien_mahv, goitap_magoi, pt_mapt, ngay_dangky) VALUES (@mahv, @magoi, @mapt, @ngay)";
                    SqlCommand cmdDK = new SqlCommand(sqlDK, conn, transaction);
                    cmdDK.Parameters.AddWithValue("@mahv", mahv);
                    cmdDK.Parameters.AddWithValue("@magoi", hv.IdGoiTap);
                    cmdDK.Parameters.AddWithValue("@ngay", hv.NgayDK);

                    if (hv.IdPT == 0)
                        cmdDK.Parameters.AddWithValue("@mapt", DBNull.Value);
                    else
                        cmdDK.Parameters.AddWithValue("@mapt", hv.IdPT);

                    cmdDK.ExecuteNonQuery();

                    // --- BƯỚC 3: THÊM VÀO BẢNG HÓA ĐƠN (PHẦN TÍCH HỢP MỚI) ---
                    string sqlHD = "INSERT INTO hoadon(hoivien_mahv, ngay_thanhtoan, tong_tien, phuong_thuc) VALUES (@mahv, GETDATE(), @tongtien, @pt)";
                    SqlCommand cmdHD = new SqlCommand(sqlHD, conn, transaction);
                    cmdHD.Parameters.AddWithValue("@mahv", mahv);
                    cmdHD.Parameters.AddWithValue("@tongtien", tongTien);
                    cmdHD.Parameters.AddWithValue("@pt", phuongThuc);

                    cmdHD.ExecuteNonQuery();

                    // XÁC NHẬN LƯU TẤT CẢ
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // NẾU LỖI BẤT KỲ BƯỚC NÀO, HỦY BỎ TOÀN BỘ
                    transaction.Rollback();
                    return false;
                }
            }
        }
        // Chỉnh sửa DSHV
        public bool CapNhatHV(int mahv, int magoi, int mapt)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "";

                if (magoi == 0)
                {
                    sql = "DELETE FROM dangky WHERE hoivien_mahv = @mahv";
                }
                else
                {
                    sql = @"
                IF EXISTS (SELECT 1 FROM dangky WHERE hoivien_mahv = @mahv)
                    UPDATE dangky SET goitap_magoi = @magoi, pt_mapt = @mapt, ngay_dangky = GETDATE() WHERE hoivien_mahv = @mahv
                ELSE
                    INSERT INTO dangky(hoivien_mahv, goitap_magoi, pt_mapt, ngay_dangky) VALUES (@mahv, @magoi, @mapt, GETDATE())";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mahv", mahv);

                if (magoi > 0)
                {
                    cmd.Parameters.AddWithValue("@magoi", magoi);
                    if (mapt == 0) cmd.Parameters.AddWithValue("@mapt", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@mapt", mapt);
                }

                return cmd.ExecuteNonQuery() >= 0;
            }
        }
        // Thêm cập nhật số điện thoại
        public bool UpdateSDTHoiVien(int mahv, string sdtMoi)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "UPDATE hoivien SET sdt = @sdt WHERE mahv = @ma";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sdt", sdtMoi);
                    cmd.Parameters.AddWithValue("@ma", mahv);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
