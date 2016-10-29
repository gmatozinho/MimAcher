using Android.App;
using Android.Content;
using MimAcher.Mobile.Activities;

namespace MimAcher.Mobile.Entidades.Fabricas
{
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class FabricaTelasComTab : TabActivity, IFabricaTelas
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        protected void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote)
        {
            var editaractivity = new Intent(contexto, typeof(EditarPerfilActivity));
            IniciarOutraTela(editaractivity, pacote);
        }

        protected void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(HomeActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        protected void IniciarMain(Context contexto)
        {
            var mainctivity = new Intent(contexto, typeof(MainActivity));
            StartActivity(mainctivity);
        }

        protected void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }
    }
}