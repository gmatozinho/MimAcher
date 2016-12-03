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
            new Thread(new ThreadStart(delegate
            {
                Thread.Sleep(4 * 1000);
                activity.RunOnUiThread(() =>
                {
                    MyMethod(telaENome, progressDialog);
                    progressDialog.Dismiss();
                });
                
            })).Start();

        }


        private static void MyMethod(TelaENomeParaLoading telaENome, ProgressDialog progressDialog)
        {
            var nometela = telaENome.NomeTela;
            if (nometela == "Inscrever")
            {
                var tela = (IFabricaTelas) telaENome.Tela;
                tela.IniciarInscrever();
            }
            if (nometela == "Entrar")
            {
                var tela = (MainActivity) telaENome.Tela;
                tela.EventoEntrar(tela, progressDialog);
            }
        }

    }
 
}
 