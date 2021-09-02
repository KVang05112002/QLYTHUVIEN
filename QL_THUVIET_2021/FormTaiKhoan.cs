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
            txtIDTaiKhoan.ReadOnly = true;
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
        private void ResetValue()
        {
            txtIDTaiKhoan.Text = "";
            TxtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
            cboQuyen.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            ResetValue();
            string sql;
            sql = "Execute dbo.sp_TaiKhoan_SinhMaTuDong";
            txtIDTaiKhoan.Text = Function.GetFieldValues(sql);
            txtIDTaiKhoan.Focus();
            LoadDataGridview();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtIDTaiKhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập ID tài khoản người dùng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDTaiKhoan.Focus();
                return;
            }    
            if(TxtTenDangNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập tên đăng nhập người dùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtTenDangNhap.Focus();
                return;
            }    
            if(txtMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mật khẩu cho người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMatKhau.Focus();
                return;
            }    
            if(cboQuyen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa phân quyền cho người dùng", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboQuyen.Focus();
                return;
            }
            sql = "Select ID from TaiKhoan where ID=N'" + txtIDTaiKhoan.Text.Trim() + "'";
            if(Class.Function.KiemTraKhoaTrung(sql) )
            {
                MessageBox.Show("ID Tài khoản này đã có!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIDTaiKhoan.Focus();
                return;
            }
            sql = "Insert into TaiKhoan Values ('" + txtIDTaiKhoan.Text.Trim() + "','" + TxtTenDangNhap.Text.Trim() + "','" + txtMatKhau.Text.Trim() + "','" + cboQuyen.Text.Trim() + "')";
            Class.Function.RunSQL(sql);
            LoadDataGridview();
            ResetValue();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if(tbTaiKhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtIDTaiKhoan.Text == "")
            {
                MessageBox.Show("Bạn Phải chon ID tài khoản", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(MessageBox.Show("Bạn có muốn xóa bảng ghi này không?", "Thong Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Delete TaiKhoan where ID =N'" + txtIDTaiKhoan.Text + "'";
                Class.Function.RunSQL(sql);
                LoadDataGridview();
                ResetValue();
            }    
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if(tbTaiKhoan.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtIDTaiKhoan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập ID tài khoản người dùng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIDTaiKhoan.Focus();
                return;
            }
            sql = "Update TaiKhoan set ID=N'" + txtIDTaiKhoan.Text.ToString() + "', TenTK=N'" + TxtTenDangNhap.Text.ToString() + "', MatKhau=N'" + txtMatKhau.Text.ToString() + "', Quyen=N'" + cboQuyen.Text.ToString() + "' where ID=N'" + txtIDTaiKhoan.Text + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridview();
            ResetValue();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }

        private void txtIDTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
