using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeCampus
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeCampus()
        {
            Contexto = new MIMACHEREntities();
        }

        public MA_CAMPUS ObterCampusPorId(int id)
        {
            return Contexto.MA_CAMPUS.Find(id);
        }

        public MA_CAMPUS ObterCampusPorNomeDeLocal(MA_CAMPUS campus)
        {
            return Contexto.MA_CAMPUS.Where(l => l.local.ToLower().Equals(campus.local.ToLower())).SingleOrDefault();
        }

        public List<MA_CAMPUS> ObterTodosOsCampus()
        {
            return Contexto.MA_CAMPUS.ToList();
        }
        

        public void InserirCampus(MA_CAMPUS campus)
        {
            if (!VerificarSeNomeDeLocalDeCampusJaExiste(campus))
            {
                Contexto.MA_CAMPUS.Add(campus);
                Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_CAMPUS.Count();
        }

        public void RemoverCampus(MA_CAMPUS campus)
        {
            Contexto.MA_CAMPUS.Remove(campus);
            Contexto.SaveChanges();
        }

        public void AtualizarCampus(MA_CAMPUS campus)
        {
            if (!VerificarSeNomeDeLocalDeCampusJaExiste(campus))
            {
                Contexto.Entry(campus).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeNomeDeLocalDeCampusJaExiste(MA_CAMPUS campus)
        {
            if (ObterCampusPorNomeDeLocal(campus) != null)
            {
                return true;
            }
            return false;
        }
    }
}
