using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_pr2_LR
{
    internal class UsuarioDAO
    {
        public void Deleteuser(int id)
        {

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

        }

        public void Edituser(int id, string textBox1,string textBox2)
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

        }
    }
}
