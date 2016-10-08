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

namespace MimAcher.Entidades
{
    //TODO: implementar esta classe utilizando Entity
    internal static class CursorBD
    {
        //Set attributes to connect to database
        private static string webServiceId = "string";

        //Set functions to read and write stuff to database
        public static void Write(Participante a)
        {
            //TODO
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

        private static void  WriteGosto(Participante a, string s)
        {
            //TODO
        }

        private static void WriteInteresse(Participante a, string s)
        {
            //TODO
        }

        private static void WriteCompetencia(Participante a, string s)
        {
            //TODO
        }

        
    }
}