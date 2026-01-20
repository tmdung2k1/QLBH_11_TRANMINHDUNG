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
    public partial class frmTimkiemkhachhang : Form
    {
        DataTable tblKH;
        public frmTimkiemkhachhang()
        {
            InitializeComponent();
        }

        private void frmTimkiemkhachhang_Load(object sender, EventArgs e)
        {
            ResetValues();
            dgv_danhsachkhachhang.DataSource = null;
        }

        //Phương thức ResetValues
        private void ResetValues()
        {
            foreach (Control Ctl in this.Controls)
                if (Ctl is TextBox)
                    Ctl.Text = "";
            txt_makhach.Focus();
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            string sql;
            if ((txt_makhach.Text == "") && (txt_tenkhach.Text == "") &&
                (txt_diachi.Text == "") && (txt_dienthoai.Text == ""))
            {
                MessageBox.Show("Hãy nhập một điều kiện tìm kiếm!!!", "Yêu cầu ...", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            sql = "SELECT * FROM tblKhach WHERE 1=1";

            if (txt_makhach.Text != "")
                sql = sql + " AND MaKhach Like N'%" + txt_makhach.Text + "%'";
            if (txt_tenkhach.Text != "")
                sql = sql + " AND TenKhachHang Like N'%" + txt_tenkhach.Text + "%'";
            if (txt_diachi.Text != "")
                sql = sql + " AND DiaChi Like N'%" + txt_diachi.Text + "%'";
            if (txt_dienthoai.Text != "")
                sql = sql + " AND DienThoai Like '%" + txt_dienthoai.Text + "%'";

            tblKH = Functions.GetDataToTable(sql);
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có bản ghi thỏa mãn điều kiện!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Có " + tblKH.Rows.Count + " bản ghi thỏa mãn điều kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dgv_danhsachkhachhang.DataSource = tblKH;
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            dgv_danhsachkhachhang.Columns[0].HeaderText = "Mã khách";
            dgv_danhsachkhachhang.Columns[1].HeaderText = "Tên khách hàng";
            dgv_danhsachkhachhang.Columns[2].HeaderText = "Địa chỉ";
            dgv_danhsachkhachhang.Columns[3].HeaderText = "Điện thoại";

            dgv_danhsachkhachhang.Columns[0].Width = 100;
            dgv_danhsachkhachhang.Columns[1].Width = 200;
            dgv_danhsachkhachhang.Columns[2].Width = 250;
            dgv_danhsachkhachhang.Columns[3].Width = 150;

            dgv_danhsachkhachhang.AllowUserToAddRows = false;
            dgv_danhsachkhachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_timlai_Click(object sender, EventArgs e)
        {
            ResetValues();
            dgv_danhsachkhachhang.DataSource = null;
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM tblKhach";
            tblKH = Functions.GetDataToTable(sql);
            dgv_danhsachkhachhang.DataSource = tblKH;
            LoadDataGridView();
            MessageBox.Show("Đã hiển thị tất cả " + tblKH.Rows.Count + " khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
