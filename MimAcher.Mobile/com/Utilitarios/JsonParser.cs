using System;
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

            var jsonObject = new JSONObject();
            var jsonArray = new JSONArray();
            var objetojsonauxiliar = new JSONObject();
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
        }

        public static string MontarJsonHobbie(int codigoParticipante, int codigoItem)
        {
            var jsonObject = new JSONObject();
            var jsonArray = new JSONArray();
            var objetojsonauxiliar = new JSONObject();
            objetojsonauxiliar.Put("cod_p_hobbie", 0);
            objetojsonauxiliar.Put("cod_participante", codigoParticipante);
            objetojsonauxiliar.Put("cod_item", codigoItem);
            objetojsonauxiliar.Put("cod_s_relacao", 0);

            jsonArray.Put(objetojsonauxiliar);
            jsonObject.Put("listaparticipantehobbie", jsonArray);

            return jsonObject.ToString();
        }

        public static string MontarJsonAprender(int codigoParticipante, int codigoItem)
        {
            var jsonObject = new JSONObject();
            var jsonArray = new JSONArray();
            var objetojsonauxiliar = new JSONObject();
            objetojsonauxiliar.Put("cod_p_aprender", 0);
            objetojsonauxiliar.Put("cod_participante", codigoParticipante);
            objetojsonauxiliar.Put("cod_item", codigoItem);
            objetojsonauxiliar.Put("cod_s_relacao", 0);

            jsonArray.Put(objetojsonauxiliar);
            jsonObject.Put("listaparticipanteaprender", jsonArray);

            return jsonObject.ToString();
        }

        public static string MontarJsonEnsinar(int codigoParticipante, int codigoItem)
        {
            var jsonObject = new JSONObject();
            var jsonArray = new JSONArray();
            var objetojsonauxiliar = new JSONObject();
            objetojsonauxiliar.Put("cod_p_ensinar", 0);
            objetojsonauxiliar.Put("cod_participante", codigoParticipante);
            objetojsonauxiliar.Put("cod_item", codigoItem);
            objetojsonauxiliar.Put("cod_s_relacao", 0);

            jsonArray.Put(objetojsonauxiliar);
            jsonObject.Put("listaparticipanteensinar", jsonArray);

            return jsonObject.ToString();
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

            var jsonObject = new JSONObject();
            var jsonArray = new JSONArray();
            var objetojsonauxiliar = new JSONObject();
            objetojsonauxiliar.Put("cod_participante", participante.CodigoParticipante);
            objetojsonauxiliar.Put("cod_usuario", participante.CodigoUsuario);
            objetojsonauxiliar.Put("cod_campus", participante.Campus);
            objetojsonauxiliar.Put("nome", participante.Nome);
            objetojsonauxiliar.Put("telefone", participante.Telefone);
            objetojsonauxiliar.Put("dt_nascimento", participante.Nascimento);
            objetojsonauxiliar.Put("latitude", localizacao[0].Replace(".",","));
            objetojsonauxiliar.Put("longitude", localizacao[1].Replace(".", ","));

            jsonArray.Put(objetojsonauxiliar);
            jsonObject.Put("listaparticipante", jsonArray);

            return jsonObject.ToString();
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
        public static string MontarJsonGetParticipante(int codigoParticipante)
        {
            return "{ \"listaparticipante\": [ { \"cod_participante\": " + codigoParticipante +
                ", \"cod_usuario\": 0, \"cod_campus\": 0, \"nome\": \"\"," +
                " \"telefone\": \"00000000\", \"dt_nascimento\": \"00/00/0000 00:00:00\", \"latitude\": \"00.00\", \"longitude\": \"00.00\" } ] }";
        }

        public static string MontarJsonUpdateUsuario(Participante participante)
        {
            return "{ \"listausuario\": [{ \"cod_usuario\": " + Convert.ToInt32(participante.CodigoUsuario) + ", \"e_mail\": \"" + participante.Email + "\", \"senha\": \""+ 
                participante.Senha + "\" }] }";
        }

        public static string MontarJsonExcluirHobbie(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipantehobbie\": [{ \"cod_p_hobbie\": 1, \"cod_participante\": "+ codigoParticipante + "," +
                "\"cod_item\": " + codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }

        public static string MontarJsonExcluirAprender(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipanteaprender\": [{ \"cod_p_aprender \": 1, \"cod_participante\": " + codigoParticipante + "," +
                "\"cod_item\": " + codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }

        public static string MontarJsonExcluirEnsinar(int codigoParticipante, int codigoItem)
        {
            return "{ \"listparticipanteensinar\": [{ \"cod_p_ensinar\": 1, \"cod_participante\": " + codigoParticipante + "," +
                "\"cod_item\": " + codigoItem + ", \"cod_s_relacao\": 0 }] }";
        }
    }
}