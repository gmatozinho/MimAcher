using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeParticipanteEnsinar
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeParticipanteEnsinar()
        {
            Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_ENSINAR ObterRelacaoDoQueOParticipanteEnsinaPorId(int id)
        {
            return Contexto.MA_PARTICIPANTE_ENSINAR.Find(id);
        }

        public MA_PARTICIPANTE_ENSINAR ObterEnsinoDeParticipantePorItemEParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return Contexto.MA_PARTICIPANTE_ENSINAR.Where(l => l.cod_participante == participanteensinar.cod_participante && l.cod_item == participanteensinar.cod_item).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistros()
        {
            return Contexto.MA_PARTICIPANTE_ENSINAR.ToList();
        }
        
        public void InserirNovoEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteensinar))
            {
                Contexto.MA_PARTICIPANTE_ENSINAR.Add(participanteensinar);
                Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_PARTICIPANTE_ENSINAR.Count();
        }

        public void RemoverEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            Contexto.MA_PARTICIPANTE_ENSINAR.Remove(participanteensinar);
            Contexto.SaveChanges();
        }

        public void AtualizarEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteensinar))
            {
                Contexto.Entry(participanteensinar).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteAprender(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (ObterEnsinoDeParticipantePorItemEParticipante(participanteensinar) != null)
            {
                return true;
            }
            return false;
        }
    }
}
