using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Datos
{
    public class D_Login
        
    {
        public MemoryStream LL(Int64 cod) {
            SqlConnection cn = new SqlConnection(D_conexion.Cc());
            cn.Open();
            SqlCommand cmd = new SqlCommand("consulta_pbx", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.BigInt).Value = cod;
            SqlDataAdapter sect_comandos = new SqlDataAdapter(cmd);
            DataSet memoria_imagen = new DataSet("Usuario"); //tabla
            byte[] datos = new byte[0];
            sect_comandos.Fill(memoria_imagen, "Usuario"); //llanar el DataSet con tabla 
            DataRow colunma = memoria_imagen.Tables["Usuario"].Rows[0]; //obtener la columna foto de la tabla x
            datos = (byte[])colunma["foto"]; //pasamos a datos lo q tenemos en columna
            MemoryStream memoria = new MemoryStream(datos);
            return memoria;
            
        }
        public int T(Int64 PAS){

            SqlConnection con = new SqlConnection(D_conexion.Cc());

            con.Open();

            SqlCommand co = new SqlCommand("actualizarPAS", con);
            co.CommandType = CommandType.StoredProcedure;
            co.Parameters.Add("@us", SqlDbType.BigInt).Value = PAS;
            SqlDataReader lec = co.ExecuteReader();
            if (lec.Read() == true)
            {
                int res2 = 1;
                return res2;

            }
            else
            {
                int res2 = 0;   
                return res2;

            }
        
        }
        public int PA(Int64 PAS)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            
            con.Open();

            SqlCommand consulta_login = new SqlCommand("PAS", con);

            consulta_login.CommandType = CommandType.StoredProcedure;

            consulta_login.Parameters.Add("@codigo", SqlDbType.BigInt).Value = PAS;
            SqlDataReader lector = consulta_login.ExecuteReader();
                
            if (lector.Read() == true)
            {
                
                return 1;

               
            }
            else
            {
                int res = 0;
                con.Close();
                return res;

            }
        }
        public int consulta_G4(Int64 usuario, string clave, string cargo)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
                     
            con.Open();

            SqlCommand consulta_login = new SqlCommand("Log_In", con);

            consulta_login.CommandType = CommandType.StoredProcedure;

            consulta_login.Parameters.Add("@usuario", SqlDbType.BigInt).Value = usuario;
            consulta_login.Parameters.Add("@clave", SqlDbType.VarChar, 100).Value = clave;
            consulta_login.Parameters.Add("@cargo", SqlDbType.VarChar, 100).Value = cargo;
            SqlDataReader lector = consulta_login.ExecuteReader();

            if (lector.Read() == true)
            {
                int res = 1;
                con.Close();
                return res;
            }
            else
            {
                int res = 0;
                con.Close();
                return res;

            }

        }
    }
}
