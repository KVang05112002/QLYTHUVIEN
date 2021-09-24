
namespace QL_THUVIET_2021
{
    partial class RPSachMuon
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QLY_ThuVien_DHDataSet = new QL_THUVIET_2021.QLY_ThuVien_DHDataSet();
            this.MuonTraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MuonTraTableAdapter = new QL_THUVIET_2021.QLY_ThuVien_DHDataSetTableAdapters.MuonTraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QLY_ThuVien_DHDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MuonTraBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.MuonTraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QL_THUVIET_2021.RPSachMuon.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // QLY_ThuVien_DHDataSet
            // 
            this.QLY_ThuVien_DHDataSet.DataSetName = "QLY_ThuVien_DHDataSet";
            this.QLY_ThuVien_DHDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // MuonTraBindingSource
            // 
            this.MuonTraBindingSource.DataMember = "MuonTra";
            this.MuonTraBindingSource.DataSource = this.QLY_ThuVien_DHDataSet;
            // 
            // MuonTraTableAdapter
            // 
            this.MuonTraTableAdapter.ClearBeforeFill = true;
            // 
            // RPSachMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RPSachMuon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPSachMuon";
            this.Load += new System.EventHandler(this.RPSachMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QLY_ThuVien_DHDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MuonTraBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource MuonTraBindingSource;
        private QLY_ThuVien_DHDataSet QLY_ThuVien_DHDataSet;
        private QLY_ThuVien_DHDataSetTableAdapters.MuonTraTableAdapter MuonTraTableAdapter;
    }
}