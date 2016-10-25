using Android.App;
using Android.Content;
using Android.Support.Design.Widget;
using Android.Views;
using Android.Widget;
using AlertDialog = Android.Support.V7.App.AlertDialog;

namespace MimAcher.Mobile.Utilitarios
{
    public static class Mensagens
    {
        public static void MensagemDeInformacaoInvalidaPadrao(Context contexto, string informacao)
        {
            var toast = $"Informação Invalida: {informacao}";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
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

        public static void MensagemDeRegistrarGeolocalizacao(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Você deseja registrar sua localização?");
            alert.SetMessage("Registre para gente o local onde você mora, para que possamos sugerir as pessoas que estão mais próximas de você");
            alert.SetPositiveButton("Sim", (senderAlert, args) => {//registrar a localização

                Toast.MakeText(contexto, "Localização registrada!", ToastLength.Short).Show();
            });
            alert.SetNegativeButton("Não", (senderAlert, args) => {//registrar a localização

                Toast.MakeText(contexto, "Ok, sua localização não será registrada", ToastLength.Short).Show();
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
    }
}