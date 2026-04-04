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
    public partial class frmLogin : Form
    {
        BLL_DangNhap bllTK = new BLL_DangNhap();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
                string user = txtTaiKhoan.Text;
                string pass = txtMatKhau.Text;

                if (bllTK.Login(user, pass))
                {
                    frmMain main = new frmMain();
                    this.Hide();
                    main.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
            }
    }
}
