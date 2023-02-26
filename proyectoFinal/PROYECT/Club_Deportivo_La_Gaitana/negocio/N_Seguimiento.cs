using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace negocio
{
    public class N_Seguimiento
    {
        private Int64 e_cod { get; set; }
        private string e_tipo { get; set; }
        private string e_valoracion { get; set; }
        private Double e_puntaje { get; set; }
        private Int64 e_codM { get; set; }
        private Int64 e_codT { get; set; }
        private Int64 e_reg { get; set; }

        public DataTable CGS()
        {
            D_Seguimiento CG = new D_Seguimiento();
            return CG.CGD();
        }
        public int Registrar(string tipo, string valoracion, Double puntaje, Int64 codM, Int64 codT, Int64 regpor)
        {
            e_reg = Convert.ToInt64(regpor);
            e_tipo = tipo;
            e_valoracion = valoracion;
            e_puntaje = puntaje;
            e_codM = codM;
            e_codT = codT;
            e_reg = regpor;
            D_Seguimiento PP = new D_Seguimiento();
            return PP.REGISTRAR(e_tipo, e_valoracion, e_puntaje, Convert.ToInt64(e_codM), Convert.ToInt64(e_codT), e_reg);
        }
        public int Actualizar(Int64 cod, string tipo, string valoracion, Double puntaje, Int64 codM, Int64 codT)
        {
            e_cod = cod;
            e_tipo = tipo;
            e_valoracion = valoracion;
            e_puntaje = puntaje;
            e_codM = codM;
            e_codT = codT;
            D_Seguimiento PP = new D_Seguimiento();
            return PP.ACTUALIZAR(e_cod, e_tipo, e_valoracion, e_puntaje, e_codM, e_codT);
        }
        public DataTable CC(Int64 cod)
        {
            e_cod = cod;
            D_Seguimiento instancia = new D_Seguimiento();
            return instancia.cc(e_cod);
        }
        public DataTable CCM(Int64 cod)
        {
            e_codM = cod;
            D_Seguimiento instancia = new D_Seguimiento();
            return instancia.ccm(e_codM);
        }
        public DataTable CCT(Int64 codT)
        {
            e_codT = codT;
            D_Seguimiento instancia = new D_Seguimiento();
            return instancia.cct(e_codT);
        
        }
        public DataTable mejor(Int64 cod)
        {
            e_codT = cod;
            D_Seguimiento instancia = new D_Seguimiento();
            return instancia.mejor(e_codT);
        }
        public DataTable bajo(Int64 cod)
        {
            e_codT = cod;
            D_Seguimiento instancia = new D_Seguimiento();
            return instancia.bajo(e_codT);
        }
    }
}
