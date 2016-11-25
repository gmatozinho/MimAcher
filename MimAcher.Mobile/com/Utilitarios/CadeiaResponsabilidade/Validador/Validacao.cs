using System.Collections.Generic;
using Android.Content;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.Validador
{
    public static class Validacao
    {

        public static bool ValidarLogin(Context contexto, Dictionary<string, string> informacoesInseridas)
        {
            AbstractValidatorHandler validarEmail = new ValidarEmail(AbstractValidatorHandler.ValidatorEnum.Email);
            AbstractValidatorHandler validarSenha = new ValidarSenha(AbstractValidatorHandler.ValidatorEnum.Senha);

            validarEmail.SetProximaOpcao(validarSenha);

            return validarEmail.ValidatorHandler(contexto, informacoesInseridas);
        }

        public static bool ValidarEditarPerfil(Context contexto, Dictionary<string, string> entradas)
        {
            AbstractValidatorHandler validarNome = new ValidarNome(AbstractValidatorHandler.ValidatorEnum.Nome);
            AbstractValidatorHandler validarNascimento = new ValidarNascimento(AbstractValidatorHandler.ValidatorEnum.Nascimento);
            AbstractValidatorHandler validarTelefone = new ValidarTelefone(AbstractValidatorHandler.ValidatorEnum.Telefone);

            validarNome.SetProximaOpcao(validarNascimento);
            validarNascimento.SetProximaOpcao(validarTelefone);
            
            return validarNome.ValidatorHandler(contexto, entradas);

        }

        public static bool ValidarCadastroParticipante(Context contexto, Dictionary<string, string> informacoesInseridas)
        {
            AbstractValidatorHandler validarNome = new ValidarNome(AbstractValidatorHandler.ValidatorEnum.Nome);
            AbstractValidatorHandler validarEmail = new ValidarEmail(AbstractValidatorHandler.ValidatorEnum.Email);
            AbstractValidatorHandler validarNascimento = new ValidarNascimento(AbstractValidatorHandler.ValidatorEnum.Nascimento);
            AbstractValidatorHandler validarSenha = new ValidarSenha(AbstractValidatorHandler.ValidatorEnum.Senha);
            AbstractValidatorHandler validarConfirmarSenha = new ValidarConfirmarSenha(AbstractValidatorHandler.ValidatorEnum.ConfirmarSenha);
            AbstractValidatorHandler validarTelefone = new ValidarTelefone(AbstractValidatorHandler.ValidatorEnum.Telefone);

            validarEmail.SetProximaOpcao(validarNome);
            validarNome.SetProximaOpcao(validarNascimento);
            validarNascimento.SetProximaOpcao(validarTelefone);
            validarTelefone.SetProximaOpcao(validarSenha);
            validarSenha.SetProximaOpcao(validarConfirmarSenha);

            return validarEmail.ValidatorHandler(contexto, informacoesInseridas);
        }

        public static bool ValidarConfirmarSenha(Context contexto, Dictionary<string, string> senhasInseridas)
        {
            AbstractValidatorHandler validarSenha = new ValidarSenha(AbstractValidatorHandler.ValidatorEnum.Senha);
            AbstractValidatorHandler validarConfirmarSenha = new ValidarConfirmarSenha(AbstractValidatorHandler.ValidatorEnum.ConfirmarSenha);

            validarSenha.SetProximaOpcao(validarConfirmarSenha);

            return validarSenha.ValidatorHandler(contexto, senhasInseridas);
        }

        

    }
}