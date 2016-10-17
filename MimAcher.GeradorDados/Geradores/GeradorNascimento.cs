using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorNascimento
    {
        private Random gen = new Random();
        private static DateTime dataInicio = new DateTime(1960, 1, 1);
        private static DateTime dataFim = new DateTime(2003, 12, 31);
        private int rangeDias = (dataFim - dataInicio).Days;

        public DateTime GerarDia()
        {
            return dataInicio.AddDays(gen.Next(rangeDias));
        }
    }
}
