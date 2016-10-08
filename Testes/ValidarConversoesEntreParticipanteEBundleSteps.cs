using Android.OS;
using MimAcher.Entidades;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using static NUnit.Core.NUnitFramework;

namespace Testes
{
    [Binding]
    public class ValidarConversoesEntreParticipanteEBundleSteps
    {
        private Participante participante, participanteConvertido;
        private Bundle bundle, bundleConvertido;

        [Given(@"eu tenho os dados de um participante")]
        public void GivenEuTenhoOsDadosDeUmParticipante()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict["nome"] = "Cayo";
            dict["email"] = "cayo@email.com";
            dict["telefone"] = "33263639";
            dict["nascimento"] = "24/01/1994";
            dict["senha"] = "1234batata";
            dict["campus"] = "Serra";

            participante = new Participante(dict);
        }
        
        [Given(@"eu tenho um bundle com os dados de um participante")]
        public void GivenEuTenhoUmBundleComOsDadosDeUmParticipante()
        {
            Bundle b = new Bundle();
            b.PutString("nome", "gustavo");
            b.PutString("senha", "gustavo123");
            b.PutString("email", "gustavo@email.com");
            b.PutString("telefone", "12345678");
            b.PutString("nascimento", "11/11/11");
            b.PutString("campus", "Vitoria");

            bundle = b;
        }
        
        [When(@"eu converter esse participante para um bundle")]
        public void WhenEuConverterEsseParticipanteParaUmBundle()
        {
            bundleConvertido = participante.ParticipanteToBundle();
        }
        
        [When(@"eu converter esse bundle em um participante")]
        public void WhenEuConverterEsseBundleEmUmParticipante()
        {
            participanteConvertido = Participante.BundleToParticipante(bundle);
        }
        
        [Then(@"eu devo ter os mesmos dados no bundle")]
        public void ThenEuDevoTerOsMesmosDadosNoBundle()
        {
            Assert.AreEqual(participante.Nome, bundleConvertido.GetString("nome"));
            Assert.AreEqual(participante.Email, bundleConvertido.GetString("email"));
            Assert.AreEqual(participante.Nascimento, bundleConvertido.GetString("nascimento"));
            Assert.AreEqual(participante.Telefone, bundleConvertido.GetString("telefone"));
            Assert.AreEqual(participante.Campus, bundleConvertido.GetString("campus"));
            Assert.AreEqual(participante.Login(bundleConvertido.GetString("senha")), true);
        }
        
        [Then(@"eu devo ter os mesmos dados no partcipante")]
        public void ThenEuDevoTerOsMesmosDadosNoPartcipante()
        {
            Assert.AreEqual(participanteConvertido.Nome, bundle.GetString("nome"));
            Assert.AreEqual(participanteConvertido.Email, bundle.GetString("email"));
            Assert.AreEqual(participanteConvertido.Nascimento, bundle.GetString("nascimento"));
            Assert.AreEqual(participanteConvertido.Telefone, bundle.GetString("telefone"));
            Assert.AreEqual(participanteConvertido.Campus, bundle.GetString("campus"));
            Assert.AreEqual(participanteConvertido.Login(bundle.GetString("senha")), true);
        }
    }
}
