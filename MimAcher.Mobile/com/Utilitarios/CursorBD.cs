using System.Collections.Generic;
using System.IO;
using System.Net;
using MimAcher.Mobile.com.Entidades;
using Newtonsoft.Json.Linq;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class CursorBd
    {
        public static int CadastrarParcipante(Participante participante)
        {
            var requisicao = MontadorRequisicao.MontarRequisicaoPostUsuario();

            var json = JsonParser.MontarJsonUsuario(participante);
            EnviarJson(json, requisicao);

            var resposta = ObterResposta(requisicao);

            var jsonResposta = JObject.Parse(resposta.ToString());
            var codigoParticipante = int.Parse(jsonResposta.SelectToken("codigo").ToString().Replace("{", "").Replace("}", ""));

            return codigoParticipante;
        }

        //TODO: setar valor de retorno correto
        public static object EnviarItem(string item)
        {
            var json = JsonParser.MontarJsonItem(item);
            var requisicao = MontadorRequisicao.MontarRequisicaoPostItem();
            EnviarJson(json, requisicao);

            return ObterResposta(requisicao);
        }

        public static Dictionary<string, List<Participante>> Match(Participante a)
        {
            var matchs = new Dictionary<string, List<Participante>>
            {
                ["hobbies"] = new List<Participante>(),
                ["aprender"] = new List<Participante>(),
                ["ensinar"] = new List<Participante>()
            };


            //TODO: buscar os matchs no banco

            return matchs;
        }

        private static void EnviarJson(string json, WebRequest requisicao)
        {
            using (var streamSaida = new StreamWriter(requisicao.GetRequestStream()))
            {
                streamSaida.Write(json);
                streamSaida.Flush();
                streamSaida.Close();
            }
        }
        //TODO: setar valor de retorno correto
        private static object ObterResposta(WebRequest requisicao)
        {
            WebResponse resposta = (HttpWebResponse)requisicao.GetResponse();
            string resultado;
            using (var streamEntrada = new StreamReader(resposta.GetResponseStream()))
            {
                resultado = streamEntrada.ReadToEnd();
                streamEntrada.Close();
            }

            return resultado;
        }

        public static Dictionary<int, string> ObterCampi()
        {
            var campi = new Dictionary<int, string>();
            var requisicao = MontadorRequisicao.MontarRequisicaoGetCampi();
            var objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            var listaCampi = objetoResposta.SelectToken("data");

            foreach (var token in listaCampi)
            {
                var chave = token.SelectToken("cod_campus").ToString().Replace("{", "").Replace("}", "");
                var valor = token.SelectToken("local").ToString().Replace("{", "").Replace("}", "");

                campi[int.Parse(chave)] = valor;
            }

            return campi;
        }

        public static Dictionary<int, string> ObterItens()
        {
            var itens = new Dictionary<int, string>();
            var requisicao = MontadorRequisicao.MontarRequisicaoGetItem();
            var objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            var listaItens = objetoResposta.SelectToken("data");

            foreach (var token in listaItens)
            {
                var chave = token.SelectToken("cod_item").ToString().Replace("{", "").Replace("}", "");
                var valor = token.SelectToken("nome").ToString().Replace("{", "").Replace("}", "");

                itens[int.Parse(chave)] = valor;
            }

            return itens;
        }

        public static void EnviarHobbie(int codigoParticipante, int codigoItem)
        {
            var json = JsonParser.MontarJsonHobbie(codigoParticipante, codigoItem);
            var requisicao = MontadorRequisicao.MontarRequisicaoPostHobbie();
            EnviarJson(json, requisicao);
        }

        public static void EnviarAprender(int codigoParticipante, int codigoItem)
        {
            var json = JsonParser.MontarJsonAprender(codigoParticipante, codigoItem);
            var requisicao = MontadorRequisicao.MontarRequisicaoPostAprender();
            EnviarJson(json, requisicao);
        }

        public static void EnviarEnsinar(int codigoParticipante, int codigoItem)
        {
            var json = JsonParser.MontarJsonEnsinar(codigoParticipante, codigoItem);
            var requisicao = MontadorRequisicao.MontarRequisicaoPostEnsinar();
            EnviarJson(json, requisicao);
        }
    }
}