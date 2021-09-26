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
//K' Vảng JinJin
namespace QL_THUVIET_2021
{
    public partial class UserSachMuon : UserControl
    {
        public UserSachMuon()
        {
            InitializeComponent();
        }
        DataTable tbSachMuon;
        private void UserSachMuon_Load(object sender, EventArgs e)
        {
            Function.FillCombo("select SoThe, GhiChu from TheThuVien", cboSoThe, "SoThe", "SoThe");
            cboSoThe.SelectedIndex = -1;
            Function.FillCombo("select MaNV, HoTen from NhanVien", cboMaNhanVien, "MaNV", "MaNV");
            cboMaNhanVien.SelectedIndex = -1;
            Function.FillCombo("select MaSV, HoTenSV from SinhVien", cboMaSinhVien, "MaSV", "MaSV");
            cboMaSinhVien.SelectedIndex = -1;
            Function.FillCombo("select MaSach, TenSach from Sach", cboMaSach, "MaSach", "MaSach");
            cboMaSach.SelectedIndex = -1;
            LoadSachMuon();
        }
        private void LoadSachMuon()
        {
            string sql;
            sql = "select * from MuonTra";
            tbSachMuon = Class.Function.GetDataToTable(sql);
            dgvSachMuon.DataSource = tbSachMuon;
            dgvSachMuon.Columns[0].HeaderText = "Mã Sách Mượn";
            dgvSachMuon.Columns[0].Width = 150;
            dgvSachMuon.Columns[1].HeaderText = "Số Thẻ";
            dgvSachMuon.Columns[1].Width = 100;
            dgvSachMuon.Columns[2].HeaderText = "Mã Nhân Viên";
            dgvSachMuon.Columns[2].Width = 150;
            dgvSachMuon.Columns[3].HeaderText = "Mã Sinh Viên";
            dgvSachMuon.Columns[3].Width = 150;
            dgvSachMuon.Columns[4].HeaderText = "Ngày Mượn";
            dgvSachMuon.Columns[4].Width = 100;
            dgvSachMuon.Columns[5].HeaderText = "Số Lượng";
            dgvSachMuon.Columns[5].Width = 100;
            dgvSachMuon.Columns[6].HeaderText = "Tình Trạng";
            dgvSachMuon.Columns[6].Width = 200;
            dgvSachMuon.Columns[7].HeaderText = "Ghi Chú";
            dgvSachMuon.Columns[7].Width = 200;
            dgvSachMuon.Columns[8].HeaderText = "Ngày Trả";
            dgvSachMuon.Columns[8].Width = 100;
            dgvSachMuon.Columns[9].HeaderText = "Mã Sách";
            dgvSachMuon.Columns[9].Width = 100;
            dgvSachMuon.AllowUserToAddRows = false;
            dgvSachMuon.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaSachMuon.Text = "";
            txtSoLuong.Text = "";
            txtGhiCHu.Text = "";
            cboMaNhanVien.Text = "";
            cboMaSinhVien.Text = "";
            cboSoThe.Text = "";
            cboTinhTrang.Text = "";
            cboMaSach.Text = "";
        }
        private void dgvSachMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(tbSachMuon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaSachMuon.Text = dgvSachMuon.CurrentRow.Cells["MaMT"].Value.ToString();
            cboSoThe.Text = dgvSachMuon.CurrentRow.Cells["SoThe"].Value.ToString();
            cboMaNhanVien.Text = dgvSachMuon.CurrentRow.Cells["MaNV"].Value.ToString();
            cboMaSinhVien.Text = dgvSachMuon.CurrentRow.Cells["MaSV"].Value.ToString();
            dtpNgayMuon.Text = dgvSachMuon.CurrentRow.Cells["NgayMuon"].Value.ToString();
            txtSoLuong.Text = dgvSachMuon.CurrentRow.Cells["SoLuongMuon"].Value.ToString();
            cboTinhTrang.Text = dgvSachMuon.CurrentRow.Cells["TinhTrang"].Value.ToString();
            txtGhiCHu.Text = dgvSachMuon.CurrentRow.Cells["GhiChu"].Value.ToString();
            dtpNgayTra.Text = dgvSachMuon.CurrentRow.Cells["NgayTra"].Value.ToString();
            cboMaSach.Text = dgvSachMuon.CurrentRow.Cells["MaSach"].Value.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            ResetValues();
            string sql;
            sql = "execute dbo.sp_SachMuon_SinhMaTuDong";
            txtMaSachMuon.Text = Class.Function.GetFieldValues(sql);
            LoadSachMuon();
            //sp_SachMuon_SinhMaTuDong
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtMaSachMuon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSachMuon.Focus();
                return;
            }
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Bạn Phải nhập số lượng mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoLuong.Focus();
                return;
            }
            if (cboSoThe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập số thẻ thư viện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSoThe.Focus();
                return;
            }
            if (cboMaNhanVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNhanVien.Focus();
                return;
            }
            if (cboMaSinhVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã Sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSinhVien.Focus();
                return;
            }
            if (cboMaSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã Sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSach.Focus();
                return;
            }
            if (dtpNgayMuon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập ngày mượn Sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayMuon.Focus();
                return;
            }
            if (dtpNgayTra.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Ngày trả Sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayTra.Focus();
                return;
            }
            sql = "Select MaMT from MuonTra where MaMT='" + txtMaSachMuon.Text + "'";
            if(Class.Function.KiemTraKhoaTrung(sql))
            {
                MessageBox.Show("Mã này đã được sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "Execute dbo.sp_insert_SachMuon '" + txtMaSachMuon.Text + "','" + cboSoThe.Text + "','" + cboMaNhanVien.Text + "','" + cboMaSinhVien.Text + "','" + Function.Ngaythangnam(dtpNgayMuon.Text) + "'," + txtSoLuong.Text + ",N'Đã Mượn',N'" + txtGhiCHu.Text + "','" + Function.Ngaythangnam(dtpNgayTra.Text) + "','" + cboMaSach.Text + "'";
            Class.Function.RunSQL(sql);
            LoadSachMuon();
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if(tbSachMuon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtMaSachMuon.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn Mã Sách mượn cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSachMuon.Focus();
                return;
            }
            sql = "Delete MuonTra where MaMT='" + txtMaSachMuon.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadSachMuon();
            ResetValues();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbSachMuon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaSachMuon.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải chọn Mã Sách mượn cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaSachMuon.Focus();
                return;
            }
            sql = "Execute dbo.sp_Update_SachMuon @MaMT='" + txtMaSachMuon.Text + "',@SoThe='" + cboSoThe.Text + "',@MaNV='" + cboMaNhanVien.Text + "',@MaSV='" + cboMaSinhVien.Text + "',@NgayMuon='" + Function.Ngaythangnam(dtpNgayMuon.Text) + "',@SoLuongMuon=" + txtSoLuong.Text + ",@TinhTrang=N'" + cboTinhTrang.Text + "',@GhiChu=N'" + txtGhiCHu.Text + "',@NgayTra='" + Function.Ngaythangnam(dtpNgayTra.Text) + "',@MaSach='" + cboMaSach.Text + "'"; 
            Class.Function.RunSQL(sql);
            LoadSachMuon();
            ResetValues();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            RPSachMuon sachmuon = new RPSachMuon();
            sachmuon.ShowDialog();
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            string sql;
            sql = "Execute dbo.sp_Update_SachMuon @MaMT='" + txtMaSachMuon.Text + "',@SoThe='" + cboSoThe.Text + "',@MaNV='" + cboMaNhanVien.Text + "',@MaSV='" + cboMaSinhVien.Text + "',@NgayMuon='" + Function.Ngaythangnam(dtpNgayMuon.Text) + "',@SoLuongMuon=" + txtSoLuong.Text + ",@TinhTrang=N'Đã Trả',@GhiChu=N'" + txtGhiCHu.Text + "',@NgayTra='" + Function.Ngaythangnam(dtpNgayTra.Text) + "',@MaSach='" + cboMaSach.Text + "'";
            Class.Function.RunSQL(sql);
            LoadSachMuon();
            ResetValues();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "")
            {
                MessageBox.Show("Bạn Phải chọn mã Phiếu mượn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimKiem.Focus();
                return;
            }
            else
            {
                cboMaSinhVien.Text = txtTimKiem.Text;
                LoadTimKiem();
            }
            
        }
        private void LoadTimKiem()
        {
            string sql = "Select * from MuonTra where MaSV like '%" + cboMaSinhVien.Text + "%'";
            tbSachMuon = Class.Function.GetDataToTable(sql);
            dgvSachMuon.DataSource = tbSachMuon;
            txtMaSachMuon.Text = dgvSachMuon.CurrentRow.Cells["MaMT"].Value.ToString();
            cboSoThe.Text = dgvSachMuon.CurrentRow.Cells["SoThe"].Value.ToString();
            cboMaNhanVien.Text = dgvSachMuon.CurrentRow.Cells["MaNV"].Value.ToString();
            cboMaSinhVien.Text = dgvSachMuon.CurrentRow.Cells["MaSV"].Value.ToString();
            dtpNgayMuon.Text = dgvSachMuon.CurrentRow.Cells["NgayMuon"].Value.ToString();
            txtSoLuong.Text = dgvSachMuon.CurrentRow.Cells["SoLuongMuon"].Value.ToString();
            cboTinhTrang.Text = dgvSachMuon.CurrentRow.Cells["TinhTrang"].Value.ToString();
            txtGhiCHu.Text = dgvSachMuon.CurrentRow.Cells["GhiChu"].Value.ToString();
            dtpNgayTra.Text = dgvSachMuon.CurrentRow.Cells["NgayTra"].Value.ToString();
            cboMaSach.Text = dgvSachMuon.CurrentRow.Cells["MaSach"].Value.ToString();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadSachMuon();
        }
    }
}
