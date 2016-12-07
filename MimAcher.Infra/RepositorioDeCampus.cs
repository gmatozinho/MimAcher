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

        public Boolean InserirCampusComRetorno(MA_CAMPUS campus)
        {
            if (!VerificarSeNomeDeLocalDeCampusJaExiste(campus))
            {
                try
                {
                    this.Contexto.MA_CAMPUS.Add(campus);
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception e)
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

        public Boolean AtualizarCampusComRetorno(MA_CAMPUS campus)
        {
            if (!VerificarSeNomeDeLocalDeCampusJaExiste(campus))
            {
                try
                {
                    this.Contexto.Entry(campus).State = EntityState.Modified;
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            else
            {
                return false;
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
