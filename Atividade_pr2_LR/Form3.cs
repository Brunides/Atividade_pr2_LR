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
    public partial class Form3 : Form
    {
        private int id1;
        public Form3()
        {
            InitializeComponent();

        }
        private void UpdateListView1()
        {
            listView2_LR.Items.Clear();

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
                    listView2_LR.Items.Add(lv);

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
        private void Form3_Load(object sender, EventArgs e)
        {
            UpdateListView1();
        }

        private void listView2_LR_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index;
            index = listView2_LR.FocusedItem.Index;
            id1 = int.Parse(listView2_LR.Items[index].SubItems[0].Text);

            textBox1.Text = listView2_LR.Items[index].SubItems[1].Text;

            textBox2.Text = listView2_LR.Items[index].SubItems[2].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Código para excluir
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.Deleteuser(id1);

            textBox1.Clear();
            textBox2.Clear();

            MessageBox.Show("excluido com sucesso",
                "aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            UpdateListView1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

            UpdateListView1();
        }
    }
}
