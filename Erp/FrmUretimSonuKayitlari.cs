using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Erp
{
    public partial class FrmUretimSonuKayitlari : Form
    {
        public FrmUretimSonuKayitlari()
        {
            InitializeComponent();
        }

        private void sbtnFisListesi_Click(object sender, EventArgs e)
        {
            FrmUretimSonuKayitListesi frm = new FrmUretimSonuKayitListesi();
            frm.Show();

        }
    }
}
