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

namespace MimAcher
{
    [Activity(Label = "ResultadoActivity", Theme = "@style/Theme.Splash")]
    public class ResultadoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            //PEGAR NOME DO USUARIO DE OUTRA ACTIVITY
            string nome_usuario = Intent.GetStringExtra("user");

            // Create your application here
            SetContentView(Resource.Layout.Resultado);
            
            //Alterando a informação no botão fulano
            Button nome_user_result = FindViewById<Button>(Resource.Id.nome_user_result);
            nome_user_result.Text = nome_usuario.ToString();

            nome_user_result.Click += delegate {
                StartActivity(typeof(EditarPerfilActivity));
            };


            //TODO Configurar recepção das informações nos campos
        }
    }
}