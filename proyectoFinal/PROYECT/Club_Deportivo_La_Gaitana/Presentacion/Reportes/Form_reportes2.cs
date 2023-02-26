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
    public partial class Form_reportes2 : Form
    {
        public Form_reportes2()
        {
            InitializeComponent();
        }
        public DataSet Nuevo;

        private void Form_reportes2_Load(object sender, EventArgs e)
        {
            CrystalReport2 Imprimir = new CrystalReport2();
            Imprimir.SetDataSource(Nuevo);
            crystalReportViewer1.ReportSource = Imprimir;
        }
    }
}
