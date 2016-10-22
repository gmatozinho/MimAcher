using System;
using System.Collections.Generic;

namespace MimAcher.Mobile.Entidades
{

    public abstract class Usuario : PacoteAbstrato
    {
        protected Usuario(Dictionary<string, string> atributos)
        {
            if (atributos == null) throw new ArgumentNullException(nameof(atributos));
            Email = atributos["email"];
            Senha = atributos["senha"];
        }

        public string Email { get; private set; }

        public string Senha {get; set;}

/*
        public bool Login(string password)
        {
            return password.Equals(Senha);
        }
*/

/*
        public void AlterarSenha(string senhaAtual, string novaSenha)
        {
            if (senhaAtual.Equals("senha"))
            {
                Senha = novaSenha;
            }
        }
*/

/*
        public void DesativarConta()
        {
            //c�digo para excluir o usu�rio do banco
        }
*/
    }
}