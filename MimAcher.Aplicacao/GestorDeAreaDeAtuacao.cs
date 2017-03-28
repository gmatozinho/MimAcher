using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeAreaDeAtuacao
    {
        public RepositorioDeAreaDeAtuacao RepositorioDeAreaDeAtuacao { get; set; }

        public GestorDeAreaDeAtuacao()
        {
            this.RepositorioDeAreaDeAtuacao = new RepositorioDeAreaDeAtuacao();
        }

        public MA_AREA_ATUACAO ObterAreaDeAtuacaoPorId(int id)
        {
            return this.RepositorioDeAreaDeAtuacao.ObterAreaDeAtuacaoPorId(id);
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacao()
        {
            return this.RepositorioDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao();
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacaosPorNome(String nome)
        {
            return this.RepositorioDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacaosPorNome(nome);
        }

        public void InserirAreaDeAtuacao(MA_AREA_ATUACAO areaDeAtuacao)
        {
            this.RepositorioDeAreaDeAtuacao.InserirAreaDeAtuacao(areaDeAtuacao);
        }

        public Boolean InserirAreaDeAtuacaoComRetorno(MA_AREA_ATUACAO areaDeAtuacao)
        {
            return this.RepositorioDeAreaDeAtuacao.InserirAreaDeAtuacaoComRetorno(areaDeAtuacao);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAreaDeAtuacao.BuscarQuantidadeRegistros();
        }

        public void RemoverAreaDeAtuacao(MA_AREA_ATUACAO areaDeAtuacao)
        {
            this.RepositorioDeAreaDeAtuacao.RemoverAreaDeAtuacao(areaDeAtuacao);
        }

        public void AtualizarAreaDeAtuacao(MA_AREA_ATUACAO areaDeAtuacao)
        {
            this.RepositorioDeAreaDeAtuacao.AtualizarAreaDeAtuacao(areaDeAtuacao);
        }

        public Boolean AtualizarAreaDeAtuacaoComRetorno(MA_AREA_ATUACAO areaDeAtuacao)
        {
            return this.RepositorioDeAreaDeAtuacao.AtualizarAreaDeAtuacaoComRetorno(areaDeAtuacao);
        }
    }
}
