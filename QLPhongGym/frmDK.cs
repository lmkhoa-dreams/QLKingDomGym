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
            string ten = txtHVT.Text;
            string sdt = txtSDT.Text;
            string gioitinh = cbGioiTinh.Text;

            if (cbGT.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn gói tập");
                return;
            }

            // Lấy ID Gói Tập 
            int idGoiTap = Convert.ToInt32(cbGT.SelectedValue);

            // Xử lý ID PT: Nếu không chọn PT thì để mặc định là 0 (xuống DAL sẽ tự chuyển thành NULL)
            int idPT = 0;
            if (cbPT.SelectedValue != null)
            {
                idPT = Convert.ToInt32(cbPT.SelectedValue);
            }

            // Gọi BLL để tống dữ liệu xuống Database
            if (HV.ThemHoiVien(ten, gioitinh, sdt, idGoiTap, idPT))
            {
                MessageBox.Show("Đăng ký thành công!");

                btnXoa_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên và số điện thoại");
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHVT.Clear();
            txtSDT.Clear();

            cbGioiTinh.SelectedIndex = -1;
            cbGT.SelectedIndex = -1;
            cbPT.SelectedIndex = -1;

            txtHVT.Focus();
        }
    }
}

