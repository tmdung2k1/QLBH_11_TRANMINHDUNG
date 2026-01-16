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
    public partial class frmDMNhanvien : Form
    {
        private DataTable tblNV;
        public frmDMNhanvien()
        {
            InitializeComponent();
        }

        private void dgv_nhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDMNhanvien_Load(object sender, EventArgs e)
        {
            txt_manhanvien.Enabled = false;
            btn_luu.Enabled = false;
            btn_boqua.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * FROM tblNhanVien";
            tblNV = Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgv_nhanvien.DataSource = tblNV;
            dgv_nhanvien.Columns[0].HeaderText = "Mã nhân viên";
            dgv_nhanvien.Columns[1].HeaderText = "Tên nhân viên";
            dgv_nhanvien.Columns[2].HeaderText = "Giới tính";
            dgv_nhanvien.Columns[3].HeaderText = "Địa chỉ";
            dgv_nhanvien.Columns[4].HeaderText = "Điện thoại";
            dgv_nhanvien.Columns[5].HeaderText = "Ngày sinh";
            dgv_nhanvien.Columns[0].Width = 100;
            dgv_nhanvien.Columns[1].Width = 150;
            dgv_nhanvien.Columns[2].Width = 100;
            dgv_nhanvien.Columns[3].Width = 150;
            dgv_nhanvien.Columns[4].Width = 100;
            dgv_nhanvien.Columns[5].Width = 100;
            dgv_nhanvien.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_nhanvien.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }
     
        private void ResetValues()
        {
            txt_manhanvien.Text = "";
            txt_tennhanvien.Text = "";
            chk_gioitinh.Checked = false;
            txt_diachi.Text = "";
            dtpNgaysinh.Value = DateTime.Now;
            mtb_dienthoai.Text = "";
        }

       
        //Chuyển dữ liệu lên textbox khi nhấn Enter
        private void txtManhanvien_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            btn_boqua.Enabled = true;
            btn_luu.Enabled = true;
            btn_them.Enabled = false;
            ResetValues();
            txt_manhanvien.Enabled = true;
            mtb_dienthoai.Enabled = true;
            txt_manhanvien.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {         
            string sql, gt;
            if (txt_manhanvien.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_manhanvien.Focus();
                return;
            }
            if (txt_tennhanvien.Text.Trim().Length == 0) // Sửa lại biến kiểm tra tên cho đúng (trong code gốc bạn check mã 2 lần)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tennhanvien.Focus();
                return;
            }
            if (txt_diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_diachi.Focus();
                return;
            }
            if (mtb_dienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtb_dienthoai.Focus();
                return;
            }

            if (chk_gioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";

            sql = "SELECT MaNhanVien FROM tblNhanVien WHERE MaNhanVien=N'" + txt_manhanvien.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_manhanvien.Focus();
                txt_manhanvien.Text = "";
                return;
            }

            
            sql = "INSERT INTO tblNhanVien(MaNhanVien,TenNhanVien,GioiTinh, DiaChi,DienThoai, NgaySinh) VALUES (N'" +
                txt_manhanvien.Text.Trim() + "',N'" +
                txt_tennhanvien.Text.Trim() + "',N'" +
                gt + "',N'" +
                txt_diachi.Text.Trim() + "','" +
                mtb_dienthoai.Text + "','" +
                dtpNgaysinh.Value.ToString("yyyy-MM-dd") + "')"; // Chuyển sang yyyy-MM-dd

            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btn_xoa.Enabled = true;
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            btn_boqua.Enabled = false;
            btn_luu.Enabled = false;
            txt_manhanvien.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {      
            string sql, gt;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_manhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_tennhanvien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tennhanvien.Focus();
                return;
            }
            if (txt_diachi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_diachi.Focus();
                return;
            }
            if (mtb_dienthoai.Text == "(   )     -")
            {
                MessageBox.Show("Bạn phải nhập điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtb_dienthoai.Focus();
                return;
            }

            if (chk_gioitinh.Checked == true)
                gt = "Nam";
            else
                gt = "Nữ";
            sql = "UPDATE tblNhanVien SET  TenNhanVien=N'" + txt_tennhanvien.Text.Trim().ToString() +
                    "',DiaChi=N'" + txt_diachi.Text.Trim().ToString() +
                    "',DienThoai='" + mtb_dienthoai.Text.ToString() +
                    "',GioiTinh=N'" + gt +
                    "',NgaySinh='" + dtpNgaysinh.Value.ToString("yyyy-MM-dd") +
                    "' WHERE MaNhanVien=N'" + txt_manhanvien.Text + "'";

            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btn_boqua.Enabled = false;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_manhanvien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                sql = "DELETE tblNhanVien WHERE MaNhanVien=N'" + txt_manhanvien.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }
        }

        private void btn_boqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btn_boqua.Enabled = false;
            btn_them.Enabled = true;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;
            btn_luu.Enabled = false;
            txt_manhanvien.Enabled = false;
        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_nhanvien_Click(object sender, EventArgs e)
        {
            if (btn_them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_manhanvien.Focus();
                return;
            }
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_manhanvien.Text = dgv_nhanvien.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            txt_tennhanvien.Text = dgv_nhanvien.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            if (dgv_nhanvien.CurrentRow.Cells["GioiTinh"].Value.ToString() == "Nam") chk_gioitinh.Checked = true;
            else chk_gioitinh.Checked = false;
            txt_diachi.Text = dgv_nhanvien.CurrentRow.Cells["DiaChi"].Value.ToString();
            mtb_dienthoai.Text = dgv_nhanvien.CurrentRow.Cells["DienThoai"].Value.ToString();
            dtpNgaysinh.Value = (DateTime)dgv_nhanvien.CurrentRow.Cells["NgaySinh"].Value;
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            // btnXoa.Enabled = true;
        }

        private void txt_manhanvien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_manhanvien_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
