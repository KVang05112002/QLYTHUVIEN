using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_THUVIET_2021
{
    public partial class Add_NhanVien : Form
    {
        public Add_NhanVien()
        {
            InitializeComponent();
        }

        private void Add_NhanVien_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "Execute dbo.sp_NhanVien_SinhMaTuDong";
            txtMaNV.Text = Class.Function.GetFieldValues(sql);
        }
    }
}
