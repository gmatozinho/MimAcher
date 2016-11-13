using Android.App;
using Android.Content;
using Android.Widget;
using MimAcher.Mobile.Activities;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;

namespace MimAcher.Mobile.Utilitarios
{
    public static class Mensagens
    {
        public static void MensagemDeInformacaoInvalidaPadrao(Context contexto, string informacao)
        {
            var toast = $"Informa��o Invalida: {informacao}";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeInformacoesEditadasComSucesso(Context contexto)
        {
            var toast = "Suas informa��es foram alteradas com sucesso";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeAdicionarItemSucesso(string item,Context activity, string text)
        {
            var toast = string.Format("{1} Inserido: {0}", item, text);
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeAdicionarItemFalha(string item, Context activity, string text)
        {
            var toast = string.Format("Voce j� possui este {1}: {0} ", item, text);
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeAdicionarItemNadaInserido(Context activity)
        {
            const string toast = ("Nada Inserido");
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeConfirmarSenhaInvalido(Context contexto)
        {
            const string toast = "As senhas n�o conferem!";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeSenhaInvalida(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Senha Invalida");
            alert.SetMessage("A senha deve ser composta de no min�mo 8 caracteres");
            alert.SetPositiveButton("Ok", (senderAlert, args) => {
                
                Toast.MakeText(contexto, "Favor, inserir uma senha v�lida!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
        
        public static void MensagemParaRegistrarGeolocalizacao(Context contexto, Participante participante)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Voc� deseja registrar sua localiza��o?");
            alert.SetMessage(
                "Registre para gente o local onde voc� mora para que possamos sugerir as pessoas que est�o mais pr�ximas de voc�.");

            alert.SetPositiveButton("Sim", async (senderAlert, args) =>
            {
                Toast.MakeText(contexto, "Sua localiza��o ser� registrada!", ToastLength.Short).Show();
                participante.Localizacao = await Geolocalizacao.CapturarLocalizacao();
            });

            alert.SetNegativeButton("N�o", (sender, args) =>
            {
                Toast.MakeText(contexto, "Sua localiza��o n�o ser� registrada", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public static void MensagemDeDataInvalida(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Data de Nascimento Invalida");
            alert.SetMessage("A Data de Nascimento deve estar de acordo com o modelo: 30/06/2002");
            alert.SetPositiveButton("Ok", (senderAlert, args) => {
                Toast.MakeText(contexto, "Favor, inserir uma data v�lida!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public static void MensagemDeLogout(Context contexto, HomeActivity home)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Deseja realizar Logout");
            alert.SetPositiveButton("Ok", (senderAlert, args) =>
            {
                home.Logout();
            });

            alert.SetNegativeButton("Cancelar", (sender, args) =>
            {
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        public static void MensagemOpcoes(string itemSelecionado, FabricaTelasComResultados resultados)
        {
            var alert = new AlertDialog.Builder(resultados);
            alert.SetTitle("Op��es");
            alert.SetMessage("Voc� deseja remover o item ou consultar combina��es?");
            alert.SetPositiveButton("Ver Combina��es", (senderAlert, args) =>
            {
                resultados.VerCombinacoes(itemSelecionado);
            });
            alert.SetNegativeButton("Remover", (senderAlert, args) =>
            {
                MensagemParaRemoverItemSelecionado(itemSelecionado, resultados);
            });
            alert.Show();
        }

        private static void MensagemParaRemoverItemSelecionado(string itemSelecionado, FabricaTelasComResultados resultados)
        {
            var alert = new AlertDialog.Builder(resultados);
            alert.SetTitle("Remover!");
            alert.SetMessage("Voc� tem certeza que deseja remover?\n\n" + itemSelecionado);
            alert.SetPositiveButton("Ok", (senderAlert, args) =>
            {
                Toast.MakeText(resultados, itemSelecionado + " foi exlu�do!", ToastLength.Short).Show();
                resultados.RemoverItemSelecionado(itemSelecionado);
            });
            alert.SetNegativeButton("Cancelar", (senderAlert, args) =>
            {
                Toast.MakeText(resultados, itemSelecionado + " n�o ser� removido!", ToastLength.Short).Show();
            });
            alert.Show();
        }


    }
}