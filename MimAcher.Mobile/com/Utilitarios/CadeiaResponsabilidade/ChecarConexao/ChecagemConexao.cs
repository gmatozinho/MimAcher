using Android.Content;
using Android.Net;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao
{
    public static  class ChecagemConexao
    {

        public static void ChecarConexão(Context activity, ConnectivityManager connectivityManager)
        {
            AbstractConnectionHandler redeStatus = new ChecarRedeStatusHandler(AbstractConnectionHandler.ChecagemTipos.RedeStatus);
            AbstractConnectionHandler conexaoServidor = new ChecarConexaoServidorHandler(AbstractConnectionHandler.ChecagemTipos.ConexaoServidor);
            AbstractConnectionHandler conexaoInternet = new ChecarConexaoInternetHandler(AbstractConnectionHandler.ChecagemTipos.ConexaoInternet);

            redeStatus.SetProximaOpcao(conexaoInternet);
            conexaoInternet.SetProximaOpcao(conexaoServidor);

            redeStatus.ConnectiontHandler(activity, connectivityManager);
            
        }



    }
}