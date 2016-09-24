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
using MimAcher.Entidades;
using MimAcher.Activities;

namespace MimAcher
{
    [Activity(Label = "EditarPerfilActivity", Theme = "@style/Theme.Splash")]
    public class EditarPerfilActivity : Activity
    {
        string email;
        string nascimento;
        string telefone;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Bundle aluno_bundle = Intent.GetBundleExtra("aluno");
            Aluno aluno = AlunoFactory.CriarAluno(aluno_bundle);

            // Create your application here
            SetContentView(Resource.Layout.EditarPerfil);

            Button nome_user = FindViewById<Button>(Resource.Id.nome_user);
            Button salvar = FindViewById<Button>(Resource.Id.salvar);
            Button alterar_senha = FindViewById<Button>(Resource.Id.alterar_senha);
            EditText telefone_info_user = FindViewById<EditText>(Resource.Id.tel_number_user);
            EditText email_info_user = FindViewById<EditText>(Resource.Id.email_info_user);
            EditText dt_nascimento_info_user = FindViewById<EditText>(Resource.Id.dt_nascimento_info_user);

            nome_user.Text = aluno.Nome;
            telefone_info_user.Hint = aluno.Telefone;
            email_info_user.Hint = aluno.Email;
            dt_nascimento_info_user.Hint = aluno.Nascimento;

            //Para alterar
            email = aluno.Email;
            telefone = aluno.Telefone;
            nascimento = aluno.Nascimento;

            //Pegar as informações inseridas
            email_info_user.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
                email = e.Text.ToString();
            };

            dt_nascimento_info_user.TextChanged += (object sender, Android.Text.TextChangedEventArgs n) => {
                nascimento = n.Text.ToString();
            };

            telefone_info_user.TextChanged += (object sender, Android.Text.TextChangedEventArgs t) => {
                telefone = t.Text.ToString();
            };


            alterar_senha.Click += delegate {
                var alterarsenhaactivity = new Intent(this, typeof(AlterarSenhaActivity));
                //mudar para trabalhar com objeto do banco
                alterarsenhaactivity.PutExtra("aluno", aluno_bundle);
                StartActivity(alterarsenhaactivity);
            };

            salvar.Click += delegate {
                var resultadoactivity = new Intent(this, typeof(ResultadoActivity));
                //mudar para trabalhar com objeto do banco
                //deverá rolar um commit para salvar alterações no banco
                AlterarAluno(aluno);
                resultadoactivity.PutExtra("aluno", aluno.ToBundle());
                StartActivity(resultadoactivity);
            };



            //Mostrar as informações do usuário retiradas do banco
        }
        private void AlterarAluno(Aluno aluno)
        {
            aluno.Email = email;
            aluno.Telefone = telefone;
            aluno.Nascimento = nascimento;
        }
    }
}