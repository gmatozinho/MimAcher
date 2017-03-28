using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeNacAreaDeAtuacao
    {
        public RepositorioDeNacAreaDeAtuacao RepositorioDeNacAreaDeAtuacao { get; set; }

        public GestorDeNacAreaDeAtuacao()
        {
            this.RepositorioDeNacAreaDeAtuacao = new RepositorioDeNacAreaDeAtuacao();
        }

        public MA_NAC_AREA_ATUACAO ObterNacAreaDeAtuacaoPorId(int id)
        {
            return this.RepositorioDeNacAreaDeAtuacao.ObterNacAreaDeAtuacaoPorId(id);
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNacAreasDeAtuacao()
        {
            return this.RepositorioDeNacAreaDeAtuacao.ObterTodasAsNacAreasDeAtuacao();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNacSAreasDeAtuacaosPorNomeDeAreaDeAtuacao(String nome)
        {
            return this.RepositorioDeNacAreaDeAtuacao.ObterTodasAsNacsAreasDeAtuacaosPorNomeDeAreaDeAtuacao(nome);
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNacSAreasDeAtuacaosPorNomeDeRepresentanteDoNac(String nomerepresentante)
        { 
       
            return this.RepositorioDeNacAreaDeAtuacao.ObterTodasAsNacsAreasDeAtuacaosPorNomeDeRepresentanteDoNac(nomerepresentante);
        }

        public void InserirNacAreaDeAtuacao(MA_NAC_AREA_ATUACAO nacAreaDeAtuacao)
        {
            this.RepositorioDeNacAreaDeAtuacao.InserirNacAreaDeAtuacao(nacAreaDeAtuacao);
        }

        public Boolean InserirNacAreaDeAtuacaoComRetorno(MA_NAC_AREA_ATUACAO nacAreaDeAtuacao)
        {
            return this.RepositorioDeNacAreaDeAtuacao.InserirNacAreaDeAtuacaoComRetorno(nacAreaDeAtuacao);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeNacAreaDeAtuacao.BuscarQuantidadeRegistros();
        }

        public void RemoverNacAreaDeAtuacao(MA_NAC_AREA_ATUACAO nacAreaDeAtuacao)
        {
            this.RepositorioDeNacAreaDeAtuacao.RemoverNacAreaDeAtuacao(nacAreaDeAtuacao);
        }

        public void AtualizarNacAreaDeAtuacao(MA_NAC_AREA_ATUACAO nacAreaDeAtuacao)
        {
            this.RepositorioDeNacAreaDeAtuacao.AtualizarNacAreaDeAtuacao(nacAreaDeAtuacao);
        }

        public Boolean AtualizarNacAreaDeAtuacaoComRetorno(MA_NAC_AREA_ATUACAO nacAreaDeAtuacao)
        {
            return this.RepositorioDeNacAreaDeAtuacao.AtualizarNacAreaDeAtuacaoComRetorno(nacAreaDeAtuacao);
        }

    }
}
