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
    public class Nac : Usuario
    {
        public static int TipoUsuario {
            get { return 2; }
        }

        public Nac(Dictionary<string, string> atributos) : base(atributos)
        {
            this.NomeRepresentante = atributos["nomeRepresentante"];
        }

        private string NomeRepresentante { get; set; }
        
    }
}