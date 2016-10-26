using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using MimAcher.Mobile.Activities.TAB;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;
using FloatingActionButton = com.refractored.fab.FloatingActionButton;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "ResultadoActivity", Theme = "@style/Theme.Splash")]
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class HomeActivity : FabricaTelasComTab, ILocationListener
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        //Variaveis globais
        private static readonly string Tag = "X:" + typeof(HomeActivity).Name;
        private Participante _participante;
        private FloatingActionButton _fab;
        private Location _currentLocation;
        private LocationManager _locationManager;
        private string _locationProvider;
        private TextView _locationText;
        private TextView _addressText;

        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);

            //Recebendo o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            _participante = Participante.BundleToParticipante(participanteBundle);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Home);
            //Iniciando as variaveis do contexto
            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            _fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            SetActionBar(toolbar);
            //Modificando a parte textual
            ActionBar.SetTitle(Resource.String.TitleHome);

            //Criando os tabs
            CreateTab(typeof(ResultHobbiesActivity), GetString(Resource.String.TitleHobbies));
            CreateTab(typeof(ResultAprenderActivity), GetString(Resource.String.TitleAprender));
            CreateTab(typeof(ResultEnsinarActivity), GetString(Resource.String.TitleEnsinar));

            //Iniciando o botão flutuante
            FabOptions();           

        }

        private void FabOptions()
        {
            _fab.Click += (s, arg) => {
                var menu = new PopupMenu(this, _fab);
                menu.Inflate(Resource.Drawable.button_result_menu);

                menu.MenuItemClick += (s1, arg1) =>
                {
                    Intent activityescolhida = null;

                    switch (arg1.Item.TitleFormatted.ToString())
                    {
                        case "Hobbies":
                            activityescolhida = new Intent(this, typeof(HobbiesActivity));
                            break;
                        case "Aprender":
                            activityescolhida = new Intent(this, typeof(QueroAprenderActivity));
                            break;
                        case "Ensinar":
                            activityescolhida = new Intent(this, typeof(QueroEnsinarActivity));
                            break;
                    }

                    if (activityescolhida != null) IniciarOutraTela(activityescolhida, _participante);
                    
                };
                menu.Show();
            };

        }
        
        //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_search, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //Define as funcionalidades deste menu
        /// <inheritdoc />
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_search:
                    //do something
                    return true;
                case Resource.Id.menu_location:
                    InitializeLocationManager();
                    return true;

                case Resource.Id.menu_preferences:
                    IniciarEditarPerfil(this, _participante);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        //Cria os tabs
        private void CreateTab(Type activityType, string label)
        {

            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.PutExtra("member", _participante.ParticipanteToBundle());
            var spec = TabHost.NewTabSpec(label);
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            var drawableIcon = Resources.GetDrawable(Resource.Drawable.abc_tab_indicator_material);
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            spec.SetIndicator(label, drawableIcon);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }

        private void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            var criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            var acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
            }
            Log.Debug(Tag, "Using " + _locationProvider + ".");
        }
        /*protected override void OnResume()
        {
            base.OnResume();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
        }*/

        /*protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
        }*/
        
        public async void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                _locationText.Text = "Unable to determine your location. Try again in a short while.";
            }
            else
            {
                _locationText.Text = string.Format("{0:f6},{1:f6}", _currentLocation.Latitude, _currentLocation.Longitude);
                Address address = await ReverseGeocodeCurrentLocation();
                DisplayAddress(address);
            }
        }

        private async Task<Address> ReverseGeocodeCurrentLocation()
        {
            Geocoder geocoder = new Geocoder(this);
            IList<Address> addressList =
                await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

            Address address = addressList.FirstOrDefault();
            return address;
        }

        void DisplayAddress(Address address)
        {
            if (address != null)
            {
                StringBuilder deviceAddress = new StringBuilder();
                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.Append(address.GetAddressLine(i));
                }
                // Remove the last comma from the end of the address.
                _addressText.Text = deviceAddress.ToString();
            }
            else
            {
                _addressText.Text = "Unable to determine the address. Try again in a few minutes.";
            }
        }

        public void OnProviderDisabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnProviderEnabled(string provider)
        {
            throw new NotImplementedException();
        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            throw new NotImplementedException();
        }
    }

}

