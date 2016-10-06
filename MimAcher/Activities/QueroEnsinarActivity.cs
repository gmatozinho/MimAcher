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
    [Activity(Label = "QueroEnsinarActivity", Theme = "@style/Theme.Splash")]
    public class QueroEnsinarActivity : Activity
    {
        public Bundle participante_bundle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            participante_bundle = Intent.GetBundleExtra("member");
            Participante aluno = Participante.BundleToParticipante(participante_bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.QueroEnsinar);

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = aluno.Nome;

            Button ok = FindViewById<Button>(Resource.Id.ok);

            ok.Click += delegate {
                Dictionary<string, bool> Ensinar = CriarDicionarioEnsinar();
                PreencherEnsinarParticipante(Ensinar, aluno);
                aluno.Commit();

                var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
                //mudar para trabalhar com objeto do banco
                resultadoactivity.PutExtra("member", participante_bundle);
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
                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    //mudar para trabalhar com objeto do banco
                    resultadoctivity.PutExtra("member", participante_bundle);
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    //do something
                    var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                    //mudar para trabalhar com objeto do banco
                    editaractivity.PutExtra("member", participante_bundle);
                    StartActivity(editaractivity);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private Dictionary<string, bool> CriarDicionarioEnsinar()
        {
            //Checkbox Variables
            Dictionary<string, bool> Ensinar = new Dictionary<string, bool>();
            CheckBox violao = FindViewById<CheckBox>(Resource.Id.violao);
            CheckBox poker = FindViewById<CheckBox>(Resource.Id.poker);
            CheckBox xadrez = FindViewById<CheckBox>(Resource.Id.xadrez);
            CheckBox violino = FindViewById<CheckBox>(Resource.Id.violino);
            CheckBox desenvolvimento_mobile = FindViewById<CheckBox>(Resource.Id.desenvolvimento_mobile);
            CheckBox angular_js = FindViewById<CheckBox>(Resource.Id.angular_js);
            CheckBox dota2 = FindViewById<CheckBox>(Resource.Id.dota2);
            CheckBox php = FindViewById<CheckBox>(Resource.Id.php);

            Ensinar.Add(violao.Text, violao.Checked);
            Ensinar.Add(poker.Text, poker.Checked);
            Ensinar.Add(xadrez.Text, xadrez.Checked);
            Ensinar.Add(violino.Text, violino.Checked);
            Ensinar.Add(desenvolvimento_mobile.Text, desenvolvimento_mobile.Checked);
            Ensinar.Add(angular_js.Text, angular_js.Checked);
            Ensinar.Add(dota2.Text, dota2.Checked);
            Ensinar.Add(php.Text, php.Checked);

            return Ensinar;
        }

        private void PreencherEnsinarParticipante(Dictionary<string, bool> Ensinar, Participante Participante)
        {
            foreach (String strKey in Ensinar.Keys)
            {
                if (Ensinar[strKey])
                {
                    Participante.AdicionarEnsinar(strKey);
                }
            }
        }
    }
}