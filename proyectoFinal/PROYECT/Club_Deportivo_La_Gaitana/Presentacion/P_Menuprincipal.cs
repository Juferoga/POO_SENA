using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using negocio;

namespace Presentacion
{
    public partial class P_Menuprincipal : Form
    {
        public P_Menuprincipal()
        {
            InitializeComponent();
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToShortDateString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {



        }

        private void btnventas_Click(object sender, EventArgs e)
        {
            P_empleados_ad menu1 = new P_empleados_ad();
            menu1.label10.Text = label4.Text;
            menu1.Show();
        }

        private void btncompras_Click(object sender, EventArgs e)
        {
            P_Test menu2 = new P_Test();
            menu2.lblcod.Text = label4.Text;
            menu2.Show();
        }

        private void btnclientes_Click(object sender, EventArgs e)
        {
            P_Jugador menu3 = new P_Jugador();
            menu3.lbl_cod.Text = label4.Text;
            menu3.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            P_Equipo menu4 = new P_Equipo();
            menu4.label6.Text = label4.Text;
            menu4.Show();
        }

        private void btnproveedores_Click(object sender, EventArgs e)
        {
            P_segimiento menu5 = new P_segimiento();
            menu5.label8.Text = label4.Text;
            menu5.Show();
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            P_Equipo menu4 = new P_Equipo();
            menu4.label6.Text = label4.Text;
            menu4.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            P_login Cierre = new P_login();
            Cierre.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblhora_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            lblhora.Text = DateTime.Now.ToLongTimeString();
            lblfecha.Text = DateTime.Now.ToShortDateString();
        }

        private void P_Menuprincipal_Load(object sender, EventArgs e)
        {

            if (lblcargo.Text == "entrenador")
            {
                btnventas.Visible = false;
                label5.Visible = false;
            }
            else {
            if(lblcargo.Text=="secretaria"){
                btnventas.Visible = false;
                label5.Visible = false;
                btncompras.Visible = false;
                label9.Visible = false;
            }
            Size desktopSize = System.Windows.Forms.SystemInformation.PrimaryMonitorSize; //Captura el Tamaño del Monitor
            panel3.Location = new Point((desktopSize.Width - panel3.Width) / 2, (desktopSize.Height - panel3.Height) / 2);

            }
            
            N_gestionempleado codigo = new N_gestionempleado();
            
            DataTable d = new DataTable();
            
            d = codigo.CEI(Convert.ToInt64(label3.Text));
            
            dataGridView1.DataSource = d;
            try
            {
                label4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            }
            catch {
                label4.Text = "1";
            }
            
                
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            P_About YY = new P_About();
            YY.Show();
        }

        private void P_Menuprincipal_AutoSizeChanged(object sender, EventArgs e)
        {
            

        }

        private void P_Menuprincipal_Resize(object sender, EventArgs e)
        {
            panel3.Left = (this.Width - panel3.Width)/2 ;
            panel3.Top = (this.Height - panel3.Height) /2; 
        }
    }
}
