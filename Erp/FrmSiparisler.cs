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
    public partial class FrmSiparisler : Form
    {
        public static string siparisx;
        string sipkalem = "";
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmSiparisler()
        {
            InitializeComponent();
        }
        string x1 = "0";
        void sipariskontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_SIPARISLER WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                x1 = dr1[0].ToString();              
            }
            conn.Close();
        }
        void siparisbilgisicekme1()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_SIPARISLER WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"'", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                txtMusteriKodu.Text = dr1[1].ToString();
                txtSiparisTarihi.Text = dr1[2].ToString();
                txtTeslimTarihi.Text= dr1[3].ToString();
                txtToplamTutar.Text= dr1[4].ToString();
            }
            conn.Close();

        }

        void siparisbilgisicekme2()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_KODU,STOK_ADI,MIKTAR,FIYAT,KDV,SIPKALEM_ID FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();

        }
        string x2 = "0";
        void musterikontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='" + txtMusteriKodu.Text + "'", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                x2 = dr1[0].ToString();

                

            }
            conn.Close();

        }
        void musteribilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT MUSTERI_ADI,IL,ILCE FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='"+txtMusteriKodu.Text+"'", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                txtMusteriAdi.Text = dr1[0].ToString();
                txtIl.Text = dr1[1].ToString();
                txtIlce.Text = dr1[2].ToString();
            }
            conn.Close();

        }
        string x3 = "0";
        void stokkontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                x3 = dr1[0].ToString();

            }
            conn.Close();

        }

        void stokbilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_ADI,FIYAT,KDV_ORANI FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                txtStokAdi.Text = dr1[0].ToString();
                txtFiyat.Text = dr1[1].ToString();
                txtKDV.Text = dr1[2].ToString();
            }
            conn.Close();

        }

        void geneltoplamhesaplama()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT SUM((MIKTAR*FIYAT)*((KDV/100)+1)) FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text+"' GROUP BY SIPARIS_NO", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                txtToplamTutar.Text = dr1[0].ToString();
            }
            conn.Close();
        }

        string x4 = "0";
        void kalemsayma() // kalem olup olmadığını kontrol ediyoruz.
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"'", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                x4 = dr1[0].ToString();
            }
            conn.Close();

        }
        void temizle1()
        {
            txtStokKodu.Text = "";
            txtStokAdi.Text = "";
            txtUrunAciklamasi.Text = "";
            txtFiyat.Text = "";
            txtKDV.Text = "";
            txtMiktar.Text = "";

        }

        void temizle2()
        {
            txtSiparisTarihi.Text = "";
            txtTeslimTarihi.Text = "";
            txtMusteriKodu.Text = "";
            txtMusteriAdi.Text = "";
            txtIl.Text = "";
            txtIlce.Text = "";
            txtToplamTutar.Text = "";
            temizle1();

        }
        string x6 = "0";
        void sipgenelisemrikontrol() // uretım durumu k olmayan bir siparisin silinmesini engellemek için bu metodu yazdık.
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"' AND (URETIMDURUMU='A' OR URETIMDURUMU='B' OR URETIMDURUMU='S')", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                x6 = dr1[0].ToString();
            }
            conn.Close();
        }

        string x5 = "0";
        void sipkalemisemrikontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT URETIMDURUMU FROM TBL_SIPARISKALEMLERI WHERE SIPKALEM_ID='"+sipkalem+"'", conn);
            SqlDataReader dr1 = sorgu1.ExecuteReader();
            while (dr1.Read())
            {
                x5 = dr1[0].ToString();
            }
            conn.Close();

        }
        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            FrmSiparisListesi.siparisno = "sipariskayit"; //
            FrmSiparisListesi frm = new FrmSiparisListesi();
            frm.Show();
        }


        private void textEdit5_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void FrmSiparisler_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            txtStokAdi.Enabled = false;
            txtKDV.Enabled = false;
            txtFiyat.Enabled = false;
            txtUrunAciklamasi.Enabled = false;
            txtMiktar.Enabled = false;
        }

        private void txtSiparisNumarasi_Leave(object sender, EventArgs e)
        {
            txtMusteriAdi.Enabled = false;
            txtIl.Enabled = false;
            txtIlce.Enabled = false;
            txtStokKodu.Enabled = true;

            sipariskontrol();
            if (Convert.ToInt16(x1)==1) // String ifadelerin kontrolü daha zor olduğu için integer dönüşümü yapıyoruz.
            {
                siparisbilgisicekme1();  // kayıt varsa bilgileri çeker.
                siparisbilgisicekme2();
                musteribilgisicekme();
                txtMusteriKodu.Enabled = false; // Bu alan Kapatıldı

            }
            else
            {
                if (txtSiparisNumarasi.Text == "") // satırda boşluk yoksa o satırdan ayrılmaz ta ki birşey yazılana dek
                {
                    txtSiparisNumarasi.Focus();
                }
                else
                {
                    siparisbilgisicekme2();
                    temizle2(); // bir önceki kayıttan kalan bir şey varsa silmesi için yazdık
                    txtMusteriKodu.Enabled = true;

                }
            }
        }

        private void txtMusteriKodu_Leave(object sender, EventArgs e)
        {
            musterikontrol();
            if(Convert.ToInt16(x2) == 1)
            {
                musteribilgisicekme();
            }
            else
            {
                txtMusteriKodu.Focus();
            }
        }

        private void txtStokKodu_Leave(object sender, EventArgs e)
        {
            stokkontrol();
            if (Convert.ToInt16(x3) == 1)
            {
                stokbilgisicekme();
                txtUrunAciklamasi.Enabled = true;
                txtMiktar.Enabled = true;
                txtFiyat.Enabled = true;
                txtKDV.Enabled = true;
                txtMiktar.Text = "0,00";

            }
            else
            {
                txtStokKodu.Focus();
            }
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {       
            
            if (sipkalem == "")  
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_SIPARISKALEMLERI (SIPARIS_NO,STOK_KODU,STOK_ADI,MIKTAR,URUN_ACIKLAMASI,FIYAT,KDV,URETIMDURUMU) VALUES ('"+txtSiparisNumarasi.Text+"','"+txtStokKodu.Text+"','"+txtStokAdi.Text+"','"+txtMiktar.Text.Replace(',','.')+"','"+txtUrunAciklamasi.Text+"','"+txtFiyat.Text.Replace(',','.')+"','"+txtKDV.Text.Replace(',', '.') + "','K')", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle1();
                siparisbilgisicekme2();
                geneltoplamhesaplama();
            }
            else
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET MIKTAR='"+txtMiktar.Text.Replace(',','.')+"',URUN_ACIKLAMASI='"+txtUrunAciklamasi.Text+"',FIYAT='"+txtFiyat.Text.Replace(',','.') + "',KDV='"+txtKDV.Text.Replace(',','.') + "' WHERE SIPKALEM_ID='" + sipkalem + "'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle1();
                siparisbilgisicekme2();
                geneltoplamhesaplama();
            }
            sipariskontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISLER SET SIPARIS_TARIHI='" + txtSiparisTarihi.Text + "',TESLIM_TARIHI='" + txtTeslimTarihi.Text + "',TOPLAM_TUTAR='" + txtToplamTutar.Text.Replace(',', '.') + "' WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_SIPARISLER(SIPARIS_NO,MUSTERI_KODU,SIPARIS_TARIHI,TESLIM_TARIHI,TOPLAM_TUTAR) VALUES('" + txtSiparisNumarasi.Text + "','" + txtMusteriKodu.Text + "','" + txtSiparisTarihi.Text + "','" + txtTeslimTarihi.Text + "','" + txtToplamTutar.Text.Replace(',', '.') + "')", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
            }
            // Kaydet butonuna basıldığında 2 şey yapılabilir. 1) Yeni veri ekleme  2) Güncelleme 
            // sipkalem  doubleclick yapıldığında değişiyordu. yani veriler alttan üst kısma taşınmış demektir
            // kaydet butonu siparisler ve sipariskalemleri tablosunu etkiler.
            // ÜSTTEKİ İF-ELSE KALEMLERİ ALTTAKİ İF ELSE SİPARİŞLERİ ETKİLER.

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtStokKodu.Text = x["STOK_KODU"].ToString();
            txtStokAdi.Text = x["STOK_ADI"].ToString();
            txtFiyat.Text = x["FIYAT"].ToString();
            txtMiktar.Text = x["MIKTAR"].ToString();
            txtKDV.Text = x["KDV"].ToString();
            sipkalem = x["SIPKALEM_ID"].ToString();
            txtStokKodu.Enabled = false;
            txtMiktar.Enabled = true;
            txtFiyat.Enabled = true;
            txtKDV.Enabled = true;
            txtUrunAciklamasi.Enabled = true;
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtTeslimTarihi.Text);
        }

        private void sbtnSil_Click(object sender, EventArgs e) // kalemlerin silme fonksiyonu
        {
            sipkalemisemrikontrol(); // üretim durumu A (AÇIK) B (BİTMİŞ) S (SEVK EDİLMİŞ)  K (KAPALI) Kontrolü yapılır.
            if (x5 == "K")
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("DELETE TBL_SIPARISKALEMLERI WHERE SIPKALEM_ID='" + sipkalem + "'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle1();
                siparisbilgisicekme2();
                sipkalem = ""; // çünkü artık böyle bir id değerine sahip bir kalem yok silindi yani. Genel toplamı tekrar hesaplamalıyız.
                txtStokKodu.Enabled = true;
                kalemsayma();
                if (Convert.ToInt16(x4)==0)
                {
                    txtToplamTutar.Text = "0,00";

                }
                else
                {
                    geneltoplamhesaplama();
                }
                conn.Open();
                SqlCommand sorgu2 = new SqlCommand("UPDATE TBL_SIPARISLER SET SIPARIS_TARIHI='" + txtSiparisTarihi.Text + "',TESLIM_TARIHI='" + txtTeslimTarihi.Text + "',TOPLAM_TUTAR='" + txtToplamTutar.Text.Replace(',', '.') + "' WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
                sorgu2.ExecuteNonQuery();
                conn.Close();


            }
            else
            {
                MessageBox.Show("bu sipariş kalmeine ait iş emri bulunmaktadır.");
            }  
        }

        private void sbtnSiparisSil_Click(object sender, EventArgs e)
        {
            sipgenelisemrikontrol(); // uretim durumları A B S olanları topluyor. Buda demektir ki bir iş emri kaydı vardır. sıfırsa yoktur ve silinebilir.
            if (Convert.ToInt16(x6) ==0)
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("DELETE TBL_SIPARISLER WHERE SIPARIS_NO='"+txtSiparisNumarasi.Text+"'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();

                conn.Open();
                SqlCommand sorgu2 = new SqlCommand("DELETE TBL_SIPARISKALEMLERI WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
                sorgu2.ExecuteNonQuery();
                conn.Close();
                temizle2();
                txtSiparisNumarasi.Text = "";
                siparisbilgisicekme2();
            }
            else
            {
                MessageBox.Show("Siparişe ait iş emri vardır.");
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            sipariskontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISLER SET SIPARIS_TARIHI='" + txtSiparisTarihi.Text + "',TESLIM_TARIHI='" + txtTeslimTarihi.Text + "',TOPLAM_TUTAR='" + txtToplamTutar.Text.Replace(',', '.') + "' WHERE SIPARIS_NO='" + txtSiparisNumarasi.Text + "'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_SIPARISLER(SIPARIS_NO,MUSTERI_KODU,SIPARIS_TARIHI,TESLIM_TARIHI,TOPLAM_TUTAR) VALUES('" + txtSiparisNumarasi.Text + "','" + txtMusteriKodu.Text + "','" + txtSiparisTarihi.Text + "','" + txtTeslimTarihi.Text + "','" + txtToplamTutar.Text.Replace(',', '.') + "')", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
            }

            siparisbilgisicekme1();
            temizle2();
            txtSiparisNumarasi.Text = "";
            siparisbilgisicekme2();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmMusteriListesi.musterikodu = "sipariskayit"; // gelinen yeri belirtmek için kullanıyoruz.
            FrmMusteriListesi frm = new FrmMusteriListesi();
            frm.Show();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmStokListesi.stokkodu = "sipariskayit";
            FrmStokListesi frm = new FrmStokListesi();
            frm.Show();
        }

        private void FrmSiparisler_Activated(object sender, EventArgs e)
        {
            if (siparisx == "siparis")
            {
                if (FrmSiparisListesi.siparisno == "") // form manuel olarak kapatılmışsa birşey yapılmaz. doubleclik ile kapatılmışsa verileri çeker
                {

                }
                else
                {
                    txtSiparisNumarasi.Text = FrmSiparisListesi.siparisno;
                    siparisbilgisicekme1();
                    siparisbilgisicekme2();
                    musteribilgisicekme();

                }
            }

            if (siparisx == "musteri")
            {
                if (FrmMusteriListesi.musterikodu == "")
                {

                }
                else
                {
                    txtMusteriKodu.Text = FrmMusteriListesi.musterikodu;
                    musteribilgisicekme();
                }

            }
            if (siparisx == "stok")
            {
                if (FrmStokListesi.stokkodu == "")
                {

                }
                else
                {
                    txtStokKodu.Text = FrmStokListesi.stokkodu;
                    stokbilgisicekme();
                }
            }
          
            
            
        }

        private void FrmSiparisler_FormClosed(object sender, FormClosedEventArgs e)
        {
            // nereden geldiğimizi ve nereye gideceğimizi  belirten parametreleri sıfırlıyoruz ki hata vermesin
            siparisx = "";
            FrmMusteriListesi.musterikodu = "";
            FrmSiparisListesi.siparisno = "";
        }
    }
}
