using System;
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

        public int ObterIdDeUltimoParticipante()
        {
            return this.Contexto.MA_PARTICIPANTE.Max(l => l.cod_participante);
        }

        public MA_PARTICIPANTE ObterParticipantePorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE.Find(id);
        }

        public MA_PARTICIPANTE ObterParticipantePorIdDeUsuario(int idUsuario)
        {
            return this.Contexto.MA_PARTICIPANTE.Where(l => l.MA_USUARIO.cod_usuario == idUsuario).SingleOrDefault();
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
        
        public void InserirParticipante(MA_PARTICIPANTE participante)
        {
            if(!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante))
            {
                if (!VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
                {
                    this.Contexto.MA_PARTICIPANTE.Add(participante);
                    this.Contexto.SaveChanges();
                }
            }
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

        public void AtualizarParticipante(MA_PARTICIPANTE participante)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante))
            {
                if (!VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
                {
                    this.Contexto.Entry(participante).State = EntityState.Modified;
                    this.Contexto.SaveChanges();
                }
            }
            else
            {
                MA_PARTICIPANTE participantejaexistente = ObterParticipantePorIdDeUsuario(participante.cod_usuario);

                if (!participantejaexistente.nome.ToLower().Equals(participante.nome.ToLower()))
                {
                    if (!VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
                    {
                        this.Contexto.Entry(participante).State = EntityState.Modified;
                        this.Contexto.SaveChanges();
                    }
                }
            }
        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumParticipante(MA_PARTICIPANTE participante)
        {
            if (ObterParticipantePorIdDeUsuario(participante.cod_usuario) != null) {
                return true;
            }
            else{
                return false;
            }
        }

        public Boolean VerificarSeNACTemAlgumNACComMesmoUsuario(MA_PARTICIPANTE participante)
        {
            if (this.Contexto.MA_PARTICIPANTE.Where(l => l.cod_usuario == participante.cod_usuario) != null)
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
