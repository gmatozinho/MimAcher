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
    [Activity(Label = "QueroAprenderActivity", Theme = "@style/Theme.Splash")]
    public class QueroAprenderActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebimento do bundle
            Bundle b = Intent.GetBundleExtra("aluno");
            //conversao no objeto
            Aluno aluno = AlunoFactory.criarAluno(b);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.QueroAprender);

            // Create your application here
            Button nome_user = FindViewById<Button>(Resource.Id.nome_user);
            Button ok = FindViewById<Button>(Resource.Id.ok);
            nome_user.Text = aluno.Nome;

            nome_user.Click += delegate {
                var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                //mudar para trabalhar com objeto do banco
                editaractivity.PutExtra("aluno", b);
                StartActivity(editaractivity);
            };

            ok.Click += delegate {
                var queroensinaractivity = new Intent(this, typeof(QueroEnsinarActivity));
                //mudar para trabalhar com objeto do banco
                queroensinaractivity.PutExtra("aluno", b);
                StartActivity(queroensinaractivity);
            };
        }
    }
}