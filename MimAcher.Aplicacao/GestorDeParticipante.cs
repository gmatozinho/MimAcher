﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeParticipante
    {
        public RepositorioDeParticipante RepositorioDeParticipante { get; set; }

        public GestorDeParticipante()
        {
            this.RepositorioDeParticipante = new RepositorioDeParticipante();
        }
        
        public MA_PARTICIPANTE ObterParticipantePorId(int id)
        {
            return this.RepositorioDeParticipante.ObterParticipantePorId(id);
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantes()
        {
            return this.RepositorioDeParticipante.ObterTodosOsParticipantes();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantesPorNome(String nome)
        {
            return this.RepositorioDeParticipante.ObterTodosOsParticipantesPorNome(nome);
        }

        public MA_PARTICIPANTE ObterParticipantePorEmail(String email)
        {
            return this.RepositorioDeParticipante.ObterParticipantePorEmail(email);
        }

        public void InserirParticipante(MA_PARTICIPANTE participante)
        {
            this.RepositorioDeParticipante.InserirParticipante(participante);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeParticipante.BuscarQuantidadeRegistros();
        }

        public void RemoverParticipante(MA_PARTICIPANTE participante)
        {
            this.RepositorioDeParticipante.RemoverParticipante(participante);
        }

        public void AtualizarParticipante(MA_PARTICIPANTE participante)
        {
            this.RepositorioDeParticipante.AtualizarParticipante(participante);
        }
    }
}