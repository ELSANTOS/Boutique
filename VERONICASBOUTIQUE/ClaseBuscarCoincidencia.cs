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
    class ClaseBuscarCoincidencia
    {
        ClassConexion miConexion = new ClassConexion();
        FbConnection con = new FbConnection();
        public DataTable BuscarTodos()
        {
            string SQLString = "SELECT CLAVE_US, NOMBRE_US, APELLIDOPAT_US, APELLIDOMAT_US FROM USUARIOS ORDER BY CLAVE_US ASC";

            DataTable DT = new DataTable();
            con = miConexion.Conectar();
            FbDataAdapter Ada;
            Ada = new FbDataAdapter(SQLString,con);
            Ada.Fill(DT);

            return DT;
        }
        public DataTable Coincidir(string Cadena)
        {
            string SQLString = "SELECT CLAVE_US, NOMBRE_US, APELLIDOPAT_US, APELLIDOMAT_US FROM USUARIOS WHERE NOMBRE_US LIKE '%" + Cadena+ "%' OR APELLIDOPAT_US LIKE '%"+Cadena+"%' ORDER BY CLAVE_US ASC";

            DataTable DT = new DataTable();
            con = miConexion.Conectar();
            FbDataAdapter Ada;
            Ada = new FbDataAdapter(SQLString, con);
            Ada.Fill(DT);

            return DT;
        }
    }
}
