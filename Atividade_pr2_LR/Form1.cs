using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;

using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Atividade_pr2_LR
{
    public partial class Form1 : Form
    {




        private int Id;
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


           
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {

           
        }

        private void ListView1_LR_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Código para excluir




        }

        private void ListView1_LR_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
           



        }

        private void ListView1_LR_MouseDoubleClick_2(object sender, MouseEventArgs e)
        {

           
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateListView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            string senhaOriginal = textBox2.Text;

            string senhaCriptografada = CriptografarSenha(senhaOriginal);
            try
            {
                Usuario usuario1 = new Usuario(Id, textBox1.Text, textBox2.Text);
                UsuarioDAO dAO = new UsuarioDAO();
                dAO.Insertuser(Id, textBox1.Text, textBox2.Text);

                MessageBox.Show(
            "Login realizado com sucesso !",
            "AVISO",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
            );
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

          





            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();

            this.Close();
        }

        public string CriptografarSenha(string SENHA)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(SENHA));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();

            }
        }


        private void buttonedit_Click_1(object sender, EventArgs e)
        {
            UsuarioDAO dAO = new UsuarioDAO();
            dAO.Edituser(Id, textBox1.Text, textBox2.Text);

            string USER_LR = textBox1.Text, SENHA = textBox2.Text;


            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE LOGIN_LR SET
           
            USER_LR = @USER_LR,
            SENHA = @SENHA
            
            WHERE id = @id"
            ;

            sqlCommand.Parameters.AddWithValue("@USER_LR", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@SENHA", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@id", Id);
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

        private void button2_Click_2(object sender, EventArgs e)
        {

           
            UpdateListView();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void ListView1_LR_MouseDoubleClick_3(object sender, MouseEventArgs e)
        {
            int index;
            index = ListView1_LR.FocusedItem.Index;
            Id = int.Parse(ListView1_LR.Items[index].SubItems[0].Text);


            textBox1.Text = ListView1_LR.Items[index].SubItems[1].Text;

            textBox2.Text = ListView1_LR.Items[index].SubItems[2].Text;
        }

        private void ListView1_LR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}