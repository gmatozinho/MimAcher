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
    public static class Validador
    {
        public Boolean ValidarEmail(String email)
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

        public Boolean ValidarNome(String nome)
        {
            if (nome.Equals(""))
            {
                return false;
            }
            return true;
        }

        public Boolean ValidarData(String data)
        {
            bool isValid = DateTime.TryParseExact(data, "dd/MM/yyyy",
                                                  CultureInfo.InvariantCulture,
                                                  DateTimeStyles.None, out dt);
            return isValid;
        }

        public Boolean ValidarTelefone(String telefone)
        {
            if (Regex.Match("(27)"+ telefone, @"^[2-9][0-9]{7,8}$").Success)
                return true;

            return false;
        }

        public List<string> ValidarEntradas(Dictionary<string, string> entradas)
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