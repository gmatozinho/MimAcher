using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimAcher.Entidades;
using MimAcher.Activities.TAB;

namespace MimAcher
{
    [Activity(Label = "HobbiesActivity", Theme = "@style/Theme.Splash")]
    public class HobbiesActivity : ListActivity
    {
        private Bundle participante_bundle;
        private Participante participante;
        private ListaItens Hobbies = new ListaItens();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            participante_bundle = Intent.GetBundleExtra("member");
            participante = Participante.BundleToParticipante(participante_bundle);          

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Hobbies);

            string hobbie = null;

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = "Hobbies";

            //Start Context activity    
            Button ok = FindViewById<Button>(Resource.Id.ok);
            Button add_hobbie = FindViewById<Button>(Resource.Id.add_hobbie);
            EditText campo_hobbie = FindViewById<EditText>(Resource.Id.digite_hobbies);
            

            campo_hobbie.TextChanged += (object sender, Android.Text.TextChangedEventArgs h) => {
                hobbie = h.Text.ToString();
            };

            add_hobbie.Click += delegate {
                Hobbies.AdicionarItem(hobbie,this,"Hobbie");                
                campo_hobbie.Text = null;
            };

            ok.Click += delegate {
                participante.PreencherItensParticipante(Hobbies.Itens, participante.Hobbies);
                participante.Commit();

                var queroaprenderactivity = new Intent(this, typeof(QueroAprenderActivity));
                queroaprenderactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(queroaprenderactivity);
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
                    participante.PreencherItensParticipante(Hobbies.Itens, participante.Hobbies);
                    participante.Commit();

                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    //mudar para trabalhar com objeto do banco
                    resultadoctivity.PutExtra("member", participante.ParticipanteToBundle());
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    //do something
                    participante.PreencherItensParticipante(Hobbies.Itens, participante.Hobbies);
                    participante.Commit();

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