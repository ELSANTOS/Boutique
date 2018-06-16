using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;
using System.Windows.Forms;

namespace VERONICASBOUTIQUE
{
    class ClassConexion
    {
        FbConnection con;
        string ConnectionString = "User=SYSDBA;" + "Password=masterkey;" +
          "Database=C:/Users/HP i3/source/repos/VERONICASBOUTIQUE/VERONICASBD.fdb;" +
          "DataSource=localhost;" + "Port=3050;" + "Dialect=3;" + "Charset=ASCII;" + "Role=;" +
          "Connection lifetime=15;" + "Pooling=true;" + "MinPoolSize=0;" + "MaxPoolSize=50;" +
          "Packet Size=8192;" + "ServerType=0";

        public FbConnection Conectar()
        {
            con = new FbConnection(ConnectionString);
            try
            {
                if (con != null)
                {
                    if (con.State.ToString().Equals("Closed"))
                    {
                        con.Open();
                    }
                }
                else
                {
                    con.Open();
                }
                //Abre la conexion
                
                MessageBox.Show("Conexion Abierta");
                
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            return con;
        }
        public void Cerrar()
        {
            con = new FbConnection(ConnectionString);
            try
            {
                if (con.State.ToString().Equals("Closed"))
                {
                    
                }
                else
                {
                    con.Close();
                }
                MessageBox.Show("Conexion cerrada");
            }
            catch (Exception x)
            {

                MessageBox.Show(x.Message);
            }

        }
    }
}
