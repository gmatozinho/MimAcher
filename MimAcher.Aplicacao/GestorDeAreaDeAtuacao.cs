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
            RepositorioDeAreaDeAtuacao = new RepositorioDeAreaDeAtuacao();
        }

        public MA_AREA_ATUACAO ObterAreaDeAtuacaoPorId(int id)
        {
            return RepositorioDeAreaDeAtuacao.ObterAreaDeAtuacaoPorId(id);
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacao()
        {
            return RepositorioDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacao();
        }

        public List<MA_AREA_ATUACAO> ObterTodasAsAreasDeAtuacaosPorNome(String nome)
        {
            return RepositorioDeAreaDeAtuacao.ObterTodasAsAreasDeAtuacaosPorNome(nome);
        }

        public void InserirAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            RepositorioDeAreaDeAtuacao.InserirAreaDeAtuacao(AreaDeAtuacao);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeAreaDeAtuacao.BuscarQuantidadeRegistros();
        }

        public void RemoverAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            RepositorioDeAreaDeAtuacao.RemoverAreaDeAtuacao(AreaDeAtuacao);
        }

        public void AtualizarAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            RepositorioDeAreaDeAtuacao.AtualizarAreaDeAtuacao(AreaDeAtuacao);
        }
    }
}
