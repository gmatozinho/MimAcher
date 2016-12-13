using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace MimAcher.Apresentacao.App
{
    public partial class ImpressaoRelacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string encoding = string.Empty;
            string extension = string.Empty;
            byte[] byteViewer;

            byteViewer = (byte[])Session["NomeArquivo"];

            if (byteViewer != null)
            {
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", byteViewer.Length.ToString());
                Response.BinaryWrite(byteViewer);
            }
        }
    }
}