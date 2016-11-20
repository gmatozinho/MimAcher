using System.Net.NetworkInformation;
using Android.Content;
using Android.Net;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao
{
    public class ChecarConexaoInternetHandler : AbstractConectionHandler
    {
        public ChecarConexaoInternetHandler(ChecagemEnum checagem) : base(checagem)
        {
            Checagem = checagem;
        }

        public override bool CheckConnection(Context activity, ConnectivityManager connectivityManager)
        {
            const string url = "www.google.com.br";

            var pingSender = new Ping();
            var reply = pingSender.Send(url);
            var resultado = reply.Status.ToString().Equals("Success");

            if (!resultado)
            {
                Write(activity);
            }

            return resultado;
        }

        public override void Write(Context activity)
        {
            Mensagens.MensagemInternetAtivadaMasComProblema(activity);
        }
    }
}