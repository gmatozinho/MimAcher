using System.Data.Common;

namespace MimAcher.BancoDadosLocal.Conexao.Parametros
{
    internal static class FabricaInt
    {
        public static void MontarParametroTelefone(DbCommand comando, object valor)
        {
            ParametroInt.Construir("telefone_param", comando);
            Parametro.AtribuirValor("telefone_param", comando, valor);
        }

        public static void MontarParametroCampus(DbCommand comando, object valor)
        {
            ParametroInt.Construir("campus_param", comando);
            Parametro.AtribuirValor("campus_param", comando, valor);
        }

        public static void MontarParametroCodigoParticipante(DbCommand comando, object valor)
        {
            ParametroInt.Construir("codigo_participante", comando);
            Parametro.AtribuirValor("codigo_participante", comando, valor);
        }
    }
}
