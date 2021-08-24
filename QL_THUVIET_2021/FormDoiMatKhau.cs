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
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-BPN90P8;Initial Catalog=QLY_ThuVien_DH;Persist Security Info=True;User ID=sa;Password=05112002@VANG");
        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select count(*) from TaiKhoan where TenTK=N'" + txtTenDN.Text + "' and MatKhau=N'" + txtMatKhauCu.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            errorProvider1.Clear();
            if(dt.Rows[0][0].ToString() == "1")
            {
                if(txtMaKhauMoi.Text == txtNhapLaiMK.Text)
                {
                    SqlDataAdapter da1 = new SqlDataAdapter("update TaiKhoan set MatKhau=N'"+txtMaKhauMoi.Text+"' where TenTK = N'"+txtTenDN.Text+"' and MatKhau=N'"+txtMatKhauCu.Text+"'",con);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    labelDoiMK.Text = "Đổi Mật Khẩu Thành Công";
                }    
                else
                {
                    errorProvider1.SetError(txtMaKhauMoi, "Bạn Chưa Nhập Mật Khẩu mới");
                    errorProvider1.SetError(txtNhapLaiMK, "Mật Khẩu Nhập lại không chính xác");
                }    
            }    
            else
            {
                errorProvider1.SetError(txtTenDN, "Tên đăng nhập không chính xác");
                errorProvider1.SetError(txtMatKhauCu, "Mật khẩu củ không chính xác");
            }    
        }
    }
}
