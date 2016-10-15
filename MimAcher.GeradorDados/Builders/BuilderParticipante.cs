using MimAcher.Entidades;
using MimAcher.GeradorDados.Geradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Random random;

        public BuilderParticipante()
        {
            geradorEmail = new GeradorEmail();
            geradorNascimento = new GeradorNascimento();
            geradorNome = new GeradorNome();
            geradorTelefone = new GeradorTelefone();
            geradorSenha = new GeradorSenha();
        }

        public Participante GerarParticipante()
        {
            Dictionary<string, string> dadosParticipante = new Dictionary<string, string>();

            dadosParticipante.Add("nome", geradorNome.GerarNome());
            dadosParticipante.Add("email", geradorEmail.GerarEmail(dadosParticipante["nome"]));
            dadosParticipante.Add("nascimento", geradorNascimento.GerarDia().ToString());
            dadosParticipante.Add("telefone", geradorTelefone.GerarTelefone().ToString());
            dadosParticipante.Add("senha", geradorSenha.GerarSenha(random.Next(8, 16)));

            participante = new Participante(dadosParticipante);

            return participante;
        }
    }
}
