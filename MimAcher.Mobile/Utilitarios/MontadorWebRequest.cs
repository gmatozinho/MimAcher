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
    public static class MontardorRequisicao
    {
        private static string url = "http://ghoststation.ddns.net:8091/";

        public static WebRequest MontarRequisicaoUsuario()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "usuario/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = "POST";

            return requisicao;
        }

        public static WebRequest MontarRequisicaoParticipante()
        {
            var requisicao = (HttpWebRequest)WebRequest.Create(url + "participante/add");
            requisicao.ContentType = "application/json";
            requisicao.Method = "POST";

            return requisicao;
        }
    }
}