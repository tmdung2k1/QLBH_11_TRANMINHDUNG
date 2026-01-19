using QLBH_11_TRANMINHDUNG.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_11_TRANMINHDUNG
{

    public partial class frmDMkhachhang : Form
    {
        DataTable tblKH;
        public frmDMkhachhang()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDMkhachhang_Load(object sender, EventArgs e)
        {
            txt_makhach.Enabled = false;
            btn_luu.Enabled = false;
            btn_boqua.Enabled = false;
            LoadDataGridView();
        }
        //Phương thức nạp dữ liệu
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblKhach";
            tblKH = Functions.GetDataToTable(sql); //Lấy dữ liệu từ bảng
            dgv_khachhang.DataSource = tblKH; //Hiển thị vào dataGridView
            dgv_khachhang.Columns[0].HeaderText = "Mã khách";
            dgv_khachhang.Columns[1].HeaderText = "Tên khách";
            dgv_khachhang.Columns[2].HeaderText = "Địa chỉ";
            dgv_khachhang.Columns[3].HeaderText = "Điện thoại";
            dgv_khachhang.Columns[0].Width = 100;
            dgv_khachhang.Columns[1].Width = 150;
            dgv_khachhang.Columns[2].Width = 150;
            dgv_khachhang.Columns[3].Width = 150;
            dgv_khachhang.AllowUserToAddRows = false;
            dgv_khachhang.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgv_khachhang_Click(object sender, EventArgs e)
        {
            if (btn_them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_makhach.Focus();
                return;
            }
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_makhach.Text = dgv_khachhang.CurrentRow.Cells["MaKhach"].Value.ToString();
            txt_tenkhach.Text = dgv_khachhang.CurrentRow.Cells["TenKhach"].Value.ToString();
            txt_diachi.Text = dgv_khachhang.CurrentRow.Cells["DiaChi"].Value.ToString();
            mtb_dienthoai.Text = dgv_khachhang.CurrentRow.Cells["DienThoai"].Value.ToString();
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            btn_boqua.Enabled = true;

        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            btn_boqua.Enabled = true;
            btn_luu.Enabled = true;
            btn_them.Enabled = false;
            ResetValues();
            txt_makhach.Enabled = true;
            txt_makhach.Focus();

        }
        //Phương thức ResetValues
        private void ResetValues()
        {
            txt_makhach.Text = "";
            txt_tenkhach.Text = "";
            txt_diachi.Text = "";
            mtb_dienthoai.Text = "";
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_makhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_makhach.Focus();
                return;
            }
            if (txt_tenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenkhach.Focus();
                return;
            }
            if (txt_diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_diachi.Focus();
                return;
            }
            if (mtb_dienthoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtb_dienthoai.Focus();
                return;
            }
            //Kiểm tra đã tồn tại mã khách chưa
            sql = "SELECT MaKhach FROM tblKhach WHERE MaKhach=N'" + txt_makhach.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã khách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_makhach.Focus();
                return;
            }
            //Chèn thêm
            sql = "INSERT INTO tblKhach VALUES (N'" + txt_makhach.Text.Trim() +
                "',N'" + txt_tenkhach.Text.Trim() + "',N'" + txt_diachi.Text.Trim() + "','" + mtb_dienthoai.Text + "')";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

            btn_xoa.Enabled = true;
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            btn_boqua.Enabled = false;
            btn_luu.Enabled = false;
            txt_makhach.Enabled = false;

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_makhach.Text == "")
            {
                MessageBox.Show("Bạn phải chọn bản ghi cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_tenkhach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên khách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenkhach.Focus();
                return;
            }
            if (txt_diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_diachi.Focus();
                return;
            }
            if (mtb_dienthoai.Text == "(  )    -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mtb_dienthoai.Focus();
                return;
            }
            sql = "UPDATE tblKhach SET TenKhach=N'" + txt_tenkhach.Text.Trim().ToString() + "',DiaChi=N'" +
                txt_diachi.Text.Trim().ToString() + "',DienThoai='" + mtb_dienthoai.Text.ToString() +
                "' WHERE MaKhach=N'" + txt_makhach.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btn_boqua.Enabled = false;

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblKH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_makhach.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblKhach WHERE MaKhach=N'" + txt_makhach.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }

        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_boqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btn_boqua.Enabled = false;
            btn_them.Enabled = true;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;
            btn_luu.Enabled = false;
            txt_makhach.Enabled = false;

        }

        private void txt_makhach_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
