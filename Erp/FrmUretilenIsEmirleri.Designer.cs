namespace Erp
{
    partial class FrmUretilenIsEmirleri
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
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUretilenIsEmirleri));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sqlDataSource2 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colISEMRI_NUMARASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTOK_KODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTOK_ADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISEMRI_ACIKLAMASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colİŞEMRİTARİHİ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTESLİMTARİHİ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIPARIS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMIKTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIPKALEM_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "Query";
            this.gridControl1.DataSource = this.sqlDataSource2;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1498, 736);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sqlDataSource2
            // 
            this.sqlDataSource2.ConnectionName = "localhost_ERP_EGITIM_Connection 1";
            this.sqlDataSource2.Name = "sqlDataSource2";
            customSqlQuery2.Name = "Query";
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            this.sqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.sqlDataSource2.ResultSchemaSerializable = resources.GetString("sqlDataSource2.ResultSchemaSerializable");
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colISEMRI_NUMARASI,
            this.colSTOK_KODU,
            this.colSTOK_ADI,
            this.colISEMRI_ACIKLAMASI,
            this.colİŞEMRİTARİHİ,
            this.colTESLİMTARİHİ,
            this.colSIPARIS_NO,
            this.colMIKTAR,
            this.colSIPKALEM_ID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colISEMRI_NUMARASI
            // 
            this.colISEMRI_NUMARASI.Caption = "İş Emri Numarası";
            this.colISEMRI_NUMARASI.FieldName = "ISEMRI_NUMARASI";
            this.colISEMRI_NUMARASI.Name = "colISEMRI_NUMARASI";
            this.colISEMRI_NUMARASI.Visible = true;
            this.colISEMRI_NUMARASI.VisibleIndex = 0;
            // 
            // colSTOK_KODU
            // 
            this.colSTOK_KODU.Caption = "Stok Kodu";
            this.colSTOK_KODU.FieldName = "STOK_KODU";
            this.colSTOK_KODU.Name = "colSTOK_KODU";
            this.colSTOK_KODU.Visible = true;
            this.colSTOK_KODU.VisibleIndex = 1;
            // 
            // colSTOK_ADI
            // 
            this.colSTOK_ADI.Caption = "Stok Adı";
            this.colSTOK_ADI.FieldName = "STOK_ADI";
            this.colSTOK_ADI.Name = "colSTOK_ADI";
            this.colSTOK_ADI.Visible = true;
            this.colSTOK_ADI.VisibleIndex = 2;
            // 
            // colISEMRI_ACIKLAMASI
            // 
            this.colISEMRI_ACIKLAMASI.CustomizationCaption = "İş Emri Açıklaması";
            this.colISEMRI_ACIKLAMASI.FieldName = "ISEMRI_ACIKLAMASI";
            this.colISEMRI_ACIKLAMASI.Name = "colISEMRI_ACIKLAMASI";
            this.colISEMRI_ACIKLAMASI.Visible = true;
            this.colISEMRI_ACIKLAMASI.VisibleIndex = 3;
            // 
            // colİŞEMRİTARİHİ
            // 
            this.colİŞEMRİTARİHİ.CustomizationCaption = "İşlem Tarihi";
            this.colİŞEMRİTARİHİ.FieldName = "İŞ EMRİ TARİHİ";
            this.colİŞEMRİTARİHİ.Name = "colİŞEMRİTARİHİ";
            this.colİŞEMRİTARİHİ.Visible = true;
            this.colİŞEMRİTARİHİ.VisibleIndex = 4;
            // 
            // colTESLİMTARİHİ
            // 
            this.colTESLİMTARİHİ.CustomizationCaption = "Teslim Tarihi";
            this.colTESLİMTARİHİ.FieldName = "TESLİM TARİHİ";
            this.colTESLİMTARİHİ.Name = "colTESLİMTARİHİ";
            this.colTESLİMTARİHİ.Visible = true;
            this.colTESLİMTARİHİ.VisibleIndex = 5;
            // 
            // colSIPARIS_NO
            // 
            this.colSIPARIS_NO.Caption = "Sipariş No";
            this.colSIPARIS_NO.FieldName = "SIPARIS_NO";
            this.colSIPARIS_NO.Name = "colSIPARIS_NO";
            this.colSIPARIS_NO.Visible = true;
            this.colSIPARIS_NO.VisibleIndex = 6;
            // 
            // colMIKTAR
            // 
            this.colMIKTAR.Caption = "Miktar";
            this.colMIKTAR.FieldName = "MIKTAR";
            this.colMIKTAR.Name = "colMIKTAR";
            this.colMIKTAR.Visible = true;
            this.colMIKTAR.VisibleIndex = 7;
            // 
            // colSIPKALEM_ID
            // 
            this.colSIPKALEM_ID.Caption = "Sipariş ID";
            this.colSIPKALEM_ID.FieldName = "SIPKALEM_ID";
            this.colSIPKALEM_ID.Name = "colSIPKALEM_ID";
            this.colSIPKALEM_ID.Visible = true;
            this.colSIPKALEM_ID.VisibleIndex = 8;
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.Name = "sqlDataSource1";
            // 
            // FrmUretilenIsEmirleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1498, 736);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmUretilenIsEmirleri";
            this.Text = "Üretilen İş Emirleri";
            this.Load += new System.EventHandler(this.FrmUretilenIsEmirleri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource2;
        private DevExpress.XtraGrid.Columns.GridColumn colISEMRI_NUMARASI;
        private DevExpress.XtraGrid.Columns.GridColumn colSTOK_KODU;
        private DevExpress.XtraGrid.Columns.GridColumn colSTOK_ADI;
        private DevExpress.XtraGrid.Columns.GridColumn colISEMRI_ACIKLAMASI;
        private DevExpress.XtraGrid.Columns.GridColumn colİŞEMRİTARİHİ;
        private DevExpress.XtraGrid.Columns.GridColumn colTESLİMTARİHİ;
        private DevExpress.XtraGrid.Columns.GridColumn colSIPARIS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colMIKTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSIPKALEM_ID;
    }
}