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

        public MA_PARTICIPANTE ObterUsuarioAtivoDeParticipantePorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE.Where(l => l.cod_participante == id && l.MA_USUARIO.cod_status == 1).SingleOrDefault();
        }

        public MA_PARTICIPANTE ObterParticipantePorIdDeUsuario(int idUsuario)
        {
            return this.Contexto.MA_PARTICIPANTE.Where(l => l.MA_USUARIO.cod_usuario == idUsuario).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantes()
        {
            return this.Contexto.MA_PARTICIPANTE.ToList();
        }

        public List<MA_PARTICIPANTE> ObterTodosOsParticipantesDeUsuariosAtivos()
        {
            return this.Contexto.MA_PARTICIPANTE.Where(l => l.MA_USUARIO.cod_status == 1).ToList();
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
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante) && !VerificarSeNacTemAlgumNacComMesmoUsuario(participante))
            {
                this.Contexto.MA_PARTICIPANTE.Add(participante);
                this.Contexto.SaveChanges();
            }
        }

        public Boolean InserirParticipanteComRetorno(MA_PARTICIPANTE participante)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante) && !VerificarSeNacTemAlgumNacComMesmoUsuario(participante))
            {
                try
                {
                    this.Contexto.MA_PARTICIPANTE.Add(participante);
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception)
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

        public void RemoverParticipante(MA_PARTICIPANTE participante)
        {
            this.Contexto.MA_PARTICIPANTE.Remove(participante);
            this.Contexto.SaveChanges();
        }

        public void AtualizarParticipante(MA_PARTICIPANTE participante)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante))
            {
                if (!VerificarSeNacTemAlgumNacComMesmoUsuario(participante))
                {
                    Atualizar(participante);
                }
            }
            else
            {
                MA_PARTICIPANTE participantejaexistente = ObterParticipantePorIdDeUsuario(participante.cod_usuario);

                if (participantejaexistente.cod_participante == participante.cod_participante && !VerificarSeNacTemAlgumNacComMesmoUsuario(participante))
                {
                    Atualizar(participante);
                }
            }
        }

        public Boolean AtualizarParticipanteComRetorno(MA_PARTICIPANTE participante)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumParticipante(participante))
            {
                if (!VerificarSeNacTemAlgumNacComMesmoUsuario(participante))
                {
                    try
                    {
                        Atualizar(participante);

                        return true;
                    }
                    catch(Exception)
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

                    if (participantejaexistente.cod_participante == participante.cod_participante && !VerificarSeNacTemAlgumNacComMesmoUsuario(participante))
                    {
                        try
                        {
                            Atualizar(participante);

                            return true;
                        }
                        catch(Exception)
                        {
                            return false;
                        }
                        
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception)
                {
                    return false;
                }                
            }
        }

        public void Atualizar(MA_PARTICIPANTE participante)
        {
            MIMACHEREntities contexto = new MIMACHEREntities();

            try
            {
                contexto.Entry(participante).State = EntityState.Modified;
                contexto.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Boolean VerificarSeParticipanteExiste(int codParticipante)
        {
            if(ObterParticipantePorId(codParticipante) != null)
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

        public Boolean VerificarSeNacTemAlgumNacComMesmoUsuario(MA_PARTICIPANTE participante)
        {
            if (this.Contexto.MA_NAC.Where(l => l.cod_usuario == participante.cod_usuario).SingleOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
