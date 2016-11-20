using Android.App;
using Android.OS;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Activities.TAB
{
    [Activity(Label = "Aprender", Theme = "@style/Theme.Splash")]
    public class ResultAprenderActivity : FabricaTelasComResultados
    {
        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo e transformando o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            Participante = Participante.BundleToParticipante(participanteBundle);

            //Listagem do que aprender            
            Items = Participante.Aprender.Conteudo;            
            ListAdapter = new ListAdapterHae(this, Items);
        }
        
    }
}
