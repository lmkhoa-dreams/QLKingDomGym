using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QLPhongGym;
using DTO_QLPhongGym;

namespace QLPhongGym
{
    public partial class frmDK : Form
    {
        BLL_HoiVien HV = new BLL_HoiVien();
        BLL_GoiTap GT = new BLL_GoiTap();
        BLL_PT PT = new BLL_PT();
        public frmDK()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmDK_Load(object sender, EventArgs e)
        {
            {
                cbGT.DataSource = GT.LayDSGoiTap();
                cbGT.DisplayMember = "tengoi";
                cbGT.ValueMember = "magoi";

                cbPT.DataSource = PT.LayDSPT();
                cbPT.DisplayMember = "ten";
                cbPT.ValueMember = "mapt";

                cbGioiTinh.SelectedIndex = -1;
                cbGT.SelectedIndex = -1;
                cbPT.SelectedIndex = -1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbGT.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn gói tập!", "Cảnh báo");
                return;
            }

            DTO_HoiVien hv = new DTO_HoiVien();
            hv.Ten = txtHVT.Text;
            hv.SDT = txtSDT.Text;
            hv.GioiTinh = cbGioiTinh.Text;
            hv.IdGoiTap = Convert.ToInt32(cbGT.SelectedValue);
            hv.NgayDK = dtpNgayDK.Value;

            if (cbPT.SelectedValue != null)
                hv.IdPT = Convert.ToInt32(cbPT.SelectedValue);
            else
                hv.IdPT = 0;

            // CHỖ THAY ĐỔI BẮT ĐẦU TỪ ĐÂY
            // --- THAY THẾ TỪ DÒNG 71 TẠI ĐÂY ---

            // 1. Lấy thông tin để truyền sang form Thanh Toán
            string hoTen = txtHVT.Text;
            string goiTap = cbGT.Text;

            // 2. Khởi tạo và mở Form Thanh Toán trước khi lưu CSDL
            frmThanhToan frm = new frmThanhToan(hoTen, goiTap, ""); // Để trống tiền để tự nhập bên kia

            // 3. Kiểm tra nếu người dùng nhấn nút "Xác Nhận" trên Form Thanh Toán
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 4. Khi đã thanh toán xong (nhấn Xác nhận), lúc này mới gọi lệnh lưu vào CSDL
                if (HV.ThemHoiVien(hv))
                {
                    MessageBox.Show("Đăng ký và Thanh toán thành công!", "Thông báo");
                    btnXoa_Click(sender, e); // Làm mới form sau khi hoàn tất
                }
                else
                {
                    MessageBox.Show("Lưu dữ liệu thất bại, vui lòng kiểm tra lại!");
                }
            }
            else
            {
                // Trường hợp người dùng nhấn Thoát hoặc đóng Form thanh toán mà không xác nhận
                MessageBox.Show("Hủy bỏ đăng ký!", "Thông báo");
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // CHỈ KHI NÀO BẠN GÁN DialogResult = OK THÌ ĐOẠN CODE LƯU CSDL NÀY MỚI CHẠY
                if (HV.ThemHoiVien(hv))
                {
                    MessageBox.Show("Đăng ký thành công!");
                }
            }
        } // Dấu đóng của hàm btnThem_Click
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHVT.Clear();
            txtSDT.Clear();

            cbGioiTinh.SelectedIndex = -1;
            cbGT.SelectedIndex = -1;
            cbPT.SelectedIndex = -1;

            txtHVT.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dtpNgayDK_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayDK_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void txtHVT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

