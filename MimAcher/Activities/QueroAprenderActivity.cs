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
    [Activity(Label = "QueroAprenderActivity", Theme = "@style/Theme.Splash")]
    public class QueroAprenderActivity : Activity
    {
        //Variaveis globais
        private Participante _participante;
        private readonly ListaItens _listAprender = new ListaItens();
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
            var campoAprender = FindViewById<EditText>(Resource.Id.digite_algo);
            var ok = FindViewById<Button>(Resource.Id.ok);
            var addAprender = FindViewById<FloatingActionButton>(Resource.Id.add_algo);
            string aprender = null;
            _listView = FindViewById<ListView>(Resource.Id.list);

            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.Title = "Aprender";
            pergunta.Text = "O que você quer aprender?";
            campoAprender.Hint = "Digite algo para aprender";

            //Funcionalidades
            campoAprender.TextChanged += (sender, a) => aprender = a.Text.ToString();

            addAprender.Click += delegate {
                _listAprender.AdicionarItem(aprender, _participante.Aprender.Itens);
                _participante.Aprender.AdicionarItemWithMessage(aprender, this,"Algo para aprender");
                campoAprender.Text = null;
                _listView.Adapter = new ListAdapterHae(this, _listAprender.Itens);
            };

            ok.Click += delegate {
                _participante.Commit();
                _listAprender.Clear();
                _listView.Adapter = null;

                var queroensinaractivity = new Intent(this, typeof(QueroEnsinarActivity));
                //TODO mudar para trabalhar com objeto do banco
                queroensinaractivity.PutExtra("member", _participante.ParticipanteToBundle());
                StartActivity(queroensinaractivity);
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
                    _listAprender.Clear();
                    _listView.Adapter = null;

                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    resultadoctivity.PutExtra("member", _participante.ParticipanteToBundle());
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    _participante.Commit();
                    _listAprender.Clear();
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