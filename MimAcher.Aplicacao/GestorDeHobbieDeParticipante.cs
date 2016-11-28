using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;
using System;

namespace MimAcher.Aplicacao
{
    public class GestorDeHobbieDeParticipante
    {
        public RepositorioDePartipanteHobbie RepositorioDeParcipanteHobbie { get; set; }

        public GestorDeHobbieDeParticipante()
        {
            this.RepositorioDeParcipanteHobbie = new RepositorioDePartipanteHobbie();
        }

        public MA_PARTICIPANTE_HOBBIE ObterHobbieDoParticipantePorId(int id)
        {
            return this.RepositorioDeParcipanteHobbie.ObterHobbieDoParticipantePorId(id);
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistros()
        {
            return this.RepositorioDeParcipanteHobbie.ObterTodosOsRegistros();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsHobbiessDeParticipantePorPorItemPaginadosPorVinteRegistros(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            return this.ObterTodosOsHobbiessDeParticipantePorPorItemPaginadosPorVinteRegistros(participantehobbie);
        }

        public void InserirNovoParticipanteHobbie(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            this.RepositorioDeParcipanteHobbie.InserirNovoParticipanteHobbie(hobbieparticipante);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeParcipanteHobbie.BuscarQuantidadeRegistros();
        }

        public void RemoverHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbiedoparticipante)
        {
            this.RepositorioDeParcipanteHobbie.RemoverHobbieDoParticipante(hobbiedoparticipante);
        }

        public void AtualizarHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            this.RepositorioDeParcipanteHobbie.AtualizarHobbieDoParticipante(hobbieparticipante);
        }

        public Boolean AtualizarHobbieDoParticipanteComRetorno(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            return this.RepositorioDeParcipanteHobbie.AtualizarHobbieDoParticipanteComRetorno(hobbieparticipante);
        }

        public Boolean VerificarSeExisteRelacaoUsuarioHobbiePorIdDaRelacao(int id_usuarioahobbie)
        {
            if (ObterHobbieDoParticipantePorId(id_usuarioahobbie) != null)
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
