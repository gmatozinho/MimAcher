using Android.Content;
using Android.Net;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao
{
    public abstract class AbstractConnectionHandler
    {
        protected ChecagemEnum Checagem;
        private AbstractConnectionHandler _proximaOpcao;
        public enum ChecagemEnum { ConexaoServidor, RedeStatus, ConexaoInternet };

        protected AbstractConnectionHandler(ChecagemEnum checagem)
        {
            Checagem = checagem;
        }

        public void SetProximaOpcao(AbstractConnectionHandler proximaOpcao)
        {
            _proximaOpcao = proximaOpcao;
        }

        public void ConnectiontHandler(Context activity, ConnectivityManager connectivityManager)
        {
            var resultado = CheckConnection(activity, connectivityManager);
            if (!resultado || _proximaOpcao == null) return;
            _proximaOpcao.ConnectiontHandler(activity, connectivityManager);
        }

        public abstract bool CheckConnection(Context activity, ConnectivityManager connectivityManager);

        public abstract void Write(Context activity);
    }
}