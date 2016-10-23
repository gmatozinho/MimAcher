using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorNascimento
    {
        private readonly Random random = new Random();
        private readonly static DateTime dataInicio = new DateTime(1960, 1, 1);
        private readonly static DateTime dataFim = new DateTime(2003, 12, 31);
        private readonly int rangeDias = (dataFim - dataInicio).Days;

        public DateTime GerarDia()
        {
            return (dataInicio.AddDays(random.Next(rangeDias)));
        }
    }
}
