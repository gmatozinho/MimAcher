﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeParticipante
    {
        public MIMACHEREntities Contexto { get; set; }
        
        public RepositorioDeParticipante()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE ObterParticipantePorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE.Find(id);
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantes()
        {
            return this.Contexto.MA_PARTICIPANTE.ToList();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantesPorNome(String nome)
        {
            return this.Contexto.MA_PARTICIPANTE.Where(l => l.nome.Equals(nome)).ToList();            
        }

        public MA_PARTICIPANTE ObterParticipantePorEmail(String email)
        {
            return this.Contexto.MA_PARTICIPANTE.Where(l => l.MA_USUARIO.e_mail.Equals(email)).SingleOrDefault();
        }
        
        public void InserirParticipante(MA_PARTICIPANTE Participante)
        {            
            this.Contexto.MA_PARTICIPANTE.Add(Participante);
            this.Contexto.SaveChanges();         
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE.Count();
        }
                
        public void RemoverParticipante(MA_PARTICIPANTE Participante)
        {
            this.Contexto.MA_PARTICIPANTE.Remove(Participante);
            this.Contexto.SaveChanges();
        }

        public void AtualizarParticipante(MA_PARTICIPANTE Participante)
        {            
            this.Contexto.Entry(Participante).State = EntityState.Modified;
            this.Contexto.SaveChanges();            
        }
    }
}