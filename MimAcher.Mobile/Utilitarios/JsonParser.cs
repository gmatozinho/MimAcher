using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Utilitarios
{
    public static class JsonParser
    {
        public static string MontarJsonItem(string nome_item)
        {
            return "{ \"listaitem\": [{ \"cod_item\": 1, \"nome\": \""+ nome_item + "\" }] }";
        }

        public static string MontarJsonUsuario(Participante participante)
        {
            var localizacao = participante.Localizacao.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return "{ \"listausuarioparticipante\": [ { \"e_mail\": \"" + participante.Email + "\", " +
                "\"senha\": \"" + participante.Senha + "\", \"cod_participante\": 1, \"cod_usuario\": 1, " +
                "\"cod_campus\": 1, \"nome\": \"" + participante.Nome + "\", \"telefone\": "+ participante.Telefone + ", " +
                "\"dt_nascimento\": \"" + participante.Nascimento + "\", \"latitude\": " + localizacao[0] + ", \"longitude\": " + localizacao[1] + "} ] }";
        }

        public static string MontarJsonHobbie(int codigo_participante, int codigo_item)
        {
            return "{ \"listparticipantehobbie\": [{ \"cod_p_hobbie\": 1, \"cod_participante\": " + codigo_participante + 
                ", \"cod_item\": "+ codigo_item + " }] }";
        }

        public static string MontarJsonAprender(int codigo_participante, int codigo_item)
        {
            return "{ \"listparticipanteaprender\": [{ \"cod_p_aprender\": 1, \"cod_participante\": " + codigo_participante +
                ", \"cod_item\": " + codigo_item + " }] }";
        }

        public static string MontarJsonEnsinar(int codigo_participante, int codigo_item)
        {
            return "{ \"listparticipanteensinar\": [{ \"cod_p_ensinar\": 1, \"cod_participante\": " + codigo_participante +
                ", \"cod_item\": " + codigo_item + " }] }";
        }
    }
}