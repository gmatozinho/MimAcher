using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using MimAcher.Mobile.Entidades;
using Newtonsoft.Json.Linq;

namespace MimAcher.Mobile.Utilitarios
{
    public static class CursorBD
    {
        public static int EnviarParticipante(Participante participante)
        {
            WebRequest requisicao = MontadorRequisicao.MontarRequisicaoPostUsuario();

            string json = JsonParser.MontarJsonUsuario(participante);
            EnviarJson(json, requisicao);

            var resposta = ObterResposta(requisicao);
            JObject json_resposta = JObject.Parse(resposta.ToString());
            int codigo_participante = Int32.Parse(json_resposta.SelectToken("codigo").ToString().Replace("{", "").Replace("}", ""));

            return codigo_participante;
        }

        //TODO: setar valor de retorno correto
        public static object EnviarItem(string item)
        {
            string json = JsonParser.MontarJsonItem(item);
            WebRequest requisicao = MontadorRequisicao.MontarRequisicaoPostItem();
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
            using (StreamWriter streamSaida = new StreamWriter(requisicao.GetRequestStream()))
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
            using (StreamReader streamEntrada = new StreamReader(resposta.GetResponseStream()))
            {
                resultado = streamEntrada.ReadToEnd();
                streamEntrada.Close();
            }

            return resultado;
        }

        public static Dictionary<int, string> ObterCampi()
        {
            Dictionary<int, string> campi = new Dictionary<int, string>();
            WebRequest requisicao = MontadorRequisicao.MontarRequisicaoGetCampi();
            var objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            var listaCampi = objetoResposta.SelectToken("data");

            foreach (var token in listaCampi)
            {
                string chave = token.SelectToken("cod_campus").ToString().Replace("{", "").Replace("}", "");
                string valor = token.SelectToken("local").ToString().Replace("{", "").Replace("}", "");

                campi[Int32.Parse(chave)] = valor;
            }

            return campi;
        }

        public static Dictionary<int, string> ObterItens()
        {
            Dictionary<int, string> itens = new Dictionary<int, string>();
            WebRequest requisicao = MontadorRequisicao.MontarRequisicaoGetItem();
            var objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            var listaItens = objetoResposta.SelectToken("data");

            foreach (var token in listaItens)
            {
                string chave = token.SelectToken("cod_item").ToString().Replace("{", "").Replace("}", "");
                string valor = token.SelectToken("nome").ToString().Replace("{", "").Replace("}", "");

                itens[Int32.Parse(chave)] = valor;
            }

            return itens;
        }

        public static void EnviarHobbie(int codigo_participante, int codigo_item)
        {
            string json = JsonParser.MontarJsonHobbie(codigo_participante, codigo_item);
            WebRequest requisicao = MontadorRequisicao.MontarRequisicaoPostHobbie();
            EnviarJson(json, requisicao);
        }

        public static void EnviarAprender(int codigo_participante, int codigo_item)
        {
            string json = JsonParser.MontarJsonAprender(codigo_participante, codigo_item);
            WebRequest requisicao = MontadorRequisicao.MontarRequisicaoPostAprender();
            EnviarJson(json, requisicao);
        }

        public static void EnviarEnsinar(int codigo_participante, int codigo_item)
        {
            string json = JsonParser.MontarJsonEnsinar(codigo_participante, codigo_item);
            WebRequest requisicao = MontadorRequisicao.MontarRequisicaoPostEnsinar();
            EnviarJson(json, requisicao);
        }
    }
}