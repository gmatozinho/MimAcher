using Android.Content;
using Android.Net;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao
{
    public static  class ChecagemConexao
    {

        public static void ChecarConexão(Context activity, ConnectivityManager connectivityManager)
        {
            AbstractConnectionHandler redeStatus = new ChecarRedeStatusHandler(AbstractConnectionHandler.ChecagemEnum.RedeStatus);
            AbstractConnectionHandler conexaoServidor = new ChecarConexaoServidorHandler(AbstractConnectionHandler.ChecagemEnum.ConexaoServidor);
            AbstractConnectionHandler conexaoInternet = new ChecarConexaoInternetHandler(AbstractConnectionHandler.ChecagemEnum.ConexaoInternet);

            redeStatus.SetProximaOpcao(conexaoInternet);
            conexaoInternet.SetProximaOpcao(conexaoServidor);

            redeStatus.ConnectiontHandler(activity, connectivityManager);
            
        }



    }
}