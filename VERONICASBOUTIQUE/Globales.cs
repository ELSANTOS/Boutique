using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace VERONICASBOUTIQUE
{
    class Globales
    {
        public Globales()
        {

        }
        private string pASSWORD;
        private string uSUARIO;
        private Image fOTO;

        //public string PASSWORD { get { return pASSWORD; } set { pASSWORD = value; } }
        //public string USUARIO { get { return uSUARIO; } set { uSUARIO = value; } }
        //public Image FOTO { get { return fOTO; } set { fOTO = value; } }

        public void GuardarGlobales(string Us, string Contra, Image Fot)
        {
            pASSWORD = Contra;
            uSUARIO = Us;
            fOTO = Fot;
        }
        public string MostrarUsuario ()
        {
            return uSUARIO;
        }

        public Image mostrarFoto()
        {
            return fOTO;
        }
    }
}
