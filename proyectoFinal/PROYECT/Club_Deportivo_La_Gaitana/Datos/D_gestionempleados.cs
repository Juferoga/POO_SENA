using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.IO;


namespace Datos
{
    public class D_gestionempleados
    {
        public DataTable ceemn(Int64 ID)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("CCUlol", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@id", SqlDbType.BigInt).Value = ID;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        
        public DataTable TELS(Int64 cod) {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("consulta_telefonousuariosss", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@numero_id", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable ccimq(Int64 id)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("consultaENLOL", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@id", SqlDbType.BigInt).Value = id;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable Email(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();

            SqlDataAdapter consultaG = new SqlDataAdapter("Email_u", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@codigo", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable consultaG_ED()
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultaG_UD", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable consultaG_E() {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultaG_u", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public DataTable cci(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlDataAdapter consultaG = new SqlDataAdapter("consultarCEIm_u", con);
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
            SqlDataAdapter consultaG = new SqlDataAdapter("consultarCEI_u", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@id", SqlDbType.BigInt).Value = cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public int ccimi(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consultaG = new SqlCommand("consultarCEIm_u", con);
            consultaG.CommandType = CommandType.StoredProcedure;
            consultaG.Parameters.Add("@id", SqlDbType.BigInt).Value = cod;
            consultaG.ExecuteNonQuery();
            con.Close();
            return 1;
        }

        public DataTable ccn(string nom)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();

            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultaEn_u", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nom;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }

        public DataTable cce(Int64 cod)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();

            SqlDataAdapter consultaG = new SqlDataAdapter("ConsultaECC_u", con);
            consultaG.SelectCommand.CommandType = CommandType.StoredProcedure;
            consultaG.SelectCommand.Parameters.Add("@codigo",SqlDbType.BigInt).Value=cod;
            DataTable Resultado = new DataTable();
            consultaG.Fill(Resultado);
            con.Close();
            return Resultado;
        }
        public int registro_empleado(string nom, Int64 num_id, string direccion, string cargo, string e_mail, string profesion, Int16 anos_e, string genero, string clave,string ciudad, byte[] foto,byte[] titulo, byte[] hoja_de_vida,string estado,string pas,Int64 reg)
        {
            SqlConnection con = new SqlConnection(D_conexion.Cc());
            con.Open();
            SqlCommand consulta_login = new SqlCommand("insertar_u", con);
            consulta_login.CommandType = CommandType.StoredProcedure;
            consulta_login.Parameters.Add("@nombre_completo", SqlDbType.VarChar, 100).Value = nom;
            consulta_login.Parameters.Add("@numero_id", SqlDbType.BigInt).Value=num_id;
            consulta_login.Parameters.Add("@direccion", SqlDbType.VarChar, 100).Value = direccion;
            consulta_login.Parameters.Add("@cargo", SqlDbType.VarChar, 100).Value = cargo;
            consulta_login.Parameters.Add("@e_mail", SqlDbType.VarChar, 100).Value = e_mail;
            consulta_login.Parameters.Add("@profesion", SqlDbType.VarChar, 100).Value = profesion;
            consulta_login.Parameters.Add("@años_experiencia", SqlDbType.SmallInt).Value = anos_e;
            consulta_login.Parameters.Add("@genero", SqlDbType.Char,1).Value = genero;
            consulta_login.Parameters.Add("@clave", SqlDbType.VarChar, 100).Value = num_id;
            consulta_login.Parameters.Add("@ciudad", SqlDbType.VarChar, 100).Value = ciudad;
            consulta_login.Parameters.Add("@foto", SqlDbType.VarBinary,8000).Value = foto;
            consulta_login.Parameters.Add("@titulo", SqlDbType.VarBinary,8000).Value = titulo;
            consulta_login.Parameters.Add("@hoja_de_vida", SqlDbType.VarBinary,8000).Value = hoja_de_vida;
            consulta_login.Parameters.Add("@registrado_por", SqlDbType.BigInt).Value = reg;
            consulta_login.Parameters.Add("@estado", SqlDbType.Char, 1).Value = estado;
            consulta_login.Parameters.Add("@PA", SqlDbType.Char, 1).Value = pas;
            consulta_login.ExecuteNonQuery();
            return 1; 
        }
        public DataTable actualizar_empleados()
        {
            SqlConnection conexion = new SqlConnection(D_conexion.Cc());
            conexion.Open();
            SqlDataAdapter actualizar = new SqlDataAdapter("ConsultaG_u", conexion);
            DataTable tabla = new DataTable();
            actualizar.Fill(tabla);
            conexion.Close();
            return tabla;
        }
        public int actualizar_empleadost(Int64 id, string direccion, string cargo, string ciudad, string E_mail, string prof, Int16 AEXP, string Gen)
        {
            SqlConnection conexion = new SqlConnection(D_conexion.Cc());
            conexion.Open();
            SqlCommand actualizar = new SqlCommand("actualizar_usuario", conexion);
            actualizar.CommandType = CommandType.StoredProcedure;
            actualizar.Parameters.Add("@numero_id", SqlDbType.BigInt).Value = id;
            actualizar.Parameters.Add("@codpost", SqlDbType.VarChar, 100).Value = direccion;
            actualizar.Parameters.Add("@rol", SqlDbType.VarChar, 30).Value = cargo;
            actualizar.Parameters.Add("@ciudad", SqlDbType.VarChar, 100).Value = ciudad;
            actualizar.Parameters.Add("@e_mail", SqlDbType.VarChar, 100).Value = E_mail;
            actualizar.Parameters.Add("@carrera", SqlDbType.VarChar, 100).Value = prof;
            actualizar.Parameters.Add("@AEXP", SqlDbType.SmallInt).Value = AEXP;
            actualizar.Parameters.Add("@genero", SqlDbType.Char, 1).Value = Gen;
            actualizar.ExecuteNonQuery();
            conexion.Close();
            return 1;
            
        }
        public int actualizar_empleadostT(Int64 telid, Int64 tel)
        {
            SqlConnection conexion = new SqlConnection(D_conexion.Cc());
            conexion.Open();
            SqlCommand actualizar = new SqlCommand("actualizar_telefonosusuario", conexion);
            actualizar.CommandType = CommandType.StoredProcedure;
            actualizar.Parameters.Add("@tel", SqlDbType.BigInt).Value = tel;
            actualizar.Parameters.Add("@telid", SqlDbType.BigInt).Value = telid;
            actualizar.ExecuteNonQuery();
            conexion.Close();
            return 1;

        }       
        public int eliminar_empleado(Int64 numero_id, string estado)
        {
            SqlConnection conexion = new SqlConnection(D_conexion.Cc());
            conexion.Open();
            SqlCommand eliminar = new SqlCommand("eliminar_empleados", conexion);
            eliminar.CommandType = CommandType.StoredProcedure;
            eliminar.Parameters.Add("@numero_id", SqlDbType.BigInt).Value = numero_id;
            eliminar.Parameters.Add("@estado", SqlDbType.Char, 1).Value = estado;
            eliminar.ExecuteNonQuery();
            return 1;
            }
        public int insertar_telefono(Int64 telefono,Int64 registrado_por){

            SqlConnection conexion = new SqlConnection(D_conexion.Cc());
                        SqlCommand insertar_telefono = new SqlCommand("InsertarTelefono_u", conexion);
                        insertar_telefono.CommandType = CommandType.StoredProcedure;
                        insertar_telefono.Parameters.Add("@Num_identificacion", SqlDbType.BigInt).Value = telefono;
                        insertar_telefono.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = registrado_por;
                        insertar_telefono.ExecuteNonQuery();
            return 1;
    }
        public int registrar_telefonos( string valores, Int64 codigo)
        {
            SqlConnection conexion = new SqlConnection(D_conexion.Cc());
            conexion.Open();
            SqlCommand insertar_telefono = new SqlCommand("InsertarTelefono_u", conexion);
            insertar_telefono.CommandType = CommandType.StoredProcedure;
            insertar_telefono.Parameters.Add("@RP", SqlDbType.BigInt).Value = codigo;
            insertar_telefono.Parameters.Add("@Telefono", SqlDbType.BigInt).Value = valores;
                        insertar_telefono.ExecuteNonQuery();
            return 1;

        }
}}
