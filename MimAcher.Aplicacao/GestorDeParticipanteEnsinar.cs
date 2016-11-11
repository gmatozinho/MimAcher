using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipanteEnsinar
    {
        public RepositorioDeParticipanteEnsinar RepositorioDeParticipanteEnsinar { get; set; }

        public GestorDeParticipanteEnsinar()
        {
            RepositorioDeParticipanteEnsinar = new RepositorioDeParticipanteEnsinar();
        }

        public MA_PARTICIPANTE_ENSINAR ObterRelacaoDoQueOParticipanteEnsinaPorId(int id)
        {
            return RepositorioDeParticipanteEnsinar.ObterRelacaoDoQueOParticipanteEnsinaPorId(id);
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistros()
        {
            return RepositorioDeParticipanteEnsinar.ObterTodosOsRegistros();
        }

        public void InserirNovoEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            RepositorioDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipante(participanteensinar);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeParticipanteEnsinar.BuscarQuantidadeRegistros();
        }

        public void RemoverEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            RepositorioDeParticipanteEnsinar.RemoverEnsinamentoDeParticipante(participanteensinar);
        }

        public void AtualizarEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            RepositorioDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipante(participanteensinar);
        }
    }
}
