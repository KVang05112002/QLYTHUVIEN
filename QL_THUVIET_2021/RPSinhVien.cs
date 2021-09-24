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
    public partial class RPSinhVien : Form
    {
        public RPSinhVien()
        {
            InitializeComponent();
        }

        private void RPSinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLY_ThuVien_DHDataSet.SinhVien' table. You can move, or remove it, as needed.
            this.SinhVienTableAdapter.Fill(this.QLY_ThuVien_DHDataSet.SinhVien);

            this.reportViewer1.RefreshReport();
        }
    }
}
