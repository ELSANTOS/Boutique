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
        private string Usuario;
        private string Password;
        private Image Foto;
        
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }

        public string usuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }

        public Image foto
        {
            get { return Foto; }
            set { Foto = value; }
        }
    }
}
