using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using MimAcher.Mobile.com.Activities.TAB;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "ResultadoActivity", Theme = "@style/Theme.Splash")]
#pragma warning disable CS0618 // O tipo ou membro � obsoleto
    public class HomeActivity : FabricaTelasComTab

#pragma warning restore CS0618 // O tipo ou membro � obsoleto
    {
        //Variaveis globais
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

            PreencherPreferenciasParticipante();
            //ChecarPreferenciasParticipante();

            //Criando os tabs
            CreateTab(typeof(ResultHobbiesActivity), GetString(Resource.String.TitleHobbies), _participante);
            CreateTab(typeof(ResultAprenderActivity), GetString(Resource.String.TitleAprender), _participante);
            CreateTab(typeof(ResultEnsinarActivity), GetString(Resource.String.TitleEnsinar), _participante);

            //Iniciando o bot�o flutuante
            BotaoFlutanteOpcoes();

            
        }

        private void ChecarPreferenciasParticipante()
        {
            var listaParaTestar = new ListaItens();

            if (_participante.Aprender == listaParaTestar || _participante.Ensinar == listaParaTestar ||
                _participante.Hobbies == listaParaTestar)
            {
                PreencherPreferenciasParticipante();
            }
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

        private void PreencherPreferenciasParticipante()
        {
            //Obter lista de itens do sistema
            var itens = CursorBd.ObterItens();
            //Montar hobbies, aprender e ensinar
            var relacoesdoparticipantecomitens = CursorBd.ObterParticipanteItens(Convert.ToInt32(_participante.CodigoParticipante), itens);
            _participante.Hobbies.Conteudo = relacoesdoparticipantecomitens["hobbie"];
            _participante.Aprender.Conteudo = relacoesdoparticipantecomitens["aprender"];
            _participante.Ensinar.Conteudo = relacoesdoparticipantecomitens["ensinar"];
        }

        public override void OnBackPressed()
        {
            OnPause();
        }

        //Cria o menu de op��es
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
                    var searchView = new SearchView(this);
                    searchView.SetQuery("Pesquisar",true);
                    break;
                case Resource.Id.menu_location:
                    RegistrarLocalizacao();
                    CursorBd.AtualizarParticipante(_participante);
                    break;
                case Resource.Id.menu_exitapp:
                    Mensagens.MensagemDeLogout(this,this);
                    break;
                case Resource.Id.menu_preferences:
                    IniciarEditarPerfil(this, _participante);
                    break;
            }

            return base.OnOptionsItemSelected(item);
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
        
    }



}




