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
    public partial class UserPhieuNhacTra : UserControl
    {
        public UserPhieuNhacTra()
        {
            InitializeComponent();
        }
        DataTable tbPhieunhactra;
        private void UserPhieuMuon_Load(object sender, EventArgs e)
        {
            Function.FillCombo("Select SoThe, GhiChu from TheThuVien", cboSoThe, "SoThe", "SoThe");
            cboSoThe.SelectedIndex = -1;
            Function.FillCombo("Select MaSV, HoTenSV from SinhVien", cboMaSV, "MaSV", "MaSV");
            cboMaSV.SelectedIndex = -1;
            Function.FillCombo("Select MaNV, HoTen from NhanVien", cboMaNV, "MaNV", "MaNV");
            cboMaNV.SelectedIndex = -1;
            Function.FillCombo("Select MaSach, TenSach from Sach", cboMaSach, "MaSach", "MaSach");
            cboMaSach.SelectedIndex = -1;
            Function.FillCombo("Select MaPNT, DonGiaPhat from PhieuNhacTra", cboTImKiem, "MaPNT", "MaPNT");
            cboTImKiem.SelectedIndex = -1;
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            string sql;
            sql = "Select * from PhieuNhacTra";
            tbPhieunhactra = Class.Function.GetDataToTable(sql);
            dgvNhacTra.DataSource = tbPhieunhactra;
            dgvNhacTra.Columns[0].HeaderText = "Mã PNT";
            dgvNhacTra.Columns[0].Width = 100;
            dgvNhacTra.Columns[1].HeaderText = "Số Thẻ";
            dgvNhacTra.Columns[1].Width = 100;
            dgvNhacTra.Columns[2].HeaderText = "Mã SV";
            dgvNhacTra.Columns[2].Width = 100;
            dgvNhacTra.Columns[3].HeaderText = "Ngày Lâp";
            dgvNhacTra.Columns[3].Width = 150;
            dgvNhacTra.Columns[4].HeaderText = "Giá Phạt";
            dgvNhacTra.Columns[4].Width = 100;
            dgvNhacTra.Columns[5].HeaderText = "Mã NV";
            dgvNhacTra.Columns[5].Width = 100;
            dgvNhacTra.Columns[6].HeaderText = "Mã Sách";
            dgvNhacTra.Columns[6].Width = 100;
            //không cho nhập trực tiếp trên datagridview
            dgvNhacTra.AllowUserToAddRows = false;
            dgvNhacTra.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValues()
        {
            txtMaPNT.Text = "";
            cboSoThe.Text = "";
            cboMaSV.Text = "";
            txtGiaPhat.Text = "0";
            cboMaNV.Text = "";
            cboMaSach.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            string sql;
            sql = "execute dbo.sp_PhieuNhacTra_SinhMaTuDong";
            txtMaPNT.Text = Class.Function.GetFieldValues(sql);
            LoadDataGridView();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtMaPNT.Text.Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã Phiếu nhác trả", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPNT.Focus();
                return;
            }
            if (cboSoThe.Text.Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Số thẻ thư viện của sinh viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboSoThe.Focus();
                return;
            }
            if (cboMaSV.Text.Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã Sinh viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSV.Focus();
                return;
            }
            if (dtpNgayLap.Text.Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Ngày lập phiếu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayLap.Focus();
                return;
            }
            if (txtGiaPhat.Text.Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập giá phạt đối với sinh viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtGiaPhat.Focus();
                return;
            }
            if (cboMaNV.Text.Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã Mã Nhân viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNV.Focus();
                return;
            }
            if (cboMaSach.Text.Length == 0)
            {
                MessageBox.Show("Bạn Phải nhập Mã sach", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSach.Focus();
                return;
            }
            sql = "select MaPNT from PhieuNhacTra where MaPNT=N'" + txtMaPNT.Text.Trim() + "'";
            if(Class.Function.KiemTraKhoaTrung(sql))
            {
                MessageBox.Show("Mã Phiếu này đã tồn tại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            sql = "Execute dbo.sp_Insert_PhieuNhacTra '" + txtMaPNT.Text + "','" + cboSoThe.Text + "','" + cboMaSV.Text + "','" + Function.Ngaythangnam(dtpNgayLap.Text) + "','" + txtGiaPhat.Text + "','" + cboMaNV.Text + "','" + cboMaSach.Text + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbPhieunhactra.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPNT.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần chọn mã Phiếu nhắc trả cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPNT.Focus();
                return;
            }
            sql = "Delete PhieuNhacTra where MaPNT=N'" + txtMaPNT.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();

        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbPhieunhactra.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtMaPNT.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần chọn mã Phiếu nhắc trả cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaPNT.Focus();
                return;
            }
            sql = "Execute dbo.sp_Update_PhieuNhacTra @MaPNT = '" + txtMaPNT.Text.Trim() + "', @SoThe='" + cboSoThe.Text.Trim() + "',@MaSV = '" + cboMaSV.Text.Trim() + "',@NgayLapPhat = '" + Function.Ngaythangnam(dtpNgayLap.Text.Trim()) + "', @DonGiaPhat= '" + txtGiaPhat.Text.Trim() + "', @MaNV = '" + cboMaNV.Text.Trim() + "', @MaSach = '" + cboMaSach.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridView();
            ResetValues();
        }
        private void dgvNhacTra_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (tbPhieunhactra.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }
            txtMaPNT.Text = dgvNhacTra.CurrentRow.Cells["MaPNT"].Value.ToString();
            cboSoThe.Text = dgvNhacTra.CurrentRow.Cells["SoThe"].Value.ToString();
            cboMaSV.Text = dgvNhacTra.CurrentRow.Cells["MaSV"].Value.ToString();
            dtpNgayLap.Text = dgvNhacTra.CurrentRow.Cells["NgayLapPhat"].Value.ToString();
            txtGiaPhat.Text = dgvNhacTra.CurrentRow.Cells["DonGiaPhat"].Value.ToString();
            cboMaNV.Text = dgvNhacTra.CurrentRow.Cells["MaNV"].Value.ToString();
            cboMaSach.Text = dgvNhacTra.CurrentRow.Cells["MaSach"].Value.ToString();
        }
        private void LoadTimKiem()
        {
            string sql;
            sql = "Select * from PhieuNhacTra where MaPNT Like '%" + txtMaPNT.Text + "%'";
            tbPhieunhactra = Class.Function.GetDataToTable(sql);
            dgvNhacTra.DataSource = tbPhieunhactra;
            string str;
            str = "select SoThe from PhieuNhacTra where MaPNT = '" + txtMaPNT.Text + "'";
            cboSoThe.Text = Class.Function.GetFieldValues(str);
            str = "select MaSV from PhieuNhacTra where MaPNT = '" + txtMaPNT.Text + "'";
            cboMaSV.Text = Class.Function.GetFieldValues(str);
            str = "select NgayLapPhat from PhieuNhacTra where MaPNT = '" + txtMaPNT.Text + "'";
            dtpNgayLap.Text = Class.Function.GetFieldValues(str);
            str = "select DonGiaPhat from PhieuNhacTra where MaPNT = '" + txtMaPNT.Text + "'";
            txtGiaPhat.Text = Class.Function.GetFieldValues(str);
            str = "select MaNV from PhieuNhacTra where MaPNT = '" + txtMaPNT.Text + "'";
            cboMaNV.Text = Class.Function.GetFieldValues(str);
            str = "select MaSach from PhieuNhacTra where MaPNT = '" + txtMaPNT.Text + "'";
            cboMaSach.Text = Class.Function.GetFieldValues(str);
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(cboTImKiem.Text == "")
            {
                MessageBox.Show("Bạn phải chọn mã Phiếu nhắc trả cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboTImKiem.Focus();
                return;
            }
            txtMaPNT.Text = cboTImKiem.Text;
            LoadTimKiem();
            cboTImKiem.SelectedIndex = -1;
        }
        private void btnLoadX_Click(object sender, EventArgs e)
        {
            LoadDataGridView();
        }
    }
}
