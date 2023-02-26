using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.IO;

namespace negocio
{
    public class N_Login
    {
        public MemoryStream Pp(Int64 cod){
            D_Login i = new D_Login();
            return i.LL(cod);
        }
        
        private string e_cargo { get; set; }
        private Int64 e_nusuario { get; set; }
        private string e_clave { get; set; }
        private Int64 e_usuario { get; set; }

        public int acceso(Int64 n_nusuario, string clave, string cargo )
        {
            e_cargo = cargo;
            e_nusuario= n_nusuario;
            e_clave = clave;
            
            
            D_Login instancia = new D_Login();
            return instancia.consulta_G4(e_nusuario, e_clave, e_cargo);
            }
       
        
        
        public int PAS (Int64 usuario){
            
            e_usuario = usuario;
            D_Login instancia = new D_Login();
            return instancia.PA(e_usuario);

        
        }
    }
}
