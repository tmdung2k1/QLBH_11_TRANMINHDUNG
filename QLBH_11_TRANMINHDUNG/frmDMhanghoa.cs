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
    public partial class frmDMhanghoa : Form
    {
        DataTable tblH;
        public frmDMhanghoa()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDMhanghoa_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * from tblChatLieu";
            txt_mahang.Enabled = false;
            btn_luu.Enabled = false;
            btn_hienthi.Enabled = false;
            LoadDataGridView();
            Functions.FillCombo(sql, cbo_machatlieu, "MaChatLieu", "TenChatLieu");
            cbo_machatlieu.SelectedIndex = -1;
            ResetValues();

        }
        // Phương thức ResetValues
        private void ResetValues()
        {
            txt_mahang.Text = "";
            txt_tenhang.Text = "";
            cbo_machatlieu.Text = "";
            txt_soluong.Text = "0";
            txt_dongianhap.Text = "0";
            txt_dongiaban.Text = "0";
            txt_soluong.Enabled = true;
            txt_dongianhap.Enabled = false;
            txt_dongiaban.Enabled = false;
            txt_anh.Text = "";
            pic_anh.Image = null;
            txt_ghichu.Text = "";
        }

        private void dvg_hanghoa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT * from tblHang";
            tblH = Functions.GetDataToTable(sql);
            dvg_hanghoa.DataSource = tblH;
            dvg_hanghoa.Columns[0].HeaderText = "Mã hàng";
            dvg_hanghoa.Columns[1].HeaderText = "Tên hàng";
            dvg_hanghoa.Columns[2].HeaderText = "Chất liệu";
            dvg_hanghoa.Columns[3].HeaderText = "Số lượng";
            dvg_hanghoa.Columns[4].HeaderText = "Đơn giá nhập";
            dvg_hanghoa.Columns[5].HeaderText = "Đơn giá bán";
            dvg_hanghoa.Columns[6].HeaderText = "Ảnh";
            dvg_hanghoa.Columns[7].HeaderText = "Ghi chú";
            dvg_hanghoa.Columns[0].Width = 80;
            dvg_hanghoa.Columns[1].Width = 140;
            dvg_hanghoa.Columns[2].Width = 80;
            dvg_hanghoa.Columns[3].Width = 80;
            dvg_hanghoa.Columns[4].Width = 100;
            dvg_hanghoa.Columns[5].Width = 100;
            dvg_hanghoa.Columns[6].Width = 200;
            dvg_hanghoa.Columns[7].Width = 300;
            dvg_hanghoa.AllowUserToAddRows = false;
            dvg_hanghoa.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            btn_hienthi.Enabled = true;
            btn_luu.Enabled = true;
            btn_them.Enabled = false;
            ResetValues();
            txt_mahang.Enabled = true;
            txt_mahang.Focus();
            txt_soluong.Enabled = true;
            txt_dongianhap.Enabled = true;
            txt_dongiaban.Enabled = true;

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txt_mahang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mahang.Focus();
                return;
            }
            if (txt_tenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenhang.Focus();
                return;
            }
            if (cbo_machatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_machatlieu.Focus();
                return;
            }
            if (txt_anh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_mo.Focus();
                return;
            }
            sql = "SELECT MaHang FROM tblHang WHERE MaHang=N'" + txt_mahang.Text.Trim() + "'";
            if (Functions.CheckKey(sql))
            {
                MessageBox.Show("Mã hàng này đã tồn tại, bạn phải chọn mã hàng khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mahang.Focus();
                return;
            }
            sql = "INSERT INTO tblHang(MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap, DonGiaBan,Anh,GhiChu) VALUES(N'"
                + txt_mahang.Text.Trim() + "',N'" + txt_tenhang.Text.Trim() +
                "',N'" + cbo_machatlieu.SelectedValue.ToString() +
                "'," + txt_soluong.Text.Trim() + "," + txt_dongianhap.Text +
                "," + txt_dongiaban.Text + ",'" + txt_anh.Text + "',N'" + txt_ghichu.Text.Trim() + "')";

            Functions.RunSQL(sql);
            LoadDataGridView();
            //ResetValues();
            btn_xoa.Enabled = true;
            btn_them.Enabled = true;
            btn_sua.Enabled = true;
            btn_hienthi.Enabled = false;
            btn_luu.Enabled = false;
            txt_mahang.Enabled = false;

        }

        private void dvg_hanghoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string MaChatLieu;
            string sql;
            if (btn_them.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mahang.Focus();
                return;
            }
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txt_mahang.Text = dvg_hanghoa.CurrentRow.Cells["MaHang"].Value.ToString();
            txt_tenhang.Text = dvg_hanghoa.CurrentRow.Cells["TenHang"].Value.ToString();
            MaChatLieu = dvg_hanghoa.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            sql = "SELECT TenChatLieu FROM tblChatLieu WHERE MaChatLieu=N'" + MaChatLieu + "'";
            cbo_machatlieu.Text = Functions.GetFieldValues(sql);
            txt_soluong.Text = dvg_hanghoa.CurrentRow.Cells["SoLuong"].Value.ToString();
            txt_dongianhap.Text = dvg_hanghoa.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            txt_dongiaban.Text = dvg_hanghoa.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            sql = "SELECT Anh FROM tblHang WHERE MaHang=N'" + txt_mahang.Text + "'";
            txt_anh.Text = Functions.GetFieldValues(sql);
            try
            {
                // Giải phóng ảnh cũ nếu có
                if (pic_anh.Image != null)
                {
                    pic_anh.Image.Dispose();
                    pic_anh.Image = null;
                }

                // Tạo bản sao độc lập của ảnh
                using (var originalImage = Image.FromFile(txt_anh.Text))
                {
                    var bitmap = new Bitmap(originalImage);
                    pic_anh.Image = bitmap;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sql = "SELECT Ghichu FROM tblHang WHERE MaHang = N'" + txt_mahang.Text + "'";
            txt_ghichu.Text = Functions.GetFieldValues(sql);
            btn_sua.Enabled = true;
            btn_xoa.Enabled = true;
            btn_hienthi.Enabled = true;

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_mahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_mahang.Focus();
                return;
            }
            if (txt_tenhang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_tenhang.Focus();
                return;
            }
            if (cbo_machatlieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbo_machatlieu.Focus();
                return;
            }
            if (txt_anh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải ảnh minh hoạ cho hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_anh.Focus();
                return;
            }
            sql = "UPDATE tblHang SET TenHang=N'" + txt_tenhang.Text.Trim().ToString() +
                "',MaChatLieu=N'" + cbo_machatlieu.SelectedValue.ToString() +
                "',SoLuong=" + txt_soluong.Text +
                ",Anh='" + txt_anh.Text + "',Ghichu=N'" + txt_ghichu.Text + "' WHERE MaHang=N'" + txt_mahang.Text + "'";
            Functions.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btn_hienthi.Enabled = false;

        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblH.Rows.Count == 0)
            {
                MessageBox.Show("Không còn dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txt_mahang.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn bản ghi nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xoá bản ghi này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "DELETE tblHang WHERE MaHang=N'" + txt_mahang.Text + "'";
                Functions.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }

        }

        private void btn_mo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                pic_anh.Image = Image.FromFile(dlgOpen.FileName);
                txt_anh.Text = dlgOpen.FileName;
            }

        }

        private void btn_dong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_boqua_Click(object sender, EventArgs e)
        {
            ResetValues();
            btn_xoa.Enabled = true;
            btn_sua.Enabled = true;
            btn_them.Enabled = true;
            btn_hienthi.Enabled = false;
            btn_luu.Enabled = false;
            txt_mahang.Enabled = false;
        }

        private void btn_hienthi_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,DonGiaBan,Anh,Ghichu FROM tblHang";
            tblH = Functions.GetDataToTable(sql);
            dvg_hanghoa.DataSource = tblH;
        }

    }
}

