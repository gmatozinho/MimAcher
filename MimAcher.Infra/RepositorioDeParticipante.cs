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
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante) && !VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
            {
                this.Contexto.MA_PARTICIPANTE.Add(participante);
                this.Contexto.SaveChanges();
            }
        }

        public Boolean InserirParticipanteComRetorno(MA_PARTICIPANTE participante)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante) && !VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
            {
                try
                {
                    this.Contexto.MA_PARTICIPANTE.Add(participante);
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
            }
            else
            {
                return true;
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
                    Atualizar(participante);
                }
            }
            else
            {
                MA_PARTICIPANTE participantejaexistente = ObterParticipantePorIdDeUsuario(participante.cod_usuario);

                if (participantejaexistente.cod_participante == participante.cod_participante && !VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
                {
                    Atualizar(participante);
                }
            }
        }

        public Boolean AtualizarParticipanteComRetorno(MA_PARTICIPANTE participante)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante))
            {
                if (!VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
                {
                    try
                    {
                        Atualizar(participante);

                        return true;
                    }
                    catch(Exception e)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    MA_PARTICIPANTE participantejaexistente = ObterParticipantePorIdDeUsuario(participante.cod_usuario);

                    if (participantejaexistente.cod_participante == participante.cod_participante && !VerificarSeNACTemAlgumNACComMesmoUsuario(participante))
                    {
                        try
                        {
                            Atualizar(participante);

                            return true;
                        }
                        catch(Exception e)
                        {
                            return false;
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception e)
                {
                    return false;
                }                
            }
        }

        public void Atualizar(MA_PARTICIPANTE participante)
        {
            MIMACHEREntities Contexto = new MIMACHEREntities();

            try
            {
                Contexto.Entry(participante).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Boolean VerificarSeParticipanteExiste(int cod_participante)
        {
            if(ObterParticipantePorId(cod_participante) != null)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumParticipante(MA_PARTICIPANTE participante)
        {
            if (ObterParticipantePorIdDeUsuario(participante.cod_usuario) != null)
            {
                return true;
            }
            return false;
        }

        public Boolean VerificarSeNACTemAlgumNACComMesmoUsuario(MA_PARTICIPANTE participante)
        {
            if (this.Contexto.MA_NAC.Where(l => l.cod_usuario == participante.cod_usuario).SingleOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
