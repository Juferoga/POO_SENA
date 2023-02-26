using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace controles_la_reencarnacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text, dateTimePicker1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double n1, n2, n3, pro;
            n1 = Convert.ToDouble(textBox6.Text);
            n2 = Convert.ToDouble(textBox7.Text);
            n3 = Convert.ToDouble(textBox8.Text);
            pro = (n1 + n2 + n3) / 3;
            label12.Text = Convert.ToString(pro);
            if (pro>=1.0 && pro< 3.8)
            {
                dataGridView2.Rows.Add(textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, label12.Text, "perdio");
            }
            else
            {
                if (pro >= 3.8 && pro <=5.0)
                {
                    dataGridView2.Rows.Add(textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, label12.Text, "paso");
                }
            }
        }

        
    }
}
