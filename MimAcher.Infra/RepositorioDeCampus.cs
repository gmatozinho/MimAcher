using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeCampus
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeCampus()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_CAMPUS ObterCampusPorId(int id)
        {
            return this.Contexto.MA_CAMPUS.Find(id);
        }

        public MA_CAMPUS ObterCampusPorNomeDeLocal(MA_CAMPUS campus)
        {
            return this.Contexto.MA_CAMPUS.Where(l => l.local.ToLower().Equals(campus.local.ToLower())).SingleOrDefault();
        }

        public List<MA_CAMPUS> ObterTodosOsCampus()
        {
            return this.Contexto.MA_CAMPUS.ToList();
        }
        

        public void InserirCampus(MA_CAMPUS campus)
        {
            if (!VerificarSeNomeDeLocalDeCampusJaExiste(campus))
            {
                this.Contexto.MA_CAMPUS.Add(campus);
                this.Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_CAMPUS.Count();
        }

        public void RemoverCampus(MA_CAMPUS campus)
        {
            this.Contexto.MA_CAMPUS.Remove(campus);
            this.Contexto.SaveChanges();
        }

        public void AtualizarCampus(MA_CAMPUS campus)
        {
            if (!VerificarSeNomeDeLocalDeCampusJaExiste(campus))
            {
                this.Contexto.Entry(campus).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeNomeDeLocalDeCampusJaExiste(MA_CAMPUS campus)
        {
            if (ObterCampusPorNomeDeLocal(campus) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
