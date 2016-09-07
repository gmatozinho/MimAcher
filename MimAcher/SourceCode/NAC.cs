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
        //geography local;

        public NAC(string id, string senha, string nomeRepresentante/*, geography local*/) : base(id, senha)
        {
            this.nomeRepresentante = nomeRepresentante;
            //this.local = local;
        }
    }
}