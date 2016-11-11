using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MimAcher.GeradorDados.Geradores
{
    public class GeradorNome
    {
        public readonly Random random = new Random();

        private readonly List<string> nomes = new List<string>();

        private readonly List<string> nomes_meio = new List<string>();

        private readonly List<string> sobrenomes = new List<string>();

        public GeradorNome()
        {
            string linha; //Indica uma linha lida de um arquivo

            //Lendo arquivo de nomes
            StreamReader file =
               new StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\nome");
            while ((linha = file.ReadLine()) != null)
            {
                nomes.Add(linha.Trim().ToLower(CultureInfo.InvariantCulture));
            }

            file.Close();

            //Lendo arquivo de nomes do meio
            file =
               new StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\nomeMeio");
            while ((linha = file.ReadLine()) != null)
            {
                nomes_meio.Add(linha.Trim().ToLower(CultureInfo.InvariantCulture));
            }

            file.Close();

            //Lendo arquivo de sobrenomes
            file =
               new StreamReader("..\\..\\..\\MimAcher.GeradorDados\\Geradores\\Dados\\sobrenome");
            while ((linha = file.ReadLine()) != null)
            {
                sobrenomes.Add(linha.Trim().ToLower(CultureInfo.InvariantCulture));
            }

            file.Close();
        }

        public string GerarNome()
        {
            string primeiroNome = nomes[random.Next(0, nomes.Count)];
            string nomeMeio = nomes_meio[random.Next(0, nomes_meio.Count)];
            string ultimoNome = sobrenomes[random.Next(0, sobrenomes.Count)];
            string nomeCompleto = string.Format("{0} {1} {2}", primeiroNome, nomeMeio, ultimoNome);

            return nomeCompleto;
        }
    }
}
