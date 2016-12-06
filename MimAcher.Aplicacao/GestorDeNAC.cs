using System;
using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeNAC
    {
        public RepositorioDeNAC RepositorioDeNAC { get; set; }

        public GestorDeNAC()
        {
            this.RepositorioDeNAC = new RepositorioDeNAC();
        }

        public MA_NAC ObterNACPorId(int id)
        {
            return this.RepositorioDeNAC.ObterNACPorId(id);
        }

        public MA_NAC ObterNACPorIdDeUsuario(int idUsuario)
        {
            return this.RepositorioDeNAC.ObterNACPorIdDeUsuario(idUsuario);
        }

        public List<MA_NAC> ObterTodosOsNAC()
        {
            return this.RepositorioDeNAC.ObterTodosOsNAC();
        }

        public List<MA_NAC> ObterTodosOsNACPorNomeDoRepresentante(String nomerepresentante)
        {
            return this.RepositorioDeNAC.ObterTodosOsNACPorNomeDoRepresentante(nomerepresentante);
        }

        public void InserirNAC(MA_NAC nac)
        {
            this.RepositorioDeNAC.InserirNAC(nac);
        }

        public Boolean InserirNACComRetorno(MA_NAC nac)
        {
            return this.RepositorioDeNAC.InserirNACComRetorno(nac);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeNAC.BuscarQuantidadeRegistros();
        }

        public void RemoverNAC(MA_NAC nac)
        {
            this.RepositorioDeNAC.RemoverNAC(nac);
        }

        public void AtualizarNAC(MA_NAC nac)
        {
            this.RepositorioDeNAC.AtualizarNAC(nac);
        }

        public Boolean AtualizarNACComRetorno(MA_NAC nac)
        {
            return this.RepositorioDeNAC.AtualizarNACComRetorno(nac);
        }

        public Boolean VerificarSeParticipanteTemAlgumParticipanteComMesmoUsuario(MA_NAC nac)
        {
            return this.RepositorioDeNAC.VerificarSeParticipanteTemAlgumParticipanteComMesmoUsuario(nac);
        }

        public Boolean VerificarSeNACTemAlgumParticipanteComMesmoUsuario(int idUsuario)
        {
            List<MA_NAC> listanac = ObterTodosOsNAC();

            foreach (MA_NAC nac in listanac)
            {
                if (nac.cod_usuario == idUsuario)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
