using Android.App;
using Android.OS;
using MimAcher.Mobile.com.Entidades;

namespace MimAcher.Mobile.com.Activities.TAB
{
    [Activity(Label = "Gostos", Theme = "@style/Theme.Splash")]
    public class CombinacoesHobbiesActivity : ListActivity
    {
        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo e transformando o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            var participante = Participante.BundleToParticipante(participanteBundle);

            //Listagem dos Hobbies
            var items = participante.Hobbies.Conteudo;
            ListAdapter = new ListAdapterHae(this, items);

        }
    }
}