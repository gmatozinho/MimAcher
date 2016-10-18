using Android.Widget;

namespace MimAcher.Mobile.Entidades
{
    public class PacoteCompleto : PacoteAbstrato
    {
        //Properties
        public ListaItens ListaItens { get; set; }

        public Participante Participante { get; set; }

        public ListView ListView { get; set; }

        //Construtor
        public PacoteCompleto(ListaItens listaItens, Participante participante, ListView listView)
        {
            ListaItens = listaItens;
            Participante = participante;
            ListView = listView;
        }
    }
}