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
    public partial class UserNhaXB : UserControl
    {
        public UserNhaXB()
        {
            InitializeComponent();
        }
        DataTable tbNXB;
        private void UserNhaXB_Load(object sender, EventArgs e)
        {
            LoadDataGridview();
        }
        private  void LoadDataGridview()
        {
            string sql = "Select * from NhaXuatBan";
            tbNXB = Class.Function.GetDataToTable(sql);
            dtgXNXB.DataSource = tbNXB;
            dtgXNXB.Columns[0].HeaderText = "Mã NXB";
            dtgXNXB.Columns[0].Width = 150;
            dtgXNXB.Columns[1].HeaderText = "Tên NXB";
            dtgXNXB.Columns[1].Width = 150;
            dtgXNXB.Columns[2].HeaderText = "Địa Chỉ";
            dtgXNXB.Columns[2].Width = 150;
            dtgXNXB.Columns[3].HeaderText = "Email";
            dtgXNXB.Columns[3].Width = 150;
            dtgXNXB.Columns[4].HeaderText = "Người đại diện";
            dtgXNXB.Columns[4].Width = 150;
            dtgXNXB.AllowUserToAddRows = false;
            dtgXNXB.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void ResetValue()
        {
            txtMaNXB.Text = "";
            txtTenNXB.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";
            txtDaiDien.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            ResetValue();
            string sql = "Excecute dbo.sp_NXB_SinhMaTuDong";
            txtMaNXB.Text = Class.Function.GetFieldValues(sql);
            LoadDataGridview();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
          
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
        }

        private void dtgXNXB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(tbNXB.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnThem.Enabled == false)
            {
                MessageBox.Show("Đang ở chế độ thêm mới", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnThem.Focus();
                return;
            }
            txtMaNXB.Text = dtgXNXB.CurrentRow.Cells["MaNXB"].Value.ToString();
            txtTenNXB.Text = dtgXNXB.CurrentRow.Cells["TenNXB"].Value.ToString();
            txtDiaChi.Text = dtgXNXB.CurrentRow.Cells["DiaChi"].Value.ToString();
            txtEmail.Text = dtgXNXB.CurrentRow.Cells["Email"].Value.ToString();
            txtDaiDien.Text = dtgXNXB.CurrentRow.Cells["TTNDaiDien"].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(txtMaNXB.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải thêm mã nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaNXB.Focus();
                return;
            }
            if (txtTenNXB.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải thêm tên nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenNXB.Focus();
                return;
            }
            if (txtDiaChi.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải nhập địa chỉ nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDiaChi.Focus();
                return;
            }
            if (txtEmail.Text.Length == 0)
            {
                MessageBox.Show("Bạn phải địa chỉ email của nhà xuất bản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEmail.Focus();
                return;
            }
            sql = "Select MaNXB from NhaXuatBan where MaNXB= '" + txtMaNXB.Text.Trim() + "'";
            if (Class.Function.KiemTraKhoaTrung(sql))
            {
                MessageBox.Show("Mã khóa này đã được sử dụng vui lòng chọn mã khóa khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql = "Excute dbo.";
        }
    }
}
