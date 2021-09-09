
namespace QL_THUVIET_2021
{
    partial class UserNoiQuy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserNoiQuy));
            this.label1 = new System.Windows.Forms.Label();
            this.txtnoiquy = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(378, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "NỘI QUY THƯ VIỆN";
            // 
            // txtnoiquy
            // 
            this.txtnoiquy.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtnoiquy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnoiquy.Location = new System.Drawing.Point(20, 101);
            this.txtnoiquy.Margin = new System.Windows.Forms.Padding(4);
            this.txtnoiquy.Multiline = true;
            this.txtnoiquy.Name = "txtnoiquy";
            this.txtnoiquy.Size = new System.Drawing.Size(1149, 476);
            this.txtnoiquy.TabIndex = 2;
            this.txtnoiquy.Text = resources.GetString("txtnoiquy.Text");
            // 
            // UserNoiQuy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::QL_THUVIET_2021.Properties.Resources.tải_xuống__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.txtnoiquy);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UserNoiQuy";
            this.Size = new System.Drawing.Size(1187, 594);
            this.Load += new System.EventHandler(this.UserNoiQuy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnoiquy;
    }
}
