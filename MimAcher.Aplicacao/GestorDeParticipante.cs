using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipante
    {
        public RepositorioDeParticipante RepositorioDeParticipante { get; set; }

        public GestorDeParticipante()
        {
            RepositorioDeParticipante = new RepositorioDeParticipante();
        }

        public int ObterIdDeUltimoParticipante()
        {
            return RepositorioDeParticipante.ObterIdDeUltimoParticipante();
        }

        public MA_PARTICIPANTE ObterParticipantePorId(int id)
        {
            return RepositorioDeParticipante.ObterParticipantePorId(id);
        }

        public MA_PARTICIPANTE ObterParticipantePorIdDeUsuario(int idUsuario)
        {
            return RepositorioDeParticipante.ObterParticipantePorIdDeUsuario(idUsuario);
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantes()
        {            
            return RepositorioDeParticipante.ObterTodosOsParticipantes();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantesPorNome(String nome)
        {
            return RepositorioDeParticipante.ObterTodosOsParticipantesPorNome(nome);
        }

        public MA_PARTICIPANTE ObterParticipantePorEmail(String email)
        {
            return RepositorioDeParticipante.ObterParticipantePorEmail(email);
        }

        public void InserirParticipante(MA_PARTICIPANTE participante)
        {
            RepositorioDeParticipante.InserirParticipante(participante);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverParticipante(MA_PARTICIPANTE participante)
        {
            RepositorioDeParticipante.RemoverParticipante(participante);
        }

        public void AtualizarParticipante(MA_PARTICIPANTE participante)
        {
            RepositorioDeParticipante.AtualizarParticipante(participante);
        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumParticipante(MA_PARTICIPANTE participante)
        {
            return RepositorioDeParticipante.VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante);
        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumParticipante(int idUsuario)
        {
            List<MA_PARTICIPANTE> listaparticipante = ObterTodosOsParticipantes();
            
            foreach(MA_PARTICIPANTE participante in listaparticipante)
            {
                if (participante.cod_usuario == idUsuario)
                {
                    return true;
                }
            }
            return false;
        }
    }
}