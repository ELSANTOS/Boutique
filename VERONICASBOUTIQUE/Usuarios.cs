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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            txtClaveUsuario.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtApellidoPatUsuario.Enabled = false;
            txtApellidoMatUsuario.Enabled = false;
            txtUsuario.Enabled = false;
            txtContra.Enabled = false;
            txtRoles.Enabled = false;
            
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

       

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            Principal frmPrincipal = new Principal();
            frmPrincipal.Show();
            this.Hide();
        }

        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            txtClaveUsuario.Enabled = true;
            txtNombreUsuario.Enabled = false;
            txtApellidoPatUsuario.Enabled = false;
            txtApellidoMatUsuario.Enabled = false;
            txtUsuario.Enabled = false;
            txtContra.Enabled = false;
            txtRoles.Enabled = false;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtClaveUsuario.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtApellidoPatUsuario.Enabled = true;
            txtApellidoMatUsuario.Enabled = true;
            txtUsuario.Enabled = true;
            txtContra.Enabled = true;
            txtRoles.Enabled = true;
        }

        private void btnListaUsuario_Click(object sender, EventArgs e)
        {
            ListadeUsuarios frmLista = new ListadeUsuarios("usuarios");
            frmLista.Show();
            this.Hide();
        }

        private void tmrFechaHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
