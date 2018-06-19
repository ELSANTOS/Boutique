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
        bool btnSearch = false;

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
            btnAceptar.Enabled = false;
            pbxFoto.Enabled = false;
            btnCancelar.Enabled = false;
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            if (btnAdd)
            {
                if (pbxFoto.Image ==null)
                {
                    pbxFoto.Image = null;
                }
                else
                {
                    Foto = pbxFoto.Image;
                }

                Clave = txtClaveUsuario.Text;
                Nombre = txtNombreUsuario.Text;
                ApellidoPat = txtApellidoPatUsuario.Text;
                ApellidoMat = txtApellidoMatUsuario.Text;
                Usuario = txtUsuario.Text;
                Contrasena = txtContra.Text;
                Roles = txtRoles.Text;
               

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
            if (btnDel)
            {
                Clave = txtClaveUsuario.Text;
                DialogResult Res = new DialogResult();
                Res = MessageBox.Show("Se eliminara un Usuario, ¿desea seguir?", "Cerrar sin Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (Res == DialogResult.Yes)
                {
                    miUsuario.Eliminar(Clave);
                }
                else
                {
                    
                }
            }
            if (btnEdit)
            {
                Clave = txtClaveUsuario.Text;
                Nombre = txtNombreUsuario.Text;
                ApellidoPat = txtApellidoPatUsuario.Text;
                ApellidoMat = txtApellidoMatUsuario.Text;
                Usuario = txtUsuario.Text;
                Contrasena = txtContra.Text;
                Roles = txtRoles.Text;
                Foto = pbxFoto.Image;
                DialogResult Res = new DialogResult();
                Res = MessageBox.Show("Se Actualizaran los datos de un Usuario, ¿desea seguir?", "Cerrar sin Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (Res == DialogResult.Yes)
                {
                    miUsuario.Editar(Clave, Nombre, ApellidoPat, ApellidoMat, Usuario, Contrasena, Roles, Foto);
                }
                else
                {

                }
            }
            if (btnSearch)
            {
                if (txtClaveUsuario.Text!="")
                {
                    Clave = txtClaveUsuario.Text;
                    DataTable Datos = new DataTable();
                    CnvertirImagen miImagen = new CnvertirImagen();
                    Datos = miUsuario.BuscarDatos(Clave);
                    txtClaveUsuario.Enabled = false;
                    if (Datos.Rows.Count>0)
                    {
                        DataRow Res = Datos.Rows[0];
                        txtClaveUsuario.Text = Convert.ToString(Res["CLAVE_US"]);
                        txtNombreUsuario.Text = Convert.ToString(Res["NOMBRE_US"]);
                        txtApellidoPatUsuario.Text= Convert.ToString(Res["APELLIDOPAT_US"]);
                        txtApellidoMatUsuario.Text = Convert.ToString(Res["APELLIDOMAT_US"]);
                        txtUsuario.Text= Convert.ToString(Res["USUARIO"]);
                        txtContra.Text= Convert.ToString(Res["CONTRASENA"]);
                        txtRoles.Text= Convert.ToString(Res["ROL"]);
                        Foto = miUsuario.BuscarImagen(Clave);
                        pbxFoto.Image = Foto;
                        pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
                else
                {
                    MessageBox.Show("Necesitas una clave de Usuario para Buscar");
                }
                
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
            if (btnSearch)
            {
                lblAccion.Text = "ELIMINAR";
                btnAdd = false;
                btnEdit = false;
                btnDel = true;
                btnSearch = false;
                txtClaveUsuario.Enabled = false;
                txtNombreUsuario.Enabled = false;
                txtClaveUsuario.Focus();
                txtApellidoPatUsuario.Enabled = false;
                txtApellidoMatUsuario.Enabled = false;
                txtUsuario.Enabled = false;
                txtContra.Enabled = false;
                txtRoles.Enabled = false;
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
            }
            else
            {
                MessageBox.Show("Busca un Usuario antes de Eliminar", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lblAccion.Text = "AGREGAR";
            txtApellidoMatUsuario.Clear();
            txtApellidoPatUsuario.Clear();
            txtClaveUsuario.Clear();
            txtContra.Clear();
            txtNombreUsuario.Clear();
            txtRoles.Clear();
            txtUsuario.Clear();
            pbxFoto.Image = null;
            btnAdd = true;
            btnEdit = false;
            btnDel = false;
            btnSearch = false;
            txtClaveUsuario.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtApellidoPatUsuario.Enabled = true;
            txtApellidoMatUsuario.Enabled = true;
            txtClaveUsuario.Focus();
            txtUsuario.Enabled = true;
            txtContra.Enabled = true;
            txtRoles.Enabled = true;
            btnAceptar.Enabled = true;
            pbxFoto.Enabled = true;
            btnCancelar.Enabled = true;
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
            if (btnSearch)
            {
                lblAccion.Text = "EDITAR";
                btnAdd = false;
                btnEdit = true;
                btnDel = false;
                btnSearch = false;
                txtClaveUsuario.Enabled = true;
                txtNombreUsuario.Enabled = true;
                txtApellidoPatUsuario.Enabled = true;
                txtApellidoMatUsuario.Enabled = true;
                txtClaveUsuario.Focus();
                txtUsuario.Enabled = true;
                txtContra.Enabled = true;
                txtRoles.Enabled = true;
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
                pbxFoto.Enabled = true;
            }
            else
            {
                MessageBox.Show("Busca un Usuario antes de Editar","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
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
                if (btnSearch)
                {
                    btnAceptar.PerformClick();
                }
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
            else
            {
                DialogResult Res = new DialogResult();
                Res = MessageBox.Show("Desea Modificar la foto del usuario?", "Cerrar sin Guardar?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (Res == DialogResult.Yes)
                {
                    lblAddFoto.Visible = false;
                    miImagen.Filter = "Archivos de Imagen|*.jpg";
                    miImagen.FileName = "";
                    miImagen.InitialDirectory = "C:/";
                    if (miImagen.ShowDialog() == DialogResult.OK)
                    {
                        Direccion = miImagen.FileName;
                        pbxFoto.ImageLocation = Direccion;
                        pbxFoto.SizeMode = PictureBoxSizeMode.StretchImage;
                        Foto = Image.FromFile(Direccion);
                    }
                }
                else
                {

                }
               
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtClaveUsuario.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtApellidoPatUsuario.Enabled = false;
            txtApellidoMatUsuario.Enabled = false;
            txtUsuario.Enabled = false;
            txtContra.Enabled = false;
            txtRoles.Enabled = false;
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            txtApellidoMatUsuario.Clear();
            txtApellidoPatUsuario.Clear();
            txtClaveUsuario.Clear();
            txtContra.Clear();
            txtNombreUsuario.Clear();
            txtRoles.Clear();
            txtUsuario.Clear();
            pbxFoto.Image = null;
            txtClaveUsuario.Focus();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            lblAccion.Text = "BUSCAR";
            txtApellidoMatUsuario.Clear();
            txtApellidoPatUsuario.Clear();
            txtClaveUsuario.Clear();
            txtContra.Clear();
            txtNombreUsuario.Clear();
            txtRoles.Clear();
            txtUsuario.Clear();
            pbxFoto.Image = null;
            btnAdd = false;
            btnEdit = false;
            btnDel = false;
            btnSearch = true;

            txtClaveUsuario.Enabled = true;
            txtNombreUsuario.Enabled = false;
            txtClaveUsuario.Focus();
            txtApellidoPatUsuario.Enabled = false;
            txtApellidoMatUsuario.Enabled = false;
            txtUsuario.Enabled = false;
            txtContra.Enabled = false;
            txtRoles.Enabled = false;
            btnAceptar.Enabled = true;
            btnCancelar.Enabled = true;
            lblAddFoto.Visible = false;
            pbxFoto.Enabled = false;
        }
    }
}
