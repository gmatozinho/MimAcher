using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Services;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "EditarPerfilActivity", Theme = "@style/Theme.Splash")]
    public class EditarPerfilActivity : ServicoTelasSemProcedimento
    {
        //Variaveis globais
        private Bundle _participanteBundle;
        private string _nome;
        private string _nascimento;
        private string _telefone;
        private Participante _participante;

        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo o bundle(Objeto participante)
            _participanteBundle = Intent.GetBundleExtra("member");
            _participante = Participante.BundleToParticipante(_participanteBundle);

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
            ActionBar.Title = "Editar Perfil";
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
                IniciarAlterarSenha();
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
                    IniciarHome();
                    return true;

                case Resource.Id.menu_preferences:
                    //chamar configurações??
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void IniciarAlterarSenha()
        {
            var alterarsenhaactivity = new Intent(this, typeof(AlterarSenhaActivity));
            //mudar para trabalhar com objeto do banco
            IniciarOutraTela(alterarsenhaactivity);
        }

        private void IniciarHome()
        {
            var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
            //mudar para trabalhar com objeto do banco
            IniciarOutraTela(resultadoctivity);
        }
        
        private void SalvarPerfilEditado()
        {
            var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
            AlterarParticipante(_participante);
            IniciarOutraTela(resultadoactivity);
        }

        public void IniciarOutraTela(Intent activitydesejada)
        {
            activitydesejada.PutExtra("member", _participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        private void AlterarParticipante(Participante participante)
        {
            participante.Nome = _nome;
            participante.Telefone = _telefone;
            participante.Nascimento = _nascimento;
        }
    }
}