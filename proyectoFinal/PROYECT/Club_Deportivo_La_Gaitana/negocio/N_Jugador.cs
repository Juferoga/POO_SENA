using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.IO;


namespace negocio
{
   public class N_Jugador
    {
       private Int64 e_TI { get; set; }
       private string e_nom { get; set; }
       private Int64 e_tel { get; set; }
       private string e_dir { get; set; }
       private double e_talla { get; set; }
       private double e_peso { get; set; }
       private DateTime e_f { get; set; }
       private Int64 e_regpor { get; set; }
       private Int64 e_cod { get; set; }

       private Int64 IDE { get; set; }
       public int CECmi(Int64 id)
       {
           IDE = id;
           D_Jugador instancia = new D_Jugador();
           return instancia.ccimi(IDE);

       }
       //Cosulta codigo por ID
       private Int64 identificaci { get; set; }
       public DataTable CECm(Int64 id)
       {
           identificaci = id;
           D_Jugador instancia = new D_Jugador();
           return instancia.ccim(identificaci);

       }

       public DataTable CETI(Int64 TI)
       {
           e_TI = TI;
           D_Jugador instancia = new D_Jugador();
           return instancia.ccimTI(e_TI);

       }
       public DataTable CEDMTR(Int64 id)
       {
           identificaci = id;
           D_Jugador instancia = new D_Jugador();
           return instancia.ccimCod(identificaci);

       }
       //consulta especifica nombre
       private string nombre { get; set; }
       public DataTable CEn(string nom)
       {
           nombre = nom;
           D_Jugador instancia = new D_Jugador();
           DataTable Rta = instancia.ccn(nombre);
           return Rta;
       }

       public DataTable ConsultarG_jLLP(Int64 ID)
       {
           e_TI=ID;
           D_Jugador instacia = new D_Jugador();
           DataTable Respuesta = instacia.ConsultaGCU_JLLP(e_TI);
           return Respuesta;
       }
       public int Actualizar(Int64 Cod,string dir,Double talla,Double peso,Int64 tel ) {
           e_cod = Cod;
           e_dir = dir;
           e_talla = talla;
           e_peso = peso;
           e_tel = tel;
           D_Jugador instancia = new D_Jugador();
           return instancia.ACTUALIZAR(e_cod,e_dir,e_talla,e_peso,e_tel);
       }
       public DataTable ConsultarG_jLLM()
       {
           D_Jugador instacia = new D_Jugador();
           DataTable Respuesta = instacia.ConsultaGCU_JLLM();
           return Respuesta;
       }
       public DataTable ConsultarG_jLL()
       {
           D_Jugador instacia = new D_Jugador();
           DataTable Respuesta = instacia.ConsultaGCU_JLL();
           return Respuesta;
       }

       public DataTable ConsultarG_j()
       {
           D_Jugador instacia = new D_Jugador();
           DataTable Respuesta = instacia.ConsultaG_J(); 
                return Respuesta;
       }
   
       private Int64 e_TIm { get; set; }
       private Int64 e_CU { get; set; }
       private Int64 e_CE { get; set; }

       public int registrom(Byte[] foto2, Byte[] foto3, Byte[] foto4, Byte[] foto5, Int64 TI, Int64 CE, Int64 CU)
       {
           e_TIm = TI;
           e_CU = CU;
           e_CE = CE;
           D_Jugador LL = new D_Jugador();
           return LL.registrom(foto2, foto3, foto4, foto5,e_TIm,e_CE,e_CU);
       }
       public int registro(string TI, string nom, Int64 tel, string dir, double talla, double peso, DateTime f, Byte[] foto, Int64 regpor)
       {
           e_TI = Convert.ToInt64(TI);
           e_nom = nom;
           e_tel = tel;
           e_talla = talla;
           e_peso = peso;
           e_f = f;
           e_regpor = regpor;
           e_dir = dir;
           

           D_Jugador LL = new D_Jugador();
           return  LL.registro(e_TI, e_nom, e_tel,e_dir, e_talla, e_peso, e_f, foto, e_regpor);

       }
       public DataTable CECU() {
           
           D_Jugador instancia=new D_Jugador();
           return instancia.ConsultaGCU_J();
       }
       public DataTable CMat()
       {

           D_Jugador instancia = new D_Jugador();
           return instancia.CMAT();
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
