using System;
using System.Windows.Forms;

namespace QLPhongGym
{
    public partial class frmThanhToan : Form
    {
        public frmThanhToan(string hoTen, string goiTap, string giaTien)
        {
            InitializeComponent();
            txtTenHoiVien.Text = hoTen;
            cbGoitap.Text = goiTap;
            txtSoTien.Text = giaTien;
        }// Dán đoạn này vào dưới hàm frmThanhToan
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoTien.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền thanh toán!");
                return;
            }
            this.DialogResult = DialogResult.OK; // Tấm vé thông hành báo về Form Đăng ký
            this.Close();
        }

        // 1. Code cho nút Thoát
        private void btnThoat_Click_1(object sender, EventArgs e) // Tên mới mặc kệ nó
        {
            this.Close();
        }

        // 2. Code cho nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Lệnh xóa trắng ô nhập tiền để nhập lại
            txtSoTien.Clear();
            txtSoTien.Focus(); // Đưa con trỏ chuột quay lại ô tiền
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}


  