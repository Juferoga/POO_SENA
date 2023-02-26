using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Datos
{
    class D_conexion // solo comparte con clases de la misma capa
    {
        public static string Cc() {
            string CadenaSQLcon = "data source=DELL\\SQLEXPRESS;initial catalog=Gaitana;integrated security=true";
            return CadenaSQLcon;
        }
    }
}
