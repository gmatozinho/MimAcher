using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MimAcher
{
    [Activity(Label = "MimAcher", Theme = "@style/Theme.Splash")]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Initializing button from layout
            Button inscrevase = FindViewById<Button>(Resource.Id.inscrevase);

            //Login button click action
            inscrevase.Click += delegate {
                StartActivity(typeof(InscreverActivity));
            };

            //TODO Configurar recepção das informações nos campos

        }
    }
}

