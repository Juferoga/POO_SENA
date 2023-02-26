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
    public partial class P_empleados_ad : Form
    {
        public P_empleados_ad()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox1.Text == "" || textBox8.Text == "" || comboBox2.Text == "" || textBox9.Text == "" || textBox5.Text == "" || comboBox1.Text == "" || comboBox3.Text == "")
            {
                MessageBox.Show("Los Campos Son Obligatorios", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int resultadoC = 0;

                N_gestionempleado instanci = new N_gestionempleado();
                resultadoC = instanci.CECmi(Convert.ToInt64(textBox1.Text));


                if (resultadoC == 0)
                {
                    MessageBox.Show("No se puede registrar un usuario con la misma identificación ", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MemoryStream imagen1 = new MemoryStream();

                    pictureBox1.Image.Save(imagen1, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] memoria_imagen1 = imagen1.ToArray();

                    MemoryStream imagen2 = new MemoryStream();
                    pictureBox1.Image.Save(imagen2, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] memoria_imagen2 = imagen2.ToArray();

                    MemoryStream imagen3 = new MemoryStream();
                    pictureBox1.Image.Save(imagen3, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] memoria_imagen3 = imagen3.ToArray();


                    N_gestionempleado instancia = new N_gestionempleado();

                    

                    int res = instancia.registrar(textBox4.Text, Convert.ToInt64(textBox1.Text), textBox8.Text, comboBox2.Text, textBox9.Text, textBox5.Text, Convert.ToInt16(numericUpDown1.Value), comboBox1.Text, lbl2.Text, comboBox3.Text, memoria_imagen1, memoria_imagen2, memoria_imagen3, lbl1.Text, lbl2.Text, Convert.ToInt64(label10.Text));
                    
                    if (res == 1)
                    {

                        

                        if (pictureBox1.Image != null)
                        {
                            pictureBox1.Image.Dispose();
                            pictureBox1.Image = null;
                        }
                        if (pictureBox2.Image != null)
                        {
                            pictureBox2.Image.Dispose();
                            pictureBox2.Image = null;
                        }
                        if (pictureBox3.Image != null)
                        {
                            pictureBox3.Image.Dispose();
                            pictureBox3.Image = null;
                        }

                        
                        
                        DataTable res123 = instancia.CECm(Convert.ToInt64(textBox1.Text));
                        dataGridView3.DataSource = res123;
                        
                        label43.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                        
                        
                        int res3 = 0;



                        if (listBox1.Items.Count > 0)  //Si el control ListBox tiene telefonos, registra en la tabla secundaria
                        {
                            for (int cont = 0; cont < listBox1.Items.Count && cont < 2; cont++)
                            {
                                res3 = instancia.regtels(listBox1.Items[cont].ToString(), Convert.ToInt64(label43.Text), Convert.ToInt64(textBox1.Text));
                            }
                        }
                        else {
                            MessageBox.Show("Ingrese Minimo Un telefono", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            button3.Visible = true; 
                        }
                        if (res3 == 1) {
                            MessageBox.Show("guardado exitoso", "Club deportivo la gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listBox1.Items.Clear();
                            textBox1.Clear();
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox8.Clear();
                            textBox9.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "Club deportivo la gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            P_Menuprincipal le = new P_Menuprincipal();
            le.Show();
            this.Hide();
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
        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(examinar.FileName);
            }
            else
            {
                MessageBox.Show("ERROR", "Club deportivo la gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(examinar.FileName);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {

            panel4.Visible = false; 
            panel3.Visible = false;
            panel2.Visible = true;
            dataGridView1.Visible = true;
            panel1.Visible = false;
            panel5.Visible = false;
        }
        private void label26_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox4.Text == "Código")
                {
                    N_gestionempleado instancia = new N_gestionempleado();
                    DataTable res = instancia.CEC(Convert.ToInt64(textBox13.Text));
                    dataGridView1.DataSource = res;
                    textBox13.Clear();
                    dataGridView4.Visible = false;
                }
                else
                {
                    if (comboBox4.Text == "Nombre")
                    {
                        N_gestionempleado instancia = new N_gestionempleado();
                        DataTable res = instancia.CEn(textBox13.Text);
                        dataGridView1.DataSource = res;
                        textBox13.Clear();
                        dataGridView4.Visible = false;
                    }
                    else
                    {
                        if (comboBox4.Text == "Identificación")
                        {
                            N_gestionempleado instancia = new N_gestionempleado();
                            DataTable res = instancia.CECm(Convert.ToInt64(textBox13.Text));
                            dataGridView1.DataSource = res;
                            textBox13.Clear();
                            dataGridView4.Visible = false;
                        }
                        else
                        {
                            if (comboBox4.Text == "Teléfonos")
                            {

                                N_gestionempleado instancia = new N_gestionempleado();
                                DataTable res = instancia.tels(Convert.ToInt64(textBox13.Text));
                                dataGridView4.DataSource = res;
                                textBox13.Clear();
                                dataGridView4.Visible = true;
                                dataGridView1.Visible = false;
                                button12.Visible = true;
                                try
                                {
                                    textBox2.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
                                    textBox6.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                                    textBox12.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();

                                }
                                catch { }
                            }
                            else
                            {
                                if (textBox13.Text == "" && comboBox4.Text == "")
                                {
                                    MessageBox.Show("Tiene que llenar por lo menos un campo", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    dataGridView4.Visible = false;
                                }
                                else
                                {
                                    MessageBox.Show("ERROR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBox13.Clear();

                                    dataGridView4.Visible = false;
                                }
                            }
                        }

                    }
                }
            }
            catch
            {

            }

        }
        private void button14_Click(object sender, EventArgs e)
        {
            N_gestionempleado instacia = new N_gestionempleado();
            DataTable Rta = instacia.ConsultaG_e();
            dataGridView1.DataSource = Rta;
            dataGridView2.DataSource = Rta;
            dataGridView4.Visible = false;
            dataGridView1.Visible = true;

        }
        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel1.Visible = false;
            dataGridView1.Visible = false;
            panel2.Visible = false;
            N_gestionempleado instancia = new N_gestionempleado();
            DataTable tabla = new DataTable();
            tabla = instancia.encapsular();
            dataGridView2.DataSource = tabla;
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (comboBox8.Text == "Recuperar" || comboBox8.Text == "Eliminar")
            {
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox13.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();


            }
            else
            {

                if (comboBox4.Text == "Teléfonos")
                {
                    textBox13.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                }

                else
                {
                    

                }
            }
        }
        private void P_empleados_ad_Load(object sender, EventArgs e)
        {
            N_gestionempleado instacia = new N_gestionempleado();
            DataTable Rta = instacia.ConsultaG_e();
            dataGridView1.DataSource = Rta;


        }
        private void button15_Click(object sender, EventArgs e)
        {
            string L1 = comboBox8.Text;
            if (textBox10.Text == "" && comboBox8.Text == "")
            {
                MessageBox.Show("Seleccione un registro de la tabla para la eliminación", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox10.Focus();
            }
            else
            {

                DialogResult sera;
                if (comboBox8.Text == "Recuperar")
                {
                    sera = MessageBox.Show("Esta seguro de Recuperar el usuario  " + textBox3.Text, "Club Deportivo La Gaitana", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                else
                {
                    sera = MessageBox.Show("Esta seguro de Eliminar el usuario  " + textBox3.Text, "Club Deportivo La Gaitana", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                if (sera == DialogResult.Yes)
                {
                    N_gestionempleado instancia = new N_gestionempleado();
                    int res = instancia.eliminar(Convert.ToInt64(textBox10.Text), label19.Text);
                    if (res == 1)
                    {
                        if (comboBox8.Text == "Recuperar")
                        {
                            sera = MessageBox.Show("Usuario Recuperado correctamente", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            sera = MessageBox.Show("Usuario Eliminado correctamente", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        
                        N_gestionempleado instacia = new N_gestionempleado();
                        DataTable Rta = instacia.ConsultaG_e();
                        dataGridView1.DataSource = Rta;
                        dataGridView2.DataSource = Rta;

                    }
                    else
                    {
                        if (sera == DialogResult.No)
                        {

                        }
                        else
                        {
                            MessageBox.Show("Error", "Club deportivo la gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
        private void actualizar_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "")
            {
                MessageBox.Show("Los campos en la actualización son obligatorios", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                N_gestionempleado LL = new N_gestionempleado();

                int KK = LL.Actualizar(Convert.ToInt64(textBox11.Text), textBox18.Text, comboBox5.Text, comboBox6.Text, textBox21.Text, textBox22.Text, Convert.ToInt16(numericUpDown2.Value), comboBox7.Text);
                if (KK == 1)
                {

                    MessageBox.Show("Actualización realizada correctamente", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    N_gestionempleado instacia = new N_gestionempleado();


                    DataTable Rta = instacia.ConsultaG_e();
                    dataGridView1.DataSource = Rta;
                    dataGridView2.DataSource = Rta;

                    textBox14.Clear(); textBox11.Clear(); textBox17.Clear(); textBox18.Clear(); textBox21.Clear(); textBox22.Clear(); numericUpDown2.Value = 0;

                }
                else
                {
                    MessageBox.Show("ERROR", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }

        }
        private void button9_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel1.Visible = true;
            panel5.Visible = false;
            panel4.Visible = false;
            panel2.Visible = false;
            dataGridView1.Visible = false;
        }
        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox9.Text.Contains("@") && textBox9.Text.Contains("."))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(textBox9, "Digite un correo valido");
            }
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void textBox13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox4.Text == "Código")
            {
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
            else
            {
                if (comboBox4.Text == "Identificación")
                {
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
                else
                {
                    if (comboBox4.Text == "Nombre")
                    {
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
                    else
                    {
                        if (comboBox4.Text == "Teléfonos")
                        {
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
                        else
                        {
                            MessageBox.Show("ERROR", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }


        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(examinar.FileName);
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(examinar.FileName);
            }
            else
            {
                MessageBox.Show("ERROR", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

            OpenFileDialog examinar = new OpenFileDialog();
            DialogResult resultado = examinar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                pictureBox3.Image = Image.FromFile(examinar.FileName);
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox14.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox11.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox17.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox18.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            comboBox5.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            comboBox6.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox21.Text = dataGridView2.CurrentRow.Cells[6].Value.ToString();
            textBox22.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            numericUpDown2.Value = Convert.ToInt16(dataGridView2.CurrentRow.Cells[8].Value.ToString());
            comboBox7.Text = dataGridView2.CurrentRow.Cells[9].Value.ToString();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void button11_Click(object sender, EventArgs e)
        {
            //Adiciona los telefonos al control ListBox
            listBox1.Items.Add(textBox7.Text);
            textBox7.Clear();
            textBox7.Focus();
            if (listBox1.Items.Count > 0)  //Si el control ListBox tiene telefonos, registra en la tabla secundaria
            {
                for (int cont = 0; cont < listBox1.Items.Count; cont++)
                {
                    N_gestionempleado instancia = new N_gestionempleado();
                }
            }
        }
        private void listBox1_Click_1(object sender, EventArgs e)
        {
            //Permite eliminar telefonos del control ListBox tras seleccionarlos
            if (listBox1.Items.Count != 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                textBox7.Focus();
            }
        }

        private void listBox1_MouseHover_1(object sender, EventArgs e)
        {
            //Muestra una notificación al usuario tras posicionar el puntero sobre un control
            toolTip1.SetToolTip(listBox1, "De clic sobre un elemento para eliminar");
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

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
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
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
        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text == "Código")
            {

                label20.Text = "Código:";
                label20.Visible = true;
                textBox13.Visible = true;
                dataGridView1.Visible = true;
            }
            else
            {
                if (comboBox4.Text == "Identificación")
                {
                    label20.Text = "Identificacion:";
                    label20.Visible = true;
                    textBox13.Visible = true;
                    dataGridView1.Visible = true;
                }
                else
                {

                    if (comboBox4.Text == "Nombre")
                    {
                        label20.Text = "Nombre:";
                        label20.Visible = true;
                        textBox13.Visible = true;
                        dataGridView1.Visible = true;
                    }
                    else
                    {
                        if (comboBox4.Text == "Teléfonos")
                        {
                            label20.Text = "Código:";
                            label20.Visible = true;
                            textBox13.Visible = true;
                        }
                    }

                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

            panel4.Visible = false;
            panel2.Visible = false;
            dataGridView1.Visible = true;
            panel1.Visible = false;
            panel5.Visible = false;
            panel3.Visible = true;

            N_gestionempleado instacia = new N_gestionempleado();
            DataTable Rta = instacia.ConsultaG_e();
            dataGridView1.DataSource = Rta;
            dataGridView2.DataSource = Rta;

        }

        private void comboBox8_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox8.Text == "Eliminar")
            {
                label19.Text = "I";
                label34.Visible = true;
                label6.Visible = true;
                textBox3.Visible = true;
                textBox10.Visible = true;
                button15.Visible = true;
                button15.Text = "Eliminar";

                N_gestionempleado instacia = new N_gestionempleado();
                DataTable Rta = instacia.ConsultaG_e();
                dataGridView1.DataSource = Rta;
                dataGridView2.DataSource = Rta;
            }
            else
            {
                if (comboBox8.Text == "Recuperar")
                {
                    label19.Text = "A";
                    label34.Visible = true;
                    label6.Visible = true;
                    textBox3.Visible = true;
                    textBox10.Visible = true;
                    button15.Visible = true;
                    button15.Text = "recuperar";
                    N_gestionempleado instacia = new N_gestionempleado();
                    DataTable Rta = instacia.ConsultaG_eD();
                    dataGridView1.DataSource = Rta;
                    dataGridView2.DataSource = Rta;
                }
                else
                {
                    MessageBox.Show("Escoja Una opción", "Club deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void label36_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
        }

        private void label37_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void label38_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            panel4.Visible = false;
            if (textBox12.Text == "" && textBox6.Text == "")
            {
                MessageBox.Show("Los campos en la actualización son obligatorios", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                    N_gestionempleado LL = new N_gestionempleado();

                    int KK = LL.ActualizarT(Convert.ToInt64(textBox6.Text), Convert.ToInt64(textBox2.Text));//ID-TEL-COD
                    if (KK == 1)
                    {

                        MessageBox.Show("Actualización realizada correctamente", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        N_gestionempleado instacia = new N_gestionempleado();


                        DataTable Rta = instacia.ConsultaG_e();
                        dataGridView1.DataSource = Rta;
                        dataGridView2.DataSource = Rta;
                        textBox13.Clear();
                        textBox14.Clear(); textBox11.Clear(); textBox17.Clear(); textBox18.Clear(); textBox21.Clear(); textBox22.Clear(); numericUpDown2.Value = 0;

                    }
                    else
                    {
                        MessageBox.Show("ERROR", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }

                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;

            textBox10.Text = dataGridView4.CurrentRow.Cells[0].Value.ToString();
            textBox6.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox12.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label44.Text = DateTime.Now.ToLongTimeString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            N_gestionempleado instancia = new N_gestionempleado();
            DataTable res123 = instancia.CECm(Convert.ToInt64(textBox1.Text));
            dataGridView3.DataSource = res123;

            label43.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();


            int res3 = 1;



            if (listBox1.Items.Count > 0)  //Si el control ListBox tiene telefonos, registra en la tabla secundaria
            {
                for (int cont = 0; cont < listBox1.Items.Count && cont < 2; cont++)
                {
                    
                    res3 = instancia.regtels(listBox1.Items[cont].ToString(), Convert.ToInt64(label43.Text), Convert.ToInt64(textBox1.Text));
                }
            }
            else
            {
                MessageBox.Show("Ingrese Minimo Un telefono", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            listBox1.Items.Clear();
            textBox1.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
    }
}
    
