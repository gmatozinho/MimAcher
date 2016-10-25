using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Net;

namespace MimAcher.Mobile.Utilitarios
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
    }
}