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
    public partial class frmLogin : Form
    {
        Globales miGlobal = new Globales();
        ClassUsuarios miUsuario = new ClassUsuarios();
        CnvertirImagen miFoto = new CnvertirImagen();
        string Us = "";
        string Ps = "";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="" || txtContra.Text =="")
            {
                MessageBox.Show("HAY CAMPOS VACIOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable DT = new DataTable();
                DT = miUsuario.IniciarSesion(txtUsuario.Text);
                DataRow Res = DT.Rows[0];
                if (DT.Rows.Count > 0)
                {
                    Us = Convert.ToString(Res["USUARIO"]);
                    Ps = Convert.ToString(Res["CONTRASENA"]);
                    
                }
                if ((Us.Equals(txtUsuario.Text)) && (Ps.Equals(txtContra.Text)))
                {
                    miGlobal.GuardarGlobales( txtUsuario.Text, txtContra.Text, miUsuario.BuscarImagenLoad(Us));
                    Principal frmPrincipal = new Principal();
                    frmPrincipal.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("USUARIO Y CONTRASEÑA NO COINCIDEN INTENTALO NUEVAMENTE", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
