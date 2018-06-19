using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.IO;

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
                    + "','" + ApMat + "','" + Usuario + "','" + Contra + "','" + Rol + "',@FOTO)";
                using (FbTransaction tran = con.BeginTransaction())
                {
                    FbCommand cmd = new FbCommand(SqlString, con, tran);
                    cmd.Connection = con;
                cmd.Parameters.Add("@FOTO",FbDbType.Array).Value = BytesFoto;
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    MessageBox.Show("Usuario Agregado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    miConexion.Cerrar();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, ToString());
            }
        }

        public void Eliminar(string Clave)
        {
            try
            {
                con = miConexion.Conectar();
                string SqlString = "DELETE FROM USUARIOS WHERE CLAVE_US = '"+Clave+"'";
                using (FbTransaction tran = con.BeginTransaction())
                {
                    FbCommand cmd = new FbCommand(SqlString, con, tran);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    MessageBox.Show("Usuario Eliminado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    miConexion.Cerrar();
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, ToString());
            }
        }

        public void Editar(string Clave, string Nombre, string ApPat, string ApMat, string Usuario, string Contra, string Rol, Image Foto)
        {
            //    try
            //    {
            con = miConexion.Conectar();
                byte[] BytesFoto = miImg.imagenaByte(Foto);
                string SqlString = "UPDATE USUARIOS SET NOMBRE_US = '"+Nombre+"', APELLIDOPAT_US = '"+ApPat+ "', APELLIDOMAT_US = '" + ApMat +
                    "', USUARIO = '" + Usuario + "', CONTRASENA = '" + Contra+ "', ROL = '" + Rol + "', FOTO = @FOTO WHERE CLAVE_US = '"+Clave+"'";

                using (FbTransaction tran = con.BeginTransaction())
                {
                    FbCommand cmd = new FbCommand(SqlString, con, tran);
                    cmd.Connection = con;
                cmd.Parameters.Add("@FOTO",FbDbType.Array).Value = BytesFoto;
                    cmd.ExecuteNonQuery();
                    cmd.Transaction.Commit();
                    MessageBox.Show("Datos del Usuario editados", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    miConexion.Cerrar();
                }

            ////}
            ////catch (Exception Ex)
            ////{
            ////    MessageBox.Show(Ex.Message, ToString());
            ////}
        }

        public DataTable BuscarDatos(string Clave)
        {
            DataTable Datos = new DataTable();
            try
            {
                string SqlString = "SELECT * FROM USUARIOS WHERE CLAVE_US = '" + Clave + "'";
                con = miConexion.Conectar();
                FbCommand cmd = new FbCommand(SqlString, con);
                FbDataAdapter Da = new FbDataAdapter(cmd);
                Da.Fill(Datos);
                miConexion.Cerrar();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Datos;
        }

        public Image BuscarImagen(string Clave)
        {
            try
            {
                string SqlString = "SELECT FOTO FROM USUARIOS WHERE CLAVE_US = '" + Clave + "'";
                con = miConexion.Conectar();
                FbCommand cmd = new FbCommand(SqlString, con);
                //FbDataReader Reader = cmd.ExecuteReader();
                //if (Reader.Read())
                //{
                //    return Reader["FOTO"].getBytes;
                //}

                byte[] miFoto = (byte[])cmd.ExecuteScalar();
                miConexion.Cerrar();
                return miImg.ByteaImagen(miFoto);

            }
            catch (Exception Ex)
            {
                
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable IniciarSesion(string Usuario)
        {
            DataTable Datos = new DataTable();
            try
            {
                string SqlString = "SELECT USUARIO, CONTRASENA FROM USUARIOS WHERE USUARIO = '" + Usuario + "'";
                con = miConexion.Conectar();
                FbCommand cmd = new FbCommand(SqlString, con);
                FbDataAdapter Da = new FbDataAdapter(cmd);
                Da.Fill(Datos);
                miConexion.Cerrar();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Datos;
        }

        public Image BuscarImagenLoad(string Us)
        {
            try
            {
                string SqlString = "SELECT FOTO FROM USUARIOS WHERE USUARIO = '" + Us + "'";
                con = miConexion.Conectar();
                FbCommand cmd = new FbCommand(SqlString, con);
                //FbDataReader Reader = cmd.ExecuteReader();
                //if (Reader.Read())
                //{
                //    return Reader["FOTO"].getBytes;
                //}

                byte[] miFoto = (byte[])cmd.ExecuteScalar();
                miConexion.Cerrar();
                return miImg.ByteaImagen(miFoto);

            }
            catch (Exception Ex)
            {

                MessageBox.Show(Ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

    }
}
