using System;
using Android.Content;
using MimAcher.Mobile.Activities;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Services
{
    public class ServicoTelasSemProcedimento : ServicoTelas
    {
        public override void IniciarEditarPerfil(Context contexto, Pacote pacote)
        {
            var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
            IniciarOutraTela(editaractivity,pacote);
        }

        public void IniciarAlterarSenha(Context contexto, Pacote pacote)
        {
            var alterarsenhaactivity = new Intent(this, typeof(AlterarSenhaActivity));
            IniciarOutraTela(alterarsenhaactivity, pacote);
        }


        public override void IniciarHome(Context contexto, Pacote pacote)
        {
            throw new NotImplementedException();
        }

        public override void IniciarOutraTela(Intent activitydesejada, Pacote pacote)
        {
            var participante = (Participante) pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        public override void IniciarQueroAprenderActivity(Context contexto, Pacote pacotePadrao)
        {
            throw new NotImplementedException();
        }
    }
}