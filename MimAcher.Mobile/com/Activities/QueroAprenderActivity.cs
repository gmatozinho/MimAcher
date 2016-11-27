using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "QueroAprenderActivity", Theme = "@style/Theme.Splash")]
    public class QueroAprenderActivity : FabricaTelasNormaisComProcedimento
    {
        //Variaveis globais
        private Participante _participante;
        private readonly ListaItens _listAprender = new ListaItens();
        private ListView _listView;
        private string _aprender;
        private EditText _campoAprender;
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
            var addAprender = FindViewById<FloatingActionButton>(Resource.Id.add_algo);
            _campoAprender = FindViewById<EditText>(Resource.Id.digite_algo);
            _listView = FindViewById<ListView>(Resource.Id.list);

            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.SetTitle(Resource.String.TitleAprender);
            pergunta.SetText(Resource.String.PerguntaAprender);
            _campoAprender.SetHint(Resource.String.HintCampoAprender);

            //Funcionalidades
            _campoAprender.TextChanged += (sender, a) => _aprender = a.Text.ToString();

            addAprender.Click += delegate {
                string[] values = { GetString(Resource.String.MsgCadastroAprender), _aprender };
                _pacoteCompleto = new PacoteCompleto(_listAprender, _participante, _listView);
                InserirItem(_campoAprender, _pacoteCompleto, values);
            };

            ok.Click += delegate {
                _pacoteCompleto = new PacoteCompleto(_listAprender, _participante, _listView);
                IniciarQueroEnsinarActivity(this, _pacoteCompleto);
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
                    _pacoteCompleto = new PacoteCompleto(_listAprender, _participante, _listView);
                    IniciarHome(this, _pacoteCompleto);
                    return true;

                case Resource.Id.menu_preferences:
                    _pacoteCompleto = new PacoteCompleto(_listAprender, _participante, _listView);
                    IniciarEditarPerfil(this, _pacoteCompleto);
                    return true;                
            }
            return base.OnOptionsItemSelected(item);
        }


       
    }
}