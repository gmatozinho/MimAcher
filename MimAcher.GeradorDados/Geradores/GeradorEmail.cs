using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    public class GeradorEmail
    {
        public Random _random = new Random();
        private string email, prefixo, servidoeEmail;
        
        private static readonly List<string> servidores_email =
            new List<string>() { "gmail.com", "hotmail.com", "", "bol.com.br", "live.com", "outlook.com", "ifes.edu.br", "yahoo.com.br"};

        public string GerarEmail(string nome)
        {
            prefixo = (RemoverEspacos(nome)).ToLower();

            servidoeEmail = servidores_email[_random.Next(0, servidores_email.Count)];
            email = string.Format("{0}@{1}", prefixo, servidoeEmail);

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
