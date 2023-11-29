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
    public partial class Form9 : Form
    {
        public int ID;
        public Form9()
        {
          
            InitializeComponent();
            UpdateListView();
        }
        private void UpdateListView()
        {
            // Limpa todos os itens existentes na ListView
            ListView1_LR.Items.Clear();

            // Cria uma nova conexão com o banco de dados
            conexao1 conn = new conexao1();
            SqlCommand sqlCom = new SqlCommand();

            // Define a conexão e a consulta SQL para o comando
            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM TABLE_LRCD";

            try
            {
                // Executa a consulta e obtém os resultados
                SqlDataReader dr = sqlCom.ExecuteReader();

                // Enquanto houver linhas para ler nos resultados...
                while (dr.Read())
                {
                    // Lê os valores das colunas NOME, TELEFONE e E-mail
                    string nome = (string)dr["NOME"];
                    string telefone = (string)dr["TELEFONE"];

                    string email = (string)dr["Email"];

                    // Cria um novo item de lista com o ID como o texto principal
                    ListViewItem lv = new ListViewItem(dr["ID"].ToString());

                    // Adiciona os valores de NOME, TELEFONE e E-mail como subitens
                    lv.SubItems.Add(nome);
                    lv.SubItems.Add(telefone);
                    lv.SubItems.Add(email);

                    // Adiciona o item de lista à ListView
                    ListView1_LR.Items.Add(lv);
                }

                // Fecha o leitor de dados
                dr.Close();
            }
            catch (Exception err)
            {
                // Se ocorrer um erro, mostra uma mensagem de erro
                MessageBox.Show(err.Message);
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                conn.CloseConnection();
            }

            

        }
        private void Form9_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE TABLE_LRCD SET
           
            NOME = @NOME,
            TELEFONE = @TELEFONE,
            Email = @Email
            
            WHERE ID = @ID"
            ;

            sqlCommand.Parameters.AddWithValue("@NOME", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@Email", textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@TELEFONE", maskedTextBox1.Text);
            sqlCommand.Parameters.AddWithValue("@id", ID);
            sqlCommand.ExecuteNonQuery();


            MessageBox.Show(
             "Login alterado com sucesso !",
             "AVISO",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information
             );

            textBox1.Clear();
            textBox3.Clear();
            maskedTextBox1.Clear();

            UpdateListView();

            this.Hide();
        }

        private void ListView1_LR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListView1_LR_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            int index;
            index = ListView1_LR.FocusedItem.Index;
            ID = int.Parse(ListView1_LR.Items[index].SubItems[0].Text);
            textBox1.Text = ListView1_LR.Items[index].SubItems[1].Text;
            maskedTextBox1.Text = ListView1_LR.Items[index].SubItems[2].Text;
            textBox3.Text = ListView1_LR.Items[index].SubItems[3].Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM TABLE_LRCD WHERE ID = @Id";
            sqlCommand.Parameters.AddWithValue("@Id", ID);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no bancao.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
            UpdateListView();
        }
    }
    
}
