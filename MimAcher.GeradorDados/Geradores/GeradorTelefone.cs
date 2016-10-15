using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorTelefone
    {
        private Random random = new Random();
        public int GerarTelefone()
        {
            return random.Next(300000000, 99999999);
        }
    }
}
