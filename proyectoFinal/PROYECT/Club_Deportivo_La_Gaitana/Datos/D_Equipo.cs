using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;

namespace Datos
{
   public class D_Equipo
    {
       public DataTable cee(Int64 ID)
       {
           SqlConnection con = new SqlConnection(D_conexion.Cc());
           con.Open();
           SqlDataAdapter consultaG = new SqlDataAdapter("consultarcod", con);
           consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
           consultaG.SelectCommand.Parameters.Add("@nombre", SqlDbType.BigInt).Value = ID;
           DataTable Resultado = new DataTable();
           consultaG.Fill(Resultado);
           con.Close();
           return Resultado;
       }
       public int ACTUALIZAR(Int64 ID, string name, string des) {

           SqlConnection con = new SqlConnection(D_conexion.Cc());
           con.Open();
           SqlCommand saveE = new SqlCommand("Actualizar_E", con);
           saveE.CommandType = CommandType.StoredProcedure;
           saveE.Parameters.Add("@codigo", SqlDbType.BigInt).Value = ID;
           saveE.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = name;
           saveE.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = des;
           saveE.ExecuteNonQuery();
           con.Close();
           return 1;
       }
       public DataTable CUCd(string nom) {
           SqlConnection con = new SqlConnection(D_conexion.Cc());
           con.Open();
           SqlDataAdapter consultaG = new SqlDataAdapter("consultarENU_E", con);
           consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
           consultaG.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar,50).Value = nom;
           DataTable Resultado = new DataTable();
           consultaG.Fill(Resultado);
           con.Close();
           return Resultado;
       }
       public DataTable ConsultarGN_E()
       {
           SqlConnection con = new SqlConnection(D_conexion.Cc());
           con.Open();
           SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarGN_E", con);
           consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
           DataTable Resultado = new DataTable();
           consultaG.Fill(Resultado);
           con.Close();
           return Resultado;

       }
       public DataTable CGE() {
           SqlConnection con = new SqlConnection(D_conexion.Cc());
           con.Open();
           SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarG_E", con);
           consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
           DataTable Resultado = new DataTable();
           consultaG.Fill(Resultado);
           con.Close();
           return Resultado;
           
       }
       public int SaveEQ(string nom, string des,Int64 ID)
       {
           SqlConnection con = new SqlConnection(D_conexion.Cc());
           con.Open();
           SqlCommand saveE = new SqlCommand("Insertar_E", con);
           saveE.CommandType = CommandType.StoredProcedure;
           saveE.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nom;
           saveE.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = des;
           saveE.Parameters.Add("@registradopor", SqlDbType.BigInt).Value = ID;
           saveE.ExecuteNonQuery();
           con.Close();
           return 1;
       }
    }
}
