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

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.ToList();
        }
        
        public void InserirNovoEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.Contexto.MA_PARTICIPANTE_ENSINAR.Add(participanteensinar);
            this.Contexto.SaveChanges();
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
            this.Contexto.Entry(participanteensinar).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
