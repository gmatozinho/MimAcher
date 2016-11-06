using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipanteAprender
    {
        public RepositorioDeAprendizadoDeParticipante RepositorioDeAprendizadoDeParticipante { get; set; }

        public GestorDeParticipanteAprender()
        {
            RepositorioDeAprendizadoDeParticipante = new RepositorioDeAprendizadoDeParticipante();
        }

        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDoParticipantePorId(int id)
        {
            return RepositorioDeAprendizadoDeParticipante.ObterAprendizadoDoParticipantePorId(id);
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsRegistros()
        {
            return RepositorioDeAprendizadoDeParticipante.ObterTodosOsRegistros();
        }

        public void InserirNovoAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            RepositorioDeAprendizadoDeParticipante.InserirNovoAprendizadoDeParticipante(participanteaprender);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeAprendizadoDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            RepositorioDeAprendizadoDeParticipante.RemoverAprendizadoDeParticipante(participanteaprender);
        }

        public void AtualizarAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            RepositorioDeAprendizadoDeParticipante.AtualizarAprendizadoDeParticipante(participanteaprender);
        }
    }

}
