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
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            txtCantidad.Enabled = false;
            txtClave.Focus();
            txtClave.Enabled = false;
            txtNombre.Enabled = false;
            txtPUnitario.Enabled = false;
            txtTipo.Enabled = false;
            gbxUMedida.Enabled = false;
            pbxFoto.Enabled = false;
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
            ListadeUsuarios frmLista = new ListadeUsuarios("Productos");
            frmLista.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCantidad.Enabled = true;
            txtClave.Enabled = true;
            txtClave.Focus();
            txtNombre.Enabled = true;
            txtPUnitario.Enabled = true;
            txtTipo.Enabled = true;
            gbxUMedida.Enabled = true;
            pbxFoto.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtCantidad.Enabled = false;
            txtClave.Enabled = true;
            txtClave.Focus();
            txtNombre.Enabled = false;
            txtPUnitario.Enabled = false;
            txtTipo.Enabled = false;
            gbxUMedida.Enabled = false;
            pbxFoto.Enabled = false;
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

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                ListadeUsuarios Lista = new ListadeUsuarios("Productos");
                Lista.Show();
                this.Hide();
            }
        }
    }
}
