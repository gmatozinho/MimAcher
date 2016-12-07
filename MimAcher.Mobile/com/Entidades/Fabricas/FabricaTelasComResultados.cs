using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.com.Activities;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Mobile.com.Entidades.Fabricas
{
    public class FabricaTelasComResultados : ListActivity, IFabricaTelas
    {
        //Variaveis globais
        protected List<string> Items;
        protected Participante Participante;
        private static readonly Dictionary<int,string> Itens = CursorBd.ObterItens();

        public void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(HomeActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        public void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        //Checa qual item foi clicado
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var itemSelecionado = Items[position];
            var codItemSelecionado = RetornaCodItemLista(itemSelecionado);
            Mensagens.MensagemOpcoes(itemSelecionado,codItemSelecionado, this);
        }

        private static int RetornaCodItemLista(string itemInserido)
        {
            var codigoItem = -1;
            foreach (var itemChave in Itens)
            {
                if (itemChave.Value == itemInserido)
                {
                    codigoItem = itemChave.Key;
                }
            }

            return codigoItem;
        }

        internal void VerCombinacoes(int itemSelecionado, Context context)
        {
            var combinacoesactivity = new Intent(context, typeof(CombinacoesActivity));
            var tipocombinacao = context.GetType().ToString();
            combinacoesactivity.PutExtra("item", itemSelecionado);
            combinacoesactivity.PutExtra("tipocombinacao", tipocombinacao);
            StartActivity(combinacoesactivity);
            Toast.MakeText(this, "Voce está na tela de exibição de combinações", ToastLength.Short).Show();
        }

        internal void RemoverItemSelecionado(string itemSelecionado)
        {
            Items.Remove(itemSelecionado);
            Participante.Aprender.Conteudo = Items;
            IniciarHome(this, Participante);
        }

        public void IniciarQueroAprenderActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarQueroEnsinarActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarHobbies(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarMain(Context contexto)
        {
            throw new NotImplementedException();
        }

        public Task IniciarInscrever()
        {
            throw new NotImplementedException();
        }

        public void IniciarEscolherFoto(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }
    }
}