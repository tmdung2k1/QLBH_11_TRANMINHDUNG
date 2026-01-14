using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH_11_TRANMINHDUNG.Class;

namespace QLBH_11_TRANMINHDUNG
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void chấtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mnu_file_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pic_bg_Click(object sender, EventArgs e)
        {
           
        }

        private void mnu_file_Click_1(object sender, EventArgs e)
        {
           Functions.Disconnect(); // Đóng kết nối
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Functions.Connect(); // Mở kết nối
        }
    }
}
