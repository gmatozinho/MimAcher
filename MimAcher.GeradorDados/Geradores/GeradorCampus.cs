using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorCampus
    {
        private static Random random = new Random();
        private static readonly List<string> campi =
            new List<string>() {"Serra", "Vitoria", "Itapina", "Santa Tereza", "Vila Velha", "Itaciba"};

        public string GerarCampus()
        {
            return campi[random.Next(0, campi.Count)];
        }
    }
}
