using System;
using System.Globalization;
using MimAcher.Mobile.com.Entidades;

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
            var isValid = DateTime.TryParseExact(participante.Nascimento, "dd/MM/yyyy",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out saida);
            participante.Nascimento = saida.ToString(CultureInfo.InvariantCulture);

            return "{ \"listausuarioparticipante\": [ { \"e_mail\": \"" + participante.Email + "\", " +
                "\"senha\": \"" + participante.Senha + "\", \"cod_participante\": 1, \"cod_usuario\": 1, " +
                "\"cod_campus\": 1, \"nome\": \"" + participante.Nome + "\", \"telefone\": "+ participante.Telefone + ", " +
                "\"dt_nascimento\": \"" + participante.Nascimento + "\", \"latitude\": " + localizacao[0] + ", \"longitude\": " + localizacao[1] + "} ] }";
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
    }
}