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

namespace MimAcher.Activities
{
    [Activity(Label = "AlterarSenhaActivity", Theme = "@style/Theme.Splash")]
    public class AlterarSenhaActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Bundle aluno_bundle = Intent.GetBundleExtra("aluno");
            Participante aluno = ParticipanteFactory.CriarParticipante(aluno_bundle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AlterarSenha);

            EditText nova_senha = FindViewById<EditText>(Resource.Id.nova_senha);
            EditText repita_nova_senha = FindViewById<EditText>(Resource.Id.repita_nova_senha);
            Button confirmar = FindViewById<Button>(Resource.Id.confirmar);
        }
    }
}