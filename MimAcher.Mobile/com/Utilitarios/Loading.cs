using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class Loading
    {

        public static void MyButtonClicked(TelaENomeParaLoading telaENome, Participante participante)
        {
            var activity = telaENome.Tela;

            var progressDialog = ProgressDialog.Show(activity, null, "Comunicando com o servidor...", true);
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            var myProgressBar = new ProgressBar(activity) {Visibility = ViewStates.Visible};
            ThreadStart thSt = delegate { RunMyMethod(telaENome, myProgressBar, participante); };
            var mythread = new Thread(thSt);
            mythread.Start();
        }


        private static void MyMethod(TelaENomeParaLoading telaENome, PacoteAbstrato participante)
        {
            var tela = (IFabricaTelas) telaENome.Tela;
            var nometela = telaENome.NomeTela;
            Thread.Sleep(5000); //take 5 secs to do it's job
            if (nometela == "Inscrever") tela.IniciarInscrever();
            if (nometela == "Entrar") tela.IniciarHome((Activity) tela, participante);
        }

        private static void RunMyMethod(TelaENomeParaLoading telaENome, View myProgressBar, PacoteAbstrato participante)
        {
            var activity = telaENome.Tela;
            activity.RunOnUiThread(() => MyMethod(telaENome, participante));
            activity.RunOnUiThread(() => myProgressBar.Visibility = ViewStates.Gone);
            
        }
    }
 
}