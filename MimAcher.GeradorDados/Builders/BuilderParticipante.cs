using System;
using System.Collections.Generic;
using System.Globalization;
using MimAcher.GeradorDados.Geradores;
using MimAcher.Mobile.Entidades;

namespace MimAcher.GeradorDados.Builders
{
   internal class BuilderParticipante
    {
        private readonly GeradorNome geradorNome;
        private readonly GeradorEmail geradorEmail;
        private readonly GeradorNascimento geradorNascimento;
        private readonly GeradorTelefone geradorTelefone;
        private readonly GeradorSenha geradorSenha;
        private readonly GeradorCampus geradorCampus;
        private readonly Random random = new Random();

        public BuilderParticipante()
        {
            geradorEmail = new GeradorEmail();
            geradorNascimento = new GeradorNascimento();
            geradorNome = new GeradorNome();
            geradorTelefone = new GeradorTelefone();
            geradorSenha = new GeradorSenha();
            geradorCampus = new GeradorCampus();
        }

        public Participante GerarParticipante()
        {
            Dictionary<string, string> dadosParticipante = new Dictionary<string, string>();

            var culture_info = new CultureInfo("pt-BR");

            dadosParticipante.Add("nome", geradorNome.GerarNome());
            dadosParticipante.Add("email", geradorEmail.GerarEmail(dadosParticipante["nome"]));
            dadosParticipante.Add("nascimento", geradorNascimento.GerarDia().ToString(culture_info));
            dadosParticipante.Add("telefone", geradorTelefone.GerarTelefone().ToString());
            dadosParticipante.Add("senha", geradorSenha.GerarSenha(random.Next(8, 16)));
            dadosParticipante.Add("campus", geradorCampus.GerarCampus());
            dadosParticipante.Add("localizacao", "0.0/0.0");

            return new Participante(dadosParticipante);
        }
    }
}
