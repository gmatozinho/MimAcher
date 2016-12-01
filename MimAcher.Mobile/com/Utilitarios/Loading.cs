using System;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.com.Activities;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Utilitarios
{
    public class Loading
    {

        public static void MyButtonClicked(TelaENomeParaLoading telaENome)
        {
            var activity = telaENome.Tela;
            var progressDialog = ProgressDialog.Show(activity, "", "Comunicando com o servidor...", true);
            progressDialog.SetProgressStyle(ProgressDialogStyle.Spinner);
            new Thread(new ThreadStart(async delegate
            {
                for (var i = 0; i < 100; i++) {
                    await Task.Delay(50);
                }
                   
                activity.RunOnUiThread(async () =>
                {
                    await MyMethod(telaENome, progressDialog);
                });
                
            })).Start();

        }


        private static Task MyMethod(TelaENomeParaLoading telaENome, ProgressDialog progressDialog)
        {
            Thread.Sleep(1000); //take 5 secs to do it's job
            var nometela = telaENome.NomeTela;
            if (nometela == "Inscrever")
            {
                //progressDialog.
                progressDialog.Dismiss();
                var tela = (IFabricaTelas) telaENome.Tela;
                return tela.IniciarInscrever();
            }
            if (nometela == "Entrar")
            {
                var tela = (MainActivity) telaENome.Tela;
                return tela.EventoEntrar(tela, progressDialog);
            }
            return Task.CompletedTask;
        }

    }
 
}
 