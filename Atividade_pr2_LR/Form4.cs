using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
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
            string usuario = textBox1.Text;
            string senha = textBox2.Text;
            conexao1 connection = new conexao1();
           
            // Cria uma nova consulta SQL
            string query = "SELECT * FROM LOGIN_LR WHERE USER_LR = @usuario AND SENHA = @senha";

            // Cria um novo comando SQL
            SqlCommand sqlCommand = new SqlCommand(query, connection.ReturnConnection());
            sqlCommand.Parameters.AddWithValue("@usuario", usuario);
            sqlCommand.Parameters.AddWithValue("@senha", senha);

            // Abre a conexão
          

            // Executa a consulta
            SqlDataReader reader = sqlCommand.ExecuteReader();

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

            // Fecha a conexão
            
        }
    }
}
