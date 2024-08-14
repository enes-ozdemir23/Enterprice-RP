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
    public partial class FrmSiparisListesi : Form
    {
        public static string siparisno;

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");

        void arama()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT S.SIPARIS_NO,M.MUSTERI_ADI,S.SIPARIS_TARIHI,S.TESLIM_TARIHI FROM TBL_SIPARISLER S LEFT JOIN TBL_MUSTERIKAYITLARI M ON S.MUSTERI_KODU=M.MUSTERI_KODU WHERE S.SIPARIS_NO LIKE '%"+txtSiparisNumarasi.Text+"%' AND M.MUSTERI_ADI LIKE '%"+txtMusteriAdi.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }
        public FrmSiparisListesi()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FrmSiparisListesi_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            arama();
        }

        private void txtSiparisNumarasi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (siparisno == "sipariskayit")
            {
                siparisno = x["SIPARIS_NO"].ToString();
                FrmSiparisler.siparisx = "siparis";
                this.Hide();
                FrmSiparisler frm = new FrmSiparisler();
                frm.Activate();
            }
            else
            {

            }

        }

        private void FrmSiparisListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            siparisno = "";
        }
    }
}
