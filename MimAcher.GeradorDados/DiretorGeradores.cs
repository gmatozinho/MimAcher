using MimAcher.GeradorDados.Builders;
using MimAcher.Mobile.Entidades;

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

            if (builderItem != null)
            {
                participante.Hobbies = builderItem.GerarListaItens();
                participante.Ensinar = builderItem.GerarListaItens();
                participante.Aprender = builderItem.GerarListaItens();
            }

            return participante;
        }
    }
}
