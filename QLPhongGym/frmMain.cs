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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDK_Click(object sender, EventArgs e)
        {
            frmDK DK = new frmDK();
            DK.ShowDialog();
        }
        private void btnDSHV_Click(object sender, EventArgs e)
        {
            frmDSHV dSHV = new frmDSHV();
            dSHV.ShowDialog();
        }
        private void btnPT_Click(object sender, EventArgs e)
        {
            frmQLPT PT = new frmQLPT();
            PT.ShowDialog();
        }
        private void btnGT_Click(object sender, EventArgs e)
        {
            frmGT GT = new frmGT();
            GT.ShowDialog();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
