using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using Android.Content;
using Android.Widget;

namespace MimAcher.Mobile.Entidades
{
    public static class Validador
    {
        public static bool ValidarEmail(string email)
        {
            try
            {
                var enderecodeemail = new MailAddress(email);
                return enderecodeemail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static bool ValidarNome(string nome)
        {
            return !string.IsNullOrEmpty(nome);
        }

        public static bool ValidarData(string data)
        {
            DateTime saida;
            var isValid = DateTime.TryParseExact(data, "dd/MM/yyyy",
                                                  CultureInfo.InvariantCulture,
                                                  DateTimeStyles.None, out saida);
            return isValid;
        }

        public static bool ValidarTelefone(string telefone)
        {
            int numero;
            return int.TryParse(telefone, out numero);
        }

        public static bool ValidarSenha(string senha)
        {
            return !string.IsNullOrEmpty(senha);
        }

        public static bool ValidarConfirmarSenha(string senha, string confirmarSenha)
        {
            return confirmarSenha == senha;
        }

        public static List<string> ValidarEntradas(Dictionary<string, string> entradas)
        {
            var erros = new List<string>();

            if (!ValidarEmail(entradas["email"])) erros.Add("E-mail");
            if (!ValidarNome(entradas["nome"])) erros.Add("Nome");
            if (!ValidarData(entradas["data"])) erros.Add("Data de Nascimento");
            if (!ValidarSenha(entradas["senha"])) erros.Add("Senha");
            if (!ValidarTelefone(entradas["telefone"])) erros.Add("Telefone");

            return erros;
        }

        public static bool ValidarCadastroParticipante(Context activity, Participante participante, string confirmarSenha)
        {
            var informacoes = ParticipanteParaDictionaryParaValidar(participante);
            var listacominformacoesinvalidas = ValidarEntradas(informacoes);
            var checarsenhasinseridas = ValidarConfirmarSenha(participante.Senha, confirmarSenha);

            if (listacominformacoesinvalidas.Count == 0)
            {
                if (checarsenhasinseridas) return true;
                const string toast = "As senhas não conferem!";
                Toast.MakeText(activity, toast, ToastLength.Long).Show();
            }
            foreach (var valor in listacominformacoesinvalidas)
            {
                var toast = $"Informação Invalida: {valor}";
                Toast.MakeText(activity, toast, ToastLength.Long).Show();
            }

            return false;
        }

        private static Dictionary<string, string> ParticipanteParaDictionaryParaValidar(Participante participante)
        {
            return new Dictionary<string, string>
            {
                ["email"] = participante.Email,
                ["nome"] = participante.Nome,
                ["data"] = participante.Nascimento,
                ["senha"] = participante.Senha,
                ["telefone"] = participante.Telefone

            };
        }

    }
}