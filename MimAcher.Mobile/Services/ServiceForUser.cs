using System.Collections.Generic;
using Android.Content;
using Android.Widget;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Services
{
    public class ServiceForUser
    {
        public static bool ValidarCadastroParticipante(Context activity, Participante participante, string confirmarSenha)
        {

            var informacoes = ParticipanteParaDictionaryParaValidar(participante);
            var lista  = Validador.ValidarEntradas(informacoes);
            var checar = Validador.ValidarConfirmarSenha(participante.Senha,confirmarSenha);

            if (lista.Count == 0)
            {
                if (checar) return true;
                const string toast = "As senhas não conferem!";
                Toast.MakeText(activity, toast, ToastLength.Long).Show();
            }
            foreach (var valor in lista)
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