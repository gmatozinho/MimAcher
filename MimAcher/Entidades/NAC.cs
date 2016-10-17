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
        
        public Nac(Dictionary<string, string> atributos) : base(atributos)
        {
            NomeRepresentante = atributos["nomeRepresentante"];
            Campus = atributos["campus"];
            Telefone = atributos["telefone"];
        }

        public string NomeRepresentante { get; set; }
        public string Campus { get; set; }
        public string Telefone { get; set; }
    }
}