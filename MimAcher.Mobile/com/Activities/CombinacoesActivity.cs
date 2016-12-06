using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Widget;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "Combinacoes", Theme = "@style/Theme.Splash")]
    public class CombinacoesActivity : ListActivity
    {
        private readonly ListaItens _combinacoes = new ListaItens();
        private ListView _listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //tenho q receber o item para gerar as combinações a serem geradas
            var codItem = Intent.GetIntExtra("item",0);
            //var participanteBundle = Intent.GetBundleExtra("member");
            //Participante = Participante.BundleToParticipante(participanteBundle);

            var itens = CursorBd.ObterItens();
            if (codItem == 0)
            {
                const string toast = ("Error");
                Toast.MakeText(this, toast, ToastLength.Long).Show();
            }
            var itemSelecionado = itens[codItem];

            var combinacoes = CursorBd.Match(codItem);
            var hobbie = combinacoes["hobbie"];
            //Items = combinacoes.Itens
            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Combinacoes);

            //Iniciando as variaveis do contexto
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            _listView = FindViewById<ListView>(Resource.Id.list);

            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.SetTitle(Resource.String.TitleCombinacoes);
            ActionBar.SetSubtitle(Resource.String.TitleAprender);

            //Recebendo e transformando o bundle(Objeto participante)
            //TODO tenho que pegar o item, e trazer o resultado do match para listar
            

            //TODO Listagem das combinações            
            //Items = Participante.Aprender.Conteudo;
            _listView.Adapter = new ListAdapterHae(this, Items);
            // Create your application here
        }
    }
}