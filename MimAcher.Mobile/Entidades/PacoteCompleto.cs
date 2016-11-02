using Android.Widget;

namespace MimAcher.Mobile.Entidades
{
    public class PacoteCompleto : PacoteAbstrato
    {
        //Properties
        public ListaItens ListaItens { get; private set; }

        public Participante Participante { get; private set; }

        public ListView ListView { get; private set; }

        //Construtor
        public PacoteCompleto(ListaItens listaItens, Participante participante, ListView listView)
        {
            ListaItens = listaItens;
            Participante = participante;
            ListView = listView;
        }
    }
}