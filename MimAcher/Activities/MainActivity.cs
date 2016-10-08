using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MimAcher.Entidades;
using System.Collections.Generic;
using MimAcher.Activities;

namespace MimAcher
{
    [Activity(Label = "MimAcher", Theme = "@style/Theme.Splash")]
    public class MainActivity : Activity
    {
        string campus = null;
        string senha = null;
        string nome = "Gasparzinho";
        string email = null;
        string nascimento = null;
        string telefone = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Iniciando váriaveis
            EditText usuario = FindViewById<EditText>(Resource.Id.usuario);
            EditText senha = FindViewById<EditText>(Resource.Id.senha);

            // Resgatando o que foi digitado nos EditText
            usuario.TextChanged += (object sender, Android.Text.TextChangedEventArgs u) => {
                string user = u.Text.ToString();
            };

            senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs p) => {
                string password = p.Text.ToString();
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

