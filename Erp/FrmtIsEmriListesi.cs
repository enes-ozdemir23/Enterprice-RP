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
    public partial class FrmtIsEmriListesi : Form
    {
        public static string isemrino;
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmtIsEmriListesi()
        {
            InitializeComponent();
        }
        void arama()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT ISEMRI_NUMARASI,STOK_KODU,STOK_ADI,SIPARIS_NO FROM TBL_ISEMRI WHERE ISEMRI_NUMARASI LIKE '%"+txtIsEmriNumarasi.Text+"%' AND STOK_KODU LIKE '%"+txtStokKodu.Text+"%' AND STOK_ADI LIKE '%"+txtStokAdi.Text+"%' AND SIPARIS_NO LIKE '%"+txtSiparisNumarasi.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }
        private void FrmtIsEmriListesi_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;

            arama();

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(isemrino=="isemrikayit")
            {
                isemrino = x["ISEMRI_NUMARASI"].ToString();
                FrmIsEmri.isemrix = "isemri";
                this.Hide();
                FrmIsEmri frm = new FrmIsEmri();
                frm.Activate();
                // aktif olursa FrmIsemri_Activated metodu çalışır.
            }
        }

        private void FrmtIsEmriListesi_FormClosed(object sender, FormClosedEventArgs e)
        {
            // manuel olarak kapatılırsa yani
            isemrino = "";

           
        }

        private void txtIsEmriNumarasi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtSiparisNumarasi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtStokKodu_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtStokAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }
    }
}
