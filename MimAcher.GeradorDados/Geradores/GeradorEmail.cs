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
        public readonly Random _random = new Random();
        
        private static readonly List<string> servidores_email =
            new List<string>() { "gmail.com", "hotmail.com", "bol.com.br", "live.com", "outlook.com", "ifes.edu.br", "yahoo.com.br"};

        public string GerarEmail(string nome)
        {
            string prefixo = (RemoverEspacos(nome)).ToLower(CultureInfo.InvariantCulture);

            string servidorEmail = servidores_email[_random.Next(0, servidores_email.Count)];
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
