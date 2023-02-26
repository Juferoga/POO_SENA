using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
   public class D_CambioClave
    {
       public int CambioClave(Int64 CC) {
           SqlConnection conexion = new SqlConnection(D_conexion.Cc());
           conexion.Open();
           SqlCommand PAS = new SqlCommand("PAS", conexion);
           PAS.CommandType = CommandType.StoredProcedure;
           PAS.Parameters.Add("@codigo", SqlDbType.BigInt).Value = CC;
           PAS.ExecuteNonQuery();
           return 1;
       }
       public int CambioC(string CC,Int64 cod)
       {
           SqlConnection conexion = new SqlConnection(D_conexion.Cc());
           conexion.Open();
           SqlCommand PAS = new SqlCommand("CCUPAS", conexion);
           PAS.CommandType = CommandType.StoredProcedure;
           PAS.Parameters.Add("@claven", SqlDbType.Char, 50).Value = CC;
           PAS.Parameters.Add("@PAS", SqlDbType.Char, 1).Value = "I";
           PAS.Parameters.Add("@numero_id", SqlDbType.BigInt).Value = cod;
           PAS.ExecuteNonQuery();
           return 1;
       }
    }
}
