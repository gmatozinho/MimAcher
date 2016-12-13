using System.Collections.Generic;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidarConfirmarSenha : AbstractValidatorHandler
    {
        public ValidarConfirmarSenha(ValidatorTipos validator) : base(validator)
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
            catch(System.Exception)
            {
                Write(activity);
                EnviarErro.EnviandoErroValidadores("Erro confirmar senha");
                return false;
            }
        }

        public override void Write(Context activity)
        {
            Mensagens.MensagemDeConfirmarSenhaInvalido(activity);
        }
    }
}