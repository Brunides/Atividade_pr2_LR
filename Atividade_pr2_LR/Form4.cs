using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Atividade_pr2_LR
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connection.ReturnConnection();
            string username = textBox1.Text;
            string password = textBox2.Text;

            // Criptografa a senha inserida
            string hashedPassword = CalcularSHA256(password);

            // Cria um novo comando SQL para verificar o usuário e a senha
            SqlCommand command = new SqlCommand("SELECT * FROM LOGIN_LR WHERE USER_LR = @USER_LR AND SENHA = @SENHA", sqlCommand.Connection);
            command.Parameters.AddWithValue("@USER_LR", username);
            command.Parameters.AddWithValue("@SENHA", hashedPassword);

            // Executa o comando e obtém o resultado
            SqlDataReader reader = command.ExecuteReader();

            // Verifica se a consulta retornou algum resultado
            if (reader.HasRows)
            {
                MessageBox.Show("Login bem sucedido!");

                Form6 form6 = new Form6();
                form6.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!");
            }

            reader.Close();
            // Fecha a conexão

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
        private string CalcularSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
                
            
        

