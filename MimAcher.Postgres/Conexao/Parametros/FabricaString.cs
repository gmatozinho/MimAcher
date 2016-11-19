using System.Data.Common;

namespace MimAcher.BancoDadosLocal.Conexao.Parametros
{
    internal static class FabricaString
    {
        public static void MontarParametroNome(DbCommand comando, object valor)
        {
            ParametroString.Construir("nome_param", comando);
            Parametro.AtribuirValor("nome_param", comando, valor);
        }

        public static void MontarParametroEmail(DbCommand comando, object valor)
        {
            ParametroString.Construir("email_param", comando);
            Parametro.AtribuirValor("email_param", comando, valor);
        }

        public static void MontarParametroSenha(DbCommand comando, object valor)
        {
            ParametroString.Construir("senha_param", comando);
            Parametro.AtribuirValor("senha_param", comando, valor);
        }

        public static void MontarParametroItem(DbCommand comando, object valor)
        {
            ParametroString.Construir("nome_item", comando);
            Parametro.AtribuirValor("nome_item", comando, valor);
        }
    }
}
