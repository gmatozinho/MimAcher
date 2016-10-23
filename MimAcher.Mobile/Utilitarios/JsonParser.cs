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
        private static string MontarJsonItem(string nome_item)
        {
            string json_base = "{ \"listaitem\": [{ \"cod_item\": 1, \"nome\": \"{0}\" }] }";

            return string.Format(json_base, nome_item);
        }

        public static string MontarJsonUsuario(Participante participante)
        {
            string json_base = "\"listausuario\":[{\"cod_usuario\": 0, \"email: \"{0}\", \"senha\": \"{1}\"}]}";
            string json_final = string.Format(json_base, participante.Email, participante.Senha);

            return json_final;
        }

        public static string MontarJsonParticipante(Participante participante)
        {
            string json_base = "{ \"listparticipante\": [{ \"cod_participante\": 0, \"cod_usuario\": 0," +
                                    "\"cod_campus\": 1, \"nome\": \"{0}\", \"dt_nascimento\":" +
                                    "\"{1}\", \"latitude\": 0, " +
                                    "\"longitude\": 0 }";
            string json_final = string.Format(json_base, participante.Nome, participante.Nascimento);

            return json_final;
        }
    }
}