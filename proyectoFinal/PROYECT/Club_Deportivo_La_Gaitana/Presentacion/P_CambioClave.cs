using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using negocio;
using System.Net;
using System.Net.Mail;


namespace Presentacion
{
    public partial class P_CambioClave : Form
    {
        public P_CambioClave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text){ 
            
            N_CambioClave instancia = new N_CambioClave();
            Int64 L = instancia.CambioC(Convert.ToInt64( label3.Text));
            if (L == 1)
            {
                N_CambioClave instan = new N_CambioClave();
                int LL = instancia.Cambio(textBox2.Text, Convert.ToInt64(label3.Text));
                if (LL == 1)
                {
                    MessageBox.Show(" Bienvenido ", "Sport-Ware", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    P_Menuprincipal TT = new P_Menuprincipal();
                    TT.label3.Text = label3.Text;
                    TT.lblcargo.Text = lblcargo.Text;
                    TT.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("ERROR","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            }
            else{
                MessageBox.Show("Las Contraseñas No Coinciden", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_Menuprincipal m = new P_Menuprincipal();
            m.label3.Text = label3.Text;
            m.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                button1.Focus();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToLongTimeString();
        }
    }
    }

