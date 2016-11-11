using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeParticipante
    {
        public MIMACHEREntities Contexto { get; set; }
        
        public RepositorioDeParticipante()
        {
            Contexto = new MIMACHEREntities();
        }

        public int ObterIdDeUltimoParticipante()
        {
            return Contexto.MA_PARTICIPANTE.Max(l => l.cod_participante);
        }

        public MA_PARTICIPANTE ObterParticipantePorId(int id)
        {
            return Contexto.MA_PARTICIPANTE.Find(id);
        }

        public MA_PARTICIPANTE ObterParticipantePorIdDeUsuario(int idUsuario)
        {
            return Contexto.MA_PARTICIPANTE.Where(l => l.MA_USUARIO.cod_usuario == idUsuario).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantes()
        {
            return Contexto.MA_PARTICIPANTE.ToList();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantesPorNome(String nome)
        {
            return Contexto.MA_PARTICIPANTE.Where(l => l.nome.Equals(nome)).ToList();            
        }

        public MA_PARTICIPANTE ObterParticipantePorEmail(String email)
        {
            return Contexto.MA_PARTICIPANTE.Where(l => l.MA_USUARIO.e_mail.Equals(email)).SingleOrDefault();
        }
        
        public void InserirParticipante(MA_PARTICIPANTE participante)
        {
            if(!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante) && !VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
            {                
                Contexto.MA_PARTICIPANTE.Add(participante);
                Contexto.SaveChanges();             
            }
        }

        
        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_PARTICIPANTE.Count();
        }
                
        public void RemoverParticipante(MA_PARTICIPANTE Participante)
        {
            Contexto.MA_PARTICIPANTE.Remove(Participante);
            Contexto.SaveChanges();
        }

        public void AtualizarParticipante(MA_PARTICIPANTE participante)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante))
            {
                if (!VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
                {
                    MA_PARTICIPANTE participantegravacao = new MA_PARTICIPANTE();

                    participantegravacao.cod_participante = participante.cod_participante;
                    participantegravacao.cod_campus = participante.cod_campus;
                    participantegravacao.cod_usuario = participante.cod_usuario;
                    participantegravacao.dt_nascimento = participante.dt_nascimento;
                    participantegravacao.nome = participante.nome;
                    participantegravacao.telefone = participante.telefone;
                    participantegravacao.geolocalizacao = participante.geolocalizacao;

                    Atualizar(participantegravacao);
                }
            }
            else
            {
                MA_PARTICIPANTE participantejaexistente = ObterParticipantePorIdDeUsuario(participante.cod_usuario);

                if (participantejaexistente.cod_participante == participante.cod_participante && !VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
                {
                        MA_PARTICIPANTE participantegravacao = new MA_PARTICIPANTE();
                        participantegravacao.cod_participante = participante.cod_participante;
                        participantegravacao.cod_campus = participante.cod_campus;
                        participantegravacao.cod_usuario = participante.cod_usuario;
                        participantegravacao.dt_nascimento = participante.dt_nascimento;
                        participantegravacao.nome = participante.nome;
                        participantegravacao.telefone = participante.telefone;
                        participantegravacao.geolocalizacao = participante.geolocalizacao;

                        Atualizar(participantegravacao);                 
                }
            }
        }

        public void Atualizar(MA_PARTICIPANTE participante)
        {
            MIMACHEREntities ContextoModificado = new MIMACHEREntities();

            ContextoModificado.Entry(participante).State = EntityState.Modified;
            ContextoModificado.SaveChanges();

        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumParticipante(MA_PARTICIPANTE participante)
        {
            if (ObterParticipantePorIdDeUsuario(participante.cod_usuario) != null) {
                return true;
            }
            return false;
        }

        public Boolean VerificarSeNACTemAlgumNACComMesmoUsuario(MA_PARTICIPANTE participante)
        {
            if (Contexto.MA_NAC.Where(l => l.cod_usuario == participante.cod_usuario).SingleOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
