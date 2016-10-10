using System;
using System.Collections.Generic;

namespace MimAcher.Entidades
{

    public abstract class Usuario
    {
        
        public Usuario(Dictionary<string, string> atributos)
        {
            Email = atributos["email"];
            Senha = atributos["senha"];
        }

        public string Email { get; set; }

        public string Senha {get; set;}

        public Boolean Login(string password)
        {
            if (password.Equals(this.Senha))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void DesativarConta()
        {
            //código para excluir o usuário do banco
        }
    }
}