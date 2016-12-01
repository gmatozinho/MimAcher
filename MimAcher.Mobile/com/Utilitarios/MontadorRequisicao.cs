using System.Net;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class MontadorRequisicao
    {
        private const string Url = "http://ghoststation.ddns.net:8092/";

        public static WebRequest MontarRequisicaoPostUsuario()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "usuarioparticipante/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoPostItem()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "item/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoGetCampi()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "campus/list");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Get;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoGetItem()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "item/list");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Get;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoPostHobbie()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participantehobbie/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoPostAprender()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participanteaprender/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoPostEnsinar()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participanteensinar/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }
        
        public static WebRequest MontarRequisicaoPostLogin()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "login/login");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoUpdateParticipante()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participante/update");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoGetParticipanteHobbie()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participantehobbie/list");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Get;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoGetParticipanteAprender()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participanteaprender/list");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Get;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoGetParticipanteEnsinar()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participanteensinar/list");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Get;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoMatchHobbie()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participantehobbie/match");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoMatchAprender()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participanteaprender/match");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoMatchEnsinar()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(Url + "participanteensinar/match");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }
    }
}