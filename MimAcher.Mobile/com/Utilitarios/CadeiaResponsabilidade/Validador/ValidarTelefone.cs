using System.Collections.Generic;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidarTelefone : AbstractValidatorHandler
    {
        public ValidarTelefone(ValidatorTipos validator) : base(validator)
        {
            Validator = validator;
        }

        public override bool Validar(Context activity, Dictionary<string, string> informacoesInseridas)
        {
            var telefone = informacoesInseridas["telefone"];
            try
            {
                long numero;
                if (!string.IsNullOrEmpty(telefone))
                {
                    telefone = telefone.Replace(" ", "").Replace("-", "");
                }
                var comparacao = long.TryParse(telefone, out numero);
                if(!comparacao)
                    Write(activity);
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
            Mensagens.MensagemDeInformacaoInvalidaPadrao(activity, "Telefone");
        }
    }
}