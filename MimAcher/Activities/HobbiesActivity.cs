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
    [Activity(Label = "HobbiesActivity", Theme = "@style/Theme.Splash")]
    public class HobbiesActivity : Activity
    {
        //Variaveis globais
        private Participante _participante;
        private readonly ListaItens _hobbies = new ListaItens();
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
            var campoHobbie = FindViewById<EditText>(Resource.Id.digite_algo);
            var ok = FindViewById<Button>(Resource.Id.ok);
            var addHobbie = FindViewById<FloatingActionButton>(Resource.Id.add_algo);
            string hobbie = null;
            _listView = FindViewById<ListView>(Resource.Id.list);
            
            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.Title = "Hobbies";
            pergunta.Text = "Quais são os seus hobbies?";
            campoHobbie.Hint = "Digite um Hobbie";

            //Funcionalidades
            campoHobbie.TextChanged += (sender, h) => hobbie = h.Text.ToString();
            
            addHobbie.Click += delegate {
                _hobbies.AdicionarItem(hobbie, _participante.Hobbies.Itens);
                _participante.Hobbies.AdicionarItemWithMessage(hobbie,this,"Hobbie");
                campoHobbie.Text = null;
                _listView.Adapter = new ListAdapterHae(this, _hobbies.Itens);
            };

            ok.Click += delegate {
                _participante.Commit();
                _hobbies.Clear();
                _listView.Adapter = null;

                var queroaprenderactivity = new Intent(this, typeof(QueroAprenderActivity));
                //TODO mudar para trabalhar com objeto do banco
                queroaprenderactivity.PutExtra("member", _participante.ParticipanteToBundle());
                StartActivity(queroaprenderactivity);
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
                    _hobbies.Clear();
                    _listView.Adapter = null;

                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    resultadoctivity.PutExtra("member", _participante.ParticipanteToBundle());
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    _hobbies.Clear();
                    _listView.Adapter = null;
                    _participante.Commit();

                    var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                    editaractivity.PutExtra("member", _participante.ParticipanteToBundle());
                    StartActivity(editaractivity);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        
    }
}