using Android.App;
using Android.OS;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;

namespace MimAcher.Mobile.Activities.TAB
{
    [Activity(Label = "Ensinar", Theme = "@style/Theme.Splash")]
    public class ResultEnsinarActivity : FabricaTelasComResultados
    {
        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo e transformando o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            Participante = Participante.BundleToParticipante(participanteBundle);

            //Listagem do que ensinar
            Items = Participante.Ensinar.Conteudo;
            ListAdapter = new ListAdapterHae(this, Items);

        }
        
    }
}