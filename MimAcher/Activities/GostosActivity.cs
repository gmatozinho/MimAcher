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

namespace MimAcher
{
    [Activity(Label = "GostosActivity", Theme = "@style/Theme.Splash")]
    public class GostosActivity : Activity
    {
        public Bundle aluno_bundle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Bundle aluno_bundle = Intent.GetBundleExtra("aluno");
            Participante aluno = ParticipanteFactory.CriarParticipante(aluno_bundle);          

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Gostos);

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = aluno.Nome;


            //Button
            Button ok = FindViewById<Button>(Resource.Id.ok);

            ok.Click += delegate {
                Dictionary<string, bool> Gostos = CriarDicionarioGostos();
                PreencherGostosAluno(Gostos, aluno);
                aluno.Commit();

                var queroaprenderactivity = new Intent(this, typeof(QueroAprenderActivity));
                queroaprenderactivity.PutExtra("aluno", aluno_bundle);
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
                case Resource.Id.menu_preferences:
                    //do something
                    var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                    //mudar para trabalhar com objeto do banco
                    editaractivity.PutExtra("aluno", aluno_bundle);
                    StartActivity(editaractivity);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        
        private Dictionary<string, bool> CriarDicionarioGostos()
        {
            //Checkbox Variables
            Dictionary<string, bool> Gostos = new Dictionary<string, bool>();
            CheckBox rock = FindViewById<CheckBox>(Resource.Id.rock);
            CheckBox games = FindViewById<CheckBox>(Resource.Id.games);
            CheckBox futebol = FindViewById<CheckBox>(Resource.Id.futebol);
            CheckBox pop = FindViewById<CheckBox>(Resource.Id.pop);
            CheckBox programacao = FindViewById<CheckBox>(Resource.Id.programacao);
            CheckBox empreender = FindViewById<CheckBox>(Resource.Id.empreender);
            CheckBox viajar = FindViewById<CheckBox>(Resource.Id.viajar);
            CheckBox analise_sistemas = FindViewById<CheckBox>(Resource.Id.analise_sistemas);

            Gostos.Add(rock.Text, rock.Checked);
            Gostos.Add(games.Text, games.Checked);
            Gostos.Add(futebol.Text, futebol.Checked);
            Gostos.Add(pop.Text, pop.Checked);
            Gostos.Add(programacao.Text, programacao.Checked);
            Gostos.Add(empreender.Text, empreender.Checked);
            Gostos.Add(viajar.Text, viajar.Checked);
            Gostos.Add(analise_sistemas.Text, analise_sistemas.Checked);

            return Gostos;
        }

        private void PreencherGostosAluno(Dictionary<string, bool> Gostos, Participante aluno)
        {
            foreach (String strKey in Gostos.Keys)
            {
                if (Gostos[strKey])
                {
                    aluno.AdicionarGosto(strKey);
                }
            }
        }
    }
}