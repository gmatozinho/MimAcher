using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeParticipanteEnsinar
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeParticipanteEnsinar()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_ENSINAR ObterRelacaoDoQueOParticipanteEnsinaPorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Find(id);
        }

        public MA_PARTICIPANTE_ENSINAR ObterEnsinoDeParticipantePorItemEParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Where(l => l.cod_participante == participanteensinar.cod_participante && l.cod_item == participanteensinar.cod_item).SingleOrDefault();
        }


        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.ToList();
        }
        
        public void InserirNovoEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteensinar))
            {
                this.Contexto.MA_PARTICIPANTE_ENSINAR.Add(participanteensinar);
                this.Contexto.SaveChanges();
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Count();
        }

        public void RemoverEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.Contexto.MA_PARTICIPANTE_ENSINAR.Remove(participanteensinar);
            this.Contexto.SaveChanges();
        }

        public void AtualizarEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteensinar))
            {
                this.Contexto.Entry(participanteensinar).State = EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteAprender(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (ObterEnsinoDeParticipantePorItemEParticipante(participanteensinar) != null)
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
