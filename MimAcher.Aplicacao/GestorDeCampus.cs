using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeCampus
    {
        public RepositorioDeCampus RepositorioDeCampus { get; set; }

        public GestorDeCampus()
        {
            this.RepositorioDeCampus = new RepositorioDeCampus();
        }

        public MA_CAMPUS ObterCampusPorId(int id)
        {
            return this.RepositorioDeCampus.ObterCampusPorId(id);
        }

        public List<MA_CAMPUS> ObterTodosOsCampus()
        {
            return this.RepositorioDeCampus.ObterTodosOsCampus();
        }
        
        public void InserirCampus(MA_CAMPUS naccampus)
        {
            this.RepositorioDeCampus.InserirCampus(naccampus);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeCampus.BuscarQuantidadeRegistros();
        }

        public void RemoverCampus(MA_CAMPUS naccampus)
        {
            this.RepositorioDeCampus.RemoverCampus(naccampus);
        }

        public void AtualizarCampus(MA_CAMPUS naccampus)
        {
            this.RepositorioDeCampus.AtualizarCampus(naccampus);
        }
    }
}
