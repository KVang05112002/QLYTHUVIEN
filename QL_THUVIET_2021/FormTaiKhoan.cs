using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using QL_THUVIET_2021.Class;

namespace QL_THUVIET_2021
{
    public partial class FormTaiKhoan : UserControl
    {
        public FormTaiKhoan()
        {
            InitializeComponent();
        }
        DataTable tbTaiKhoan;
        private void FormTaiKhoan_Load(object sender, EventArgs e)
        {
            txtIDTaiKhoan.Enabled = true;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            Function.FillCombo("SELECT ID, Quyen FROM TaiKhoan", cboQuyen, "Quyen", "Quyen");
            cboQuyen.SelectedIndex = -1;
            LoadDataGridview();
        }
        private void LoadDataGridview()
        {
            string sql;
            sql = "SELECT ID, TenTK, MatKhau, Quyen FROM TaiKhoan";
            tbTaiKhoan = Class.Function.GetDataToTable(sql);
            dtgTaiKhoan.DataSource = tbTaiKhoan;
            dtgTaiKhoan.Columns[0].HeaderText = "ID Tài Khoản";
            dtgTaiKhoan.Columns[1].HeaderText = "Tên Đăng Nhập";
            dtgTaiKhoan.Columns[2].HeaderText = "Mật Khẩu";
            dtgTaiKhoan.Columns[3].HeaderText = "Quyền";
            dtgTaiKhoan.Columns[0].Width = 200;
            dtgTaiKhoan.Columns[1].Width = 150;
            dtgTaiKhoan.Columns[2].Width = 100;
            dtgTaiKhoan.Columns[3].Width = 100;
            dtgTaiKhoan.AllowUserToAddRows = false;
            dtgTaiKhoan.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dtgTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ Thêm Mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDTaiKhoan.Focus();
                return;
            }    
            if(tbTaiKhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtIDTaiKhoan.Text = dtgTaiKhoan.CurrentRow.Cells["ID"].Value.ToString();
            TxtTenDangNhap.Text = dtgTaiKhoan.CurrentRow.Cells["TenTK"].Value.ToString();
            txtMatKhau.Text = dtgTaiKhoan.CurrentRow.Cells["MatKhau"].Value.ToString();
            cboQuyen.Text = dtgTaiKhoan.CurrentRow.Cells["Quyen"].Value.ToString();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
    }
}
