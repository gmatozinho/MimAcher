using System.Collections.Generic;
using System.IO;
using System.Net;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Utilitarios
{
    public static class CursorBD
    {
        public static bool EnviarParticipante(Participante participante)
        {
            WebRequest requisicao = MontardorRequisicao.MontarRequisicaoUsuario();

            string json = JsonParser.MontarJsonUsuario(participante);
            EnviarJson(json, requisicao);

            ObterResposta(requisicao);

            requisicao = MontardorRequisicao.MontarRequisicaoParticipante();
            json = JsonParser.MontarJsonParticipante(participante);
            EnviarJson(json, requisicao);

            return ObterResposta(requisicao);
        }

        public static void EnviarItens(TipoItem tipo, List<string> itens)
        {

        }

        //TODO: setar valor de retorno correto
        public static bool EnviarItem(string item)
        {
            string json = JsonParser.MontarJsonItem(item);
            WebRequest requisicao = MontardorRequisicao.MontarRequisicaoItem();
            EnviarJson(json, requisicao);

            return ObterResposta(requisicao);
        }

        public static Dictionary<string, List<Participante>> Match(Participante a)
        {
            var matchs = new Dictionary<string, List<Participante>>
            {
                ["gostos"] = new List<Participante>(),
                ["interesses"] = new List<Participante>(),
                ["competencias"] = new List<Participante>()
            };


            //TODO: buscar os matchs no banco

            return matchs;
        }

        private static void EnviarJson(string json, WebRequest requisicao)
        {
            using (StreamWriter streamSaida = new StreamWriter(requisicao.GetRequestStream()))
            {
                streamSaida.Write(json);
                streamSaida.Flush();
                streamSaida.Close();
            }
        }
        //TODO: setar valor de retorno correto
        private static bool ObterResposta(WebRequest requisicao)
        {
            WebResponse resposta = (HttpWebResponse)requisicao.GetResponse();
            string resultado;
            using (StreamReader streamEntrada = new StreamReader(resposta.GetResponseStream()))
            {
                resultado = streamEntrada.ReadToEnd();
                streamEntrada.Close();
            }

            bool sucesso;

            if (resultado.Contains("True"))
                sucesso = true;
            else sucesso = false;

            return sucesso;
        }
    }
}