using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;
using MimAcher.Dominio;

namespace MimAcher.Aplicacao
{
    public class GestorDeStatus
    {
        public RepositorioDeStatus RepositorioDeStatus { get; set; }

        public GestorDeStatus()
        {
            this.RepositorioDeStatus = new RepositorioDeStatus();
        }

        public MA_STATUS ObterStatusPorId(int id)
        {
            return this.RepositorioDeStatus.ObterStatusPorId(id);
        }

        public MA_STATUS ObterStatusPorNome(MA_STATUS statusrelacao)
        {
            return this.RepositorioDeStatus.ObterStatusPorNome(statusrelacao);
        }

        public List<MA_STATUS> ObterTodosOsStatus()
        {
            return this.RepositorioDeStatus.ObterTodosOsStatus();
        }

        public List<MA_STATUS> ObterTodosOsStatusPorNome(String nome)
        {
            return this.RepositorioDeStatus.ObterTodosOsStatusPorNome(nome);
        }

        public void InserirStatus(MA_STATUS status)
        {
            this.RepositorioDeStatus.InserirStatus(status);
        }

        public Boolean InserirStatusComRetorno(MA_STATUS status)
        {
            return this.RepositorioDeStatus.InserirStatusComRetorno(status);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeStatus.BuscarQuantidadeRegistros();
        }

        public void RemoverStatus(MA_STATUS status)
        {
            this.RepositorioDeStatus.RemoverStatus(status);
        }

        public void AtualizarStatus(MA_STATUS status)
        {
            this.RepositorioDeStatus.AtualizarStatus(status);
        }

        public Boolean AtualizarStatusComRetorno(MA_STATUS status)
        {
            return this.RepositorioDeStatus.AtualizarStatusComRetorno(status);
        }
    }
}
