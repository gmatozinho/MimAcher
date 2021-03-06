﻿using System.Collections.Generic;
using System.Net.Mail;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidarEmail : AbstractValidatorHandler
    {
        public ValidarEmail(ValidatorTipos validator) : base(validator)
        {
            Validator = validator;
        }

        public override bool Validar(Context activity, Dictionary<string, string> informacoesInseridas)
        {
            var email = informacoesInseridas["email"];

            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    Write(activity);
                    return false;
                }
                
                var enderecodeemail = new MailAddress(email);
                var comparacao = enderecodeemail.Address == email;
                if (!comparacao)
                    Write(activity);
                return comparacao ;

            }
            catch(System.Exception)
            {
                Write(activity);
                EnviarErro.EnviandoErroValidadores("Erro Email");
                return false;
            }
        }

        public override void Write(Context activity)
        {
            Mensagens.MensagemDeInformacaoInvalidaPadrao(activity, "Email");
        }
    }
}