using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using MimAcher.Entidades;
using System.Collections.Generic;

namespace MimAcher
{
    [Activity(Label = "MimAcher", Theme = "@style/Theme.Splash")]
    public class MainActivity : Activity
    {
        //até comunicar com o banco informações hipotéticas
        readonly string campus = "Serra";
        readonly string senha = null;
        readonly string nome = "Gasparzinho";
        readonly string email = null;
        readonly string nascimento = "09/10/1995";
        readonly string telefone = "00000000";
        string user_email;
        string user_password;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Iniciando váriaveis
            EditText campo_e_mail = FindViewById<EditText>(Resource.Id.email);
            EditText campo_senha = FindViewById<EditText>(Resource.Id.senha);

            // Resgatando o que foi digitado nos EditText
            campo_e_mail.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                user_email = e.Text.ToString();
            };

            campo_senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs p) => {
                user_password = p.Text.ToString();
            };


            //Initializing button from layout
            Button entrar = FindViewById<Button>(Resource.Id.entrar);
            Button inscrevase = FindViewById<Button>(Resource.Id.inscrevase);

            //Login button click action, e passando o nome do usuário para próxima activity
            entrar.Click += delegate {
                Participante participante = new Participante(CriarDicionarioDeInformacoes());
                var resultadoActivity = new Intent(this, typeof(ResultadoActivity));
                resultadoActivity.PutExtra("member",participante.ParticipanteToBundle());
                StartActivity(resultadoActivity);
            };
            //Tenho que fazer a autenticação no banco de dados
            //Ideia é buscar usuario no banco, se existir retorna true e checa senha, se nao retorna usuario inexistente
            //Busca senha neste mesmo usuario, se for igual retorna true se nao retorna senha invalida

            inscrevase.Click += delegate {
                StartActivity(typeof(InscreverActivity));
            };
        }

        //função temporaria
        //deve pegar o usuario no banco
        private Dictionary<string, string> CriarDicionarioDeInformacoes()
        {
            Dictionary<string, string> informacoes = new Dictionary<string, string>();
            informacoes["campus"] = campus;
            informacoes["senha"] = senha;
            informacoes["email"] = email;
            informacoes["nome"] = nome;
            informacoes["telefone"] = telefone;
            informacoes["nascimento"] = nascimento;

            return informacoes;
        }
        
    }

    




}

