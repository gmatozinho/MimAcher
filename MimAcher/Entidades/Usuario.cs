using System;
using System.Collections.Generic;

namespace MimAcher.Entidades
{

    public abstract class Usuario
    {
        
        public Usuario(Dictionary<string, string> atributos)
        {
            this.Id = atributos["id"];
            this.Senha = atributos["senha"];
        }

        public string Id { get; set; }

        protected string Senha {get; set;}

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
    }
}