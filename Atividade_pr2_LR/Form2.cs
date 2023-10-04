using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_pr2_LR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string senhaInserida = textBoxSenha.Text;
            string senhaCorreta = "brunid123"; // Substitua isso pela senha correta

            if (senhaInserida == senhaCorreta)
            {
                // A senha está correta, então você pode abrir o novo formulário
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {
                // A senha está incorreta, exiba uma mensagem de erro
                MessageBox.Show("Senha incorreta. Tente novamente.");
                textBoxSenha.Clear(); // Limpa o campo de senha
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
