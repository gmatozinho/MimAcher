using System.Net.NetworkInformation;
using Android.Content;
using Android.Net;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidadedeChecarConexao
{
    public static  class ChecagemConexao
    {

        public static bool ChecarConexão(Context activity, ConnectivityManager connectivityManager)
        {
            return ChecarInternetHabilitada(activity, connectivityManager) && ChecarConexaoComServidor(activity) && ConexaoComInternet(activity);
        }

        private static bool ChecarInternetHabilitada(Context activity, ConnectivityManager connectivityManager)
        {
            var activeConnection = connectivityManager.ActiveNetworkInfo;
            var isOnline = (activeConnection != null) && activeConnection.IsConnected;

            if (!isOnline)
            {
                Mensagens.MensagemInternetDesativada(activity);
            }

            return isOnline;
        }

        private static bool ChecarConexaoComServidor(Context activity)
        {
            const string url = "ghoststation.ddns.net";

            var pingSender = new Ping();
            var reply = pingSender.Send(url);
            var resultado = reply.Status.ToString().Equals("Success");

            if (!resultado)
            {
                Mensagens.MensagemServidorOffline(activity);
            }

            return resultado;
        }

        private static bool ConexaoComInternet(Context activity)
        {
            const string url = "www.google.com.br";

            var pingSender = new Ping();
            var reply = pingSender.Send(url);
            var resultado = reply.Status.ToString().Equals("Success");

            if (!resultado)
            {
                Mensagens.MensagemInternetAtivadaMasComProblema(activity);
            }

            return resultado;

        }


    }
}