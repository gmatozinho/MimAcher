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

        public MA_NAC_CAMPUS ObterNACCampusPorId(int id)
        {
            return this.RepositorioDeNACCampus.ObterNACCampusPorId(id);
        }

        public List<MA_NAC_CAMPUS> ObterTodosOsNACCampus()
        {
            return this.RepositorioDeNACCampus.ObterTodosOsNACCampus();
        }

        public List<MA_NAC_CAMPUS> ObterTodosOsNACCampusPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.RepositorioDeNACCampus.ObterTodosOsNACCampusPorNomeDoRepresentante(nomerepresentante);
        }

        public MA_NAC_CAMPUS ObterNACCampusPorIdDeUsuario(int id_usuario)
        {
            return this.RepositorioDeNACCampus.ObterNACCampusPorIdDeUsuario(id_usuario);
        }
        
        public void InserirNACCampus(MA_NAC_CAMPUS naccampus)
        {
            this.RepositorioDeNACCampus.InserirNACCampus(naccampus);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeNACCampus.BuscarQuantidadeRegistros();
        }

        public void RemoverNACCampus(MA_NAC_CAMPUS naccampus)
        {
            this.RepositorioDeNACCampus.RemoverNACCampus(naccampus);
        }

        public void AtualizarNACCampus(MA_NAC_CAMPUS naccampus)
        {
            this.RepositorioDeNACCampus.AtualizarNACCampus(naccampus);
        }
    }
}
