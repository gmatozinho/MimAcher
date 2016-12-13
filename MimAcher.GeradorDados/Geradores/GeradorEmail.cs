using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    public class GeradorEmail
    {
        public readonly Random Random = new Random();
        
        private static readonly List<string> ServidoresEmail =
            new List<string>() { "gmail.com", "hotmail.com", "bol.com.br", "live.com", "outlook.com", "ifes.edu.br", "yahoo.com.br"};

        public string GerarEmail(string nome)
        {
            string prefixo = (RemoverEspacos(nome)).ToLower(CultureInfo.InvariantCulture);

            string servidorEmail = ServidoresEmail[Random.Next(0, ServidoresEmail.Count)];
            string email = string.Format("{0}@{1}", prefixo, servidorEmail);

            return email;
        }

        private string RemoverEspacos(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
