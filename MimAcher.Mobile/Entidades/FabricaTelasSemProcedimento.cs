using Android.Content;
using MimAcher.Mobile.Activities;

namespace MimAcher.Mobile.Entidades
{
    public class FabricaTelasSemProcedimento : FabricaAbstrataTelas
    {
        public override void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        public void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote)
        {
            var alterarsenhaactivity = new Intent(contexto, typeof(AlterarSenhaActivity));
            IniciarOutraTela(alterarsenhaactivity, pacote);
        }
        
        public void IniciarHobbies(Context contexto, PacoteAbstrato pacote)
        {
            var hobbiesactivity = new Intent(contexto, typeof(HobbiesActivity));
            IniciarOutraTela(hobbiesactivity, pacote);
        }
    }
}