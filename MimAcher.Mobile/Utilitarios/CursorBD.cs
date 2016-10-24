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

            using (StreamWriter streamSaida = new StreamWriter(requisicao.GetRequestStream()))
            {
                string json = JsonParser.MontarJsonUsuario(participante);
                EnviarJson(json, streamSaida);
            }

            ObterResposta(requisicao);
            requisicao = MontardorRequisicao.MontarRequisicaoParticipante();
            using (StreamWriter streamSaida = new StreamWriter(requisicao.GetRequestStream()))
            {
                string json = JsonParser.MontarJsonParticipante(participante);
                EnviarJson(json, streamSaida);
            }

            return ObterResposta(requisicao);
        }

        public static void EnviarItens(TipoItem tipo, List<string> itens)
        {

        }

        public static int EnviarItem(TipoItem tipo, string item)
        {
            int codigo_item = 1;

            return codigo_item;
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

        private static void EnviarJson(string json, StreamWriter streamSaida)
        {
            streamSaida.Write(json);
            streamSaida.Flush();
            streamSaida.Close();
        }

        private static bool ObterResposta(WebRequest requisicao)
        {
            WebResponse resposta = (HttpWebResponse)requisicao.GetResponse();
            string resultado;
            using (StreamReader streamEntrada = new StreamReader(resposta.GetResponseStream()))
            {
                resultado = streamEntrada.ReadToEnd();
            }

            bool sucesso;

            if (resultado.Contains("True"))
                sucesso = true;
            else sucesso = false;

            return sucesso;
        }
    }
}