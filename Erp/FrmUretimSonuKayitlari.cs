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
    public partial class FrmUretimSonuKayitlari : Form
    {
        public static string fisx = ""; 
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmUretimSonuKayitlari()
        {
            InitializeComponent();
        }

        string x1 = "0";
        void uretimsonukaydikontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_URETIMSONUKAYITLARI WHERE URETIMSONUKAYDI_NUMARASI='" + txtFisNo.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString();
            }
            conn.Close();

        }
        void uretimsonukaydıbilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISEMRI_NUMARASI FROM TBL_URETIMSONUKAYITLARI WHERE URETIMSONUKAYDI_NUMARASI='"+txtFisNo.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtIsEmriNumarasi.Text = dr[0].ToString();
            }
            conn.Close();
            txtIsEmriNumarasi.Enabled = false;
            sbtntIsEmriListesi.Enabled = false;
        }
        string x2 = "";
        void isemrikontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x2 = dr[0].ToString();

            }
            conn.Close();
        }

        void isemribilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT MR.SIPARIS_NO,MR.STOK_KODU,MR.STOK_ADI,MR.SIPKALEM_ID,MR.MIKTAR,SIP.MUSTERI_KODU,MK.MUSTERI_ADI FROM  TBL_ISEMRI MR LEFT JOIN TBL_SIPARISLER SIP ON MR.SIPARIS_NO=SIP.SIPARIS_NO LEFT JOIN TBL_MUSTERIKAYITLARI MK ON SIP.MUSTERI_KODU=MK.MUSTERI_KODU WHERE MR.ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtSiparisNumarasi.Text = dr[0].ToString();
                txtStokKodu.Text= dr[1].ToString();
                txtStokAdi.Text= dr[2].ToString();  
                txtKalemID.Text= dr[3].ToString();
                txtMiktar.Text= dr[4].ToString();
                txtMusteriKodu.Text= dr[5].ToString();
                txtMusteriAdi.Text= dr[6].ToString();
            }
            conn.Close();
        }

        void stoguuretimealma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='A' WHERE SIPKALEM_ID='" + txtKalemID.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();

        }
        void stogusevkehazirlama()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='B' WHERE SIPKALEM_ID='" + txtKalemID.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();

        }
        void isemriniacma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_ISEMRI SET DURUM='Y' WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();

        }

        void isemrinikapatma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_ISEMRI SET DURUM='E' WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();

        }


        private void sbtnFisListesi_Click(object sender, EventArgs e)
        {
            FrmUretimSonuKayitListesi.fisno = "uretimsonukaydi";
            FrmUretimSonuKayitListesi frm = new FrmUretimSonuKayitListesi();
            frm.Show();

        }
        void temizle()
        {
            txtIsEmriNumarasi.Text = "";
            txtKalemID.Text = "";
            txtMiktar.Text = "";
            txtMusteriAdi.Text = "";
            txtMusteriKodu.Text = "";
            txtSiparisNumarasi.Text = "";
            txtStokAdi.Text = "";
            txtStokKodu.Text = "";
            txtIsEmriNumarasi.Enabled = true;
            sbtntIsEmriListesi.Enabled = true;

        }
        // DİKKAT EDİLİRSE G MIKTAR 0 YAPILDI, AÇIKLAMA ÜRETİM YAPILDI
        void stokhareketkaydigirisi()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_STOKHAREKETLERI(URETIMSONUKAYDI_NUMARASI,ISEMRI_NUMARASI,STOK_KODU,STOK_ADI,G_MIKTAR,C_MIKTAR,MUSTERI_ADI,ACIKLAMA) VALUES('" + txtFisNo.Text + "','" + txtIsEmriNumarasi.Text + "','" + txtStokKodu.Text + "','" + txtStokAdi.Text + "','" + txtMiktar.Text.Replace(',', '.') + "','0','" + txtMusteriAdi.Text + "','ÜRETİM')", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
            
        }
        void stokhareketkaydisilme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("DELETE TBL_STOKHAREKETLERI WHERE URETIMSONUKAYDI_NUMARASI='"+txtFisNo.Text+"'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        private void txtIsEmriNumarasi_Leave(object sender, EventArgs e)
        {
            if (txtIsEmriNumarasi.Text == "")
            {
                txtIsEmriNumarasi.Focus();
            }
            else
            {
                isemrikontrol();
                if (Convert.ToInt16(x2) == 1)
                {
                    isemribilgisicekme();
                }
                else
                {
                    MessageBox.Show("iş emri num. bulunmamaktadır.");
                    txtIsEmriNumarasi.Focus();

                }
            }

        }

        private void txtFisNo_Leave(object sender, EventArgs e)
        {
            if (txtFisNo.Text == "")
            {
                txtFisNo.Focus();
            }
            else
            {
                uretimsonukaydikontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    uretimsonukaydıbilgisicekme();
                    isemribilgisicekme();
                }
                else
                {
                    temizle();
                    txtIsEmriNumarasi.Enabled = true;
                    sbtntIsEmriListesi.Enabled = true;
                }

            }
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            if (txtFisNo.Text == "" || txtIsEmriNumarasi.Text == "")
            {
                MessageBox.Show("lütfen gerekli olan bilgileri doldurunuz.");
            }
            else
            {
                uretimsonukaydikontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    MessageBox.Show("mevcut üreitim sonu kaydı sistemde bulunmaktadır.");
                }
                else
                {
                    stokhareketkaydigirisi();
                    stogusevkehazirlama();
                    isemrinikapatma();
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_URETIMSONUKAYITLARI(URETIMSONUKAYDI_NUMARASI,ISEMRI_NUMARASI,STOK_KODU,STOK_ADI,MIKTAR,SIPARIS_NUMARASI,SIPKALEM_ID,MUSTERI_KODU,MUSTERI_ADI) VALUES('"+txtFisNo.Text+"','"+txtIsEmriNumarasi.Text+"','"+txtStokKodu.Text+"','"+txtStokAdi.Text+"','"+txtMiktar.Text.Replace(',','.')+"','"+txtSiparisNumarasi.Text+"','"+txtKalemID.Text+"','"+txtMusteriKodu.Text+"','"+txtMusteriAdi.Text+"')", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtFisNo.Text = "";
                }

            }
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            if (txtFisNo.Text == "" || txtIsEmriNumarasi.Text == "")
            {
                MessageBox.Show("lütfen gerekli olan bilgileri doldurunuz.");
            }
            else
            {
                uretimsonukaydikontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    stokhareketkaydisilme();
                    stoguuretimealma();
                    isemriniacma();
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("DELETE TBL_URETIMSONUKAYITLARI WHERE URETIMSONUKAYDI_NUMARASI='"+txtFisNo.Text+"'",conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtFisNo.Text = "";

                }
                else
                {
                    MessageBox.Show("böyle bir üretim sonu kaydı bulunmamaktadır.");
                }
            }
        }

        private void sbtntIsEmriListesi_Click(object sender, EventArgs e)
        {
            FrmtIsEmriListesi.isemrino = "uretimsonukayit";    //
            FrmtIsEmriListesi frm = new FrmtIsEmriListesi();
            frm.Show();
        }

        private void FrmUretimSonuKayitlari_Activated(object sender, EventArgs e)
        {
            if (fisx == "isemri")
            {
                txtIsEmriNumarasi.Text = FrmtIsEmriListesi.isemrino;
                isemribilgisicekme();
                fisx = "";

            }
            if (fisx == "uretimsonukaydi")
            {
                txtFisNo.Text = FrmUretimSonuKayitListesi.fisno;
                uretimsonukaydıbilgisicekme();
                isemribilgisicekme();
                fisx = "";


            }
        }

        private void FrmUretimSonuKayitlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            fisx = ""; //böylece hafıza temizlenir

        }

        private void FrmUretimSonuKayitlari_Load(object sender, EventArgs e)
        {

        }

        private void sbtnSiparisTemizle_Click(object sender, EventArgs e)
        {
            temizle();
            txtFisNo.Text = "";
        }
    }
}
