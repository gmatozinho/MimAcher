using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeAprendizadoDeParticipante
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAprendizadoDeParticipante()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDoParticipantePorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Find(id);
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.ToList();
        }

        public void InserirNovoAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.Contexto.MA_PARTICIPANTE_APRENDER.Add(participanteaprender);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Count();
        }

        public void RemoverAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.Contexto.MA_PARTICIPANTE_APRENDER.Remove(participanteaprender);
            this.Contexto.SaveChanges();
        }

        public void AtualizarAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.Contexto.Entry(participanteaprender).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
