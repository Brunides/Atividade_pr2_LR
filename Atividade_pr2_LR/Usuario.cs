using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_pr2_LR
{
    public class Usuario
    {
        private string _id;
        private string _uSER_LR;
        private string _sENHA;


        public Usuario(string user, string password)
        {

            USER_LR = user;
            SENHA = password;

        }
        public string id
        {
            set
            {
                id = value;

            }
            get
            {
                return _id;
            }
        }
        public string USER_LR
        { 
            set
            {
                USER_LR = value;
                
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
                SENHA = value;
            }
            get
            {
                return _sENHA;
            }
        }

    }
}
