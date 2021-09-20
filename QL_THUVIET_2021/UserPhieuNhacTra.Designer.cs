
namespace QL_THUVIET_2021
{
    partial class UserPhieuNhacTra
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPhieuNhacTra));
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboTImKiem = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvNhacTra = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtGiaPhat = new System.Windows.Forms.TextBox();
            this.btnXuat = new DevComponents.DotNetBar.ButtonX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.btnSua = new DevComponents.DotNetBar.ButtonX();
            this.btnXoa = new DevComponents.DotNetBar.ButtonX();
            this.btnThem = new DevComponents.DotNetBar.ButtonX();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.cboMaSach = new System.Windows.Forms.ComboBox();
            this.cboMaNV = new System.Windows.Forms.ComboBox();
            this.cboMaSV = new System.Windows.Forms.ComboBox();
            this.cboSoThe = new System.Windows.Forms.ComboBox();
            this.txtMaPNT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadX = new DevComponents.DotNetBar.ButtonX();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhacTra)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTimKiem.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Location = new System.Drawing.Point(1073, 82);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(113, 28);
            this.btnTimKiem.TabIndex = 20;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cboTImKiem
            // 
            this.cboTImKiem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboTImKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTImKiem.FormattingEnabled = true;
            this.cboTImKiem.Location = new System.Drawing.Point(636, 82);
            this.cboTImKiem.Name = "cboTImKiem";
            this.cboTImKiem.Size = new System.Drawing.Size(410, 28);
            this.cboTImKiem.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Yellow;
            this.label9.Location = new System.Drawing.Point(538, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Tìm Kiếm:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.dgvNhacTra);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(541, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 450);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bảng Phiếu Nhắc Trả Sách";
            // 
            // dgvNhacTra
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhacTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhacTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhacTra.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvNhacTra.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgvNhacTra.Location = new System.Drawing.Point(6, 26);
            this.dgvNhacTra.Name = "dgvNhacTra";
            this.dgvNhacTra.RowHeadersWidth = 51;
            this.dgvNhacTra.RowTemplate.Height = 24;
            this.dgvNhacTra.Size = new System.Drawing.Size(639, 418);
            this.dgvNhacTra.TabIndex = 0;
            this.dgvNhacTra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhacTra_CellContentClick_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnLoadX);
            this.groupBox1.Controls.Add(this.txtGiaPhat);
            this.groupBox1.Controls.Add(this.btnXuat);
            this.groupBox1.Controls.Add(this.btnLuu);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.dtpNgayLap);
            this.groupBox1.Controls.Add(this.cboMaSach);
            this.groupBox1.Controls.Add(this.cboMaNV);
            this.groupBox1.Controls.Add(this.cboMaSV);
            this.groupBox1.Controls.Add(this.cboSoThe);
            this.groupBox1.Controls.Add(this.txtMaPNT);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.groupBox1.Location = new System.Drawing.Point(29, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(487, 503);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin phiêu nhắc trả sách";
            // 
            // txtGiaPhat
            // 
            this.txtGiaPhat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtGiaPhat.Location = new System.Drawing.Point(158, 316);
            this.txtGiaPhat.Name = "txtGiaPhat";
            this.txtGiaPhat.Size = new System.Drawing.Size(305, 27);
            this.txtGiaPhat.TabIndex = 31;
            // 
            // btnXuat
            // 
            this.btnXuat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXuat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXuat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnXuat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXuat.HoverImage = global::QL_THUVIET_2021.Properties.Resources.tải_xuống__4_;
            this.btnXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnXuat.Image")));
            this.btnXuat.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnXuat.ImageTextSpacing = 10;
            this.btnXuat.Location = new System.Drawing.Point(344, 364);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(137, 55);
            this.btnXuat.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnXuat.TabIndex = 30;
            this.btnXuat.Text = "Xuất";
            this.btnXuat.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.HoverImage = global::QL_THUVIET_2021.Properties.Resources.tải_xuống__4_;
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnLuu.ImageTextSpacing = 10;
            this.btnLuu.Location = new System.Drawing.Point(173, 436);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(150, 55);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnLuu.TabIndex = 29;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSua
            // 
            this.btnSua.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSua.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSua.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSua.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnSua.HoverImage = global::QL_THUVIET_2021.Properties.Resources.tải_xuống__4_;
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnSua.ImageTextSpacing = 10;
            this.btnSua.Location = new System.Drawing.Point(6, 436);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(150, 55);
            this.btnSua.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnSua.TabIndex = 28;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnXoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnXoa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXoa.HoverImage = global::QL_THUVIET_2021.Properties.Resources.tải_xuống__4_;
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnXoa.ImageTextSpacing = 10;
            this.btnXoa.Location = new System.Drawing.Point(173, 364);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(150, 55);
            this.btnXoa.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnThem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnThem.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThem.HoverImage = ((System.Drawing.Image)(resources.GetObject("btnThem.HoverImage")));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnThem.ImageTextSpacing = 10;
            this.btnThem.Location = new System.Drawing.Point(6, 364);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(150, 55);
            this.btnThem.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(158, 273);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(305, 27);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // cboMaSach
            // 
            this.cboMaSach.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboMaSach.FormattingEnabled = true;
            this.cboMaSach.Location = new System.Drawing.Point(158, 226);
            this.cboMaSach.Name = "cboMaSach";
            this.cboMaSach.Size = new System.Drawing.Size(305, 28);
            this.cboMaSach.TabIndex = 2;
            // 
            // cboMaNV
            // 
            this.cboMaNV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboMaNV.FormattingEnabled = true;
            this.cboMaNV.Location = new System.Drawing.Point(158, 179);
            this.cboMaNV.Name = "cboMaNV";
            this.cboMaNV.Size = new System.Drawing.Size(305, 28);
            this.cboMaNV.TabIndex = 2;
            // 
            // cboMaSV
            // 
            this.cboMaSV.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboMaSV.FormattingEnabled = true;
            this.cboMaSV.Location = new System.Drawing.Point(158, 133);
            this.cboMaSV.Name = "cboMaSV";
            this.cboMaSV.Size = new System.Drawing.Size(305, 28);
            this.cboMaSV.TabIndex = 2;
            // 
            // cboSoThe
            // 
            this.cboSoThe.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboSoThe.FormattingEnabled = true;
            this.cboSoThe.Location = new System.Drawing.Point(158, 85);
            this.cboSoThe.Name = "cboSoThe";
            this.cboSoThe.Size = new System.Drawing.Size(305, 28);
            this.cboSoThe.TabIndex = 2;
            // 
            // txtMaPNT
            // 
            this.txtMaPNT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtMaPNT.Location = new System.Drawing.Point(158, 44);
            this.txtMaPNT.Name = "txtMaPNT";
            this.txtMaPNT.Size = new System.Drawing.Size(305, 27);
            this.txtMaPNT.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 319);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Đơn Giá phạt:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày Lâp:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã Sách:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã SV:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã NV:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số Thẻ TV:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ma PNT:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(201, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(827, 46);
            this.label1.TabIndex = 15;
            this.label1.Text = "DANH MỤC LẬP PHIẾU NHẮC TRẢ SÁNH";
            // 
            // btnLoadX
            // 
            this.btnLoadX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLoadX.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnLoadX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLoadX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLoadX.HoverImage = global::QL_THUVIET_2021.Properties.Resources.tải_xuống__4_;
            this.btnLoadX.Image = global::QL_THUVIET_2021.Properties.Resources.load;
            this.btnLoadX.ImageFixedSize = new System.Drawing.Size(50, 50);
            this.btnLoadX.ImageTextSpacing = 10;
            this.btnLoadX.Location = new System.Drawing.Point(344, 436);
            this.btnLoadX.Name = "btnLoadX";
            this.btnLoadX.Size = new System.Drawing.Size(137, 55);
            this.btnLoadX.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnLoadX.TabIndex = 32;
            this.btnLoadX.Text = "Load";
            this.btnLoadX.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.btnLoadX.Click += new System.EventHandler(this.btnLoadX_Click);
            // 
            // UserPhieuNhacTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QL_THUVIET_2021.Properties.Resources.tải_xuống__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cboTImKiem);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserPhieuNhacTra";
            this.Size = new System.Drawing.Size(1220, 605);
            this.Load += new System.EventHandler(this.UserPhieuMuon_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhacTra)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.ComboBox cboTImKiem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btnXuat;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private DevComponents.DotNetBar.ButtonX btnSua;
        private DevComponents.DotNetBar.ButtonX btnXoa;
        private DevComponents.DotNetBar.ButtonX btnThem;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.ComboBox cboMaSach;
        private System.Windows.Forms.ComboBox cboMaNV;
        private System.Windows.Forms.ComboBox cboMaSV;
        private System.Windows.Forms.ComboBox cboSoThe;
        private System.Windows.Forms.TextBox txtMaPNT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiaPhat;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgvNhacTra;
        private DevComponents.DotNetBar.ButtonX btnLoadX;
    }
}
