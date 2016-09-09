using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeGosto
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeGosto()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<GOSTO> ObterTodosOsRegistrosDoQueSePodeEnsinado()
        {
            return this.Contexto.GOSTO.ToList();
        }

        public List<GOSTO> ObterTodosOsRegistrosDeGostoPorNome(String nome)
        {
            return this.Contexto.GOSTO.Where(l => l.nome.Equals(nome)).ToList();
        }

        public void InserirNovoGosto(GOSTO gosto)
        {
            this.Contexto.GOSTO.Add(gosto);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.GOSTO.Count();
        }

        public void RemoverGosto(GOSTO gosto)
        {
            this.Contexto.GOSTO.Remove(gosto);
            this.Contexto.SaveChanges();
        }

        public void AtualizarGosto(GOSTO gosto)
        {
            this.Contexto.Entry(gosto).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
