using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    public class GeradorNome
    {
        public readonly Random Random = new Random();

        private readonly List<string> _nomes = new List<string>();

        private readonly List<string> _nomesMeio = new List<string>();

        private readonly List<string> _sobrenomes = new List<string>();

        public GeradorNome()
        {
            string linha; //Indica uma linha lida de um arquivo

            //Lendo arquivo de nomes
            System.IO.StreamReader file =
               new System.IO.StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\nome");
            while ((linha = file.ReadLine()) != null)
            {
                _nomes.Add(linha.Trim().ToLower(CultureInfo.InvariantCulture));
            }

            file.Close();

            //Lendo arquivo de nomes do meio
            file =
               new System.IO.StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\nomeMeio");
            while ((linha = file.ReadLine()) != null)
            {
                _nomesMeio.Add(linha.Trim().ToLower(CultureInfo.InvariantCulture));
            }

            file.Close();

            //Lendo arquivo de sobrenomes
            file =
               new System.IO.StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\sobrenome");
            while ((linha = file.ReadLine()) != null)
            {
                _sobrenomes.Add(linha.Trim().ToLower(CultureInfo.InvariantCulture));
            }

            file.Close();
        }

        public string GerarNome()
        {
            string primeiroNome = _nomes[Random.Next(0, _nomes.Count)];
            string nomeMeio = _nomesMeio[Random.Next(0, _nomesMeio.Count)];
            string ultimoNome = _sobrenomes[Random.Next(0, _sobrenomes.Count)];
            string nomeCompleto = string.Format("{0} {1} {2}", primeiroNome, nomeMeio, ultimoNome);

            return nomeCompleto;
        }
    }
}
