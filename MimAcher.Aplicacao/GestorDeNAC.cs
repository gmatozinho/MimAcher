using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeNac
    {
        public RepositorioDeNac RepositorioDeNac { get; set; }

        public GestorDeNac()
        {
            this.RepositorioDeNac = new RepositorioDeNac();
        }

        public MA_NAC ObterNacPorId(int id)
        {
            return this.RepositorioDeNac.ObterNacPorId(id);
        }

        public MA_NAC ObterNacPorIdDeUsuario(int idUsuario)
        {
            return this.RepositorioDeNac.ObterNacPorIdDeUsuario(idUsuario);
        }

        public MA_NAC ObterNacDeUsuarioAtivoPorId(int idUsuario)
        {
            return this.RepositorioDeNac.ObterNacDeUsuarioAtivoPorId(idUsuario);
        }

        public List<MA_NAC> ObterTodosOsNac()
        {
            return this.RepositorioDeNac.ObterTodosOsNac();
        }

        public List<MA_NAC> ObterTodosOsNacDeUsuariosAtivos()
        {
            return this.RepositorioDeNac.ObterTodosOsNacDeUsuariosAtivos();
        }

        public List<MA_NAC> ObterTodosOsNacPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.RepositorioDeNac.ObterTodosOsNacPorNomeDoRepresentante(nomerepresentante);
        }

        public void InserirNac(MA_NAC nac)
        {
            this.RepositorioDeNac.InserirNac(nac);
        }

        public Boolean InserirNacComRetorno(MA_NAC nac)
        {
            return this.RepositorioDeNac.InserirNacComRetorno(nac);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeNac.BuscarQuantidadeRegistros();
        }

        public void RemoverNac(MA_NAC nac)
        {
            this.RepositorioDeNac.RemoverNac(nac);
        }

        public void AtualizarNac(MA_NAC nac)
        {
            this.RepositorioDeNac.AtualizarNac(nac);
        }

        public Boolean AtualizarNacComRetorno(MA_NAC nac)
        {
            return this.RepositorioDeNac.AtualizarNacComRetorno(nac);
        }

        public Boolean VerificarSeParticipanteTemAlgumParticipanteComMesmoUsuario(MA_NAC nac)
        {
            return this.RepositorioDeNac.VerificarSeParticipanteTemAlgumParticipanteComMesmoUsuario(nac);
        }

        public Boolean VerificarSeNacTemAlgumParticipanteComMesmoUsuario(int idUsuario)
        {
            List<MA_NAC> listanac = ObterTodosOsNac();

            foreach (MA_NAC nac in listanac)
            {
                if (nac.cod_usuario == idUsuario)
                {
                    return true;
                }
            }

            return false;
        }

        public Boolean VerificarSeNacPorId(int idNac)
        {
            if(ObterNacPorId(idNac) != null)
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
