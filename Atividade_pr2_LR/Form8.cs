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
using System.Net.Mail;
using System.Net;

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
           
            string  EMAIL = textBox2.Text;
            string TELEFONE = maskedTextBox1.Text;

            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO TABLE_LRCD VALUES
            (@NOME, @TELEFONE,@Email)";
            sqlCommand.Parameters.AddWithValue("@NOME", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@TELEFONE", TELEFONE);
            sqlCommand.Parameters.AddWithValue("@Email", EMAIL);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show(
                           "Login realizado com sucesso !",
                           "AVISO",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Information
                           );

            maskedTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
           


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
    }
}
