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
    public partial class FrmMusteriListesi : Form
    {
        public static string musterikodu;
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmMusteriListesi()
        {
            InitializeComponent();
        }

        void arama()
        {
            conn.Open();

            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT MUSTERI_KODU, MUSTERI_ADI, IL, ILCE FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU LIKE '%"+txtMusteriKodu.Text+"%' AND MUSTERI_ADI LIKE '%"+txtMusteriAdi.Text+"%' AND IL LIKE '%"+txtIl.Text+"%' AND ILCE LIKE '%"+txtIlce.Text+"%'" , conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt; // db'den alınan sonuçlar adabtörde saklandı ardından gridkontrole aktarıldı.
            conn.Close();
        }
        private void FrmMusteriListesi_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false; //listedeki verileri değiştirme işlemini kapatmış olduk.
            arama();
        }

        private void txtMusteriKodu_TextChanged(object sender, EventArgs e)
        {
            arama();

        }

        private void txtMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtIl_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtIlce_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            // sipariş kayıttan geldiysen sipariş kaydını aç, müşteri kayıttan geldiyse müşteri kayıtı aç.
            
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle); 
            if (musterikodu =="musterikayit")
            {
                musterikodu = x["MUSTERI_KODU"].ToString();
                this.Hide();
                FrmMusteriKayitlari frm = new FrmMusteriKayitlari();
                frm.Activate();
  
            }
            else
            {
                if (musterikodu == "sipariskayit")
                {
                    musterikodu = x["MUSTERI_KODU"].ToString();
                    FrmSiparisler.siparisx = "musteri";
                    this.Hide();
                    FrmSiparisler frm = new FrmSiparisler();
                    frm.Activate();

                }

            }
        }

        private void FrmMusteriListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            musterikodu = ""; // yani liste kapandığında musterikodundaki nereden geldiğini belirten değerde silinir
                              // double click yapıldıysa tıklanan veriler listeye yazılır.
        }
    }
}
