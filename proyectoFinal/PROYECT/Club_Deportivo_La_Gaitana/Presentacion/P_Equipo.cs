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
    public partial class P_Equipo : Form
    {
        public P_Equipo()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            N_Equipo LL = new N_Equipo();
            int LOL = LL.SaveE(textBox1.Text, richTextBox1.Text, Convert.ToInt64(label6.Text));
            if (LOL == 1)
            {
                MessageBox.Show("Equipo Registrado Correctamente", "Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
                richTextBox1.Clear();
            }
            else
            {
                MessageBox.Show("Error", "No Ingresado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            dataGridView1.Visible = false;
            panel3.Visible = false;

        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            dataGridView1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            dataGridView1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            N_Equipo CG = new N_Equipo();
            DataTable LL;
            LL = CG.CGEm();
            dataGridView1.DataSource = LL;
        }

        private void P_Equipo_Load(object sender, EventArgs e)
        {
            N_Equipo CG = new N_Equipo();
            DataTable LL;
            LL = CG.CGEm();
            dataGridView1.DataSource = LL;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            richTextBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            label1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            dataGridView1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Los campos en la actualización son obligatorios", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                N_Equipo LL = new N_Equipo();
                int KK = LL.actualizar(Convert.ToInt64(label9.Text), textBox2.Text, richTextBox2.Text);
                if (KK == 1)
                {

                    MessageBox.Show("Actualización realizada correctamente", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    N_Equipo CG = new N_Equipo();
                    DataTable LL1;
                    LL1 = CG.CGEm();
                    dataGridView1.DataSource = LL1;

                    textBox2.Clear();
                    richTextBox2.Clear();

                }
                else
                {
                    MessageBox.Show("ERROR", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox13.Text == "") {
                MessageBox.Show("El campo es obligatorio para la busqueda", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                N_Equipo LL = new N_Equipo();
                DataTable M = LL.CEE(Convert.ToInt64(textBox13.Text));
                dataGridView1.DataSource = M;
                textBox13.Clear();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToLongTimeString();
           
        }
    }
}
