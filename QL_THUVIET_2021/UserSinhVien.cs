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
    public partial class UserSinhVien : UserControl
    {
        public UserSinhVien()
        {
            InitializeComponent();
        }
        DataTable tbnhanvien;
        private void UserSinhVien_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "Select * from SinhVien";
            tbnhanvien = Class.Function.GetDataToTable(sql);
            dgvXSinhVien.DataSource = tbnhanvien;
            dgvXSinhVien.Columns[0].HeaderText = "Mã Sinh Viên";
            dgvXSinhVien.Columns[0].Width = 150;
            dgvXSinhVien.Columns[1].HeaderText = "Họ Tên Sinh Viên";
            dgvXSinhVien.Columns[1].Width = 250;
            dgvXSinhVien.Columns[2].HeaderText = "Giới Tính";
            dgvXSinhVien.Columns[2].Width = 150;
            dgvXSinhVien.Columns[3].HeaderText = "Ngày Sinh";
            dgvXSinhVien.Columns[3].Width = 150;
            dgvXSinhVien.Columns[4].HeaderText = "Địa Chỉ";
            dgvXSinhVien.Columns[4].Width = 250;
            dgvXSinhVien.Columns[5].HeaderText = "Số Điện Thoại";
            dgvXSinhVien.Columns[5].Width = 200;
            dgvXSinhVien.AllowUserToAddRows = false;
            dgvXSinhVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaSV.Text = "";
            txtHoTen.Text = "";
            cboGioiTinh.Text = "";
            txtDiaChi.Text = "";
            txtSoDT.Text = "";
        }

        private void dgvXSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }    
            if(tbnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //string sql;
            txtMaSV.Text = dgvXSinhVien.CurrentRow.Cells["MaSV"].Value.ToString();
            txtHoTen.Text = dgvXSinhVien.CurrentRow.Cells["HoTenSV"].Value.ToString();
            cboGioiTinh.Text = dgvXSinhVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            dtpNgaySinh.Text = dgvXSinhVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtDiaChi.Text = dgvXSinhVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtSoDT.Text = dgvXSinhVien.CurrentRow.Cells["SoDT"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            string sql;
            sql = "execute sp_SinhVien_SinhMaTuDong";
            txtMaSV.Text = Class.Function.GetFieldValues(sql);
            LoadDataGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtMaSV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Cần Nhập Thông tin Mã Nhân Viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return;
            }
            if (txtHoTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập thông tin họ tên sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtHoTen.Focus();
                return;
            }
            if (cboGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập thông tin giới tính sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboGioiTinh.Focus();
                return;
            }
            if (dtpNgaySinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập thông tin ngày sinh sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgaySinh.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn cần nhập thông tin địa chỉ của sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtSoDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số điện thoại của sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDT.Focus();
                return;
            }
            sql = "Select MaSV from SinhVien where MaSV=N'" + txtMaSV.Text.Trim() + "'";
            if(Class.Function.KiemTraKhoaTrung(sql))
            {
                MessageBox.Show("Mã Sinh Viên này đã tồn tại xin vui lòng nhập mã mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "Execute sp_Insert_SinhVien '"+txtMaSV.Text+"', N'"+txtHoTen.Text+"',N'"+cboGioiTinh.Text+"','"+Function.Ngaythangnam(dtpNgaySinh.Text)+"',N'"+txtDiaChi.Text+"','"+txtSoDT.Text+"'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if(tbnhanvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtMaSV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã Sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return;
            }    
            sql = "Delete SinhVien where MaSV=N'"+txtMaSV.Text.Trim()+"'";
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
            if (txtMaSV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã Sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSV.Focus();
                return;
            }
            sql = "Update SinhVien set HoTenSV=N'" + txtHoTen.Text.Trim() + "',GioiTinh=N'" + cboGioiTinh.Text.Trim() + "',NgaySinh='" + Function.Ngaythangnam(dtpNgaySinh.Text) +"',DiaChi=N'" + txtDiaChi.Text.Trim() + "',SoDT='" + txtSoDT.Text.Trim() + "' where MaSV = N'"+txtMaSV.Text.Trim()+"'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }
    }
}
