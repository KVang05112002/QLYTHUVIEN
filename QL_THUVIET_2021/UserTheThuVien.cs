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
    public partial class UserTheThuVien : UserControl
    {
        public UserTheThuVien()
        {
            InitializeComponent();
        }
        DataTable tbThethuvien;
        private void UserTheThuVien_Load(object sender, EventArgs e)
        {
            Function.FillCombo("Select MaNV, HoTen from NhanVien", cboMaNV,"MaNV","MaNV");
            Function.FillCombo("Select MaSV, HoTenSV from SinhVien", cboMaSV, "MaSV", "MaSV");
            LoadDataGridview();
        }

        private void LoadDataGridview()
        {
            string sql;
            sql = "Select*from TheThuVien";
            tbThethuvien = Class.Function.GetDataToTable(sql);
            dgvTheThuVien.DataSource = tbThethuvien;
            dgvTheThuVien.Columns[0].HeaderText = "Số Thẻ Thư Viện";
            dgvTheThuVien.Columns[0].Width = 180;
            dgvTheThuVien.Columns[1].HeaderText = "Mã Nhân Viên";
            dgvTheThuVien.Columns[1].Width = 150;
            dgvTheThuVien.Columns[2].HeaderText = "Ngày Bắt Đầu";
            dgvTheThuVien.Columns[2].Width = 150;
            dgvTheThuVien.Columns[3].HeaderText = "Ngày Hết Hạn";
            dgvTheThuVien.Columns[3].Width = 150;
            dgvTheThuVien.Columns[4].HeaderText = "Ghi Chú";
            dgvTheThuVien.Columns[4].Width = 200;
            dgvTheThuVien.Columns[5].HeaderText = "Mã Sinh Viên";
            dgvTheThuVien.Columns[5].Width = 150;
            dgvTheThuVien.AllowUserToAddRows = false;
            dgvTheThuVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void ResetValues()
        {
            txtSoThe.Text = "";
            cboMaNV.Text = "";
            cboMaSV.Text = "";
            txtGhiChu.Text = "";

        }

        private void dgvTheThuVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở Chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }    
            if(tbThethuvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtSoThe.Text = dgvTheThuVien.CurrentRow.Cells["SoThe"].Value.ToString();
            cboMaNV.Text = dgvTheThuVien.CurrentRow.Cells["MaNV"].Value.ToString();
            dtpNgayBD.Text = dgvTheThuVien.CurrentRow.Cells["NgayBatDau"].Value.ToString();
            dtpNgayKT.Text = dgvTheThuVien.CurrentRow.Cells["NgayHetHan"].Value.ToString();
            txtGhiChu.Text = dgvTheThuVien.CurrentRow.Cells["GhiChu"].Value.ToString();
            cboMaSV.Text = dgvTheThuVien.CurrentRow.Cells["MaSV"].Value.ToString();
        }
    }
}
