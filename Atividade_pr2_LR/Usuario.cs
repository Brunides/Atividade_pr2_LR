using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Atividade_pr2_LR
{
    public class Usuario
    {

        private int _id;
        private string _uSER_LR;
        private string _sENHA;
        private string _nOME;
        private string _tELEFONE;
        private string _email;
     


        public Usuario(int id,string user, string password)
        {
            Id= id;
            USER_LR = user;
            SENHA = password;
        }
        public Usuario(int id, string nome, string telefone, string email)
        {
            ID = id;
            NOME = nome;
            TELEFONE = telefone;
            Email = email;
        }

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        public string USER_LR
        { 
            set
            {
                _uSER_LR = value;
                
            }
            get 
            {
            return _uSER_LR;
            }
        }  
        public string SENHA
        { 
            set
            {
                _sENHA = value;
            }
            get
            {
                return _sENHA;
            }
        }
        public int ID
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        public string NOME
        {
            set
            {
                _nOME = value;

            }
            get
            {
                return _nOME;
            }
        }
        public string TELEFONE
        {
            set
            {
                _tELEFONE = value;
            }
            get
            {
                return _tELEFONE;
            }
        }


        public string Email
        {

            set
            {

                _email = value;
            }
            get
            {

                return _email;
            }

        }



        public string user
        {

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo Nome está vazio");

                _uSER_LR = value;
            }
            get { return _uSER_LR; }
        }
           public string password
        {

            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new Exception("campo Nome está vazio");

                _sENHA= value;
            }
            get { return _sENHA; }
        }

        

    }
}
