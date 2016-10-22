using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "EscolherFotoActivity", Theme = "@style/Theme.Splash")]
    public class EscolherFotoActivity : FabricaTelasSemProcedimento
    {
        

        //Metodos do controlador
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            PacoteAbstrato pacote = Participante.BundleToParticipante(participanteBundle);

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
                IniciarHobbies(this,pacote);
            };
        }

        private void SelecionarFoto()
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

        

        
    }

}

