using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "EditarPerfilActivity", Theme = "@style/Theme.Splash")]
    public class EditarPerfilActivity : FabricaTelasSemProcedimento
    {
        //Variaveis globais
        private string _nome;
        private string _nascimento;
        private string _telefone;
        private Participante _participante;
        private PacoteAbstrato _pacote;

        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            _participante = Participante.BundleToParticipante(participanteBundle);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.EditarPerfil);

            //Iniciando as variaveis do contexto
            var salvar = FindViewById<Button>(Resource.Id.salvar);
            var alterarSenha = FindViewById<TextView>(Resource.Id.alterar_senha);
            var telefoneInfoUser = FindViewById<EditText>(Resource.Id.tel_number_user);
            var nomeInfoUser = FindViewById<EditText>(Resource.Id.nome_info_user);
            var dtNascimentoInfoUser = FindViewById<EditText>(Resource.Id.dt_nascimento_info_user);
            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            
            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.SetTitle(Resource.String.TitleEditarPerfil);
            telefoneInfoUser.Hint = _participante.Telefone;
            nomeInfoUser.Hint = _participante.Nome;
            dtNascimentoInfoUser.Hint = _participante.Nascimento;

            //Funcionalidades
            //Para Exibir
            _nome = _participante.Nome;
            _telefone = _participante.Telefone;
            _nascimento = _participante.Nascimento;

            //Pegar as informações inseridas
            nomeInfoUser.TextChanged += (sender, nomecapturado) => _nome = nomecapturado.Text.ToString();
            dtNascimentoInfoUser.TextChanged += (sender, nascimentocapturado) => _nascimento = nascimentocapturado.Text.ToString();
            telefoneInfoUser.TextChanged += (sender, telefonecapturado) => _telefone = telefonecapturado.Text.ToString();

            alterarSenha.Click += delegate
            {
                _pacote = _participante;
                IniciarAlterarSenha(this,_pacote);
            };

            salvar.Click += delegate
            {
                SalvarPerfilEditado();
            };
        }
        
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_nosearch, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_home:
                    _pacote = _participante;
                    IniciarHome(this,_pacote);
                    return true;

                case Resource.Id.menu_preferences:
                    //chamar configurações??
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        
        private void SalvarPerfilEditado()
        {
            var resultadoactivity = new Intent(this, typeof(HomeActivity));
            AlterarParticipante(_participante);
            _pacote = _participante;
            IniciarOutraTela(resultadoactivity,_pacote);
        }
        
        private void AlterarParticipante(Participante participante)
        {
            participante.Nome = _nome;
            participante.Telefone = _telefone;
            participante.Nascimento = _nascimento;
        }
    }
}