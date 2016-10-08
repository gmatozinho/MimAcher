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
    [Activity(Label = "QueroEnsinarActivity", Theme = "@style/Theme.Splash")]
    public class QueroEnsinarActivity : Activity
    {
        private Bundle participante_bundle;
        private Participante participante;
        private ListaItens ListEnsinar = new ListaItens();
        private ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            participante_bundle = Intent.GetBundleExtra("member");
            participante = Participante.BundleToParticipante(participante_bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.QueroEnsinar);

            string ensinar = null;

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = "Ensinar";

            //Start context itens            
            Button ok = FindViewById<Button>(Resource.Id.ok);
            FloatingActionButton add_ensinar = FindViewById<FloatingActionButton>(Resource.Id.add_ensinar);
            EditText campo_ensinar = FindViewById<EditText>(Resource.Id.digite_ensinar);

            listView = FindViewById<ListView>(Resource.Id.list);

            campo_ensinar.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                ensinar = e.Text.ToString();
            };

            add_ensinar.Click += delegate {
                ListEnsinar.AdicionarItem(ensinar, participante.Ensinar.Itens);
                participante.Ensinar.AdicionarItemWithMessage(ensinar, this,"Algo para ensinar");
                campo_ensinar.Text = null;
                listView.Adapter = new ListAdapterHAE(this, ListEnsinar.Itens);
            };

            ok.Click += delegate {
                participante.Commit();
                ListEnsinar.Clear();
                listView.Adapter = null;

                var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
                //mudar para trabalhar com objeto do banco
                resultadoactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(resultadoactivity);
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
                    ListEnsinar.Clear();
                    listView.Adapter = null;

                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    //mudar para trabalhar com objeto do banco
                    resultadoctivity.PutExtra("member", participante.ParticipanteToBundle());
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    //do something
                    participante.Commit();
                    ListEnsinar.Clear();
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