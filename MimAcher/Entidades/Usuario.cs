using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MimAcher.Entidades
{
    
    public abstract class Usuario
    {
        private string id;
        private string senha;

        public Usuario(Dictionary<string, string> atributos)
        {
            this.Id = atributos["id"];
            this.Senha = atributos["senha"];
        }

        public string Id {
            get {
                return id;
            }

            set {
                id = value;
            }
        }

        protected string Senha {
            get {
                return senha;
            }

            set {
                senha = value;
            }
        }

        public Boolean login(string password)
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