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
    public class D_Jugador
    {

        public int ccimi(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consultaG = new SqlCommand("BAI", con);
            consultaG.CommandType = CommandType.StoredProcedure;
            consultaG.Parameters.Add("@id", SqlDbType.BigInt).Value = cod;
            consultaG.ExecuteNonQuery();
            con.Close();
            return 1;
        }
        public DataTable ccimTI(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarECTI_M", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@id", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }

        public DataTable ccimCod(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarEC_M", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@id", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }

        public DataTable ccim(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarEC_j", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@id", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable ccn(string nom)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();

            SqlDataAdapter consultaG = new SqlDataAdapter("consultarEN_j", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nom;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }

        public DataTable ConsultaGCU_JLLP(Int64 ide)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarEID_M", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@id", SqlDbType.BigInt).Value = ide ;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;

        }
        public int ACTUALIZAR(Int64 Cod, string dir, Double talla, Double peso,Int64 tel)
        {

            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consulta_login = new SqlCommand("Actualizar_j", con);
            consulta_login.CommandType = CommandType.StoredProcedure;
            consulta_login.Parameters.Add("@Cod", SqlDbType.BigInt).Value = Cod;
            consulta_login.Parameters.Add("@direccion", SqlDbType.VarChar, 100).Value = dir;
            consulta_login.Parameters.Add("@talla", SqlDbType.Real).Value = talla;
            consulta_login.Parameters.Add("@peso", SqlDbType.Real).Value = peso;
            consulta_login.Parameters.Add("@tel", SqlDbType.BigInt).Value = tel;
            consulta_login.ExecuteNonQuery();
            return 1;
        }
        public DataTable ConsultaGCU_JLLM()
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarG_M", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;

        }
        public DataTable ConsultaGCU_JLL()
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultaECLL_J", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
                consultaG.Fill(Resultado);
            con.Close();
            return Resultado;

        }
        public DataTable ConsultaGCU_J()
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("consultaECU_J", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;

        }
        public DataTable ConsultaG_J (){
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultarG_j", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
            
        }
        public int registrom(Byte[] foto2, Byte[] foto3, Byte[] foto4, Byte[] foto5, Int64 TI, Int64 CE, Int64 CU)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consulta_login = new SqlCommand("reg_mat", con);
            consulta_login.CommandType = CommandType.StoredProcedure;
            consulta_login.Parameters.Add("@EPS", SqlDbType.VarBinary).Value = foto2;
            consulta_login.Parameters.Add("@EM", SqlDbType.VarBinary).Value = foto3;
            consulta_login.Parameters.Add("@FD", SqlDbType.VarBinary).Value = foto4;
            consulta_login.Parameters.Add("@CT", SqlDbType.VarBinary).Value = foto5;
            consulta_login.Parameters.Add("@TI", SqlDbType.BigInt).Value = TI;
            consulta_login.Parameters.Add("@CU", SqlDbType.BigInt).Value = CE;
            consulta_login.Parameters.Add("@CE", SqlDbType.BigInt).Value = CU;
            consulta_login.ExecuteNonQuery();
            return 1; 
        
        }
        public int registro(Int64 TI, string nom, Int64 tel, string dir, double talla, double peso, DateTime f, Byte[] foto, Int64 regpor)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consulta_login = new SqlCommand("insertar_j", con);
            consulta_login.CommandType = CommandType.StoredProcedure;
            consulta_login.Parameters.Add("@ID", SqlDbType.BigInt).Value = TI;
            consulta_login.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nom;
            consulta_login.Parameters.Add("@telefono", SqlDbType.BigInt).Value = tel;
            consulta_login.Parameters.Add("@talla", SqlDbType.Real).Value = talla;
            consulta_login.Parameters.Add("@peso", SqlDbType.Real).Value = peso;
            consulta_login.Parameters.Add("@direccion", SqlDbType.VarChar, 100).Value = dir;
            consulta_login.Parameters.Add("@fechanac", SqlDbType.Date).Value = f;
            consulta_login.Parameters.Add("@foto", SqlDbType.VarBinary).Value = foto;
            consulta_login.Parameters.Add("@registradopor", SqlDbType.BigInt).Value =  regpor;
            consulta_login.ExecuteNonQuery();
            con.Close();
            return 1; 
        }
        public DataTable CMAT()
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("CMAT", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;

        }
    }
}
