using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class D_Test
    {
        public int ccimi(string cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consultaG = new SqlCommand("CPT", con);
            consultaG.CommandType = CommandType.StoredProcedure;
            consultaG.Parameters.Add("@nom", SqlDbType.VarChar,30).Value = cod;
            SqlDataReader ireader = consultaG.ExecuteReader(CommandBehavior.SingleRow);
            if (ireader.HasRows) {
                con.Close();
                return 1;
                
            }
            else {
                con.Close();
                return 45;
                
            }
            
            
            
        }
        public int ACTUALIZAR(string dato, Int16 PP, Int16 Pm, Int16 PM,Int64 cod) {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consulta_login = new SqlCommand("Actualizar_t", con);
            consulta_login.CommandType = CommandType.StoredProcedure;
            consulta_login.Parameters.Add("@dato", SqlDbType.VarChar, 100).Value = dato;
            consulta_login.Parameters.Add("@PP", SqlDbType.TinyInt).Value = PP;
            consulta_login.Parameters.Add("@PMinimo", SqlDbType.TinyInt).Value = Pm;
            consulta_login.Parameters.Add("@Pmax", SqlDbType.TinyInt).Value = PM;
            consulta_login.Parameters.Add("@codigo", SqlDbType.BigInt).Value = cod;
            consulta_login.ExecuteNonQuery();
            return 1;
        }
        public DataTable busquedaGn()
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("CTnnnnn", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable busquedaG() {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarG_T", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public int Registrar(string n, string um, Int16 min, Int16 max, Int16 prom,Int64 R)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consulta_login = new SqlCommand("insertar_T", con);
            consulta_login.CommandType = CommandType.StoredProcedure;
            consulta_login.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = n;
            consulta_login.Parameters.Add("@dato", SqlDbType.VarChar, 30).Value = um;
            consulta_login.Parameters.Add("@min", SqlDbType.SmallInt).Value = min;
            consulta_login.Parameters.Add("@max", SqlDbType.SmallInt).Value = max;
            consulta_login.Parameters.Add("@prom", SqlDbType.SmallInt).Value = prom;
            consulta_login.Parameters.Add("@codigouser", SqlDbType.BigInt).Value = R;
            consulta_login.ExecuteNonQuery();
            return 1;
        }
        public DataTable cec(Int64 cod)
        {

            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarEC_T", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@codigo", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable ced(string id)
        {

            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarED_T", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@test", SqlDbType.VarChar,30).Value = id;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable cen(string nom)
        {

            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("consultarE_T", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar,100).Value = nom;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable ConsultaGCU_J()
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("CT", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;

        }
        }
}
