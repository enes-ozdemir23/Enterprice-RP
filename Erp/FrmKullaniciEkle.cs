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
    public partial class FrmKullaniciEkle : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");

        public FrmKullaniciEkle()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO TBL_KULLANICILAR (KULLANICI_ADI, SIFRE) VALUES (@kullaniciAdi, @sifre)", conn);

            cmd.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox2.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Kullanıcı Kaydedildi!");
            textBox1.Text = "";
            textBox2.Text = "";
            conn.Close();
        }
    }
}
