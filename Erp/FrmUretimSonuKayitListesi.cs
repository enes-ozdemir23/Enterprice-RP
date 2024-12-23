﻿using System;
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
    public partial class FrmUretimSonuKayitListesi : Form
    {
        public static string fisno;
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");
        public FrmUretimSonuKayitListesi()
        {
            InitializeComponent();
        }
        void arama()
        {
            conn.Open();
            DataTable dt = new DataTable();
            SqlCommand sorgu1 = new SqlCommand("SELECT URETIMSONUKAYDI_NUMARASI, ISEMRI_NUMARASI, STOK_KODU,STOK_ADI,SIPARIS_NUMARASI,MUSTERI_ADI FROM TBL_URETIMSONUKAYITLARI WHERE URETIMSONUKAYDI_NUMARASI LIKE '%"+txtFisNo.Text+"%' AND SIPARIS_NUMARASI LIKE '%"+txtSiparisNumarasi.Text+"%' AND STOK_KODU LIKE '%"+txtStokKodu.Text+"%' AND STOK_ADI LIKE '%"+txtStokAdi.Text+"%' AND MUSTERI_ADI LIKE '%"+txtMusteriAdi.Text+"%' AND ISEMRI_NUMARASI LIKE '%"+txtIsEmriNumarasi.Text+"%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(sorgu1);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            conn.Close();
        }
        private void FrmUretimSonuKayitListesi_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            arama();
        }

        private void txtFisNo_TextChanged(object sender, EventArgs e)
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

        private void txtIsEmriNumarasi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtMusteriAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void txtStokAdi_TextChanged(object sender, EventArgs e)
        {
            arama();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow x = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if(fisno== "uretimsonukaydi")
            {
                fisno = x["URETIMSONUKAYDI_NUMARASI"].ToString();
                FrmUretimSonuKayitlari.fisx = "uretimsonukaydi";
                this.Hide();
                FrmUretimSonuKayitlari frm = new FrmUretimSonuKayitlari();
                frm.Activate();
            }

        }
    }
}
