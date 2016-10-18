using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "EscolherFotoActivity", Theme = "@style/Theme.Splash")]
    public class EscolherFotoActivity : Activity
    {
        private Bundle _participanteBundle;
        private Participante _participante;

        //Metodos do controlador
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo o bundle(Objeto participante)
            _participanteBundle = Intent.GetBundleExtra("member");
            _participante = Participante.BundleToParticipante(_participanteBundle);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.EscolherFoto);

            //Iniciando as variaveis do contexto
            var avançar = FindViewById<Button>(Resource.Id.avançar);
            var escolherFoto = FindViewById<ImageView>(Resource.Id.exibirfoto);

            //Funcionalidades
            escolherFoto.Click += delegate {
                SelecionarFoto();
            };

            //botar a foto no banco
            avançar.Click += delegate {
                IniciarHobbies();
            };
        }

        public void SelecionarFoto()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);
            StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"), 0);
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

        public void IniciarHobbies()
        {
            var hobbiesactivity = new Intent(this, typeof(HobbiesActivity));
            IniciarOutraTela(hobbiesactivity);
        }

        public void IniciarOutraTela(Intent activitydesejada)
        {
            activitydesejada.PutExtra("member", _participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }
    }

}

