using System.Collections.Generic;
using System.Data.Common;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class FabricaParametros
    {
        public static void CriarParametrosParticipante(DbCommand comando, Participante participante, Dictionary<string, int> campi)
        {
            FabricaString.MontarParametroNome(comando, participante.Nome);
            FabricaString.MontarParametroEmail(comando, participante.Email);
            FabricaString.MontarParametroSenha(comando, participante.Senha);

            FabricaDate.MontarParametroNascimento(comando, participante.Nascimento);

            FabricaInt.MontarParametroTelefone(comando, participante.Telefone);
            FabricaInt.MontarParametroCampus(comando, campi[participante.Campus]);
        }

        public static void CriarParametrosItem(DbCommand comando, string nomeItem, int codigoParticipante)
        {
            FabricaString.MontarParametroItem(comando, nomeItem);
            FabricaInt.MontarParametroCodigoParticipante(comando, codigoParticipante);
        }
    }
}
