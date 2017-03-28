using MimAcher.GeradorDados.Geradores;
using System;
using System.Collections.Generic;
using System.Globalization;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.GeradorDados.Builders
{
   internal class BuilderParticipante
    {
        private readonly GeradorNome _geradorNome;
        private readonly GeradorEmail _geradorEmail;
        private readonly GeradorNascimento _geradorNascimento;
        private readonly GeradorTelefone _geradorTelefone;
        private readonly GeradorSenha _geradorSenha;
        private readonly GeradorCampus _geradorCampus;
        private readonly Random _random = new Random();

        public BuilderParticipante()
        {
            _geradorEmail = new GeradorEmail();
            _geradorNascimento = new GeradorNascimento();
            _geradorNome = new GeradorNome();
            _geradorTelefone = new GeradorTelefone();
            _geradorSenha = new GeradorSenha();
            _geradorCampus = new GeradorCampus();
        }

        public Participante GerarParticipante()
        {
            Dictionary<string, string> dadosParticipante = new Dictionary<string, string>();

            var cultureInfo = new CultureInfo("pt-BR");

            dadosParticipante.Add("nome", _geradorNome.GerarNome());
            dadosParticipante.Add("email", _geradorEmail.GerarEmail(dadosParticipante["nome"]));
            dadosParticipante.Add("nascimento", _geradorNascimento.GerarDia().ToString(cultureInfo));
            dadosParticipante.Add("telefone", _geradorTelefone.GerarTelefone().ToString());
            dadosParticipante.Add("senha", _geradorSenha.GerarSenha(_random.Next(8, 16)));
            dadosParticipante.Add("campus", _geradorCampus.GerarCampus());
            dadosParticipante.Add("localizacao", "0.0/0.0");

            return new Participante(dadosParticipante);
        }
    }
}
