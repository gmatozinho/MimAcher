using System.Data;
using Npgsql;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class ParametroString
    {
        public static void Construir(string nome_parametro, NpgsqlCommand comando)
        {
            var parametro = comando.CreateParameter();
            parametro.DbType = DbType.AnsiString;
            parametro.ParameterName = nome_parametro;
            comando.Parameters.Add(parametro);
        }
    }
}
