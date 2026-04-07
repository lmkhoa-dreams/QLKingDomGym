using BLL_QLPhongGym;
using DTO_QLPhongGym;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLPhongGym
{
    public partial class frmQLPT : Form
    {
        private BLL_PT bllPT = new BLL_PT();
        public frmQLPT()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            BLL_PT dal = new BLL_PT();
            dgvPT.DataSource = dal.LayDSPT();
            dgvPT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmQLPT_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenPT = txtTenPT.Text.Trim(); // txtTen là ô nhập Tên
            string gioiTinh = cbGioiTinh.Text.Trim(); // cboGioiTinh là ô chọn Nam/Nữ
            string sdt = txtSDT.Text.Trim(); // txtSDT là ô nhập Số điện thoại

            // (Tùy chọn) Kiểm tra xem người dùng có nhập thiếu thông tin không
            if (string.IsNullOrEmpty(tenPT) || string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Tên, Giới tính, SĐT)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng lại, không chạy tiếp code bên dưới
            }

            // 2. Đóng gói dữ liệu vào DTO_PT
            DTO_PT ptMoi = new DTO_PT(tenPT, gioiTinh, sdt);

            // 3. Gọi lớp BLL (hoặc DAL nếu bạn gọi trực tiếp) để lưu vào SQL
            BLL_PT dal_pt = new BLL_PT(); // Nếu bạn dùng BLL thì đổi thành BLL_PT

            bool ketQua = dal_pt.ThemPT(ptMoi);

            // 4. Thông báo kết quả cho người dùng
            if (ketQua == true)
            {
                MessageBox.Show("Đã thêm PT thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa trắng các ô nhập liệu để chuẩn bị nhập người khác
                txtTenPT.Clear();
                txtSDT.Clear();
                cbGioiTinh.SelectedIndex = -1;

                // Nếu bạn có hàm Load lại danh sách lên bảng DataGridView thì gọi ở đây
                LoadData(); 
            }
            else
            {
                MessageBox.Show("Thêm thất bại. Vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvPT.SelectedRows.Count > 0)
            {
                // Lấy mã PT của dòng đang chọn
                int maPT = Convert.ToInt32(dgvPT.SelectedRows[0].Cells["mapt"].Value);

                DialogResult hoi = MessageBox.Show("Bạn có muốn xóa PT này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (hoi == DialogResult.Yes)
                {
                    BLL_PT dal = new BLL_PT();
                    if (dal.XoaPT(maPT))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadData(); // Cập nhật lại bảng
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn một dòng PT ở bảng bên dưới để xóa!", "Thông báo");
            }
        }
    }
}