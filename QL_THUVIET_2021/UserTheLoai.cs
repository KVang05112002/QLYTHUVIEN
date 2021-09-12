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
using QL_THUVIET_2021.Class;

namespace QL_THUVIET_2021
{
    public partial class UserTheLoai : UserControl
    {
        public UserTheLoai()
        {
            InitializeComponent();
        }
        DataTable tbnhanvien;
        private void UserTheLoai_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "Select * from TheLoai";
            tbnhanvien = Class.Function.GetDataToTable(sql);
            dtgXTheLoai.DataSource = tbnhanvien;
            dtgXTheLoai.Columns[0].HeaderText = "Mã Thể Loại";
            dtgXTheLoai.Columns[0].Width = 150;
            dtgXTheLoai.Columns[1].HeaderText = "Tên Thể Loại";
            dtgXTheLoai.Columns[1].Width = 250;
            dtgXTheLoai.AllowUserToAddRows = false;
            dtgXTheLoai.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaTL.Text = "";
            txtTenTL.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            string sql;
            sql = "execute dbo.sp_TheLoai_SinhMaTuDong";
            txtMaTL.Text = Class.Function.GetFieldValues(sql);
            LoadDataGridView();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã Thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTL.Focus();
                return;
            }
            sql = "Delete TheLoai where MaTL=N'" + txtMaTL.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã Thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTL.Focus();
                return;
            }
            sql = "Update TheLoai set TenTL=N'" + txtTenTL.Text.Trim() + "' where MaTL = '" + txtMaTL.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaTL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Cần Nhập Thông tin Mã Thể Loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTL.Focus();
                return;
            }
            if (txtTenTL.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập thông tin họ tên thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTL.Focus();
                return;
            }
            sql = "Execute sp_insertinto_TheLoai '" + txtMaTL.Text + "', N'" + txtTenTL.Text + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void dtgXTheLoai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(tbnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }
            txtMaTL.Text = dtgXTheLoai.CurrentRow.Cells["MaTL"].Value.ToString();
            txtTenTL.Text = dtgXTheLoai.CurrentRow.Cells["TenTL"].Value.ToString();
            LoadDataGridView();
        }
    }
}
