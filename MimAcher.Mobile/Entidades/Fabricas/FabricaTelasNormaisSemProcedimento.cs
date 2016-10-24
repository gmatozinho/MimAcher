using Android.Content;
using MimAcher.Mobile.Activities;

namespace MimAcher.Mobile.Entidades.Fabricas
{
    public class FabricaTelasNormaisSemProcedimento : FabricaAbstrataTelasNormais
    {
        protected override void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        protected void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote)
        {
            var alterarsenhaactivity = new Intent(contexto, typeof(AlterarSenhaActivity));
            IniciarOutraTela(alterarsenhaactivity, pacote);
        }

        protected void IniciarHobbies(Context contexto, PacoteAbstrato pacote)
        {
            var hobbiesactivity = new Intent(contexto, typeof(HobbiesActivity));
            IniciarOutraTela(hobbiesactivity, pacote);
        }

        protected void IniciarEscolherFoto(Context contexto, PacoteAbstrato pacote)
        {
            var escolherfotoactivity = new Intent(contexto, typeof(EscolherFotoActivity));
            IniciarOutraTela(escolherfotoactivity,pacote);
        }

        protected void IniciarInscrever()
        {
            var inscreveractivity = new Intent(this, typeof(InscreverActivity));
            StartActivity(inscreveractivity);
        }

    }
}