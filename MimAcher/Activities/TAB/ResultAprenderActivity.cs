using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimAcher.Entidades;

namespace MimAcher.Activities.TAB
{
    [Activity(Label = "Aprender", Theme = "@style/Theme.Splash")]
    public class ResultAprenderActivity : ListActivity
    {
        List<string> items;
        public Bundle participante_bundle;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            participante_bundle = Intent.GetBundleExtra("member");
            Participante participante = Participante.BundleToParticipante(participante_bundle);

            //Listagem do que aprender            
            items = participante.Aprender.Itens;            
            ListAdapter = new ListAdapterHae(this, items);
        }
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = items[position];
            Toast.MakeText(this, t, ToastLength.Short).Show();
        }
    }
}