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
    [Activity(Label = "GostosActivity", Theme = "@style/Theme.Splash")]
    public class GostosActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            String user = "Fulano";
            user = Intent.GetStringExtra("user");

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Gostos);

            // Create your application here
            Button nome_user = FindViewById<Button>(Resource.Id.nome_user);
            Button ok = FindViewById<Button>(Resource.Id.ok);
            nome_user.Text = user;

            nome_user.Click += delegate {
                var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                //mudar para trabalhar com objeto do banco
                editaractivity.PutExtra("user", user);
                StartActivity(editaractivity);
            };

            ok.Click += delegate {
                var queroaprenderactivity = new Intent(this, typeof(QueroAprenderActivity));
                //mudar para trabalhar com objeto do banco
                queroaprenderactivity.PutExtra("user", user);
                StartActivity(queroaprenderactivity);
            };

        }
    }
}