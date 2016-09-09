using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeNACCampus
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeNACCampus()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<NAC_CAMPUS> ObterTodosOsNACCampus()
        {
            return this.Contexto.NAC_CAMPUS.ToList();
        }

        public List<NAC_CAMPUS> ObterTodosOsNACCampusPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.Contexto.NAC_CAMPUS.Where(l => l.nome_representante.Equals(nomerepresentante)).ToList();
        }

        public NAC_CAMPUS ObterNACCampusPorLogin(String login)
        {
            return this.Contexto.NAC_CAMPUS.Where(l => l.login.Equals(login)).SingleOrDefault();
        }


        public void InserirNACCampus(NAC_CAMPUS naccampus)
        {
            this.Contexto.NAC_CAMPUS.Add(naccampus);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.NAC_CAMPUS.Count();
        }

        public void RemoverNACCampus(NAC_CAMPUS naccampus)
        {
            this.Contexto.NAC_CAMPUS.Remove(naccampus);
            this.Contexto.SaveChanges();
        }

        public void AtualizarNACCampus(NAC_CAMPUS naccampus)
        {
            this.Contexto.Entry(naccampus).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
