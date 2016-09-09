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

        public MA_APRENDER ObterAprendizadoPorId(int id)
        {
            return this.Contexto.MA_APRENDER.Find(id);
        }

        public List<MA_APRENDER> ObterTodosOsRegistrosDoQueSePodeAprender()
        {
            return this.Contexto.MA_APRENDER.ToList();
        }

        public List<MA_APRENDER> ObterTodosOsRegistrosDoQueSePodeAprenderPorNome(String nome)
        {
            return this.Contexto.MA_APRENDER.Where(l => l.nome.Equals(nome)).ToList();
        }
        
        public void InserirNovoAprendizado(MA_APRENDER aprender)
        {
            this.Contexto.MA_APRENDER.Add(aprender);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_APRENDER.Count();
        }

        public void RemoverAprendizado(MA_APRENDER aprender)
        {
            this.Contexto.MA_APRENDER.Remove(aprender);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAprendizado(MA_APRENDER aprender)
        {
            this.Contexto.Entry(aprender).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
