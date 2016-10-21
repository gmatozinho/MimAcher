using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using MimAcher.Entidades;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class FabricaParametros
    {
        public static void CriarParametrosParticipante(NpgsqlCommand comando, Participante participante, Dictionary<string, int> campi)
        {
            FabricaString.MontarParametroNome(comando, participante.Nome);
            FabricaString.MontarParametroEmail(comando, participante.Email);
            FabricaString.MontarParametroSenha(comando, participante.Senha);

            FabricaDate.MontarParametroNascimento(comando, participante.Nascimento);

            FabricaInt.MontarParametroTelefone(comando, participante.Telefone);
            FabricaInt.MontarParametroCampus(comando, campi[participante.Campus]);
        }

        public static void CriarParametrosItem(NpgsqlCommand comando, string nome_item, int codigo_participante)
        {
            FabricaString.MontarParametroItem(comando, nome_item);
            FabricaInt.MontarParametroCodigoParticipante(comando, codigo_participante);
        }
    }
}
