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
        private BuilderParticipante builderParticipante;
        private BuilderNac builderNac;
        private BuilderItem builderItem;
        private Usuario usuario;

        public DiretorGeradores()
        {
            builderParticipante = new BuilderParticipante();
            builderNac = new BuilderNac();
            builderItem = new BuilderItem();
        }


        public Usuario GerarParticipante()
        {
            Participante participante = builderParticipante.GerarParticipante();

            participante.Hobbies = builderItem.GerarListaItens(TipoUsuario.PARTICIPANTE);
            participante.Ensinar = builderItem.GerarListaItens(TipoUsuario.PARTICIPANTE);
            participante.Aprender = builderItem.GerarListaItens(TipoUsuario.PARTICIPANTE);

            return participante;
        }

        public Usuario GerarNac()
        {
            Nac nac = builderNac.GerarNac();

            return nac;
        }
    }
}
