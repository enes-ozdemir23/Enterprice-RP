using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Erp
{
    public partial class FrmStokListesi : Form
    {
        public static string stokkodu; //global degisken
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmStokListesi()
        {
            InitializeComponent();
        }

        void arama()
        {
            conn.Open();

            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_STOKKAYITLARI WHERE STOK_KODU LIKE '%"+txtStokKodu.Text+
                "%' AND STOK_ADI LIKE '%"+txtStokAdi.Text+"%' AND GRUP_KODU LIKE '%"+txtGrupKodu.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt; // db'den alınan sonuçlar adabtörde saklandı ardından gridkontrole aktarıldı.
            conn.Close();
        }
        private void FrmStokListesi_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false; // gridte ki verilerin değiştirilememesi için kullandığım komut
            arama();
        }

        private void txtStokKodu_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtStokAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtGrupKodu_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow satir = gridView1.GetDataRow(gridView1.FocusedRowHandle); // tıklanan satırın bilgisi

            if(stokkodu=="kayit")
            {
                stokkodu = satir["STOK_KODU"].ToString();
                
                this.Hide();
                FrmStokKayitlari frm = new FrmStokKayitlari();
                frm.Activate();

            }
            if (stokkodu == "sipariskayit")
            {
                stokkodu = satir["STOK_KODU"].ToString();
                FrmSiparisler.siparisx = "stok";
                this.Hide();
                FrmSiparisler frm = new FrmSiparisler();
                frm.Activate();
            }
            if (stokkodu == "isemri")
            {
                stokkodu=satir["STOK_KODU"].ToString();
                FrmIsEmri.isemrix = "stok";
                this.Hide();
                FrmIsEmri frm = new FrmIsEmri();
                frm.Activate();
            }
            if (stokkodu == "stokhareket")
            {
                stokkodu = satir["STOK_KODU"].ToString();
                FrmStokHareketleri.stokhareketx = "stok";
                this.Hide();
                FrmStokHareketleri frm = new FrmStokHareketleri();
                frm.Activate();
                
            }
        }

        private void FrmStokListesi_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void FrmStokListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            stokkodu = ""; // "kayit" degerini alan global degisken  
        }
    }
}
