using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Activities;
using MimAcher.Mobile.Entidades;


namespace MimAcher.Mobile.Services
{
    public class ServicoTelasComProcedimento : ServicoTelas
    {
        public override void IniciarHome(Context contexto,Pacote pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(ResultadoActivity));
            IniciarOutraTela(resultadoctivity,pacote);
        }

        public override void IniciarQueroAprenderActivity(Context contexto, Pacote pacote)
        {
            var queroaprenderactivity = new Intent(contexto, typeof(QueroAprenderActivity));
            //TODO mudar para trabalhar com objeto do banco
            IniciarOutraTela(queroaprenderactivity,pacote);
        }

        public override void IniciarEditarPerfil(Context contexto, Pacote pacote)
        {
            var editaractivity = new Intent(contexto, typeof(EditarPerfilActivity));
            IniciarOutraTela(editaractivity,pacote);
        }

        public override void IniciarOutraTela(Intent activitydesejada, Pacote pacote)
        {
            var pacotePadrao = (PacotePadrao) pacote;
            ProcedimentoPadrao(pacotePadrao);
            activitydesejada.PutExtra("member", pacotePadrao.Participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        public void ProcedimentoPadrao(PacotePadrao pacote)
        {
            pacote.Participante.Commit();
            pacote.ListaItens.Clear();
            pacote.ListView.Adapter = null;
        }

        public void InserirItem(PacotePadrao pacotePadrao, EditText campoTexto, string item)
        {
            pacotePadrao.ListaItens.AdicionarItem(item, pacotePadrao.Participante.Hobbies.Conteudo);
            pacotePadrao.Participante.Hobbies.AdicionarItemWithMessage(item, this, "Hobbie");
            campoTexto.Text = null;
            pacotePadrao.ListView.Adapter = new ListAdapterHae(this, pacotePadrao.ListaItens.Conteudo);
        }



    }
}