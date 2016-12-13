using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeNACAreaDeAtuacao
    {
        public RepositorioDeNacAreaDeAtuacao RepositorioDeNACAreaDeAtuacao { get; set; }

        public GestorDeNACAreaDeAtuacao()
        {
            this.RepositorioDeNACAreaDeAtuacao = new RepositorioDeNacAreaDeAtuacao();
        }

        public MA_NAC_AREA_ATUACAO ObterNACAreaDeAtuacaoPorId(int id)
        {
            return this.RepositorioDeNACAreaDeAtuacao.ObterNACAreaDeAtuacaoPorId(id);
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACAreasDeAtuacao()
        {
            return this.RepositorioDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACSAreasDeAtuacaosPorNomeDeAreaDeAtuacao(String nome)
        {
            return this.RepositorioDeNACAreaDeAtuacao.ObterTodasAsNACSAreasDeAtuacaosPorNomeDeAreaDeAtuacao(nome);
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACSAreasDeAtuacaosPorNomeDeRepresentanteDoNAC(String nomerepresentante)
        {
            return this.RepositorioDeNACAreaDeAtuacao.ObterTodasAsNACSAreasDeAtuacaosPorNomeDeRepresentanteDoNAC(nomerepresentante);
        }

        public void InserirNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            this.RepositorioDeNACAreaDeAtuacao.InserirNACAreaDeAtuacao(NACAreaDeAtuacao);
        }

        public Boolean InserirNACAreaDeAtuacaoComRetorno(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            return this.RepositorioDeNACAreaDeAtuacao.InserirNACAreaDeAtuacaoComRetorno(NACAreaDeAtuacao);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeNACAreaDeAtuacao.BuscarQuantidadeRegistros();
        }

        public void RemoverNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            this.RepositorioDeNACAreaDeAtuacao.RemoverNACAreaDeAtuacao(NACAreaDeAtuacao);
        }

        public void AtualizarNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            this.RepositorioDeNACAreaDeAtuacao.AtualizarNACAreaDeAtuacao(NACAreaDeAtuacao);
        }

        public Boolean AtualizarNACAreaDeAtuacaoComRetorno(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            return this.RepositorioDeNACAreaDeAtuacao.AtualizarNACAreaDeAtuacaoComRetorno(NACAreaDeAtuacao);
        }

    }
}
