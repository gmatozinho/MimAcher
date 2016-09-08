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
    [Activity(Label = "EscolherFotoActivity", Theme = "@style/Theme.Splash")]
    public class EscolherFotoActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Bundle aluno_bundle = Intent.GetBundleExtra("aluno");
            // Create your application here
            SetContentView(Resource.Layout.EscolherFoto);

            //Create button
            Button avançar = FindViewById<Button>(Resource.Id.avançar);
            ImageView escolher_foto = FindViewById<ImageView>(Resource.Id.exibirfoto);

            //escolher a imagem
            escolher_foto.Click += delegate {
                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(
                    Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };
            //botar a foto no banco

            avançar.Click += delegate {
                var gostosactivity = new Intent(this, typeof(GostosActivity));
                gostosactivity.PutExtra("aluno", aluno_bundle);
                StartActivity(gostosactivity);
            };
        }

        //alter result
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                var imageView =
                    FindViewById<ImageView>(Resource.Id.exibirfoto);
                imageView.SetImageURI(data.Data);                       
           }
        }
    }

}

