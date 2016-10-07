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
using System.Text.RegularExpressions;

namespace MimAcher.Entidades
{
    public static class Validador
    {
        public static Boolean ValidarEmail(String email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static Boolean ValidarNome(String nome)
        {
            return !nome.Equals("");
        }

        public static Boolean ValidarData(String data)
        {
            DateTime saida;
            bool isValid = DateTime.TryParseExact(data, "dd/MM/yyyy",
                                                  System.Globalization.CultureInfo.InvariantCulture,
                                                  System.Globalization.DateTimeStyles.None, out saida);
            return isValid;
        }

        public static Boolean ValidarTelefone(String telefone)
        {
            Regex r = new Regex(@"^[2-9][0-9]{7,8}$");
            return ((r.Match("27" + telefone)).Success);
        }

        public static List<string> ValidarEntradas(Dictionary<string, string> entradas)
        {
            List<string> erros = new List<string>();

            if (ValidarEmail(entradas["email"])) erros.Add("email");
            if (ValidarData(entradas["data"])) erros.Add("data");
            if (ValidarNome(entradas["nome"])) erros.Add("nome");
            if (ValidarTelefone(entradas["telefone"])) erros.Add("telefone");

            return erros;
        }
    }
}