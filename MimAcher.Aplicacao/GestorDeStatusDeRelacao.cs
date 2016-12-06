using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;
using MimAcher.Dominio;

namespace MimAcher.Aplicacao
{
    public class GestorDeStatusDeRelacao
    {
        public RepositorioDeStatusDeRelacao RepositorioDeStatusDeRelacao { get; set; }

        public GestorDeStatusDeRelacao()
        {
            this.RepositorioDeStatusDeRelacao = new RepositorioDeStatusDeRelacao();
        }

        public MA_STATUS_RELACAO ObterStatusDeRelacaoPorId(int id)
        {
            return this.RepositorioDeStatusDeRelacao.ObterStatusDeRelacaoPorId(id);
        }

        public MA_STATUS_RELACAO ObterStatusDeRelacaoPorNome(MA_STATUS_RELACAO statusrelacao)
        {
            return this.RepositorioDeStatusDeRelacao.ObterStatusDeRelacaoPorNome(statusrelacao);
        }

        public List<MA_STATUS_RELACAO> ObterTodosOsStatusDeRelacao()
        {
            return this.RepositorioDeStatusDeRelacao.ObterTodosOsStatusDeRelacao();
        }

        public List<MA_STATUS_RELACAO> ObterTodosOsStatusDeRelacaoPorNome(String nome)
        {
            return this.RepositorioDeStatusDeRelacao.ObterTodosOsStatusDeRelacaoPorNome(nome);
        }

        public void InserirStatusDeRelacao(MA_STATUS_RELACAO StatusDeRelacao)
        {
            this.RepositorioDeStatusDeRelacao.InserirStatusDeRelacao(StatusDeRelacao);
        }

        public Boolean InserirStatusDeRelacaoComRetorno(MA_STATUS_RELACAO StatusDeRelacao)
        {
            return this.RepositorioDeStatusDeRelacao.InserirStatusDeRelacaoComRetorno(StatusDeRelacao);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeStatusDeRelacao.BuscarQuantidadeRegistros();
        }

        public void RemoverStatusDeRelacao(MA_STATUS_RELACAO StatusDeRelacao)
        {
            this.RepositorioDeStatusDeRelacao.RemoverStatusDeRelacao(StatusDeRelacao);
        }

        public void AtualizarStatusDeRelacao(MA_STATUS_RELACAO StatusDeRelacao)
        {
            this.RepositorioDeStatusDeRelacao.AtualizarStatusDeRelacao(StatusDeRelacao);
        }

        public Boolean AtualizarStatusDeRelacaoComRetorno(MA_STATUS_RELACAO StatusDeRelacao)
        {
            return this.RepositorioDeStatusDeRelacao.AtualizarStatusDeRelacaoComRetorno(StatusDeRelacao);
        }
    }
}
