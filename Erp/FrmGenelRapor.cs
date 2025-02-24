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
    public partial class FrmGenelRapor : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");

        public FrmGenelRapor()
        {
            InitializeComponent();
        }

        void sevkehazirsiparislisteleme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT SIP.SIPARIS_NO AS 'SİPARİŞ NUMARASI',MK.MUSTERI_ADI AS'MÜŞTERİ ADI',SIP.TESLIM_TARIHI AS 'TESLİM TARİHİ',SIP.TOPLAM_TUTAR AS 'TOPLAM TUTAR'FROM TBL_SIPARISLER SIP LEFT JOIN TBL_MUSTERIKAYITLARI MK ON SIP.MUSTERI_KODU=MK.MUSTERI_KODU WHERE SIPARIS_NO NOT IN(SELECT DISTINCT SIPARIS_NO FROM TBL_SIPARISKALEMLERI WHERE URETIMDURUMU='K' OR URETIMDURUMU='S' OR URETIMDURUMU='A')", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlSiparisListesi.DataSource = dt;
            conn.Close();
        }
        void stokkontrolraporu()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_KODU AS 'STOK KODU',STOK_ADI AS 'STOK ADI',(SELECT ISNULL(SUM(MIKTAR),0) FROM TBL_SIPARISKALEMLERI SIP WHERE SIP.STOK_KODU=SK.STOK_KODU) AS 'SİPARİŞ MİKTARI',(SELECT ISNULL(SUM(MIKTAR),0) FROM TBL_ISEMRI MR WHERE MR.STOK_KODU=SK.STOK_KODU AND DURUM='Y') AS 'İŞ EMRİ MİKTARI',(SELECT ISNULL(SUM(G_MIKTAR)-SUM(C_MIKTAR),0) FROM TBL_STOKHAREKETLERI SH WHERE SH.STOK_KODU=SK.STOK_KODU) AS 'STOK MİKTARI' FROM TBL_STOKKAYITLARI SK", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlStokKontrol.DataSource = dt;
            conn.Close();

        }

        private void FrmGenelRapor_Load(object sender, EventArgs e)
        {
            gViewIsEmirleri.OptionsBehavior.Editable = false;
            gViewMusteriCiro.OptionsBehavior.Editable = false;
            gViewSatisRaporu.OptionsBehavior.Editable = false;
            gViewSiparisListesi.OptionsBehavior.Editable = false;
            gViewStokKontrol.OptionsBehavior.Editable = false;
            sevkehazirsiparislisteleme();
            stokkontrolraporu();
            eksikisemirleri();
            stoksatisraporu();
            musterisatisraporu();

        }

        void eksikisemirleri()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_KODU AS 'STOK_KODU',STOK_ADI AS 'STOK_ADI',MIKTAR AS 'MIKTAR',SIPKALEM_ID AS 'SİPARİŞ KALEM_ID' FROM TBL_SIPARISKALEMLERI WHERE URETIMDURUMU = 'K'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlIsEmirleri.DataSource = dt;
            conn.Close();
            
                
        }
        void stoksatisraporu()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 25 STOK_ADI,SUM(MIKTAR) AS 'TOPLAM SATIŞ MİKTARI' FROM TBL_SIPARISKALEMLERI GROUP BY STOK_ADI ORDER BY SUM(MIKTAR) DESC", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlSatisRaporu.DataSource = dt;
            conn.Close();
        }
        void musterisatisraporu()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 10 MUSTERI_ADI AS 'MÜŞTERİ ADI', SUM(TOPLAM_TUTAR) AS 'TOPLAM CİRO' FROM TBL_SIPARISLER SIP LEFT JOIN TBL_MUSTERIKAYITLARI MK ON SIP.MUSTERI_KODU=MK.MUSTERI_KODU GROUP BY MUSTERI_ADI ORDER BY SUM(TOPLAM_TUTAR) DESC", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlMusteriCiro.DataSource = dt;
            conn.Close();

        }

        private void gControlStokKontrol_Click(object sender, EventArgs e)
        {

        }
    }
}
