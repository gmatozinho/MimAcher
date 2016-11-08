using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeAprendizadoDeParticipante
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAprendizadoDeParticipante()
        {
            Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDoParticipantePorId(int id)
        {
            return Contexto.MA_PARTICIPANTE_APRENDER.Find(id);
        }

        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDeParticipantePorItemEParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            return Contexto.MA_PARTICIPANTE_APRENDER.Where(l => l.cod_participante == participanteaprender.cod_participante && l.cod_item == participanteaprender.cod_item).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsRegistros()
        {
            return Contexto.MA_PARTICIPANTE_APRENDER.ToList();
        }

        public void InserirNovoAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteaprender))
            {
                Contexto.MA_PARTICIPANTE_APRENDER.Add(participanteaprender);
                Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_PARTICIPANTE_APRENDER.Count();
        }

        public void RemoverAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            Contexto.MA_PARTICIPANTE_APRENDER.Remove(participanteaprender);
            Contexto.SaveChanges();
        }

        public void AtualizarAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteaprender))
            {
                Contexto.Entry(participanteaprender).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteAprender(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            if(ObterAprendizadoDeParticipantePorItemEParticipante(participanteaprender) != null)
            {
                return true;
            }
            return false;
        }
    }
}
