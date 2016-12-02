using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;
using System;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipanteEnsinar
    {
        public RepositorioDeParticipanteEnsinar RepositorioDeParticipanteEnsinar { get; set; }

        public GestorDeParticipanteEnsinar()
        {
            this.RepositorioDeParticipanteEnsinar = new RepositorioDeParticipanteEnsinar();
        }

        public MA_PARTICIPANTE_ENSINAR ObterRelacaoDoQueOParticipanteEnsinaPorId(int id)
        {
            return this.RepositorioDeParticipanteEnsinar.ObterRelacaoDoQueOParticipanteEnsinaPorId(id);
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistros()
        {
            return this.RepositorioDeParticipanteEnsinar.ObterTodosOsRegistros();
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return this.ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(participanteensinar);
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(int id_item)
        {
            return this.ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(id_item);
        }

        public void InserirNovoEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.RepositorioDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipante(participanteensinar);
        }

        public Boolean InserirNovoEnsinamentoDeParticipanteComRetorno(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return this.InserirNovoEnsinamentoDeParticipanteComRetorno(participanteensinar);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeParticipanteEnsinar.BuscarQuantidadeRegistros();
        }

        public void RemoverEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.RepositorioDeParticipanteEnsinar.RemoverEnsinamentoDeParticipante(participanteensinar);
        }

        public void AtualizarEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.RepositorioDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipante(participanteensinar);
        }

        public Boolean AtualizarEnsinamentoDeParticipanteComRetorno(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return this.AtualizarEnsinamentoDeParticipanteComRetorno(participanteensinar);
        }

        public Boolean VerificarSeExisteRelacaoUsuarioEnsinarPorIdDaRelacao(int id_usuarioensinar)
        {
            if (ObterRelacaoDoQueOParticipanteEnsinaPorId(id_usuarioensinar) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean VerificarSeExisteAprendizadoDeParticipantePorIdDeItem(int id_item)
        {
            return this.RepositorioDeParticipanteEnsinar.VerificarSeExisteEnsinoDeParticipantePorIdDeItem(id_item);
        }
    }
}
