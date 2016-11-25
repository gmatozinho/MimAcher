﻿using System.Collections.Generic;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public class ValidarSenha : AbstractValidatorHandler
    {
        public ValidarSenha(ValidatorEnum validator) : base(validator)
        {
            Validator = validator;
        }

        public override bool Validar(Context activity, Dictionary<string, string> informacoesInseridas)
        {
            var senha = informacoesInseridas["senha"];
            try
            {
                var comparacao =  !string.IsNullOrEmpty(senha) && senha.Length >= 8;
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
            Mensagens.MensagemDeSenhaInvalida(activity);
        }
    }
}