using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class FabricaDate
    {
        public static void MontarParametroNascimento(NpgsqlCommand comando, object valor)
        {
            ParametroDate.Construir("nascimento_param", comando);
            Parametro.AtribuirValor("nascimento_param", comando, valor);
        }
    }
}
