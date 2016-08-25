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
            Button avançar = FindViewById<Button>(Resource.Id.avançar);
            //Choose Picture button click action
            avançar.Click += delegate {
                StartActivity(typeof(EscolherFotoActivity));
            };

            //TODO Configurar recepção das informações nos campos
        }
    }
}


