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
    public partial class frmDMChatlieu : Form
    {
        DataTable tblCL;
        public frmDMChatlieu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmDMChatlieu_Load(object sender, EventArgs e)
        {
            txt_machatlieu.Enabled = false;
            btn_luu.Enabled = false;
            btn_boqua.Enabled = false;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT Machatlieu, Tenchatlieu FROM tblChatlieu";
            tblCL = Class.Functions.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgv_chatlieu.DataSource = tblCL; //Nguồn dữ liệu            
            dgv_chatlieu.Columns[0].HeaderText = "Mã chất liệu";
            dgv_chatlieu.Columns[1].HeaderText = "Tên chất liệu";
            dgv_chatlieu.Columns[0].Width = 100;
            dgv_chatlieu.Columns[1].Width = 300;
            dgv_chatlieu.AllowUserToAddRows = false; //Không cho người dùng thêm dữ liệu trực tiếp
            dgv_chatlieu.EditMode = DataGridViewEditMode.EditProgrammatically; //Không cho sửa dữ liệu trực tiếp
        }

        private void dgv_chatlieu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void ResetValue()
        {
            txt_machatlieu.Text = "";
            txt_tenchatlieu.Text = "";
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            btn_boqua.Enabled = true;
            btn_luu.Enabled = true;
            btn_them.Enabled = false;
            ResetValue();
            txt_machatlieu.Enabled = true;
            txt_machatlieu.Focus();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_machatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_machatlieu.Focus();
                return;
            }
            if (txt_tenchatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenchatlieu.Focus();
                return;
            }
            sql = "SELECT Machatlieu FROM tblChatlieu WHERE Machatlieu=N'" + txt_machatlieu.Text.Trim() + "'";
            if (Class.Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã chất liệu này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_machatlieu.Focus();
                return;
            }
            sql = "INSERT INTO tblChatlieu(Machatlieu, Tenchatlieu) VALUES(N'" +
                txt_machatlieu.Text.Trim() + "',N'" + txt_tenchatlieu.Text.Trim() + "')";
            Class.Functions.RunSQL(sql);//Thực hiện câu lệnh sql
            LoadDataGridView();//Nạp lại DataGridView
            ResetValue();
            btn_xoa.Enabled = true;
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            btn_luu.Enabled = false;
            btn_boqua.Enabled = false;
            btn_luu.Enabled = false;
            txt_machatlieu.Enabled = false;

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string sql; //Lưu câu lệnh sql
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_machatlieu.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_tenchatlieu.Text.Trim().Length == 0) //nếu chưa nhập tên chất liệu
            {
                MessageBox.Show("Bạn chưa nhập tên chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "UPDATE tblChatlieu SET Tenchatlieu=N'" +
                txt_tenchatlieu.Text.ToString() +
                "' WHERE Machatlieu=N'" + txt_machatlieu.Text + "'";
            Class.Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValue();

            btn_boqua.Enabled = false;

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_machatlieu.Text == "") //nếu chưa chọn bản ghi nào
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblChatlieu WHERE Machatlieu=N'" + txt_machatlieu.Text + "'";
                Class.Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValue();
            }

        }

        private void btn_boqua_Click(object sender, EventArgs e)
        {
            ResetValue();
            btn_boqua.Enabled = false;
            btn_them.Enabled = true;
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;
            btn_luu.Enabled = false;
            txt_machatlieu.Enabled = false;

        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_machatlieu_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void dgv_chatlieu_Click(object sender, EventArgs e)
        {
            if (btn_them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_machatlieu.Focus();
                return;
            }
            if (tblCL.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_machatlieu.Text = dgv_chatlieu.CurrentRow.Cells["Machatlieu"].Value.ToString();
            txt_tenchatlieu.Text = dgv_chatlieu.CurrentRow.Cells["Tenchatlieu"].Value.ToString();
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            btn_boqua.Enabled = true;
        }
    }
}

