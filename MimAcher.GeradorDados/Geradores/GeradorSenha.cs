using System;
using System.Linq;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorSenha
    {
        private static Random random = new Random();
        private static string caracteresValidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public string GerarSenha(int length)
        {
            return new string(Enumerable.Repeat(caracteresValidos, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
