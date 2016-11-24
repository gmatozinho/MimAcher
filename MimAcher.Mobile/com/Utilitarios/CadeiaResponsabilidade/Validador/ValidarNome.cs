using System.Collections.Generic;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidarNome : AbstractValidatorHandler
    {
        public ValidarNome(ValidatorEnum validator) : base(validator)
        {
            Validator = validator;
        }

        public override bool Validar(Context activity, Dictionary<string, string> informacoesInseridas)
        {
            var nome = informacoesInseridas["nome"];
            try
            {
                return !string.IsNullOrEmpty(nome);
            }
            catch
            {
                return false;
            }
        }

        public override void Write(Context activity)
        {
            throw new System.NotImplementedException();
        }
    }
}