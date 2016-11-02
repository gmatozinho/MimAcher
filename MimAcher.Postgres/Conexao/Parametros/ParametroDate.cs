using Npgsql;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class ParametroDate
    {
        public static void Construir(string nome_parametro, NpgsqlCommand comando)
        {
            var parametro = comando.CreateParameter();
            parametro.DbType = System.Data.DbType.Date;
            parametro.ParameterName = nome_parametro;
            comando.Parameters.Add(parametro);
        }
    }
}
