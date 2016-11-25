﻿using System.Collections.Generic;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public abstract class AbstractValidatorHandler
    {
        protected ValidatorEnum Validator;
        private AbstractValidatorHandler _proximaOpcao;
        public enum ValidatorEnum { Email, Nome, Nascimento, Senha, Telefone, ConfirmarSenha}

        protected AbstractValidatorHandler(ValidatorEnum validator)
        {
            Validator = validator;
        }

        public void SetProximaOpcao(AbstractValidatorHandler proximaOpcao)
        {
            _proximaOpcao = proximaOpcao;
        }

        public bool ValidatorHandler(Context activity, Dictionary<string,string> informacoesInseridas)
        {
            var resultado = Validar(activity, informacoesInseridas);
            if (!resultado || _proximaOpcao == null) return resultado;
            resultado = _proximaOpcao.ValidatorHandler(activity, informacoesInseridas);
            return resultado;
        }

        public abstract bool Validar(Context activity, Dictionary<string,string> informacoesInseridas);

        public abstract void Write(Context activity);

    }
}