using System;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorTelefone
    {
        private readonly Random random = new Random();
        public int GerarTelefone()
        {
            return random.Next(30000000, 99999999);
        }
    }
}
