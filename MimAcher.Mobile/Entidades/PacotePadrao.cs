using Android.Widget;
using MimAcher.Mobile.Services;

namespace MimAcher.Mobile.Entidades
{
    public class PacotePadrao : Pacote
    {
        //Properties
        public ListaItens ListaItens { get; set; }

        public Participante Participante { get; set; }

        public ListView ListView { get; set; }

        //Construtor
        public PacotePadrao(ListaItens listaItens, Participante participante, ListView listView)
        {
            ListaItens = listaItens;
            Participante = participante;
            ListView = listView;
        }
    }
}