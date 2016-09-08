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
using MimAcher.SourceCode;

namespace MimAcher
{
    [Activity(Label = "QueroEnsinarActivity", Theme = "@style/Theme.Splash")]
    public class QueroEnsinarActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Bundle aluno_bundle = Intent.GetBundleExtra("aluno");
            Aluno aluno = AlunoFactory.criarAluno(aluno_bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.QueroEnsinar);

            // Create your application here
            Button nome_user = FindViewById<Button>(Resource.Id.nome_user);
            Button ok = FindViewById<Button>(Resource.Id.ok);
            
            nome_user.Text = aluno.Nome;

            nome_user.Click += delegate {
                var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                //mudar para trabalhar com objeto do banco
                editaractivity.PutExtra("aluno", aluno_bundle);
                StartActivity(editaractivity);
            };

            ok.Click += delegate {
                Dictionary<string, bool> Ensinar = criarDicionarioEnsinar();
                preencherEnsinarAluno(Ensinar, aluno);
                aluno.commit();

                var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
                //mudar para trabalhar com objeto do banco
                resultadoactivity.PutExtra("aluno", aluno_bundle);
                StartActivity(resultadoactivity);
            };
        }

        private Dictionary<string, bool> criarDicionarioEnsinar()
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

        private void preencherEnsinarAluno(Dictionary<string, bool> Ensinar, Aluno aluno)
        {
            foreach (String strKey in Ensinar.Keys)
            {
                if (Ensinar[strKey])
                {
                    aluno.adicionarEnsinar(strKey);
                }
            }
        }
    }
}