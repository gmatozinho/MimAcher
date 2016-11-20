using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;
using Android.Content;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.Mobile.com.Utilitarios
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
            if (!string.IsNullOrEmpty(data))
            {
                var dataatual = DateTime.Today;

                DateTime saida;
                var isValid = DateTime.TryParseExact(data, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out saida);

                if (!isValid) return false;
                var compare = DateTime.Compare(saida, dataatual);
                return compare <= 0;
            }
            return false;
        }

        public static bool ValidarTelefone(string telefone)
        {
            if (!string.IsNullOrEmpty(telefone))
            {

                telefone = telefone.Replace(" ", "").Replace("-", "");
                long numero;
                return long.TryParse(telefone, out numero);
            }
            return false;
        }

        private static bool ValidarSenha(string senha)
        {
            return !string.IsNullOrEmpty(senha) && senha.Length >= 8;
        }

        public static bool ValidarConfirmarSenha(string senha, string confirmarSenha)
        {
            return confirmarSenha == senha;
        }

        private static List<string> ValidarEntradasParaCadastro(IReadOnlyDictionary<string, string> entradas)
        {
            var erros = new List<string>();

            if (!ValidarEmail(entradas["email"])) erros.Add("E-mail");
            if (!ValidarNome(entradas["nome"])) erros.Add("Nome");
            if (!ValidarData(entradas["data"])) erros.Add("Data de Nascimento");
            if (!ValidarSenha(entradas["senha"])) erros.Add("Senha");
            if (!ValidarTelefone(entradas["telefone"])) erros.Add("Telefone");

            return erros;
        }

        private static List<string> ValidarEntradasParaEditarPerfil(IReadOnlyDictionary<string, string> entradas)
        {
            var erros = new List<string>();

            if (!ValidarNome(entradas["nome"])) erros.Add("Nome");
            if (!ValidarData(entradas["data"])) erros.Add("Data de Nascimento");
            if (!ValidarTelefone(entradas["telefone"])) erros.Add("Telefone");


            return erros;
        }

        public static bool ValidarEditarPerfil(Context contexto, Dictionary<string,string> entradas )
        {
            var listacominformacoesinvalidas = ValidarEntradasParaEditarPerfil(entradas);

            if (listacominformacoesinvalidas.Count == 0)
            {
                return true;
            }
            foreach (var valor in listacominformacoesinvalidas)
            {
                Mensagens.MensagemDeInformacaoInvalidaPadrao(contexto, valor);
            }

            return false;
        }



        public static bool ValidarCadastroParticipante(Context contexto, Participante participante, string confirmarSenha)
        {
            var informacoes = ParticipanteParaDictionaryParaValidar(participante);
            var listacominformacoesinvalidas = ValidarEntradasParaCadastro(informacoes);
            var checarsenhasinseridas = ValidarConfirmarSenha(participante.Senha, confirmarSenha);

            if (listacominformacoesinvalidas.Count == 0)
            {
                if (checarsenhasinseridas) return true;
                Mensagens.MensagemDeConfirmarSenhaInvalido(contexto);
            }
            foreach (var valor in listacominformacoesinvalidas)
            {
                if (valor == "Senha")
                {
                    Mensagens.MensagemDeSenhaInvalida(contexto);
                }
                else if (valor == "Data de Nascimento")
                {
                    Mensagens.MensagemDeDataInvalida(contexto);
                }
                else Mensagens.MensagemDeInformacaoInvalidaPadrao(contexto,valor);
            }

            return false;
        }

        
        public static bool ValidadorDeLogin(string usuario, string senha)
        {
            return ValidarEmail(usuario) && ValidarSenha(senha);
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