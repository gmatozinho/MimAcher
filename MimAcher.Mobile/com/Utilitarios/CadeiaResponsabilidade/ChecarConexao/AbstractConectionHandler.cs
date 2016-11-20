using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Net;

namespace MimAcher.Mobile.com.Utilitarios.CadeiaResponsabilidade.ChecarConexao
{
    public abstract class AbstractConectionHandler
    {
        protected ChecagemEnum Checagem;
        private AbstractConectionHandler _proximaOpcao;
        public enum ChecagemEnum { ConexaoServidor, RedeStatus, ConexaoInternet };

        protected AbstractConectionHandler(ChecagemEnum checagem)
        {
            Checagem = checagem;
        }

        public void SetProximaOpcao(AbstractConectionHandler proximaOpcao)
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