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
            RepositorioDeNAC = new RepositorioDeNAC();
        }

        public MA_NAC ObterNACPorId(int id)
        {
            return RepositorioDeNAC.ObterNACPorId(id);
        }

        public MA_NAC ObterNACPorIdDeUsuario(int idUsuario)
        {
            return RepositorioDeNAC.ObterNACPorIdDeUsuario(idUsuario);
        }

        public List<MA_NAC> ObterTodosOsNAC()
        {
            return RepositorioDeNAC.ObterTodosOsNAC();
        }

        public List<MA_NAC> ObterTodosOsNACPorNomeDoRepresentante(String nomerepresentante)
        {
            return RepositorioDeNAC.ObterTodosOsNACPorNomeDoRepresentante(nomerepresentante);
        }
        
        public void InserirNAC(MA_NAC nac)
        {
            RepositorioDeNAC.InserirNAC(nac);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeNAC.BuscarQuantidadeRegistros();
        }

        public void RemoverNAC(MA_NAC nac)
        {
            RepositorioDeNAC.RemoverNAC(nac);
        }

        public void AtualizarNAC(MA_NAC nac)
        {
            RepositorioDeNAC.AtualizarNAC(nac);
        }

        public Boolean VerificarSeParticipanteTemAlgumParticipanteComMesmoUsuario(MA_NAC nac)
        {
            return RepositorioDeNAC.VerificarSeParticipanteTemAlgumParticipanteComMesmoUsuario(nac);
        }

        public Boolean VerificarSeNACTemAlgumParticipanteComMesmoUsuario(int idUsuario)
        {
            List<MA_NAC> listanac = ObterTodosOsNAC();

            foreach(MA_NAC nac in listanac)
            {
                if(nac.cod_usuario == idUsuario)
                {
                    return true;
                }
            }

            return false;        }
    }
}
