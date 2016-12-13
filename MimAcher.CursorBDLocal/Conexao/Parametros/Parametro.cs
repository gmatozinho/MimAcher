using System.Data.Common;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class Parametro
    {
        public static void AtribuirValor(string nomeParametro, DbCommand comando, object valor)
        {
            comando.Parameters[nomeParametro].Value = valor;
        }
    }
}
