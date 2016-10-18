using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using MimAcher.Activities.TAB;
using MimAcher.Entidades;
using Resource = MimAcher.Resources.Resource;

namespace MimAcher.Activities
{
    [Activity(Label = "QueroEnsinarActivity", Theme = "@style/Theme.Splash")]
    public class QueroEnsinarActivity : Activity
    {
        //Variaveis globais
        private Participante _participante;
        private readonly ListaItens _listEnsinar = new ListaItens();
        private ListView _listView;

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
            var campoEnsinar = FindViewById<EditText>(Resource.Id.digite_algo);
            var ok = FindViewById<Button>(Resource.Id.ok);
            var addEnsinar = FindViewById<FloatingActionButton>(Resource.Id.add_algo);
            string ensinar = null;
            _listView = FindViewById<ListView>(Resource.Id.list);

            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.Title = "Ensinar";
            pergunta.Text = "O que você quer ensinar?";
            campoEnsinar.Hint = "Digite algo para ensinar";

            //Funcionalidades           
            campoEnsinar.TextChanged += (sender, e) => ensinar = e.Text.ToString();

            addEnsinar.Click += delegate {
                _listEnsinar.AdicionarItem(ensinar, _participante.Ensinar.Itens);
                _participante.Ensinar.AdicionarItemWithMessage(ensinar, this,"Algo para ensinar");
                campoEnsinar.Text = null;
                _listView.Adapter = new ListAdapterHae(this, _listEnsinar.Itens);
            };

            ok.Click += delegate {
                _participante.Commit();
                _listEnsinar.Clear();
                _listView.Adapter = null;

                var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
                //TODO mudar para trabalhar com objeto do banco
                resultadoactivity.PutExtra("member", _participante.ParticipanteToBundle());
                StartActivity(resultadoactivity);
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
                    _participante.Commit();
                    _listEnsinar.Clear();
                    _listView.Adapter = null;

                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    resultadoctivity.PutExtra("member", _participante.ParticipanteToBundle());
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    _participante.Commit();
                    _listEnsinar.Clear();
                    _listView.Adapter = null;

                    var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                    editaractivity.PutExtra("member", _participante.ParticipanteToBundle());
                    StartActivity(editaractivity);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        
    }
}