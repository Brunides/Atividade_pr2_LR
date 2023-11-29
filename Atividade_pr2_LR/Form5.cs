using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Atividade_pr2_LR
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
          
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = "SELECT Email FROM TABLE_LRCD WHERE NOME = @NOME";
            sqlCommand.Parameters.AddWithValue("@NOME", textBox1.Text);

            // Executa o comando e obtém o resultado
            string email = (string)sqlCommand.ExecuteScalar();

            // Cria uma nova mensagem de e-mail
            MailMessage mail = new MailMessage("seuemail@example.com", email);
            mail.Subject = "oi";
            mail.Body = "tudo bão";

            // Cria um novo cliente SMTP
            SmtpClient client = new SmtpClient("bbrunid@gmail.com");
            client.Credentials = new NetworkCredential("bbrunid@gmail.com", "Atividadedomarquito");

            // Envia o e-mail
            client.Send(mail);

            MessageBox.Show("E-mail enviado com sucesso!");
        }
    }
}
