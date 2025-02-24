namespace Erp
{
    partial class FrmGenelRapor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGenelRapor));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gControlStokKontrol = new DevExpress.XtraGrid.GridControl();
            this.gViewStokKontrol = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gControlSiparisListesi = new DevExpress.XtraGrid.GridControl();
            this.gViewSiparisListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gControlMusteriCiro = new DevExpress.XtraGrid.GridControl();
            this.gViewMusteriCiro = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.gControlSatisRaporu = new DevExpress.XtraGrid.GridControl();
            this.gViewSatisRaporu = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.gControlIsEmirleri = new DevExpress.XtraGrid.GridControl();
            this.gViewIsEmirleri = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gControlStokKontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewStokKontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gControlSiparisListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewSiparisListesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gControlMusteriCiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewMusteriCiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gControlSatisRaporu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewSatisRaporu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gControlIsEmirleri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewIsEmirleri)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl1.CaptionImageOptions.Image")));
            this.groupControl1.Controls.Add(this.gControlStokKontrol);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1190, 351);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Stok Raporu";
            // 
            // gControlStokKontrol
            // 
            this.gControlStokKontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gControlStokKontrol.Location = new System.Drawing.Point(2, 23);
            this.gControlStokKontrol.MainView = this.gViewStokKontrol;
            this.gControlStokKontrol.Name = "gControlStokKontrol";
            this.gControlStokKontrol.Size = new System.Drawing.Size(1186, 326);
            this.gControlStokKontrol.TabIndex = 0;
            this.gControlStokKontrol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gViewStokKontrol});
            this.gControlStokKontrol.Click += new System.EventHandler(this.gControlStokKontrol_Click);
            // 
            // gViewStokKontrol
            // 
            this.gViewStokKontrol.GridControl = this.gControlStokKontrol;
            this.gViewStokKontrol.Name = "gViewStokKontrol";
            this.gViewStokKontrol.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl2
            // 
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.gControlSiparisListesi);
            this.groupControl2.Location = new System.Drawing.Point(1208, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(700, 351);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Sevke Hazır Siparişler";
            // 
            // gControlSiparisListesi
            // 
            this.gControlSiparisListesi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gControlSiparisListesi.Location = new System.Drawing.Point(2, 23);
            this.gControlSiparisListesi.MainView = this.gViewSiparisListesi;
            this.gControlSiparisListesi.Name = "gControlSiparisListesi";
            this.gControlSiparisListesi.Size = new System.Drawing.Size(696, 326);
            this.gControlSiparisListesi.TabIndex = 0;
            this.gControlSiparisListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gViewSiparisListesi});
            // 
            // gViewSiparisListesi
            // 
            this.gViewSiparisListesi.GridControl = this.gControlSiparisListesi;
            this.gViewSiparisListesi.Name = "gViewSiparisListesi";
            this.gViewSiparisListesi.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl3
            // 
            this.groupControl3.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl3.CaptionImageOptions.Image")));
            this.groupControl3.Controls.Add(this.gControlMusteriCiro);
            this.groupControl3.Location = new System.Drawing.Point(12, 369);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(589, 405);
            this.groupControl3.TabIndex = 2;
            this.groupControl3.Text = "Müşteri Kar Raporu";
            // 
            // gControlMusteriCiro
            // 
            this.gControlMusteriCiro.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gControlMusteriCiro.Location = new System.Drawing.Point(2, 23);
            this.gControlMusteriCiro.MainView = this.gViewMusteriCiro;
            this.gControlMusteriCiro.Name = "gControlMusteriCiro";
            this.gControlMusteriCiro.Size = new System.Drawing.Size(585, 380);
            this.gControlMusteriCiro.TabIndex = 0;
            this.gControlMusteriCiro.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gViewMusteriCiro});
            // 
            // gViewMusteriCiro
            // 
            this.gViewMusteriCiro.GridControl = this.gControlMusteriCiro;
            this.gViewMusteriCiro.Name = "gViewMusteriCiro";
            this.gViewMusteriCiro.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl4
            // 
            this.groupControl4.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl4.CaptionImageOptions.Image")));
            this.groupControl4.Controls.Add(this.gControlSatisRaporu);
            this.groupControl4.Location = new System.Drawing.Point(607, 369);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(595, 405);
            this.groupControl4.TabIndex = 3;
            this.groupControl4.Text = "Ürün Satış Raporu";
            // 
            // gControlSatisRaporu
            // 
            this.gControlSatisRaporu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gControlSatisRaporu.Location = new System.Drawing.Point(2, 23);
            this.gControlSatisRaporu.MainView = this.gViewSatisRaporu;
            this.gControlSatisRaporu.Name = "gControlSatisRaporu";
            this.gControlSatisRaporu.Size = new System.Drawing.Size(591, 380);
            this.gControlSatisRaporu.TabIndex = 0;
            this.gControlSatisRaporu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gViewSatisRaporu});
            // 
            // gViewSatisRaporu
            // 
            this.gViewSatisRaporu.GridControl = this.gControlSatisRaporu;
            this.gViewSatisRaporu.Name = "gViewSatisRaporu";
            this.gViewSatisRaporu.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl5
            // 
            this.groupControl5.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl5.CaptionImageOptions.Image")));
            this.groupControl5.Controls.Add(this.gControlIsEmirleri);
            this.groupControl5.Location = new System.Drawing.Point(1208, 369);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(700, 405);
            this.groupControl5.TabIndex = 4;
            this.groupControl5.Text = "İş Emri Bekleyen Siparişler";
            // 
            // gControlIsEmirleri
            // 
            this.gControlIsEmirleri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gControlIsEmirleri.Location = new System.Drawing.Point(2, 23);
            this.gControlIsEmirleri.MainView = this.gViewIsEmirleri;
            this.gControlIsEmirleri.Name = "gControlIsEmirleri";
            this.gControlIsEmirleri.Size = new System.Drawing.Size(696, 380);
            this.gControlIsEmirleri.TabIndex = 0;
            this.gControlIsEmirleri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gViewIsEmirleri});
            // 
            // gViewIsEmirleri
            // 
            this.gViewIsEmirleri.GridControl = this.gControlIsEmirleri;
            this.gViewIsEmirleri.Name = "gViewIsEmirleri";
            this.gViewIsEmirleri.OptionsView.ShowGroupPanel = false;
            // 
            // FrmGenelRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1834, 811);
            this.Controls.Add(this.groupControl5);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmGenelRapor";
            this.Text = "Genel Rapor";
            this.Load += new System.EventHandler(this.FrmGenelRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gControlStokKontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewStokKontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gControlSiparisListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewSiparisListesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gControlMusteriCiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewMusteriCiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gControlSatisRaporu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewSatisRaporu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gControlIsEmirleri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gViewIsEmirleri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gControlStokKontrol;
        private DevExpress.XtraGrid.Views.Grid.GridView gViewStokKontrol;
        private DevExpress.XtraGrid.GridControl gControlSiparisListesi;
        private DevExpress.XtraGrid.Views.Grid.GridView gViewSiparisListesi;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gControlMusteriCiro;
        private DevExpress.XtraGrid.Views.Grid.GridView gViewMusteriCiro;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl gControlSatisRaporu;
        private DevExpress.XtraGrid.Views.Grid.GridView gViewSatisRaporu;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraGrid.GridControl gControlIsEmirleri;
        private DevExpress.XtraGrid.Views.Grid.GridView gViewIsEmirleri;
    }
}