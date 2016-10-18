using Android.App;
using Android.Content;
using Java.Lang;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Services
{
    public abstract class ServicoTelas : Activity
    {
        public abstract void IniciarHome(Context contexto, Pacote pacote);

        public abstract void IniciarQueroAprenderActivity(Context contexto, Pacote pacote);

        public abstract void IniciarEditarPerfil(Context contexto, Pacote pacote);

        public abstract void IniciarOutraTela(Intent activitydesejada, Pacote pacote);

    }
}