using System;
using System.Collections.Generic;

namespace MimAcher.Entidades
{

    public abstract class Usuario
    {
        protected Usuario(Dictionary<string, string> atributos)
        {
            if (atributos == null) throw new ArgumentNullException(nameof(atributos));
            Email = atributos["email"];
            Senha = atributos["senha"];
        }

        public string Email { get; set; }

        public string Senha {get; set;}

        public bool Login(string password)
        {
            return password.Equals(Senha);
        }

        public void AlterarSenha(string senhaAtual, string novaSenha)
        {
            if (senhaAtual.Equals("senha"))
            {
                Senha = novaSenha;
            }
        }

        public void DesativarConta()
        {
            //código para excluir o usuário do banco
        }
    }
}