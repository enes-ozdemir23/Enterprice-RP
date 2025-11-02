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
    public partial class FrmStokKayitlari : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");

        public FrmStokKayitlari()
        {
            InitializeComponent();
        }
        string x1 = "0";
        void stokkartikontol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString(); // eğer aranılan satırdan 1 tane bile varsa   bu değer 1 olur. pk olduğu için en fazla birtane olur.
            }
            // MessageBox.Show(x1);

            conn.Close();

        }

        string x2 = "0";
        void grupkodukontrol()
            {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_GRUPKOD WHERE GRUP_KODU='" + txtGrupKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x2 = dr[0].ToString(); // eğer aranılan satırdan 1 tane bile varsa bu değer 1 olur. pk olduğu için en fazla birtane olur.
            }
            // MessageBox.Show(x1);

            conn.Close();

        }

        
        void temizle()
        {

            txtFiyat.Text = "";
            txtGrupAdi.Text= "";
            txtGrupKodu.Text= "";
            txtKDVOrani.Text= "";
            txtStokAdi.Text = "";
        }
        void stokbilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtStokAdi.Text = dr[1].ToString();             
                txtGrupKodu.Text = dr[2].ToString();             
                txtFiyat.Text = dr[3].ToString();             
                txtKDVOrani.Text = dr[4].ToString();             
                
            }
            

            conn.Close();
        }

        void grupbilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT GRUP_ADI FROM TBL_GRUPKOD WHERE GRUP_KODU='"+txtGrupKodu.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtGrupAdi.Text = dr[0].ToString();
            

            }


            conn.Close();

        }

        private void FrmStokKayitlari_Load(object sender, EventArgs e)
        {
            // Mouse ile boyut ayarlaması özelliği devre dışı.
            this.FormBorderStyle = FormBorderStyle.FixedSingle; 
            txtFiyat.Text = "0,00";
            txtKDVOrani.Text = "0,00";
        }

        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            FrmStokListesi.stokkodu = "kayit";  // stok kayitlarindan geldiğimizi belirtmek için yazıldı.
            FrmStokListesi frm = new FrmStokListesi();
            frm.Show();

            // Diğer Formdaki bir elemana erişip değerini belirledik.
        }

        private void sbtnGrupKodListesi_Click(object sender, EventArgs e)
        {
            FrmStokGrupKodlari frm = new FrmStokGrupKodlari();
            frm.Show();
        }

        private void txtStokKodu_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtStokKodu_Leave(object sender, EventArgs e)
        {
            if(txtStokKodu.Text=="")
            {
                txtStokKodu.Focus(); // hücreden ayrılmaz
            }
            else
            {
                FrmStokListesi.stokkodu = txtStokKodu.Text;
                stokkartikontol(); // x değerini kontrol ediyor.
                if (Convert.ToUInt16(x1) == 1)
                {
                    stokbilgisicekme();
                    grupbilgisicekme();
                }
                else
                {
                    temizle();
                    txtFiyat.Text = "0,00";
                    txtKDVOrani.Text = "0,00";
                    
                }

            }
            
        }

        private void FrmStokKayitlari_Activated(object sender, EventArgs e)
        {
            if (FrmStokListesi.stokkodu == "") //yani form kapatıldysa formu temizle
            {
                temizle();
                txtStokKodu.Text = "";
            }
            else
            {
                txtStokKodu.Text = FrmStokListesi.stokkodu; // form bir değer seçilip dönülmüşse (otomatik kapanır)
                stokbilgisicekme();
                grupbilgisicekme();
                // Form aktif olursa burası çalışır.

            }

        }

        private void txtGrupKodu_Leave(object sender, EventArgs e)
        {
            grupkodukontrol();
            if(Convert.ToInt16(x2)==1)
            {
                grupbilgisicekme();
            }
            else
            {
                txtGrupKodu.Focus(); // yani o satırdan çıkılamaz
            }
        }

        private void FrmStokKayitlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmStokListesi.stokkodu = ""; // stok listesi kapanıp tekrar açıldığında önceki seçilenleri silmek için kullanılan kod
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            stokkartikontol();
            if (Convert.ToInt16(x1) == 1)
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_STOKKAYITLARI SET STOK_ADI='"+txtStokAdi.Text+"',GRUP_KODU='"+txtGrupKodu.Text+"',FIYAT='"+txtFiyat.Text.Replace(',','.')+"',KDV_ORANI='"+txtKDVOrani.Text.Replace(',','.')+"' WHERE STOK_KODU='"+txtStokKodu.Text+"' ", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                txtStokKodu.Text = "";

                // güncelleme
                // x1 değişkeni grup kodu daha önceden varsa 1, yoksa 0 değerini alıyordu.
                // ekleme silme güncelleme gibi işlemlerde ExecuteNQ metodu kullanılır. Select'de kullanmaya gerek yoktur. 

            }
            else
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_STOKKAYITLARI(STOK_KODU,STOK_ADI,GRUP_KODU,FIYAT,KDV_ORANI) VALUES('"+txtStokKodu.Text+"','"+txtStokAdi.Text+"','"+txtGrupKodu.Text+"','"+txtFiyat.Text.Replace(',','.')+"','"+txtKDVOrani.Text.Replace(',', '.') + "')", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                txtStokKodu.Text = "";
                // YENİ KAYIT


            }
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            stokkartikontol();
            if(Convert.ToInt16(x1)==1) // varsa siler
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("DELETE TBL_STOKKAYITLARI WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                txtStokKodu.Text = ""; // stokkodu bilgisi her yerden silinmemeli. Bazı yerlerde silinebilir fakat bazı yerlerde bağlantı var

            }
            else
            {
                MessageBox.Show("Böyle bir stok kodu bulunmamaktadır.");

            }
        }

        private void FrmStokKayitlari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                this.Hide();
            }
            if (e.KeyCode == Keys.Enter)
            {
                sbtnKaydet.PerformClick();
            }
            if (e.KeyCode == Keys.F5)
            {
                FrmStokListesi frm = new FrmStokListesi();
                frm.Show();
            }

        }
    }
}
