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
            frmDMChatlieu frm = new frmDMChatlieu();
            frm.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMkhachhang frm = new frmDMkhachhang();
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.MdiParent = this;
            frm.Show();
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

        private void mnu_hanghoa_Click(object sender, EventArgs e)
        {
            frmDMhanghoa frm = new frmDMhanghoa();
            frm.MdiParent = this;
            frm.Show();
        }
        private void mnu_nhanvien_Click(object sender, EventArgs e)
        {
            frmDMNhanvien frm = new frmDMNhanvien();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnu_hoadonban_Click(object sender, EventArgs e)
        {
            frmHDbanhang frm = new frmHDbanhang();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnufind_hoadon_Click(object sender, EventArgs e)
        {
            frmTimkiemhoadon frm = new frmTimkiemhoadon();
            frm.ShowDialog();
        }

        private void mnufind_hang_Click(object sender, EventArgs e)
        {
            frmTimkiemhanghoa frm = new frmTimkiemhanghoa();
            frm.ShowDialog();
        }

        private void mnufind_khachhang_Click(object sender, EventArgs e)
        {
            frmTimkiemkhachhang frm = new frmTimkiemkhachhang();
            frm.ShowDialog();
        }

        private void mnuBC_sanpham_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC_hangton_Click(object sender, EventArgs e)
        {
            frmBaoCaoHangTon frm = new frmBaoCaoHangTon();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuBC_doanhthu_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu frm = new frmBaoCaoDoanhThu();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuHien_trogiup_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://timoday.edu.vn/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở trình duyệt. Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
