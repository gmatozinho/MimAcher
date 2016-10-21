using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using MimAcher.Entidades;

namespace MimAcher.Activities
{
    [Activity(Label = "AlterarSenhaActivity", Theme = "@style/Theme.Splash")]
    public class AlterarSenhaActivity : Activity
    {
        //Variaveis globais
        private string _novasenha;
        private string _repitasenha;
        Participante _participante;

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
            novaSenha.TextChanged += (sender, n) => _novasenha = n.Text.ToString();
            repitaNovaSenha.TextChanged += (sender, r) => _repitasenha = r.Text.ToString();

            confirmar.Click += delegate
            {
                ChecarSenha();
                
            };
            
        }

        private void ChecarSenha()
        {
            if (_repitasenha == _novasenha)
            {
                _participante.Senha = _novasenha;
                const string toast = ("Senha Alterada");
                Toast.MakeText(this, toast, ToastLength.Long).Show();

                var editarperfilactivity = new Intent(this, typeof(EditarPerfilActivity));
                //mudar para trabalhar com objeto do banco
                //deverá rolar um commit para salvar alterações no banco                
                editarperfilactivity.PutExtra("member", _participante.ParticipanteToBundle());
                StartActivity(editarperfilactivity);
            }
            else
            {
                const string toast = ("As senhas estão diferentes");
                Toast.MakeText(this, toast, ToastLength.Long).Show();

                var alterarsenhaactivity = new Intent(this, typeof(AlterarSenhaActivity));
                //mudar para trabalhar com objeto do banco
                //deverá rolar um commit para salvar alterações no banco                
                alterarsenhaactivity.PutExtra("member", _participante.ParticipanteToBundle());
                StartActivity(alterarsenhaactivity);
            }
        }

        
    }
}