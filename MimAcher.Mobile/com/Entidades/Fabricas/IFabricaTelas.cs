using System.Threading.Tasks;
using Android.Content;

namespace MimAcher.Mobile.com.Entidades.Fabricas
{
    public interface IFabricaTelas
    {
        void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote);

        void IniciarQueroAprenderActivity(Context contexto, PacoteAbstrato pacote);

        void IniciarQueroEnsinarActivity(Context contexto, PacoteAbstrato pacote);

        void IniciarHobbies(Context contexto, PacoteAbstrato pacote);

        void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote);

        void IniciarHome(Context contexto, PacoteAbstrato pacote);

        void IniciarMain(Context contexto);

        Task IniciarInscrever();

        void IniciarEscolherFoto(Context contexto, PacoteAbstrato pacote);

        void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote);


    }
}