using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorCampus
    {
        private static Random _random = new Random();
        private static readonly List<string> Campi =
            new List<string>() {"Serra", "Vitoria", "Itapina", "Santa Tereza", "Vila Velha", "Itaciba"};

        public string GerarCampus()
        {
            return Campi[_random.Next(0, Campi.Count)];
        }
    }
}
