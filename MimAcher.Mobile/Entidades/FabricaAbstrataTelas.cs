using Android.App;
using Android.Content;
using MimAcher.Mobile.Activities;

namespace MimAcher.Mobile.Entidades
{
    public abstract class FabricaAbstrataTelas : Activity
    {
        public void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(ResultadoActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        public void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote)
        {
            var editaractivity = new Intent(contexto, typeof(EditarPerfilActivity));
            IniciarOutraTela(editaractivity, pacote);
        }

        public abstract void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote);

    }
}