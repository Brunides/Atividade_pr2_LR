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

namespace Atividade_pr2_LR
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NOME = maskedTextBox1.Text, E_MAIL = maskedTextBox3.Text;
            string TELEFONE = maskedTextBox2.Text;

            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO TABLE_LRCD VALUES
            (@NOME, @TELEFONE,@E_MAIL)";
            sqlCommand.Parameters.AddWithValue("@NOME", NOME);
            sqlCommand.Parameters.AddWithValue("@TELEFONE", TELEFONE);
            sqlCommand.Parameters.AddWithValue("@E_MAIL", E_MAIL);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show(
                           "Login realizado com sucesso !",
                           "AVISO",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                           );

            maskedTextBox1.Clear();
            maskedTextBox3.Clear();
            maskedTextBox2.Clear();

        }
    }
}
