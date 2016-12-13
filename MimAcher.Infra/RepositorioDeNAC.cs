using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeNac
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeNac()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_NAC ObterNacPorId(int id)
        {
            return this.Contexto.MA_NAC.Find(id);
        }

        public MA_NAC ObterNacDeUsuarioAtivoPorId(int id)
        {
            return this.Contexto.MA_NAC.Where(l => l.cod_nac == id && l.MA_USUARIO.cod_status == 1).SingleOrDefault();
        }

        public MA_NAC ObterNacPorIdDeUsuario(int idUsuario)
        {
            return this.Contexto.MA_NAC.SingleOrDefault(l => l.MA_USUARIO.cod_usuario == idUsuario);
        }

        public List<MA_NAC> ObterTodosOsNac()
        {
            return this.Contexto.MA_NAC.ToList();
        }

        public List<MA_NAC> ObterTodosOsNacDeUsuariosAtivos()
        {
            return this.Contexto.MA_NAC.Where(l => l.MA_USUARIO.cod_status == 1).ToList();
        }

        public List<MA_NAC> ObterTodosOsNacPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.Contexto.MA_NAC.Where(l => l.nome_representante.Equals(nomerepresentante)).ToList();
        }

        public void InserirNac(MA_NAC nac)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumNac(nac))
            {
                this.Contexto.MA_NAC.Add(nac);
                this.Contexto.SaveChanges();
            }
        }

        public Boolean InserirNacComRetorno(MA_NAC nac)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumNac(nac))
            {
                try
                {
                    this.Contexto.MA_NAC.Add(nac);
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
                return false;
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_NAC.Count();
        }

        public void RemoverNac(MA_NAC nac)
        {
            this.Contexto.MA_NAC.Remove(nac);
            this.Contexto.SaveChanges();
        }

        public void AtualizarNac(MA_NAC nac)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumNac(nac))
            {
                if (!VerificarSeUsuarioJaTemVinculoComAlgumNac(nac))
                {
                    this.Contexto.Entry(nac).State = EntityState.Modified;
                    this.Contexto.SaveChanges();
                }
            }
            else
            {
                MA_NAC nacjaexistente = ObterNacPorIdDeUsuario(nac.cod_usuario);

                if (nacjaexistente.nome_representante.ToLowerInvariant().Equals(nac.nome_representante.ToLowerInvariant()) && !VerificarSeUsuarioJaTemVinculoComAlgumNac(nac))
                {
                    this.Contexto.Entry(nac).State = EntityState.Modified;
                    this.Contexto.SaveChanges();
                }
            }
        }

        public Boolean AtualizarNacComRetorno(MA_NAC nac)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumNac(nac))
            {
                if (!VerificarSeUsuarioJaTemVinculoComAlgumNac(nac))
                {
                    try
                    {
                        this.Contexto.Entry(nac).State = EntityState.Modified;
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
                    return false;
                }
            }
            else
            {
                MA_NAC nacjaexistente = ObterNacPorIdDeUsuario(nac.cod_usuario);

                if (nacjaexistente.nome_representante.ToLowerInvariant().Equals(nac.nome_representante.ToLowerInvariant()) && !VerificarSeUsuarioJaTemVinculoComAlgumNac(nac))
                {
                    try
                    {
                        this.Contexto.Entry(nac).State = EntityState.Modified;
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
                    return false;
                }
            }
        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumNac(MA_NAC nac)
        {
            if (ObterNacPorIdDeUsuario(nac.cod_usuario) != null)
            {
                return true;
            }
            return false;
        }

        public Boolean VerificarSeParticipanteTemAlgumParticipanteComMesmoUsuario(MA_NAC nac)
        {
            if (this.Contexto.MA_PARTICIPANTE.Where(l => l.cod_usuario == nac.cod_usuario).SingleOrDefault() != null)
            {
                return true;
            }
            return false;
        }

    }
}
