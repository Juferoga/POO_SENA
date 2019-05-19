using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comunicar_Datos
{
    public class Usuario
    {
        public static string user1;

        public void Tipo_Usuario(string DatoComunicar)
        {
            user1 = DatoComunicar;
        }
    }
}
