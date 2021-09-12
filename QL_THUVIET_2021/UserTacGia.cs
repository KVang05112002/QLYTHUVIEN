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
    public partial class UserTacGia : UserControl
    {
        public UserTacGia()
        {
            InitializeComponent();
        }
        DataTable tbtacgia;
        private void UserTacGia_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "select * from TacGia";
            tbtacgia = Class.Function.GetDataToTable(sql);
            dtgXTacGia.DataSource = tbtacgia;
            dtgXTacGia.Columns[0].HeaderText = "Mã Tác Giả";
            dtgXTacGia.Columns[0].Width = 150;
            dtgXTacGia.Columns[1].HeaderText = "Tên Tác Giả";
            dtgXTacGia.Columns[1].Width = 250;
            dtgXTacGia.Columns[2].HeaderText = "Ghi Chú";
            dtgXTacGia.Columns[2].Width = 250;
            dtgXTacGia.AllowUserToAddRows = false;
            dtgXTacGia.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaTG.Text = "";
            txtTenTG.Text = "";
            txtGhiChu.Text = "";
        }

        private void dtgXTacGia_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }
            if (tbtacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //string sql;
            txtMaTG.Text = dtgXTacGia.CurrentRow.Cells["MaTG"].Value.ToString();
            txtTenTG.Text = dtgXTacGia.CurrentRow.Cells["TenTG"].Value.ToString();
            txtGhiChu.Text = dtgXTacGia.CurrentRow.Cells["GhiChu"].Value.ToString();
            LoadDataGridView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            string sql;
            sql = "execute dbo.sp_TacGia_SinhMaTuDong";
            txtMaTG.Text = Class.Function.GetFieldValues(sql);
            LoadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if (txtMaTG.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Cần Nhập Thông tin Mã Tác Giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTG.Focus();
                return;
            }
            if (txtTenTG.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập thông tin họ tên Tác Giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenTG.Focus();
                return;
            }
            if (txtGhiChu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGhiChu.Focus();
                return;
            }
            sql = "Select MaTG from TacGia where MaTG=N'" + txtMaTG.Text.Trim() + "'";
            if (Class.Function.KiemTraKhoaTrung(sql))
            {
                MessageBox.Show("Mã Tác Giả này đã tồn tại xin vui lòng nhập mã mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "Execute dbo.sp_insertinto_TacGia '" + txtMaTG.Text + "', N'" + txtTenTG.Text + "',N'" + txtGhiChu.Text + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbtacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTG.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã Tác Giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTG.Focus();
                return;
            }
            sql = "Update TacGia set TenTG=N'" + txtTenTG.Text.Trim() + "',GhiChu=N'"+txtGhiChu.Text.Trim()+"' where MaTG = '" + txtMaTG.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbtacgia.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaTG.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã Tác Giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaTG.Focus();
                return;
            }
            sql = "Delete TacGia where MaTG=N'" + txtMaTG.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }
    }
}
