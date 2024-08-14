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
    public partial class FrmStokGrupKodlari : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmStokGrupKodlari()
        {
            InitializeComponent();
        }

        String x1 = "0";
        void grupkodukontrol()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT COUNT(*) FROM TBL_GRUPKOD WHERE GRUP_KODU='" + txtGrupKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                x1 = dr[0].ToString(); // eğer aranılan satırdan 1 tane bile varsa   bu değer 1 olur. pk olduğu için en fazla birtane olur.
            }
            // MessageBox.Show(x1);

            conn.Close();
        }

        void grupkodubilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT GRUP_ADI FROM TBL_GRUPKOD WHERE GRUP_KODU='" + txtGrupKodu.Text + "'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtGrupAdi.Text = dr[0].ToString();

            }

            conn.Close();
        }

        void temizle()
        {
            txtGrupAdi.Text = "";
            txtGrupKodu.Text = "";
        }

        void grupkodulisteleme()
        {
            conn.Open();

            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT * FROM TBL_GRUPKOD", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt; // db'den alınan sonuçlar adabtörde saklandı ardından gridkontrole aktarıldı.
            conn.Close();
        }

        private void FrmStokGrupKodlari_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false; // gridte ki verilerin değiştirilememesi için kullandığım komut
            grupkodulisteleme();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            DataRow satir = gridView1.GetDataRow(gridView1.FocusedRowHandle); // odaklandığımız satırda ki veriler "satir" da tutuluyor.
            txtGrupKodu.Text = satir["GRUP_KODU"].ToString();
            txtGrupAdi.Text = satir["GRUP_ADI"].ToString();

            // tek tıklamayla tıklanılan veriler üst kutucuklara taşınıyor.
        }

        private void txtGrupKodu_Leave(object sender, EventArgs e)
        {
            grupkodukontrol();
            if (Convert.ToInt16(x1) == 1)
            {
                grupkodubilgisicekme();
            }
            else
            {
                txtGrupAdi.Text = "";
            }
        }

        private void sbtnKaydet_Click(object sender, EventArgs e)
        {
            grupkodukontrol();
            if(Convert.ToInt16(x1)==1)
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("UPDATE TBL_GRUPKOD SET GRUP_ADI='"+txtGrupAdi.Text +"' WHERE GRUP_KODU='"+ txtGrupKodu.Text +"'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                grupkodulisteleme();

                // güncelleme
                // x1 değişkeni grup kodu daha önceden varsa 1, yoksa 0 değerini alıyordu.
                // ekleme silme güncelleme gibi işlemlerde ExecuteNQ metodu kullanılır. Select'de kullanmaya gerek yoktur. 
            }
            else
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("INSERT INTO TBL_GRUPKOD (GRUP_KODU,GRUP_ADI) VALUES ('" + txtGrupKodu.Text + "','" + txtGrupAdi.Text + "')", conn);
                sorgu1.ExecuteNonQuery();          
                conn.Close();
                temizle();
                grupkodulisteleme();

                // yeni kayıt
            }
  
            
        }

        private void sbtnSil_Click(object sender, EventArgs e)
        {
            grupkodukontrol();
            if(Convert.ToInt16(x1)==1) // silinecek  değerin var olup olmadığının kontrolü. varsa siler yoksa silemez
            {
                conn.Open();
                SqlCommand sorgu1 = new SqlCommand("DELETE TBL_GRUPKOD WHERE GRUP_KODU='" + txtGrupKodu.Text + "'", conn);
                sorgu1.ExecuteNonQuery();
                conn.Close();
                temizle();
                grupkodulisteleme();

            }
            else
            {
                


            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
