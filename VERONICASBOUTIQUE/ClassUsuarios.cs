using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace VERONICASBOUTIQUE
{
    class ClassUsuarios
    {
        CnvertirImagen miImg = new CnvertirImagen();
        ClassConexion miConexion = new ClassConexion();
        FbConnection con;

        public void Insertar(string Clave, string Nombre, string ApPat, string ApMat, string Usuario,string Contra,string Rol, Image Foto)
        {
            try
            {
                con = miConexion.Conectar();
                byte[] BytesFoto = miImg.imagenaByte(Foto);
                string SqlString = "INSERT INTO USUARIOS VALUES ('" + Clave + "','" + Nombre + "','" + ApPat 
                    + "','" + ApMat + "','" + Usuario + "','" + Contra + "','" + Rol + "','" + BytesFoto + "')";

                using (FbTransaction tran = con.BeginTransaction())
                {
                    FbCommand cmd = new FbCommand(SqlString, con, tran);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    MessageBox.Show("Articulo Agregado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    miConexion.Cerrar();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, ToString());
            }

}

        public void Eliminar()
        {

        }

        public void Editar()
        {

        }
    }
}
