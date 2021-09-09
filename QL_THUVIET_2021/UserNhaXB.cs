using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QL_THUVIET_2021
{
    public partial class UserNhaXB : UserControl
    {
        public UserNhaXB()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-BPN90P8;Initial Catalog=QLY_ThuVien_DH;Persist Security Info=True;User ID=sa;Password=05112002@VANG");
        private void UserNhaXB_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
            LayDSNXB();
        }
        private void ketnoicsdl()
        {
            cnn.Open();
            string sql = "select * from NhaXuatBan";  // lay het du lieu trong bang 
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dtgXNXB.DataSource = dt; //đổ dữ liệu vào datagridview
        }
        private void LayDSNXB()
        {
            SqlConnection con = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            try
            {
                con.Open();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "[dbo].[SP_LayDSNXB]";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Connection = con;
                da.Fill(dt);
                dtgXNXB.DataSource = dt;
                con.Close();
                dtgXNXB.Columns[0].Width = 35;
                dtgXNXB.Columns[0].HeaderText = "Mã NXB";
                dtgXNXB.Columns[1].Width = 130;
                dtgXNXB.Columns[1].HeaderText = "Tên NXB";
                dtgXNXB.Columns[2].Width = 80;
                dtgXNXB.Columns[2].HeaderText = "Địa Chỉ";
                dtgXNXB.Columns[3].Width = 80;
                dtgXNXB.Columns[3].HeaderText = "Email";
                dtgXNXB.Columns[4].Width = 135;
                dtgXNXB.Columns[4].HeaderText = "Thông tin người đại diện";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private bool KiemTraThongTinNXB()
        {
            if (txtMaNXB.Text == "")
            {
                MessageBox.Show("Vui lòng điền mã Nhà xuất bản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNXB.Focus();
                return false;
            }
            if (txtTenNXB.Text == "")
            {
                MessageBox.Show("Vui lòng điền tên nxb.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNXB.Focus();
                return false;
            }
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Vui lòng điền Email của NXB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng điền địa chỉ của NXB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return false;
            }
            if (txtDaiDien.Text == "")
            {
                MessageBox.Show("Vui lòng điền thông tin người đại diện của NXB.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDaiDien.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTraThongTinNXB())
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    //conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "[dbo].[SP_ThemNXB]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaNXB", SqlDbType.NVarChar).Value = txtMaNXB.Text;
                    cmd.Parameters.Add("@TenNXB", SqlDbType.NVarChar).Value = txtTenNXB.Text;
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@TTNDaiDien", SqlDbType.NVarChar).Value = txtDaiDien.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LayDSNXB();
                    MessageBox.Show("Thêm mới Nhà Xuất Bản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaNXB.Text == "" || txtMaNXB.Text == "Thêm mới không cần ID")
            {
                MessageBox.Show("Vui lòng điền ID nxb cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNXB.Focus();
                txtMaNXB.SelectAll();
            }
            else if (KiemTraThongTinNXB())
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    // conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "[dbo].[SP_SuaNXB]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaXNB", SqlDbType.VarChar).Value = txtMaNXB.Text;
                    cmd.Parameters.Add("@TenNXB", SqlDbType.NVarChar).Value = txtTenNXB.Text;
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtDiaChi.Text;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@TTNDaiDien", SqlDbType.NVarChar).Value = txtDaiDien.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LayDSNXB();
                    MessageBox.Show("Sửa Nhà Xuất Bản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaNXB.Text == "Thêm mới không cần ID" || txtMaNXB.Text == "")
            {
                MessageBox.Show("Vui lòng điền ID nxb cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNXB.Focus();
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    //conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "[dbo].[SP_XoaNXB]";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaNXB", SqlDbType.Int).Value = Convert.ToInt32(txtMaNXB.Text);
                    cmd.Parameters.Add("@TenNXB", SqlDbType.NVarChar).Value = Convert.ToInt32(txtTenNXB.Text);
                    cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = Convert.ToInt32(txtDiaChi.Text);
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Convert.ToInt32(txtEmail.Text);
                    cmd.Parameters.Add("@TTNDaiDien", SqlDbType.NVarChar).Value = txtDaiDien.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LayDSNXB();
                    MessageBox.Show("Xóa Nhà Xuất Bản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
