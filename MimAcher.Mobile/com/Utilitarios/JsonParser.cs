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

        public static JSONObject MontarJsonUsuario(Participante participante)
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
            objetojsonauxiliar.Put("telefone", Convert.ToInt64(participante.Telefone));
            objetojsonauxiliar.Put("dt_nascimento", participante.Nascimento);
            objetojsonauxiliar.Put("latitude", localizacao[0]);
            objetojsonauxiliar.Put("longitude", localizacao[1]);

            jsonArray.Put(objetojsonauxiliar);
            jsonObject.Put("listausuarioparticipante", jsonArray);

            return jsonObject;

            /*return "{ \"listausuarioparticipante\": [ { \"e_mail\": \"" + participante.Email + "\", " +
                "\"senha\": \"" + participante.Senha + "\", \"cod_participante\": 1, \"cod_usuario\": 1, " +
                "\"cod_campus\": \"" + participante.Campus + "\", \"nome\": \"" + participante.Nome + "\", \"telefone\": "+ participante.Telefone + ", " +
                "\"dt_nascimento\": \"" + participante.Nascimento + "\", \"latitude\": " + localizacao[0] + ", \"longitude\": " + localizacao[1] + "} ] }";*/
        }

        public static string MontarJsonHobbie(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipantehobbie\": [{ \"cod_p_hobbie\": 1, \"cod_participante\": " + codigoParticipante + 
                ", \"cod_item\": "+ codigoItem + " }] }";
        }

        public static string MontarJsonAprender(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipanteaprender\": [{ \"cod_p_aprender\": 1, \"cod_participante\": " + codigoParticipante +
                ", \"cod_item\": " + codigoItem + " }] }";
        }

        public static string MontarJsonEnsinar(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipanteensinar\": [{ \"cod_p_ensinar\": 1, \"cod_participante\": " + codigoParticipante +
                ", \"cod_item\": " + codigoItem + " }] }";
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
    }
}