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
    public partial class FrmSiparisSevk : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");

        public FrmSiparisSevk()
        {
            InitializeComponent();
        }

        void musterilistesicekme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT MUSTERI_KODU,MUSTERI_ADI FROM TBL_MUSTERIKAYITLARI", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            searchLookUpEdit1.Properties.ValueMember = "MUSTERI_KODU"; //ARKA PLANDA TUTULACAK DEĞER
            searchLookUpEdit1.Properties.DisplayMember = "MUSTERI_ADI";//EKRANDA GÖZÜKECEK OLAN DEĞER
            searchLookUpEdit1.Properties.DataSource = dt;

            conn.Close();
        }

        void siparislistesicekme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            // seçilen değerin numarasını alıyoruz arkad planda.
            SqlCommand sorgu1 = new SqlCommand("SELECT SIPARIS_NO,TESLIM_TARIHI,TOPLAM_TUTAR FROM TBL_SIPARISLER WHERE SIPARIS_NO NOT IN (SELECT DISTINCT SIPARIS_NO FROM TBL_SIPARISKALEMLERI WHERE URETIMDURUMU='K' OR URETIMDURUMU='A' OR URETIMDURUMU='S') AND MUSTERI_KODU='"+searchLookUpEdit1.EditValue+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlSiparis.DataSource = dt;
            conn.Close();
        }

        private void FrmSiparisSevk_Load(object sender, EventArgs e)
        {
            searchLookUpEdit1.EditValue = "";
            musterilistesicekme();
            gViewSiparis.OptionsBehavior.Editable = false;
            gViewUrunler.OptionsBehavior.Editable = false;
        }

        private void sbtnSiparisRapor_Click(object sender, EventArgs e)
        {
            siparislistesicekme();
        }

        string z;
        private void gViewSiparis_Click(object sender, EventArgs e)
        {
            DataRow x = gViewSiparis.GetDataRow(gViewSiparis.FocusedRowHandle);
            z = x["SIPARIS_NO"].ToString();
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_KODU,STOK_ADI,MIKTAR,URUN_ACIKLAMASI,SIPKALEM_ID FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='"+z+"'",conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gControlUrunler.DataSource = dt;
            conn.Close();
        }

        private void sbtnSevkEmri_Click(object sender, EventArgs e)
        {
            // 5 tane siparis gelirse aşağıdaki gridview'e bunların sıpkalem_ıd değerini almamız gerekiyor. Aldıktan sonra her bir id değerinin bilgilerini
            // çekeceğiz. Böylelikle stok hareketlerini oluşturabileceğiz.
            string musterikodu = "";
            string stokkodu = "";
            string stokadi = "";
            string miktar = "";
            string musteriadi = "";
            int x =Convert.ToUInt16(gViewUrunler.RowCount.ToString());
            for(int i=0; i<=x-1; i++) // 5 satır varsa i=0,1,2,3,4 yani 5  satırı alır. her satırın bilgilerini sırayla alacak.
            {
                string kalemID = gViewUrunler.GetRowCellValue(i, "SIPKALEM_ID").ToString();  //döngüyle kalem id değerlerini alıyoruz.
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("SELECT S.MUSTERI_KODU, SK.STOK_KODU,SK.STOK_ADI,SK.MIKTAR,MK.MUSTERI_ADI FROM TBL_SIPARISKALEMLERI SK LEFT JOIN TBL_SIPARISLER S ON SK.SIPARIS_NO=S.SIPARIS_NO LEFT JOIN TBL_MUSTERIKAYITLARI MK ON S.MUSTERI_KODU=MK.MUSTERI_KODU WHERE SIPKALEM_ID='" + kalemID + "'", conn);
                SqlDataReader dr = sorgu1.ExecuteReader();
                while (dr.Read())
                {
                    //içerikleri çektiğimiz için her biri içinde stok hareketi oluşturmamız lazım.
                    musterikodu = dr[0].ToString();
                    stokkodu= dr[1].ToString();
                    stokadi= dr[2].ToString(); 
                    miktar= dr[3].ToString();
                    musteriadi= dr[4].ToString();

                }

                conn.Close();

                conn.Open();
                SqlCommand sorgu2 = new SqlCommand("INSERT INTO TBL_STOKHAREKETLERI(URETIMSONUKAYDI_NUMARASI,ISEMRI_NUMARASI,STOK_KODU,STOK_ADI,G_MIKTAR,C_MIKTAR,MUSTERI_ADI,ACIKLAMA) VALUES('" + musterikodu + "',' ','" + stokkodu + "','" + stokadi +"', '0','"+miktar.Replace(',','.') +"','"+musteriadi+"','SEVKIYAT')", conn);
                sorgu2.ExecuteNonQuery();
                conn.Close();

            }
            conn.Open();
            SqlCommand sorgu3 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='S' WHERE SIPARIS_NO='"+z+"'", conn);
            sorgu3.ExecuteNonQuery();
            conn.Close();
            siparislistesicekme();
            gControlUrunler.DataSource = "";
            MessageBox.Show(z);
        }
    }
}
