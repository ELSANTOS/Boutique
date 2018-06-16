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
        ClassUsuarios miUsuario = new ClassUsuarios();
        string Clave = "";
        string Nombre = "";
        string ApellidoPat = "";
        string ApellidoMat = "";
        string Usuario = "";
        string Contrasena = "";
        string Roles = "";
        Image Foto = null;
        bool btnAdd = false;
        bool btnDel = false;
        bool btnEdit = false;


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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (btnAdd)
            {
                Clave = txtClaveUsuario.Text;
                Nombre = txtNombreUsuario.Text;
                ApellidoPat = txtApellidoPatUsuario.Text;
                ApellidoMat = txtApellidoMatUsuario.Text;
                Usuario = txtUsuario.Text;
                Contrasena = txtContra.Text;
                Roles = txtRoles.Text;
                Foto = pbxFoto.Image;

                miUsuario.Insertar(Clave,Nombre,ApellidoPat,ApellidoMat,Usuario,Contrasena,Roles,Foto);

                txtApellidoMatUsuario.Clear();
                txtApellidoPatUsuario.Clear();
                txtClaveUsuario.Clear();
                txtContra.Clear();
                txtNombreUsuario.Clear();
                txtRoles.Clear();
                txtUsuario.Clear();
                pbxFoto.Image = null;
                txtClaveUsuario.Enabled = false;
                txtNombreUsuario.Enabled = false;
                txtApellidoPatUsuario.Enabled = false;
                txtApellidoMatUsuario.Enabled = false;
                txtUsuario.Enabled = false;
                txtContra.Enabled = false;
                txtRoles.Enabled = false;

               
            }
            


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
            btnAdd = false;
            btnEdit = false;
            btnDel = true;
            txtClaveUsuario.Enabled = true;
            txtNombreUsuario.Enabled = false;
            txtClaveUsuario.Focus();
            txtApellidoPatUsuario.Enabled = false;
            txtApellidoMatUsuario.Enabled = false;
            txtUsuario.Enabled = false;
            txtContra.Enabled = false;
            txtRoles.Enabled = false;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnAdd = true;
            btnEdit = false;
            btnDel = false;
            txtClaveUsuario.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtApellidoPatUsuario.Enabled = true;
            txtApellidoMatUsuario.Enabled = true;
            txtClaveUsuario.Focus();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnAdd = false;
            btnEdit = true;
            btnDel = false;
            txtClaveUsuario.Enabled = true;
            txtNombreUsuario.Enabled = false;
            txtClaveUsuario.Focus();
            txtApellidoPatUsuario.Enabled = false;
            txtApellidoMatUsuario.Enabled = false;
            txtUsuario.Enabled = false;
            txtContra.Enabled = false;
            txtRoles.Enabled = false;
        }

        private void txtClaveUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.F4)
            {
                ListadeUsuarios frmLista = new ListadeUsuarios("usuarios");
                frmLista.Show();
                this.Hide();
            }
            if (e.KeyCode == Keys.Enter)
            {
                txtClaveUsuario.Enabled = false;
                txtNombreUsuario.Enabled = true;
                txtNombreUsuario.Focus();
                txtApellidoPatUsuario.Enabled = true;
                txtApellidoMatUsuario.Enabled = true;
                txtUsuario.Enabled = true;
                txtContra.Enabled = true;
                txtRoles.Enabled = true;
            }
        }

        private void pbxFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog miImagen = new OpenFileDialog();
            String Direccion;
            if (pbxFoto.Image == null)
            {
                lblAddFoto.Visible = false;
                miImagen.Filter = "Archivos de Imagen|*.jpg";
                miImagen.FileName = "";
                miImagen.InitialDirectory = "C:/";
                if (miImagen.ShowDialog()==DialogResult.OK)
                {
                    Direccion = miImagen.FileName;
                    pbxFoto.ImageLocation = Direccion;
                    pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    Foto = Image.FromFile(Direccion);    
                }
            }
        }
    }
}
