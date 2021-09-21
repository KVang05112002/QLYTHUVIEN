using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_THUVIET_2021.Class;

namespace QL_THUVIET_2021
{
    public partial class FormMain :DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            Class.Function.Connect();
        }
        private void Closethis()
        {
            TabItem SelectedTab = tabMain.SelectedTab;
            if (MessageBox.Show("Bạn Có muốn tắt: " + SelectedTab.Text, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if(tabMain.SelectedTabIndex!=0)
                tabMain.Tabs.Remove(SelectedTab);
        }
        private void tabMain_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {
            Closethis();
        }

        private void đóngTrangNàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Closethis();
        }

        private void ctmnMain_Opening(object sender, CancelEventArgs e)
        {
            if (tabMain.SelectedTabIndex == 0)
                đóngTrangNàyToolStripMenuItem.Enabled = false;
            else
                đóngTrangNàyToolStripMenuItem.Enabled = true;
        }

        private void đóngTrangKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = tabMain.SelectedTabIndex;
            for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
                if (index != i)
                    tabMain.Tabs.RemoveAt(i);
            tabMain.Refresh();
        }

        private void đóngTấtCảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = tabMain.SelectedTabIndex;
            for (int i = tabMain.Tabs.Count - 1; i > 0; i--)
                    tabMain.Tabs.RemoveAt(i);
            tabMain.Refresh();
        }

        private void btnQLNguoiDung_Click(object sender, EventArgs e)
        {
            FormTaiKhoan ftk = new FormTaiKhoan();
            AddNewTab("QL Tài Khoản", ftk);
            //ftk.ShowDialog();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            var dangxuat = MessageBox.Show("Bạn Có Muốn Đăng Xuất không?", "Xác Nhận", MessageBoxButtons.YesNo);
            if (dangxuat == DialogResult.Yes)
            {
                this.Close();
                Login lg = new Login();
                lg.Show();
            }
        }

       

        private void buttonItem6_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Black;
        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Blue;
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007Silver;
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2007VistaGlass;
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Black;
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Blue;
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2010Silver;
        }

        private void buttonItem17_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Office2013;
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.VisualStudio2010Blue;
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.VisualStudio2012Dark;
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.VisualStudio2012Light;
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            styleManager1.ManagerStyle = eStyle.Windows7Blue;
        }

        private void btnThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            FormDoiMatKhau fdmk = new FormDoiMatKhau();
            fdmk.ShowDialog();
        }

        private void tabMain_Click(object sender, EventArgs e)
        {
            
        }
        public void AddNewTab(string tabname, UserControl uccontrol)
        {
            foreach (TabItem tab in tabMain.Tabs)
            {
                if (tab.Text == tabname)
                {
                    tabMain.SelectedTab = tab;
                    return;
                }
            }
            TabControlPanel newTabPanel = new TabControlPanel();
            TabItem newTabPage = new TabItem(components);
            newTabPanel.Dock = DockStyle.Fill;
            newTabPanel.Location = new System.Drawing.Point(0, 26);
            newTabPanel.Name = "panel" + tabname;
            newTabPanel.Padding = new System.Windows.Forms.Padding(1);
            newTabPanel.Size = new System.Drawing.Size(1000, 396);
            newTabPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
            newTabPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            newTabPanel.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            newTabPanel.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
            newTabPanel.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right)
                        | DevComponents.DotNetBar.eBorderSide.Bottom)));
            newTabPanel.Style.GradientAngle = 90;
            newTabPanel.TabIndex = 2;
            newTabPanel.TabItem = newTabPage;
            Random ran = new Random();
            newTabPage.Name = tabname + ran.Next(100000) + ran.Next(22342);
            newTabPage.AttachedControl = newTabPanel;
            newTabPage.Text = tabname;
            uccontrol.Dock = DockStyle.Fill;
            newTabPanel.Controls.Add(uccontrol);
            tabMain.Controls.Add(newTabPanel);
            tabMain.Tabs.Add(newTabPage);
            tabMain.SelectedTab = newTabPage;
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            try
            {
                UserQLYNhanVien usernhanvien = new UserQLYNhanVien();
                AddNewTab("QL Nhân Viên", usernhanvien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTacGia_Click(object sender, EventArgs e)
        {
            try
            {
                UserTacGia usertacgia = new UserTacGia();
                AddNewTab("QL Tác Giả", usertacgia);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonItem3_Click(object sender, EventArgs e)
        {
            try
            {
                UserTheLoai usertheloai = new UserTheLoai();
                AddNewTab("Thể Loại", usertheloai);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNhaXuatBan_Click(object sender, EventArgs e)
        {
            try
            {
                UserNhaXB usernhaxb = new UserNhaXB();
                AddNewTab("Nhà XB", usernhaxb);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnQLSinhVien_Click(object sender, EventArgs e)
        {
            try
            {
                UserSinhVien usersinhvien = new UserSinhVien();
                AddNewTab("QL Sinh Viên", usersinhvien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNoiQuy_Click(object sender, EventArgs e)
        {
            try
            {
                UserNoiQuy usernoiquy = new UserNoiQuy();
                AddNewTab("Nội quy", usernoiquy);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnTheThuVien_Click(object sender, EventArgs e)
        {
            try
            {
                UserTheThuVien userthethuvien = new UserTheThuVien();
                AddNewTab("Thẻ Thư Viện", userthethuvien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPhieuMuon_Click(object sender, EventArgs e)
        {
            try
            {
                UserPhieuMuonTra Muontra = new UserPhieuMuonTra();
                AddNewTab("Lập Phiếu Mượn", Muontra);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnNhacTra_Click(object sender, EventArgs e)
        {
            try
            {
                UserPhieuNhacTra nhactra = new UserPhieuNhacTra();
                AddNewTab("Phiếu Nhác Trả", nhactra);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
                UserSach sach = new UserSach();
                AddNewTab("QL Sach", sach);
            
        }

        private void btnSachMuon_Click(object sender, EventArgs e)
        {
            UserSachMuon sachMuon = new UserSachMuon();
            AddNewTab("QL Sách Mượn", sachMuon);
        }
    }
}
