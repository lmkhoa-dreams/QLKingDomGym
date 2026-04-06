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

namespace QLPhongGym
{
    public partial class frmDSHV : Form
    {
        BLL_HoiVien HV = new BLL_HoiVien();
        public frmDSHV()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDSHV.DataSource = HV.LayDanhSach();
            dgvDSHV.Columns["MaHV"].HeaderText = "Mã HV";
            dgvDSHV.Columns["Ten"].HeaderText = "Họ Tên";
            dgvDSHV.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvDSHV.Columns["SDT"].HeaderText = "SĐT";
            dgvDSHV.Columns["TenGoiTap"].HeaderText = "Gói Tập";
            dgvDSHV.Columns["TenPT"].HeaderText = "Tên PT";
            dgvDSHV.Columns["IdGoiTap"].Visible = false;
            dgvDSHV.Columns["IdPT"].Visible = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSHV.CurrentRow != null)
            {
                int mahv = Convert.ToInt32(dgvDSHV.CurrentRow.Cells["MaHV"].Value);
                string ten = dgvDSHV.CurrentRow.Cells["Ten"].Value.ToString();
                DialogResult kq = MessageBox.Show($"Bạn có chắc chắn muốn xóa hội viên [{ten}] không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (kq == DialogResult.Yes)
                {
                    //Gọi hàm Xoa ở BLL
                    if (HV.Xoa(mahv))
                    {
                        MessageBox.Show("Đã xóa thành công!");
                        dgvDSHV.DataSource = HV.LayDanhSach();
                    }
                    else
                    {
                        MessageBox.Show("Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hội viên cần xóa");
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {

        }

        private void frmDSHV_Load(object sender, EventArgs e)
        {
            LoadData();
            dgvDSHV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Cho phép DataGridView được chỉnh sửa
            dgvDSHV.ReadOnly = false;

            //Những cột ko đc phép sửa
            dgvDSHV.Columns["MaHV"].ReadOnly = true;
            dgvDSHV.Columns["TenGoiTap"].ReadOnly = true;
            dgvDSHV.Columns["TenPT"].ReadOnly = true;

            // Đổi màu nền mấy cột bị khóa
            dgvDSHV.Columns["MaHV"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvDSHV.Columns["TenGoiTap"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvDSHV.Columns["TenPT"].DefaultCellStyle.BackColor = Color.LightGray;   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy thông tin của dòng vừa bị sửa
            int rowIndex = e.RowIndex;

            //Lấy mahv để biết đang sửa ai
            int mahv = Convert.ToInt32(dgvDSHV.Rows[rowIndex].Cells["MaHV"].Value); 
            string tenMoi = dgvDSHV.Rows[rowIndex].Cells["Ten"].Value?.ToString() ?? "";
            string gioiTinhMoi = dgvDSHV.Rows[rowIndex].Cells["GioiTinh"].Value?.ToString() ?? "";
            string sdtMoi = dgvDSHV.Rows[rowIndex].Cells["SDT"].Value?.ToString() ?? "";

            // Gọi BLL
            if (HV.Sua(mahv, tenMoi, gioiTinhMoi, sdtMoi))
            {
            }
            else
            {
                MessageBox.Show("Họ tên và SĐT không được để trống");
                LoadData();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();
            dgvDSHV.DataSource = HV.TimKiem(tuKhoa);
        }
    }
}
