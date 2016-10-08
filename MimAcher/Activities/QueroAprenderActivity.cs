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
using MimAcher.Activities.TAB;
using com.refractored.fab;

namespace MimAcher
{
    [Activity(Label = "QueroAprenderActivity", Theme = "@style/Theme.Splash")]
    public class QueroAprenderActivity : Activity
    {
        private Bundle participante_bundle;
        private Participante participante;
        private ListaItens ListAprender = new ListaItens();
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            participante_bundle = Intent.GetBundleExtra("member");
            participante = Participante.BundleToParticipante(participante_bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.QueroAprender);

            string aprender = null;

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = "Aprender";

            //Button
            
            Button ok = FindViewById<Button>(Resource.Id.ok);
            FloatingActionButton add_aprender= FindViewById<FloatingActionButton>(Resource.Id.add_aprender);
            EditText campo_aprender = FindViewById<EditText>(Resource.Id.digite_aprender);

            listView = FindViewById<ListView>(Resource.Id.list);

            campo_aprender.TextChanged += (object sender, Android.Text.TextChangedEventArgs a) => {
                aprender = a.Text.ToString();
            };

            add_aprender.Click += delegate {
                ListAprender.AdicionarItem(aprender, participante.Aprender.Itens);
                participante.Aprender.AdicionarItemWithMessage(aprender, this,"Algo para aprender");
                campo_aprender.Text = null;
                listView.Adapter = new ListAdapterHAE(this, ListAprender.Itens);
            };

            ok.Click += delegate {
                participante.Commit();
                ListAprender.Clear();
                listView.Adapter = null;

                var queroensinaractivity = new Intent(this, typeof(QueroEnsinarActivity));
                queroensinaractivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(queroensinaractivity);
            };
        }

        //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_nosearch, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        //Define as funcionalidades destes menus
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_home:
                    //do something
                    participante.Commit();
                    ListAprender.Clear();
                    listView.Adapter = null;

                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    //mudar para trabalhar com objeto do banco
                    resultadoctivity.PutExtra("member", participante.ParticipanteToBundle());
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    //do something
                    participante.Commit();
                    ListAprender.Clear();
                    listView.Adapter = null;

                    var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                    //mudar para trabalhar com objeto do banco
                    editaractivity.PutExtra("member", participante.ParticipanteToBundle());
                    StartActivity(editaractivity);
                    return true;                
            }
            return base.OnOptionsItemSelected(item);
        }

        


    }
}