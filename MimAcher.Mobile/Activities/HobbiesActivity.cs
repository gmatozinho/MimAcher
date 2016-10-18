using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Services;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "HobbiesActivity", Theme = "@style/Theme.Splash")]
    public class HobbiesActivity : ServicoTelasComProcedimento
    {
        //Variaveis globais
        private Participante _participante;
        private readonly ListaItens _hobbies = new ListaItens();
        private ListView _listView;
        private string _hobbie;
        private EditText _campoHobbie;
        private PacotePadrao _pacotePadrao;

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
            ActionBar.Title = "Hobbies";
            pergunta.Text = "Quais são os seus hobbies?";
            _campoHobbie.Hint = "Digite um Hobbie";

            //Funcionalidades
            _campoHobbie.TextChanged += (sender, hobbiecapturado) => _hobbie = hobbiecapturado.Text.ToString();
            
            addHobbie.Click += delegate {
                _pacotePadrao = new PacotePadrao(_hobbies, _participante, _listView);
                InserirItem(_pacotePadrao,_campoHobbie,_hobbie);
            };

            ok.Click += delegate {
                _pacotePadrao = new PacotePadrao(_hobbies,_participante,_listView);
                IniciarQueroAprenderActivity(this,_pacotePadrao);
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
                    _pacotePadrao = new PacotePadrao(_hobbies, _participante, _listView);
                    IniciarHome(this,_pacotePadrao);
                    return true;

                case Resource.Id.menu_preferences:
                    _pacotePadrao = new PacotePadrao(_hobbies, _participante, _listView);
                    IniciarEditarPerfil(this,_pacotePadrao);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}