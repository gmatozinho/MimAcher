using System.Collections.Generic;
using System.IO;
using System.Net;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Utilitarios;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;

namespace MimAcher.Mobile.Utilitarios
{
    public static class CursorBD
    {
        public static int EnviarParticipante(Participante participante)
        {
            WebRequest requisicao = MontadorRequisicao.MontarRequisicaoPostUsuario();

            string json = JsonParser.MontarJsonUsuario(participante);
            EnviarJson(json, requisicao);

            int codigo_usuario = (int)ObterResposta(requisicao);

            requisicao = MontadorRequisicao.MontarRequisicaoPostParticipante();
            json = JsonParser.MontarJsonParticipante(participante);
            EnviarJson(json, requisicao);

            int codigo_participante = (int)ObterResposta(requisicao);

            return codigo_participante;
        }

        public static void EnviarItens(TipoItem tipo, List<string> itens)
        {

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
    }
}