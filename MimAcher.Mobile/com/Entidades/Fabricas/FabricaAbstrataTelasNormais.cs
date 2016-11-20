using System.Threading.Tasks;
using Android.App;
using Android.Content;
using MimAcher.Mobile.com.Activities;

namespace MimAcher.Mobile.com.Entidades.Fabricas
{
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public abstract class FabricaAbstrataTelasNormais : Activity, IFabricaTelas
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        
        public void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote)
        {
            var editaractivity = new Intent(contexto, typeof(EditarPerfilActivity));
            IniciarOutraTela(editaractivity, pacote);
        }

        public void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(HomeActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        public abstract void IniciarQueroAprenderActivity(Context contexto, PacoteAbstrato pacote);
        public abstract void IniciarQueroEnsinarActivity(Context contexto, PacoteAbstrato pacote);
        public abstract void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote);
        public abstract void IniciarHobbies(Context contexto, PacoteAbstrato pacote);
        public abstract void IniciarMain(Context contexto);
        public abstract Task IniciarInscrever();
        public abstract void IniciarEscolherFoto(Context contexto, PacoteAbstrato pacote);
        public abstract void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote);
    }
}