using System.Collections.Generic;

namespace MimAcher.Mobile.Entidades
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