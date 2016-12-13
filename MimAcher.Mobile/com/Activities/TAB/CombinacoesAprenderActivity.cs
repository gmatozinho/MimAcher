using Android.App;
using Android.OS;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.Mobile.com.Activities.TAB
{
    [Activity(Label = "Aprender", Theme = "@style/Theme.Splash")]
    public class CombinacoesAprenderActivity : ListActivity 
    {
        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo e transformando o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            var participante = Participante.BundleToParticipante(participanteBundle);

            //Listagem do que aprender            
            var items = participante.Aprender.Conteudo;            
            ListAdapter = new ListAdapterHae(this, items);
        }
        
    }
}
