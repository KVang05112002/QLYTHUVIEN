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
    public partial class UserQLYNhanVien : UserControl
    {
        public UserQLYNhanVien()
        {
            InitializeComponent();
        }

        private void UserQLYNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.JPG)| *.JPG | GIF Files(*.GIF) | *.GIF";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                ptbHinhAnh.Image = Image.FromFile(dlg.FileName);
            }
        }
    }
}
