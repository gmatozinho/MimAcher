using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Geradores
{
    class GeradorNascimento
    {
        private readonly Random _random = new Random();
        private readonly static DateTime DataInicio = new DateTime(1960, 1, 1);
        private readonly static DateTime DataFim = new DateTime(2003, 12, 31);
        private readonly int _rangeDias = (DataFim - DataInicio).Days;

        public DateTime GerarDia()
        {
            return (DataInicio.AddDays(_random.Next(_rangeDias)));
        }
    }
}
