using System.Collections.Generic;
using System.Net.Mail;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidadorEmail : AbstractValidatorHandler
    {
        public ValidadorEmail(ValidatorEnum validator) : base(validator)
        {
            Validator = validator;
        }

        public override bool Validar(Context activity, Dictionary<string, string> informacoesInseridas)
        {
            var email = informacoesInseridas["email"];

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

        public override void Write(Context activity)
        {
            throw new System.NotImplementedException();
        }
    }
}