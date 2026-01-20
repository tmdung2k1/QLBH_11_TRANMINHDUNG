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
    public partial class frmTimkiemhanghoa : Form
    {
        DataTable tblHang;
        DataTable tblChatLieu;

        public frmTimkiemhanghoa()
        {
            InitializeComponent();
        }

        private void frmTimkiemhanghoa_Load(object sender, EventArgs e)
        {
            // Load danh sách chất liệu vào ComboBox
            string sql = "SELECT * FROM tblChatLieu";
            Functions.FillCombo(sql, cbo_machatlieu, "MaChatLieu", "TenChatLieu");
            cbo_machatlieu.SelectedIndex = -1;

            ResetValues();
            dgv_danhsachhanghoa.DataSource = null;
        }

        //Phương thức ResetValues
        private void ResetValues()
        {
            txt_mahang.Text = "";
            txt_tenhang.Text = "";
            cbo_machatlieu.SelectedIndex = -1;
            txt_soluongtu.Text = "";
            txt_soluongden.Text = "";
            txt_dongiatu.Text = "";
            txt_dongiaden.Text = "";
            txt_mahang.Focus();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txt_mahang.Text == "") && (txt_tenhang.Text == "") &&
                (cbo_machatlieu.Text == "") && (txt_soluongtu.Text == "") &&
                (txt_soluongden.Text == "") && (txt_dongiatu.Text == "") &&
                (txt_dongiaden.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, GhiChu FROM tblHang WHERE 1=1";

            if (txt_mahang.Text != "")
                sql = sql + " AND MaHang Like N'%" + txt_mahang.Text + "%'";
            if (txt_tenhang.Text != "")
                sql = sql + " AND TenHang Like N'%" + txt_tenhang.Text + "%'";
            if (cbo_machatlieu.Text != "")
                sql = sql + " AND MaChatLieu = N'" + cbo_machatlieu.SelectedValue.ToString() + "'";
            if (txt_soluongtu.Text != "")
                sql = sql + " AND SoLuong >= " + txt_soluongtu.Text;
            if (txt_soluongden.Text != "")
                sql = sql + " AND SoLuong <= " + txt_soluongden.Text;
            if (txt_dongiatu.Text != "")
                sql = sql + " AND DonGiaBan >= " + txt_dongiatu.Text;
            if (txt_dongiaden.Text != "")
                sql = sql + " AND DonGiaBan <= " + txt_dongiaden.Text;

            tblHang = Functions.GetDataToTable(sql);
            if (tblHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblHang.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv_danhsachhanghoa.DataSource = tblHang;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dgv_danhsachhanghoa.Columns[0].HeaderText = "Mã hàng";
            dgv_danhsachhanghoa.Columns[1].HeaderText = "Tên hàng";
            dgv_danhsachhanghoa.Columns[2].HeaderText = "Mã chất liệu";
            dgv_danhsachhanghoa.Columns[3].HeaderText = "Số lượng";
            dgv_danhsachhanghoa.Columns[4].HeaderText = "Đơn giá nhập";
            dgv_danhsachhanghoa.Columns[5].HeaderText = "Đơn giá bán";
            dgv_danhsachhanghoa.Columns[6].HeaderText = "Ghi chú";

            dgv_danhsachhanghoa.Columns[0].Width = 100;
            dgv_danhsachhanghoa.Columns[1].Width = 200;
            dgv_danhsachhanghoa.Columns[2].Width = 100;
            dgv_danhsachhanghoa.Columns[3].Width = 80;
            dgv_danhsachhanghoa.Columns[4].Width = 120;
            dgv_danhsachhanghoa.Columns[5].Width = 120;
            dgv_danhsachhanghoa.Columns[6].Width = 200;

            dgv_danhsachhanghoa.AllowUserToAddRows = false;
            dgv_danhsachhanghoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_timlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgv_danhsachhanghoa.DataSource = null;
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            string sql = "SELECT MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, GhiChu FROM tblHang";
            tblHang = Functions.GetDataToTable(sql);
            dgv_danhsachhanghoa.DataSource = tblHang;
            LoadDataGridView();
            MessageBox.Show("Đã hiển thị tất cả " + tblHang.Rows.Count + " hàng hóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_soluongtu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_soluongden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_dongiatu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txt_dongiaden_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar >= '0') && (e.KeyChar <= '9')) || (Convert.ToInt32(e.KeyChar) == 8))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
