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
    public partial class UserSach : UserControl
    {
        public UserSach()
        {
            InitializeComponent();
        }
        DataTable tbSach;
        private void UserSach_Load(object sender, EventArgs e)
        {
            Function.FillCombo("select MaTG, TenTG from TacGia ", cboMaTG, "MaTG", "MaTG");
            cboMaTG.SelectedIndex = -1;
            Function.FillCombo("select MaTL, TenTL from TheLoai ", cboMaTheLoai, "MaTL", "MaTL");
            cboMaTheLoai.SelectedIndex = -1;
            Function.FillCombo("select MaNXB, TenNXB from NhaXuatBan ", cboNhaXuatBan, "MaNXB", "MaNXB");
            cboNhaXuatBan.SelectedIndex = -1;
            LoadSach();
        }
        private void LoadSach()
        {
            string sql;
            sql = "select * from Sach";
            tbSach = Class.Function.GetDataToTable(sql);
            dgvSach.DataSource = tbSach;
            dgvSach.Columns[0].HeaderText = "Mã Sách";
            dgvSach.Columns[0].Width = 100;
            dgvSach.Columns[1].HeaderText = "Tên Sách";
            dgvSach.Columns[1].Width = 200;
            dgvSach.Columns[2].HeaderText = "Năm XB";
            dgvSach.Columns[2].Width = 100;
            dgvSach.Columns[3].HeaderText = "Số lượng";
            dgvSach.Columns[3].Width = 100;
            dgvSach.Columns[4].HeaderText = "Trạng thái";
            dgvSach.Columns[4].Width = 150;
            dgvSach.Columns[5].HeaderText = "Mã TG";
            dgvSach.Columns[5].Width = 100;
            dgvSach.Columns[6].HeaderText = "Mã TL";
            dgvSach.Columns[6].Width = 100;
            dgvSach.Columns[7].HeaderText = "Mã NXB";
            dgvSach.Columns[7].Width = 100;
            dgvSach.AllowUserToAddRows = false;
            dgvSach.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaSach.Text = "";
            txtTenSach.Text = "";
            txtSoLuong.Text = "";
            cboTrangThai.Text = "";
            cboNhaXuatBan.Text = "";
            cboMaTheLoai.Text = "";
            cboMaTG.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            ResetValues();
            string sql;
            sql = "Execute dbo.";
            txtMaSach.Text = Class.Function.GetFieldValues(sql);
            LoadSach();
        }
        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(tbSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSach.Text = dgvSach.CurrentRow.Cells["MaSach"].Value.ToString();
            txtTenSach.Text = dgvSach.CurrentRow.Cells["TenSach"].Value.ToString();
            dtpNamXuatBan.Text = dgvSach.CurrentRow.Cells["NamXB"].Value.ToString();
            txtSoLuong.Text = dgvSach.CurrentRow.Cells["SoLuong"].Value.ToString();
            cboTrangThai.Text = dgvSach.CurrentRow.Cells["TrangThai"].Value.ToString();
            cboMaTG.Text = dgvSach.CurrentRow.Cells["MaTG"].Value.ToString();
            cboMaTheLoai.Text = dgvSach.CurrentRow.Cells["MaTL"].Value.ToString();
            cboNhaXuatBan.Text = dgvSach.CurrentRow.Cells["MaNXB"].Value.ToString();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(txtMaSach.Text.Length == 0)
            {
                MessageBox.Show("Bạn Cần Nhập Mã Sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }
            string sql;
            sql = "select MaSach from Sach where MaSach=N'" + txtMaSach.Text + "'";
            if (Class.Function.KiemTraKhoaTrung(sql))
            {
                MessageBox.Show("Mã Sách này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "";
            Class.Function.RunSQL(sql);
            LoadSach();
            ResetValues();
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có mã Sach Cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSach.Text.Length == 0)
            {
                MessageBox.Show("Bạn Cần chọn mã sách cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }
            sql = "";
            Class.Function.RunSQL(sql);
            LoadSach();
            ResetValues();
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbSach.Rows.Count == 0)
            {
                MessageBox.Show("Không có mã Sach Cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSach.Text.Length == 0)
            {
                MessageBox.Show("Bạn Cần chọn mã sách cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSach.Focus();
                return;
            }
            sql = "";
            Class.Function.RunSQL(sql);
            LoadSach();
            ResetValues();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {

        }
    }
}
