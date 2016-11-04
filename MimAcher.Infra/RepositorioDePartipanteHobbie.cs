using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDePartipanteHobbie
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDePartipanteHobbie()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_HOBBIE ObterHobbieDoParticipantePorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Find(id);
        }

        public MA_PARTICIPANTE_HOBBIE ObterParticipanteHobbiePorItemEParticipante(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_participante == participantehobbie.cod_participante && l.cod_item == participantehobbie.cod_item).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.ToList();
        }
                
        public void InserirNovoParticipanteHobbie(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(hobbieparticipante))
            {
                this.Contexto.MA_PARTICIPANTE_HOBBIE.Add(hobbieparticipante);
                this.Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Count();
        }

        public void RemoverHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbiedoparticipante)
        {
            this.Contexto.MA_PARTICIPANTE_HOBBIE.Remove(hobbiedoparticipante);
            this.Contexto.SaveChanges();
        }

        public void AtualizarHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(hobbieparticipante))
            {
                this.Contexto.Entry(hobbieparticipante).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteAprender(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            if (ObterParticipanteHobbiePorItemEParticipante(participantehobbie) != null)
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
