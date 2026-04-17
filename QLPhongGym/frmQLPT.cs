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
            if (dgvPT.Columns.Count > 0)
            {
                dgvPT.Columns["mapt"].HeaderText = "Mã PT";
                dgvPT.Columns["ten"].HeaderText = "Họ và Tên";
                dgvPT.Columns["gioitinh"].HeaderText = "Giới Tính";
                dgvPT.Columns["sdt"].HeaderText = "Số Điện Thoại";

                dgvPT.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
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
            string tenPT = txtTenPT.Text.Trim();
            string gioiTinh = cbGioiTinh.Text.Trim();
            string sdt = txtSDT.Text.Trim();

            if (string.IsNullOrEmpty(tenPT) || string.IsNullOrEmpty(gioiTinh) || string.IsNullOrEmpty(sdt))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin (Tên, Giới tính, SĐT)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DTO_PT ptMoi = new DTO_PT(tenPT, gioiTinh, sdt);

            // Gọi BLL để lưu vào SQL
            BLL_PT dal_pt = new BLL_PT();
            bool ketQua = dal_pt.ThemPT(ptMoi);

            //Thông báo kết quả
            if (ketQua == true)
            {
                MessageBox.Show("Đã thêm PT thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenPT.Clear();
                txtSDT.Clear();
                cbGioiTinh.SelectedIndex = -1;
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
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Đã có người đăng ký ko thể xóa");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn một dòng PT ở bảng bên dưới để xóa!", "Thông báo");
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}