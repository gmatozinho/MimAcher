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
    public static class ParticipanteFactory
    {
        public static Participante CriarParticipante(Bundle b)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary["nome"] = b.GetString("nome");
            dictionary["id"] = b.GetString("id");
            dictionary["senha"] = b.GetString("senha");
            dictionary["email"] = b.GetString("email");
            dictionary["nascimento"] = b.GetString("nascimento");
            dictionary["telefone"] = b.GetString("telefone");

            return new Participante(dictionary);
        }
    }
}