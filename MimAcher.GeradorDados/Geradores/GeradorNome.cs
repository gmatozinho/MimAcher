using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    public class GeradorNome
    {
        public Random _random = new Random();
        private string nomeCompleto, primeiroNome, nomeMeio, ultimoNome;

        private static readonly List<string> nomes =
            new List<string>() { "Cayo", "Gustavo", "Moises", "Joao", "Ricardo" };

        private static readonly List<string> nomes_meio =
            new List<string>() { "Paulo", "Matozinho", "", "da Silva", "Costa" };

        private static readonly List<string> sobrenomes =
            new List<string>() { "Donatti", "Lima", "Pandolfi", "Pereira", "Schrodinger" };

        public string GerarNome()
        {
            primeiroNome = nomes[_random.Next(0, nomes.Count)];
            nomeMeio = nomes_meio[_random.Next(0, nomes_meio.Count)];
            ultimoNome = sobrenomes[_random.Next(0, sobrenomes.Count)];
            nomeCompleto = string.Format("{0} {1} {2}", primeiroNome, nomeMeio, ultimoNome);

            return nomeCompleto;
        }
    }
}
