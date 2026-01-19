using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLBH_11_TRANMINHDUNG.Class;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace QLBH_11_TRANMINHDUNG
{
    public partial class frmTimkiemhoadon : Form
    {
        DataTable tblHDB;
        public frmTimkiemhoadon()
        {
            InitializeComponent();
        }

        private void frmTimkiemhoadon_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgv_danhsachhoadon.DataSource = null;
        }
        //Phương thức ResetValues
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txt_mahoadon.Focus();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txt_mahoadon.Text == "") && (txt_thang.Text == "") && (txt_nam.Text == "") &&
               (txt_manhanvien.Text == "") && (txt_makhachhang.Text == "") &&
               (txt_tongtien.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            sql = "SELECT * FROM tblHDBan WHERE 1=1";
            if (txt_mahoadon.Text != "")
                sql = sql + " AND MaHDBan Like N'%" + txt_mahoadon.Text + "%'";
            if (txt_thang.Text != "")
                sql = sql + " AND MONTH(NgayBan) =" + txt_thang.Text;
            if (txt_nam.Text != "")
                sql = sql + " AND YEAR(NgayBan) =" + txt_nam.Text;
            if (txt_manhanvien.Text != "")
                sql = sql + " AND MaNhanVien Like N'%" + txt_manhanvien.Text + "%'";
            if (txt_makhachhang.Text != "")
                sql = sql + " AND MaKhach Like N'%" + txt_makhachhang.Text + "%'";
            if (txt_tongtien.Text != "")
                sql = sql + " AND TongTien <=" + txt_tongtien.Text;
            tblHDB = Functions.GetDataToTable(sql);
            if (tblHDB.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHDB.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgv_danhsachhoadon.DataSource = tblHDB;
            LoadDataGridView();

        }
        private void LoadDataGridView()
        {
            dgv_danhsachhoadon.Columns[0].HeaderText = "Mã HĐB";
            dgv_danhsachhoadon.Columns[1].HeaderText = "Mã nhân viên";
            dgv_danhsachhoadon.Columns[2].HeaderText = "Ngày bán";
            dgv_danhsachhoadon.Columns[3].HeaderText = "Mã khách";
            dgv_danhsachhoadon.Columns[4].HeaderText = "Tổng tiền";
            dgv_danhsachhoadon.Columns[0].Width = 150;
            dgv_danhsachhoadon.Columns[1].Width = 100;
            dgv_danhsachhoadon.Columns[2].Width = 80;
            dgv_danhsachhoadon.Columns[3].Width = 80;
            dgv_danhsachhoadon.Columns[4].Width = 80;
            dgv_danhsachhoadon.AllowUserToAddRows = false;
            dgv_danhsachhoadon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_boqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgv_danhsachhoadon.DataSource = null;
        }

        private void txt_tongtien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
