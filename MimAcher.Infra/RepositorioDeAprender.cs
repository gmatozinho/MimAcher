using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeAprender
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAprender()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<APRENDER> ObterTodosOsRegistrosDoQueSePodeAprender()
        {
            return this.Contexto.APRENDER.ToList();
        }

        public List<APRENDER> ObterTodosOsRegistrosDoQueSePodeAprenderPorNome(String nome)
        {
            return this.Contexto.APRENDER.Where(l => l.nome.Equals(nome)).ToList();
        }
        
        public void InserirNovoAprendizado(APRENDER aprender)
        {
            this.Contexto.APRENDER.Add(aprender);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.APRENDER.Count();
        }

        public void RemoverAprendizado(APRENDER aprender)
        {
            this.Contexto.APRENDER.Remove(aprender);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAprendizado(APRENDER aprender)
        {
            this.Contexto.Entry(aprender).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
