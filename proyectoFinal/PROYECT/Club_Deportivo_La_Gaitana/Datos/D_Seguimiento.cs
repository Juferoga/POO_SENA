using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Seguimiento
    {
        public DataTable CGD()
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarG_S", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public int ACTUALIZAR(Int64 cod, string tipo, string valoracion, Double puntaje, Int64 codM, Int64 codT)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consulta_login = new SqlCommand("Actualizar_S", con);
            consulta_login.CommandType = CommandType.StoredProcedure;
            consulta_login.Parameters.Add("@cod", SqlDbType.VarChar, 100).Value = cod;
            consulta_login.Parameters.Add("@tipo", SqlDbType.VarChar, 50).Value = tipo;
            consulta_login.Parameters.Add("@valoracion", SqlDbType.VarChar, 100).Value = valoracion;
            consulta_login.Parameters.Add("@puntaje", SqlDbType.Real).Value = puntaje;
            consulta_login.Parameters.Add("@codM", SqlDbType.BigInt).Value = codM;
            consulta_login.Parameters.Add("@codT", SqlDbType.BigInt).Value = codT;
            consulta_login.ExecuteNonQuery();
            return 1;
        }
        public int REGISTRAR(string tipo, string valoracion, Double puntaje, Int64 codM, Int64 codT, Int64 regpor)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consulta_login = new SqlCommand("Insertar_S", con);
            consulta_login.CommandType = CommandType.StoredProcedure;
            consulta_login.Parameters.Add("@tipo", SqlDbType.VarChar, 50).Value = tipo;
            consulta_login.Parameters.Add("@valoracion", SqlDbType.VarChar, 100).Value = valoracion;
            consulta_login.Parameters.Add("@puntaje", SqlDbType.Real).Value = puntaje;
            consulta_login.Parameters.Add("@codM", SqlDbType.BigInt).Value = codM;
            consulta_login.Parameters.Add("@codT", SqlDbType.BigInt).Value = codT;
            consulta_login.Parameters.Add("@cod", SqlDbType.BigInt).Value = regpor;
            consulta_login.ExecuteNonQuery();
            return 1;
        }
        public DataTable cc(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();

            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarEC", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@cod", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable ccm(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();

            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarEM", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@cod", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable cct(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();

            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarECT", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@cod", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
       
        public DataTable mejor(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("mejor", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;

        }
        public DataTable bajo(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("bajo", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
            

        }
    }
}
