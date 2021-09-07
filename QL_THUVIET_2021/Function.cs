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
        public static string GetFieldValues(string sql)
        {
            string ma = "";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader;
            reader = cmd.ExecuteReader();
            while (reader.Read())
                ma = reader.GetValue(0).ToString();
            reader.Close();
            return ma;
        }
        public static bool KiemTraKhoaTrung(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static void RunSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            cmd.Dispose();
            cmd = null;
        }
        public static string Ngaythangnam(string date)
        {
            string[] elements = date.Split('/');
            string dt = string.Format("{0}/{1}/{2}", elements[0], elements[1], elements[2]);
            return dt;

        }
        public static bool IsDate(string date)
        {
            string[] elements = date.Split('/');
            if ((Convert.ToInt32(elements[0]) >= 1) && (Convert.ToInt32(elements[0]) <= 31) && (Convert.ToInt32(elements[1]) >= 1) && (Convert.ToInt32(elements[1]) <= 12) && (Convert.ToInt32(elements[2]) >= 1900))
                return true;
            else return false;
        }
    }
}
