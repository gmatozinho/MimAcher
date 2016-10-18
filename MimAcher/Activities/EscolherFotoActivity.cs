using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MimAcher.Resources;

namespace MimAcher.Activities
{
    [Activity(Label = "EscolherFotoActivity", Theme = "@style/Theme.Splash")]
    public class EscolherFotoActivity : Activity
    {
        //Metodos do controlador
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            SetContentView(Resource.Layout.EscolherFoto);


            //Iniciando as variaveis do contexto
            var avançar = FindViewById<Button>(Resource.Id.avançar);
            var escolherFoto = FindViewById<ImageView>(Resource.Id.exibirfoto);

            //Funcionalidades
            escolherFoto.Click += delegate {
                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(
                    Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };

            //botar a foto no banco
            avançar.Click += delegate {
                var hobbiesactivity = new Intent(this, typeof(HobbiesActivity));
                hobbiesactivity.PutExtra("member", participanteBundle);
                StartActivity(hobbiesactivity);
            };
        }
        
        //Retorna a imagem para a activity
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode != Result.Ok) return;
            var imageView =
                FindViewById<ImageView>(Resource.Id.exibirfoto);
            imageView.SetImageURI(data.Data);
        }
    }

}

