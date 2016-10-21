using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal class Parametro
    {
        public static void AtribuirValor(string nome_parametro, NpgsqlCommand comando, object valor)
        {
            comando.Parameters[nome_parametro].Value = valor;
        }
    }
}
