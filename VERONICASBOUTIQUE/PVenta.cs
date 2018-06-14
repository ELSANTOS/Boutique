using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VERONICASBOUTIQUE
{
    public partial class PVenta : Form
    {
        public PVenta()
        {
            InitializeComponent();
        }
    

        private void tmrFechaHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            Principal frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Hide();
        }
    }
}
