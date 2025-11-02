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
    public partial class FrmIsEmri : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmIsEmri()
        {
            InitializeComponent();
        }
        string x1 = "0";

        void isemrikontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI='"+txtIsEmriNumarasi.Text+"'",conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString();
            }
            conn.Close();
        }
        void isemribilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI='"+txtIsEmriNumarasi.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtStokKodu.Text= dr[1].ToString();
                txtStokAdi.Text= dr[2].ToString();
                txttIsEmriAciklmasi.Text= dr[3].ToString();
                txtIsEmriTarihi.Text= dr[4].ToString();
                txtTeslimTarihi.Text= dr[5].ToString();
                txtSiparisNumarasi.Text= dr[6].ToString();
                txtMiktar.Text= dr[7].ToString();
                txtKalemId.Text= dr[8].ToString();
                string x= dr[9].ToString();
                if (x == "Y")
                {
                    rbtnYeni.Checked = true;
                }
                else
                {
                    rbtnTamamlanmis.Checked = true;
                }

            }
            conn.Close();
            txtStokKodu.Enabled = false;
            txtMiktar.Enabled = false;
            txtSiparisNumarasi.Enabled = false;
            sbtnStokListesi.Enabled = false;
            sbtnSiparisListesi.Enabled = false;
            

        }
        string x2 = "0";
        void stokkartikontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x2 = dr[0].ToString();
            }
            conn.Close();
        }

        void stokbilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT STOK_ADI FROM TBL_STOKKAYITLARI WHERE STOK_KODU='" + txtStokKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtStokAdi.Text = dr[0].ToString();
            }
            conn.Close();
        }

        void sipariskalemiacma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='A' WHERE SIPKALEM_ID='"+txtKalemId.Text+"'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        void sipariskalemikapatma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='K' WHERE SIPKALEM_ID='" + txtKalemId.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        void sipariskaleminibitirme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_SIPARISKALEMLERI SET URETIMDURUMU='b' WHERE SIPKALEM_ID='" + txtKalemId.Text + "'", conn);
            sorgu1.ExecuteNonQuery();
            conn.Close();
        }

        string y1 = "";
        void  isemrinumarasihesaplama()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT TOP 1 CONCAT('I',REPLICATE('0',10-(LEN(SUBSTRING(ISEMRI_NUMARASI,2,9)+1)+1)),SUBSTRING(ISEMRI_NUMARASI,2,9)+1) AS 'URETIM SONU KAYDI NUMARASI' FROM TBL_ISEMRI ORDER BY ISEMRI_NUMARASI DESC", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                y1 = dr[0].ToString();
            }
            conn.Close();

        }
        void isemrilistesicekme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISEMRI_NUMARASI,STOK_KODU,STOK_ADI,SIPARIS_NO,MIKTAR,DURUM FROM TBL_ISEMRI", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }

        void sipnovemiktaraulasma()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT SIPARIS_NO,MIKTAR FROM TBL_SIPARISKALEMLERI WHERE SIPKALEM_ID='"+txtKalemId.Text+"'",conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtSiparisNumarasi.Text = dr[0].ToString();
                txtMiktar.Text = dr[1].ToString();
            }
            conn.Close();

        }

        void temizle()
        {
            txttIsEmriAciklmasi.Text = "";
            txtIsEmriTarihi.Text = "";
            txtKalemId.Text = "";
            txtMiktar.Text = "";
            txtSiparisNumarasi.Text = "" ;
            txtStokAdi.Text = "";
            txtStokKodu.Text = "";
            txtTeslimTarihi.Text = "";
            txtStokKodu.Enabled = true;
            txtMiktar.Enabled = true;
            txtSiparisNumarasi.Enabled = true;
            rbtnYeni.Checked = true;
            sbtnSiparisListesi.Enabled = true;
            sbtnStokListesi.Enabled = true;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void sbtntIsEmriListesi_Click(object sender, EventArgs e)
        {
            FrmtIsEmriListesi.isemrino = "isemrikayit";
            FrmtIsEmriListesi frm = new FrmtIsEmriListesi();
            frm.Show();
        }

        public static string stokkodu;
        public static string isemrix;
        private void sbtnSiparisListesi_Click(object sender, EventArgs e)
        {
            stokkodu = txtStokKodu.Text;
            FrmIsEmriSiparisleri frm = new FrmIsEmriSiparisleri();
            frm.Show();
        }

        private void FrmIsEmri_Load(object sender, EventArgs e)
        {
            isemrinumarasihesaplama();
            txtIsEmriNumarasi.Text = y1;
            gridView1.OptionsBehavior.Editable = false;
            isemrilistesicekme();


        }

        private void txtIsEmriNumarasi_Leave(object sender, EventArgs e)
        {
            if (txtIsEmriNumarasi.Text == "")
            {
                txtIsEmriNumarasi.Focus();
            }
            isemrikontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                isemribilgisicekme();
                
            }
            else
            {
                temizle();
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtIsEmriNumarasi.Text = dr["ISEMRI_NUMARASI"].ToString();
            isemribilgisicekme();
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            if (rbtnTamamlanmis.Checked == true)
            {
                MessageBox.Show("Bu iş emrine ait üretim sonu kaydı vardır silinemez.");
            }
            else
            {
                isemrikontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    conn.Open();
                    SqlCommand sorgu1 = new SqlCommand("DELETE TBL_ISEMRI WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
                    sorgu1.ExecuteNonQuery();
                    conn.Close();
                    sipariskalemikapatma(); // çünkü iş emri silindi
                    temizle();
                    txtIsEmriNumarasi.Text = "";
                    isemrilistesicekme();
                    isemrinumarasihesaplama();
                    txtIsEmriNumarasi.Text = y1;
                }
                else
                {
                    MessageBox.Show("Böyle bir iş emri kaydı bulunmamaktadır.");
                }

            }
            
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            if (rbtnTamamlanmis.Checked == true)
            {
                MessageBox.Show("Bu iş emrine ait üretim sonu kaydı vardır kayıt üzerinde güncelleme işlemi yapılamaz.");
            }
            else
            {
                isemrikontrol();
                if (Convert.ToInt16(x1) == 1)
                {
                    if (rbtnYeni.Checked == true)
                    {
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_ISEMRI SET ISEMRI_ACIKLAMASI='" + txttIsEmriAciklmasi.Text + "', ISEMRI_TARIHI='" + txtIsEmriTarihi.Text + "',TESLIM_TARIHI='" + txtTeslimTarihi.Text + "',DURUM='Y' WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        sipariskalemiacma();
                        temizle();
                        txtIsEmriNumarasi.Text = "";
                        isemrilistesicekme();
                        isemrinumarasihesaplama();
                        txtIsEmriNumarasi.Text = y1;


                    }
                    else
                    {
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_ISEMRI SET ISEMRI_ACIKLAMASI='" + txttIsEmriAciklmasi.Text + "', ISEMRI_TARIHI='" + txtIsEmriTarihi.Text + "',TESLIM_TARIHI='" + txtTeslimTarihi.Text + "',DURUM='E' WHERE ISEMRI_NUMARASI='" + txtIsEmriNumarasi.Text + "'", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        sipariskaleminibitirme();
                        temizle();
                        txtIsEmriNumarasi.Text = "";
                        isemrilistesicekme();
                        isemrinumarasihesaplama();
                        txtIsEmriNumarasi.Text = y1;
                    }
                }
                else
                {
                    if (rbtnYeni.Checked == true)
                    {
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_ISEMRI (ISEMRI_NUMARASI,STOK_KODU,STOK_ADI,ISEMRI_ACIKLAMASI,ISEMRI_TARIHI,TESLIM_TARIHI,SIPARIS_NO,MIKTAR,SIPKALEM_ID,DURUM) VALUES ('" + txtIsEmriNumarasi.Text + "','" + txtStokKodu.Text + "','" + txtStokAdi.Text + "','" + txttIsEmriAciklmasi.Text + "','" + txtIsEmriTarihi.Text + "','" + txtTeslimTarihi.Text + "','" + txtSiparisNumarasi.Text + "','" + txtMiktar.Text.Replace(',', '.') + "','" + txtKalemId.Text + "','Y')", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        sipariskalemiacma();
                        temizle();
                        txtIsEmriNumarasi.Text = "";
                        isemrilistesicekme();
                        isemrinumarasihesaplama();
                        txtIsEmriNumarasi.Text = y1;

                    }
                    else
                    {
                        conn.Open();
                        SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_ISEMRI (ISEMRI_NUMARASI,STOK_KODU,STOK_ADI,ISEMRI_ACIKLAMASI,ISEMRI_TARIHI,TESLIM_TARIHI,SIPARIS_NO,MIKTAR,SIPKALEM_ID,DURUM) VALUES ('" + txtIsEmriNumarasi.Text + "','" + txtStokKodu.Text + "','" + txtStokAdi.Text + "','" + txttIsEmriAciklmasi.Text + "','" + txtIsEmriTarihi.Text + "','" + txtTeslimTarihi.Text + "','" + txtSiparisNumarasi.Text + "','" + txtMiktar.Text.Replace(',', '.') + "','" + txtKalemId.Text + "','E')", conn);
                        sorgu1.ExecuteNonQuery();
                        conn.Close();
                        sipariskaleminibitirme();
                        temizle();
                        txtIsEmriNumarasi.Text = "";
                        isemrilistesicekme();
                        isemrinumarasihesaplama();
                        txtIsEmriNumarasi.Text = y1;
                    }
                }

            }
            
        }

        private void FrmIsEmri_Activated(object sender, EventArgs e)
        {
            // is emri listesinden geliyorsa
            if (isemrix == "isemri") 
            {
                txtIsEmriNumarasi.Text = FrmtIsEmriListesi.isemrino;
                isemribilgisicekme();
                isemrix = "";
            }

            // Yani stoktan geldiğini belirtiyor.
            if (isemrix == "stok")
            {
                txtStokKodu.Text = FrmStokListesi.stokkodu;
                stokbilgisicekme();
                isemrix = ""; // pencere değişikliğinden dolayı yine bilgileri çekmesin diye bunu temizledik
            }


            // siparis ekranından geliyorsa if içindeki kodlar çalışır.
            if (isemrix == "siparis")
            {
                txtKalemId.Text = FrmIsEmriSiparisleri.kalemid;
                if (txtKalemId.Text == "")
                {

                }
                else // yani doubleclick yapılmış
                {
                    sipnovemiktaraulasma();
                    txtMiktar.Enabled = false;
                    isemrix = "";
                }

            }
        }

        private void txtStokKodu_Leave(object sender, EventArgs e)
        {
            stokkartikontrol();
            if (Convert.ToInt16(x2)==1)
            {
                stokbilgisicekme();
                txtSiparisNumarasi.Text = "";
                txtMiktar.Text = "";
                txtKalemId.Text = "";
                txtStokAdi.Enabled = false;

            }
            else
            {
                txtStokKodu.Focus();
            }
        }

        private void FrmIsEmri_FormClosed(object sender, FormClosedEventArgs e)
        {
            // form kapatıldıgı zamanki temizliyoruz verileri. yani hafızayı temizliyoruz.

            FrmIsEmriSiparisleri.kalemid = "";
            FrmStokListesi.stokkodu = "";
            FrmtIsEmriListesi.isemrino = "";
            isemrix = "";
        }

        private void sbtnSiparisTemizle_Click(object sender, EventArgs e)
        {

            temizle();
            txtIsEmriNumarasi.Text = "";
            txtIsEmriNumarasi.Focus();
        
        }

        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            FrmStokListesi.stokkodu = "isemri"; // yani imrinden geldigimizi bildiriyoruz.
            FrmStokListesi frm = new FrmStokListesi();
            frm.Show();
        }
    }
}
