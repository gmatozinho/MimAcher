using Android.App;
using Android.OS;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Activities.TAB
{
    [Activity(Label = "Ensinar", Theme = "@style/Theme.Splash")]
    public class CombinacoesEnsinarActivity : ListActivity
    {
        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo e transformando o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            var participante = Participante.BundleToParticipante(participanteBundle);

            //Listagem do que ensinar
            var items = participante.Ensinar.Conteudo;
            ListAdapter = new ListAdapterHae(this, items);

        }
        
    }
}