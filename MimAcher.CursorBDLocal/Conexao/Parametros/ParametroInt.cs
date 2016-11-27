using System.Data;
using System.Data.Common;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class ParametroInt
    {
        public static void Construir(string nome_parametro, DbCommand comando)
        {
            var parametro = comando.CreateParameter();
            parametro.DbType = DbType.Int32;
            parametro.ParameterName = nome_parametro;
            comando.Parameters.Add(parametro);
        }
    }
}
