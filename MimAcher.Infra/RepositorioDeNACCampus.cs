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

        public MA_NAC_CAMPUS ObterNACCampusPorId(int id)
        {
            return this.Contexto.MA_NAC_CAMPUS.Find(id);
        }

        public List<MA_NAC_CAMPUS> ObterTodosOsNACCampus()
        {
            return this.Contexto.MA_NAC_CAMPUS.ToList();
        }

        public List<MA_NAC_CAMPUS> ObterTodosOsNACCampusPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.Contexto.MA_NAC_CAMPUS.Where(l => l.nome_representante.Equals(nomerepresentante)).ToList();
        }

        public MA_NAC_CAMPUS ObterNACCampusPorIdDeUsuario(int id_usuario)
        {
            return this.Contexto.MA_NAC_CAMPUS.Where(l => l.cod_us == id_usuario).SingleOrDefault();
        }


        public void InserirNACCampus(MA_NAC_CAMPUS naccampus)
        {
            this.Contexto.MA_NAC_CAMPUS.Add(naccampus);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_NAC_CAMPUS.Count();
        }

        public void RemoverNACCampus(MA_NAC_CAMPUS naccampus)
        {
            this.Contexto.MA_NAC_CAMPUS.Remove(naccampus);
            this.Contexto.SaveChanges();
        }

        public void AtualizarNACCampus(MA_NAC_CAMPUS naccampus)
        {
            this.Contexto.Entry(naccampus).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
