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
using Microsoft.Reporting.WinForms;
using Word = Microsoft.Office.Interop.Word;

namespace QLBH_11_TRANMINHDUNG
{
    public partial class frmBaoCao : Form
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }

        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            dtpNgaySX.Value = DateTime.Now;
            // Thiết lập ReportViewer
            this.rpvBaoCao.RefreshReport();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ database theo điều kiện ngày sản xuất
                string sql = "SELECT MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, GhiChu FROM tblHang";

                // Nếu có điều kiện lọc theo ngày (giả sử có trường NgaySX trong database)
                // sql += " WHERE NgaySX >= '" + dtpNgaySX.Value.ToString("yyyy-MM-dd") + "'";

                DataTable dt = Functions.GetDataToTable(sql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Xóa các data source cũ
                rpvBaoCao.LocalReport.DataSources.Clear();

                // Đường dẫn đến file report
                rpvBaoCao.LocalReport.ReportPath = Application.StartupPath + "\\rptSanPham.rdlc";

                // Tạo ReportDataSource
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1"; // Tên DataSet trong file .rdlc
                rds.Value = dt;

                // Thêm data source vào report
                rpvBaoCao.LocalReport.DataSources.Add(rds);

                // Refresh report để hiển thị
                rpvBaoCao.RefreshReport();

                MessageBox.Show("Đã tạo báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rpvBaoCao_Load(object sender, EventArgs e)
        {

        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ database
                string sql = "SELECT MaHang, TenHang, MaChatLieu, SoLuong, DonGiaNhap, DonGiaBan, GhiChu FROM tblHang";
                DataTable dt = Functions.GetDataToTable(sql);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất báo cáo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Tạo SaveFileDialog để chọn nơi lưu file
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Word Documents (*.docx)|*.docx";
                saveDialog.FileName = "BaoCaoSanPham_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".docx";
                saveDialog.Title = "Lưu báo cáo Word";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tạo Word Application
                    Word.Application wordApp = new Word.Application();
                    Word.Document wordDoc = wordApp.Documents.Add();
                    wordApp.Visible = false;

                    // Thêm tiêu đề
                    Word.Paragraph para1 = wordDoc.Paragraphs.Add();
                    para1.Range.Text = "BÁO CÁO DANH SÁCH SẢN PHẨM";
                    para1.Range.Font.Size = 16;
                    para1.Range.Font.Bold = 1;
                    para1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    para1.Range.InsertParagraphAfter();

                    // Thêm ngày báo cáo
                    Word.Paragraph para2 = wordDoc.Paragraphs.Add();
                    para2.Range.Text = "Ngày xuất: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                    para2.Range.Font.Size = 11;
                    para2.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    para2.Range.InsertParagraphAfter();
                    para2.Range.InsertParagraphAfter();

                    // Tạo bảng
                    int rows = dt.Rows.Count + 1; // +1 cho header
                    int cols = 6; // Mã hàng, Tên hàng, Chất liệu, SL, Giá nhập, Giá bán
                    Word.Table table = wordDoc.Tables.Add(para2.Range, rows, cols);
                    table.Borders.Enable = 1;

                    // Header
                    table.Cell(1, 1).Range.Text = "Mã hàng";
                    table.Cell(1, 2).Range.Text = "Tên hàng";
                    table.Cell(1, 3).Range.Text = "Chất liệu";
                    table.Cell(1, 4).Range.Text = "Số lượng";
                    table.Cell(1, 5).Range.Text = "Giá nhập";
                    table.Cell(1, 6).Range.Text = "Giá bán";

                    // Format header
                    for (int col = 1; col <= cols; col++)
                    {
                        table.Cell(1, col).Range.Font.Bold = 1;
                        table.Cell(1, col).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                        table.Cell(1, col).Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                    }

                    // Dữ liệu
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        table.Cell(i + 2, 1).Range.Text = dt.Rows[i]["MaHang"].ToString();
                        table.Cell(i + 2, 2).Range.Text = dt.Rows[i]["TenHang"].ToString();
                        table.Cell(i + 2, 3).Range.Text = dt.Rows[i]["MaChatLieu"].ToString();
                        table.Cell(i + 2, 4).Range.Text = dt.Rows[i]["SoLuong"].ToString();
                        table.Cell(i + 2, 5).Range.Text = string.Format("{0:#,##0}", dt.Rows[i]["DonGiaNhap"]);
                        table.Cell(i + 2, 6).Range.Text = string.Format("{0:#,##0}", dt.Rows[i]["DonGiaBan"]);

                        // Căn phải cho cột số
                        table.Cell(i + 2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                        table.Cell(i + 2, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                        table.Cell(i + 2, 6).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                    }

                    // Lưu file
                    wordDoc.SaveAs2(saveDialog.FileName);
                    wordDoc.Close();
                    wordApp.Quit();

                    // Giải phóng COM objects
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(table);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDoc);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);

                    MessageBox.Show("Đã xuất báo cáo ra Word thành công!\nFile: " + saveDialog.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Mở file Word
                    if (MessageBox.Show("Bạn có muốn mở file vừa tạo không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
