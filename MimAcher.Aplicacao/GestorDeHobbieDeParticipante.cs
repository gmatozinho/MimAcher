using System.Collections.Generic;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeHobbieDeParticipante
    {
        public RepositorioDePartipanteHobbie RepositorioDeParcipanteHobbie { get; set; }

        public GestorDeHobbieDeParticipante()
        {
            RepositorioDeParcipanteHobbie = new RepositorioDePartipanteHobbie();
        }

        public MA_PARTICIPANTE_HOBBIE ObterHobbieDoParticipantePorId(int id)
        {
            return RepositorioDeParcipanteHobbie.ObterHobbieDoParticipantePorId(id);
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistros()
        {
            return RepositorioDeParcipanteHobbie.ObterTodosOsRegistros();
        }

        public void InserirNovoParticipanteHobbie(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            RepositorioDeParcipanteHobbie.InserirNovoParticipanteHobbie(hobbieparticipante);
        }

        public int BuscarQuantidadeRegistros()
        {
            return RepositorioDeParcipanteHobbie.BuscarQuantidadeRegistros();
        }

        public void RemoverHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbiedoparticipante)
        {
            RepositorioDeParcipanteHobbie.RemoverHobbieDoParticipante(hobbiedoparticipante);
        }

        public void AtualizarHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            RepositorioDeParcipanteHobbie.AtualizarHobbieDoParticipante(hobbieparticipante);
        }
    }
}
