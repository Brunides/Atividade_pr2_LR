using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_pr2_LR
{
    public partial class Form1 : Form
    {
        private int Id;
        public Form1()
        {
            InitializeComponent();
            UpdateListView();

        }
        private void UpdateListView()
        {
            ListView1_LR.Items.Clear();

          


            UsuarioDAO usuarioDAO = new UsuarioDAO();
            List<Usuario> usuarios = usuarioDAO.SelectUser();
            try
            {
              

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
              
            foreach(Usuario usuario in usuarios) 
                {
                    ListViewItem lv = new ListViewItem(usuario.Id.ToString());


                    lv.SubItems.Add(usuario.USER_LR);
                    lv.SubItems.Add(usuario.SENHA);
                    ListView1_LR.Items.Add(lv);

                }
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
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

            try
            {
                Usuario usuario = new Usuario(Id, textBox1.Text, textBox2.Text);
                UsuarioDAO dAO = new UsuarioDAO();
                dAO.Insertuser(Id, textBox1.Text, textBox2.Text);

            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }

            textBox1.Clear();
            textBox2.Clear();

            UpdateListView();
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
            UsuarioDAO dAO = new UsuarioDAO();
            dAO.Edituser(Id, textBox1.Text, textBox2.Text);

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
          
        }

        private void ListView1_LR_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();


           
        }

        private void ListView1_LR_MouseDoubleClick_2(object sender, MouseEventArgs e)
        {
            int index;
            index = ListView1_LR.FocusedItem.Index;
            Id = int.Parse(ListView1_LR.Items[index].SubItems[0].Text);

            textBox1.Text = ListView1_LR.Items[index].SubItems[1].Text;

            textBox2.Text = ListView1_LR.Items[index].SubItems[2].Text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UpdateListView();
        }
    }
}
