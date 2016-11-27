using System.Collections.Generic;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidarConfirmarSenha : AbstractValidatorHandler
    {
        public ValidarConfirmarSenha(ValidatorEnum validator) : base(validator)
        {
            Validator = validator;
        }

        public override bool Validar(Context activity, Dictionary<string, string> informacoesInseridas)
        {
            var senha =  informacoesInseridas["senha"];
            var confirmarSenha = informacoesInseridas["confirmarSenha"];

            try
            {
                var comparacao = confirmarSenha == senha;
                if(!comparacao) Write(activity);
                return comparacao;

            }
            catch
            {
                Write(activity);
                return false;
            }
        }

        public override void Write(Context activity)
        {
            Mensagens.MensagemDeConfirmarSenhaInvalido(activity);
        }
    }
}