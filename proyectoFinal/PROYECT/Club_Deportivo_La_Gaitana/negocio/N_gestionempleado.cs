using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;

namespace negocio
{
using Datos;
    public class N_gestionempleado
    {
        private string e_nom { get; set; }
        private Int64 e_numid { get; set; }
        private string e_dir { get; set; }
        private string e_car { get; set; }
        
        private string e_email { get; set; }
        private string e_pro { get; set; }
        private Int16 e_anose { get; set; }
        private string e_gen { get; set; }
        private string e_clave { get; set; }
        private Int64 e_tel1 { get; set; }
        private Int64 e_tel2 { get; set; }
        private string e_ciudad { get; set; }
        private byte[] e_foto { get; set; }
        private byte[] e_titulo { get; set; }
        private byte[] e_hojav { get; set; }
        private Int64 e_regi { get; set; }
        private string e_estado {get;set; }
        private string e_pas { get; set; }

        private Int64 e_telid { get; set; }
        public int ActualizarT(Int64 id, Int64 tel)
        {
            e_numid = id;
            e_tel1 = tel;
            D_gestionempleados i = new D_gestionempleados();
            int LL = i.actualizar_empleadostT(e_numid,e_tel1);
            return LL;
        }
        public int Actualizar(Int64 id,string direccion,string cargo,string ciudad,string E_mail,string prof,Int16 AEXP,string Gen)
        {
            e_numid = id;
            e_dir=direccion;
            e_car = cargo;
            e_ciudad=ciudad;
            e_email=E_mail;
            e_pro = prof;
            e_anose = AEXP;
            e_gen = Gen;

            D_gestionempleados i = new D_gestionempleados();
           int LL = i.actualizar_empleadost(e_numid,e_dir,e_car,e_ciudad,e_email,e_pro,e_anose,e_gen);
            return LL;
        }
        //consulta Telefonos
        public DataTable tels(Int64 cod)
        {
            e_codigo = cod;
            D_gestionempleados instancia = new D_gestionempleados();
            DataTable rta = instancia.TELS(e_codigo);
            return rta;
        }
        //Consulta general eliminados
        public DataTable ConsultaG_eD()
        {
            D_gestionempleados instancia = new D_gestionempleados();
            DataTable Rta = instancia.consultaG_ED();
            return Rta;
        }
        //Consulta General
        public DataTable ConsultaG_e (){
          D_gestionempleados instancia = new D_gestionempleados();
           DataTable Rta = instancia.consultaG_E();
           return Rta;
        }

        //consulta especifica identificacion solo muestra codigo
        private Int64 codigo { get; set; }
        public DataTable CEI(Int64 Cod)
        {
            codigo = Cod;
            D_gestionempleados instancia = new D_gestionempleados();
            DataTable Rta = instancia.cci(codigo);
            return Rta;
        }

        //CE codigo
        private Int64 identificacion { get; set; }
        public DataTable CEC(Int64 id)
        {
            identificacion = id;
            D_gestionempleados instancia = new D_gestionempleados();
            DataTable Rta = new DataTable();
            return Rta  = instancia.cce(identificacion);
            
        }

        //Cosulta codigo por ID
        private Int64 identificaci { get; set; }
        public DataTable CECm(Int64 id)
        {
            identificaci = id;
            D_gestionempleados instancia = new D_gestionempleados();
            return instancia.ccim(identificaci);
            
        }
        //consulta Previa a registro
        private Int64 IDE { get; set; }
        public int CECmi(Int64 id)
        {
            IDE = id;
            D_gestionempleados instancia = new D_gestionempleados();
            return instancia.ccimi(IDE);

        }
        //consulta especifica nombre
        private string nombre { get; set; }
        public DataTable CEn(string nom)
        {
            nombre = nom;
            D_gestionempleados instancia = new D_gestionempleados();
            DataTable Rta = instancia.ccn(nombre);
            return Rta;
        }


        public int registrar(string nom, Int64 num_id, string direccion, string cargo, string e_mail, string profesion, Int16 anos_e, string genero, string clave,string ciudad,byte[] foto, byte[] titulo,byte[] hoja_de_vida,string state,string pa,Int64 Reg)
 
        {
            string L=Convert.ToString(num_id);
        e_nom=nom;
        e_numid=num_id;
        e_dir=direccion;
        e_car=cargo;
        
        e_email=e_mail;
        e_pro=profesion;
        e_anose=anos_e;
        e_gen=genero;
        e_clave = L;
        e_ciudad = ciudad;
        e_foto = foto;
        e_titulo = titulo;
        e_hojav = hoja_de_vida;
        e_estado = state;
        e_pas = pa;
        e_regi = Reg;
        
        
        D_gestionempleados instancia = new D_gestionempleados();
        return instancia.registro_empleado(e_nom = nom, e_numid = num_id, e_dir = direccion, e_car = cargo, e_email = e_mail,
    e_pro = profesion,
    e_anose = anos_e,
    e_gen = genero,
    e_clave = clave,e_ciudad=ciudad,e_foto,e_titulo,e_hojav,e_estado,e_pas,e_regi);
        

        }
        public DataTable encapsular()
        {
            D_gestionempleados instancia = new D_gestionempleados();

            return instancia.actualizar_empleados();
        }

        public int eliminar(Int64 numero_id, string estado)
        {
            D_gestionempleados instancia = new D_gestionempleados();
            return instancia.eliminar_empleado(numero_id, estado);

        }
        private Int64 e_codigo { get; set; }
        private Int64 e_telefo { get; set; }
        //POTTES ?


        private Int64 e_id { get; set; }
        
        
        public DataTable rta(Int64 cod ) {
            e_id = cod;
            D_gestionempleados TT = new D_gestionempleados();
            return TT.Email(cod);
        }   
        

        private Int64 e_telefono { get; set; }
        private Int64 e_regpor { get; set; }
        public int insertar_t(Int64 telefonos,Int64 registrado_por){
            e_telefono=telefonos;
            e_regpor= registrado_por;
        D_gestionempleados instancia = new D_gestionempleados();
            return instancia.insertar_telefono(telefonos,registrado_por);
                 
    
         
}
        private Int64 e_ide { get; set; }
        public DataTable rta1(Int64 cod)
        {
            e_ide = cod;
            D_gestionempleados TT = new D_gestionempleados();
            return TT.Email(cod);
        }

       
        private string e_tels { get; set; }
        private Int64 e_RP { get; set; }
        private Int64 e_ID { get; set; }
        public int regtels( string tels,Int64 RP,Int64 ID)
        {
            e_RP = RP;
            e_ID = ID;
            e_tels = tels;
            D_gestionempleados instancia = new D_gestionempleados();
            return instancia.registrar_telefonos( e_tels,e_RP);
        }
        //Consulta Nombre
        public DataTable CECmq(Int64 id)
        {
            D_gestionempleados instancia = new D_gestionempleados();
            return instancia.ccimq(id);

        }

        
        public DataTable CECn(Int64 id)
        {
            identificacion = id;
            D_gestionempleados instancia = new D_gestionempleados();
            DataTable Rta = new DataTable();
            return Rta = instancia.ceemn(identificacion);

        }

        public N_Login N_Login
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public N_CambioClave N_CambioClave
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public N_Equipo N_Equipo
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public N_Jugador N_Jugador
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        internal N_Recovery N_Recovery
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public N_Test N_Test
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public N_Seguimiento N_Seguimiento
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }


    }
}
