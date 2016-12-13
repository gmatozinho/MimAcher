using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Dominio;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeStatus
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeStatus()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_STATUS ObterStatusPorId(int id)
        {
            return this.Contexto.MA_STATUS.Find(id);
        }

        public MA_STATUS ObterStatusPorNome(MA_STATUS status)
        {
            return this.Contexto.MA_STATUS.Where(l => l.nome.Equals(status.nome)).SingleOrDefault();
        }

        public List<MA_STATUS> ObterTodosOsStatus()
        {
            return this.Contexto.MA_STATUS.ToList();
        }

        public List<MA_STATUS> ObterTodosOsStatusPorNome(String nome)
        {
            return this.Contexto.MA_STATUS.Where(l => l.nome.ToLowerInvariant().Equals(nome.ToLowerInvariant())).ToList();
        }

        public void InserirStatus(MA_STATUS Status)
        {
            if (VerificarSeNomeDeStatusJaExiste(Status))
            {
                this.Contexto.MA_STATUS.Add(Status);
                this.Contexto.SaveChanges();
            }

        }

        public Boolean InserirStatusComRetorno(MA_STATUS Status)
        {
            if (VerificarSeNomeDeStatusJaExiste(Status))
            {
                try
                {
                    this.Contexto.MA_STATUS.Add(Status);
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_STATUS.Count();
        }

        public void RemoverStatus(MA_STATUS Status)
        {
            this.Contexto.MA_STATUS.Remove(Status);
            this.Contexto.SaveChanges();
        }

        public void AtualizarStatus(MA_STATUS Status)
        {
            if (VerificarSeNomeDeStatusJaExiste(Status))
            {
                this.Contexto.Entry(Status).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean AtualizarStatusComRetorno(MA_STATUS Status)
        {
            if (VerificarSeNomeDeStatusJaExiste(Status))
            {
                try
                {
                    this.Contexto.Entry(Status).State = EntityState.Modified;
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeNomeDeStatusJaExiste(MA_STATUS status)
        {
            if (ObterStatusPorNome(status) != null)
            {
                return true;
            }
            return false;
        }
    }
}
