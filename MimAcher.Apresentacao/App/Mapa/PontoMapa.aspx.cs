using System;
using System.Drawing;
using System.Web.UI;
using MimAcher.Aplicacao;
using MimAcher.Dominio;
using Subgurim.Controles;
using Subgurim.Controles.GoogleChartIconMaker;

namespace MimAcher.Apresentacao.App.Mapa
{
    public partial class PontoMapa : Page
    {
        public GestorDeParticipante GestorDeParticipante { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            GestorDeParticipante = new GestorDeParticipante();

            ExibirTodosOsPontosNoMapa();
        }

        protected void ExibirTodosOsPontosNoMapa()
        {
            MA_PARTICIPANTE participante = (MA_PARTICIPANTE)Session["participante"];
                        
            GLatLng mainLocation = new GLatLng(Convert.ToDouble(participante.geolocalizacao.Latitude), Convert.ToDouble(participante.geolocalizacao.Longitude));
            GMap1.setCenter(mainLocation, 15);

            XPinLetter xpinLetter = new XPinLetter(PinShapes.pin_star, "H", Color.Blue, Color.White, Color.Chocolate);
            GMap1.Add(new GMarker(mainLocation, new GMarkerOptions(new GIcon(xpinLetter.ToString(), xpinLetter.Shadow()))));

        }
    }
}