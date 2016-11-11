using System;
using Android.App;
using Android.Content;
using MimAcher.Mobile.Activities;
using System.Threading.Tasks;

namespace MimAcher.Mobile.Entidades.Fabricas
{
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class FabricaTelasComTab : TabActivity, IFabricaTelas
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        public void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote)
        {
            var editaractivity = new Intent(contexto, typeof(EditarPerfilActivity));
            IniciarOutraTela(editaractivity, pacote);
        }

        public void IniciarEscolherFoto(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarHobbies(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(HomeActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        public Task IniciarInscrever()
        {
            throw new NotImplementedException();
        }

        public void IniciarMain(Context contexto)
        {
            var mainctivity = new Intent(contexto, typeof(MainActivity));
            StartActivity(mainctivity);
        }

        public void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        public void IniciarQueroAprenderActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarQueroEnsinarActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }
    }
}