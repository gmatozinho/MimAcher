using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Services;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "AlterarSenhaActivity", Theme = "@style/Theme.Splash")]
    public class AlterarSenhaActivity : FabricaTelasSemProcedimento
    {
        //Variaveis globais
        private string _novasenha;
        private string _repitasenha;
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
            SetContentView(Resource.Layout.AlterarSenha);

            //Iniciando as variaveis do contexto
            var novaSenha = FindViewById<EditText>(Resource.Id.nova_senha);
            var repitaNovaSenha = FindViewById<EditText>(Resource.Id.repita_nova_senha);
            var confirmar = FindViewById<Button>(Resource.Id.confirmar);

            //Funcionalidades
            //Pegar as informações inseridas
            novaSenha.TextChanged += (sender, novasenhacapturada) => _novasenha = novasenhacapturada.Text.ToString();
            repitaNovaSenha.TextChanged += (sender, repitasenhacapturada) => _repitasenha = repitasenhacapturada.Text.ToString();

            confirmar.Click += delegate
            {
                ChecarSenhas();
            };
            
        }

        private void ChecarSenhas()
        {
            if (Validador.ValidarConfirmarSenha(_novasenha, _repitasenha))
                SalvarAlteracao();
            else
                ManterUsuarioNaTela();
        }

        public void SalvarAlteracao()
        {
            _participante.Senha = _novasenha;
            const string toast = ("Senha Alterada");
            Toast.MakeText(this, toast, ToastLength.Long).Show();

            _pacote = _participante;
            IniciarEditarPerfil(this,_pacote);
        }

        public void ManterUsuarioNaTela()
        {
            const string toast = ("As senhas estão diferentes");
            Toast.MakeText(this, toast, ToastLength.Long).Show();

            _pacote = _participante;
            IniciarAlterarSenha(this, _pacote);
        }
    }
}