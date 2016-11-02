using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;
using MimAcher.Dominio;

namespace MimAcher.Aplicacao
{
    public class GestorDeHobbieDeParticipante
    {
        public RepositorioDePartipanteHobbie RepositorioDeParcipanteHobbie { get; set; }

        public GestorDeHobbieDeParticipante()
        {
            this.RepositorioDeParcipanteHobbie = new RepositorioDePartipanteHobbie();
        }

        public MA_PARTICIPANTE_HOBBIE ObterHobbieDoParticipantePorId(int id)
        {
            return this.RepositorioDeParcipanteHobbie.ObterHobbieDoParticipantePorId(id);
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistros()
        {
            return this.RepositorioDeParcipanteHobbie.ObterTodosOsRegistros();
        }

        public void InserirNovoParticipanteHobbie(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            this.RepositorioDeParcipanteHobbie.InserirNovoParticipanteHobbie(hobbieparticipante);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeParcipanteHobbie.BuscarQuantidadeRegistros();
        }

        public void RemoverHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbiedoparticipante)
        {
            this.RepositorioDeParcipanteHobbie.RemoverHobbieDoParticipante(hobbiedoparticipante);
        }

        public void AtualizarHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            this.RepositorioDeParcipanteHobbie.AtualizarHobbieDoParticipante(hobbieparticipante);
        }
    }
}
