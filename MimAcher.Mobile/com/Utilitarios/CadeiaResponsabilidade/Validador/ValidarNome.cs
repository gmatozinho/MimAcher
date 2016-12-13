using System.Collections.Generic;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidarNome : AbstractValidatorHandler
    {
        public ValidarNome(ValidatorTipos validator) : base(validator)
        {
            Validator = validator;
        }

        public override bool Validar(Context activity, Dictionary<string, string> informacoesInseridas)
        {
            var nome = informacoesInseridas["nome"];
            try
            {
                if (string.IsNullOrEmpty(nome))
                {
                    Write(activity);
                    return false;
                }
                return true;
            }
            catch (System.Exception)
            {
                Write(activity);
                EnviarErro.EnviandoErroValidadores("Erro Nome");
                return false;
            }
        }

        public override void Write(Context activity)
        {
            Mensagens.MensagemDeInformacaoInvalidaPadrao(activity, "Nome");
        }
    }
}