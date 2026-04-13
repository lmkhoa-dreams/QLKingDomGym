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
        BLL_GoiTap GT = new BLL_GoiTap();
        BLL_PT PT = new BLL_PT();
        public frmDSHV()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            dgvDSHV.DataSource = HV.LayDanhSach();
            dgvDSHV.Columns["Mã HV"].ReadOnly = true;
            dgvDSHV.Columns["Gói Tập"].ReadOnly = true;
            dgvDSHV.Columns["Tên PT"].ReadOnly = true;
            dgvDSHV.Columns["Ngày ĐK"].ReadOnly = true;

            // Lấy dữ liệu gói tập
            DataTable dtGoi = GT.LayDSGoiTap();
            DataRow drGoi = dtGoi.NewRow();
            drGoi["magoi"] = 0;
            drGoi["tengoi"] = "Hủy đăng ký";
            dtGoi.Rows.InsertAt(drGoi, 0);

            cboGoiTapCapNhat.DataSource = dtGoi;
            cboGoiTapCapNhat.DisplayMember = "tengoi";
            cboGoiTapCapNhat.ValueMember = "magoi";

            // Lấy dữ liệu PT
            DataTable dtPT = PT.LayDSPT();
            DataRow drPT = dtPT.NewRow();
            drPT["mapt"] = 0;
            drPT["ten"] = "Không thuê PT";
            dtPT.Rows.InsertAt(drPT, 0);

            cboPTCapNhat.DataSource = dtPT;
            cboPTCapNhat.DisplayMember = "ten";
            cboPTCapNhat.ValueMember = "mapt";

            cboGoiTapCapNhat.SelectedIndex = -1;
            cboPTCapNhat.SelectedIndex = -1;
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
                DialogResult kq = MessageBox.Show($"Bạn có chắc chắn muốn xóa hội viên {ten} không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
            // Lấy thông tin
            int rowIndex = e.RowIndex;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra có click dòng trên dataview ko
            if (dgvDSHV.CurrentRow != null)
            {
                int mahv = Convert.ToInt32(dgvDSHV.CurrentRow.Cells["Mã HV"].Value);

                if (cboGoiTapCapNhat.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn gói tập muốn đăng ký!");
                    return;
                }

                int magoi = Convert.ToInt32(cboGoiTapCapNhat.SelectedValue);

                int mapt = 0;
                if (cboPTCapNhat.SelectedValue != null)
                {
                    mapt = Convert.ToInt32(cboPTCapNhat.SelectedValue);
                }
                // Gọi BLL 
                if (HV.CapNhatHV(mahv, magoi, mapt))
                {
                    MessageBox.Show("Cập nhật gói tập thành công!");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn một hội viên trong bảng ở trên trước!");
            }
        }

        private void btnCapNhatSDT_Click(object sender, EventArgs e)
        {
            if (dgvDSHV.CurrentRow != null)
            {
                int mahv = Convert.ToInt32(dgvDSHV.CurrentRow.Cells["Mã HV"].Value);

                string sdtMoi = txtSDT.Text.Trim();

                if (HV.CapNhatSoDienThoai(mahv, sdtMoi))
                {
                    MessageBox.Show($"Đã cập nhật SĐT mới cho hội viên {mahv}!", "Thành công");
                    LoadData(); 
                    txtSDT.Clear(); 
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại! Vui lòng kiểm tra lại dữ liệu.", "Lỗi");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hội viên cần đổi SĐT trên bảng!");
            }
        }
    }
}
