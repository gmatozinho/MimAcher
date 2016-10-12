using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeNAC
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeNAC()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_NAC ObterNACPorId(int id)
        {
            return this.Contexto.MA_NAC.Find(id);
        }

        public List<MA_NAC> ObterTodosOsNAC()
        {
            return this.Contexto.MA_NAC.ToList();
        }

        public List<MA_NAC> ObterTodosOsNACPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.Contexto.MA_NAC.Where(l => l.nome_representante.Equals(nomerepresentante)).ToList();
        }
        
        public void InserirNAC(MA_NAC nac)
        {
            this.Contexto.MA_NAC.Add(nac);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_NAC.Count();
        }

        public void RemoverNAC(MA_NAC nac)
        {
            this.Contexto.MA_NAC.Remove(nac);
            this.Contexto.SaveChanges();
        }

        public void AtualizarNAC(MA_NAC nac)
        {
            this.Contexto.Entry(nac).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
