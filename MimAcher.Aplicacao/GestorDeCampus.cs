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
            RepositorioDeCampus = new RepositorioDeCampus();
        }

        public MA_CAMPUS ObterCampusPorId(int id)
        {
            return RepositorioDeCampus.ObterCampusPorId(id);
        }

        public List<MA_CAMPUS> ObterTodosOsCampus()
        {
            return RepositorioDeCampus.ObterTodosOsCampus();
        }
        
        public void InserirCampus(MA_CAMPUS naccampus)
        {
            RepositorioDeCampus.InserirCampus(naccampus);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeCampus.BuscarQuantidadeRegistros();
        }

        public void RemoverCampus(MA_CAMPUS naccampus)
        {
            RepositorioDeCampus.RemoverCampus(naccampus);
        }

        public void AtualizarCampus(MA_CAMPUS naccampus)
        {
            RepositorioDeCampus.AtualizarCampus(naccampus);
        }
    }
}
