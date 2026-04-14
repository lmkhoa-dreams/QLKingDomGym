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
                cbGoitap.DataSource = GT.LayDSGoiTap();
                cbGoitap.DisplayMember = "tengoi";
                cbGoitap.ValueMember = "magoi";

                cbPT.DataSource = PT.LayDSPT();
                cbPT.DisplayMember = "ten";
                cbPT.ValueMember = "mapt";

                cbGioiTinh.SelectedIndex = -1;
                cbGoitap.SelectedIndex = -1;
                cbPT.SelectedIndex = -1;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbGoitap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn gói tập!", "Cảnh báo");
                return;
            }

            DTO_HoiVien hv = new DTO_HoiVien();
            hv.Ten = txtHVT.Text;
            hv.SDT = txtSDT.Text;
            hv.GioiTinh = cbGioiTinh.Text;
            hv.IdGoiTap = Convert.ToInt32(cbGoitap.SelectedValue);
            hv.NgayDK = dtpNgayDK.Value;
            hv.IdPT = (cbPT.SelectedValue != null) ? Convert.ToInt32(cbPT.SelectedValue) : 0;

            string giaTien = "0";
            if (cbGoitap.Text.Contains("1 Tháng")) giaTien = "250000";
            else if (cbGoitap.Text.Contains("3 Tháng")) giaTien = "280000";
            else giaTien = "200000"; 

            frmThanhToan frm = new frmThanhToan(hv.Ten, cbGoitap.Text, giaTien);

            if (frm.ShowDialog() == DialogResult.OK)
            {

                if (HV.ThemHoiVien(hv))
                {
                    MessageBox.Show("Đăng ký và Thanh toán thành công!", "Thông báo");
                    btnXoa_Click(sender, e); 
                }
                else
                {
                    MessageBox.Show("Lưu dữ liệu thất bại, vui lòng kiểm tra SQL!");
                }
            }
            else
            {
                MessageBox.Show("Hủy bỏ đăng ký!", "Thông báo");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHVT.Clear();
            txtSDT.Clear();

            cbGioiTinh.SelectedIndex = -1;
            cbGoitap.SelectedIndex = -1;
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

