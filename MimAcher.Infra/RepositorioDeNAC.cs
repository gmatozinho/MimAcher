using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeNAC
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeNAC()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_NAC ObterNACPorId(int id)
        {
            return this.Contexto.MA_NAC.Find(id);
        }

        public MA_NAC ObterNACPorIdDeUsuario(int idUsuario)
        {
            return this.Contexto.MA_NAC.SingleOrDefault(l => l.MA_USUARIO.cod_usuario == idUsuario);
        }
        
        public List<MA_NAC> ObterTodosOsNAC()
        {
            return this.Contexto.MA_NAC.ToList();
        }

        public List<MA_NAC> ObterTodosOsNACPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.Contexto.MA_NAC.Where(l => l.nome_representante.Equals(nomerepresentante)).ToList();
        }
        
        public void InserirNAC(MA_NAC nac)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumNAC(nac))
            {
                this.Contexto.MA_NAC.Add(nac);
                this.Contexto.SaveChanges();             
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_NAC.Count();
        }

        public void RemoverNAC(MA_NAC nac)
        {
            this.Contexto.MA_NAC.Remove(nac);
            this.Contexto.SaveChanges();
        }

        public void AtualizarNAC(MA_NAC nac)
        {
            if (!VerificarSeUsuarioJaTemVinculoComAlgumNAC(nac))
            {
                if (!VerificarSeUsuarioJaTemVinculoComAlgumNAC(nac))
                {
                    this.Contexto.Entry(nac).State = EntityState.Modified;
                    this.Contexto.SaveChanges();
                }
            }
            else
            {
                MA_NAC nacjaexistente = ObterNACPorIdDeUsuario(nac.cod_usuario);

                if (nacjaexistente.nome_representante.ToLowerInvariant().Equals(nac.nome_representante.ToLowerInvariant()) && !VerificarSeUsuarioJaTemVinculoComAlgumNAC(nac))
                {
                    this.Contexto.Entry(nac).State = EntityState.Modified;
                    this.Contexto.SaveChanges();                 
                }
            }
        }

        public Boolean VerificarSeUsuarioJaTemVinculoComAlgumNAC(MA_NAC nac)
        {
            if (ObterNACPorIdDeUsuario(nac.cod_usuario) != null)
            {
                return true;
            }
            return false;
        }

        public Boolean VerificarSeParticipanteTemAlgumParticipanteComMesmoUsuario(MA_NAC nac)
        {
            if(this.Contexto.MA_PARTICIPANTE.Where(l => l.cod_usuario == nac.cod_usuario).SingleOrDefault() !=  null)
            {
                return true;
            }
            return false;
        }
        
    }
}
