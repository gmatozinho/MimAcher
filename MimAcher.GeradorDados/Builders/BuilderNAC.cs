using MimAcher.Entidades;
using MimAcher.GeradorDados.Geradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados.Builders
{
    internal class BuilderNac
    {
        private Nac nac;
        private GeradorNome geradorNome;
        private GeradorEmail geradorEmail;
        private GeradorTelefone geradorTelefone;
        private GeradorSenha geradorSenha;
        private Random random;

        public BuilderNac()
        {
            geradorEmail = new GeradorEmail();
            geradorNome = new GeradorNome();
            geradorTelefone = new GeradorTelefone();
            geradorSenha = new GeradorSenha();
        }

        public Nac GerarNac()
        {
            Dictionary<string, string> dadosNac = new Dictionary<string, string>();

            dadosNac.Add("nome", geradorNome.GerarNome());
            dadosNac.Add("email", geradorEmail.GerarEmail(dadosNac["nome"]));
            dadosNac.Add("telefone", geradorTelefone.GerarTelefone().ToString());
            dadosNac.Add("senha", geradorSenha.GerarSenha(random.Next(8, 16)));

            nac = new Nac(dadosNac);

            return nac;
        }
    }
}
