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

        private List<string> nomes = new List<string>();

        private List<string> nomes_meio = new List<string>();

        private List<string> sobrenomes = new List<string>();

        public GeradorNome()
        {
            string linha; //Indica uma linha lida de um arquivo

            //Lendo arquivo de nomes
            System.IO.StreamReader file =
               new System.IO.StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\nome");
            while ((linha = file.ReadLine()) != null)
            {
                nomes.Add(linha.Trim().ToLower());
            }

            file.Close();

            //Lendo arquivo de nomes do meio
            file =
               new System.IO.StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\nomeMeio");
            while ((linha = file.ReadLine()) != null)
            {
                nomes_meio.Add(linha.Trim().ToLower());
            }

            file.Close();

            //Lendo arquivo de sobrenomes
            file =
               new System.IO.StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\sobrenome");
            while ((linha = file.ReadLine()) != null)
            {
                sobrenomes.Add(linha.Trim().ToLower());
            }

            file.Close();
        }

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
