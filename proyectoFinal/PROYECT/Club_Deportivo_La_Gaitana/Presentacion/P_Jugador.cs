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

namespace Presentacion
{
    public partial class P_Jugador : Form
    {
        public P_Jugador()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;
            dataGridView1.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            N_Jugador instacia = new N_Jugador();
            DataTable Rta = instacia.ConsultarG_jLL();

            dataGridView1.DataSource = Rta;
            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            dataGridView1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = true;
            panel1.Visible = false;
            dataGridView1.Visible = true;

            N_Jugador instacia = new N_Jugador();
            DataTable Rta = instacia.ConsultarG_j();
            dataGridView1.DataSource = Rta;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;
            dataGridView1.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            P_Menuprincipal m = new P_Menuprincipal();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            N_Jugador instacia = new N_Jugador();
            DataTable Rta = instacia.ConsultarG_j();
            dataGridView1.DataSource = Rta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(examinar.FileName);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(examinar.FileName);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(examinar.FileName);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(examinar.FileName);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox4.Image = Image.FromFile(examinar.FileName);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox5.Image = Image.FromFile(examinar.FileName);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || numericUpDown1.Value == 0 || numericUpDown2.Value == 0)
            {
                MessageBox.Show("Los Campos Son Obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MemoryStream imagen1 = new MemoryStream();

                pictureBox1.Image.Save(imagen1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] memoria_imagen1 = imagen1.ToArray();

                N_Jugador instancia = new N_Jugador();

                int res = instancia.registro(textBox6.Text, textBox2.Text, Convert.ToInt64(textBox3.Text), textBox4.Text, Convert.ToDouble(numericUpDown1.Value), Convert.ToDouble(numericUpDown2.Value), dateTimePicker1.MaxDate, memoria_imagen1, Convert.ToInt64(lbl_cod.Text));

                if (res == 1)
                {
                    N_Jugador instan = new N_Jugador();
                    DataTable LL = instan.CECU();
                    comboBox2.ValueMember = "";
                    comboBox2.DataSource = LL;
                    MessageBox.Show("Guardado Exitoso", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    groupBox1.Visible = true;

                    if (comboBox1.Text == "")
                    {
                        linkLabel1.Visible = true;

                    }
                }
                else
                {
                    MessageBox.Show("error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int resultadoC = 2;

            N_Jugador instanci = new N_Jugador();
            resultadoC = instanci.CECmi(Convert.ToInt64(comboBox2.Text));
            MemoryStream imagen1 = new MemoryStream();

            if (resultadoC == 2)
            {
                MessageBox.Show("No se puede registrar dos matriculas a un jugador ", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                pictureBox2.Image.Save(imagen1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] memoria_imagen1 = imagen1.ToArray();

                MemoryStream imagen2 = new MemoryStream();

                pictureBox2.Image.Save(imagen1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] memoria_imagen2 = imagen2.ToArray();

                MemoryStream imagen3 = new MemoryStream();

                pictureBox2.Image.Save(imagen1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] memoria_imagen3 = imagen3.ToArray();

                MemoryStream imagen4 = new MemoryStream();

                pictureBox2.Image.Save(imagen1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] memoria_imagen4 = imagen4.ToArray();

                MemoryStream imagen5 = new MemoryStream();

                pictureBox2.Image.Save(imagen1, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] memoria_imagen5 = imagen5.ToArray();

                N_Jugador instancia = new N_Jugador();


                int res = instancia.registrom(memoria_imagen2, memoria_imagen3, memoria_imagen4, memoria_imagen5, Convert.ToInt64(comboBox2.Text), Convert.ToInt64(label3.Text), Convert.ToInt64(lbl_cod.Text));

                if (res == 1)
                {
                    MessageBox.Show("guardado exitoso", "Club Deportivo La Gaitana",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("error", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void P_Jugador_Load(object sender, EventArgs e)
        {
            colordata(dataGridView1);
            colordata(dataGridView2);
            N_Jugador instancia = new N_Jugador();
            DataTable g3 = instancia.ConsultarG_j();
            dataGridView1.DataSource = g3;

            N_Equipo nombres = new N_Equipo();
            DataTable g4 = nombres.ConsultarG_EN();
            comboBox1.ValueMember = "nombre";
            comboBox1.DataSource = g4;

            N_Equipo nuevo1 = new N_Equipo();
            DataTable res1 = nuevo1.CUC(comboBox1.Text);
            dataGridView2.DataSource = res1;


            N_Jugador instan = new N_Jugador();
            DataTable LL = instan.CECU();
            comboBox2.ValueMember = "numero_id";
            comboBox2.DataSource = LL;

            N_Equipo nuevo = new N_Equipo();
            DataTable res = nuevo.CUC(comboBox2.Text);
            dataGridView2.DataSource = res;

        }

        private void lbl_cod_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            N_Equipo nuevo = new N_Equipo();
            DataTable res = nuevo.CUC(comboBox1.Text);
            dataGridView2.DataSource = res;
            try
            {
                label3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            }
            catch { }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                numericUpDown4.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                numericUpDown3.Value = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                textBox9.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            }
            catch { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (comboBox4.Text == "TI Jugador")
                {
                    N_Jugador instancia = new N_Jugador();
                    DataTable res = instancia.CETI(Convert.ToInt64(textBox13.Text));
                    dataGridView1.DataSource = res;
                    textBox13.Clear();
                }
                else
                {
                    if (comboBox4.Text == "Código")
                    {
                        N_Jugador instancia = new N_Jugador();
                        DataTable res = instancia.CEDMTR(Convert.ToInt64(textBox13.Text));
                        dataGridView1.DataSource = res;
                        textBox13.Clear();
                    }

                    else
                    {
                        if (textBox13.Text == "" && comboBox4.Text == "")
                        {
                            MessageBox.Show("Tiene que llenar por lo menos un campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox13.Clear();
                        }
                    }
                }
            }
            else
            {
                if (comboBox4.Text == "Nombre")
                {
                    N_Jugador instancia = new N_Jugador();
                    DataTable res = instancia.CEn(textBox13.Text);
                    dataGridView1.DataSource = res;
                    textBox13.Clear();
                }
                else
                {
                    if (comboBox4.Text == "Identificación")
                    {
                        N_Jugador instancia = new N_Jugador();
                        DataTable res = instancia.CECm(Convert.ToInt64(textBox13.Text));
                        dataGridView1.DataSource = res;
                        textBox13.Clear();
                    }

                    else
                    {
                        if (textBox13.Text == "" && comboBox4.Text == "")
                        {
                            MessageBox.Show("Tiene que llenar por lo menos un campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox13.Clear();
                        }


                    }
                }
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox5.Text == "" || textBox7.Text == "" || textBox9.Text == "" || numericUpDown4.Value == 0 || numericUpDown3.Value == 0)
            {
                MessageBox.Show("Los campos en la actualización son obligatorios", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                N_Jugador LL = new N_Jugador();

                int KK = LL.Actualizar(Convert.ToInt64(textBox1.Text), textBox9.Text, Convert.ToDouble(numericUpDown4.Value), Convert.ToDouble(numericUpDown3.Value), Convert.ToInt64(textBox7.Text));
                if (KK == 1)
                {

                    MessageBox.Show("Actualización realizada correctamente", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    N_Jugador instacia = new N_Jugador();
                    DataTable Rta = instacia.ConsultarG_jLL();

                    dataGridView1.DataSource = Rta;

                    textBox1.Clear(); textBox9.Clear(); textBox5.Clear(); numericUpDown3.Value = 0; numericUpDown3.Value = 0;

                }
            }

        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {

            if (comboBox4.Text == "Identificación")
            {
                label7.Text = "Identificacion:";
                label7.Visible = true;
                textBox13.Visible = true;
                textBox13.Clear();
            }
            else
            {

                if (comboBox4.Text == "Nombre")
                {
                    label7.Text = "Nombre:";
                    label7.Visible = true;
                    textBox13.Visible = true;
                    textBox13.Clear();
                }


            }
        }

        private void label26_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            label24.Visible = true;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }

        private void label28_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }

        private void label29_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
            pictureBox5.Visible = false;
        }

        private void label31_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = true;
        }
        private void colordata(DataGridView dt)
        {
            dt.RowsDefaultCellStyle.BackColor = Color.LightGray;
            dt.AlternatingRowsDefaultCellStyle.BackColor = Color.White;

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // validacion campo solo letras NO SIMBOLOS,NONUMEROS 
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                N_Jugador instacia = new N_Jugador();
                DataTable Rta = instacia.ConsultarG_jLLM();

                dataGridView1.DataSource = Rta;

                comboBox3.Visible = true;
                comboBox4.Visible = false;
            }
            else
            {
                N_Jugador instacia = new N_Jugador();
                DataTable Rta = instacia.ConsultarG_jLL();

                dataGridView1.DataSource = Rta;
                comboBox3.Visible = false;
                comboBox4.Visible = true;
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            label7.Visible = true;
            textBox13.Visible = true;
            label7.Text = comboBox3.Text;
        }

        private void label33_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            P_Equipo menu4 = new P_Equipo();
            menu4.label6.Text = lbl_cod.Text;
            menu4.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            N_Jugador instan = new N_Jugador();
            DataTable LL = instan.CECU();
            comboBox2.ValueMember = "";
            comboBox2.DataSource = LL;

            N_Equipo nombres = new N_Equipo();
            DataTable g4 = nombres.ConsultarG_EN();
            comboBox1.ValueMember = "nombre";
            comboBox1.DataSource = g4;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label34.Text = DateTime.Now.ToLongTimeString();
        }

        private void comboBox2_Click(object sender, EventArgs e)
        {

            N_Jugador instan = new N_Jugador();
            DataTable LL = instan.CECU();
            comboBox2.ValueMember = "";
            comboBox2.DataSource = LL;

            N_Equipo nombres = new N_Equipo();
            DataTable g4 = nombres.ConsultarG_EN();
            comboBox1.ValueMember = "nombre";
            comboBox1.DataSource = g4;
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {

            N_Jugador instan = new N_Jugador();
            DataTable LL = instan.CECU();
            comboBox2.ValueMember = "";
            comboBox2.DataSource = LL;

            N_Equipo nombres = new N_Equipo();
            DataTable g4 = nombres.ConsultarG_EN();
            comboBox1.ValueMember = "nombre";
            comboBox1.DataSource = g4;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
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
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            label38.Text = "Las Imagenes no pueden cargar";
            label38.Visible = true;
            
        }
    }
}
