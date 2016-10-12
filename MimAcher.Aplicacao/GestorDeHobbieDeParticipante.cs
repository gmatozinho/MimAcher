using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeHobbieDeParticipante
    {
        public RepositorioDePartipanteHobbie RepositorioDeGostoDeAluno { get; set; }

        public GestorDeHobbieDeParticipante()
        {
            this.RepositorioDeGostoDeAluno = new RepositorioDePartipanteHobbie();
        }

        public MA_PARTICIPANTE_HOBBIE ObterHobbieDoParticipantePorId(int id)
        {
            return this.RepositorioDeGostoDeAluno.ObterHobbieDoParticipantePorId(id);
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistros()
        {
            return this.RepositorioDeGostoDeAluno.ObterTodosOsRegistros();
        }

        public void InserirNovoParticipanteHobbie(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            this.RepositorioDeGostoDeAluno.InserirNovoParticipanteHobbie(hobbieparticipante);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeGostoDeAluno.BuscarQuantidadeRegistros();
        }

        public void RemoverHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbiedoparticipante)
        {
            this.RepositorioDeGostoDeAluno.RemoverHobbieDoParticipante(hobbiedoparticipante);
        }

        public void AtualizarHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            this.RepositorioDeGostoDeAluno.AtualizarHobbieDoParticipante(hobbieparticipante);
        }
    }
}
