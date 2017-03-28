using System.Data;
using System.Data.Common;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class ParametroDate
    {
        public static void Construir(string nomeParametro, DbCommand comando)
        {
            var parametro = comando.CreateParameter();
            parametro.DbType = DbType.Date;
            parametro.ParameterName = nomeParametro;
            comando.Parameters.Add(parametro);
        }
    }
}
