using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using negocio;
using System.IO;
using System.Drawing.Imaging;

namespace Presentacion
{
    public partial class P_Test : Form
    {
        public P_Test()
        {
            InitializeComponent();
        }

        private void P_Test_Load(object sender, EventArgs e)
        {
            N_Test ll = new N_Test();
           
            
            DataTable PP = new DataTable();
            PP = ll.busquedage();
            dataGridView1.DataSource = PP;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            N_Test ll= new N_Test();
            DataTable PP = new DataTable();
            PP = ll.busquedage();
            dataGridView1.DataSource = PP;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Ninguno de estos campos puede estar vacio", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (numericUpDown6.Value == 0 || numericUpDown7.Value == 0)
                {
                    MessageBox.Show("Puntaje promedio y Maximo no pueden tener valor de 0", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (numericUpDown7.Value > numericUpDown6.Value)
                    {
                        MessageBox.Show("El puntaje  del promedio no puede ser mayor al de el puntaje máximo", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                        
                    else
                    {
                        if (numericUpDown5.Value > numericUpDown7.Value || numericUpDown5.Value > numericUpDown6.Value) {
                            MessageBox.Show("El puntaje  del minimo no puede ser mayor al de el puntaje máximo ni al promedio", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else{
                        int resultadoC = 0;

                N_Test instanci = new N_Test();
                resultadoC = instanci.CECmi(textBox1.Text);

                if (resultadoC == 1)
                {
                    MessageBox.Show("No se puede registrar un test con el mismo nombre ", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      }
                            else{
                      
                            N_Test instancia = new N_Test();
                            int rta = instancia.registro(textBox1.Text, comboBox1.Text, Convert.ToInt16(numericUpDown5.Value), Convert.ToInt16(numericUpDown6.Value), Convert.ToInt16(numericUpDown7.Value), Convert.ToInt64(lblcod.Text));
                            if (rta == 1)
                            {
                                MessageBox.Show("Registro Guardado Exitosamente", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                numericUpDown5.Value = 0;
                                numericUpDown6.Value = 0;
                                numericUpDown7.Value = 0;
                                textBox1.Clear();
                            }
                            
                            
                            else{
                            MessageBox.Show("ERROR", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                    }}

                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            numericUpDown10.Value =Convert.ToInt16( dataGridView1.CurrentRow.Cells[3].Value.ToString());
            numericUpDown8.Value =Convert.ToInt16( dataGridView1.CurrentRow.Cells[4].Value.ToString());
            numericUpDown9.Value = Convert.ToInt16(dataGridView1.CurrentRow.Cells[5].Value.ToString());
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible= false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
            }

        private void button13_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel4.Visible = false;
            dataGridView1.Visible = true;


            N_Test ll = new N_Test();
            DataTable PP = new DataTable();
            PP = ll.busquedage();
            dataGridView1.DataSource = PP;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            N_Test ll = new N_Test();
            DataTable PP = new DataTable();
            PP = ll.busquedage();
            dataGridView1.DataSource = PP;

            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
            dataGridView1.Visible = true;
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "" ) {
                MessageBox.Show("Es necesario ingresar un dato", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox4.Text == "Código")
                {
                    N_Test instancia = new N_Test();
                    DataTable res = instancia.CEC(Convert.ToInt64(textBox13.Text));
                    dataGridView1.DataSource = res;
                    textBox13.Clear();
                }
                else
                {
                    if (comboBox4.Text == "Nombre")
                    {
                        N_Test instancia = new N_Test();
                        DataTable res = instancia.CEN(textBox13.Text);
                        dataGridView1.DataSource = res;
                        textBox13.Clear();
                    }
                    else
                    {
                        
                                                        

                                MessageBox.Show("Tiene que llenar por lo menos un campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        


                    }
                }
            }
        }

        private void comboBox4_SelectedValueChanged_1(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Código")
            {

                label25.Text = "Código:";
                label25.Visible = true;
                textBox13.Visible = true;
                
            }
            else{
                if (comboBox4.Text == "Nombre")
                    {
                        label25.Text = "Nombre:";
                        label25.Visible = true;
                        textBox13.Visible = true;
                    }

                
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox3.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Ninguno de estos campos puede estar vacio", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (numericUpDown10.Value == 0 || numericUpDown8.Value == 0 || numericUpDown9.Value == 0)
                {
                    MessageBox.Show("Puntaje promedio y Maximo no pueden tener valor de 0", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (numericUpDown10.Value > numericUpDown9.Value)
                    {
                        MessageBox.Show("El puntaje  del promedio no puede ser mayor al de el puntaje máximo", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int KK=0;
                            N_Test instancia = new N_Test();
                            KK=instancia.actualizar(comboBox3.Text,Convert.ToInt16( numericUpDown10.Value),Convert.ToInt16( numericUpDown8.Value),Convert.ToInt16( numericUpDown9.Value),Convert.ToInt64(textBox9.Text));
                            if (KK == 1)
                            {

                                MessageBox.Show("Actualización realizada correctamente", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                N_Test ll = new N_Test();
                                DataTable PP = new DataTable();
                                PP = ll.busquedage();
                                dataGridView1.DataSource = PP;

                                comboBox3.Text = ""; numericUpDown10.Value = 0; numericUpDown8.Value = 0; numericUpDown9.Value = 0;

                            }
                            else
                            {
                                MessageBox.Show("ERROR", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);


                            }
                    }
                }
            }
        }

        private void comboBox5_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validacion campo solo letras NO SIMBOLOS,NO NUMEROS 
            if (Char.IsLetter(e.KeyChar))
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
                MessageBox.Show("este campo no permite numeros ni simbolos", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToLongTimeString();
        }
       
    }
}
