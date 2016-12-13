using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;
using System;
using MimAcher.Dominio.Model;
using System.Data.Entity;


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

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistrosAtivos()
        {
            return this.RepositorioDeParticipanteEnsinar.ObterTodosOsRegistrosAtivos();
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return this.RepositorioDeParticipanteEnsinar.ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(participanteensinar);
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(int id_item)
        {
            return this.RepositorioDeParticipanteEnsinar.ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(id_item);
        }

        public MA_PARTICIPANTE_ENSINAR ObterEnsinoDeParticipantePorItemEParticipante(int id_item, int id_participante)
        {
            return this.RepositorioDeParticipanteEnsinar.ObterEnsinoDeParticipantePorItemEParticipante(id_item, id_participante);
        }

        public List<RelacaoImpressao> ObterTodasAsRelacoesDeParticipanteEnsinarOrdenadoPorQuantidade()
        {
            List<MA_PARTICIPANTE_ENSINAR> listaparticipanteensinar = ObterTodosOsRegistros();
            List<RelacaoImpressao> listarelacaoimpressao = new List<RelacaoImpressao>();

            foreach(MA_PARTICIPANTE_ENSINAR pa in listaparticipanteensinar)
            {
                RelacaoImpressao relacaoimpressao = new RelacaoImpressao();

                //listaparticipanteensinar.wh
            }

            return listarelacaoimpressao;
        }

        public void InserirNovoEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.RepositorioDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipante(participanteensinar);
        }

        public Boolean InserirNovoEnsinamentoDeParticipanteComRetorno(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return this.RepositorioDeParticipanteEnsinar.InserirNovoEnsinamentoDeParticipanteComRetorno(participanteensinar);
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
            return this.RepositorioDeParticipanteEnsinar.AtualizarEnsinamentoDeParticipanteComRetorno(participanteensinar);
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

        public Boolean VerificarSeExisteRelacaoUsuarioEnsinarPorItemEParticipante(int id_item, int id_participante)
        {
            if(ObterEnsinoDeParticipantePorItemEParticipante(id_item, id_participante) != null)
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
