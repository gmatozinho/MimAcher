//View error
using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;

namespace UITest1
{
    [Binding]
    public class ValidateFieldsSteps
    {
        readonly IApp app;

               

        [Given(@"an user is making its registry")]
        public void GivenAnUserIsMakingItsRegistry()
        {
            //pass
        }
        
        [When(@"I try to advance to next step")]
        public void WhenITryToAdvanceToNextStep()
        {
            app.WaitForElement(c => c.Marked("botao_avancar"));
            //TODO: descobrir o nome do botao avançar
        }   
        
        [Then(@"all registry fields should be valid")]
        public void ThenAllRegistryFieldsShouldBeValid()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
