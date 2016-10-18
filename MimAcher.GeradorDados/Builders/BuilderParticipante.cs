using MimAcher.GeradorDados.Geradores;
using System;
using System.Collections.Generic;
using MimAcher.Mobile.Entidades;

namespace MimAcher.GeradorDados.Builders
{
   internal class BuilderParticipante
    {
        private Participante participante;
        private GeradorNome geradorNome;
        private GeradorEmail geradorEmail;
        private GeradorNascimento geradorNascimento;
        private GeradorTelefone geradorTelefone;
        private GeradorSenha geradorSenha;
        private GeradorCampus geradorCampus;
        private Random random = new Random();

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

            dadosParticipante.Add("nome", geradorNome.GerarNome());
            dadosParticipante.Add("email", geradorEmail.GerarEmail(dadosParticipante["nome"]));
            dadosParticipante.Add("nascimento", geradorNascimento.GerarDia().ToString());
            dadosParticipante.Add("telefone", geradorTelefone.GerarTelefone().ToString());
            dadosParticipante.Add("senha", geradorSenha.GerarSenha(random.Next(8, 16)));
            dadosParticipante.Add("campus", geradorCampus.GerarCampus());

            participante = new Participante(dadosParticipante);

            return participante;
        }
    }
}
