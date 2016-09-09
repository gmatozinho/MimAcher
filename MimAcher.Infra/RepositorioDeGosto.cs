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

        public MA_GOSTO ObterGostoPorId(int id)
        {
            return this.Contexto.MA_GOSTO.Find(id);
        }

        public List<MA_GOSTO> ObterTodosOsRegistrosDoQueSePodeEnsinado()
        {
            return this.Contexto.MA_GOSTO.ToList();
        }

        public List<MA_GOSTO> ObterTodosOsRegistrosDeGostoPorNome(String nome)
        {
            return this.Contexto.MA_GOSTO.Where(l => l.nome.Equals(nome)).ToList();
        }

        public void InserirNovoGosto(MA_GOSTO gosto)
        {
            this.Contexto.MA_GOSTO.Add(gosto);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_GOSTO.Count();
        }

        public void RemoverGosto(MA_GOSTO gosto)
        {
            this.Contexto.MA_GOSTO.Remove(gosto);
            this.Contexto.SaveChanges();
        }

        public void AtualizarGosto(MA_GOSTO gosto)
        {
            this.Contexto.Entry(gosto).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
