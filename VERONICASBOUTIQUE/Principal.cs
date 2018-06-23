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
    public partial class Principal : Form
    {
        ClassConexion miConexion = new ClassConexion();
        Globales miGlobal = new Globales();
        public Principal()
        {
            InitializeComponent();
            pbxFotoUsuario.Image = miGlobal.mostrarFoto();
            lblUsuario.Text = miGlobal.MostrarUsuario();
            tmrFechaHora.Start();
        }

        private void pbxSalir_Click(object sender, EventArgs e)
        {
            frmLogin frmentrar = new frmLogin();
            frmentrar.Show();
            this.Hide();
        }

        private void pbxUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.Show();
            this.Hide();
        }

        private void pbxProductos_Click(object sender, EventArgs e)
        {
            Productos frmProductos = new Productos();
            frmProductos.Show();
            this.Hide();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Principal_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void panel8_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            frmLogin FrmLog = new frmLogin();
            FrmLog.Show();
            this.Hide();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios frmUsuarios = new Usuarios();
            frmUsuarios.Show();
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos frmProductos = new Productos();
            frmProductos.Show();
            this.Hide();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Reportes frmReportes = new Reportes();
            frmReportes.Show();
            this.Hide();
        }

        private void btnPVenta_Click(object sender, EventArgs e)
        {
            PVenta frmPVenta = new PVenta();
            frmPVenta.Show();
            this.Hide();
        }

        private void tmrFechaHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void btnPagos_Click(object sender, EventArgs e)
        {
            Pagos frmPagos = new Pagos();
            frmPagos.Show();
            this.Hide();
        }
    }
}
