using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;

namespace negocio
{
   public class N_CambioClave
    {
       private Int64 e_Clave { set; get;}

       public int CambioC(Int64 CC) 
       { 

       D_CambioClave instancia=new D_CambioClave();
           e_Clave = CC;

        return instancia.CambioClave(e_Clave);
       
       }

       private string e_Claven { set; get; }

       private Int64 e_User { set; get; }
       
       public int Cambio(string CC,Int64 usuario)
       {

           D_CambioClave instancia = new D_CambioClave();
           e_Claven = CC;
           e_User = usuario;
           return instancia.CambioC(e_Claven, e_User);

       }
    }
}
