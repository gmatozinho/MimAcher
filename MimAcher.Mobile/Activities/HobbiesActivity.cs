using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;
using ActionBar = Android.Support.V7.App.ActionBar;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "HobbiesActivity", Theme = "@style/Theme.Splash")]
    public class HobbiesActivity : FabricaTelasNormaisComProcedimento
    {
        //Variaveis globais
        private Participante _participante;
        private readonly ListaItens _hobbies = new ListaItens();
        private ListView _listView;
        private string _hobbie;
        private EditText _campoHobbie;
        private PacoteCompleto _pacoteCompleto;

        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Recebendo e transformando o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            _participante = Participante.BundleToParticipante(participanteBundle);          

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Perfil);

            //Iniciando as variaveis do contexto
            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            var pergunta = FindViewById<TextView>(Resource.Id.pergunta);
            var ok = FindViewById<Button>(Resource.Id.ok);
            var addHobbie = FindViewById<FloatingActionButton>(Resource.Id.add_algo);
            _campoHobbie = FindViewById<EditText>(Resource.Id.digite_algo);
            _listView = FindViewById<ListView>(Resource.Id.list);
            
            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.SetTitle(Resource.String.TitleHobbies);
            pergunta.SetText(Resource.String.PerguntaHobbies);
            _campoHobbie.SetHint(Resource.String.HintCampoHobbies);

            //Funcionalidades
            _campoHobbie.TextChanged += (sender, hobbiecapturado) => _hobbie = hobbiecapturado.Text.ToString();
            
            addHobbie.Click += delegate {
                string[] values = {"Hobbie", _hobbie};
                _pacoteCompleto = new PacoteCompleto(_hobbies, _participante, _listView);
                InserirItem(_campoHobbie,_pacoteCompleto,values);
            };

            ok.Click += delegate {
                _pacoteCompleto = new PacoteCompleto(_hobbies,_participante,_listView);
                IniciarQueroAprenderActivity(this,_pacoteCompleto);
            };
        }

        //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_nosearch, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //Define as funcionalidades deste menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_home:
                    _pacoteCompleto = new PacoteCompleto(_hobbies, _participante, _listView);
                    IniciarHome(this,_pacoteCompleto);
                    return true;

                case Resource.Id.menu_preferences:
                    _pacoteCompleto = new PacoteCompleto(_hobbies, _participante, _listView);
                    IniciarEditarPerfil(this,_pacoteCompleto);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}