using Android.App;
using Android.Content;
using MimAcher.Mobile.Activities;

namespace MimAcher.Mobile.Entidades
{
    public abstract class FabricaAbstrataTelas : Activity
    {
        protected void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(HomeActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        protected void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote)
        {
            var editaractivity = new Intent(contexto, typeof(EditarPerfilActivity));
            IniciarOutraTela(editaractivity, pacote);
        }

        protected abstract void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote);

    }
}