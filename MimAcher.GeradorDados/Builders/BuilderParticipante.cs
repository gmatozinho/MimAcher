using MimAcher.Entidades;
using MimAcher.GeradorDados.Geradores;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            dadosParticipante.Add("nome", geradorNome.GerarNome());
            dadosParticipante.Add("email", geradorEmail.GerarEmail(dadosParticipante["nome"]));
            dadosParticipante.Add("nascimento", geradorNascimento.GerarDia().ToString(CultureInfo.InvariantCulture));
            dadosParticipante.Add("telefone", geradorTelefone.GerarTelefone().ToString());
            dadosParticipante.Add("senha", geradorSenha.GerarSenha(random.Next(8, 16)));
            dadosParticipante.Add("campus", geradorCampus.GerarCampus());

            return new Participante(dadosParticipante);
        }
    }
}
