using Npgsql;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class FabricaInt
    {
        public static void MontarParametroTelefone(NpgsqlCommand comando, object valor)
        {
            ParametroInt.Construir("telefone_param", comando);
            Parametro.AtribuirValor("telefone_param", comando, valor);
        }

        public static void MontarParametroCampus(NpgsqlCommand comando, object valor)
        {
            ParametroInt.Construir("campus_param", comando);
            Parametro.AtribuirValor("campus_param", comando, valor);
        }

        public static void MontarParametroCodigoParticipante(NpgsqlCommand comando, object valor)
        {
            ParametroInt.Construir("codigo_participante", comando);
            Parametro.AtribuirValor("codigo_participante", comando, valor);
        }
    }
}
