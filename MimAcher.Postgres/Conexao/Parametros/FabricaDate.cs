using System.Data.Common;

namespace MimAcher.BancoDadosLocal.Conexao.Parametros
{
    internal static class FabricaDate
    {
        public static void MontarParametroNascimento(DbCommand comando, object valor)
        {
            ParametroDate.Construir("nascimento_param", comando);
            Parametro.AtribuirValor("nascimento_param", comando, valor);
        }
    }
}
