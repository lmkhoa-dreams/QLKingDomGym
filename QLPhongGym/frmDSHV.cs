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
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSHV.CurrentRow != null)
            {
                int mahv = Convert.ToInt32(dgvDSHV.CurrentRow.Cells["Mã HV"].Value);
                string ten = dgvDSHV.CurrentRow.Cells["Họ Tên"].Value.ToString();
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
            dgvDSHV.Columns["Mã HV"].ReadOnly = true;
            dgvDSHV.Columns["Gói Tập"].ReadOnly = true;
            dgvDSHV.Columns["Tên PT"].ReadOnly = true;
            dgvDSHV.Columns["Ngày ĐK"].ReadOnly = true;

            // Đổi màu nền mấy cột bị khóa
            dgvDSHV.Columns["Mã HV"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvDSHV.Columns["Gói Tập"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvDSHV.Columns["Tên PT"].DefaultCellStyle.BackColor = Color.LightGray;
            dgvDSHV.Columns["Ngày ĐK"].DefaultCellStyle.BackColor = Color.LightGray;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy thông tin của dòng vừa bị sửa
            int rowIndex = e.RowIndex;

            //Lấy mahv để biết đang sửa ai
            int mahv = Convert.ToInt32(dgvDSHV.Rows[rowIndex].Cells["Mã HV"].Value); 
            string tenMoi = dgvDSHV.Rows[rowIndex].Cells["Họ Tên"].Value?.ToString() ?? "";
            string gioiTinhMoi = dgvDSHV.Rows[rowIndex].Cells["Giới Tính"].Value?.ToString() ?? "";
            string sdtMoi = dgvDSHV.Rows[rowIndex].Cells["SĐT"].Value?.ToString() ?? "";

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
