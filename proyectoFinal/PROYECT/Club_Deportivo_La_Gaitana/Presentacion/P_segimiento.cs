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
    public partial class P_segimiento : Form
    {
        public P_segimiento()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Los Campos Son Obligatorios", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                N_Seguimiento MM = new N_Seguimiento();
                MM.Registrar(comboBox1.Text, textBox2.Text, Convert.ToDouble(numericUpDown1.Value), Convert.ToInt64(label4.Text), Convert.ToInt64(label7.Text), Convert.ToInt64(label8.Text));
                MessageBox.Show("Registrado Exitoso", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);

                numericUpDown1.Value = 0;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            N_Seguimiento CG = new N_Seguimiento();
            DataTable LL;
            LL = CG.CGS();
            dataGridView1.DataSource = LL;
        }

        private void P_segimiento_Load(object sender, EventArgs e)
        {
            N_gestionempleado instancia = new N_gestionempleado();
            DataTable LL = instancia.CEC(Convert.ToInt64(label8.Text));
            dataGridView1.DataSource = LL;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            N_Jugador instacia = new N_Jugador();
            DataTable Rta = instacia.ConsultarG_jLL();
            dataGridView2.DataSource = Rta;

            panel1.Visible = true;

            dataGridView1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;

            N_Test ll = new N_Test();
            DataTable PP = new DataTable();
            PP = ll.busquedage();

            dataGridView3.DataSource = PP;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            N_Seguimiento CG = new N_Seguimiento();
            DataTable LL;
            LL = CG.CGS();
            dataGridView1.DataSource = LL;
            dataGridView1.Visible = true;
            panel2.Visible = true;
            panel1.Visible = false;
            panel4.Visible = false;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            N_Seguimiento CG = new N_Seguimiento();
            DataTable LL;
            LL = CG.CGS();
            dataGridView1.DataSource = LL;
            panel4.Visible = true;
            dataGridView1.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;

            N_Jugador nombres = new N_Jugador();
            DataTable g4 = nombres.CMat();
            comboBox5.ValueMember = "codigo";
            comboBox5.DataSource = g4;

            N_Test instan = new N_Test();
            DataTable PP = instan.CECU();
            comboBox7.ValueMember = "codigo";
            comboBox7.DataSource = PP;


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            numericUpDown10.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            comboBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            N_Seguimiento plop = new N_Seguimiento();
            int ToT = plop.Actualizar(Convert.ToInt64(textBox9.Text), comboBox6.Text,comboBox3.Text, Convert.ToDouble(numericUpDown10.Value), Convert.ToInt64(comboBox5.Text), Convert.ToInt64(comboBox7.Text));
            N_Seguimiento CG = new N_Seguimiento();
            if (ToT == 1)
            {
                MessageBox.Show("Segumiento actualizado con éxito", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DataTable LL;
            LL = CG.CGS();
            dataGridView1.DataSource = LL;
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Código")
            {

                label20.Text = "Código:";
                label20.Visible = true;
                textBox13.Visible = true;
            }
            else
            {
                if (comboBox4.Text == "Código Matricula")
                {

                    label20.Text = "Código Matricula:";
                    label20.Visible = true;
                    textBox13.Visible = true;
                }
                else
                {

                    if (comboBox4.Text == "Código Test")
                    {

                        label20.Text = "Código Test:";
                        label20.Visible = true;
                        textBox13.Visible = true;
                    }
                    
                        else
                        {
                            try
                            {
                                if (comboBox4.Text == "Alto")
                                {
                                    N_Seguimiento instancia = new N_Seguimiento();
                                    DataTable res = instancia.mejor(Convert.ToInt64(textBox13.Text));
                                    dataGridView1.DataSource = res;
                                }
                                else
                                {
                                    if (comboBox4.Text == "Bajo")
                                    {
                                        N_Seguimiento instancia = new N_Seguimiento();
                                        DataTable res = instancia.bajo(Convert.ToInt64(textBox13.Text));
                                        dataGridView1.DataSource = res;
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }

           
            }
        

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.Text == "Código")
                {
                    N_Seguimiento instancia = new N_Seguimiento();
                    DataTable res=instancia.CC(Convert.ToInt64(textBox13.Text));
                    dataGridView1.DataSource = res;
                }
                else
                {
                    if (comboBox4.Text == "Código Matricula")
                    {
                        N_Seguimiento instancia = new N_Seguimiento();
                        DataTable res = instancia.CCM(Convert.ToInt64(textBox13.Text));
                        dataGridView1.DataSource = res;
                        textBox13.Clear();
                    }
                    else
                    {

                        if (comboBox4.Text == "Código Test")
                        {
                            N_Seguimiento instancia = new N_Seguimiento();
                            DataTable res = instancia.CCT(Convert.ToInt64(textBox13.Text));
                            dataGridView1.DataSource = res;
                            textBox13.Clear();
                        }
                        
                            else
                            {
                                textBox13.Clear();
                            }
                            if (comboBox4.Text == "Alto")
                            {
                                N_Seguimiento instancia = new N_Seguimiento();
                                DataTable res = instancia.mejor(Convert.ToInt64(textBox13.Text));
                                dataGridView1.DataSource = res;
                            }
                            else
                            {
                                if (comboBox4.Text == "Bajo")
                                {
                                    N_Seguimiento instancia = new N_Seguimiento();
                                    DataTable res = instancia.bajo(Convert.ToInt64(textBox13.Text));
                                    dataGridView1.DataSource = res;
                                }
                            }
                        }
                    }

                }
            
            catch
            {
                MessageBox.Show("No Se Encontro El Registro ", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            ////N_Test nuevo = new N_Test();
            ////DataTable res = nuevo.CUC(comboBox1.Text);
            //dataGridView2.DataSource = res;
            //try
            //{
            //    label3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            //}
            //catch { }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label7.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label11.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            N_Jugador instacia = new N_Jugador();
            DataTable Rta = instacia.ConsultarG_jLLP(Convert.ToInt64(label11.Text));
            dataGridView4.DataSource = Rta;
            try
            {
                label4.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Este Jugador no Posee número de Matricula", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                N_gestionempleado instancia = new N_gestionempleado();
                DataTable LL = instancia.CECn(Convert.ToInt64(label8.Text));
                dataGridView5.DataSource = LL;
                label40.Text = dataGridView5.CurrentRow.Cells[0].Value.ToString();
            }
            catch { }


            label39.Text = DateTime.Now.ToLongTimeString();
            try
            {
                if (Convert.ToInt16(label7.Text) < 7)
                {
                    comboBox1.Text = "Físico";
                    comboBox1.Enabled = false;
                    linkLabel1.Visible = true;
                }
                else
                {
                    if (Convert.ToInt16(label7.Text) < 14)
                    {
                        comboBox1.Text = "Técnico";
                        comboBox1.Enabled = false;
                        linkLabel1.Visible = true;
                    }
                    else
                    {
                        comboBox1.Enabled = true;
                        linkLabel1.Visible = false;
                    }

                }
                if (label7.Text == "label7")
                {
                    linkLabel1.Enabled = false;
                }
                else
                {
                    linkLabel1.Enabled = true;
                }
            }
            catch { }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Int16 b;
            b=Convert.ToInt16( label7.Text);
            tabControl1.Visible = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            switch (b) {
                case 1:
                    tabControl1.SelectedTab = tabPage1;
                    break;
                case 2:
                    tabControl1.SelectedTab = tabPage2;
                    break;
                case 3:
                    tabControl1.SelectedTab = tabPage3;
                    break;
                case 4:
                    tabControl1.SelectedTab = tabPage4;
                    break;
                case 5:
                    tabControl1.SelectedTab = tabPage5;
                    break;
                case 6:
                    tabControl1.SelectedTab = tabPage6;
                    break;
                case 7:
                    tabControl1.SelectedTab = tabPage7;
                    break;
                case 8:
                    tabControl1.SelectedTab = tabPage8;
                    break;
                case 9:
                    tabControl1.SelectedTab = tabPage9;
                    break;
                case 10:
                    tabControl1.SelectedTab = tabPage10;
                    break;
                case 11:
                    tabControl1.SelectedTab = tabPage11;
                    break;
                case 12:
                    tabControl1.SelectedTab = tabPage12;
                    break;
                case 13:
                    tabControl1.SelectedTab = tabPage13;
                    break;              
                    
            }

        }



        private void button15_Click(object sender, EventArgs e)
        {
            N_gestionempleado instancia = new N_gestionempleado();
            DataTable LL = instancia.CECn(Convert.ToInt64(Convert.ToInt64(label8.Text)));
            dataGridView1.DataSource = LL;
        }
        
        
        Reportes.DataSet1 datos = new Reportes.DataSet1();
       
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            datos.Clear();
                for (int co = 0; co < dataGridView1.Rows.Count; co++)
                {
                    Reportes.DataSet1.DataTable1Row fila = datos.DataTable1.NewDataTable1Row();
                    fila.Codigo = dataGridView1.Rows[co].Cells[0].Value.ToString();
                    fila.Tipo = dataGridView1.Rows[co].Cells[1].Value.ToString();
                    fila.Valoracion = dataGridView1.Rows[co].Cells[2].Value.ToString();
                    fila.Puntaje = dataGridView1.Rows[co].Cells[3].Value.ToString();
                    fila.Matricula = dataGridView1.Rows[co].Cells[4].Value.ToString();
                    fila.Test = dataGridView1.Rows[co].Cells[5].Value.ToString();
                    datos.DataTable1.Rows.Add(fila);
                    
                }
                Reportes.Form_reportes Abrir = new Reportes.Form_reportes();
                Abrir.Nuevo = datos;
                
                Abrir.Show();
                
            
            }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown2.Value >= 48 && numericUpDown2.Value <= 51)
            {
                label12.Text = "Se recomienda puntaje de 75 en adelante";
                textBox2.Text = "Excelente";
                textBox2.Show();
            }
            else
            {
                if (numericUpDown2.Value >= 40 && numericUpDown2.Value <= 46)
                {
                    label12.Text = "Se recomienda puntaje de 50 a 75";
                    textBox2.Text = "Buena";
                    textBox2.Show();
                }
                else
                {
                    if (numericUpDown2.Value >= 35 && numericUpDown2.Value <= 39)
                    {
                        label12.Text = "Se recomienda puntaje de 25 a 50";
                        textBox2.Text = "Regular";
                        textBox2.Show();
                    }
                    else
                    {
                        if (numericUpDown2.Value >= 25 && numericUpDown2.Value <= 34)
                        {
                            label12.Text = "Se recomienda puntaje de 0 a 25";
                            textBox2.Text = "Mala";
                            textBox2.Show();
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (numericUpDown4.Value >= 76 && numericUpDown4.Value <= 83)
            {
                label12.Text = "Se recomienda puntaje de 75 a 100";
                textBox2.Text = "Excelente";
                textBox2.Show();
            }
            else
            {
                if (numericUpDown4.Value >= 65 && numericUpDown4.Value <= 75)
                {
                    label12.Text = "Se recomienda puntaje de 50 a 75";
                    textBox2.Text = "Buena";
                    textBox2.Show();
                }
                else
                {
                    if (numericUpDown4.Value >= 58 && numericUpDown4.Value <= 64)
                    {
                        label12.Text = "Se recomienda puntaje de 25 a 50";
                        textBox2.Text = "Regular";
                        textBox2.Show();
                    }
                    else
                    {
                        if (numericUpDown4.Value >= 44 && numericUpDown4.Value <= 57)
                        {
                            label12.Text = "Se recomienda puntaje de 0 a 25";
                            textBox2.Text = "Mala";
                            textBox2.Show();
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (numericUpDown6.Value >= 18 && numericUpDown6.Value <= 21)
            {
                label12.Text = "Se recomienda puntaje de 75 a 100";
                textBox2.Text = "Excelente";
                textBox2.Show();
            }
            else
            {
                if (numericUpDown6.Value >= 22 && numericUpDown6.Value <= 25)
                {
                    label12.Text = "Se recomienda puntaje de 50 a 75";
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown6.Value = numericUpDown1.Value;
                }
                else
                {
                    if (numericUpDown6.Value >= 26 && numericUpDown6.Value <= 29)
                    {
                        label12.Text = "Se recomienda puntaje de 25 a 50";
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown6.Value = numericUpDown1.Value;
                    }
                    else
                    {
                        if (numericUpDown6.Value >= 30 && numericUpDown6.Value <= 50)
                        {
                            label12.Text = "Se recomienda puntaje de 0 a 25";
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown6.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (numericUpDown7.Value >= 4 && numericUpDown7.Value <= 5)
            {
             label12.Text = "Se recomienda puntaje de 75 a 100";
                textBox2.Text = "Excelente";
                textBox2.Show();
                numericUpDown7.Value = numericUpDown1.Value;
            }
            else
            {
                
                if (numericUpDown7.Value >= 6 && numericUpDown7.Value <= 7)
                {
                    label12.Text = "Se recomienda puntaje de 50 a 75";
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown7.Value = numericUpDown1.Value;
                }
                else
                {
                    
                    if (numericUpDown7.Value >= 8 && numericUpDown7.Value <= 9)
                    {
                        label12.Text = "Se recomienda puntaje de 25 a 50";
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown7.Value = numericUpDown1.Value;
                    }
                    else
                    {
                    
                        if (numericUpDown7.Value >= 9 && numericUpDown7.Value <= 15)
                        {
                            label12.Text = "Se recomienda puntaje de 0 a 25";
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown7.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (numericUpDown8.Value >= 71 && numericUpDown8.Value <= 76)
            {
                label12.Text = "Se recomienda puntaje de 75 a 100"; 
                textBox2.Text = "Excelente";
                textBox2.Show();
                numericUpDown8.Value = numericUpDown1.Value;
            }
            else
            {
                if (numericUpDown8.Value >= 63 && numericUpDown8.Value <= 70)
                {
                    label12.Text = "Se recomienda puntaje de 50 a 75";
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown8.Value = numericUpDown1.Value;
                }
                else
                {
                    if (numericUpDown8.Value >= 59 && numericUpDown8.Value <= 62)
                    {
                        label12.Text = "Se recomienda puntaje de 25 a 50";
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown8.Value = numericUpDown1.Value;
                    }
                    else
                    {
                        if (numericUpDown8.Value >= 45 && numericUpDown8.Value <= 58)
                        {
                            label12.Text = "Se recomienda puntaje de 0 a 25";
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown8.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        { }
                    
        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            Int16 b;
            b = Convert.ToInt16(label7.Text);
            switch (b)
            {
                case 1:
                    tabControl1.SelectedTab = tabPage1;
                    break;
                case 2:
                    tabControl1.SelectedTab = tabPage2;
                    break;
                case 3:
                    tabControl1.SelectedTab = tabPage3;
                    break;
                case 4:
                    tabControl1.SelectedTab = tabPage4;
                    break;
                case 5:
                    tabControl1.SelectedTab = tabPage5;
                    break;
                case 6:
                    tabControl1.SelectedTab = tabPage6;
                    break;
                case 7:
                    tabControl1.SelectedTab = tabPage7;
                    break;
                case 8:
                    tabControl1.SelectedTab = tabPage8;
                    break;
                case 9:
                    tabControl1.SelectedTab = tabPage9;
                    break;
                case 10:
                    tabControl1.SelectedTab = tabPage10;
                    break;
                case 11:
                    tabControl1.SelectedTab = tabPage11;
                    break;
                case 12:
                    tabControl1.SelectedTab = tabPage12;
                    break;
                case 13:
                    tabControl1.SelectedTab = tabPage13;
                    break;

            }
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            Int32 P;
            P = (Convert.ToInt32( numericUpDown5.Value) - 504) / 45;
            label12.Text = Convert.ToString( P);
        }

        private void button24_Click(object sender, EventArgs e)
        {
             if (numericUpDown3.Value >= 20 && numericUpDown3.Value <= 25)
            {
                textBox2.Text = "Excelente";
                textBox2.Show();
                numericUpDown3.Value = numericUpDown1.Value;
            }
            else
            {
                if (numericUpDown3.Value >= 15 && numericUpDown3.Value <= 19)
                {
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown3.Value = numericUpDown1.Value;
                }
                else
                {
                    if (numericUpDown3.Value >= 9 && numericUpDown3.Value <= 14)
                    {
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown3.Value = numericUpDown1.Value;
                    }
                    else
                    {
                        if (numericUpDown3.Value >= 5 && numericUpDown3.Value <= 8)
                        {
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown3.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
         if (numericUpDown14.Value >= 40 && numericUpDown14.Value <= 50)
            {
                textBox2.Text = "Excelente";
                textBox2.Show();
                numericUpDown14.Value = numericUpDown1.Value;
            }
            else
            {
                if (numericUpDown14.Value >= 30 && numericUpDown14.Value <= 39)
                {
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown14.Value = numericUpDown1.Value;
                }
                else
                {
                    if (numericUpDown14.Value >= 20 && numericUpDown14.Value <= 29)
                    {
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown14.Value = numericUpDown1.Value;
                    }
                    else
                    {
                        if (numericUpDown14.Value >= 10 && numericUpDown14.Value <= 19)
                        {
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown14.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        
        }

        

        private void button13_Click(object sender, EventArgs e)
        {
            if (numericUpDown12.Value >= 5 && numericUpDown12.Value <= 10)
            {
                textBox2.Text = "Excelente";
                textBox2.Show();
                numericUpDown12.Value = numericUpDown1.Value;
            }
            else
            {
                if (numericUpDown12.Value >= 11 && numericUpDown12.Value <= 15)
                {
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown12.Value = numericUpDown1.Value;
                }
                else
                {
                    if (numericUpDown12.Value >= 16 && numericUpDown12.Value <= 20)
                    {
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown12.Value = numericUpDown1.Value;
                    }
                    else
                    {
                        if (numericUpDown12.Value >= 21 && numericUpDown12.Value <= 30)
                        {
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown12.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (numericUpDown13.Value >= 5 && numericUpDown13.Value <= 6)
            {
                textBox2.Text = "Excelente";
                textBox2.Show();
                numericUpDown13.Value = numericUpDown1.Value;
            }
            else
            {
                if (numericUpDown13.Value >= 7 && numericUpDown13.Value <= 9)
                {
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown13.Value = numericUpDown1.Value;
                }
                else
                {
                    if (numericUpDown13.Value >= 10 && numericUpDown13.Value <= 12)
                    {
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown13.Value = numericUpDown1.Value;
                    }
                    else
                    {
                        if (numericUpDown13.Value >= 13 && numericUpDown13.Value <= 20)
                        {
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown13.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (numericUpDown15.Value >= 80 && numericUpDown15.Value <= 100)
            {
                textBox2.Text = "Excelente";
                textBox2.Show();
                numericUpDown15.Value = numericUpDown1.Value;
            }
            else
            {
                if (numericUpDown15.Value >= 60 && numericUpDown15.Value <= 79)
                {
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown15.Value = numericUpDown1.Value;
                }
                else
                {
                    if (numericUpDown15.Value >= 40 && numericUpDown15.Value <= 59)
                    {
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown15.Value = numericUpDown1.Value;
                    }
                    else
                    {
                        if (numericUpDown15.Value >= 10 && numericUpDown15.Value <= 39)
                        {
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown15.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            if (numericUpDown14.Value >= 20 && numericUpDown14.Value <= 25)
            {
                textBox2.Text = "Excelente";
                textBox2.Show();
                numericUpDown14.Value = numericUpDown1.Value;
            }
            else
            {
                if (numericUpDown14.Value >= 15 && numericUpDown14.Value <= 19)
                {
                    textBox2.Text = "Buena";
                    textBox2.Show();
                    numericUpDown14.Value = numericUpDown1.Value;
                }
                else
                {
                    if (numericUpDown14.Value >= 10 && numericUpDown14.Value <= 14)
                    {
                        textBox2.Text = "Regular";
                        textBox2.Show();
                        numericUpDown14.Value = numericUpDown1.Value;
                    }
                    else
                    {
                        if (numericUpDown14.Value >= 5 && numericUpDown14.Value <= 9)
                        {
                            textBox2.Text = "Mala";
                            textBox2.Show();
                            numericUpDown14.Value = numericUpDown1.Value;
                        }
                        else
                        {
                            MessageBox.Show("error", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }

        }
        }
        }
        

        
    


