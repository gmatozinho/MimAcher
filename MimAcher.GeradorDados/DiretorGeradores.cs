using MimAcher.GeradorDados.Builders;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.GeradorDados
{
    public class DiretorGeradores
    {
        private readonly BuilderParticipante _builderParticipante;
        private readonly BuilderItem _builderItem;

        public DiretorGeradores()
        {
            _builderParticipante = new BuilderParticipante();
            _builderItem = new BuilderItem();
        }


        public Usuario GerarParticipante()
        {
            Participante participante = _builderParticipante.GerarParticipante();

            if (_builderItem != null)
            {
                participante.Hobbies = _builderItem.GerarListaItens();
                participante.Ensinar = _builderItem.GerarListaItens();
                participante.Aprender = _builderItem.GerarListaItens();
            }

            return participante;
        }
    }
}
