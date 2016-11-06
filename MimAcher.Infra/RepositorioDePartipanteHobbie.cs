using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDePartipanteHobbie
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDePartipanteHobbie()
        {
            Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_HOBBIE ObterHobbieDoParticipantePorId(int id)
        {
            return Contexto.MA_PARTICIPANTE_HOBBIE.Find(id);
        }

        public MA_PARTICIPANTE_HOBBIE ObterParticipanteHobbiePorItemEParticipante(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            return Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_participante == participantehobbie.cod_participante && l.cod_item == participantehobbie.cod_item).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistros()
        {
            return Contexto.MA_PARTICIPANTE_HOBBIE.ToList();
        }
                
        public void InserirNovoParticipanteHobbie(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(hobbieparticipante))
            {
                Contexto.MA_PARTICIPANTE_HOBBIE.Add(hobbieparticipante);
                Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_PARTICIPANTE_HOBBIE.Count();
        }

        public void RemoverHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbiedoparticipante)
        {
            Contexto.MA_PARTICIPANTE_HOBBIE.Remove(hobbiedoparticipante);
            Contexto.SaveChanges();
        }

        public void AtualizarHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(hobbieparticipante))
            {
                Contexto.Entry(hobbieparticipante).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteAprender(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            if (ObterParticipanteHobbiePorItemEParticipante(participantehobbie) != null)
            {
                return true;
            }
            return false;
        }
    }
}
