using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Entidades;
using MimAcher.Mobile.Entidades.Fabricas;
using MimAcher.Mobile.Utilitarios;

namespace MimAcher.Mobile.Activities
{
    [Activity(Label = "MimAcher", Theme = "@style/Theme.Splash")]
    public class MainActivity : FabricaTelasNormaisSemProcedimento
    {
        
        //Variaveis globais
        //até comunicar com o banco informações hipotéticas
        private readonly string _campus = "Serra";
        private readonly string _senha = null;
        private readonly string _nome = "Gustavo";
        private readonly string _email = null;
        private readonly string _nascimento = "09/10/1995";
        private readonly string _telefone = "00000000";
        private string _emailInserido;
        private string _senhaInserida;
        
        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Main);

            //Iniciando as variaveis do contexto
            var campoEmail = FindViewById<EditText>(Resource.Id.email);
            var campoSenha = FindViewById<EditText>(Resource.Id.senha);
            var entrar = FindViewById<Button>(Resource.Id.entrar);
            var inscrevase = FindViewById<Button>(Resource.Id.inscrevase);

            //Funcionalidades
            //Resgatando o que foi digitado nos EditText
            campoEmail.TextChanged += (sender, texto) => _emailInserido = texto.Text.ToString();
            campoSenha.TextChanged += (sender, texto) => _senhaInserida = texto.Text.ToString();

            entrar.Click += delegate
            {
                Usuario.Login(_emailInserido, _senhaInserida);
                var participante = new Participante(MontarUsuário());
                IniciarHome(this,participante);
            };

            //Tenho que fazer a autenticação no banco de dados
            //Ideia é buscar usuario no banco, se existir retorna true e checa senha, se nao retorna usuario inexistente
            //Busca senha neste mesmo usuario, se for igual retorna true se nao retorna senha invalida

            inscrevase.Click += delegate {
                IniciarInscrever();
            };
        }

        
        //função temporaria
        //deve pegar o usuario no banco
        private Dictionary<string, string> MontarUsuário()
        {
            var informacoes = new Dictionary<string, string>
            {
                ["campus"] = _campus,
                ["senha"] = _senha,
                ["email"] = _email,
                ["nome"] = _nome,
                ["telefone"] = _telefone,
                ["nascimento"] = _nascimento
            };

            return informacoes;
        }

    }
}

