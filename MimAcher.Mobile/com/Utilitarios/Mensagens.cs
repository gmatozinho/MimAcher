using Android.App;
using Android.Content;
using Android.Widget;
using MimAcher.Mobile.com.Activities;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class Mensagens
    {
        public static void MensagemDeInformacaoInvalidaPadrao(Context contexto, string informacao)
        {
            var toast = $"Informação Invalida: {informacao}";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeInformacoesEditadasComSucesso(Context contexto)
        {
            var toast = "Suas informações foram alteradas com sucesso";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeAdicionarItemSucesso(string item,Context activity, string text)
        {
            var toast = string.Format("{1} Inserido: {0}", item, text);
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeAdicionarItemFalha(string item, Context activity, string text)
        {
            var toast = string.Format("Voce já possui este {1}: {0} ", item, text);
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeAdicionarItemNadaInserido(Context activity)
        {
            const string toast = ("Nada Inserido");
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeConfirmarSenhaInvalido(Context contexto)
        {
            const string toast = "As senhas não conferem!";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        public static void MensagemDeSenhaInvalida(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Senha Invalida");
            alert.SetMessage("A senha deve ser composta de no minímo 8 caracteres");
            alert.SetPositiveButton("Ok", (senderAlert, args) => {
                
                Toast.MakeText(contexto, "Favor, inserir uma senha válida!", ToastLength.Short).Show();
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
        
        public static void MensagemParaRegistrarGeolocalizacao(Context contexto, Participante participante)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Você deseja registrar sua localização?");
            alert.SetMessage(
                "Registre para gente o local onde você mora para que possamos sugerir as pessoas que estão mais próximas de você.");

            alert.SetPositiveButton("Sim", async (senderAlert, args) =>
            {
                Toast.MakeText(contexto, "Sua localização será registrada!", ToastLength.Short).Show();
                participante.Localizacao = await Geolocalizacao.CapturarLocalizacao();
            });

            alert.SetNegativeButton("Não", (sender, args) =>
            {
                Toast.MakeText(contexto, "Sua localização não será registrada", ToastLength.Short).Show();
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
                Toast.MakeText(contexto, "Favor, inserir uma data válida!", ToastLength.Short).Show();
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
            alert.SetTitle("Opções");
            alert.SetMessage("Você deseja remover o item ou consultar combinações?");
            alert.SetPositiveButton("Ver Combinações", (senderAlert, args) =>
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
            alert.SetMessage("Você tem certeza que deseja remover?\n\n" + itemSelecionado);
            alert.SetPositiveButton("Ok", (senderAlert, args) =>
            {
                Toast.MakeText(resultados, itemSelecionado + " foi exluído!", ToastLength.Short).Show();
                resultados.RemoverItemSelecionado(itemSelecionado);
            });
            alert.SetNegativeButton("Cancelar", (senderAlert, args) =>
            {
                Toast.MakeText(resultados, itemSelecionado + " não será removido!", ToastLength.Short).Show();
            });
            alert.Show();
        }

        public static void MensagemServidorOnline(Context activity)
        {
            const string toast = "Servidor Online";
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        public static void MensagemServidorOffline(Context activity)
        {
            var alert = new AlertDialog.Builder(activity);
            alert.SetTitle("Notificação:");
            alert.SetMessage("Desculpe o transtorno, estamos enfrentando problemas com o servidor, tente novamente mais tarde.");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }

        public static void MensagemInternetDesativada(Context activity)
        {
            var alert = new AlertDialog.Builder(activity);
            alert.SetTitle("Notificação:");
            alert.SetMessage("Por favor verifique se o seu wifi está ligado");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }

        public static void MensagemInternetAtivadaMasComProblema(Context activity)
        {
            var alert = new AlertDialog.Builder(activity);
            alert.SetTitle("Notificação:");
            alert.SetMessage("Por favor verifique sua conexão com a internet!");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }




    }
}