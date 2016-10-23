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
using System.Net;
using System.IO;

namespace MimAcher.Entidades
{
    public static class CursorBD
    {
        //Set attributes to connect to database
        private static readonly string url = "http://ghoststation.ddns.net:8091/";

        //Set functions to read and write stuff to database
        public static void EnviarParticipante(Participante participante)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "usuario/add");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json_base = "\"listausuario\":[{\"cod_usuario\": 0, \"email: \"{0}\", \"senha\": \"{1}\"}]}";
                string json_final = string.Format(json_base, participante.Email, participante.Senha);

                streamWriter.Write(json_final);
                streamWriter.Flush();
                streamWriter.Close();
            }

            httpWebRequest = (HttpWebRequest)WebRequest.Create(url + "participante/add");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json_base = "{ \"listparticipante\": [{ \"cod_participante\": 0, \"cod_usuario\": 0," +
                                    "\"cod_campus\": 1, \"nome\": \"{0}\", \"dt_nascimento\":" +
                                    "\"{1}\", \"latitude\": 0, " +
                                    "\"longitude\": 0 }";
                string json_final = string.Format(json_base, participante.Nome, participante.Nascimento);

                streamWriter.Write(json_final);
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static Dictionary<string, List<Participante>> Match(Participante a)
        {
            Dictionary<string, List<Participante>> matchs = new Dictionary<string, List<Participante>>();

            matchs["gostos"] = new List<Participante>();
            matchs["interesses"] = new List<Participante>();
            matchs["competencias"] = new List<Participante>();

            //TODO: buscar os matchs no banco

            return matchs;
        }

        public static Participante GetParticipante(string email)
        {
            Participante participante = null;
            //TODO
            return participante;
        }
        
    }
}