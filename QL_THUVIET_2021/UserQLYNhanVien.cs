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
    public partial class UserQLYNhanVien : UserControl
    {
        public UserQLYNhanVien()
        {
            InitializeComponent();
        }
        DataTable tbNhanVien;
        private void UserQLYNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "Select * from NhanVien";
            tbNhanVien = Class.Function.GetDataToTable(sql);
            dgvXNhanVien.DataSource = tbNhanVien;
            dgvXNhanVien.Columns[0].HeaderText = "Mã Nhân Viên";
            dgvXNhanVien.Columns[1].HeaderText = "Tên Nhân Viên";
            dgvXNhanVien.Columns[2].HeaderText = "Giới Tính";
            dgvXNhanVien.Columns[3].HeaderText = "Địa Chỉ";
            dgvXNhanVien.Columns[4].HeaderText = "Ngày Sinh";
            dgvXNhanVien.Columns[5].HeaderText = "Số Điện Thoại";
            dgvXNhanVien.Columns[0].Width = 150;
            dgvXNhanVien.Columns[1].Width = 250;
            dgvXNhanVien.Columns[2].Width = 150;
            dgvXNhanVien.Columns[3].Width = 250;
            dgvXNhanVien.Columns[4].Width = 200;
            dgvXNhanVien.Columns[5].Width = 150;
            dgvXNhanVien.AllowUserToAddRows = false;
            dgvXNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            cboGioiTinh.Text = "";
            dtpNgaySinh.Text = "";
            txtDiaChi.Text = "";
            txtSoDT.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Add_NhanVien ad = new Add_NhanVien();
            //ad.ShowDialog();
            string sql;
            btnLuu.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            ResetValues();
            sql = "Execute dbo.sp_NhanVien_SinhMaTuDong";
            txtMaNV.Text = Class.Function.GetFieldValues(sql);
            LoadDataGridView();

        }

        private void dgvXNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql;
            if(btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }    
            if(tbNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaNV.Text = dgvXNhanVien.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTenNV.Text = dgvXNhanVien.CurrentRow.Cells["HoTen"].Value.ToString();
            cboGioiTinh.Text = dgvXNhanVien.CurrentRow.Cells["GioiTinh"].Value.ToString();
            txtDiaChi.Text = dgvXNhanVien.CurrentRow.Cells["DiaChi"].Value.ToString();
            dtpNgaySinh.Text = dgvXNhanVien.CurrentRow.Cells["NgaySinh"].Value.ToString();
            txtSoDT.Text = dgvXNhanVien.CurrentRow.Cells["SoDT"].Value.ToString();
            sql = "execute dbo.sp_SelectAll_NhanVien";
            tbNhanVien = Class.Function.GetDataToTable(sql);
            dgvXNhanVien.DataSource = tbNhanVien;
            //txtMaNV.DataBindings.Clear();
            //txtMaNV.DataBindings.Add("Text", dgvXNhanVien.DataSource, "MaNV");
            //txtTenNV.DataBindings.Clear();
            //txtTenNV.DataBindings.Add("Text", dgvXNhanVien.DataSource, "HoTen");
            //cboGioiTinh.DataBindings.Clear();
            //cboGioiTinh.DataBindings.Add("Text", dgvXNhanVien.DataSource, "GioiTinh");
            //txtDiaChi.DataBindings.Clear();
            //txtDiaChi.DataBindings.Add("Text", dgvXNhanVien.DataSource, "DiaChi");
            //dtpNgaySinh.DataBindings.Clear();
            //dtpNgaySinh.DataBindings.Add("date", dgvXNhanVien.DataSource, "NgaySinh");
            //txtSoDT.DataBindings.Clear();
            //txtSoDT.DataBindings.Add("Text", dgvXNhanVien.DataSource, "SoDT");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã Nhân Viên", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }    
            if(txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Tên Nhân Viên", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNV.Focus();
                return;
            }    
            if(cboGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Giới tính Nhân Viên", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Địa Chỉ Nhân Viên", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (dtpNgaySinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Ngày Sinh", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgaySinh.Focus();
                return;
            }
            if (txtSoDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Tên Nhân Viên", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoDT.Focus();
                return;
            }
            sql = "Select MaNV from NhanVien where MaNV = N'" + txtMaNV.Text.Trim() + "'";
            if(Class.Function.KiemTraKhoaTrung(sql))
            {
                    MessageBox.Show("Mã Nhân Viên Này đã tồn tại.", "Thống báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
            sql = "execute dbo.sp_Insert_NhanVien '" + txtMaNV.Text + "', N'"+txtTenNV.Text+"',N'"+cboGioiTinh.Text+"',N'"+txtDiaChi.Text+"', '"+ Function.Ngaythangnam(dtpNgaySinh.Text)+"','"+txtSoDT.Text+"'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e) 
        {
            string ngay = dtpNgaySinh.Value.ToString("dd/MM/yyyy");
            string sql;
            if (tbNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin bảng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }
            sql = "Execute dbo.sp_Update_NhanVien @MaNV = '"+txtMaNV.Text.Trim()+"', @HoTen =  N'" + txtTenNV.Text.Trim() + "', @GioiTinh = N'" + cboGioiTinh.Text.Trim() + "',@DiaChi= N'" + txtDiaChi.Text.Trim() + "',@NgaySinh='" + Function.Ngaythangnam(dtpNgaySinh.Text.Trim()) + "',@SoDT =  N'" + txtSoDT.Text.Trim() + "'";
            //sql = "Update NhanVien set HoTen=N'" + txtTenNV.Text.Trim().ToString() + "',GioiTinh = N'" + cboGioiTinh.Text.Trim().ToString() + "', DiaChi = N'" + txtDiaChi.Text.Trim().ToString() + "',NgaySinh = '" + Function.Ngaythangnam(dtpNgaySinh.Text.Trim()) + "',SoDT= N'" + txtSoDT.Text.Trim().ToString() + "' where MaNV='" + txtMaNV.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            //Class.Function.Disconnect();
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if(tbNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải chọn mã Sinh viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNV.Focus();
                return;
            }    
            if(MessageBox.Show("Bạn có muốn xóa dữ liệu này không", "Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "Delete NhanVien where MaNV='" + txtMaNV.Text + "'";
                Class.Function.RunSQL(sql);
                LoadDataGridView();
                ResetValues();
            }    

        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            RPNhanVien nhanvien = new RPNhanVien();
            nhanvien.ShowDialog();
        }
    }
}
