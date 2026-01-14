using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QLBH_11_TRANMINHDUNG.Class
{
    internal class Functions
    {
        public static SqlConnection con;
        public static void Connect()
        {

            con= new SqlConnection(); // Khai báo đối tượng kết nối
            // Chuỗi kết nối
            // Data Source = LAPTOP - 8GA3B18K\SQLEXPRESS; Initial Catalog = QLBHLN_11_TRANMINHDUNG; User ID = sa; Trust Server Certificate = True
            con.ConnectionString = @"Data Source=LAPTOP-8GA3B18K\SQLEXPRESS;Initial Catalog=QLBH_11_TRANMINHDUNG;Integrated Security=True";
           
            con.Open(); // Mở kết nối
            //kiem tra ket noi
            if(con.State == ConnectionState.Open)
            {
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kết nối thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static void Disconnect()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close(); // Đóng kết nối
                con.Dispose(); // Giải phóng tài nguyên
                con = null;
            }
        }
    }
}
