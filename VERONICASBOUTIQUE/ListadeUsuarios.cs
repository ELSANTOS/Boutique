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
    public partial class ListadeUsuarios : Form
    {
        ClassUsuarios CoincidirUs = new ClassUsuarios();
        string Reg;
        public ListadeUsuarios(string reg)
        {
            InitializeComponent();
            Reg = reg;
            lblLista.Text = "LISTA DE " + reg.ToUpper();
            txtCoincidir.Focus();
            dgvLista.DataSource= CoincidirUs.BuscarTodos();

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

        private void btnPrincipal_Click(object sender, EventArgs e)
        {
            switch (Reg)
            {
                case "usuarios":
                    Usuarios frmUsuario = new Usuarios();
                    frmUsuario.Show();
                    this.Close();
                    break;

                case "Productos":
                    Productos frmProductos = new Productos();
                    frmProductos.Show();
                    this.Close();
                    break;

                case "Reportes":
                    Reportes frmReportes = new Reportes();
                    frmReportes.Show();
                    this.Close();
                    break;

            }
            
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

        private void txtCoincidir_TextChanged(object sender, EventArgs e)
        {
            dgvLista.DataSource = CoincidirUs.Coincidir(txtCoincidir.Text);
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
