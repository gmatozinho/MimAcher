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

namespace MimAcher
{
    [Activity(Label = "QueroAprenderActivity", Theme = "@style/Theme.Splash")]
    public class QueroAprenderActivity : Activity
    {
        public Bundle aluno_bundle;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            aluno_bundle = Intent.GetBundleExtra("aluno");
            Aluno aluno = AlunoFactory.CriarAluno(aluno_bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.QueroAprender);

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = aluno.Nome;

            Button ok = FindViewById<Button>(Resource.Id.ok);

            ok.Click += delegate {
                Dictionary<string, bool> Aprender = CriarDicionarioAprender();
                PreencherAprenderAluno(Aprender, aluno);
                aluno.Commit();

                var queroensinaractivity = new Intent(this, typeof(QueroEnsinarActivity));
                //mudar para trabalhar com objeto do banco
                queroensinaractivity.PutExtra("aluno", aluno_bundle);
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

        private Dictionary<string, bool> CriarDicionarioAprender()
        {
            //Checkbox Variables
            Dictionary<string, bool> Aprender = new Dictionary<string, bool>();
            CheckBox violao = FindViewById<CheckBox>(Resource.Id.violao);
            CheckBox poker = FindViewById<CheckBox>(Resource.Id.poker);
            CheckBox xadrez = FindViewById<CheckBox>(Resource.Id.xadrez);
            CheckBox violino = FindViewById<CheckBox>(Resource.Id.violino);
            CheckBox desenvolvimento_mobile = FindViewById<CheckBox>(Resource.Id.desenvolvimento_mobile);
            CheckBox angular_js = FindViewById<CheckBox>(Resource.Id.angular_js);
            CheckBox dota2 = FindViewById<CheckBox>(Resource.Id.dota2);
            CheckBox php = FindViewById<CheckBox>(Resource.Id.php);

            Aprender.Add(violao.Text, violao.Checked);
            Aprender.Add(poker.Text, poker.Checked);
            Aprender.Add(xadrez.Text, xadrez.Checked);
            Aprender.Add(violino.Text, violino.Checked);
            Aprender.Add(desenvolvimento_mobile.Text, desenvolvimento_mobile.Checked);
            Aprender.Add(angular_js.Text, angular_js.Checked);
            Aprender.Add(dota2.Text, dota2.Checked);
            Aprender.Add(php.Text, php.Checked);

            return Aprender;
        }

        private void PreencherAprenderAluno(Dictionary<string, bool> Aprender, Aluno aluno)
        {
            foreach (String strKey in Aprender.Keys)
            {
                if (Aprender[strKey])
                {
                    aluno.AdicionarAprender(strKey);
                }
            }
        }
    }
}