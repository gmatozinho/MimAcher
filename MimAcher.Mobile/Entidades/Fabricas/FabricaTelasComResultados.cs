using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Activities;
using MimAcher.Mobile.Utilitarios;

namespace MimAcher.Mobile.Entidades.Fabricas
{
    public class FabricaTelasComResultados : ListActivity, IFabricaTelas
    {
        //Variaveis globais
        protected List<string> Items;
        protected Participante Participante;

        private void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(HomeActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        private void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        //Checa qual item foi clicado
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var itemSelecionado = Items[position];
            //Toast.MakeText(this, itemSelecionado, ToastLength.Short).Show();
            Mensagens.MensagemOpcoes(itemSelecionado,this);
        }

        internal void VerCombinacoes(string itemSelecionado)
        {
            //TODO pesquisar o item no banco, buscando as combinações
            Toast.MakeText(this, "Voce está na tela de exibição de combinações", ToastLength.Short).Show();
        }

        internal void RemoverItemSelecionado(string itemSelecionado)
        {
            Items.Remove(itemSelecionado);
            Participante.Aprender.Conteudo = Items;
            IniciarHome(this, Participante);
        }

    }
}