using Npgsql;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class Parametro
    {
        public static void AtribuirValor(string nome_parametro, NpgsqlCommand comando, object valor)
        {
            comando.Parameters[nome_parametro].Value = valor;
        }
    }
}
