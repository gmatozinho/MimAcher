using System.Globalization;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace MimAcher.Mobile.Utilitarios
{
    public static class Geolocalizacao
    {
        public static async Task<string> CapturarLocalizacao()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 100; //100 is new default
            var position = await locator.GetPositionAsync(10000);
            var latitude = position.Latitude.ToString(CultureInfo.InvariantCulture);
            var longitude = position.Longitude.ToString(CultureInfo.InvariantCulture);

            var localizacao =  latitude + "/" + longitude;
            return localizacao;
        }

    }
}