using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Dominio;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeStatusDeRelacao
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeStatusDeRelacao()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_STATUS_RELACAO ObterStatusDeRelacaoPorId(int id)
        {
            return this.Contexto.MA_STATUS_RELACAO.Find(id);
        }

        public MA_STATUS_RELACAO ObterStatusDeRelacaoPorNome(MA_STATUS_RELACAO statusrelacao)
        {
            return this.Contexto.MA_STATUS_RELACAO.Where(l => l.nome.Equals(statusrelacao.nome)).SingleOrDefault();
        }

        public List<MA_STATUS_RELACAO> ObterTodosOsStatusDeRelacao()
        {
            return this.Contexto.MA_STATUS_RELACAO.ToList();
        }

        public List<MA_STATUS_RELACAO> ObterTodosOsStatusDeRelacaoPorNome(String nome)
        {
            return this.Contexto.MA_STATUS_RELACAO.Where(l => l.nome.ToLowerInvariant().Equals(nome.ToLowerInvariant())).ToList();
        }

        public void InserirStatusDeRelacao(MA_STATUS_RELACAO StatusDeRelacao)
        {
            if (VerificarSeNomeDeStatusDeRelacaoJaExiste(StatusDeRelacao))
            {
                this.Contexto.MA_STATUS_RELACAO.Add(StatusDeRelacao);
                this.Contexto.SaveChanges();
            }

        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_STATUS_RELACAO.Count();
        }

        public void RemoverStatusDeRelacao(MA_STATUS_RELACAO StatusDeRelacao)
        {
            this.Contexto.MA_STATUS_RELACAO.Remove(StatusDeRelacao);
            this.Contexto.SaveChanges();
        }

        public void AtualizarStatusDeRelacao(MA_STATUS_RELACAO StatusDeRelacao)
        {
            if (VerificarSeNomeDeStatusDeRelacaoJaExiste(StatusDeRelacao))
            {
                this.Contexto.Entry(StatusDeRelacao).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeNomeDeStatusDeRelacaoJaExiste(MA_STATUS_RELACAO statusrelacao)
        {
            if (ObterStatusDeRelacaoPorNome(statusrelacao) != null)
            {
                return true;
            }
            return false;
        }
    }
}
