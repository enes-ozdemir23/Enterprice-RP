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
    public partial class FrmStokHareketleri : Form
    {
        public static string stokhareketx = "";
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");

        public FrmStokHareketleri()
        {
            InitializeComponent();
        }

        void stokbilgisicekme()
        {
            conn.Open();
            SqlCommand sorgu1 = new SqlCommand("SELECT SK.STOK_ADI,GK.GRUP_ADI FROM TBL_STOKKAYITLARI SK LEFT JOIN TBL_GRUPKOD GK  ON SK.GRUP_KODU=GK.GRUP_KODU WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
            SqlDataReader dr = sorgu1.ExecuteReader();
            while (dr.Read())
            {
                txtStokAdi.Text = dr[0].ToString();
                txtGrupAdi.Text = dr[1].ToString();

            }
            conn.Close();

            conn.Open();
            SqlCommand sorgu2 = new SqlCommand("SELECT ISNULL((SUM(G_MIKTAR)-SUM(C_MIKTAR)),0) AS 'STOK MİKTARI' FROM TBL_STOKHAREKETLERI WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
            SqlDataReader dr2 = sorgu2.ExecuteReader();
            while (dr2.Read())
            {
                txtStokMiktari.Text = dr2[0].ToString();
            }
            conn.Close();
        }

        void stokhareketlistesicekme()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT URETIMSONUKAYDI_NUMARASI AS 'ÜRETİM SONU KAYDI',ISEMRI_NUMARASI AS 'İŞ  EMRİ NUMARASI',ACIKLAMA AS 'AÇIKLAMA',STOK_KODU AS 'STOK KODU', STOK_ADI AS 'STOK_ADI',G_MIKTAR AS 'ÜRETİM MİKTARI',C_MIKTAR AS 'SEVK MİKTARI',MUSTERI_ADI AS 'MÜŞTERİ ADI' FROM TBL_STOKHAREKETLERI WHERE STOK_KODU='"+txtStokKodu.Text+"'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }
        void temizle()
        {
            txtStokKodu.Text = "";
            txtStokAdi.Text = "";
            txtGrupAdi.Text = "";
            txtStokMiktari.Text = "";
            gridControl1.DataSource = "";
        }

        private void sbtnStokListesi_Click(object sender, EventArgs e)
        {
            FrmStokListesi.stokkodu = "stokhareket";
            FrmStokListesi frm = new FrmStokListesi();
            frm.Show();
        }

        private void FrmStokHareketleri_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
        }

        private void txtStokKodu_Leave(object sender, EventArgs e)
        {
            stokbilgisicekme();
            stokhareketlistesicekme();
        }

        private void sbtnSiparisTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void FrmStokHareketleri_Activated(object sender, EventArgs e)
        {
            if (stokhareketx == "stok")
            {
                txtStokKodu.Text = FrmStokListesi.stokkodu;
                stokbilgisicekme();
                stokhareketlistesicekme();
                stokhareketx = "";
            }
        }

        private void FrmStokHareketleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmStokListesi.stokkodu = "";
            stokhareketx = "";
        }

        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            string tur = Convert.ToString(gridView1.GetRowCellValue(e.RowHandle, "AÇIKLAMA"));
            if (tur == "ÜRETİM")
            {
                e.Appearance.BackColor = Color.Green;
            }
            else
            {
                e.Appearance.BackColor = Color.Red;
            }
        }
    }
}
