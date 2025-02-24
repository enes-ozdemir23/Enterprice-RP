using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private void tileControl1_Click(object sender, EventArgs e)
        {

        }

        private void tileItem3_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            MessageBox.Show(".");
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void tileItem6_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmStokKayitlari frm = new FrmStokKayitlari();
            frm.Show();
        }

        private void tileItem10_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmMusteriKayitlari frm = new FrmMusteriKayitlari();
            frm.Show();
        }

        private void tileItem12_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmSiparisler frm = new FrmSiparisler();
            frm.Show();
        }

        private void tileItem14_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmIsEmri frm = new FrmIsEmri();
            frm.Show();
        }

        private void tileItem16_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmUretimSonuKayitlari frm = new FrmUretimSonuKayitlari();
            frm.Show();
        }

        private void tileItem4_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmStokHareketleri frm = new FrmStokHareketleri();
            frm.Show();
        }

        private void tileItem11_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmSiparisSevk frm = new FrmSiparisSevk();
            frm.Show();
        }

        private void tileItem13_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmGenelRapor frm = new FrmGenelRapor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tileItem15_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            FrmAyarlar frm = new FrmAyarlar();
            frm.Show();
        }
    }
}
