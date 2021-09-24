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
    public partial class RPSachMuon : Form
    {
        public RPSachMuon()
        {
            InitializeComponent();
        }

        private void RPSachMuon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLY_ThuVien_DHDataSet.MuonTra' table. You can move, or remove it, as needed.
            this.MuonTraTableAdapter.Fill(this.QLY_ThuVien_DHDataSet.MuonTra);

            this.reportViewer1.RefreshReport();
        }
    }
}
