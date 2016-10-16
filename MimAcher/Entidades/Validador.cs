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
        public static bool ValidarEmail(string email)
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

        public static bool ValidarNome(string nome)
        {
            return !nome.Equals("");
        }

        public static bool ValidarData(string data)
        {
            DateTime saida;
            var isValid = DateTime.TryParseExact(data, "dd/MM/yyyy",
                                                  System.Globalization.CultureInfo.InvariantCulture,
                                                  System.Globalization.DateTimeStyles.None, out saida);
            return isValid;
        }

        public static bool ValidarTelefone(string telefone)
        {
            int numero;
            return int.TryParse(telefone, out numero);
        }

        public static List<string> ValidarEntradas(Dictionary<string, string> entradas)
        {
            var erros = new List<string>();

            if (ValidarEmail(entradas["email"])) erros.Add("email");
            if (ValidarData(entradas["data"])) erros.Add("data");
            if (ValidarNome(entradas["nome"])) erros.Add("nome");
            if (ValidarTelefone(entradas["telefone"])) erros.Add("telefone");

            return erros;
        }
    }
}