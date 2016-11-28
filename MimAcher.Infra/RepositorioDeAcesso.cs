using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Dominio;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeAcesso
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAcesso()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_ACESSO ObterAcessoPorId(int id)
        {
            return this.Contexto.MA_ACESSO.Find(id);
        }

        public MA_ACESSO ObterAcessoPorNome(MA_ACESSO acesso)
        {
            return this.Contexto.MA_ACESSO.Where(l => l.nome.Equals(acesso.nome)).SingleOrDefault();
        }

        public List<MA_ACESSO> ObterTodosOsAcessos()
        {
            return this.Contexto.MA_ACESSO.ToList();
        }

        public List<MA_ACESSO> ObterTodosOsAcessosPorNome(String nome)
        {
            return this.Contexto.MA_ACESSO.Where(l => l.nome.ToLowerInvariant().Equals(nome.ToLowerInvariant())).ToList();
        }

        public void InserirAcesso(MA_ACESSO Acesso)
        {
            if (VerificarSeNomeDeAcessoJaExiste(Acesso))
            {
                this.Contexto.MA_ACESSO.Add(Acesso);
                this.Contexto.SaveChanges();
            }

        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ACESSO.Count();
        }

        public void RemoverAcesso(MA_ACESSO Acesso)
        {
            this.Contexto.MA_ACESSO.Remove(Acesso);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAcesso(MA_ACESSO Acesso)
        {
            if (VerificarSeNomeDeAcessoJaExiste(Acesso))
            {
                this.Contexto.Entry(Acesso).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeNomeDeAcessoJaExiste(MA_ACESSO acesso)
        {
            if (ObterAcessoPorNome(acesso) != null)
            {
                return true;
            }
            return false;
        }
    }
}
