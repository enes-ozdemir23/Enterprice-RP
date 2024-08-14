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
    public partial class FrmMusteriKayitlari : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmMusteriKayitlari()
        {
            InitializeComponent();
        }

        String x1 = "0";

        void musterikontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='"+txtMusteriKodu.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString();
            }
            

            conn.Close(); // kayıt varsa x1=olur
        }

        void musteribilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='"+txtMusteriKodu.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read()) //verileri okuyana dek döngü çalışır. 
            {
                txtMusteriAdi.Text = dr[1].ToString();
                txtAdres.Text= dr[2].ToString();
                cbxIl.Text= dr[3].ToString();
                cbxIlce.Text= dr[4].ToString();
                txtTelefon.Text= dr[5].ToString();
                txtEposta.Text= dr[6].ToString();
                string x = dr[7].ToString();
                if (x == "A")
                {
                    rbtnAlici.Checked = true;

                }
                else
                {
                    rbtnSatici.Checked = true;
                }
            }
            conn.Close();
            illisteleme();
            ilcelisteleme();
        }

        void illisteleme()
        {
            cbxIl.Items.Clear();
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISIM FROM TBL_IL", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read()) //verileri okuyana dek döngü çalışır. 
            {
                cbxIl.Items.Add(dr[0]);


            }


            conn.Close();

        }
        void ilcelisteleme()
        {
            cbxIlce.Items.Clear();
            if (cbxIl.SelectedIndex == -1) return; // combobox ilk çalıştığnda -1 değerini verir
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISIM FROM TBL_ILCE WHERE IL_ID='"+ (cbxIl.SelectedIndex+1) + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read()) //verileri okuyana dek döngü çalışır. 
            {
                cbxIlce.Items.Add(dr[0]);


            }


            conn.Close();
        }

        void temizle()
        {
            txtAdres.Text = "";
            txtMusteriAdi.Text = "";
            txtEposta.Text = "";
            txtTelefon.Text = "";
            cbxIl.Text = "";
            cbxIlce.Text = "";
            cbxIlce.Items.Clear();
            cbxIl.Items.Clear();
            rbtnAlici.Checked = false;
            rbtnSatici.Checked = false;
        }
        private void FrmMusteriKayitlari_Load(object sender, EventArgs e)
        {
            illisteleme();
            ilcelisteleme();

        }

        private void txtMusteriKodu_Leave(object sender, EventArgs e)
        {
            if (txtMusteriKodu.Text == "")
            {
                txtMusteriKodu.Focus();

            }
            else
            {
                musterikontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    musteribilgisicekme();
                }
                else
                {
                    temizle();
                    illisteleme();

                }

            }

            
        }

        

        private void sbtnKaydet_Click(object sender, EventArgs e) //select için executereader ve datareader kullanılır. diğerleri için nonquery
        {
            musterikontrol(); 
            if (Convert.ToInt16(x1)==1) 
            {
                if (rbtnAlici.Checked == true) // musteri kayıtlıysa yapılacak işlem=update(alici)
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_MUSTERIKAYITLARI SET MUSTERI_ADI='" + txtMusteriAdi.Text + "',ADRES='" + txtAdres.Text + "',IL='" + cbxIl.Text + "',ILCE='" + cbxIlce.Text + "',TELEFON='" + txtTelefon.Text + "',E_POSTA='" + txtEposta.Text + "',TIP='A' WHERE MUSTERI_KODU='" + txtMusteriKodu.Text + "'", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtMusteriKodu.Text = "";
                }
                else
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_MUSTERIKAYITLARI SET MUSTERI_ADI='" + txtMusteriAdi.Text + "',ADRES='" + txtAdres.Text + "',IL='" + cbxIl.Text + "',ILCE='" + cbxIlce.Text + "',TELEFON='" + txtTelefon.Text + "',E_POSTA='" + txtEposta.Text + "',TIP='S' WHERE MUSTERI_KODU='" + txtMusteriKodu.Text + "'", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtMusteriKodu.Text = "";
                }
            }
            else
            {
                if (rbtnAlici.Checked == true) // musteri kayıtlı değilse yapılacak işlem=insert(alici)
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_MUSTERIKAYITLARI (MUSTERI_KODU,MUSTERI_ADI,ADRES,IL,ILCE,TELEFON,E_POSTA,TIP) VALUES ('"+txtMusteriKodu.Text+"','"+txtMusteriAdi.Text+"','"+txtAdres.Text+"','"+cbxIl.Text+"','"+cbxIlce.Text+"','"+txtTelefon.Text+"','"+ txtEposta.Text + "','A')", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtMusteriKodu.Text = "";
                }
                else
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_MUSTERIKAYITLARI (MUSTERI_KODU,MUSTERI_ADI,ADRES,IL,ILCE,TELEFON,E_POSTA,TIP) VALUES ('" + txtMusteriKodu.Text + "','" + txtMusteriAdi.Text + "','" + txtAdres.Text + "','" + cbxIl.Text + "','" + cbxIlce.Text + "','" + txtTelefon.Text + "','" + txtEposta.Text + "','S')", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    temizle();
                    txtMusteriKodu.Text = "";

                }
            }
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("DELETE TBL_MUSTERIKAYITLARI WHERE MUSTERI_KODU='"+txtMusteriKodu.Text+"'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
            temizle();
            txtMusteriKodu.Text = "";


        }

        private void cbxIl_Leave(object sender, EventArgs e)
        {
            ilcelisteleme();
            cbxIlce.Text = ""; // Bir müşterinin şehri değiştiğinde daha önce kayıtlı olan ilçenin silinmesi için yazdık.
        }

        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            FrmMusteriListesi.musterikodu = "musterikayit"; // muşteri kayıttan geldiğimizi göstermek için global değişkeni belirteç olarak kullandık
            FrmMusteriListesi frm = new FrmMusteriListesi(); // sipariş kayıttanda gelmiş olabiliriz bunu belirtmek için kullanıyoruz.                                                
            frm.Show();

            // global değişken kullanma nedeni nereden geldiğimizi ve nereye gittiğimizi ve
            // nereye gideceğimizi kayıt altında  tutumaktır. müşteri kayıtlarından geliyorsak tekrar oraya dönmek için. siparişten geliyorsakta yine...
        }

        private void FrmMusteriKayitlari_Activated(object sender, EventArgs e)
        {   // modül aktif olduğunda:

            if (FrmMusteriListesi.musterikodu == "")
            {
                temizle();       // listeden bir şey seçilir sonra tekrar açıp listeden hiçbir şey seçilmezse liste kapandığında veriler silinir.
                txtMusteriKodu.Text = "";
            }
            else
            {
                txtMusteriKodu.Text = FrmMusteriListesi.musterikodu;
                musteribilgisicekme();
            }

        }

        private void FrmMusteriKayitlari_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmMusteriListesi.musterikodu = ""; 

            // listeden bir kayıt seçip ardından müşteri kayıtı formunu kapatıp tekrar kayıt formunu açtığımda önceki seçilen veriler hala mevcuttu
            // bu kodla verileri siliyoruz.
        }
    }
}
