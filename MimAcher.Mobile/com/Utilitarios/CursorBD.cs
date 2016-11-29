using System.Collections.Generic;
using System.IO;
using System.Net;
using MimAcher.Mobile.com.Entidades;
using Newtonsoft.Json.Linq;
using System;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class CursorBd
    {
        public static string EnviarParticipante(Participante participante)
        {
            var requisicao = MontadorRequisicao.MontarRequisicaoPostUsuario();

            var json = JsonParser.MontarJsonUsuario(participante);
            EnviarJson(json, requisicao);

            var resposta = ObterResposta(requisicao);
            var jsonResposta = JObject.Parse(resposta.ToString());
            var codigoParticipante = jsonResposta.SelectToken("codigo").ToString().Replace("{", "").Replace("}", "");

            return codigoParticipante;
        }
        
        public static string EnviarItem(string item)
        {
            var json = JsonParser.MontarJsonItem(item);
            var requisicao = MontadorRequisicao.MontarRequisicaoPostItem();
            EnviarJson(json, requisicao);

            var resposta = ObterResposta(requisicao);
            var jsonResposta = JObject.Parse(resposta.ToString());
            var codigoItem = jsonResposta.SelectToken("codigo").ToString().Replace("{", "").Replace("}", "");

            return codigoItem;
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

        public static string Login(Dictionary<string, string> emailESenha)
        {
            var email = emailESenha["email"];
            var senha = emailESenha["senha"];

            var json = JsonParser.MontarJsonLogin(email, senha);
            var requisicao = MontadorRequisicao.MontarRequisicaoPostLogin();
            EnviarJson(json, requisicao);
            var objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            var resultado = objetoResposta.SelectToken("codigo");

            var codigoParticipante = resultado.ToString();

            return codigoParticipante;
        }

        public static void AtualizarParticipante(Participante participante)
        {
            var json = JsonParser.MontarJsonUpdateParticipante(participante);
            var requisicao = MontadorRequisicao.MontarRequisicaoUpdateParticipante();
            EnviarJson(json, requisicao);
        }

        public static Dictionary<string, List<string>> ObterParticipanteItem(int codigoParticipante, Dictionary<int, string> itens)
        {
            Dictionary<string, List<string>> relacoes = new Dictionary<string, List<string>>();

            var requisicao = MontadorRequisicao.MontarRequisicaoGetParticipanteHobbie();
            var objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            var listaItens = objetoResposta.SelectToken("data");

            var hobbies = new List<string>();
            foreach (var token in listaItens)
            {
                var codigoItem = token.SelectToken("cod_item").ToString().Replace("{", "").Replace("}", "");
                var codigoParticipanteRetorno = token.SelectToken("cod_participante").ToString().Replace("{", "").Replace("}", "");

                if (Int32.Parse(codigoParticipanteRetorno) == codigoParticipante) hobbies.Add(itens[Int32.Parse(codigoItem)]);
            }
            relacoes["hobbie"] = hobbies;

            requisicao = MontadorRequisicao.MontarRequisicaoGetParticipanteAprender();
            objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            listaItens = objetoResposta.SelectToken("data");

            var aprender = new List<string>();
            foreach (var token in listaItens)
            {
                var codigoItem = token.SelectToken("cod_item").ToString().Replace("{", "").Replace("}", "");
                var codigoParticipanteRetorno = token.SelectToken("cod_participante").ToString().Replace("{", "").Replace("}", "");

                if (Int32.Parse(codigoParticipanteRetorno) == codigoParticipante) aprender.Add(itens[Int32.Parse(codigoItem)]);
            }
            relacoes["aprender"] = aprender;

            requisicao = MontadorRequisicao.MontarRequisicaoGetParticipanteEnsinar();
            objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            listaItens = objetoResposta.SelectToken("data");

            var ensinar = new List<string>();
            foreach (var token in listaItens)
            {
                var codigoItem = token.SelectToken("cod_item").ToString().Replace("{", "").Replace("}", "");
                var codigoParticipanteRetorno = token.SelectToken("cod_participante").ToString().Replace("{", "").Replace("}", "");

                if (Int32.Parse(codigoParticipanteRetorno) == codigoParticipante) ensinar.Add(itens[Int32.Parse(codigoItem)]);
            }
            relacoes["ensinar"] = ensinar;
            
            return relacoes;
        }

        public static Dictionary<string, List<int>> Match(int codigoItem)
        {
            Dictionary<string, List<int>> matchs = new Dictionary<string, List<int>>();

            var requisicao = MontadorRequisicao.MontarRequisicaoMatchHobbie();
            var json = JsonParser.MontarJsonMatchHobbie(codigoItem);
            EnviarJson(json, requisicao);
            var objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            var listaItens = objetoResposta.SelectToken("listaparticipantehobbie");

            var listaParticipantes = new List<int>();
            foreach (var token in listaItens)
            {
                var codigoParticipante = token.SelectToken("cod_participante").ToString().Replace("{", "").Replace("}", "");

                listaParticipantes.Add(Int32.Parse(codigoParticipante));
            }

            matchs["hobbie"] = listaParticipantes;

            requisicao = MontadorRequisicao.MontarRequisicaoMatchAprender();
            json = JsonParser.MontarJsonMatchAprender(codigoItem);
            EnviarJson(json, requisicao);
            objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            listaItens = objetoResposta.SelectToken("listaparticipanteaprender");

            listaParticipantes = new List<int>();
            foreach (var token in listaItens)
            {
                var codigoParticipante = token.SelectToken("cod_participante").ToString().Replace("{", "").Replace("}", "");

                listaParticipantes.Add(Int32.Parse(codigoParticipante));
            }

            matchs["aprender"] = listaParticipantes;

            requisicao = MontadorRequisicao.MontarRequisicaoMatchEnsinar();
            json = JsonParser.MontarJsonMatchEnsinar(codigoItem);
            EnviarJson(json, requisicao);
            objetoResposta = JObject.Parse((string)ObterResposta(requisicao));

            listaItens = objetoResposta.SelectToken("listaparticipanteensinar");

            listaParticipantes = new List<int>();
            foreach (var token in listaItens)
            {
                var codigoParticipante = token.SelectToken("cod_participante").ToString().Replace("{", "").Replace("}", "");

                listaParticipantes.Add(Int32.Parse(codigoParticipante));
            }

            matchs["ensinar"] = listaParticipantes;

            return matchs;
        }
    }
}