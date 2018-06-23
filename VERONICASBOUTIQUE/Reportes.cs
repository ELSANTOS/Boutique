using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VERONICASBOUTIQUE
{
    public partial class Reportes : Form
    {
        public Reportes()
        {
            InitializeComponent();
            pnlSubMenu.Visible = false;
        }

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            Principal frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Hide();
        }

        private void tmrFechaHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnListaUsuario_Click(object sender, EventArgs e)
        {
            pnlSubMenu.Visible = false;
            ListadeUsuarios frmLista = new ListadeUsuarios("Reportes");
            frmLista.Show();
            this.Hide();
           
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            pnlSubMenu.Visible = true;
        }

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            pnlSubMenu.Visible = false;
        }

        private void btnReporteInventarios_Click(object sender, EventArgs e)
        {
            pnlSubMenu.Visible = false;
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            pnlSubMenu.Visible = false;
        }
    }
}
