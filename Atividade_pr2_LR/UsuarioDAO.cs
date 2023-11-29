using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_pr2_LR
{

    
    internal class UsuarioDAO
    {
        public void Deleteuser(int Id)
        {

            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"DELETE FROM LOGIN_LR WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", Id);
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

        }
      

        public void Edituser(int Id, string USER_LR,string SENHA)
        {

           

            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"UPDATE LOGIN_LR SET
           
            USER_LR = @USER_LR,
            SENHA = @SENHA
            
            WHERE id = @id";

            sqlCommand.Parameters.AddWithValue("@USER_LR", USER_LR);
            sqlCommand.Parameters.AddWithValue("@SENHA", SENHA);
            sqlCommand.Parameters.AddWithValue("@id", Id);
            sqlCommand.ExecuteNonQuery();

        }

        public void Insertuser(int Id, string USER_LR, string SENHA)
        {


            conexao1 connection = new conexao1();
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = @"INSERT INTO LOGIN_LR VALUES
            (@USER_LR, @SENHA)";
            sqlCommand.Parameters.AddWithValue("@USER_LR", USER_LR);
            sqlCommand.Parameters.AddWithValue("@SENHA", SENHA);
            sqlCommand.ExecuteNonQuery();



        }


        public  List<Usuario>SelectUser()
        {
           

            conexao1 conn = new conexao1();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM LOGIN_LR ";

            List<Usuario> list = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    Usuario objeto = new Usuario(
                    (int)dr["id"],
                    (string)dr["USER_LR"],
                    (string)dr["SENHA"]);
                    list.Add(objeto);
                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Erro na Leitura." + err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return list;
        }
        public List<Usuario> SelectUser2()
        {


            conexao1 conn = new conexao1();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM TABLE_LRCD ";

            List<Usuario> list = new List<Usuario>();
            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    Usuario objet = new Usuario(
                    (int)dr["ID"],
                    (string)dr["NOME"],
                    (string)dr["TELEFONE"],
                    (string)dr["E-mail"]);
                    list.Add(objet);
                }
                dr.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Erro na Leitura." + err.Message);
            }
            finally
            {
                conn.CloseConnection();
            }
            return list;
        }
    }
    }

