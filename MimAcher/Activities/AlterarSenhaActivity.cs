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
        private string novasenha;
        private string repitasenha;
        Participante participante;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            Bundle participante_bundle = Intent.GetBundleExtra("member");
            participante = Participante.BundleToParticipante(participante_bundle);

            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.AlterarSenha);

            EditText nova_senha = FindViewById<EditText>(Resource.Id.nova_senha);
            EditText repita_nova_senha = FindViewById<EditText>(Resource.Id.repita_nova_senha);
            Button confirmar = FindViewById<Button>(Resource.Id.confirmar);

            //Pegar as informações inseridas
            nova_senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs n) =>
            {
                novasenha = n.Text.ToString();
            };

            repita_nova_senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs r) =>
            {
                repitasenha = r.Text.ToString();
            };


            confirmar.Click += delegate
            {
                CheckSenhas();
                
            };
            
        }

        private void CheckSenhas()
        {
            if (repitasenha == novasenha)
            {
                participante.Senha = novasenha;
                string toast = string.Format("Senha Alterada");
                Toast.MakeText(this, toast, ToastLength.Long).Show();

                var editarperfilactivity = new Intent(this, typeof(EditarPerfilActivity));
                //mudar para trabalhar com objeto do banco
                //deverá rolar um commit para salvar alterações no banco                
                editarperfilactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(editarperfilactivity);
            }
            else
            {
                string toast = string.Format("As senhas estão diferentes");
                Toast.MakeText(this, toast, ToastLength.Long).Show();

                var alterarsenhaactivity = new Intent(this, typeof(AlterarSenhaActivity));
                //mudar para trabalhar com objeto do banco
                //deverá rolar um commit para salvar alterações no banco                
                alterarsenhaactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(alterarsenhaactivity);
            }
        }

        
    }
}