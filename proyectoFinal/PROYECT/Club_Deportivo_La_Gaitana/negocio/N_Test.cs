using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;

namespace negocio
{
    public class N_Test
    {
        private string IDE { get; set; }
        public int CECmi(string id)
        {
            IDE = id;
            D_Test instancia = new D_Test();
            return instancia.ccimi(IDE);

        }
        public DataTable busquedagen()
        {
            D_Test LL = new D_Test();
            return LL.busquedaGn();

        }
        public DataTable busquedage() {
            D_Test LL = new D_Test();
            return LL.busquedaG();
            
        }
        private string e_nom { get; set; }
        private string e_UDM { get; set; }
        private Int16 e_min { get; set; }
        private Int16 e_max { get; set; }
        private Int16 e_prom { get; set; }
        private Int64 e_reg { get; set; }

        public int actualizar(string dato,Int16 PP,Int16 Pm,Int16 PM,Int64 cod) {
            e_reg = cod;
            e_UDM = dato;
            e_prom = PP;
            e_min = Pm;
            e_max = PM;
            D_Test instancia = new D_Test();
           return instancia.ACTUALIZAR(e_UDM,e_prom,e_min,e_max,e_reg);
        }

        public int registro(string n,string um,Int16 min,Int16 max,Int16 prom,Int64 Reg) {
            e_nom = n;
            e_UDM = um;
            e_min = min;
            e_max = max;
            e_prom = prom;
            e_reg = Reg;
            D_Test instancia=new D_Test();
           return instancia.Registrar(e_nom,e_UDM,e_min,e_max,e_prom,e_reg);
        }

        private Int64 e_cod { get; set; }
        private string e_id { get; set; }
        private string e_nome { get; set; }
        
        public DataTable CEC(Int64 cod) {
            e_cod = cod;
            D_Test LL = new D_Test();
            return LL.cec(e_cod);
        }
        public DataTable CED(string id) {
            e_id = id;
            D_Test LL = new D_Test();
            return LL.ced(e_id);
        }
        public DataTable CEN(string nom) {
            e_nome = nom;
            D_Test LL = new D_Test();
            return LL.cen(e_nome);
        }
        public DataTable CECU()
        {

            D_Test instancia = new D_Test();
            return instancia.ConsultaGCU_J();
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
