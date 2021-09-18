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
    public partial class UserPhieuMuonTra : UserControl
    {
        public UserPhieuMuonTra()
        {
            InitializeComponent();
        }
        DataTable tbPhieuMuon;
        private void UserPhieuMuonTra_Load(object sender, EventArgs e)
        {
            Function.FillCombo("Select SoThe, Manv from TheThuVien", cboSoThe, "SoThe", "SoThe");
            cboSoThe.SelectedIndex = -1;
            Function.FillCombo("Select MaSach, TenSach from Sach", cboMaSach, "MaSach", "MaSach");
            cboMaSach.SelectedIndex = -1;
            Function.FillCombo("Select MaSV, HoTenSV from SinhVien", cboMaSinhVien, "MaSV", "MaSV");
            cboMaSinhVien.SelectedIndex = -1;
            Function.FillCombo("Select MaPM, NgayMuon from PhieuMuon", cboTImKiem, "MaPM", "MaPM");
            cboTImKiem.SelectedIndex = -1;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "Select*from PhieuMuon";
            tbPhieuMuon = Class.Function.GetDataToTable(sql);
            dgvPhieuMuonX.DataSource = tbPhieuMuon;
            dgvPhieuMuonX.Columns[0].HeaderText = "Mã Phiếu Mượn";
            dgvPhieuMuonX.Columns[0].Width = 150;
            dgvPhieuMuonX.Columns[1].HeaderText = "Mã Sách";
            dgvPhieuMuonX.Columns[1].Width = 100;
            dgvPhieuMuonX.Columns[2].HeaderText = "Số Thẻ TV";
            dgvPhieuMuonX.Columns[2].Width = 100;
            dgvPhieuMuonX.Columns[3].HeaderText = "Ngày Mượn";
            dgvPhieuMuonX.Columns[3].Width = 150;
            dgvPhieuMuonX.Columns[4].HeaderText = "Mã Sinh Viên";
            dgvPhieuMuonX.Columns[4].Width = 150;
            dgvPhieuMuonX.AllowUserToAddRows = false;
            dgvPhieuMuonX.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaPM.Text = "";
            cboMaSach.Text = "";
            cboMaSinhVien.Text = "";
            cboSoThe.Text = "";
        }
        private void dgvPhieuMuonX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tbPhieuMuon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liêu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }
            txtMaPM.Text = dgvPhieuMuonX.CurrentRow.Cells["MaPM"].Value.ToString();
            cboMaSach.Text = dgvPhieuMuonX.CurrentRow.Cells["MaSach"].Value.ToString();
            cboSoThe.Text = dgvPhieuMuonX.CurrentRow.Cells["SoThe"].Value.ToString();
            dtpNgayMuon.Text = dgvPhieuMuonX.CurrentRow.Cells["NgayMuon"].Value.ToString();
            cboMaSinhVien.Text = dgvPhieuMuonX.CurrentRow.Cells["MaSV"].Value.ToString();
            LoadDataGridView();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            string sql;
            sql = "Execute dbo.sp_PhieuMuon_SinhMaTuDong";
            txtMaPM.Text = Class.Function.GetFieldValues(sql);
            LoadDataGridView();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        { 
            string sql;
            if(txtMaPM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã Phiếu Mượn sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPM.Focus();
                return;
            }    
            if(cboMaSach.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSach.Focus();
                return;
            }
            if (cboSoThe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập số thể thư viện của sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSoThe.Focus();
                return;
            }
            if (dtpNgayMuon.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày mà sinh viên mượn sách", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayMuon.Focus();
                return;
            }
            if (cboMaSinhVien.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã sinh viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSinhVien.Focus();
                return;
            }
            sql = "Select MaPM from PhieuMuon where MaPM='" + txtMaPM.Text.Trim() + "'";
            if(Class.Function.KiemTraKhoaTrung(sql))
            {
                MessageBox.Show("Mã phiếu mượn này đã có nhân sinh viên sở hửu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "execute dbo.sp_insertinto_PhieuMuon '" + txtMaPM.Text + "','" + cboMaSach.Text + "','" + cboSoThe.Text + "','" + Function.Ngaythangnam(dtpNgayMuon.Text) + "','" + cboMaSinhVien.Text + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(tbPhieuMuon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liêu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            if(txtMaPM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Chọn dòng dữ liệu cần xóa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPM.Focus();
                return;
            }
            string sql;
            sql = "Delete PhieuMuon where MaPM='"+txtMaPM.Text.Trim()+"'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (tbPhieuMuon.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liêu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPM.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn Phải Chọn dòng dữ liệu cần sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPM.Focus();
                return;
            }
            string sql;
            sql = "Execute dbo.sp_Update_PhieuMuon @MaPM = '" + txtMaPM.Text.Trim() + "',@MaSach = '" + cboMaSach.Text.Trim() + "',@SoThe='" + cboSoThe.Text.Trim() + "',@NgayMuon='" + Function.Ngaythangnam(dtpNgayMuon.Text) + "',@MaSV='" + cboMaSinhVien.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }
        private void LoadTimKiem()
        {
            string sql = "Select * from PhieuMuon where MaPM like '%" + txtMaPM.Text + "%'";
            tbPhieuMuon = Class.Function.GetDataToTable(sql);
            dgvPhieuMuonX.DataSource = tbPhieuMuon;
            string str;
            str = "Select MaSach from PhieuMuon where MaPM = '" + txtMaPM.Text + "'";
            cboMaSach.Text = Class.Function.GetFieldValues(str);
            str = "Select SoThe from PhieuMuon where MaPM = '" + txtMaPM.Text + "'";
            cboSoThe.Text = Class.Function.GetFieldValues(str);
            str = "Select NgayMuon from PhieuMuon where MaPM = '" + txtMaPM.Text + "'";
            dtpNgayMuon.Text = Class.Function.GetFieldValues(str);
            str = "Select MaSV from PhieuMuon where MaPM = '" + txtMaPM.Text + "'";
            cboMaSinhVien.Text = Class.Function.GetFieldValues(str);

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTImKiem.Text == "")
            {
                MessageBox.Show("Bạn Phải chọn mã Phiếu mượn để tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTImKiem.Focus();
                return;
            }
            txtMaPM.Text = cboTImKiem.Text;
            LoadTimKiem();
            cboTImKiem.SelectedIndex = -1;
        }

        private void btnLoadX_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
