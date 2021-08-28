using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QL_THUVIET_2021.Class
{
    class Function
    {
        public static SqlConnection conn;

        public static void Connect()
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-BPN90P8;Initial Catalog=QLY_ThuVien_DH;Persist Security Info=True;User ID=sa;Password=05112002@VANG";
            conn.Open();
            if (conn.State == ConnectionState.Open)
                MessageBox.Show("kết nối thành công");
            else MessageBox.Show("kết nối thất bại");
        }
        public static void Disconnect()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        public static DataTable GetDataToTable(string sql) //Lấy dữ liệu vào bảng
        {
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand();
            da.SelectCommand.Connection = Function.conn;
            da.SelectCommand.CommandText = sql;
            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }
        public static void FillCombo(string sql, ComboBox cbo, string ma, string quyen)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            da.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = ma; //trường giá trị
            cbo.DisplayMember = quyen; //trường hiển thị

        }
    }
}
