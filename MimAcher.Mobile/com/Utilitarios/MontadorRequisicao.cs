using System.Net;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class MontadorRequisicao
    {
        private static string url = "http://ghoststation.ddns.net:8092/";

        public static WebRequest MontarRequisicaoPostUsuario()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "usuarioparticipante/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoPostItem()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "item/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoGetCampi()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "campus/list");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Get;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoGetItem()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "item/list");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Get;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoPostHobbie()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "participantehobbie/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoPostAprender()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "participanteaprender/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }

        public static WebRequest MontarRequisicaoPostEnsinar()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "participanteensinar/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = WebRequestMethods.Http.Post;

            return requisicao;
        }
    }
}