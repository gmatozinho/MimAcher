using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class ParametroInt
    {
        public static void Construir(string nome_parametro, NpgsqlCommand comando)
        {
            var parametro = comando.CreateParameter();
            parametro.DbType = System.Data.DbType.Int32;
            parametro.ParameterName = nome_parametro;
            comando.Parameters.Add(parametro);
        }
    }
}
