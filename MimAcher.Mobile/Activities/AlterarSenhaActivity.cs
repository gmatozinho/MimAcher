using Android.App;
using Android.OS;
using Android.Widget;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;
using MimAcher.Mobile.Utilitarios;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "AlterarSenhaActivity", Theme = "@style/Theme.Splash")]
    public class AlterarSenhaActivity : FabricaTelasSemProcedimento
    {
        //Variaveis globais
        private string _novasenha;
        private string _repitasenha;
        private Participante _participante;
        

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
            //Pegar as informa��es inseridas
            novaSenha.TextChanged += (sender, novasenhacapturada) => _novasenha = novasenhacapturada.Text.ToString();
            repitaNovaSenha.TextChanged += (sender, repitasenhacapturada) => _repitasenha = repitasenhacapturada.Text.ToString();

            confirmar.Click += delegate
            {
                ChecarAlteracao();
            };
            
        }

        private void ChecarAlteracao()
        {
            if (Validador.ValidarConfirmarSenha(_novasenha, _repitasenha))
                SalvarAlteracao();
            else
                ManterUsuarioNaTela();
        }

        private void SalvarAlteracao()
        {
            _participante.AlterarSenha(_participante.Senha, _novasenha);
            const string toast = ("Senha Alterada");
            Toast.MakeText(this, toast, ToastLength.Long).Show();

            PacoteAbstrato pacote = _participante;
            IniciarEditarPerfil(this,pacote);
        }

        private void ManterUsuarioNaTela()
        {
            const string toast = ("As senhas est�o diferentes");
            Toast.MakeText(this, toast, ToastLength.Long).Show();

            PacoteAbstrato pacote = _participante;
            IniciarAlterarSenha(this, pacote);
        }
    }
}