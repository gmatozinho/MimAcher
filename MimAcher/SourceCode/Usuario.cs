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

namespace MimAcher.SourceCode
{
    public abstract class Usuario
    {
        private string id;
        private string senha;

        public Usuario(string id, string senha)
        {
            this.id = id;
            this.senha = senha;
        }

        public Boolean login(string password)
        {
            if (password.Equals(this.senha))
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