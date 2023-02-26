using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using negocio;
using System.Data.SqlClient;
using System.IO;



namespace Presentacion
{
    public partial class P_login : Form
    {
        public P_login()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" ) 
            {
                MessageBox.Show("campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                else {
                
                N_Login instancia = new N_Login();
                int dato = instancia.acceso(Convert.ToInt64(textBox1.Text), textBox2.Text, comboBox1.Text);
                if (dato == 1)
                {
                    N_Login i = new N_Login();
                    int res = i.PAS(Convert.ToInt64(textBox1.Text));
                    if (res == 1)
                    {
                        
                        P_CambioClave cam = new P_CambioClave();
                        cam.lblcargo.Text = comboBox1.Text;
                        cam.label3.Text = textBox1.Text;
                        cam.Show();

                        this.Hide();
                    }
                    else {
                  
                        P_Menuprincipal TT = new P_Menuprincipal();
                        TT.lblcargo.Text = comboBox1.Text;
                        TT.label3.Text = textBox1.Text;
                        TT.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("error de acceso,verifique sus datos");
                    Application.Restart();
                }
            }
            
        }

        private void P_login_Load(object sender, EventArgs e)
        {
            button3.Visible = true;

            label5.Text = DateTime.Now.ToShortDateString();
            label6.Text = DateTime.Now.ToLongTimeString();
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            P_Recovery TT = new P_Recovery();
            TT.Show();
            this.Hide();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label5.Text = DateTime.Now.ToShortDateString();
            label6.Text = DateTime.Now.ToLongTimeString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validacion campo numerico

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Campo numérico", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                try
                {
                    try
                    {
                        N_Login QQ = new N_Login();
                        
                        pictureBox1.Image = Image.FromStream(QQ.Pp(Convert.ToInt64(textBox1.Text)));
                    }
                    catch {
                    
                    }
                    try
                    {
                        N_gestionempleado instancia = new N_gestionempleado();
                        DataTable res = instancia.CECmq(Convert.ToInt64(textBox1.Text));
                        dataGridView1.DataSource = res;

                        label7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    }
                    catch { 
                    
                    }
                    pictureBox1.Location = new Point(337, 190);
                    label7.Visible = true;
                    linkLabel2.Visible = true;

                    button5.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button1.Visible = true;
                    button4.Visible = true;

                    label1.Visible = false;
                    textBox1.Visible = false;

                    label2.Visible = true;
                    textBox2.Visible = true;

                    textBox2.Focus();
                }
                catch
                {

                    pictureBox1.Location = new Point(337, 190);
                    label7.Visible = true;
                    linkLabel2.Visible = true;

                    label7.Text = textBox1.Text;
                    button5.Visible = false;
                    button2.Visible = false;
                    button3.Visible = false;
                    button1.Visible = true;
                    button4.Visible = true;

                    label1.Visible = false;
                    textBox1.Visible = false;

                    label2.Visible = true;
                    textBox2.Visible = true;

                    textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                button4.Visible = true;
                button5.Visible = true;

                label2.Visible = false;
                textBox2.Visible = false;

                label3.Visible = true;
                comboBox1.Visible = true;
                comboBox1.Focus();
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("campos obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                N_Login instancia = new N_Login();
                int dato = instancia.acceso(Convert.ToInt64(textBox1.Text), textBox2.Text, comboBox1.Text);
                if (dato == 1)
                {
                    N_Login i = new N_Login();
                    
                    int res = i.PAS(Convert.ToInt64(textBox1.Text));
                    if (res == 1)
                    {

                        P_CambioClave cam = new P_CambioClave();
                        cam.label3.Text = textBox1.Text;
                        cam.lblcargo.Text = comboBox1.Text;
                        cam.Show();

                        this.Hide();
                    }
                    else
                    {

                        P_Menuprincipal TT = new P_Menuprincipal();
                        TT.label3.Text = textBox1.Text;
                        TT.lblcargo.Text = comboBox1.Text;
                        TT.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("error de acceso,verifique sus datos");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            try
            {
                try
                {

                    N_Login QQ = new N_Login();
                                 

                    pictureBox1.Image = Image.FromStream(QQ.Pp(Convert.ToInt64(textBox1.Text)));
                }
                catch { }
                try
                {
                    N_gestionempleado instancia = new N_gestionempleado();
                    DataTable res = instancia.CECmq(Convert.ToInt64(textBox1.Text));
                    dataGridView1.DataSource = res;

                    label7.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }
                catch {
                
                }
                pictureBox1.Location = new Point(337, 190);
                label7.Visible = true;
                linkLabel2.Visible = true;

                button5.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button1.Visible = true;
                button4.Visible = true;

                label1.Visible = false;
                textBox1.Visible = false;

                label2.Visible = true;
                textBox2.Visible = true;

                textBox2.Focus();
            }
            catch {

                pictureBox1.Location = new Point(337, 190);
                label7.Visible = true;
                linkLabel2.Visible = true;

                label7.Text = textBox1.Text;
                button5.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button1.Visible = true;
                button4.Visible = true;

                label1.Visible = false;
                textBox1.Visible = false;

                label2.Visible = true;
                textBox2.Visible = true;

                textBox2.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = true;

            label2.Visible = false;
            textBox2.Visible = false;

            label3.Visible = true;
            comboBox1.Visible = true;
            comboBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(192, 168);
            label7.Text = textBox1.Text;
            label7.Visible = false;
            linkLabel2.Visible = true;

            button4.Visible = false;
            button5.Visible = false;
            button3.Visible = true;
            button1.Visible = false;
            button2.Visible = false;

            comboBox1.Visible = false;
            label3.Visible = false;

            label1.Visible = true;
            textBox1.Visible = true;

            label2.Visible = false;
            textBox2.Visible = false;

            textBox1.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button1.Visible = true;
            button4.Visible = true;
            comboBox1.Visible = false;
            label3.Visible = false;

            label1.Visible = false;
            textBox1.Visible = false;

            label2.Visible = true;
            textBox2.Visible = true;

            textBox2.Focus();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void P_login_Resize(object sender, EventArgs e)
        {
            panel1.Left = (this.Width - panel1.Width) / 2;
            panel1.Top = (this.Height - panel1.Height) / 2;
            pictureBox2.Left = (this.Width - pictureBox2.Width) / 2;
        }



      
    }
}
