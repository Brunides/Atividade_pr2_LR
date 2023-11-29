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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            
            }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            //aqui temos o botao de gera o pdf a partir das colunas do nosso banco de dados 
            // Conexão com o banco de dados SQL Server
            string stringConnection = @"Data Source="
                     + Environment.MachineName +
                     @"\SQLEXPRESS;Initial Catalog=" +
                     "Atividade_pr2" + ";Integrated Security=true";
            SqlConnection connection = new SqlConnection(stringConnection);
            connection.Open();

            // Consulta SQL para recuperar as informações
            string query = "SELECT NOME, TELEFONE, Email FROM TABLE_LRCD";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            // Cria um novo documento PDF
            Document document = new Document();
            PdfWriter.GetInstance(document, new FileStream("arquivo.pdf", FileMode.Create));
            document.Open();

            // Cria uma nova tabela e adiciona as informações recuperadas
            PdfPTable table = new PdfPTable(3);
            table.AddCell("NOME");
            table.AddCell("TELEFONE");
            table.AddCell("Email");

            while (reader.Read())
            {
                table.AddCell(reader["NOME"].ToString());
                table.AddCell(reader["TELEFONE"].ToString());
                table.AddCell(reader["Email"].ToString());
            }

            // Adiciona a tabela ao documento
            document.Add(table);

            // Fecha o documento e a conexão com o banco de dados
            document.Close();
            connection.Close();

            MessageBox.Show(
            "RELATORIO GERADO COM SUCESSO",
            "ATENÇÃO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

