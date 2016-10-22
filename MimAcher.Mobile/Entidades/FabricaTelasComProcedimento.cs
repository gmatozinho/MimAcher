using Android.Content;
using Android.Widget;
using MimAcher.Mobile.Activities;

namespace MimAcher.Mobile.Entidades
{
    public class FabricaTelasComProcedimento : FabricaAbstrataTelas
    {
        protected override void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var pacotePadrao = (PacoteCompleto)pacote;
            ProcedimentoPadrao(pacotePadrao);
            activitydesejada.PutExtra("member", pacotePadrao.Participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        protected void IniciarQueroAprenderActivity(Context contexto, PacoteAbstrato pacote)
        {
            var queroaprenderactivity = new Intent(contexto, typeof(QueroAprenderActivity));
            //TODO mudar para trabalhar com objeto do banco
            IniciarOutraTela(queroaprenderactivity,pacote);
        }

        protected void IniciarQueroEnsinarActivity(Context contexto, PacoteAbstrato pacote)
        {
            var queroensinaractivity = new Intent(contexto, typeof(QueroEnsinarActivity));
            //TODO mudar para trabalhar com objeto do banco
            IniciarOutraTela(queroensinaractivity, pacote);
        }

        private static void ProcedimentoPadrao(PacoteCompleto pacote)
        {
            pacote.Participante.Commit();
            pacote.ListaItens.Clear();
            pacote.ListView.Adapter = null;
        }

        protected void InserirItem(EditText campo, PacoteCompleto pacoteCompleto, string[] mensagemEItem)
        {
            switch (mensagemEItem[0])
            {
                case "Hobbie":
                    pacoteCompleto.ListaItens.AdicionarItem(mensagemEItem[1], pacoteCompleto.Participante.Hobbies.Conteudo);
                    pacoteCompleto.Participante.Hobbies.AdicionarItemWithMessage(mensagemEItem[1], this, mensagemEItem[0]);
                    LimparEListar(campo, pacoteCompleto.ListView, pacoteCompleto.ListaItens);
                    break;
                case "Algo para Aprender":
                    pacoteCompleto.ListaItens.AdicionarItem(mensagemEItem[1], pacoteCompleto.Participante.Aprender.Conteudo);
                    pacoteCompleto.Participante.Aprender.AdicionarItemWithMessage(mensagemEItem[1], this, mensagemEItem[0]);
                    LimparEListar(campo, pacoteCompleto.ListView, pacoteCompleto.ListaItens);
                    break;
                case "Algo para Ensinar":
                    pacoteCompleto.ListaItens.AdicionarItem(mensagemEItem[1], pacoteCompleto.Participante.Ensinar.Conteudo);
                    pacoteCompleto.Participante.Ensinar.AdicionarItemWithMessage(mensagemEItem[1], this, mensagemEItem[0]);
                    LimparEListar(campo,pacoteCompleto.ListView,pacoteCompleto.ListaItens);
                    break;
            }
        }

        private void LimparEListar(TextView campo, ListView listar, ListaItens lista)
        {
            campo.Text = null;
            listar.Adapter = new ListAdapterHae(this, lista.Conteudo);
        }
    }
}