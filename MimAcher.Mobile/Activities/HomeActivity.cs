using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using MimAcher.Mobile.Activities.TAB;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;
using MimAcher.Mobile.Utilitarios;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "ResultadoActivity", Theme = "@style/Theme.Splash")]
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class HomeActivity : FabricaTelasComTab

#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        //Variaveis globais
        private SearchView _searchView;
        private Participante _participante;
        private FloatingActionButton _fab;

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
            BotaoFlutanteOpcoes();

        }

        private void BotaoFlutanteOpcoes()
        {
            _fab.Click += (s, arg) =>
            {
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

                    if (activityescolhida != null)IniciarOutraTela(activityescolhida, _participante);
                };
                menu.Show();
            };

        }
        public override void OnBackPressed() { }
        //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_search, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //Define as funcionalidades deste menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_search:
                    _searchView = new SearchView(this);
                    _searchView.SetQuery("Pesquisar",true);
                    break;
                case Resource.Id.menu_location:
                    RegistrarLocalizacao();
                    break;
                case Resource.Id.menu_exitapp:
                    Mensagens.MensagemDeLogout(this,this);
                    break;
                case Resource.Id.menu_preferences:
                    IniciarEditarPerfil(this, _participante);
                    //TestarGeolocalizacao();
                    break;
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

        private void RegistrarLocalizacao()
        {
            Mensagens.MensagemParaRegistrarGeolocalizacao(this, _participante);
        }

        public void Logout()
        {
            IniciarMain(this);
            Finish();
        }

        private void TestarGeolocalizacao()
        {
            var localizacao = _participante.Localizacao.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var toast = $"Coordenadas:\n lat{localizacao[0]} long{localizacao[1]}";
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        }
        
    }



}




