using Android.App;
using Android.Content;
using MimAcher.Mobile.Activities;

namespace MimAcher.Mobile.Entidades.Fabricas
{
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public abstract class FabricaAbstrataTelasNormais : Activity, IFabricaTelas
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        protected abstract void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote);

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
    }
}