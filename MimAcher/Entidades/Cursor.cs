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
    internal static class Cursor
    {
        //Set attributes to connect to database


        //Set functions to read and write stuff to database
        public static void Write(Aluno a)
        {
            //TODO
        }

        public static Dictionary<string, List<Aluno>> Match(Aluno a)
        {
            Dictionary<string, List<Aluno>> matchs = new Dictionary<string, List<Aluno>>();

            matchs["gostos"] = new List<Aluno>();
            matchs["interesses"] = new List<Aluno>();
            matchs["competencias"] = new List<Aluno>();

            //TODO: buscar os matchs no banco

            return matchs;
        }

        private static void  WriteGosto(Aluno a, string s)
        {
            //TODO
        }

        private static void WriteInteresse(Aluno a, string s)
        {
            //TODO
        }

        private static void WriteCompetencia(Aluno a, string s)
        {
            //TODO
        }
    }
}