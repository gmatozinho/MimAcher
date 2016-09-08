using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MimAcher.SourceCode;

namespace MimAcher
{
    [Activity(Label = "InscreverActivity", Theme = "@style/Theme.Splash")]
    public class InscreverActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Inscrever);
            //Initializing button and variables from layout
            string usuario = "Fulano";
            string senha = null;
            string nome = null;
            string email = null;
            string nascimento = null;
            string telefone = null;

            //Resgatando o que foi digitado nos EditText e button
            Button botao_avan�ar = FindViewById<Button>(Resource.Id.avan�ar);
            EditText campo_usuario = FindViewById<EditText>(Resource.Id.usuario);
            EditText campo_senha = FindViewById<EditText>(Resource.Id.senha);
            EditText campo_nome = FindViewById<EditText>(Resource.Id.nome);
            EditText campo_e_mail = FindViewById<EditText>(Resource.Id.email);
            EditText campo_dt_nascimento = FindViewById<EditText>(Resource.Id.dt_nascimento);
            EditText campo_telefone = FindViewById<EditText>(Resource.Id.telefone);

            //Pegar as informa��es inseridas
            campo_usuario.TextChanged += (object sender, Android.Text.TextChangedEventArgs u) => {
                usuario = u.Text.ToString();
            };

            campo_senha.TextChanged += (object sender, Android.Text.TextChangedEventArgs s) => {
                senha = s.Text.ToString();
            };

            campo_nome.TextChanged += (object sender, Android.Text.TextChangedEventArgs n) => {
                nome = n.Text.ToString();
            };

            campo_e_mail.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                email = e.Text.ToString();
            };

            campo_dt_nascimento.TextChanged += (object sender, Android.Text.TextChangedEventArgs n) => {
                nascimento = n.Text.ToString();
            };

            campo_telefone.TextChanged += (object sender, Android.Text.TextChangedEventArgs t) => {
                telefone = t.Text.ToString();
            };

            //Inserir informa��es no banco, por�m antes checar persist�ncia
            
            //Choose Picture button click action
            botao_avan�ar.Click += delegate {
                //Criando dicion�rio com as informa��es inseridas do usu�rio
                //Criar metodo
                Dictionary<string, string> informacoes = new Dictionary<string, string>();
                informacoes["id"] = usuario;
                informacoes["senha"] = senha;
                informacoes["email"] = email;
                informacoes["nome"] = nome;
                informacoes["telefone"] = telefone;
                informacoes["nascimento"] = nascimento;
                //Criando o objeto aluno
                Aluno aluno = new Aluno(informacoes);
                aluno.commit();

                var escolherfotoactivity = new Intent(this, typeof(EscolherFotoActivity));
                escolherfotoactivity.PutExtra("aluno", aluno.toBundle());
                StartActivity(escolherfotoactivity);
            };

            //TODO Configurar recep��o das informa��es nos campos
        }
    }
}


