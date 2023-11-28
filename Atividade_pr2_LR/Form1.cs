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

            
           

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Por favor, insira uma senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Por favor, escolha um nome de usuario.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (string.IsNullOrEmpty(textBox3_1.Text))
                    {
                        MessageBox.Show("Por favor, insira uma senha.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (textBox2.Text == textBox3_1.Text)
                        {
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
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("senhas diferentes, verifique a ortografia", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }





            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();

           
        }

        private string CalcularSHA256(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Converte a string de entrada em bytes
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                // Calcula o hash SHA-256
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Converte o resultado do hash em uma string hexadecimal
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
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
            
        }

        private void ListView1_LR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
}