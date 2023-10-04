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
    public partial class Form1 : Form
    {
        private int id;
        public Form1()
        {
            InitializeComponent();

        }
        private void UpdateListView()
        {
            ListView1_LR.Items.Clear();

            conexao1 conn = new conexao1();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM LOGIN_LR";

            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {

                    string name = (string)dr["USER_LR"];

                    string pass = (string)dr["SENHA"];

                    ListViewItem lv = new ListViewItem(dr["id"].ToString());

                    lv.SubItems.Add(name);
                    lv.SubItems.Add(pass);
                    ListView1_LR.Items.Add(lv);

                }
                dr.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text, senha = textBox2.Text;


            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO LOGIN_LR VALUES
            (@USER_LR, @SENHA)";
            sqlCommand.Parameters.AddWithValue("@USER_LR", usuario);
            sqlCommand.Parameters.AddWithValue("@SENHA", senha);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show(
                "Login realizado com sucesso !",
                "AVISO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );

            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
            string USER_LR = textBox1.Text, SENHA = textBox2.Text;


            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE LOGIN_LR SET
           
            USER_LR = @USER_LR,
            SENHA = @SENHA
            
            WHERE id = @id";

            sqlCommand.Parameters.AddWithValue("@USER_LR", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@SENHA", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();

            MessageBox.Show(
             "Login alterado com sucesso !",
             "AVISO",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information
             );

            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();
        }

        private void ListView1_LR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Código para excluir
            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM LOGIN_LR WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir usuário no banco.\n" + err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();
        }

        private void ListView1_LR_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            int index;
            index = ListView1_LR.FocusedItem.Index;
            id = int.Parse(ListView1_LR.Items[index].SubItems[0].Text);

            textBox1.Text = ListView1_LR.Items[index].SubItems[1].Text;

            textBox2.Text = ListView1_LR.Items[index].SubItems[2].Text;
        }
    }
}
