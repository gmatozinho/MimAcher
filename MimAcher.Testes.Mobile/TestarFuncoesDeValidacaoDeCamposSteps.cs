using MimAcher.Mobile.Entidades;
using TechTalk.SpecFlow;
using static NUnit.Core.NUnitFramework;

namespace Testes
{
    [Binding]
    public class TestarFuncoesDeValidacaoDeCamposSteps
    {
        private string nome, email, data, telefone;
        private bool retornoNome, retornoEmail, retornoTelefone, retornoData;

        [Given(@"eu recebi um '(.*)' com valor valido")]
        public void GivenEuRecebiUmComValorValido(string campo)
        {
            switch (campo)
            {
                case ("nome"):
                    nome = "cayo";
                    break;
                case ("email"):
                    email = "cayo@email.com";
                    break;
                case ("data"):
                    data = "24/01/1994";
                    break;
                case ("telefone"):
                    telefone = "33263639";
                    break;
            }
        }

        [Given(@"eu recebi um '(.*)' com valor invalido")]
        public void GivenEuRecebiUmComValorInvalido(string campo)
        {
            switch (campo)
            {
                case ("nome"):
                    nome = "";
                    break;
                case ("email"):
                    email = "cayoemail.com";
                    break;
                case ("data"):
                    data = "24/01/199454";
                    break;
                case ("telefone"):
                    telefone = "numero";
                    break;
            }
        }

        [When(@"eu chamar o validador do '(.*)'")]
        public void WhenEuChamarOValidadorDo(string campo)
        {
            switch (campo)
            {
                case ("nome"):
                    retornoNome = Validador.ValidarNome(nome);
                    break;
                case ("email"):
                    retornoEmail = Validador.ValidarEmail(email);
                    break;
                case ("data"):
                    retornoData = Validador.ValidarData(data);
                    break;
                case ("telefone"):
                    retornoTelefone = Validador.ValidarTelefone(telefone);
                    break;
            }
        }
        
        [Then(@"eu devo receber um retorno True para o '(.*)'")]
        public void ThenEuDevoReceberUmRetornoTrueParaO(string campo)
        {
            switch (campo)
            {
                case ("nome"):
                    Assert.AreEqual(retornoNome, true);
                    break;
                case ("email"):
                    Assert.AreEqual(retornoEmail, true);
                    break;
                case ("data"):
                    Assert.AreEqual(retornoData, true);
                    break;
                case ("telefone"):
                    Assert.AreEqual(retornoTelefone, true);
                    break;
            }
        }
        
        [Then(@"eu devo receber um retorno False para o '(.*)'")]
        public void ThenEuDevoReceberUmRetornoFalseParaO(string campo)
        {
            switch (campo)
            {
                case ("nome"):
                    Assert.AreEqual(retornoNome, false);
                    break;
                case ("email"):
                    Assert.AreEqual(retornoEmail, false);
                    break;
                case ("data"):
                    Assert.AreEqual(retornoData, false);
                    break;
                case ("telefone"):
                    Assert.AreEqual(retornoTelefone, false);
                    break;
            }
        }
    }
}
