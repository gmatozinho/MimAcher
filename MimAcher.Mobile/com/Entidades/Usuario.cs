using System;
using System.Collections.Generic;
using Android.Content;
using MimAcher.Mobile.com.Utilitarios;
using MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador;

namespace MimAcher.Mobile.com.Entidades
{

    public abstract class Usuario : PacoteAbstrato
    {
        protected Usuario(Dictionary<string, string> atributos)
        {
            if (atributos == null) throw new ArgumentNullException(nameof(atributos));
            Email = atributos["email"];
            Senha = atributos["senha"];
        }

        public string Email { get; set; }

        public string Senha {get; private set;}


        public static string Login(Context context, Dictionary<string, string> emailESenha)
        {
            if (Validacao.ValidarLogin(context,emailESenha)) return CursorBd.Login(emailESenha);
            return "-2";
        }

        public void AlterarSenha(string novaSenha)
        {
            Senha = novaSenha;
        }

        

    }
}