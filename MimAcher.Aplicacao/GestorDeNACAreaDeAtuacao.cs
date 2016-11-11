using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeNACAreaDeAtuacao
    {
        public RepositorioDeNACAreaDeAtuacao RepositorioDeNACAreaDeAtuacao { get; set; }

        public GestorDeNACAreaDeAtuacao()
        {
            RepositorioDeNACAreaDeAtuacao = new RepositorioDeNACAreaDeAtuacao();
        }

        public MA_NAC_AREA_ATUACAO ObterNACAreaDeAtuacaoPorId(int id)
        {
            return RepositorioDeNACAreaDeAtuacao.ObterNACAreaDeAtuacaoPorId(id);
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACAreasDeAtuacao()
        {
            return RepositorioDeNACAreaDeAtuacao.ObterTodasAsNACAreasDeAtuacao();
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACSAreasDeAtuacaosPorNomeDeAreaDeAtuacao(String nome)
        {
            return RepositorioDeNACAreaDeAtuacao.ObterTodasAsNACSAreasDeAtuacaosPorNomeDeAreaDeAtuacao(nome);
        }

        public List<MA_NAC_AREA_ATUACAO> ObterTodasAsNACSAreasDeAtuacaosPorNomeDeRepresentanteDoNAC(String nomerepresentante)
        {
            return RepositorioDeNACAreaDeAtuacao.ObterTodasAsNACSAreasDeAtuacaosPorNomeDeRepresentanteDoNAC(nomerepresentante);
        }

        public void InserirNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            RepositorioDeNACAreaDeAtuacao.InserirNACAreaDeAtuacao(NACAreaDeAtuacao);            
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeNACAreaDeAtuacao.BuscarQuantidadeRegistros();
        }

        public void RemoverNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            RepositorioDeNACAreaDeAtuacao.RemoverNACAreaDeAtuacao(NACAreaDeAtuacao);
        }

        public void AtualizarNACAreaDeAtuacao(MA_NAC_AREA_ATUACAO NACAreaDeAtuacao)
        {
            RepositorioDeNACAreaDeAtuacao.AtualizarNACAreaDeAtuacao(NACAreaDeAtuacao);
        }

    } 
}
