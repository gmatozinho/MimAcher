using System;
using System.Collections.Generic;
using System.Globalization;
using MimAcher.Mobile.com.Entidades;
using Org.Json;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class JsonParser
    {
        public static string MontarJsonItem(string nomeItem)
        {
            return "{ \"listaitem\": [{ \"cod_item\": 1, \"nome\": \""+ nomeItem + "\" }] }";
        }

        public static string MontarJsonUsuario(Participante participante)
        {
            //tratamento das informaçoes com separadores
            var localizacao = participante.Localizacao.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var acertandoTelefone = participante.Telefone.Replace(" ", "").Replace("-", "");
            participante.Telefone = acertandoTelefone;
            DateTime saida;
            DateTime.TryParseExact(participante.Nascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out saida);

            participante.Nascimento = saida.ToString(CultureInfo.InvariantCulture);

            JSONObject jsonObject = new JSONObject();
            JSONArray jsonArray = new JSONArray();
            JSONObject objetojsonauxiliar = new JSONObject();
            objetojsonauxiliar.Put("cod_participante", 0);
            objetojsonauxiliar.Put("cod_usuario", 0);
            objetojsonauxiliar.Put("e_mail", participante.Email);
            objetojsonauxiliar.Put("senha", participante.Senha);
            objetojsonauxiliar.Put("cod_campus", Convert.ToInt16(participante.Campus));
            objetojsonauxiliar.Put("nome", participante.Nome);
            objetojsonauxiliar.Put("telefone", participante.Telefone);
            objetojsonauxiliar.Put("dt_nascimento", participante.Nascimento);
            objetojsonauxiliar.Put("latitude", localizacao[0]);
            objetojsonauxiliar.Put("longitude", localizacao[1]);

            jsonArray.Put(objetojsonauxiliar);
            jsonObject.Put("listausuarioparticipante", jsonArray);

            return jsonObject.ToString();

            /*return "{ \"listausuarioparticipante\": [ { \"e_mail\": \"" + participante.Email + "\", " +
                "\"senha\": \"" + participante.Senha + "\", \"cod_participante\": 1, \"cod_usuario\": 1, " +
                "\"cod_campus\": \"" + participante.Campus + "\", \"nome\": \"" + participante.Nome + "\", \"telefone\": "+ participante.Telefone + ", " +
                "\"dt_nascimento\": \"" + participante.Nascimento + "\", \"latitude\": " + localizacao[0] + ", \"longitude\": " + localizacao[1] + "} ] }";*/
        }

        public static string MontarJsonHobbie(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipantehobbie\": [{ \"cod_p_hobbie\": 0, \"cod_participante\": " + codigoParticipante + 
                ", \"cod_item\": "+ codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }

        public static string MontarJsonAprender(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipanteaprender\": [{ \"cod_p_aprender\": 0, \"cod_participante\": " + codigoParticipante +
                ", \"cod_item\": " + codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }

        public static string MontarJsonEnsinar(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipanteensinar\": [{ \"cod_p_ensinar\": 0, \"cod_participante\": " + codigoParticipante +
                ", \"cod_item\": " + codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }

        public static string MontarJsonLogin(string email, string senha)
        {
            return "{ \"listausuario\": [{\"e_mail\": \"" + email + "\", \"senha\": \"" + senha + "\" }] }";
        }

        public static string MontarJsonUpdateParticipante(Participante participante)
        {
            //tratamento das informaçoes com separadores
            var localizacao = participante.Localizacao.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var acertandoTelefone = participante.Telefone.Replace(" ", "").Replace("-", "");
            participante.Telefone = acertandoTelefone;
            DateTime saida;
            DateTime.TryParseExact(participante.Nascimento, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out saida);

            participante.Nascimento = saida.ToString(CultureInfo.InvariantCulture);

            return "{ \"listaparticipante\": [ { \"cod_participante\": 1, \"cod_usuario\": 1, " + 
                "\"cod_campus\": 1, \"nome\": \"" + participante.Nome + "\", \"telefone\": " + participante.Telefone + ", " + 
                "\"dt_nascimento\": \"" + participante.Nascimento + "\", \"latitude\": " + localizacao[0] + ", " + 
                "\"longitude\": }" + localizacao[1] + " } ] }";
        }

        public static string MontarJsonMatchHobbie(int codigoItem)
        {
            return "{ \"listaparticipantehobbie\": [{ \"cod_p_aprender\": 0, \"cod_participante\": 0, \"cod_item\": " + codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }

        public static string MontarJsonMatchAprender(int codigoItem)
        {
            return "{ \"listaparticipanteaprender\": [{ \"cod_p_aprender\": 0, \"cod_participante\": 0, \"cod_item\": " + codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }

        public static string MontarJsonMatchEnsinar(int codigoItem)
        {
            return "{ \"listaparticipanteensinar\": [{ \"cod_p_aprender\": 0, \"cod_participante\": 0, \"cod_item\": " + codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }
    }
}