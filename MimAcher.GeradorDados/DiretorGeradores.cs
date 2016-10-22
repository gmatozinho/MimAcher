using MimAcher.Entidades;
using MimAcher.GeradorDados.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.GeradorDados
{
    public class DiretorGeradores
    {
        private readonly BuilderParticipante builderParticipante;
        private readonly BuilderItem builderItem;

        public DiretorGeradores()
        {
            builderParticipante = new BuilderParticipante();
            builderItem = new BuilderItem();
        }


        public Usuario GerarParticipante()
        {
            Participante participante = builderParticipante.GerarParticipante();

            participante.Hobbies = builderItem.GerarListaItens();
            participante.Ensinar = builderItem.GerarListaItens();
            participante.Aprender = builderItem.GerarListaItens();

            return participante;
        }
    }
}
