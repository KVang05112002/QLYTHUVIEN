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
            dtpNgayBD.Text = dgvTheThuVien.CurrentRow.Cells["NgayBanDau"].Value.ToString();
            dtpNgayKT.Text = dgvTheThuVien.CurrentRow.Cells["NgayHetHan"].Value.ToString();
            txtGhiChu.Text = dgvTheThuVien.CurrentRow.Cells["GhiChu"].Value.ToString();
            cboMaSV.Text = dgvTheThuVien.CurrentRow.Cells["MaSV"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            ResetValues();
            string sql;
            sql = "execute sp_TheThuVien_SinhMaTuDong";
            txtSoThe.Text = Class.Function.GetFieldValues(sql);
            LoadDataGridview();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtSoThe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải thêm số thẻ của sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoThe.Focus();
                return;
            }
            if (cboMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải Nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaNV.Focus();
                return;
            }
            if (dtpNgayBD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạt phải nhập ngày bắn đầu thực thi thẻ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayBD.Focus();
                return;
            }
            if (dtpNgayKT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập ngày kết thúc thẻ thư viện này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dtpNgayKT.Focus();
                return;
            }
            if (cboMaSV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập Mã số Sinh viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cboMaSV.Focus();
                return;
            }
            sql = "Select SoThe from TheThuVien where SoThe=N'" + txtSoThe.Text.Trim() + "'";
            if(Class.Function.KiemTraKhoaTrung(sql))
            {
                MessageBox.Show("Số thẻ này đã có sinh viên sở hửu vui lòng Nhập số thẻ khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "Execute sp_Insert_TheThuVien N'" + txtSoThe.Text + "','" + cboMaNV.Text + "','" + Function.Ngaythangnam(dtpNgayBD.Text) + "','" + Function.Ngaythangnam(dtpNgayKT.Text) + "',N'" + txtGhiChu.Text.Trim() + "','" + cboMaSV.Text + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridview();
            ResetValues();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbThethuvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSoThe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn Số Thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoThe.Focus();
                return;
            }
            sql = "Update TheThuVien set MaNV='"+cboMaNV.Text.Trim()+"',NgayBanDau='"+Function.Ngaythangnam(dtpNgayBD.Text)+ "',NgayHetHan='" + Function.Ngaythangnam(dtpNgayKT.Text) + "',GhiChu=N'"+txtGhiChu.Text.Trim()+"',MaSV='"+cboMaSV.Text.Trim()+"'  where SoThe = N'" + txtSoThe.Text.Trim() + "'";
            Class.Function.RunSQL(sql);
            LoadDataGridview();
            ResetValues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tbThethuvien.Rows.Count == 0)
            {
                MessageBox.Show("Không có thông tin dữ liệu cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtSoThe.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn Số Thẻ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoThe.Focus();
                return;
            }
            sql = "delete TheThuVien where SoThe='"+txtSoThe.Text+"'";
            Class.Function.RunSQL(sql);
            LoadDataGridview();
            ResetValues();
        }
    }
}
