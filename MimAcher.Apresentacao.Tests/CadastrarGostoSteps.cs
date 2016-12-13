using System;
using TechTalk.SpecFlow;

namespace MimAcher.Apresentacao.Tests
{
    [Binding]
    public class CadastrarGostoSteps
    {
        [Given(@"A tela contém um campo com código e descrição em brancos")]
        public void GivenATelaContemUmCampoComCodigoEDescricaoEmBrancos()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Eu escrevo no campo descrição")]
        public void GivenEuEscrevoNoCampoDescricao()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Ao pressionar botão Salvar")]
        public void WhenAoPressionarBotaoSalvar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"A tela deverá fechar e o resultado aparecerá na grid")]
        public void ThenATelaDeveraFecharEoResultadoApareceraNaGrid()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
