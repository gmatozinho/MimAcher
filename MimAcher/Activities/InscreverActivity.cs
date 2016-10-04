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


namespace MimAcher
{
    [Activity(Label = "InscreverActivity", Theme = "@style/Theme.Splash")]
    public class InscreverActivity : Activity
    {
        //Initializing variables from layout
        string usuario = null;
        string senha = null;
        string nome = "Fulano";
        string email = null;
        string nascimento = null;
        string telefone = null;
        View line_fim_curso;
        EditText campo_dt_fim_curso;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Inscrever);

            Spinner tipo_usuario = FindViewById<Spinner>(Resource.Id.user_type);
            Spinner campus = FindViewById<Spinner>(Resource.Id.campus);
            Button botao_avançar = FindViewById<Button>(Resource.Id.avançar);
            EditText campo_usuario = FindViewById<EditText>(Resource.Id.usuario);
            EditText campo_senha = FindViewById<EditText>(Resource.Id.senha);
            EditText campo_nome = FindViewById<EditText>(Resource.Id.nome);
            EditText campo_e_mail = FindViewById<EditText>(Resource.Id.email);
            EditText campo_dt_nascimento = FindViewById<EditText>(Resource.Id.dt_nascimento);
            EditText campo_telefone = FindViewById<EditText>(Resource.Id.telefone);
            campo_dt_fim_curso = FindViewById<EditText>(Resource.Id.dt_fimcurso);
            line_fim_curso = FindViewById<View>(Resource.Id.conclusão_curso_line);

            //Escolhendo o Campus
            var opcoes_campus = new List<string>() { "Serra", "Vitória", "Vila Velha" };
            var adapter_campus = new ArrayAdapter<string>(this, Resource.Drawable.spinner_item, opcoes_campus);
            adapter_campus.SetDropDownViewResource(Resource.Drawable.spinner_dropdown_item);
            campus.Adapter = adapter_campus;
            var escolha_campus = campus.SelectedItem;
            campus.ItemSelected += spinner_ItemSelected_campus;


            //Escolhendo tipo de usuário
            var opcoes_tipo_usuario = new List<string>() { "Aluno", "Ex-Aluno", "Professor" };
            var adapter_tipo_usuario = new ArrayAdapter<string>(this, Resource.Drawable.spinner_item, opcoes_tipo_usuario);
            adapter_tipo_usuario.SetDropDownViewResource(Resource.Drawable.spinner_dropdown_item);
            tipo_usuario.Adapter = adapter_tipo_usuario;
            tipo_usuario.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected_tipo_usuario);

            //Pegar as informações inseridas
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
            //TODO Pegar informações de data fim curso e do tipo de usuário e campus
            
            

            botao_avançar.Click += delegate {
                Participante participante = this.CriarParticipante();
                participante.Commit();

                var escolherfotoactivity = new Intent(this, typeof(EscolherFotoActivity));
                escolherfotoactivity.PutExtra("member", participante.ParticipanteToBundle());
                StartActivity(escolherfotoactivity);
            };

        }

        
         private void spinner_ItemSelected_campus(object sender, AdapterView.ItemSelectedEventArgs e)        
         {
             Spinner campus = (Spinner)sender;

             string toast = string.Format("Campus selecionado: {0}", campus.GetItemAtPosition(e.Position));        
             Toast.MakeText(this, toast, ToastLength.Long).Show();
        
        }


        private void spinner_ItemSelected_tipo_usuario(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner tipo_usuario = (Spinner)sender;

            string toast = string.Format("Tipo Usuário selecionado: {0}", tipo_usuario.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();

            var escolha_tipo_usuario = tipo_usuario.SelectedItem;
            if (escolha_tipo_usuario.ToString() == "Aluno")
            {
                campo_dt_fim_curso.Visibility = ViewStates.Visible;
                line_fim_curso.Visibility = ViewStates.Visible;
            }
            else
            {
                campo_dt_fim_curso.Visibility = ViewStates.Invisible;
                line_fim_curso.Visibility = ViewStates.Invisible;
            }
        }

        private Participante CriarParticipante()
        {
            Dictionary<string, string> informacoes = new Dictionary<string, string>();
            informacoes["id"] = usuario;
            informacoes["senha"] = senha;
            informacoes["email"] = email;
            informacoes["nome"] = nome;
            informacoes["telefone"] = telefone;
            informacoes["nascimento"] = nascimento;

            Participante participante = new Participante(informacoes);

            return participante;
        }
    }
}


