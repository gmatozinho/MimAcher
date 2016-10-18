using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Entidades;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "EditarPerfilActivity", Theme = "@style/Theme.Splash")]
    public class EditarPerfilActivity : Activity
    {
        //Variaveis globais
        private Bundle _participanteBundle;
        private string _nome;
        private string _nascimento;
        private string _telefone;

        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo o bundle(Objeto participante)
            _participanteBundle = Intent.GetBundleExtra("member");
            var participante = Participante.BundleToParticipante(_participanteBundle);

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
            telefoneInfoUser.Hint = participante.Telefone;
            nomeInfoUser.Hint = participante.Nome;
            dtNascimentoInfoUser.Hint = participante.Nascimento;

            //Funcionalidades
            //Para alterar
            _nome = participante.Nome;
            _telefone = participante.Telefone;
            _nascimento = participante.Nascimento;

            //Pegar as informações inseridas
            nomeInfoUser.TextChanged += (sender, n) => _nome = n.Text.ToString();
            dtNascimentoInfoUser.TextChanged += (sender, n) => _nascimento = n.Text.ToString();
            telefoneInfoUser.TextChanged += (sender, t) => _telefone = t.Text.ToString();

            alterarSenha.Click += delegate
            {
                var alterarsenhaactivity = new Intent(this, typeof(AlterarSenhaActivity));
                //mudar para trabalhar com objeto do banco
                alterarsenhaactivity.PutExtra("member", _participanteBundle);
                StartActivity(alterarsenhaactivity);
            };

            salvar.Click += delegate
            {
                var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
                //mudar para trabalhar com objeto do banco
                //deverá rolar um commit para salvar alterações no banco
                AlterarParticipante(participante);
                resultadoactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(resultadoactivity);
            };
        }

        //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_nosearch, menu);
            return base.OnCreateOptionsMenu(menu);
        }


        //Define as funcionalidades destes menus
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_home:
                    var resultadoctivity = new Intent(this, typeof(ResultadoActivity));
                    //mudar para trabalhar com objeto do banco
                    resultadoctivity.PutExtra("member", _participanteBundle);
                    StartActivity(resultadoctivity);
                    return true;

                case Resource.Id.menu_preferences:
                    //do something
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        //Modifica o participante com as novas informações 
        private void AlterarParticipante(Participante participante)
        {
            participante.Nome = _nome;
            participante.Telefone = _telefone;
            participante.Nascimento = _nascimento;
        }
    }
}