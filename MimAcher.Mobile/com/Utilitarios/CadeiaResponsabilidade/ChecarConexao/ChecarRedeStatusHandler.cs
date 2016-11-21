using Android.Content;
using Android.Net;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao
{
    public class ChecarRedeStatusHandler : AbstractConnectionHandler
    {

        public ChecarRedeStatusHandler(ChecagemEnum checagem) : base(checagem)
        {
            Checagem = checagem;
        }

        public override bool CheckConnection(Context activity, ConnectivityManager connectivityManager)
        {
            var activeConnection = connectivityManager.ActiveNetworkInfo;
            var isOnline = (activeConnection != null) && activeConnection.IsConnected;

            if (!isOnline)
            {
                Write(activity);
            }

            return isOnline;
        }

        public override void Write(Context activity)
        {
            Mensagens.MensagemInternetDesativada(activity);
        }
    }
}