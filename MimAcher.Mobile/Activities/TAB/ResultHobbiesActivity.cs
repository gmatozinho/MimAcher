using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;

namespace MimAcher.Mobile.Activities.TAB
{
    [Activity(Label = "Gostos", Theme = "@style/Theme.Splash")]
    public class ResultHobbiesActivity : FabricaTelasComResultados
    {
        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo e transformando o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            Participante = Participante.BundleToParticipante(participanteBundle);

            //Listagem dos Hobbies
            Items = Participante.Hobbies.Conteudo;
            ListAdapter = new ListAdapterHae(this, Items);

        }
    }
}