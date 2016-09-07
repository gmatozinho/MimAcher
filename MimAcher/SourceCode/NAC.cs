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
    public class NAC : Usuario
    {
        private static int tipoUsuario = 2;
        private string nomeRepresentante;

        public NAC(Dictionary<string, string> atributos) : base(atributos)
        {
            this.NomeRepresentante = atributos["nomeRepresentante"];
        }

        public string NomeRepresentante {
            get {
                return nomeRepresentante;
            }

            set {
                nomeRepresentante = value;
            }
        }
    }
}