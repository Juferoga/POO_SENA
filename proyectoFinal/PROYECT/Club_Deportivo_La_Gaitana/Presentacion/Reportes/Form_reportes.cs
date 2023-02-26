using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Presentacion.Reportes
{
    public partial class Form_reportes : Form
    {
        public Form_reportes()
        {
            InitializeComponent();
        }
        public DataSet Nuevo;

        private void Form_reportes_Load(object sender, EventArgs e)
        {
            CrystalReport1 Imprimir = new CrystalReport1();
            Imprimir.SetDataSource(Nuevo);
            crystalReportViewer1.ReportSource = Imprimir;



        }

        private void Form_reportes_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
        
    }
}
