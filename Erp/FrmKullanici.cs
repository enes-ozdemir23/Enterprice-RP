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
    public partial class FrmKullanici : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-SU16M9I9\\VT_SQL;Initial Catalog=ERP_EGITIM;Integrated Security=True");

        public FrmKullanici()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM TBL_KULLANICILAR WHERE KULLANICI_ADI=@kullaniciAdi AND SIFRE=@sifre", conn);

            cmd.Parameters.AddWithValue("@kullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox2.Text);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                FrmGiris frm = new FrmGiris();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre!");
            }
            conn.Close();
        

    }
    }
}
