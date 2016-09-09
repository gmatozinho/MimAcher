using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeNACCampus
    {
        public RepositorioDeNACCampus RepositorioDeNACCampus { get; set; }

        public GestorDeNACCampus()
        {
            this.RepositorioDeNACCampus = new RepositorioDeNACCampus();
        }

        public List<NAC_CAMPUS> ObterTodosOsNACCampus()
        {
            return this.RepositorioDeNACCampus.ObterTodosOsNACCampus();
        }

        public List<NAC_CAMPUS> ObterTodosOsNACCampusPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.RepositorioDeNACCampus.ObterTodosOsNACCampusPorNomeDoRepresentante(nomerepresentante);
        }

        public NAC_CAMPUS ObterNACCampusPorLogin(String login)
        {
            return this.RepositorioDeNACCampus.ObterNACCampusPorLogin(login);
        }


        public void InserirNACCampus(NAC_CAMPUS naccampus)
        {
            this.RepositorioDeNACCampus.InserirNACCampus(naccampus);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeNACCampus.BuscarQuantidadeRegistros();
        }

        public void RemoverNACCampus(NAC_CAMPUS naccampus)
        {
            this.RepositorioDeNACCampus.RemoverNACCampus(naccampus);
        }

        public void AtualizarNACCampus(NAC_CAMPUS naccampus)
        {
            this.RepositorioDeNACCampus.AtualizarNACCampus(naccampus);
        }
    }
}
