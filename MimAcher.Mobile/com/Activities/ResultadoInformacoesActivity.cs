using Android.App;
using Android.OS;

namespace MimAcher.Mobile.com.Activities
{

    [Activity(Label = "ResultadoInformacoesActivity", Theme = "@style/Theme.Splash")]
    public class ResultadoInformacoesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.UsuarioResultado);
            //show results
        }
    }

}