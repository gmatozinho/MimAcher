using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeNAC
    {
        public RepositorioDeNAC RepositorioDeNAC { get; set; }

        public GestorDeNAC()
        {
            this.RepositorioDeNAC = new RepositorioDeNAC();
        }

        public MA_NAC ObterNACPorId(int id)
        {
            return this.RepositorioDeNAC.ObterNACPorId(id);
        }

        public MA_NAC ObterNACPorIdDeUsuario(int idUsuario)
        {
            return this.RepositorioDeNAC.ObterNACPorIdDeUsuario(idUsuario);
        }

        public List<MA_NAC> ObterTodosOsNAC()
        {
            return this.RepositorioDeNAC.ObterTodosOsNAC();
        }

        public List<MA_NAC> ObterTodosOsNACPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.RepositorioDeNAC.ObterTodosOsNACPorNomeDoRepresentante(nomerepresentante);
        }
        
        public void InserirNAC(MA_NAC nac)
        {
            this.RepositorioDeNAC.InserirNAC(nac);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeNAC.BuscarQuantidadeRegistros();
        }

        public void RemoverNAC(MA_NAC nac)
        {
            this.RepositorioDeNAC.RemoverNAC(nac);
        }

        public void AtualizarNAC(MA_NAC nac)
        {
            this.RepositorioDeNAC.AtualizarNAC(nac);
        }
    }
}
