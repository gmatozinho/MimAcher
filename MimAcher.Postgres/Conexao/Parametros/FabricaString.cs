using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MimAcher.Postgres.Conexao.Parametros
{
    internal static class FabricaString
    {
        public static void MontarParametroNome(NpgsqlCommand comando, object valor)
        {
            ParametroString.Construir("nome_param", comando);
            Parametro.AtribuirValor("nome_param", comando, valor);
        }

        public static void MontarParametroEmail(NpgsqlCommand comando, object valor)
        {
            ParametroString.Construir("email_param", comando);
            Parametro.AtribuirValor("email_param", comando, valor);
        }

        public static void MontarParametroSenha(NpgsqlCommand comando, object valor)
        {
            ParametroString.Construir("senha_param", comando);
            Parametro.AtribuirValor("senha_param", comando, valor);
        }

        public static void MontarParametroItem(NpgsqlCommand comando, object valor)
        {
            ParametroString.Construir("nome_item", comando);
            Parametro.AtribuirValor("nome_item", comando, valor);
        }
    }
}
