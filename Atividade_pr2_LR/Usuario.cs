using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_pr2_LR
{
    public class Usuario
    {

        private int _id;
        private string _uSER_LR;
        private string _sENHA;


        public Usuario(int id,string user, string password)
        {
            Id= id;
            USER_LR = user;
            SENHA = password;

        }

        public int Id//y
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
