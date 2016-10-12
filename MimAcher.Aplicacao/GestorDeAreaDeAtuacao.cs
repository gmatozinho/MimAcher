using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void InserirAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            this.RepositorioDeAreaDeAtuacao.InserirAreaDeAtuacao(AreaDeAtuacao);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAreaDeAtuacao.BuscarQuantidadeRegistros();
        }

        public void RemoverAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            this.RepositorioDeAreaDeAtuacao.RemoverAreaDeAtuacao(AreaDeAtuacao);
        }

        public void AtualizarAreaDeAtuacao(MA_AREA_ATUACAO AreaDeAtuacao)
        {
            this.RepositorioDeAreaDeAtuacao.AtualizarAreaDeAtuacao(AreaDeAtuacao);
        }
    }
}
