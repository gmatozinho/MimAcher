using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorTelefone
    {
        private readonly Random _random = new Random();
        public int GerarTelefone()
        {
            return _random.Next(30000000, 99999999);
        }
    }
}
