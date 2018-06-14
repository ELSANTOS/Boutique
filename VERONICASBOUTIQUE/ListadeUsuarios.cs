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
    public partial class ListadeUsuarios : Form
    {
        public ListadeUsuarios()
        {
            InitializeComponent();
        }

        private void pbxRegresar_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.Show();
            this.Hide();
        }

        private void tmrFechaHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
