using System;
using System.Threading.Tasks;
using Android.Content;
using MimAcher.Mobile.com.Activities;

namespace MimAcher.Mobile.com.Entidades.Fabricas
{
    public class FabricaTelasNormaisSemProcedimento : FabricaAbstrataTelasNormais
    {
        public override void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        public override void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote)
        {
            var alterarsenhaactivity = new Intent(contexto, typeof(AlterarSenhaActivity));
            IniciarOutraTela(alterarsenhaactivity, pacote);
        }

        public override void IniciarHobbies(Context contexto, PacoteAbstrato pacote)
        {
            var hobbiesactivity = new Intent(contexto, typeof(HobbiesActivity));
            IniciarOutraTela(hobbiesactivity, pacote);
        }

        public override void IniciarEscolherFoto(Context contexto, PacoteAbstrato pacote)
        {
            var escolherfotoactivity = new Intent(contexto, typeof(EscolherFotoActivity));
            IniciarOutraTela(escolherfotoactivity,pacote);
        }

        public override Task IniciarInscrever()
        {
            var inscreveractivity = new Intent(this, typeof(InscreverActivity));
            StartActivity(inscreveractivity);
            return Task.CompletedTask;
        }

        public override void IniciarQueroAprenderActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public override void IniciarQueroEnsinarActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public override void IniciarMain(Context contexto)
        {
            var mainactivity = new Intent(contexto, typeof(MainActivity));
            StartActivity(mainactivity);
        }
        
    }
}