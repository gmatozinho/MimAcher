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

namespace MimAcher.SourceCode
{
    //TODO: implementar esta classe utilizando Entity
    internal static class Cursor
    {
        //Set attributes to connect to database


        //Set functions to read and write stuff to database
        public static void write(Aluno a)
        {

        }

        public static Dictionary<string, List<Aluno>> match(Aluno a)
        {
            Dictionary<string, List<Aluno>> matchs = new Dictionary<string, List<Aluno>>();

            matchs["gostos"] = new List<Aluno>();
            matchs["interesses"] = new List<Aluno>();
            matchs["competencias"] = new List<Aluno>();

            return matchs;
        }

        private static void  writeGosto(Aluno a, string s)
        {

        }

        private static void writeInteresse(Aluno a, string s)
        {

        }

        private static void writeCompetencia(Aluno a, string s)
        {

        }
    }
}