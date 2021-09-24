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
    public partial class RPSach : Form
    {
        public RPSach()
        {
            InitializeComponent();
        }

        private void RPSach_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLY_ThuVien_DHDataSet.Sach' table. You can move, or remove it, as needed.
            this.SachTableAdapter.Fill(this.QLY_ThuVien_DHDataSet.Sach);

            this.reportViewer1.RefreshReport();
        }
    }
}
