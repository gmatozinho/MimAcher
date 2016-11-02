using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;
using System.Drawing;

namespace MimAcher.Apresentacao.App.Mapa
{
    public partial class PontoMapa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExibirTodosOsPontosNoMapa()
        {
            MA_PARTICIPANTE participante = (MA_PARTICIPANTE)Session["participante"];
                        
            GLatLng mainLocation = new GLatLng(Convert.ToDouble(participante.geolocalizacao.Latitude), Convert.ToDouble(participante.geolocalizacao.Longitude));
            this.GMap1.setCenter(mainLocation, 15);

            XPinLetter xpinLetter = new XPinLetter(PinShapes.pin_star, "H", Color.Blue, Color.White, Color.Chocolate);
            this.GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));

        }
    }
}