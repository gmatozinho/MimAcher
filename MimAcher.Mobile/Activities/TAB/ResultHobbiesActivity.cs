using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Activities.TAB
{
    [Activity(Label = "Gostos", Theme = "@style/Theme.Splash")]
    public class ResultHobbiesActivity : ListActivity
    {
        //Variaveis globais
        private List<string> _items;
        private Bundle _participanteBundle;

        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo e transformando o bundle(Objeto participante)
            _participanteBundle = Intent.GetBundleExtra("member");
            var participante = Participante.BundleToParticipante(_participanteBundle);

            //Listagem dos Hobbies
            _items = participante.Hobbies.Conteudo;
            ListAdapter = new ListAdapterHae(this, _items);

        }

        //Checa qual item foi clicado
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = _items[position];
            Toast.MakeText(this, t, ToastLength.Short).Show();
        }
    }
}