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

            // Create your application here
            //Recebimento do bundle
            Bundle b = Intent.GetBundleExtra("aluno");
            //conversao em aluno
            Aluno aluno = AlunoFactory.criarAluno(b);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.QueroEnsinar);

            // Create your application here
            //Buttons
            Button nome_user = FindViewById<Button>(Resource.Id.nome_user);
            Button ok = FindViewById<Button>(Resource.Id.ok);
            //Button change text
            nome_user.Text = aluno.Nome;

            nome_user.Click += delegate {
                var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                //mudar para trabalhar com objeto do banco
                editaractivity.PutExtra("aluno", b);
                StartActivity(editaractivity);
            };

            ok.Click += delegate {
                var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
                //mudar para trabalhar com objeto do banco
                resultadoactivity.PutExtra("aluno", b);
                StartActivity(resultadoactivity);
            };
        }
    }
}