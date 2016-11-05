using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;
using MimAcher.Dominio;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipanteAprender
    {
        public RepositorioDeAprendizadoDeParticipante RepositorioDeAprendizadoDeParticipante { get; set; }

        public GestorDeParticipanteAprender()
        {
            this.RepositorioDeAprendizadoDeParticipante = new RepositorioDeAprendizadoDeParticipante();
        }

        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDoParticipantePorId(int id)
        {
            return this.RepositorioDeAprendizadoDeParticipante.ObterAprendizadoDoParticipantePorId(id);
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsRegistros()
        {
            return this.RepositorioDeAprendizadoDeParticipante.ObterTodosOsRegistros();
        }

        public void InserirNovoAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.RepositorioDeAprendizadoDeParticipante.InserirNovoAprendizadoDeParticipante(participanteaprender);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAprendizadoDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.RepositorioDeAprendizadoDeParticipante.RemoverAprendizadoDeParticipante(participanteaprender);
        }

        public void AtualizarAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.RepositorioDeAprendizadoDeParticipante.AtualizarAprendizadoDeParticipante(participanteaprender);
        }
    }

}
