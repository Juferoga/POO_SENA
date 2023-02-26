using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Data;

namespace negocio
{
  public class N_Equipo
    {
      private Int64 e_ID { get; set; }
      private string e_name { get; set; }
      private string e_des { get; set; }
      public int actualizar(Int64 ID, string name, string des) {
          e_ID = ID;
          e_name = name;
          e_des = des;
          D_Equipo LL = new D_Equipo();
          return LL.ACTUALIZAR(e_ID,e_name,e_des);
      
      }
      public DataTable CUC(string nom) {
          
          D_Equipo LL = new D_Equipo();
          return LL.CUCd(nom);
      }
      
      public DataTable ConsultarG_EN()
      {
          D_Equipo instacia = new D_Equipo();
          DataTable Respuesta = instacia.ConsultarGN_E();
          return Respuesta;
      }
      public DataTable CGEm() {
          D_Equipo LL= new D_Equipo();
          LL.CGE();
          return LL.CGE();
      }
      private string n { get; set; }
      private string d { get; set; }
      private Int64 IDD { get; set; }
      public int SaveE(string nom,string des,Int64 IDDv)
      { 
          D_Equipo Ll = new D_Equipo();
          n = nom;
          d = des;
          IDD = IDDv;
        return  Ll.SaveEQ(nom,des,IDDv);
      
      }
      public DataTable CEE(Int64 cod) {
          e_ID = cod;
          D_Equipo PP = new D_Equipo();
       return   PP.cee(e_ID);
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
    }
}
