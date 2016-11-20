using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Android.Content;
using Android.Net;
using static MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao.AbstractConectionHandler;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao
{
    public static  class ChecagemConexao
    {

        public static void ChecarConexão(Context activity, ConnectivityManager connectivityManager)
        {
            AbstractConectionHandler redeStatus = new ChecarRedeStatusHandler(ChecagemEnum.RedeStatus);
            AbstractConectionHandler conexaoServidor = new ChecarConexaoServidorHandler(ChecagemEnum.ConexaoServidor);
            AbstractConectionHandler conexaoInternet = new ChecarConexaoInternetHandler(ChecagemEnum.ConexaoInternet);

            redeStatus.SetProximaOpcao(conexaoInternet);
            conexaoInternet.SetProximaOpcao(conexaoServidor);

            redeStatus.ConnectiontHandler(activity, connectivityManager);
            
        }



    }
}