using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using negocio;
using System.Net.Mail;

namespace Presentacion
{
    public partial class P_Recovery : Form
    {
        
        MailMessage mail = new MailMessage();
        public P_Recovery()
        {
            
            InitializeComponent();
        }

        private void P_Recovery_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Los Campos Son Obligaatorios");
            }
            else{
                    label2.Visible = true;
                    textBox2.Visible = true;
                    button3.Visible = true;
                    try
                    {
                        N_gestionempleado TT = new N_gestionempleado();
                        DataTable LL = new DataTable();
                        LL = TT.rta(Convert.ToInt64(textBox1.Text));
                        dataGridView1.DataSource = LL;
                        textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        label4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    }
                    catch {
                        N_gestionempleado TT = new N_gestionempleado();
                        DataTable LL = new DataTable();
                        LL = TT.rta(Convert.ToInt64(textBox1.Text));
                        dataGridView1.DataSource = LL;
                        MessageBox.Show("Este Registro No Existe", "Club Deportivo La Gaitana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            P_login LL = new P_login();
            LL.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string PARA; //DEFINICION DE VARIABLES PARA ENVIO DE CORREO

            string MENSAJE;

            string DE;

            string CONTRASENA;

            MailMessage mail;

            PARA = textBox2.Text;

            MENSAJE = "desarrollador---- "+"La clave para su ingreso es:   "+label4.Text;

            DE = "juancholoco61@hotmail.com"; //Cuenta de correo desde donde es emitido el mensaje

            CONTRASENA = "JuanFelipe1"; //Contraseña del correo electrónico desde donde es emitido el mensaje

            mail = new MailMessage();

            mail.To.Add(new MailAddress(PARA));

            mail.From = new MailAddress(DE); //Debe ingresarse el E-mail remitente

            mail.Subject = "Recuperacion de la contraseña"; //Asunto del mensaje, en este caso el objeto Label lbl1

            mail.Body = MENSAJE; //El cuerpo del mensaje Mail es el contenido de la variable MENSAJE

            mail.IsBodyHtml = false;

            SmtpClient client = new SmtpClient("smtp.live.com", 587); //PROTOCOLO DE TRANSFERENCIA DE DATOS MAIL

            //SMTP: smtp.live.com HOTMAIL Si el mensaje es emitido desde hotmail, es empleado el smtp live

            //SMTP: smtp.mail.yahoo.com YAHOO Si el mensaje es emitido desde yahoo, es empleado el smtp mail.yahoo

            //SMTP: smtp.gmail.com GMAIL Si el mensaje es emitido desde gmail, es empleado el smtp gmail

            //Se brindan permisos para acceder a la cuenta de correo electrónico y enviar el mensaje
            {

                client.Credentials = new System.Net.NetworkCredential(DE, CONTRASENA);

                client.EnableSsl = true;

                client.Send(mail);

                //Mensaje de notificación de envio del mensaje

                MessageBox.Show("Mensaje de confirmación enviado", "Envio de notificaciones", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
