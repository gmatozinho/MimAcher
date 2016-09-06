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
    [Activity(Label = "InscreverActivity", Theme = "@style/Theme.Splash")]
    public class InscreverActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Inscrever);
            //Initializing button from layout
            Button avan�ar = FindViewById<Button>(Resource.Id.avan�ar);


            //Pegar as informa��es inseridas

            //Choose Picture button click action
            avan�ar.Click += delegate {
                StartActivity(typeof(EscolherFotoActivity));
            };

            //TODO Configurar recep��o das informa��es nos campos
        }
    }
}


